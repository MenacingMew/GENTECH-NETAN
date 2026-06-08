using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminUserManagement : UserControl
    {
        public AdminUserManagement()
        {
            InitializeComponent();
        }

        private void AdminUserManagement_Load(object sender, EventArgs e)
        {
            txtSearchName.StateCommon.Content.Color1 = Color.DarkGray;
            txtSearchName.Text = "Search by name...";
            cmbRole.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            LoadUsers();
        }

        private void LoadUsers()
        {
            dvgEnrollees.Rows.Clear();

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    CONCAT_WS(' ', FirstName, NULLIF(MiddleName, ''), LastName)  AS Name,
                    'Student'                                                      AS Role,
                    Email,
                    CASE WHEN Status = 1 THEN 'Passed' ELSE 'Failed' END          AS Status
                FROM temporary_student";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string role = reader["Role"].ToString();
                            string email = reader["Email"].ToString();
                            string status = reader["Status"].ToString();

                            AddUserRow(name, role, email, status);
                        }
                    }
                }

                dvgEnrollees.Sort(dvgEnrollees.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load users:\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddUserRow(string Name, string Role, string Email, string Status)
        {
            int index = dvgEnrollees.Rows.Add();
            DataGridViewRow row = dvgEnrollees.Rows[index];

            row.Cells[0].Value = Name;
            row.Cells[1].Value = Role;
            row.Cells[2].Value = Email;
            row.Cells[3].Value = Status;

            row.Cells[3].Style.BackColor = Status == "Passed" ? Color.Green : Color.Red;
            row.Cells[3].Style.ForeColor = Color.White;
        }

        // =========================================
        // SEARCH BAR - REAL-TIME FILTERING
        // =========================================
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Search by name...")
                return;
            FilterData();
        }

        private void FilterData()
        {
            string selectedStatus = cmbStatus.Text;
            string selectedRole = cmbRole.Text;
            string searchText = txtSearchName.Text == "Search by name..."
                ? ""
                : txtSearchName.Text.ToLower();

            foreach (DataGridViewRow row in dvgEnrollees.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string role = row.Cells[1].Value?.ToString() ?? "";
                string name = row.Cells[0].Value?.ToString() ?? "";
                string status = row.Cells[3].Value?.ToString() ?? "";

                bool statusMatch = selectedStatus == "All" || status == selectedStatus;
                bool roleMatch = selectedRole == "All" || role == selectedRole;
                bool searchMatch = string.IsNullOrEmpty(searchText) || name.ToLower().Contains(searchText);

                row.Visible = statusMatch && roleMatch && searchMatch;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        // =========================================
        // EXPORT & PROMOTE WITH ALL FEATURES
        // =========================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File (*.csv)|*.csv";

            if (cmbRole.SelectedItem.ToString() == "All")
            {
                MessageBox.Show("Please select a specific role (Student or Faculty) to export.",
                                "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog.FileName = $"{cmbRole.SelectedItem}_Passed.csv";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            DialogResult confirm = MessageBox.Show(
                "Exporting will also promote all Passed students to the student database,\n" +
                "create their Statement of Account, Enrollment Credentials,\n" +
                "and send them their login OTP via email.\n\nContinue?",
                "Confirm Export & Promote", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int exportCount = 0;
            int failCount = 0;
            int emailFail = 0;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    var students = new List<(int id, string firstName, string middleName, string lastName, string email)>();

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT TempStudent_ID, FirstName, MiddleName, LastName, Email FROM temporary_student WHERE Status = 1", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add((
                                Convert.ToInt32(reader["TempStudent_ID"]),
                                reader["FirstName"].ToString(),
                                reader["MiddleName"] == DBNull.Value ? "" : reader["MiddleName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["Email"].ToString()
                            ));
                        }
                    }

                    if (students.Count == 0)
                    {
                        MessageBox.Show("No Passed students found to export.",
                            "Nothing to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var rows = new List<string>();
                    rows.Add("FirstName,MiddleName,LastName,Email");

                    foreach (var s in students)
                    {
                        try
                        {
                            string otp = GenerateOTP();
                            string hashedOtp = HashPassword(otp);

                            // Check if email already exists in student table
                            int existingCount = 0;
                            using (MySqlCommand checkCmd = new MySqlCommand(
                                "SELECT COUNT(*) FROM student WHERE Email = @Email", conn))
                            {
                                checkCmd.Parameters.AddWithValue("@Email", s.email);
                                existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                            }

                            if (existingCount > 0)
                            {
                                failCount++;
                                continue;
                            }

                            // Get next available section
                            int section = GetNextSection(1, 1);

                            // 1. INSERT INTO student table
                            string insertQuery = @"
                                INSERT INTO student 
                                    (Program_ID, First_Name, Last_Name, Birth_Date,
                                     Email, Contact_Number, Password, Year_Level, Section_ID)
                                VALUES 
                                    (1, @FirstName, @LastName, '2000-01-01',
                                     @Email, 'N/A', @Password, 1, @SectionID)";


                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@FirstName", s.firstName);
                                insertCmd.Parameters.AddWithValue("@LastName", s.lastName);
                                insertCmd.Parameters.AddWithValue("@Email", s.email);
                                insertCmd.Parameters.AddWithValue("@Password", hashedOtp);
                                insertCmd.Parameters.AddWithValue("@SectionID", section);
                                insertCmd.ExecuteNonQuery();
                            }

                            // Get new Student_ID
                            long newStudentId;
                            using (MySqlCommand lastIdCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                            {
                                newStudentId = Convert.ToInt64(lastIdCmd.ExecuteScalar());
                            }

                            // 2. INSERT INTO enrollment_credentials with HASHED password
                            string credQuery = @"
                            INSERT INTO enrollment_credentials 
                                (Student_ID, Password)
                            VALUES 
                                (@StudentID, @Password)";

                            using (MySqlCommand credCmd = new MySqlCommand(credQuery, conn))
                            {
                                credCmd.Parameters.AddWithValue("@StudentID", newStudentId);
                                credCmd.Parameters.AddWithValue("@Password", hashedOtp);
                                credCmd.ExecuteNonQuery();
                            }

                            // 3. INSERT INTO statement_of_account
                            int currentSemesterId = GetCurrentSemesterID(conn);
                            string soaQuery = @"
                            INSERT INTO statement_of_account 
                                (Student_ID, Semester_ID, Tuition_Fee, Miscellaneous_Fee, 
                                 Registration_Fee, Laboratory_Fee, Total_Amount_Due)
                            VALUES 
                                (@StudentID, @SemesterID, 0, 0, 0, 0, 0)";

                            using (MySqlCommand soaCmd = new MySqlCommand(soaQuery, conn))
                            {
                                soaCmd.Parameters.AddWithValue("@StudentID", newStudentId);
                                soaCmd.Parameters.AddWithValue("@SemesterID", currentSemesterId);
                                soaCmd.ExecuteNonQuery();
                            }

                            // 4. Send email with OTP (plain text, not hashed)
                            bool emailSent = SendOtpEmail(s.email, s.firstName, otp, IDFormatter.FormatEnrollmentID((int)newStudentId, DateTime.Now.Year));

                            if (!emailSent) emailFail++;

                            rows.Add($"{s.firstName},{s.middleName},{s.lastName},{s.email}");
                            exportCount++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                ex.ToString(),
                                "Promotion Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            failCount++;
                        }
                    }

                    // Save CSV
                    File.WriteAllText(saveFileDialog.FileName, string.Join(Environment.NewLine, rows));

                    // Delete ALL promoted students from temporary_student
                    using (MySqlCommand clearCmd = new MySqlCommand(
                        "DELETE FROM temporary_student WHERE Status = 1", conn))
                    {
                        clearCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Export & Promotion complete.\n\n" +
                    $"✔ {exportCount} promoted & exported\n" +
                    $"✘ {failCount} failed\n" +
                    $"✉ {emailFail} email(s) failed to send\n\n" +
                    $"Created for each student:\n" +
                    $"• Student Record (with Section)\n" +
                    $"• Enrollment Credentials (Hashed Password)\n" +
                    $"• Statement of Account",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================
        // HELPER: Get Next Available Section
        // =========================================
        private int GetNextSection(int programId, int yearLevel)
        {
            


            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Get all sections for this program, check which has space
                string query = @"
            SELECT s.Section_ID, s.Max_Slots,
                   (SELECT COUNT(*) FROM student WHERE Section_ID = s.Section_ID) as Current_Count
            FROM section s
            WHERE s.Program_ID = @programId
            ORDER BY s.Section_ID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@programId", programId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sectionId = Convert.ToInt32(reader["Section_ID"]);
                            int maxSlots = Convert.ToInt32(reader["Max_Slots"]);
                            int currentCount = Convert.ToInt32(reader["Current_Count"]);

                            if (currentCount < maxSlots)
                                return sectionId;
                        }
                    }
                }

                // If all sections are full, create a new section
                string insertSection = @"
            INSERT INTO section (Program_ID, Section_Name, Max_Slots)
            VALUES (@programId, 
                    (SELECT COUNT(*) + 1 FROM section WHERE Program_ID = @programId2), 
                    50);
            SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(insertSection, conn))
                {
                    cmd.Parameters.AddWithValue("@programId", programId);
                    cmd.Parameters.AddWithValue("@programId2", programId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        // =========================================
        // HELPER: Get Current Semester ID
        // =========================================
        private int GetCurrentSemesterID(MySqlConnection conn)
        {
            string query = @"SELECT Semester_ID FROM semester 
                            WHERE Start_Date <= @today AND End_Date >= @today
                            ORDER BY Semester_ID DESC LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@today", DateTime.Now);
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
            }

            // Fallback
            string fallbackQuery = "SELECT Semester_ID FROM semester ORDER BY Start_Date DESC LIMIT 1";
            using (MySqlCommand cmd = new MySqlCommand(fallbackQuery, conn))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 1;
            }
        }

        // =========================================
        // OTP & HASHING
        // =========================================
        private string GenerateOTP()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789";
            Random rnd = new Random();
            char[] otp = new char[8]; // 8-character OTP
            for (int i = 0; i < otp.Length; i++)
                otp[i] = chars[rnd.Next(chars.Length)];
            return new string(otp);
        }

        private string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // =========================================
        // EMAIL SENDER
        // =========================================
        private bool SendOtpEmail(string toEmail, string firstName, string otp, string credentialId)
        {
            try
            {
                string imagePath = @"C:\Users\user\Downloads\GENTECH-NETAN-OngariaEnrollmentPageV1\GENTECH-NETAN-OngariaEnrollmentPageV1\VERY_IMPORTANT.jpg";

                using (var mail = new System.Net.Mail.MailMessage())
                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    mail.From = new System.Net.Mail.MailAddress("omurice226@gmail.com", "PUPSIS");
                    mail.To.Add(toEmail);
                    mail.Subject = "Your Journey at PUP Begins";
                    mail.Body = $@"Dear {firstName},

After careful deliberation, the gates of the Polytechnic University of the Philippines have opened for you.

Your application has been reviewed, found worthy, and you have been accepted as a student of this institution.

Your journey begins now.

To access the student portal, use your new credentials below:
        
Credential ID: {credentialId}
Password: {otp}

Guard them well, for they are yours alone. Upon your first entry, you shall be required to change your password.

We await your presence.

— The Administration
Polytechnic University of the Philippines";

                    if (File.Exists(imagePath))
                    {
                        var attachment = new System.Net.Mail.Attachment(imagePath);
                        mail.Attachments.Add(attachment);
                    }

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(
                        "omurice226@gmail.com",
                        "qngm olzm bkbt eutn"
                    );

                    smtp.Send(mail);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e) { }

        // =========================================
        // TEXTBOX WATERMARK EVENTS
        // =========================================
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && txt.Text == "Search by name...")
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Search by name...";
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}