using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using MimeKit;
using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using MailKit.Net.Smtp;

namespace WindowsFormsApp1
{
    public partial class AdminFacultynAdminCreate : UserControl
    {
        private static string connectionString = "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        private string currentFacultyID = "";
        private string currentAdminID = "";
        private int currentDepartmentID = 1;

        public AdminFacultynAdminCreate()
        {
            InitializeComponent();
            LoadFacultyGridView();
            this.txtAdminSearchModify.Enter += new System.EventHandler(this.txtAdminSearchModify_Enter);
            this.txtAdminSearchModify.Leave += new System.EventHandler(this.txtAdminSearchModify_Leave);
        }

        // =========================================
        // PASSWORD GENERATOR
        // =========================================
        private string GenerateRandomPassword(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%";
            Random rnd = new Random();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[rnd.Next(chars.Length)];
            }
            return new string(result);
        }

        // =========================================
        // LOAD FACULTY GRIDVIEW
        // =========================================
        private void LoadFacultyGridView()
        {
            if (dvgFacultyView == null) return;

            dvgFacultyView.Columns.Clear();
            dvgFacultyView.Rows.Clear();

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "FacultyID";
            colID.HeaderText = "Faculty ID";
            colID.Width = 150;
            dvgFacultyView.Columns.Add(colID);

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Name";
            colName.HeaderText = "Name";
            colName.Width = 250;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvgFacultyView.Columns.Add(colName);

            DataGridViewTextBoxColumn colDept = new DataGridViewTextBoxColumn();
            colDept.Name = "Department";
            colDept.HeaderText = "Department";
            colDept.Width = 200;
            dvgFacultyView.Columns.Add(colDept);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnView";
            btn.Text = "View";
            btn.Width = 90;
            btn.UseColumnTextForButtonValue = true;
            dvgFacultyView.Columns.Add(btn);

            dvgFacultyView.AllowUserToAddRows = false;
            dvgFacultyView.RowHeadersVisible = false;

            string query = @"
                SELECT 
                    f.Faculty_ID,
                    CONCAT(f.First_Name, ' ', f.Last_Name) as FullName,
                    d.Department_Name
                FROM faculty f
                JOIN department d ON f.Department_ID = d.Department_ID
                WHERE (f.IsArchived = FALSE OR f.IsArchived IS NULL)
                ORDER BY f.Faculty_ID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dvgFacultyView.Rows.Add(
                                    reader["Faculty_ID"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Department_Name"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading faculty: " + ex.Message);
            }
        }

        // =========================================
        // VIEW FACULTY DETAILS
        // =========================================
        private void dvgFacultyView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;

            if (dvgFacultyView.Columns[e.ColumnIndex].Name == "btnView")
            {
                string facultyID = dvgFacultyView.Rows[e.RowIndex].Cells["FacultyID"].Value.ToString();

                string query = @"
                    SELECT 
                        f.Faculty_ID, 
                        f.First_Name, 
                        f.Last_Name, 
                        f.Middle_Name,
                        f.Suffix,
                        f.Email, 
                        f.Contact_Number,
                        f.Address,
                        f.Sex,
                        DATE_FORMAT(f.Birth_Date, '%W, %B %d, %Y') as Birth_Date,
                        d.Department_Name
                    FROM faculty f
                    LEFT JOIN department d ON f.Department_ID = d.Department_ID
                    WHERE f.Faculty_ID = @id";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", facultyID);

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    dvgFacultyView.Visible = false;
                                    cmbFilterFacultyView.Visible = false;
                                    btnClearView.Visible = true;
                                    panel2.Visible = true;
                                    panel2.Controls.Clear();

                                    Panel mainPanel = new Panel();
                                    mainPanel.Dock = DockStyle.Fill;
                                    mainPanel.BackColor = Color.White;
                                    mainPanel.AutoScroll = true;
                                    mainPanel.Padding = new Padding(20);

                                    int y = 20;
                                    int labelWidth = 150;
                                    int valueWidth = 350;
                                    int rowHeight = 35;
                                    int leftMargin = 30;

                                    Label lblTitle = new Label()
                                    {
                                        Text = "FACULTY INFORMATION",
                                        Font = new Font("Segoe UI", 18, FontStyle.Bold),
                                        ForeColor = Color.Maroon,
                                        Location = new Point(leftMargin, y),
                                        Size = new Size(400, 40)
                                    };
                                    mainPanel.Controls.Add(lblTitle);
                                    y += 60;

