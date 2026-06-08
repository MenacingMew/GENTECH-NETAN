using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GENTECH_PROJECTPUPSIS;
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class LoginSignInPage : UserControl
    {
        public LoginSignInPage()
        {
            InitializeComponent();
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "ID";
                txtID.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void hrbSignIn_Click(object sender, EventArgs e)
        {
            string username = txtID.Text;
            string password = txtPassword.Text;

            if (username == "ID" || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your ID", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password == "Password" || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse formatted ID
            int? parsedId = ParseFormattedID(username);
            if (parsedId.HasValue)
                username = parsedId.Value.ToString();

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Try hashed password first
            if (AuthenticateAndLoadUser(username, hashedPassword))
            {
                OpenFormByRole();
                return;
            }

            // Try plain text password (for legacy accounts)
            if (AuthenticateAndLoadUser(username, password))
            {
                OpenFormByRole();
                return;
            }

            MessageBox.Show("Invalid ID/Email or Password", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Main authentication method

        private void OpenFormByRole()
        {
            switch (UserSession.UserRole)
            {
                case UserSession.ROLE_ADMIN:
                    AdminMainForm admin = new AdminMainForm();
                    admin.Show();
                    this.FindForm()?.Hide();
                    break;
                case UserSession.ROLE_FACULTY:
                    FacultyMainForm faculty = new FacultyMainForm();
                    faculty.Show();
                    this.FindForm()?.Hide();
                    break;
                case UserSession.ROLE_STUDENT:
                    StudentMainForm student = new StudentMainForm();
                    student.Show();
                    this.FindForm()?.Hide();
                    break;
                case UserSession.ROLE_ENROLLMENT:
                    EnrollmentMainForm enrollment = new EnrollmentMainForm();
                    enrollment.Show();
                    this.FindForm()?.Hide();
                    break;
            }
        }
        private bool AuthenticateAndLoadUser(string username, string password, bool isHashed = true)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    // Try STUDENT
                    if (LoadStudentData(conn, username, password))
                        return true;

                    // Try FACULTY
                    if (LoadFacultyData(conn, username, password))
                        return true;

                    // Try ENROLLMENT STAFF
                    if (LoadEnrollmentStaffData(conn, username, password))
                        return true;

                    // Try ADMIN
                    if (LoadAdminData(conn, username, password))
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        // Load STUDENT data
        private bool LoadStudentData(MySqlConnection conn, string username, string password)
        {
            bool isNumeric = int.TryParse(username, out int studentId);

            string query;
            if (isNumeric)
            {
                query = @"SELECT s.*, p.Program_Code, p.Program_Name, sec.Section_Name
                  FROM student s 
                  LEFT JOIN program p ON s.Program_ID = p.Program_ID 
                  LEFT JOIN section sec ON s.Section_ID = sec.Section_ID
                  WHERE s.Student_ID = @studentId AND s.Password = @password";
            }
            else
            {
                query = @"SELECT s.*, p.Program_Code, p.Program_Name, sec.Section_Name
                  FROM student s 
                  LEFT JOIN program p ON s.Program_ID = p.Program_ID 
                  LEFT JOIN section sec ON s.Section_ID = sec.Section_ID
                  WHERE s.Email = @email AND s.Password = @password";
            }

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (isNumeric)
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                else
                    cmd.Parameters.AddWithValue("@email", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int creationYear = reader["Birth_Date"] != DBNull.Value ?
                            Convert.ToDateTime(reader["Birth_Date"]).Year : DateTime.Now.Year;

                        UserSession.SetStudentData(
                            studentId: Convert.ToInt32(reader["Student_ID"]),
                            firstName: reader["First_Name"].ToString(),
                            lastName: reader["Last_Name"].ToString(),
                            email: reader["Email"].ToString(),
                            contactNumber: reader["Contact_Number"].ToString(),
                            birthDate: Convert.ToDateTime(reader["Birth_Date"]),
                            yearLevel: reader["Year_Level"] as int?,
                            programId: reader["Program_ID"] as int?,
                            programCode: reader["Program_Code"]?.ToString(),
                            programName: reader["Program_Name"]?.ToString(),
                            sectionId: reader["Section_ID"] as int?,
                            sectionName: reader["Section_Name"]?.ToString(),
                            password: password,
                            creationYear: creationYear  // ADD THIS
                        );
                        return true;
                    }
                }
            }
            return false;
        }

        private int? ParseFormattedID(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            // Student: 2024-00136-SM-0 → 136
            // Pattern: YYYY-XXXXX-XX-X
            if (input.Contains("-") && !input.StartsWith("F-") && !input.StartsWith("A-") && !input.StartsWith("ENR-"))
            {
                var parts = input.Split('-');
                if (parts.Length >= 2 && int.TryParse(parts[1], out int id))
                    return id;
            }
            // Faculty: F-2024-005 → 5
            if (input.StartsWith("F-"))
            {
                var parts = input.Split('-');
                if (parts.Length >= 3 && int.TryParse(parts[2], out int id))
                    return id;
            }
            // Admin: A-2024-003 → 3
            if (input.StartsWith("A-"))
            {
                var parts = input.Split('-');
                if (parts.Length >= 3 && int.TryParse(parts[2], out int id))
                    return id;
            }
            // Enrollment: ENR-2024-00100 → 100
            if (input.StartsWith("ENR-"))
            {
                var parts = input.Split('-');
                if (parts.Length >= 3 && int.TryParse(parts[2], out int id))
                    return id;
            }
            return null;
        }


        private bool LoadFacultyData(MySqlConnection conn, string username, string password)
        {
            bool isNumeric = int.TryParse(username, out int facultyId);

            string query;
            if (isNumeric)
            {
                query = @"SELECT f.*, d.Department_Name 
                  FROM faculty f 
                  LEFT JOIN department d ON f.Department_ID = d.Department_ID 
                  WHERE f.Faculty_ID = @facultyId AND f.Password = @password";
            }
            else
            {
                query = @"SELECT f.*, d.Department_Name 
                  FROM faculty f 
                  LEFT JOIN department d ON f.Department_ID = d.Department_ID 
                  WHERE f.Email = @email AND f.Password = @password";
            }

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (isNumeric)
                    cmd.Parameters.AddWithValue("@facultyId", facultyId);
                else
                    cmd.Parameters.AddWithValue("@email", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int creationYear = reader["Birth_Date"] != DBNull.Value ?
                            Convert.ToDateTime(reader["Birth_Date"]).Year : DateTime.Now.Year;

                        UserSession.SetFacultyData(
                            facultyId: Convert.ToInt32(reader["Faculty_ID"]),
                            firstName: reader["First_Name"].ToString(),
                            lastName: reader["Last_Name"].ToString(),
                            email: reader["Email"].ToString(),
                            departmentId: reader["Department_ID"] as int?,
                            departmentName: reader["Department_Name"]?.ToString(),
                            password: password,
                            creationYear: creationYear  // ADD THIS
                        );
                        return true;
                    }
                }
            }
            return false;
        }

        // Load ENROLLMENT STAFF data
        private bool LoadEnrollmentStaffData(MySqlConnection conn, string username, string password)
        {
            if (!int.TryParse(username, out int credentialId))
                return false;

            string query = @"SELECT ec.*, s.*, p.Program_Code, p.Program_Name, sec.Section_Name
                     FROM enrollment_credentials ec 
                     INNER JOIN student s ON ec.Student_ID = s.Student_ID 
                     LEFT JOIN program p ON s.Program_ID = p.Program_ID 
                     LEFT JOIN section sec ON s.Section_ID = sec.Section_ID
                     WHERE ec.Credential_ID = @credentialId AND ec.Password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@credentialId", credentialId);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int creationYear = reader["Birth_Date"] != DBNull.Value ?
                            Convert.ToDateTime(reader["Birth_Date"]).Year : DateTime.Now.Year;

                        UserSession.SetEnrollmentStaffData(
                            credentialId: Convert.ToInt32(reader["Credential_ID"]),
                            studentId: Convert.ToInt32(reader["Student_ID"]),
                            firstName: reader["First_Name"].ToString(),
                            lastName: reader["Last_Name"].ToString(),
                            email: reader["Email"].ToString(),
                            contactNumber: reader["Contact_Number"].ToString(),
                            birthDate: Convert.ToDateTime(reader["Birth_Date"]),
                            yearLevel: reader["Year_Level"] as int?,
                            programId: reader["Program_ID"] as int?,
                            programCode: reader["Program_Code"]?.ToString(),
                            programName: reader["Program_Name"]?.ToString(),
                            sectionId: reader["Section_ID"] as int?,
                            sectionName: reader["Section_Name"]?.ToString(),
                            password: password,
                            creationYear: creationYear  
                        );
                        return true;
                    }
                }
            }
            return false;
        }

        private bool LoadAdminData(MySqlConnection conn, string username, string password)
        {
            bool isNumeric = int.TryParse(username, out int adminId);

            string query;
            if (isNumeric)
            {
                query = @"SELECT * FROM admin 
                  WHERE Admin_ID = @adminId AND Password = @password";
            }
            else
            {
                query = @"SELECT * FROM admin 
                  WHERE Email = @email AND Password = @password";
            }

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (isNumeric)
                    cmd.Parameters.AddWithValue("@adminId", adminId);
                else
                    cmd.Parameters.AddWithValue("@email", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int creationYear = reader["Birth_Date"] != DBNull.Value ?
                            Convert.ToDateTime(reader["Birth_Date"]).Year : DateTime.Now.Year;

                        UserSession.SetAdminData(
                            adminId: Convert.ToInt32(reader["Admin_ID"]),
                            firstName: reader["First_Name"].ToString(),
                            lastName: reader["Last_Name"].ToString(),
                            email: reader["Email"].ToString(),
                            roleDescription: reader["Role_Description"].ToString(),
                            middleName: reader["Middle_Name"]?.ToString(),
                            suffix: reader["Suffix"]?.ToString(),
                            contactNumber: reader["Contact_Number"]?.ToString(),
                            address: reader["Address"]?.ToString(),
                            sex: reader["Sex"]?.ToString(),
                            birthDate: reader["Birth_Date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["Birth_Date"]) : (DateTime?)null,
                            password: password,
                            creationYear: creationYear  // ADD THIS
                        );
                        return true;
                    }
                }
            }
            return false;
        }


        private bool EmailExistsInDatabase(string email)
        {
            string query = @"
                SELECT COUNT(*) FROM (
                    SELECT Email FROM admin WHERE Email = @email
                    UNION ALL
                    SELECT Email FROM faculty WHERE Email = @email
                    UNION ALL
                    SELECT Email FROM student WHERE Email = @email
                ) AS combined";

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())

                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string input = Interaction.InputBox("Enter your email address:", "Forgot Password", "");

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string email = input.Trim();

            if (EmailExistsInDatabase(email))
            {
                MessageBox.Show($"Password reset link has been sent to {email}\n\n" +
                    "(Note: In production, an actual email would be sent. " +
                    "Please contact your system administrator for password reset.)",
                    "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email address does not exist in our system, please try again!",
                    "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowPass_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPass.Text = "Hide Password";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPass.Text = "Show Password";
            }
        }

        private void OpenUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _)) return;

            try
            {
                Process.Start(url);
            }
            catch
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmbofficial");
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/HMSocietyPUPSMB");
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmb.isite");
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/acespupsmb");
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmbiskolarium");
        }
        private string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}