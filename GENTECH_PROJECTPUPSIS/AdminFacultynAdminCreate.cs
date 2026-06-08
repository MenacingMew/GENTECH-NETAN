using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using MailKit.Net.Smtp;
using MimeKit;
using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminFacultynAdminCreate : UserControl
    {
       

        private string currentFacultyID = "";
        private string currentAdminID = "";
        private int currentDepartmentID = 1;

        public AdminFacultynAdminCreate()
        {
            InitializeComponent();
            InitModifyGrid();
            LoadModifyData();
            LoadFacultyGridView();
            SetupModifyForm();
            LoadDepartmentCombo();
            LoadFilterCombo(); 
        }

        private void btnBackModify_Click(object sender, EventArgs e)
        {
            ClearModifyForm();
            panel3.Visible = false;
            kryptonDataGridView1.Visible = true;
            cmbFilterModify.Visible = true;
            LoadModifyData();
        }
        private void InitModifyGrid()
        {
            kryptonDataGridView1.Columns.Clear();
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FacultyID", HeaderText = "Faculty ID", Width = 150 });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Department", HeaderText = "Department", Width = 200 });
            kryptonDataGridView1.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "Action", Name = "btnEdit", Text = "Edit", Width = 90, UseColumnTextForButtonValue = true });
        }
        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnEdit"].Index) return;

            // Hide grid, show modify form
            kryptonDataGridView1.Visible = false;
            cmbFilterModify.Visible = false;  // Your filter combo
            panel3.Visible = true;
            btnArchive.Visible = true;
            btnBackFaculty.Visible = true;
            btnSaveFaculty.Visible = true;

            string facultyID = kryptonDataGridView1.Rows[e.RowIndex].Cells["FacultyID"].Value.ToString();
            var controls = panel3.Tag as ModifyFacultyControls;
            if (controls != null)
            {
                controls.txtSearch.Text = facultyID;
                controls.txtSearch.StateCommon.Content.Color1 = Color.Black;
                SearchFacultyForModify(facultyID);
            }
        }
        private void LoadModifyData()
        {
            kryptonDataGridView1.Rows.Clear();
            string query = @"
        SELECT f.Faculty_ID, CONCAT(f.First_Name, ' ', f.Last_Name) as FullName, d.Department_Name
        FROM faculty f
        JOIN department d ON f.Department_ID = d.Department_ID
        WHERE (f.IsArchived = FALSE OR f.IsArchived IS NULL)
        ORDER BY f.Faculty_ID";

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                kryptonDataGridView1.Rows.Add(
                                    IDFormatter.FormatFacultyID(Convert.ToInt32(reader["Faculty_ID"]), DateTime.Now.Year),  // Formatted
                                    reader["FullName"].ToString(),
                                    reader["Department_Name"].ToString()
                                );
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        // =========================================
        // PASSWORD GENERATOR
        // =========================================
        private string GenerateRandomPassword(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$ %";
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
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dvgFacultyView.Rows.Add(
                                         IDFormatter.FormatFacultyID(Convert.ToInt32(reader["Faculty_ID"]), DateTime.Now.Year),
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
        // TextBox and ComboBox Event Handlers for Watermark Effect
        // =========================================

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && txt.ForeColor == Color.DarkGray) { txt.Text = ""; txt.ForeColor = Color.Black; }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = txt.Tag?.ToString() ?? ""; txt.ForeColor = Color.DarkGray; }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ReaLTaiizor.Controls.ComboBoxEdit;
            if (comboBox != null && comboBox.SelectedIndex != 0) comboBox.ForeColor = Color.Black;
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
                    using (MySqlConnection conn = DbConnection.GetConnection())
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

                                    AddField("Faculty ID:", IDFormatter.FormatFacultyID(Convert.ToInt32(reader["Faculty_ID"]), DateTime.Now.Year));
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
                                    panel2.Controls.Add(mainPanel);
                                    btnBack.Visible = true;
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
        // =========================================
        // CREATE FACULTY (Tab 1) - UPDATED
        // =========================================
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string suffix = txtSuffix.Text.Trim();
            string address = txtAddress.Text.Trim();
            string contactNo = txtContactNo.Text.Trim();
            string email = txtEmail.Text.Trim();
            string facultyID = txtFacultyID.Text.Trim();

            string sex = "";
            if (cmbSex.SelectedIndex == 1) sex = "Male";
            else if (cmbSex.SelectedIndex == 2) sex = "Female";

            DateTime birthDate = dtpBirthday.Value;

            // ========== VALIDATION ==========
            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            { MessageBox.Show("Please enter a valid First Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!IsValidName(firstName))
            { MessageBox.Show("First Name can only contain letters, spaces, hyphens, and periods.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            { MessageBox.Show("Please enter a valid Last Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!IsValidName(lastName))
            { MessageBox.Show("Last Name can only contain letters, spaces, hyphens, and periods.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!string.IsNullOrEmpty(middleName) && middleName != "Middle Name")
            {
                if (!IsValidName(middleName))
                { MessageBox.Show("Middle Name can only contain letters, spaces, hyphens, and periods.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            if (!string.IsNullOrEmpty(suffix) && suffix != "Jr., Sr., I, III")
            {
                if (!IsValidName(suffix))
                { MessageBox.Show("Suffix can only contain letters and periods.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            if (email == "Email" || string.IsNullOrWhiteSpace(email))
            { MessageBox.Show("Please enter a valid Email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!IsValidEmail(email))
            { MessageBox.Show("Please enter a valid email address (e.g., name@domain.com).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (facultyID == "Faculty ID" || string.IsNullOrWhiteSpace(facultyID))
            { MessageBox.Show("Please enter a Faculty ID (must be a number).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!IsValidNumber(facultyID))
            { MessageBox.Show("Faculty ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!string.IsNullOrEmpty(contactNo) && contactNo != "Contact No.")
            {
                if (!IsValidPhoneNumber(contactNo))
                { MessageBox.Show("Contact Number must contain 10-15 digits only.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            if (!string.IsNullOrEmpty(address) && address != "Address")
            {
                if (address.Length < 5)
                { MessageBox.Show("Please enter a valid Address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            // Department validation
            if (cmbDepartment.SelectedIndex <= 0)
            { MessageBox.Show("Please select a Department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbSex.SelectedIndex <= 0)
            { MessageBox.Show("Please select Sex.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Birth date validation
            if (birthDate > DateTime.Now.AddYears(-18))
            { MessageBox.Show("Faculty must be at least 18 years old.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int facultyIdNumber = int.Parse(facultyID);

            // Get Department ID
            int deptId = 1;
            string deptName = cmbDepartment.SelectedItem?.ToString() ?? "";

            // Generate hashed password
            string generatedPassword = GenerateRandomPassword(10);
            string hashedPassword = HashPassword(generatedPassword);

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    // Get Department ID
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Department_ID FROM department WHERE Department_Name = @name", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", deptName);
                        object result = cmd.ExecuteScalar();
                        if (result != null) deptId = Convert.ToInt32(result);
                    }

                    // Check duplicate Faculty ID
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM faculty WHERE Faculty_ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", facultyIdNumber);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        { MessageBox.Show($"Faculty ID {facultyIdNumber} already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    }

                    // Check duplicate Email
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM faculty WHERE Email = @email", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        { MessageBox.Show($"Email '{email}' already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    }

                    // INSERT faculty
                    string insertQuery = @"
                INSERT INTO faculty 
                    (Faculty_ID, Department_ID, First_Name, Last_Name, Middle_Name, Suffix, 
                     Email, Contact_Number, Address, Sex, Birth_Date, Password, IsArchived) 
                VALUES 
                    (@id, @deptID, @first, @last, @middle, @suffix, 
                     @email, @contact, @address, @sex, @birthdate, @password, 0)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", facultyIdNumber);
                        cmd.Parameters.AddWithValue("@deptID", deptId);
                        cmd.Parameters.AddWithValue("@first", firstName);
                        cmd.Parameters.AddWithValue("@last", lastName);
                        cmd.Parameters.AddWithValue("@middle", (middleName == "Middle Name") ? "" : middleName);
                        cmd.Parameters.AddWithValue("@suffix", (suffix == "Jr., Sr., I, III") ? "" : suffix);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contact", (contactNo == "Contact No.") ? "" : contactNo);
                        cmd.Parameters.AddWithValue("@address", (address == "Address") ? "" : address);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@birthdate", birthDate);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                int creationYear = DateTime.Now.Year;

                MessageBox.Show($"✅ FACULTY CREATED SUCCESSFULLY!\n\n" +
                 $"Name: {firstName} {middleName} {lastName} {suffix}\n" +
                  $"Faculty ID: {IDFormatter.FormatFacultyID(facultyIdNumber, creationYear)}\n" +
                 $"Department: {deptName}\n" +
                 $"Email: {email}\n" +
                 $"Password: {generatedPassword}",
                 "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFacultyCreateFields(); 
                LoadFacultyGridView();
                LoadModifyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating faculty: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void cmbFilterFacultyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cmbFilterFacultyView.SelectedItem?.ToString() ?? "All";
            foreach (DataGridViewRow row in dvgFacultyView.Rows)
            {
                if (!row.IsNewRow)
                    row.Visible = filter == "All" || (row.Cells["Department"].Value?.ToString() ?? "") == filter;
            }
        }
        private void cmbFilterModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cmbFilterModify.SelectedItem?.ToString() ?? "All";  // ← FIXED
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (!row.IsNewRow)
                    row.Visible = filter == "All" || (row.Cells["Department"].Value?.ToString() ?? "") == filter;
            }
        }
        private void LoadFilterCombo()
        {
            if (cmbFilterModify == null) return;

            cmbFilterModify.Items.Clear();
            cmbFilterModify.Items.Add("All");

            string query = "SELECT Department_Name FROM department ORDER BY Department_Name";
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbFilterModify.Items.Add(reader["Department_Name"].ToString());
                    }
                }
            }
            cmbFilterModify.SelectedIndex = 0;
        }

        private void LoadDepartmentCombo()
        {
            if (cmbDepartment == null) return;

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("Select Department");

            string query = "SELECT Department_Name FROM department ORDER BY Department_Name";
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbDepartment.Items.Add(reader["Department_Name"].ToString());
                    }
                }
            }
            cmbDepartment.SelectedIndex = 0;
        }
        private void btnSaveFaculty_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFacultyID))
            {
                MessageBox.Show("No faculty record loaded. Please search for a faculty first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var controls = panel3.Tag as ModifyFacultyControls;
            if (controls == null) return;

            string firstName = controls.txtFirstName.Text.Trim();
            string lastName = controls.txtLastName.Text.Trim();
            string email = controls.txtEmail.Text.Trim();

            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            { MessageBox.Show("Please enter a valid First Name."); return; }
            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            { MessageBox.Show("Please enter a valid Last Name."); return; }
            if (email == "Email" || string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            { MessageBox.Show("Please enter a valid Email."); return; }

            // Get department ID
            int deptId = 1;
            string deptName = controls.cmbDept.SelectedItem?.ToString() ?? "";
            if (deptName != "Select Department")
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Department_ID FROM department WHERE Department_Name = @name", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", deptName);
                        object result = cmd.ExecuteScalar();
                        if (result != null) deptId = Convert.ToInt32(result);
                    }
                }
            }

            string sex = "";
            if (controls.cmbSex.SelectedIndex == 1) sex = "Male";
            else if (controls.cmbSex.SelectedIndex == 2) sex = "Female";

            if (MessageBox.Show("Save changes to this faculty record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string updateQuery = @"UPDATE faculty SET 
            First_Name=@first, Last_Name=@last, Middle_Name=@middle, Suffix=@suffix,
            Email=@email, Contact_Number=@contact, Address=@address,
            Sex=@sex, Birth_Date=@birthdate, Department_ID=@deptId
            WHERE Faculty_ID=@id";

                try
                {
                    using (MySqlConnection conn = DbConnection.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@first", firstName);
                            cmd.Parameters.AddWithValue("@last", lastName);
                            cmd.Parameters.AddWithValue("@middle", controls.txtMiddleName.Text == "Middle Name" ? "" : controls.txtMiddleName.Text.Trim());
                            cmd.Parameters.AddWithValue("@suffix", controls.txtSuffix.Text == "Jr., Sr., I, III" ? "" : controls.txtSuffix.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@contact", controls.txtContact.Text == "Contact No." ? "" : controls.txtContact.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", controls.txtAddress.Text == "Address" ? "" : controls.txtAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@sex", sex);
                            cmd.Parameters.AddWithValue("@birthdate", controls.dtpBirth.Value);
                            cmd.Parameters.AddWithValue("@deptId", deptId);
                            cmd.Parameters.AddWithValue("@id", currentFacultyID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Faculty record saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearModifyForm();
                    LoadModifyData();
                    LoadFacultyGridView();
                    btnBackModify_Click(sender, e);
                    btnArchive.Visible = false;
                    btnBackFaculty.Visible = false;
                    btnSaveFaculty.Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFacultyID))
            { MessageBox.Show("No faculty record loaded."); return; }

            if (MessageBox.Show($"Archive faculty {currentFacultyID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DbConnection.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("UPDATE faculty SET IsArchived = 1 WHERE Faculty_ID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentFacultyID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Faculty archived.", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearModifyForm();
                    LoadModifyData();
                    LoadFacultyGridView();
                    btnBackModify_Click(sender, e);
                    btnBackFaculty.Visible = false;
                    btnSaveFaculty.Visible = false;
                    btnArchive.Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
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
            cmbDepartment.SelectedIndex = 0;
            dtpBirthday.Value = DateTime.Now;
        }

        // =========================================
        // CREATE ADMIN (Tab 3)
        // =========================================
        private void btnCreateAdmin_Click(object sender, EventArgs e)
        {
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

            using (MySqlConnection conn = DbConnection.GetConnection())
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
                        int creationYear = DateTime.Now.Year;
                        MessageBox.Show(
                        $"✅ ADMIN CREATED!\n\n" +
                        $"Name: {firstName} {middleName} {lastName}\n" +
                        $"Admin ID: {IDFormatter.FormatAdminID(adminIdNumber, creationYear)}\n" +
                        $"Email: {email}\n" +
                        $"PASSWORD: {generatedPassword}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearAdminCreateFields();
                    }
                }
            }
        }


        // =========================================
        // VALIDATION METHODS
        // =========================================
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

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true;
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return phone.Length >= 10 && phone.Length <= 15;
        }

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


        // =========================================
        // MAILKIT EMAIL SENDER HELPERS
        // =========================================
        private void SendPasswordEmail(string email, string firstName, string lastName, string adminID, string password)
        {
            try
            {
                using (var mail = new System.Net.Mail.MailMessage())
                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    mail.From = new System.Net.Mail.MailAddress("omurice226@gmail.com", "PUPSIS");
                    mail.To.Add(email);
                    mail.Subject = "GenTech System - New Administrator Credentials";
                    mail.Body = $"Hello {firstName},\n\n" +
                               $"Your system administrator account has been set up successfully.\n\n" +
                               $"User ID: {adminID}\n" +
                               $"Password: {password}\n\n" +
                               $"Please change your password upon first login.\n\n" +
                               $"Regards,\nGenTech Academic Infrastructure";

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(
                        "omurice226@gmail.com",
                        "qngm olzm bkbt eutn"  // App Password
                    );

                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email failed: " + ex.Message);
            }
        }

        // =========================================
        // CUSTOM EVENT HANDLERS (Watermarks)
        // =========================================


        private void txtAdminSearchModify_Leave(object sender, EventArgs e)
        {

        }

        private string[] facultyLines;

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select CSV File"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            facultyLines = File.ReadAllLines(dlg.FileName);

            if (facultyLines.Length == 0)
            {
                MessageBox.Show("The selected CSV file is empty.", "Invalid File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] headers = facultyLines[0].Split(',');
            bool headersValid =
                headers.Length >= 5 &&
                headers[0].Trim() == "FirstName" &&
                headers[1].Trim() == "MiddleName" &&
                headers[2].Trim() == "LastName" &&
                headers[3].Trim() == "Email" &&
                headers[4].Trim() == "Type";

            if (!headersValid)
            {
                MessageBox.Show(
                    "Invalid CSV format. Please use the correct faculty import template.\n\n" +
                    "Expected columns:\n  FirstName, MiddleName, LastName, Email, Type\n\n" +
                    "The Type column must say 'Faculty' for each row.\n\n" +
                    "Note: Do not use the student CSV — that is a different format.",
                    "Wrong CSV Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvPreview.Rows.Clear();
            dgvPreview.Columns.Clear();
            dgvPreview.Columns.Add("FirstName", "First Name");
            dgvPreview.Columns.Add("MiddleName", "Middle Name");
            dgvPreview.Columns.Add("LastName", "Last Name");
            dgvPreview.Columns.Add("Email", "Email");

            for (int i = 1; i < facultyLines.Length; i++)
            {
                string line = facultyLines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] values = line.Split(',');
                if (values.Length < 5) continue;

                if (values[4].Trim() != "Faculty") continue;

                if (string.IsNullOrWhiteSpace(values[0]) &&
                    string.IsNullOrWhiteSpace(values[1]) &&
                    string.IsNullOrWhiteSpace(values[2]) &&
                    string.IsNullOrWhiteSpace(values[3])) continue;

                dgvPreview.Rows.Add(
                    values[0].Trim(), values[1].Trim(),
                    values[2].Trim(), values[3].Trim());
            }

            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.EnableHeadersVisualStyles = false;
            dgvPreview.ColumnHeadersVisible = true;
            dgvPreview.Font = new Font("Segoe UI", 11f);
            dgvPreview.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvPreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPreview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgvPreview.Columns)
                col.MinimumWidth = 100;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvPreview.Visible = true;
            btnCreateCSV.Visible = true;
            btnCancelCSV.Visible = true;
            btnBatchUpload.Visible = false;
            btnCreate.Visible = false;
        }

        private void btnCancelFaculty_Click(object sender, EventArgs e)
        {
            ResetFacultyPreview();
        }

        private void ResetFacultyPreview()
        {
            dgvPreview.Visible = false;
            btnCreateCSV.Visible = false;
            btnCancelCSV.Visible = false;
            btnBatchUpload.Visible = true;
            btnCreate.Visible = true;
        }

        private void btnCancelCSV_Click(object sender, EventArgs e)
        {
            ResetFacultyPreview();
        }

        private void btnCreateCSV_Click(object sender, EventArgs e)
        {

        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && txt.Text == "Faculty ID")
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

        // =========================================
        // MODIFY FACULTY - Panel 3 Setup (Same pattern as AdminStudentRecords)
        // =========================================

        private void SetupModifyForm()
        {
            panel3.Controls.Clear();

            Panel editPanel = new Panel();
            editPanel.Dock = DockStyle.Fill;
            editPanel.BackColor = Color.White;
            editPanel.AutoScroll = true;
            editPanel.Padding = new Padding(20);

            int y = 20;
            int labelWidth = 150;
            int controlWidth = 250;
            int leftMargin = 30;

            // Title
            Label lblTitle = new Label()
            {
                Text = "MODIFY FACULTY",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.Maroon,
                Location = new Point(leftMargin, y),
                Size = new Size(400, 40)
            };
            editPanel.Controls.Add(lblTitle);
            y += 60;

            // Search
            Label lblSearch = new Label() { Text = "Faculty ID:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblSearch);

            KryptonTextBox txtSearchLocal = new KryptonTextBox()
            {
                Name = "txtFacultySearchModify",
                Location = new Point(leftMargin + labelWidth + 10, y),
                Size = new Size(180, 35),
                Text = "Enter Faculty ID"
            };
            txtSearchLocal.StateCommon.Content.Color1 = Color.DarkGray;
            txtSearchLocal.Enter += (s, ev) =>
            {
                if (txtSearchLocal.Text == "Enter Faculty ID")
                {
                    txtSearchLocal.Text = "";
                    txtSearchLocal.StateCommon.Content.Color1 = Color.Black;
                }
            };
            txtSearchLocal.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchLocal.Text))
                {
                    txtSearchLocal.Text = "Enter Faculty ID";
                    txtSearchLocal.StateCommon.Content.Color1 = Color.DarkGray;
                }
            };
            editPanel.Controls.Add(txtSearchLocal);

            Button btnSearch = new Button()
            {
                Text = "Search",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point(leftMargin + labelWidth + 10 + 190, y)
            };
            btnSearch.Click += (s, ev) => SearchFacultyForModify(txtSearchLocal.Text);
            editPanel.Controls.Add(btnSearch);
            y += 60;

            // Separator
            Label lblSeparator = new Label()
            {
                Text = "─────────────────────────────────────────────────────────────────────────",
                ForeColor = Color.LightGray,
                Location = new Point(leftMargin, y),
                Size = new Size(600, 20)
            };
            editPanel.Controls.Add(lblSeparator);
            y += 30;

            // First Name
            Label lblFirstName = new Label() { Text = "First Name:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblFirstName);
            ReaLTaiizor.Controls.SmallTextBox txtFirstNameLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyFirstName", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "First Name", Text = "First Name", ForeColor = Color.DarkGray };
            txtFirstNameLocal.Enter += TextBox_Enter;
            txtFirstNameLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtFirstNameLocal);
            y += 45;

            // Middle Name
            Label lblMiddle = new Label() { Text = "Middle Name:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblMiddle);
            ReaLTaiizor.Controls.SmallTextBox txtMiddleNameLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyMiddle", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Middle Name", Text = "Middle Name", ForeColor = Color.DarkGray };
            txtMiddleNameLocal.Enter += TextBox_Enter;
            txtMiddleNameLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtMiddleNameLocal);
            y += 45;

            // Last Name
            Label lblLastName = new Label() { Text = "Last Name:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblLastName);
            ReaLTaiizor.Controls.SmallTextBox txtLastNameLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyLastName", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Last Name", Text = "Last Name", ForeColor = Color.DarkGray };
            txtLastNameLocal.Enter += TextBox_Enter;
            txtLastNameLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtLastNameLocal);
            y += 45;

            // Suffix
            Label lblSuffix = new Label() { Text = "Suffix:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblSuffix);
            ReaLTaiizor.Controls.SmallTextBox txtSuffixLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultySuffix", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Jr., Sr., I, III", Text = "Jr., Sr., I, III", ForeColor = Color.DarkGray };
            txtSuffixLocal.Enter += TextBox_Enter;
            txtSuffixLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtSuffixLocal);
            y += 45;

            // Email
            Label lblEmail = new Label() { Text = "Email:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblEmail);
            ReaLTaiizor.Controls.SmallTextBox txtEmailLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyEmail", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Email", Text = "Email", ForeColor = Color.DarkGray };
            txtEmailLocal.Enter += TextBox_Enter;
            txtEmailLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtEmailLocal);
            y += 45;

            // Contact Number
            Label lblContact = new Label() { Text = "Contact No.:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblContact);
            ReaLTaiizor.Controls.SmallTextBox txtContactLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyContact", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Contact No.", Text = "Contact No.", ForeColor = Color.DarkGray };
            txtContactLocal.Enter += TextBox_Enter;
            txtContactLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtContactLocal);
            y += 45;

            // Address
            Label lblAddress = new Label() { Text = "Address:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblAddress);
            ReaLTaiizor.Controls.SmallTextBox txtAddressLocal = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFacultyAddress", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Address", Text = "Address", ForeColor = Color.DarkGray };
            txtAddressLocal.Enter += TextBox_Enter;
            txtAddressLocal.Leave += TextBox_Leave;
            editPanel.Controls.Add(txtAddressLocal);
            y += 45;

            // Sex
            Label lblSex = new Label() { Text = "Sex:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblSex);
            ReaLTaiizor.Controls.ComboBoxEdit cmbSexLocal = new ReaLTaiizor.Controls.ComboBoxEdit() { Name = "cmbEditFacultySex", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbSexLocal.Items.Add("Select Sex");
            cmbSexLocal.Items.Add("Male");
            cmbSexLocal.Items.Add("Female");
            cmbSexLocal.SelectedIndex = 0;
            editPanel.Controls.Add(cmbSexLocal);
            y += 45;

            // Date of Birth
            Label lblDOB = new Label() { Text = "Date of Birth:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblDOB);
            DateTimePicker dtpBirthLocal = new DateTimePicker() { Name = "dtpEditFacultyBirth", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Format = DateTimePickerFormat.Short };
            editPanel.Controls.Add(dtpBirthLocal);
            y += 45;

            // Department
            Label lblDept = new Label() { Text = "Department:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblDept);
            ReaLTaiizor.Controls.ComboBoxEdit cmbDeptLocal = new ReaLTaiizor.Controls.ComboBoxEdit() { Name = "cmbEditFacultyDept", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDeptLocal.Items.Add("Select Department");
            editPanel.Controls.Add(cmbDeptLocal);

            panel3.Controls.Add(editPanel);

            // Store controls in Tag (NO BUTTONS)
            panel3.Tag = new ModifyFacultyControls
            {
                txtFirstName = txtFirstNameLocal,
                txtMiddleName = txtMiddleNameLocal,
                txtLastName = txtLastNameLocal,
                txtSuffix = txtSuffixLocal,
                txtEmail = txtEmailLocal,
                txtContact = txtContactLocal,
                txtAddress = txtAddressLocal,
                cmbSex = cmbSexLocal,
                dtpBirth = dtpBirthLocal,
                cmbDept = cmbDeptLocal,
                txtSearch = txtSearchLocal,
            };

            LoadDepartmentsIntoCombo(cmbDeptLocal);
        }
        private void LoadDepartmentsIntoCombo(ReaLTaiizor.Controls.ComboBoxEdit cmb)
        {
            string query = "SELECT Department_Name FROM department ORDER BY Department_Name";
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmb.Items.Add(reader["Department_Name"].ToString());
                    }
                }
            }
        }

        private void SearchFacultyForModify(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue) || searchValue == "Enter Faculty ID")
            {
                MessageBox.Show("Please enter a Faculty ID to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                    string query = @"
                SELECT f.*, d.Department_Name
                FROM faculty f
                LEFT JOIN department d ON f.Department_ID = d.Department_ID
                WHERE f.Faculty_ID = @id";

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
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
                                var controls = panel3.Tag as ModifyFacultyControls;
                                if (controls != null)
                                {
                                    controls.txtFirstName.Text = reader["First_Name"].ToString();
                                    controls.txtFirstName.ForeColor = Color.Black;
                                    controls.txtLastName.Text = reader["Last_Name"].ToString();
                                    controls.txtLastName.ForeColor = Color.Black;
                                    controls.txtMiddleName.Text = reader["Middle_Name"]?.ToString() ?? "";
                                    controls.txtMiddleName.ForeColor = Color.Black;
                                    controls.txtSuffix.Text = reader["Suffix"]?.ToString() ?? "";
                                    controls.txtSuffix.ForeColor = Color.Black;
                                    controls.txtEmail.Text = reader["Email"].ToString();
                                    controls.txtEmail.ForeColor = Color.Black;
                                    controls.txtContact.Text = reader["Contact_Number"]?.ToString() ?? "";
                                    controls.txtContact.ForeColor = Color.Black;
                                    controls.txtAddress.Text = reader["Address"]?.ToString() ?? "";
                                    controls.txtAddress.ForeColor = Color.Black;
                                    controls.dtpBirth.Value = Convert.ToDateTime(reader["Birth_Date"]);

                                    string sex = reader["Sex"]?.ToString() ?? "";
                                    if (sex == "Male") controls.cmbSex.SelectedIndex = 1;
                                    else if (sex == "Female") controls.cmbSex.SelectedIndex = 2;
                                    else controls.cmbSex.SelectedIndex = 0;

                                    string dept = reader["Department_Name"]?.ToString() ?? "";
                                    for (int i = 0; i < controls.cmbDept.Items.Count; i++)
                                    {
                                        if (controls.cmbDept.Items[i].ToString() == dept)
                                        {
                                            controls.cmbDept.SelectedIndex = i;
                                            break;
                                        }
                                    }


                                }
                            }
                            else
                            {
                                MessageBox.Show($"Faculty ID {searchValue} not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ClearModifyForm();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error searching faculty: " + ex.Message); }
        }

        private void ClearModifyForm()
        {
            var controls = panel3.Tag as ModifyFacultyControls;
            if (controls != null)
            {
                controls.txtFirstName.Text = "First Name"; controls.txtFirstName.ForeColor = Color.DarkGray;
                controls.txtLastName.Text = "Last Name"; controls.txtLastName.ForeColor = Color.DarkGray;
                controls.txtMiddleName.Text = "Middle Name"; controls.txtMiddleName.ForeColor = Color.DarkGray;
                controls.txtSuffix.Text = "Jr., Sr., I, III"; controls.txtSuffix.ForeColor = Color.DarkGray;
                controls.txtEmail.Text = "Email"; controls.txtEmail.ForeColor = Color.DarkGray;
                controls.txtContact.Text = "Contact No."; controls.txtContact.ForeColor = Color.DarkGray;
                controls.txtAddress.Text = "Address"; controls.txtAddress.ForeColor = Color.DarkGray;
                controls.cmbSex.SelectedIndex = 0;
                controls.cmbDept.SelectedIndex = 0;
                controls.dtpBirth.Value = DateTime.Now;
                controls.txtSearch.Text = "Enter Faculty ID";
                controls.txtSearch.StateCommon.Content.Color1 = Color.DarkGray;
            }
            currentFacultyID = "";

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // If panel3 (modify form) is visible, return to modify grid
            if (panel3.Visible)
            {
                ClearModifyForm();
                panel3.Visible = false;
                kryptonDataGridView1.Visible = true;

                cmbFilterModify.Visible = true;
                btnSaveFaculty.Visible = false;
                btnArchive.Visible = false;
                btnBackFaculty.Visible = false;

                LoadModifyData();
                return;
            }
        }

        private void btnBackView_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                panel2.Visible = false;
                panel2.Controls.Clear();
                dvgFacultyView.Visible = true;
                cmbFilterFacultyView.Visible = true;
                btnBack.Visible = false;
                return;
            }
        }
    }
    public class ModifyFacultyControls
    {
        public ReaLTaiizor.Controls.SmallTextBox txtFirstName { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtMiddleName { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtLastName { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtSuffix { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtEmail { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtContact { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtAddress { get; set; }
        public ReaLTaiizor.Controls.ComboBoxEdit cmbSex { get; set; }
        public DateTimePicker dtpBirth { get; set; }
        public ReaLTaiizor.Controls.ComboBoxEdit cmbDept { get; set; }
        public KryptonTextBox txtSearch { get; set; }
        
    }
}