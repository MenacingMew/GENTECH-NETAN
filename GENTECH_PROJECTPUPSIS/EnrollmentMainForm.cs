using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentMainForm : Form
    {
        private EnrollmentHome home = new EnrollmentHome();
        private EnrollmentGrades grades = new EnrollmentGrades();
        private EnrollmentAccounts accounts = new EnrollmentAccounts();
        private EnrollmentSchedules schedule = new EnrollmentSchedules();
        private EnrollmentConfirmation selectSubjects = new EnrollmentConfirmation();
        private string connectionString = "server=localhost;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";
        public EnrollmentMainForm()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            pnlEnrollmentNavigator.SuspendLayout();
            pnlEnrollmentNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlEnrollmentNavigator.Controls.Add(control);
            pnlEnrollmentNavigator.ResumeLayout();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(home);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            LoadControl(accounts);
        }

        private async void btnEnrollmentForm_Click(object sender, EventArgs e)
        {
            // Check 1: Payment due
            bool hasPaymentDue = await CheckIfStudentHasPaymentDue();

            if (hasPaymentDue)
            {
                DialogResult result = MessageBox.Show(
                    "You have an outstanding balance. Please settle your payment before enrolling.\n\n" +
                    "Would you like to go to the Accounts section now?",
                    "Payment Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    LoadControl(accounts);
                }
                return;
            }

            // Check 2: Already enrolled
            bool isAlreadyEnrolled = await CheckIfAlreadyEnrolled();

            if (isAlreadyEnrolled)
            {
                MessageBox.Show("You are already enrolled for the current semester.",
                    "Already Enrolled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Proceed to enrollment confirmation
            EnrollmentHome confirmation = new EnrollmentHome();
            LoadControl(confirmation);
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

        private async Task<bool> CheckIfAlreadyEnrolled()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;
                    string currentSemester = GetCurrentSemester();
                    string currentAcademicYear = GetCurrentAcademicYear();

                    string query = @"SELECT COUNT(*) 
                            FROM enrollment e
                            JOIN semester sem ON e.Semester_ID = sem.Semester_ID
                            WHERE e.Student_ID = @studentId
                            AND sem.Semester_Name = @semester
                            AND sem.Academic_Year = @academicYear
                            AND e.Enrollment_Status = 'Enrolled'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semester", currentSemester);
                        cmd.Parameters.AddWithValue("@academicYear", currentAcademicYear);

                        int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking enrollment: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> CheckIfStudentHasPaymentDue()
        {
            EnrollmentHome home = new EnrollmentHome();
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Get current semester and academic year
                    string currentSemester = GetCurrentSemester();
                    string currentAcademicYear = GetCurrentAcademicYear();

                    string query = @"SELECT Total_Amount_Due 
                            FROM statement_of_account soa
                            JOIN semester sem ON soa.Semester_ID = sem.Semester_ID
                            WHERE soa.Student_ID = @studentId
                            AND sem.Semester_Name = @semester
                            AND sem.Academic_Year = @academicYear
                            ORDER BY soa.Statement_Of_Account_ID DESC
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", UserSession.EnrollmentStudentID ?? 0);
                        cmd.Parameters.AddWithValue("@semester", currentSemester);
                        cmd.Parameters.AddWithValue("@academicYear", currentAcademicYear);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal totalDue = Convert.ToDecimal(result);
                            return totalDue > 0;
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking payment status: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            LoadControl(schedule);
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            LoadControl(grades);
        }

        private void EnrollmentMainForm_Load(object sender, EventArgs e)
        {
            LoadControl(home);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginFormPUPSIS loginForm = new LoginFormPUPSIS();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