                                    void AddField(string labelText, string value)
                                    {
                                        Label lbl = new Label()
                                        {
                                            Text = labelText,
                                            Font = new Font("Segoe UI", 11, FontStyle.Bold),
                                            ForeColor = Color.FromArgb(64, 64, 64),
                                            Location = new Point(leftMargin, y),
                                            Size = new Size(labelWidth, 30)
                                        };
                                        mainPanel.Controls.Add(lbl);

                                        Label lblValue = new Label()
                                        {
                                            Text = string.IsNullOrEmpty(value) ? "—" : value,
                                            Font = new Font("Segoe UI", 11),
                                            ForeColor = Color.Black,
                                            Location = new Point(leftMargin + labelWidth + 10, y),
                                            Size = new Size(valueWidth, 30)
                                        };
                                        mainPanel.Controls.Add(lblValue);

                                        y += rowHeight;
                                    }

                                    AddField("First Name:", reader["First_Name"].ToString());
                                    AddField("Middle Name:", reader["Middle_Name"]?.ToString() ?? "");
                                    AddField("Last Name:", reader["Last_Name"].ToString());
                                    AddField("Suffix:", reader["Suffix"]?.ToString() ?? "");
                                    AddField("Email:", reader["Email"].ToString());
                                    AddField("Date of Birth:", reader["Birth_Date"]?.ToString() ?? "");
                                    AddField("Contact No.:", reader["Contact_Number"]?.ToString() ?? "");
                                    AddField("Sex:", reader["Sex"]?.ToString() ?? "");
                                    AddField("Address:", reader["Address"]?.ToString() ?? "");
                                    AddField("Department:", reader["Department_Name"]?.ToString() ?? "");

                                    y += 20;

                                    Button btnBack = new Button()
                                    {
                                        Text = "Back",
                                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                                        BackColor = Color.Maroon,
                                        ForeColor = Color.White,
                                        FlatStyle = FlatStyle.Flat,
                                        Size = new Size(120, 40),
                                        Location = new Point(leftMargin, y)
                                    };
                                    btnBack.Click += (s, ev) =>
                                    {
                                        panel2.Visible = false;
                                        dvgFacultyView.Visible = true;
                                        cmbFilterFacultyView.Visible = true;
                                        btnClearView.Visible = false;
                                    };
                                    mainPanel.Controls.Add(btnBack);

