using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminModifyEnrollment : UserControl
    {
        private static string connectionString = "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        private string currentStudentID = "";
        private int currentEnrollmentID = 0;
        private int currentSemesterID = 1;

        public AdminModifyEnrollment()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            if (dvgModifyEnrollment == null) return;

            dvgModifyEnrollment.Columns.Clear();

            // Checkbox column
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Width = 40;

            // Hidden Course ID column
            DataGridViewTextBoxColumn courseId = new DataGridViewTextBoxColumn();
            courseId.Name = "Course_ID";
            courseId.Visible = false;

            // Hidden Enrollment Detail ID column
            DataGridViewTextBoxColumn detailId = new DataGridViewTextBoxColumn();
            detailId.Name = "Detail_ID";
            detailId.Visible = false;

            // Subject Code
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.HeaderText = "Subject Code";
            code.Width = 120;

            // Description
            DataGridViewTextBoxColumn desc = new DataGridViewTextBoxColumn();
            desc.HeaderText = "Description";
            desc.Width = 250;

            // Units
            DataGridViewTextBoxColumn units = new DataGridViewTextBoxColumn();
            units.HeaderText = "Units";
            units.Width = 60;

            // Schedule
            DataGridViewTextBoxColumn sched = new DataGridViewTextBoxColumn();
            sched.HeaderText = "Schedule";
            sched.Width = 200;

            dvgModifyEnrollment.Columns.AddRange(new DataGridViewColumn[] { chk, courseId, detailId, code, desc, units, sched });

            dvgModifyEnrollment.AllowUserToAddRows = false;
            dvgModifyEnrollment.RowHeadersVisible = false;
            dvgModifyEnrollment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtStudentID?.Text?.Trim();

            if (string.IsNullOrEmpty(searchValue) || searchValue == "Student ID")
            {
                MessageBox.Show("Please enter a Student ID or Email");
                return;
            }

            SearchStudent(searchValue);
        }

        private void SearchStudent(string studentID)
        {
            string query = @"
                SELECT 
                    s.Student_ID,
                    CONCAT(s.First_Name, ' ', s.Last_Name) as FullName,
                    p.Program_Name,
                    'Section A' as Section_Name,
                    s.Year_Level
                FROM student s
                LEFT JOIN program p ON s.Program_ID = p.Program_ID
                WHERE s.Student_ID = @studentID OR s.Email = @studentID
                LIMIT 1";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentStudentID = reader["Student_ID"].ToString();

                                if (lblName != null) lblName.Text = reader["FullName"].ToString();
                                if (lblProgram != null) lblProgram.Text = reader["Program_Name"]?.ToString() ?? "N/A";
                                if (lblStudentID != null) lblStudentID.Text = "ID: " + currentStudentID;

                                if (lblName != null) lblName.Visible = true;
                                if (lblProgram != null) lblProgram.Visible = true;
                                if (lblStudentID != null) lblStudentID.Visible = true;

                                LoadStudentEnrolledSubjects();

                                EnableButtons(true);
                            }
                            else
                            {
                                MessageBox.Show("Student not found!");
                                ClearAll();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStudentEnrolledSubjects()
        {
            if (dvgModifyEnrollment == null) return;

            dvgModifyEnrollment.Rows.Clear();

            currentEnrollmentID = GetOrCreateEnrollment(currentStudentID, currentSemesterID);
            if (currentEnrollmentID == 0) return;

            // Simplified query - get enrollment details
            string query = @"
        SELECT 
            ed.Enrollment_Detail_ID,
            c.Course_ID,
            c.Course_Code,
            c.Course_Name,
            c.Units
        FROM enrollment_details ed
        JOIN enrollment e ON ed.Enrollment_ID = e.Enrollment_ID
        JOIN schedule s ON ed.Schedule_ID = s.Schedule_ID
        JOIN course c ON s.Course_ID = c.Course_ID
        WHERE e.Enrollment_ID = @enrollmentID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@enrollmentID", currentEnrollmentID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int totalUnits = 0;

                            while (reader.Read())
                            {
                                int units = reader.GetInt32("Units");
                                totalUnits += units;

                                dvgModifyEnrollment.Rows.Add(
                                    false,  // Checkbox
                                    reader["Course_ID"].ToString(),
                                    reader["Enrollment_Detail_ID"].ToString(),
                                    reader["Course_Code"].ToString(),
                                    reader["Course_Name"].ToString(),
                                    units,
                                    "TBA"  // Schedule placeholder
                                );
                            }

                            UpdateSummaryLabels(totalUnits);

                            if (totalUnits == 0)
                            {
                                // No subjects enrolled yet
                                lblUnitsEnrolled.Text = "0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }

        private int GetOrCreateEnrollment(string studentID, int semesterID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if enrollment exists
                string checkQuery = "SELECT Enrollment_ID FROM enrollment WHERE Student_ID = @studentID AND Semester_ID = @semesterID";
                using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@semesterID", semesterID);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                // Create new enrollment
                string insertQuery = @"INSERT INTO enrollment (Student_ID, Semester_ID, Enrollment_Date, Enrollment_Status) 
                               VALUES (@studentID, @semesterID, @date, 'Active')";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@semesterID", semesterID);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                // Get new enrollment ID
                using (MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentStudentID))
            {
                MessageBox.Show("Please search for a student first!");
                return;
            }

            // Create a simple selection form
            Form pickForm = new Form();
            pickForm.Text = "Select Subject to Add";
            pickForm.Size = new Size(500, 400);
            pickForm.StartPosition = FormStartPosition.CenterScreen;
            pickForm.BackColor = Color.White;

            // Create ListBox to show subjects
            ListBox listSubjects = new ListBox();
            listSubjects.Dock = DockStyle.Fill;
            listSubjects.Font = new Font("Segoe UI", 11);
            listSubjects.Height = 300;

            // Store course IDs in a parallel list
            List<int> courseIds = new List<int>();
            List<int> scheduleIds = new List<int>();

            // Load courses from database
            string courseQuery = @"
        SELECT 
            c.Course_ID,
            c.Course_Code,
            c.Course_Name,
            c.Units,
            s.Schedule_ID
        FROM course c
        LEFT JOIN schedule s ON c.Course_ID = s.Course_ID
        WHERE s.Schedule_ID IS NOT NULL";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(courseQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string display = $"{reader["Course_Code"]} - {reader["Course_Name"]} ({reader["Units"]} units)";
                                listSubjects.Items.Add(display);
                                courseIds.Add(reader.GetInt32("Course_ID"));
                                scheduleIds.Add(reader.GetInt32("Schedule_ID"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
                return;
            }

            if (listSubjects.Items.Count == 0)
            {
                MessageBox.Show("No courses available. Please add courses and schedules first.");
                return;
            }

            // Button panel at bottom
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 60;
            buttonPanel.BackColor = Color.White;

            Button btnAdd = new Button();
            btnAdd.Text = "Add Selected Subject";
            btnAdd.Size = new Size(200, 40);
            btnAdd.Location = new Point(150, 10);
            btnAdd.BackColor = Color.Maroon;
            btnAdd.ForeColor = Color.White;
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.FlatStyle = FlatStyle.Flat;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(360, 10);
            btnCancel.BackColor = Color.Gray;
            btnCancel.ForeColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 10);
            btnCancel.FlatStyle = FlatStyle.Flat;

            btnAdd.Click += (s, ev) =>
            {
                if (listSubjects.SelectedIndex >= 0)
                {
                    int selectedIndex = listSubjects.SelectedIndex;
                    int courseID = courseIds[selectedIndex];
                    int scheduleID = scheduleIds[selectedIndex];
                    string selectedSubject = listSubjects.SelectedItem.ToString();

                    // Check if already enrolled
                    string checkQuery = @"
                SELECT COUNT(*) 
                FROM enrollment_details ed
                JOIN schedule s ON ed.Schedule_ID = s.Schedule_ID
                WHERE ed.Enrollment_ID = @enrollmentID AND s.Course_ID = @courseID";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@enrollmentID", currentEnrollmentID);
                            cmd.Parameters.AddWithValue("@courseID", courseID);
                            int exists = Convert.ToInt32(cmd.ExecuteScalar());

                            if (exists > 0)
                            {
                                MessageBox.Show("This subject is already enrolled!", "Duplicate",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Add to enrollment_details
                    string insertQuery = "INSERT INTO enrollment_details (Enrollment_ID, Schedule_ID) VALUES (@enrollmentID, @scheduleID)";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@enrollmentID", currentEnrollmentID);
                            cmd.Parameters.AddWithValue("@scheduleID", scheduleID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Refresh the grid
                    LoadStudentEnrolledSubjects();

                    pickForm.Close();
                    MessageBox.Show($"Added: {selectedSubject}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a subject to add.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnCancel.Click += (s, ev) => { pickForm.Close(); };

            buttonPanel.Controls.Add(btnAdd);
            buttonPanel.Controls.Add(btnCancel);

            pickForm.Controls.Add(listSubjects);
            pickForm.Controls.Add(buttonPanel);
            pickForm.ShowDialog();
        }

        private void btnDropSubjects_Click(object sender, EventArgs e)
        {
            List<int> detailIDsToDelete = new List<int>();

            for (int i = dvgModifyEnrollment.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dvgModifyEnrollment.Rows[i];
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    int detailID = Convert.ToInt32(row.Cells[2].Value);
                    detailIDsToDelete.Add(detailID);
                }
            }

            if (detailIDsToDelete.Count == 0)
            {
                MessageBox.Show("Please check the subjects you want to drop.");
                return;
            }

            if (MessageBox.Show($"Drop {detailIDsToDelete.Count} subject(s)?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (int detailID in detailIDsToDelete)
                    {
                        string query = "DELETE FROM enrollment_details WHERE Enrollment_Detail_ID = @detailID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@detailID", detailID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                LoadStudentEnrolledSubjects();
                MessageBox.Show("Subject(s) dropped successfully!");
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int totalUnits = 0;
            foreach (DataGridViewRow row in dvgModifyEnrollment.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    totalUnits += Convert.ToInt32(row.Cells[5].Value);
                }
            }

            MessageBox.Show($"Enrollment saved!\nTotal Units: {totalUnits}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // When user clicks into the textbox
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "Student ID")
            {
                txtStudentID.Text = "";
                txtStudentID.StateCommon.Content.Color1 = Color.Black;
            }
        }

        // When user leaves the textbox
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                txtStudentID.Text = "Student ID";
                txtStudentID.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            dvgModifyEnrollment?.Rows.Clear();

            if (lblName != null) lblName.Visible = false;
            if (lblProgram != null) lblProgram.Visible = false;
            if (lblStudentID != null) lblStudentID.Visible = false;

            if (lblStatus != null) lblStatus.Text = "--";
            if (lblUnitsOverload != null) lblUnitsOverload.Text = "--";
            if (lblUnitsEnrolled != null) lblUnitsEnrolled.Text = "--";
            if (lblUnitsAllowed != null) lblUnitsAllowed.Text = "--";

            if (txtStudentID != null)
            {
                txtStudentID.Text = "Student ID";
            }

            EnableButtons(false);
            currentStudentID = "";
            currentEnrollmentID = 0;
        }

        private void EnableButtons(bool enabled)
        {
            if (btnClear != null) btnClear.Enabled = enabled;
            if (btnAddSubjects != null) btnAddSubjects.Enabled = enabled;
            if (btnDropSubjects != null) btnDropSubjects.Enabled = enabled;
            if (btnSaveChanges != null) btnSaveChanges.Enabled = enabled;
        }

        private void UpdateSummaryLabels(int totalUnits)
        {
            int maxUnits = 23;
            int overload = totalUnits > maxUnits ? totalUnits - maxUnits : 0;

            if (lblUnitsEnrolled != null) lblUnitsEnrolled.Text = totalUnits.ToString();
            if (lblUnitsAllowed != null) lblUnitsAllowed.Text = maxUnits.ToString();
            if (lblUnitsOverload != null) lblUnitsOverload.Text = overload.ToString();
            if (lblStatus != null) lblStatus.Text = overload > 0 ? "Overload" : "Regular";
        }

        // Helper class for course items
        private class CourseItem
        {
            public int ID { get; set; }
            public string Display { get; set; }

            public override string ToString()
            {
                return Display;
            }
        }

       
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
       

}