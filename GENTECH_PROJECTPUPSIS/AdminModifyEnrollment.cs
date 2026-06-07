using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // Change to this

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminModifyEnrollment : UserControl
    {
        private static string connectionString = "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        private string currentStudentID = "";
        private int currentEnrollmentID = 0;
        private int currentSemesterID = 0;
        public AdminModifyEnrollment()
        {
            InitializeComponent();
            SetupDataGridView();

            currentSemesterID = GetCurrentSemesterID();
            // Add this event to handle checkbox clicks
            dvgModifyEnrollment.CellClick += DvgModifyEnrollment_CellClick;
            dvgModifyEnrollment.CurrentCellDirtyStateChanged += DvgModifyEnrollment_CurrentCellDirtyStateChanged;
        }

        private int GetCurrentSemesterID()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get the current date
                    DateTime today = DateTime.Now;

                    // Find the semester that includes today's date
                    string query = @"SELECT Semester_ID, Semester_Name, Academic_Year 
                            FROM semester 
                            WHERE Start_Date <= @today AND End_Date >= @today
                            ORDER BY Semester_ID DESC 
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int semesterId = Convert.ToInt32(reader["Semester_ID"]);
                                string semesterName = reader["Semester_Name"].ToString();
                                string academicYear = reader["Academic_Year"].ToString();

                                // Optional: Show what semester is active
                                Console.WriteLine($"Active Semester: {semesterName} ({academicYear}) - ID: {semesterId}");

                                return semesterId;
                            }
                        }
                    }

                    // If no semester matches today's date, get the latest semester
                    string fallbackQuery = "SELECT Semester_ID FROM semester ORDER BY Start_Date DESC LIMIT 1";
                    using (MySqlCommand fallbackCmd = new MySqlCommand(fallbackQuery, conn))
                    {
                        object result = fallbackCmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting current semester: " + ex.Message);
            }

            return 1; // Last resort fallback
        }
        // This handles when user clicks the checkbox
        private void DvgModifyEnrollment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only handle clicks on the checkbox column (index 0)
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Toggle the checkbox value
                DataGridViewRow row = dvgModifyEnrollment.Rows[e.RowIndex];
                bool currentValue = row.Cells[0].Value != null && (bool)row.Cells[0].Value;
                row.Cells[0].Value = !currentValue;
                dvgModifyEnrollment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // This ensures the checkbox value is committed immediately
        private void DvgModifyEnrollment_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgModifyEnrollment.IsCurrentCellDirty && dvgModifyEnrollment.CurrentCell.ColumnIndex == 0)
            {
                dvgModifyEnrollment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
        private int GetExistingEnrollment(string studentID, int semesterID)
        {
            string query = @"SELECT Enrollment_ID FROM enrollment 
                    WHERE Student_ID = @studentID AND Semester_ID = @semesterID
                    ORDER BY Enrollment_ID DESC LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@semesterID", semesterID);
                    object result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
        private void LoadStudentEnrolledSubjects()
        {
            dvgModifyEnrollment.Rows.Clear();

            // Find existing enrollment instead of creating one
            currentEnrollmentID = GetExistingEnrollment(currentStudentID, currentSemesterID);

            if (currentEnrollmentID == 0)
            {
                MessageBox.Show("No enrollment found for this student in the current semester.\n" +
                               "Student must enroll first through the Enrollment Confirmation.",
                               "No Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
        SELECT 
            es.Enrolled_Subject_ID,
            c.Course_ID,
            c.Course_Code,
            c.Course_Name,
            c.Units
        FROM enrolled_subjects es
        JOIN course c ON es.Course_ID = c.Course_ID
        WHERE es.Enrollment_ID = @enrollmentID";

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

                                int rowIndex = dvgModifyEnrollment.Rows.Add();
                                DataGridViewRow row = dvgModifyEnrollment.Rows[rowIndex];

                                row.Cells[0].Value = false;                                          // Checkbox
                                row.Cells[1].Value = reader["Course_ID"].ToString();                 // Course_ID (hidden)
                                row.Cells[2].Value = reader["Enrolled_Subject_ID"].ToString();       // Enrolled_Subject_ID (hidden)
                                row.Cells[3].Value = reader["Course_Code"].ToString();               // Subject Code
                                row.Cells[4].Value = reader["Course_Name"].ToString();               // Description
                                row.Cells[5].Value = units;                                          // Units
                                row.Cells[6].Value = "TBA";                                          // Schedule
                            }

                            UpdateSummaryLabels(totalUnits);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }


        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            if (currentEnrollmentID == 0)
            {
                MessageBox.Show("No existing enrollment found. Student must enroll first.",
                    "No Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(currentStudentID))
            {
                MessageBox.Show("Please search for a student first!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form pickForm = new Form();
            pickForm.Text = "Select Subject";
            pickForm.Size = new Size(550, 450);
            pickForm.StartPosition = FormStartPosition.CenterScreen;
            pickForm.BackColor = Color.White;

            DataGridView dgvCourses = new DataGridView();
            dgvCourses.Dock = DockStyle.Top;
            dgvCourses.Height = 320;
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.ReadOnly = true;

            DataTable coursesTable = new DataTable();
            string courseQuery = @"
        SELECT 
            c.Course_ID, 
            c.Course_Code, 
            c.Course_Name, 
            c.Units
        FROM course c";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(courseQuery, conn);
                    adapter.Fill(coursesTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
                return;
            }

            if (coursesTable.Rows.Count == 0)
            {
                MessageBox.Show("No courses available. Please add courses first.");
                return;
            }

            dgvCourses.DataSource = coursesTable;

            if (dgvCourses.Columns["Course_ID"] != null)
                dgvCourses.Columns["Course_ID"].Visible = false;

            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 60;
            buttonPanel.BackColor = Color.White;

            Button btnAdd = new Button();
            btnAdd.Text = "Add Selected Subject";
            btnAdd.Size = new Size(200, 40);
            btnAdd.Location = new Point(175, 10);
            btnAdd.BackColor = Color.Maroon;
            btnAdd.ForeColor = Color.White;
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.FlatStyle = FlatStyle.Flat;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(385, 10);
            btnCancel.BackColor = Color.Gray;
            btnCancel.ForeColor = Color.White;

            btnAdd.Click += (s, ev) =>
            {
                if (dgvCourses.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvCourses.SelectedRows[0];
                    int courseID = Convert.ToInt32(selectedRow.Cells["Course_ID"].Value);
                    string courseCode = selectedRow.Cells["Course_Code"].Value.ToString();
                    string courseName = selectedRow.Cells["Course_Name"].Value.ToString();

                    // Check if already enrolled using enrolled_subjects
                    string checkQuery = @"
                SELECT COUNT(*) 
                FROM enrolled_subjects es
                WHERE es.Enrollment_ID = @enrollmentID AND es.Course_ID = @courseID";

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
                                MessageBox.Show($"{courseCode} is already enrolled!", "Duplicate",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Insert into enrolled_subjects
                    string insertQuery = @"
                INSERT INTO enrolled_subjects (Enrollment_ID, Course_ID) 
                VALUES (@enrollmentID, @courseID)";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@enrollmentID", currentEnrollmentID);
                            cmd.Parameters.AddWithValue("@courseID", courseID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadStudentEnrolledSubjects();
                    pickForm.Close();
                    MessageBox.Show($"Added: {courseCode} - {courseName}", "Success",
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

            pickForm.Controls.Add(dgvCourses);
            pickForm.Controls.Add(buttonPanel);
            pickForm.ShowDialog();
        }

        private void btnDropSubjects_Click(object sender, EventArgs e)
        {
            List<int> rowsToRemove = new List<int>();
            List<string> subjectNames = new List<string>();
            List<int> enrolledSubjectIDsToDelete = new List<int>();

            for (int i = 0; i < dvgModifyEnrollment.Rows.Count; i++)
            {
                DataGridViewRow row = dvgModifyEnrollment.Rows[i];

                bool isChecked = false;
                if (row.Cells[0].Value is bool)
                {
                    isChecked = (bool)row.Cells[0].Value;
                }

                if (isChecked)
                {
                    rowsToRemove.Add(i);
                    subjectNames.Add(row.Cells[3].Value?.ToString() ?? "Unknown");

                    // Get the Enrolled_Subject_ID from hidden column (index 2)
                    if (row.Cells[2].Value != null && !string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    {
                        int enrolledSubjectID = Convert.ToInt32(row.Cells[2].Value);
                        enrolledSubjectIDsToDelete.Add(enrolledSubjectID);
                    }
                }
            }

            if (rowsToRemove.Count == 0)
            {
                MessageBox.Show("Please check the subjects you want to drop.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Drop {rowsToRemove.Count} subject(s)?\n\n{string.Join("\n", subjectNames)}",
                "Confirm Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete from enrolled_subjects table
                if (enrolledSubjectIDsToDelete.Count > 0)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            foreach (int enrolledSubjectID in enrolledSubjectIDsToDelete)
                            {
                                string deleteQuery = "DELETE FROM enrolled_subjects WHERE Enrolled_Subject_ID = @id";
                                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", enrolledSubjectID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Remove from grid
                for (int i = rowsToRemove.Count - 1; i >= 0; i--)
                {
                    dvgModifyEnrollment.Rows.RemoveAt(rowsToRemove[i]);
                }

                // Recalculate total units
                int totalUnits = 0;
                foreach (DataGridViewRow row in dvgModifyEnrollment.Rows)
                {
                    if (row.Cells[5].Value != null)
                    {
                        int units;
                        if (int.TryParse(row.Cells[5].Value.ToString(), out units))
                        {
                            totalUnits += units;
                        }
                    }
                }
                UpdateSummaryLabels(totalUnits);

                MessageBox.Show($"Successfully dropped {rowsToRemove.Count} subject(s)!\nRemaining units: {totalUnits}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int totalUnits = 0;
            foreach (DataGridViewRow row in dvgModifyEnrollment.Rows)
            {
                if (row.Cells[5].Value != null)  // Units is now index 5
                {
                    totalUnits += Convert.ToInt32(row.Cells[5].Value);
                }
            }

            MessageBox.Show($"Enrollment saved!\nTotal Units: {totalUnits}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();

            // Reset the search textbox to placeholder
            txtStudentID.Text = "Student ID";
            txtStudentID.StateCommon.Content.Color1 = Color.DarkGray;
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

   
        // Handle when user clicks into the textbox
        // Handle when user clicks into the textbox
        private void txtStudentID_Enter(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "Student ID")
            {
                txtStudentID.Text = "";
                txtStudentID.StateCommon.Content.Color1 = Color.Black;
                txtStudentID.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
        }

        // Handle when user leaves the textbox (if empty, restore placeholder)
        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                txtStudentID.Text = "Student ID";
                txtStudentID.StateCommon.Content.Color1 = Color.DarkGray;
                txtStudentID.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            }
        }

        // Optional: Real-time search as user types (if you want live suggestions)
        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            // If you want to show what user is typing
            if (txtStudentID.Text != "Student ID" && !string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                txtStudentID.StateCommon.Content.Color1 = Color.Black;
                txtStudentID.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
        }
        // Placeholder handlers (remove if not needed)
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}