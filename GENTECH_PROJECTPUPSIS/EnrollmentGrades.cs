using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector; 

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentGrades : UserControl
    {
        // Replace this with the ID of the currently logged-in student later

        public EnrollmentGrades()
        {
            InitializeComponent();

            // Check if a student is logged in, then load their specific data
            if (UserSession.IsEnrollmentStaff())
            {
                // Use the global ID directly from the session
                LoadGradesFromDatabase(UserSession.StudentID ?? 0);
            }
            else
            {
                MessageBox.Show("No student session found.");
            }
        }

        private void LoadGradesFromDatabase(int studentId)
        {
            kryptonDataGridView2.Rows.Clear(); // Clear any existing rows

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    // This query uses JOINs to get the text names associated with your IDs.
                    // Note: You may need to adjust the JOINs depending on how Assessment_ID links to Courses!
                    string query = @"
                    SELECT 
                        c.Course_Code, 
                        c.Course_Name, 
                        c.Units, 
                        CONCAT(f.First_Name, ' ', f.Last_Name) AS Faculty, 
                        g.Score AS Grade
                    FROM grades g
                    LEFT JOIN assessment a ON g.Assessment_ID = a.Assessment_ID
                    LEFT JOIN schedule s ON a.Schedule_ID = s.Schedule_ID
                    LEFT JOIN course c ON s.Course_ID = c.Course_ID
                    LEFT JOIN faculty f ON s.Faculty_ID = f.Faculty_ID
                    WHERE g.Student_ID = @StudentId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Use ternary operators to check for DBNull safely
                                string code = reader["Course_Code"] != DBNull.Value ? reader["Course_Code"].ToString() : "N/A";
                                string description = reader["Course_Name"] != DBNull.Value ? reader["Course_Name"].ToString() : "Unknown Course";
                                double units = reader["Units"] != DBNull.Value ? Convert.ToDouble(reader["Units"]) : 0.0;
                                string faculty = reader["Faculty"] != DBNull.Value ? reader["Faculty"].ToString() : "TBA";
                                double grade = reader["Grade"] != DBNull.Value ? Convert.ToDouble(reader["Grade"]) : 0.0;

                                string status = DetermineGradeStatus(grade);

                                kryptonDataGridView2.Rows.Add(code, description, units, faculty, grade, status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load grades: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DetermineGradeStatus(double grade)
        {
            if (grade >= 1.0 && grade <= 3.0)
            {
                return "Passed";
            }
            else if (grade == 5.0)
            {
                return "Failed";
            }
            else if (grade == 0.0) 
            {
                return "INC";
            }

            return "Withdrawn/Unknown";
        }
    }
}