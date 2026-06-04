using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentHome : UserControl
    {
        public EnrollmentHome()
        {
            InitializeComponent();
        }

        private void EnrollmentHome_Load(object sender, EventArgs e)
        {
            // Display enrollment staff information
            DisplayStaffInfo();

            // Display current date
            DisplayCurrentDate();

            // Load enrolled subjects
            LoadEnrolledSubjects();

            // Load student statistics or counts
            LoadEnrollmentStats();
        }

        private void DisplayStaffInfo()
        {
            // Check if user is logged in
            if (!UserSession.IsLoggedIn || !UserSession.IsEnrollmentStaff())
            {
                MessageBox.Show("Session expired. Please login again.",
                    "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Display staff welcome message
            lblEnrollmentName.Text = $"Welcome, {UserSession.GetFullName()}!";
            lblCourseSection.Text = $"{UserSession.ProgramCode} {UserSession.YearLevel}-{UserSession.Section}";


            // Since enrollment staff are also students, show their student info

            // Display in a formatted label if you have one

        }

        private void DisplayCurrentDate()
        {
        
        }


           
        private void LoadEnrolledSubjects()
        {
            // You can load subjects from database based on the enrollment staff's student ID
            if (!UserSession.IsEnrollmentStaff()) return;

            // Option 1: Load dummy data (your current implementation)
            LoadDummySubjects();

            // Option 2: Load from database (uncomment and use this instead)
            // LoadSubjectsFromDatabase(UserSession.EnrollmentStudentID ?? 0);
        }

        private void LoadDummySubjects()
        {
            dvgEnrolled.Rows.Clear();

            DummiesBasicToKungfu("Comp 001", "Object-Oriented Programming", 3);
            DummiesBasicToKungfu("Comp 002", "Data Structures and Algorithms", 3);
            DummiesBasicToKungfu("Comp 003", "Database Management Systems", 3);
            DummiesBasicToKungfu("Comp 004", "Web Development", 3);
            DummiesBasicToKungfu("Comp 005", "Computer Networks", 3);
            DummiesBasicToKungfu("Comp 006", "Software Engineering", 3);
            DummiesBasicToKungfu("Comp 007", "Operating Systems", 3);
            DummiesBasicToKungfu("Comp 008", "Human-Computer Interaction", 2);
        }

        private void LoadSubjectsFromDatabase(int studentId)
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

                string query = @"SELECT s.Subject_Code, s.Subject_Description, s.Units 
                                FROM enrolled_subjects es
                                INNER JOIN subjects s ON es.Subject_ID = s.Subject_ID
                                WHERE es.Student_ID = @studentId
                                AND es.Semester = @semester
                                AND es.Academic_Year = @academicYear";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semester", "1st"); // or get from session
                        cmd.Parameters.AddWithValue("@academicYear", "2024-2025"); // or calculate dynamically

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dvgEnrolled.Rows.Clear();

                            while (reader.Read())
                            {
                                string code = reader["Subject_Code"].ToString();
                                string description = reader["Subject_Description"].ToString();
                                int units = Convert.ToInt32(reader["Units"]);

                                DummiesBasicToKungfu(code, description, units);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEnrollmentStats()
        {
            // Display enrollment statistics if you have labels for them
            try
            {
                string connectionString = "server=localhost;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get total enrolled students
                   

                    // Get total subjects
                   

                    // Get total units
                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading stats: {ex.Message}");
            }
        }

        private void DummiesBasicToKungfu(string code, string description, int unit)
        {
            int index = dvgEnrolled.Rows.Add();
            DataGridViewRow row = dvgEnrolled.Rows[index];

            row.Cells[0].Value = code;
            row.Cells[1].Value = description;
            row.Cells[2].Value = unit;
        }

        private void btnEnrollNow_Click(object sender, EventArgs e)
        {
            // Check if user has permission to enroll
            if (!UserSession.IsEnrollmentStaff())
            {
                MessageBox.Show("You don't have permission to access enrollment.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Log the action
            LogAction("Clicked Enroll Now button");

            // Navigate to enrollment confirmation
            EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
            if (main != null)
            {
                main.LoadControl(new EnrollmentConfirmation());
            }
        }

        private void lblDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PNG Image|*.png";
            save.Title = "Save Image";
            save.FileName = $"COR_{UserSession.EnrollmentStudentID}_{DateTime.Now:yyyyMMdd}.png";

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName,
                System.Drawing.Imaging.ImageFormat.Png);

                LogAction($"Downloaded COR to {save.FileName}");

                MessageBox.Show(
                 "Image saved successfully!",
                 "Success",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
             );
            }
        }

        private void LogAction(string action)
        {
            // Optional: Log user actions
            if (UserSession.IsLoggedIn)
            {
                Console.WriteLine($"[{DateTime.Now}] {UserSession.GetFullName()} " +
                                $"(Staff ID: {UserSession.CredentialID}): {action}");

                // You can also log to database here
            }
        }

        // Optional: Add a refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EnrollmentHome_Load(sender, e);
        }
    }
}