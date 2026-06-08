using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentConfirmation : UserControl
    {
        private string connectionString = "server=localhost;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        public EnrollmentConfirmation()
        {
            InitializeComponent();
        }

        private void EnrollmentConfirmation_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAvailableSubjects();
            LoadStudentInfo();

        }

        private void GetCurrentSchoolYear()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (month >= 6) 
            {
                lblAY.Text = $"AY {year}-{year + 1}";
            }
            else 
            {
                lblAY.Text = $"AY {year - 1}-{year}";
            }
        }

        private void LoadStudentInfo()
        {
            lblName.Text = UserSession.GetFullName() ?? "John Doe";
            lblProgram.Text = UserSession.ProgramName ?? "Bachelor of Science in Computer Science";
            GetCurrentAcademicYear();
            lblSemester.Text = GetCurrentSemester();
        }
        private void LoadAvailableSubjects()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int programId = UserSession.ProgramID ?? 0;
                    int yearLevel = UserSession.YearLevel ?? 1;
                    string semester = GetCurrentSemester();
                    string academicYear = GetCurrentAcademicYear();
                    int studentId = UserSession.EnrollmentStudentID ?? 0;

                    // Get courses not yet enrolled by the student
                    string query = @"SELECT 
                                        c.Course_ID,
                                        c.Course_Code,
                                        c.Course_Name,
                                        c.Units
                                    FROM course c
                                    WHERE c.Program_ID = @programId
                                    AND c.Course_ID NOT IN (
                                        SELECT es.Course_ID 
                                        FROM enrolled_subjects es
                                        JOIN enrollment e ON es.Enrollment_ID = e.Enrollment_ID
                                        JOIN semester sem ON e.Semester_ID = sem.Semester_ID
                                        WHERE e.Student_ID = @studentId
                                        AND sem.Semester_Name = @semester
                                        AND sem.Academic_Year = @academicYear
                                    )
                                    ORDER BY c.Course_Code";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@programId", programId);
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@academicYear", academicYear);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dvgEnrollment.Rows.Clear();

                            while (reader.Read())
                            {
                                string code = reader["Course_Code"].ToString();
                                string name = reader["Course_Name"].ToString();
                                int units = Convert.ToInt32(reader["Units"]);
                                int courseId = Convert.ToInt32(reader["Course_ID"]);

                                // Add row with checkbox unchecked, code, name, units, schedule
                                dvgEnrollment.Rows.Add(false, code, name, units, "MWF • 8:00 AM - 9:00 AM");

                                // Store Course_ID in the row tag for later use
                                dvgEnrollment.Rows[dvgEnrollment.Rows.Count - 1].Tag = courseId;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDummySubjects();
            }
        }

        private void LoadDummySubjects()
        {
            dvgEnrollment.Rows.Clear();
            dvgEnrollment.Rows.Add(false, "IT101", "Introduction to Computing", 3, "MWF • 8:00 AM - 9:00 AM");
            dvgEnrollment.Rows.Add(false, "CS102", "Programming 1", 3, "TTH • 1:00 PM - 2:30 PM");
            dvgEnrollment.Rows.Add(false, "MATH101", "College Algebra", 3, "MWF • 8:00 AM - 9:00 AM");
            dvgEnrollment.Rows.Add(false, "ENG101", "Purposive Communication", 3, "TTH • 1:00 PM - 2:30 PM");
            dvgEnrollment.Rows.Add(false, "NSTP101", "National Service Training Program", 3, "MWF • 8:00 AM - 9:00 AM");
            dvgEnrollment.Rows.Add(false, "PE101", "Physical Fitness", 2, "TTH • 1:00 PM - 2:30 PM");
            dvgEnrollment.Rows.Add(false, "HIST101", "Readings in Philippine History", 3, "MWF • 8:00 AM - 9:00 AM");
            dvgEnrollment.Rows.Add(false, "SCI101", "General Biology", 3, "TTH • 1:00 PM - 2:30 PM");
        }

        private void UpdateTotals()
        {
            int totalUnits = 0;
            int totalSubjects = 0;

            foreach (DataGridViewRow row in dvgEnrollment.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells[0].Value != null && (bool)row.Cells[0].Value;

                if (isChecked)
                {
                    totalSubjects++;

                    if (int.TryParse(row.Cells[3].Value?.ToString(), out int units))
                    {
                        totalUnits += units;
                    }
                }
            }

            lblTotalSubjects.Text = totalSubjects.ToString();
            lblTotalUnits.Text = totalUnits.ToString();
        }

        private void SetupDataGridView()
        {
            dvgEnrollment.Columns.Clear();

            dvgEnrollment.AllowUserToAddRows = false;
            dvgEnrollment.RowHeadersVisible = false;
            dvgEnrollment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgEnrollment.MultiSelect = false;
            dvgEnrollment.RowTemplate.Height = 38;
            dvgEnrollment.BorderStyle = BorderStyle.None;
            dvgEnrollment.BackgroundColor = Color.White;
            dvgEnrollment.GridColor = Color.Gainsboro;

            dvgEnrollment.EnableHeadersVisualStyles = false;
            dvgEnrollment.ColumnHeadersHeight = 42;
            dvgEnrollment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dvgEnrollment.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dvgEnrollment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvgEnrollment.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dvgEnrollment.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dvgEnrollment.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dvgEnrollment.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Checkbox Column
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Width = 50;

            // Subject Code
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.HeaderText = "Subject Code";
            code.Width = 160;

            // Description
            DataGridViewTextBoxColumn desc = new DataGridViewTextBoxColumn();
            desc.HeaderText = "Description";
            desc.Width = 280;

            // Units
            DataGridViewTextBoxColumn units = new DataGridViewTextBoxColumn();
            units.HeaderText = "Units";
            units.Width = 80;

            // Schedule ComboBox
            DataGridViewComboBoxColumn sched = new DataGridViewComboBoxColumn();
            sched.HeaderText = "Schedules";
            sched.Width = 260;
            sched.FlatStyle = FlatStyle.Flat;
            sched.Items.Add("MWF • 8:00 AM - 9:00 AM");
            sched.Items.Add("TTH • 1:00 PM - 2:30 PM");
            sched.Items.Add("MWF • 10:00 AM - 11:00 AM");
            sched.Items.Add("TTH • 3:00 PM - 4:30 PM");

            dvgEnrollment.Columns.Add(chk);
            dvgEnrollment.Columns.Add(code);
            dvgEnrollment.Columns.Add(desc);
            dvgEnrollment.Columns.Add(units);
            dvgEnrollment.Columns.Add(sched);
        }

        private void dvgEnrollment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotals();
        }

        private void dvgEnrollment_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgEnrollment.IsCurrentCellDirty)
            {
                dvgEnrollment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
            main.LoadControl(new EnrollmentHome());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!cxbConfirm.Checked)
            {
                MessageBox.Show(
                    "Please check the confirmation box before you can continue",
                    "Confirmation Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int totalUnits = int.Parse(lblTotalUnits.Text);

            if (totalUnits != 23)
            {
                MessageBox.Show(
                    "You must have exactly 23 units to submit your enrollment.",
                    "Invalid Units",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to submit your enrollment?",
                "Confirm Enrollment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (SubmitEnrollment())
                {
                    MessageBox.Show(
                        "Enrollment successfully submitted!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
                    main.LoadControl(new EnrollmentHome());
                }
            }
        }

        private bool SubmitEnrollment()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;
                    string semester = GetCurrentSemester();
                    string academicYear = GetCurrentAcademicYear();

                    // Get Semester_ID
                    string semQuery = @"SELECT Semester_ID FROM semester 
                                       WHERE Semester_Name = @semester 
                                       AND Academic_Year = @academicYear 
                                       LIMIT 1";

                    int semesterId;
                    using (MySqlCommand semCmd = new MySqlCommand(semQuery, conn))
                    {
                        semCmd.Parameters.AddWithValue("@semester", semester);
                        semCmd.Parameters.AddWithValue("@academicYear", academicYear);
                        semesterId = Convert.ToInt32(semCmd.ExecuteScalar());
                    }

                    // Create enrollment record
                    string enrollQuery = @"INSERT INTO enrollment 
                                          (Student_ID, Semester_ID, Enrollment_Date, Enrollment_Status) 
                                          VALUES (@studentId, @semesterId, @date, 'Enrolled')";

                    long enrollmentId;
                    using (MySqlCommand enrollCmd = new MySqlCommand(enrollQuery, conn))
                    {
                        enrollCmd.Parameters.AddWithValue("@studentId", studentId);
                        enrollCmd.Parameters.AddWithValue("@semesterId", semesterId);
                        enrollCmd.Parameters.AddWithValue("@date", DateTime.Now);
                        enrollCmd.ExecuteNonQuery();
                        enrollmentId = enrollCmd.LastInsertedId;
                    }

                    // Insert selected subjects into enrolled_subjects
                    foreach (DataGridViewRow row in dvgEnrollment.Rows)
                    {
                        if (row.IsNewRow) continue;

                        bool isChecked = row.Cells[0].Value != null && (bool)row.Cells[0].Value;

                        if (isChecked && row.Tag != null)
                        {
                            int courseId = Convert.ToInt32(row.Tag);

                            string subjectQuery = @"INSERT INTO enrolled_subjects 
                                                   (Enrollment_ID, Course_ID) 
                                                   VALUES (@enrollmentId, @courseId)";

                            using (MySqlCommand subjCmd = new MySqlCommand(subjectQuery, conn))
                            {
                                subjCmd.Parameters.AddWithValue("@enrollmentId", enrollmentId);
                                subjCmd.Parameters.AddWithValue("@courseId", courseId);
                                subjCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting enrollment: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GetCurrentSemester()
        {
            int month = DateTime.Now.Month;
            if (month >= 8 && month <= 12) return "1st Semester";
            else if (month >= 1 && month <= 5) return "2nd Semester";
            else return "Summer";
        }

        private string GetCurrentAcademicYear()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month >= 6) return $"{year}-{year + 1}";
            else return $"{year - 1}-{year}";
        }
    }
}