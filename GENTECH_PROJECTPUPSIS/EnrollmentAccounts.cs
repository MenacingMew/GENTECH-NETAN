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
    public partial class EnrollmentAccounts : UserControl
    {
        private string connectionString = "server=localhost;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        public EnrollmentAccounts()
        {
            InitializeComponent();
        }

        private void EnrollmentAccounts_Load(object sender, EventArgs e)
        {
            LoadStatementOfAccount();
        }

        private void LoadStatementOfAccount()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;

                    // Get current semester
                    string currentSemester = GetCurrentSemester();
                    string currentAcademicYear = GetCurrentAcademicYear();

                    string query = @"SELECT 
                                        soa.Tuition_Fee,
                                        soa.Miscellaneous_Fee,
                                        soa.Registration_Fee,
                                        soa.Laboratory_Fee,
                                        soa.Total_Amount_Due,
                                        sem.Semester_Name,
                                        sem.Academic_Year
                                    FROM statement_of_account soa
                                    JOIN semester sem ON soa.Semester_ID = sem.Semester_ID
                                    WHERE soa.Student_ID = @studentId
                                    AND sem.Semester_Name = @semester
                                    AND sem.Academic_Year = @academicYear
                                    ORDER BY soa.Statement_Of_Account_ID DESC
                                    LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semester", currentSemester);
                        cmd.Parameters.AddWithValue("@academicYear", currentAcademicYear);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal tuition = Convert.ToDecimal(reader["Tuition_Fee"]);
                                decimal misc = Convert.ToDecimal(reader["Miscellaneous_Fee"]);
                                decimal registration = Convert.ToDecimal(reader["Registration_Fee"]);
                                decimal lab = Convert.ToDecimal(reader["Laboratory_Fee"]);
                                decimal totalDue = Convert.ToDecimal(reader["Total_Amount_Due"]);
                                string semester = reader["Semester_Name"].ToString();
                                string academicYear = reader["Academic_Year"].ToString();

                                // Check if free education (total is 0)
                                if (totalDue == 0)
                                {
                                    lbl_misc.Text = "No fees to display";
                                    lbl_totalAmount.Text = "Covered by Free Higher Education Act";
                                   
                                    button11.Visible = false;
                                    kryptonPanel2.Visible = false;
                                }
                                else
                                {
                                    lbl_misc.Text = $"Tuition Fee: ₱{tuition:N2}\n" +
                                                   $"Miscellaneous Fee: ₱{misc:N2}\n" +
                                                   $"Registration Fee: ₱{registration:N2}\n" +
                                                   $"Laboratory Fee: ₱{lab:N2}";
                                    lbl_totalAmount.Text = $"₱{totalDue:N2}";
                                   
                                    button11.Visible = true;
                                    kryptonPanel2.Visible = true;
                                }
                            }
                            else
                            {
                                // No SOA found
                                lbl_misc.Text = "No statement of account found";
                                lbl_totalAmount.Text = "₱0.00";
                               
                                button11.Visible = false;
                                kryptonPanel2.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading account: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCurrentSemester()
        {
            int month = DateTime.Now.Month;
            if (month >= 8 && month <= 12)
                return "1st Semester";
            else if (month >= 1 && month <= 5)
                return "2nd Semester";
            else
                return "Summer";
        }

        private string GetCurrentAcademicYear()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month >= 6)
                return $"{year}-{year + 1}";
            else
                return $"{year - 1}-{year}";
        }

        private void lbl_misc_Click(object sender, EventArgs e)
        {

        }

        private void lbl_totalAmount_Click(object sender, EventArgs e)
        {

        }
    }
}