                                    panel2.Controls.Add(mainPanel);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading faculty details: " + ex.Message);
                }
            }
        }

        // =========================================
        // CREATE FACULTY (Tab 1)
        // =========================================
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Get values from FACULTY form fields
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string suffix = txtSuffix.Text.Trim();
            string address = txtAddress.Text.Trim();
            string contactNo = txtContactNo.Text.Trim();
            string email = txtEmail.Text.Trim();
            string facultyID = txtFacultyID.Text.Trim();

            // Get sex from combo box
            string sex = "";
            if (cmbSex.SelectedIndex == 1) sex = "Male";
            else if (cmbSex.SelectedIndex == 2) sex = "Female";

            DateTime birthDate = dtpBirthday.Value;

            // ========== VALIDATION ==========

            // First Name validation
            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter a valid First Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(firstName))
            {
                MessageBox.Show("First Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Last Name validation
            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter a valid Last Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(lastName))
            {
                MessageBox.Show("Last Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email validation
            if (email == "Email" || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., name@domain.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Faculty ID validation
            if (facultyID == "Faculty ID" || string.IsNullOrWhiteSpace(facultyID))
            {
                MessageBox.Show("Please enter a Faculty ID (must be a number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidNumber(facultyID))
            {
                MessageBox.Show("Faculty ID must be a number (e.g., 18, 19, 20).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Middle Name validation (optional)
            if (!string.IsNullOrEmpty(middleName) && middleName != "Middle Name")
            {
                if (!IsValidName(middleName))
                {
                    MessageBox.Show("Middle Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Contact Number validation (optional)
            if (!string.IsNullOrEmpty(contactNo) && contactNo != "Contact No.")
            {
                if (!IsValidPhoneNumber(contactNo))
                {
                    MessageBox.Show("Contact Number must contain 10-15 digits only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int facultyIdNumber = int.Parse(facultyID);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if Faculty ID already exists
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM faculty WHERE Faculty_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", facultyIdNumber);
                    int exists = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exists > 0)
                    {
                        MessageBox.Show($"Faculty ID {facultyIdNumber} already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Insert into faculty table
                string insertQuery = @"
            INSERT INTO faculty (Faculty_ID, Department_ID, First_Name, Last_Name, Middle_Name, Suffix, Email, Contact_Number, Address, Sex, Birth_Date, Password, IsArchived) 
            VALUES (@id, @deptID, @first, @last, @middle, @suffix, @email, @contact, @address, @sex, @birthdate, @password, 0)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", facultyIdNumber);
                    cmd.Parameters.AddWithValue("@deptID", currentDepartmentID);
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.Parameters.AddWithValue("@middle", (middleName == "Middle Name") ? "" : middleName);
                    cmd.Parameters.AddWithValue("@suffix", (suffix == "Jr., Sr., I, III") ? "" : suffix);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contact", (contactNo == "Contact No.") ? "" : contactNo);
                    cmd.Parameters.AddWithValue("@address", (address == "Address") ? "" : address);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@birthdate", birthDate);
                    cmd.Parameters.AddWithValue("@password", "123");
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"✅ FACULTY CREATED SUCCESSFULLY!\n\n" +
                $"Name: {firstName} {middleName} {lastName} {suffix}\n" +
                $"Faculty ID: {facultyID}\n" +
                $"Email: {email}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFacultyCreateFields();
            LoadFacultyGridView();
        }

        private void ClearFacultyCreateFields()
        {
            txtFirstName.Text = "First Name";
            txtMiddleName.Text = "Middle Name";
            txtLastName.Text = "Last Name";
            txtSuffix.Text = "Jr., Sr., I, III";
            txtAddress.Text = "Address";
            txtContactNo.Text = "Contact No.";
            txtEmail.Text = "Email";
            txtFacultyID.Text = "Faculty ID";
            txtFirstName.ForeColor = Color.DarkGray;
            txtMiddleName.ForeColor = Color.DarkGray;
            txtLastName.ForeColor = Color.DarkGray;
            txtSuffix.ForeColor = Color.DarkGray;
            txtAddress.ForeColor = Color.DarkGray;
            txtContactNo.ForeColor = Color.DarkGray;
            txtEmail.ForeColor = Color.DarkGray;
            txtFacultyID.ForeColor = Color.DarkGray;
            cmbSex.SelectedIndex = 0;
            dtpBirthday.Value = DateTime.Now;
        }

        // =========================================
        // CREATE ADMIN (Tab 3)
        // =========================================
        private void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            // Get values from ADMIN form fields
            string firstName = txtFirstAdminCreate.Text.Trim();
            string middleName = txtMiddleAdminCreate.Text.Trim();
            string lastName = txtLastAdminCreate.Text.Trim();
            string suffix = txtSuffixAdminCreate.Text.Trim();
            string email = txtEmailAdminCreate.Text.Trim();
            string contactNo = txtContactAdminCreate.Text.Trim();
            string address = txtAddressAdminCreate.Text.Trim();
            string adminID = txtAdminIDCreate.Text.Trim();

            string sex = "";
            if (cmbSexAdminCreate.SelectedIndex == 1) sex = "Male";
            else if (cmbSexAdminCreate.SelectedIndex == 2) sex = "Female";

            DateTime birthDate = dtpBirthdayAdminCreate.Value;

            // ========== VALIDATION ==========

            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter a valid First Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(firstName))
            {
                MessageBox.Show("First Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter a valid Last Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(lastName))
            {
                MessageBox.Show("Last Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (email == "Email" || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., name@domain.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (adminID == "Admin ID" || string.IsNullOrWhiteSpace(adminID))
            {
                MessageBox.Show("Please enter an Admin ID (must be a number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidNumber(adminID))
            {
                MessageBox.Show("Admin ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(contactNo) && contactNo != "Contact No.")
            {
                if (!IsValidPhoneNumber(contactNo))
                {
                    MessageBox.Show("Contact Number must contain 10-15 digits only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(middleName) && middleName != "Middle Name")
            {
                if (!IsValidName(middleName))
                {
                    MessageBox.Show("Middle Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int adminIdNumber = int.Parse(adminID);
            string generatedPassword = GenerateRandomPassword(10);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM admin WHERE Admin_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", adminIdNumber);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show($"Admin ID {adminIdNumber} already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM admin WHERE Email = @email", conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show($"Email '{email}' already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string insertQuery = @"
            INSERT INTO admin (Admin_ID, First_Name, Last_Name, Middle_Name, Suffix, Email, Contact_Number, Address, Sex, Birth_Date, Password, Role_Description) 
            VALUES (@id, @first, @last, @middle, @suffix, @email, @contact, @address, @sex, @birthdate, @password, @role)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", adminIdNumber);
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.Parameters.AddWithValue("@middle", (middleName == "Middle Name" || middleName == "") ? "" : middleName);
                    cmd.Parameters.AddWithValue("@suffix", (suffix == "Jr., Sr., I, III" || suffix == "") ? "" : suffix);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contact", (contactNo == "Contact No." || contactNo == "") ? "" : contactNo);
                    cmd.Parameters.AddWithValue("@address", (address == "Address" || address == "") ? "" : address);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@birthdate", birthDate);
                    cmd.Parameters.AddWithValue("@password", generatedPassword);
                    cmd.Parameters.AddWithValue("@role", "Administrator");

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        SendPasswordEmail(email, firstName, lastName, adminID, generatedPassword);

                        MessageBox.Show(
                            $"✅ ADMIN CREATED!\n\n" +
                            $"Name: {firstName} {middleName} {lastName}\n" +
                            $"Admin ID: {adminIdNumber}\n" +
                            $"Email: {email}\n" +
                            $"PASSWORD: {generatedPassword}\n\n" +
                            $"Save this password for login!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearAdminCreateFields();
                    }
                }
            }
        }

        // =========================================
        // VALIDATION METHODS
        // =========================================

        // Validate name (letters, spaces, hyphens, dots only)
        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '.')
                    return false;
            }
            return true;
        }

        // Validate phone number (numbers only, 10-15 digits)
        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true; // Optional field
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return phone.Length >= 10 && phone.Length <= 15;
        }

        // Validate email format
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Validate number (for IDs)
        private bool IsValidNumber(string number)
        {
            return int.TryParse(number, out _);
        }

        private void ClearAdminCreateFields()
        {
            txtFirstAdminCreate.Text = "First Name";
            txtMiddleAdminCreate.Text = "Middle Name";
            txtLastAdminCreate.Text = "Last Name";
            txtSuffixAdminCreate.Text = "Jr., Sr., I, III";
            txtAddressAdminCreate.Text = "Address";
            txtContactAdminCreate.Text = "Contact No.";
            txtEmailAdminCreate.Text = "Email";
            txtAdminIDCreate.Text = "Admin ID";

            txtFirstAdminCreate.ForeColor = Color.DarkGray;
            txtMiddleAdminCreate.ForeColor = Color.DarkGray;
            txtLastAdminCreate.ForeColor = Color.DarkGray;
            txtSuffixAdminCreate.ForeColor = Color.DarkGray;
            txtAddressAdminCreate.ForeColor = Color.DarkGray;
            txtContactAdminCreate.ForeColor = Color.DarkGray;
            txtEmailAdminCreate.ForeColor = Color.DarkGray;
            txtAdminIDCreate.ForeColor = Color.DarkGray;

            if (cmbSexAdminCreate != null) cmbSexAdminCreate.SelectedIndex = 0;
            dtpBirthdayAdminCreate.Value = DateTime.Now;
        }

        // =========================================
        // SEARCH FACULTY (Modify Tab)
        // =========================================
        private void btnSearchFaculty_Click(object sender, EventArgs e)
        {
            string searchValue = txtFacultySearch.Text?.Trim();
            if (string.IsNullOrEmpty(searchValue) || searchValue == "Faculty ID")
            {
                MessageBox.Show("Please enter a Faculty ID to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT Faculty_ID, First_Name, Last_Name, Middle_Name, Suffix, Email, Contact_Number, Address, Sex, Birth_Date
                FROM faculty WHERE Faculty_ID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", searchValue);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentFacultyID = reader["Faculty_ID"].ToString();

                                txtFirstModify.Text = reader["First_Name"].ToString();
                                txtLastModify.Text = reader["Last_Name"].ToString();
                                txtEmailModify.Text = reader["Email"].ToString();
                                txtMiddleModify.Text = reader["Middle_Name"]?.ToString() ?? "";
                                txtSuffixModify.Text = reader["Suffix"]?.ToString() ?? "";
                                txtContactModify.Text = reader["Contact_Number"]?.ToString() ?? "";
                                txtAddressModify.Text = reader["Address"]?.ToString() ?? "";

                                string sex = reader["Sex"]?.ToString() ?? "";
                                if (sex == "Male") cmbSexModify.SelectedIndex = 1;
                                else if (sex == "Female") cmbSexModify.SelectedIndex = 2;
                                else cmbSexModify.SelectedIndex = 0;

                                if (reader["Birth_Date"] != DBNull.Value)
                                    poisonDateTime2.Value = Convert.ToDateTime(reader["Birth_Date"]);
                                else
                                    poisonDateTime2.Value = DateTime.Now;

                                txtFirstModify.ForeColor = Color.Black;
                                txtLastModify.ForeColor = Color.Black;
                                txtEmailModify.ForeColor = Color.Black;
                                txtMiddleModify.ForeColor = Color.Black;
                                txtSuffixModify.ForeColor = Color.Black;
                                txtContactModify.ForeColor = Color.Black;
                                txtAddressModify.ForeColor = Color.Black;

                                btnSaveFaculty.Enabled = true;
                                btnSaveFaculty.PrimaryColor = Color.Maroon;
                                btnDeleteFaculty.Enabled = true;
                                btnDeleteFaculty.PrimaryColor = Color.Maroon;
                            }
                            else
                            {
                                MessageBox.Show("Faculty not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching faculty: " + ex.Message);
            }
        }

        private void btnSaveFaculty_Click(object sender, EventArgs e)
        {
            if (!btnSaveFaculty.Enabled) return;

            string firstName = txtFirstModify.Text.Trim();
            string lastName = txtLastModify.Text.Trim();
            string email = txtEmailModify.Text.Trim();
            string contactNo = txtContactModify.Text.Trim();
            string middleName = txtMiddleModify.Text.Trim();

            // ========== VALIDATION ==========

            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter a valid First Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(firstName))
            {
                MessageBox.Show("First Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter a valid Last Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidName(lastName))
            {
                MessageBox.Show("Last Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (email == "Email" || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(contactNo) && contactNo != "Contact No.")
            {
                if (!IsValidPhoneNumber(contactNo))
                {
                    MessageBox.Show("Contact Number must contain 10-15 digits only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(middleName) && middleName != "Middle Name")
            {
                if (!IsValidName(middleName))
                {
                    MessageBox.Show("Middle Name can only contain letters, spaces, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string sex = "";
            if (cmbSexModify.SelectedIndex == 1) sex = "Male";
            else if (cmbSexModify.SelectedIndex == 2) sex = "Female";

            if (MessageBox.Show("Save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string updateQuery = @"
            UPDATE faculty SET First_Name=@first, Last_Name=@last, Middle_Name=@middle, Suffix=@suffix,
            Email=@email, Contact_Number=@contact, Address=@address, Sex=@sex, Birth_Date=@birthdate
            WHERE Faculty_ID=@id";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@first", firstName);
                            cmd.Parameters.AddWithValue("@last", lastName);
                            cmd.Parameters.AddWithValue("@middle", txtMiddleModify.Text == "Middle Name" ? "" : txtMiddleModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@suffix", txtSuffixModify.Text == "Jr., Sr., I, III" ? "" : txtSuffixModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@contact", contactNo == "Contact No." ? "" : contactNo);
                            cmd.Parameters.AddWithValue("@address", txtAddressModify.Text == "Address" ? "" : txtAddressModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@sex", sex);
                            cmd.Parameters.AddWithValue("@birthdate", poisonDateTime2.Value);
                            cmd.Parameters.AddWithValue("@id", currentFacultyID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Faculty saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFacultyModifyFields();
                    LoadFacultyGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteFaculty_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFacultyID)) return;
            if (MessageBox.Show($"Archive faculty {currentFacultyID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0", conn))
                            cmd.ExecuteNonQuery();

                        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM faculty WHERE Faculty_ID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentFacultyID);
                            cmd.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1", conn))
                            cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Faculty archived.", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFacultyModifyFields();
                    LoadFacultyGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearFacultyModifyFields()
        {
            txtFirstModify.Text = "First Name";
            txtMiddleModify.Text = "Middle Name";
            txtLastModify.Text = "Last Name";
            txtSuffixModify.Text = "Jr., Sr., I, III";
            txtAddressModify.Text = "Address";
            txtContactModify.Text = "Contact No.";
            txtEmailModify.Text = "Email";
            txtFirstModify.ForeColor = Color.DarkGray;
            txtMiddleModify.ForeColor = Color.DarkGray;
            txtLastModify.ForeColor = Color.DarkGray;
            txtSuffixModify.ForeColor = Color.DarkGray;
            txtAddressModify.ForeColor = Color.DarkGray;
            txtContactModify.ForeColor = Color.DarkGray;
            txtEmailModify.ForeColor = Color.DarkGray;
            cmbSexModify.SelectedIndex = 0;
            poisonDateTime2.Value = DateTime.Now;
            btnSaveFaculty.Enabled = false;
            btnSaveFaculty.PrimaryColor = Color.Gray;
            btnDeleteFaculty.Enabled = false;
            btnDeleteFaculty.PrimaryColor = Color.Gray;
            txtFacultySearch.Text = "Faculty ID";
            txtFacultySearch.StateCommon.Content.Color1 = Color.DarkGray;
            currentFacultyID = "";
        }

        // =========================================
        // SEARCH ADMIN (Modify Admin Tab)
        // =========================================
        private void btnAdminSearchModify_Click(object sender, EventArgs e)
        {
            // Get search value and trim whitespace
            string searchValue = txtAdminSearchModify.Text?.Trim();

            // Check if search is empty or still has placeholder text
            if (string.IsNullOrEmpty(searchValue) || searchValue == "Admin ID")
            {
                MessageBox.Show("Please enter a valid Admin ID to search.", "Search Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate that it's a number
            if (!int.TryParse(searchValue, out int adminId))
            {
                MessageBox.Show("Admin ID must be a number (e.g., 1, 2, 64).", "Invalid ID",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
        SELECT Admin_ID, First_Name, Last_Name, Middle_Name, Suffix, 
               Email, Contact_Number, Address, Sex, Birth_Date
        FROM admin 
        WHERE Admin_ID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", adminId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Store current admin ID
                                currentAdminID = reader["Admin_ID"].ToString();

                                // Populate text fields
                                txtFirstAdminModify.Text = reader["First_Name"].ToString();
                                txtLastAdminModify.Text = reader["Last_Name"].ToString();
                                txtEmailAdminModify.Text = reader["Email"].ToString();
                                txtAdminIDModify.Text = reader["Admin_ID"].ToString();

                                // Handle nullable fields
                                txtMiddleAdminModify.Text = reader["Middle_Name"]?.ToString() ?? "";
                                txtSuffixAdminModify.Text = reader["Suffix"]?.ToString() ?? "";
                                txtContactAdminModify.Text = reader["Contact_Number"]?.ToString() ?? "";
                                txtAddressAdminModify.Text = reader["Address"]?.ToString() ?? "";

                                // Set sex combo box
                                string sex = reader["Sex"]?.ToString() ?? "";
                                if (sex == "Male")
                                    cmbSexAdminModify.SelectedIndex = 1;
                                else if (sex == "Female")
                                    cmbSexAdminModify.SelectedIndex = 2;
                                else
                                    cmbSexAdminModify.SelectedIndex = 0;

                                // Set birth date
                                if (reader["Birth_Date"] != DBNull.Value)
                                    dtpBirthdayAdminModify.Value = Convert.ToDateTime(reader["Birth_Date"]);
                                else
                                    dtpBirthdayAdminModify.Value = DateTime.Now;

                                // Change text color to black (remove placeholder appearance)
                                txtFirstAdminModify.ForeColor = Color.Black;
                                txtLastAdminModify.ForeColor = Color.Black;
                                txtEmailAdminModify.ForeColor = Color.Black;
                                txtMiddleAdminModify.ForeColor = Color.Black;
                                txtSuffixAdminModify.ForeColor = Color.Black;
                                txtContactAdminModify.ForeColor = Color.Black;
                                txtAddressAdminModify.ForeColor = Color.Black;
                                txtAdminIDModify.ForeColor = Color.Black;

                                // Enable save and archive buttons
                                btnSaveAdmin.Enabled = true;
                                btnSaveAdmin.PrimaryColor = Color.Maroon;
                                btnArchive.Enabled = true;
                                btnArchive.PrimaryColor = Color.Maroon;

                                // Show success
                                MessageBox.Show($"Admin ID {adminId} found! You can now modify the details.",
                                               "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Admin ID {adminId} not found in the database.",
                                               "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ClearAdminModifyFields(); // Clear any previous data
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching admin: {ex.Message}",
                               "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            if (!btnSaveAdmin.Enabled) return;

            if (string.IsNullOrWhiteSpace(txtFirstAdminModify.Text) || txtFirstAdminModify.Text == "First Name" ||
                string.IsNullOrWhiteSpace(txtLastAdminModify.Text) || txtLastAdminModify.Text == "Last Name")
            {
                MessageBox.Show("First Name and Last Name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sex = "";
                if (cmbSexAdminModify.SelectedIndex == 1) sex = "Male";
                else if (cmbSexAdminModify.SelectedIndex == 2) sex = "Female";

                string updateQuery = @"
                    UPDATE admin SET First_Name=@first, Last_Name=@last, Middle_Name=@middle, Suffix=@suffix,
                    Email=@email, Contact_Number=@contact, Address=@address, Sex=@sex, Birth_Date=@birthdate
                    WHERE Admin_ID=@id";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@first", txtFirstAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@last", txtLastAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@middle", txtMiddleAdminModify.Text == "Middle Name" ? "" : txtMiddleAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@suffix", txtSuffixAdminModify.Text == "Jr., Sr., I, III" ? "" : txtSuffixAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txtEmailAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", txtContactAdminModify.Text == "Contact No." ? "" : txtContactAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", txtAddressAdminModify.Text == "Address" ? "" : txtAddressAdminModify.Text.Trim());
                            cmd.Parameters.AddWithValue("@sex", sex);
                            cmd.Parameters.AddWithValue("@birthdate", dtpBirthdayAdminModify.Value);
                            cmd.Parameters.AddWithValue("@id", int.Parse(currentAdminID));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Admin saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAdminModifyFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentAdminID)) return;
            if (MessageBox.Show($"Archive admin {currentAdminID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM admin WHERE Admin_ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", currentAdminID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Admin archived.", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAdminModifyFields();
            }
        }

        private void ClearAdminModifyFields()
        {
            txtFirstAdminModify.Text = "First Name";
            txtMiddleAdminModify.Text = "Middle Name";
            txtLastAdminModify.Text = "Last Name";
            txtSuffixAdminModify.Text = "Jr., Sr., I, III";
            txtAddressAdminModify.Text = "Address";
            txtContactAdminModify.Text = "Contact No.";
            txtEmailAdminModify.Text = "Email";
            txtAdminIDModify.Text = "Admin ID";
            txtFirstAdminModify.ForeColor = Color.DarkGray;
            txtMiddleAdminModify.ForeColor = Color.DarkGray;
            txtLastAdminModify.ForeColor = Color.DarkGray;
            txtSuffixAdminModify.ForeColor = Color.DarkGray;
            txtAddressAdminModify.ForeColor = Color.DarkGray;
            txtContactAdminModify.ForeColor = Color.DarkGray;
            txtEmailAdminModify.ForeColor = Color.DarkGray;
            txtAdminIDModify.ForeColor = Color.DarkGray;
            cmbSexAdminModify.SelectedIndex = 0;
            dtpBirthdayAdminModify.Value = DateTime.Now;
            btnSaveAdmin.Enabled = false;
            btnSaveAdmin.PrimaryColor = Color.Gray;
            btnArchive.Enabled = false;
            btnArchive.PrimaryColor = Color.Gray;
            txtAdminSearchModify.Text = "Admin ID";
            txtAdminSearchModify.StateCommon.Content.Color1 = Color.DarkGray;
            currentAdminID = "";
        }

        // =========================================
        // CSV UPLOAD HANDLERS
        // =========================================
        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnCreate.Visible = false;
                btnCreateCSV.Visible = true;
                btnCancelCSV.Visible = true;
                dgvPreview.Visible = true;
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                dgvPreview.Rows.Clear();
                dgvPreview.Columns.Clear();
                string[] headers = lines[0].Split(',');
                foreach (string header in headers) dgvPreview.Columns.Add(header, header);
                for (int i = 1; i < lines.Length; i++) dgvPreview.Rows.Add(lines[i].Split(','));
            }
        }

        private void btnCreateCSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Load this CSV file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int success = 0;
                foreach (DataGridViewRow row in dgvPreview.Rows)
                {
                    if (row.IsNewRow) continue;
                    try
                    {
                        string facultyID = row.Cells[0].Value?.ToString();
                        if (!string.IsNullOrEmpty(facultyID))
                        {
                            using (MySqlConnection conn = new MySqlConnection(connectionString))
                            {
                                conn.Open();
                                string insertQuery = "INSERT INTO faculty (Faculty_ID, Department_ID, First_Name, Last_Name, Email, Password) VALUES (@id, 1, @first, @last, @email, '123')";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", facultyID);
                                    cmd.Parameters.AddWithValue("@first", row.Cells[1].Value?.ToString() ?? "");
                                    cmd.Parameters.AddWithValue("@last", row.Cells[2].Value?.ToString() ?? "");
                                    cmd.Parameters.AddWithValue("@email", row.Cells[3].Value?.ToString() ?? "");
                                    cmd.ExecuteNonQuery();
                                    success++;
                                }
                            }
                        }
                    }
                    catch { }
                }
                MessageBox.Show($"Loaded {success} faculty records.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFacultyGridView();
            }
            dgvPreview.Visible = false;
            btnCreateCSV.Visible = false;
            btnCancelCSV.Visible = false;
            btnCreate.Visible = true;
        }

        private void btnCancelCSV_Click(object sender, EventArgs e)
        {
            dgvPreview.Visible = false;
            btnCreateCSV.Visible = false;
            btnCancelCSV.Visible = false;
            btnCreate.Visible = true;
        }

        private void btnClearView_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Visible = false;
            dvgFacultyView.Visible = true;
            cmbFilterFacultyView.Visible = true;
            btnClearView.Visible = false;
        }

        // =========================================
        // SEND EMAIL
        // =========================================
        private void SendPasswordEmail(string toEmail, string firstName, string lastName, string adminId, string password)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PUPSIS System", "acuyatadaya@gmail.com"));
                message.To.Add(new MailboxAddress($"{firstName} {lastName}", toEmail));
                message.Subject = "Your PUPSIS Admin Account Credentials";

                string body = $@"
        <html>
        <body>
            <h2>PUPSIS Admin Account</h2>
            <p>Dear <strong>{firstName} {lastName}</strong>,</p>
            <p>Your admin account has been created.</p>
            <p><strong>Admin ID:</strong> {adminId}</p>
            <p><strong>Email:</strong> {toEmail}</p>
            <p><strong>Password:</strong> {password}</p>
            <p>Best regards,<br>PUPSIS Administration</p>
        </body>
        </html>";

                message.Body = new TextPart("html") { Text = body };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("acuyatadaya@gmail.com", "mzbk knaf nbdx omgt");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email NOT sent!\nError: {ex.Message}", "Email Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        // =========================================
        // PLACEHOLDER HANDLERS - FACULTY CREATE TAB
        // =========================================
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag?.ToString() ?? "";
                txt.ForeColor = Color.DarkGray;
            }
        }

        // =========================================
        // PLACEHOLDER HANDLERS - FACULTY MODIFY TAB
        // =========================================
        private void txtFirstModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtFirstModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag?.ToString() ?? "First Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        // Apply the same pattern for all modify tab textboxes
        private void txtMiddleModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtMiddleModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Middle Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtLastModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtLastModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Last Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtSuffixModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtSuffixModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Jr., Sr., I, III";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtAddressModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtAddressModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Address";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtContactModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtContactModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Contact No.";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmailModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtEmailModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Email";
                txt.ForeColor = Color.DarkGray;
            }
        }

        // =========================================
        // PLACEHOLDER HANDLERS - CREATE ADMIN TAB
        // =========================================
        private void txtFirstAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtFirstAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "First Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtMiddleAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtMiddleAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Middle Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtLastAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtLastAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Last Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtSuffixAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtSuffixAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Jr., Sr., I, III";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtAddressAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtAddressAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Address";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtContactAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtContactAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Contact No.";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmailAdminCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtEmailAdminCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Email";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtAdminIDCreate_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtAdminIDCreate_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Admin ID";
                txt.ForeColor = Color.DarkGray;
            }
        }

        // =========================================
        // PLACEHOLDER HANDLERS - MODIFY ADMIN TAB
        // =========================================
        private void txtFirstAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtFirstAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "First Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtMiddleAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtMiddleAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Middle Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtLastAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtLastAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Last Name";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtSuffixAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtSuffixAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Jr., Sr., I, III";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtAddressAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtAddressAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Address";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtContactAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtContactAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Contact No.";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmailAdminModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtEmailAdminModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Email";
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void txtAdminIDModify_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void txtAdminIDModify_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Admin ID";
                txt.ForeColor = Color.DarkGray;
            }
        }
        private void txtAdminSearchModify_Enter(object sender, EventArgs e)
        {
            if (txtAdminSearchModify.Text == "Admin ID")
            {
                txtAdminSearchModify.Text = "";
                txtAdminSearchModify.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void txtAdminSearchModify_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdminSearchModify.Text))
            {
                txtAdminSearchModify.Text = "Admin ID";
                txtAdminSearchModify.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        // =========================================
        // KRYPTON TEXTBOX HANDLERS (for search boxes)
        // =========================================
        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && txt.StateCommon.Content.Color1 == Color.DarkGray)
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Faculty ID";
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        private void kryptonTextBox11_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && txt.StateCommon.Content.Color1 == Color.DarkGray)
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox11_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Admin ID";
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        // =========================================
        // EMPTY EVENT HANDLERS
        // =========================================
        private void AdminFacultynAdminCreate_Load(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtFirstModify_TextChanged(object sender, EventArgs e) { }
        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnSearchModify_Click(object sender, EventArgs e) { }
    }
}