using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ModifyStudentControls
    {
        public ReaLTaiizor.Controls.SmallTextBox txtFirstName { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtLastName { get; set; }
        public DateTimePicker dtpBirth { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtEmail { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtContact { get; set; }
        public ReaLTaiizor.Controls.ComboBoxEdit cmbProgram { get; set; }
        public ReaLTaiizor.Controls.SmallTextBox txtYear { get; set; }
        public KryptonTextBox txtSearch { get; set; }
    }

    public partial class AdminStudentRecords : UserControl
    {
        private static string connectionString = "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";
        private string currentStudentID = "";

        private enum ActiveView { None, StudentView, ModifyEdit }
        private ActiveView _activeView = ActiveView.None;

        public AdminStudentRecords()
        {
            InitializeComponent();
        }

        private void AdminStudentRecords_Load(object sender, EventArgs e)
        {
            InitStudentViewGrid();
            InitModifyGrid();
            SetupModifyForm();

            btnBack.Visible = false;
            hopeRoundButton2.Visible = false;
            edit_btn.Visible = false;
            btn_Archive.Visible = false;

            if (cmbFilterFacultyView.Items.Count > 0)
            {
                cmbFilterFacultyView.Items.Clear();
                cmbFilterFacultyView.Items.Add("All");
                cmbFilterFacultyView.Items.Add("BSIT");
                cmbFilterFacultyView.Items.Add("BSCS");
                cmbFilterFacultyView.SelectedIndex = 0;
            }

            if (poisonComboBox1.Items.Count > 0)
            {
                poisonComboBox1.Items.Clear();
                poisonComboBox1.Items.Add("All");
                poisonComboBox1.Items.Add("BSIT");
                poisonComboBox1.Items.Add("BSCS");
                poisonComboBox1.SelectedIndex = 0;
            }

            LoadStudentData();
            LoadModifyData();
            LoadProgramsIntoCombo();
        }

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

            Label lblTitle = new Label()
            {
                Text = "MODIFY STUDENT",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.Maroon,
                Location = new Point(leftMargin, y),
                Size = new Size(400, 40)
            };
            editPanel.Controls.Add(lblTitle);
            y += 60;

            // Search section
            Label lblSearch = new Label()
            {
                Text = "Student ID:",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(leftMargin, y),
                Size = new Size(labelWidth, 35)
            };
            editPanel.Controls.Add(lblSearch);

            KryptonTextBox txtStudentSearch = new KryptonTextBox()
            {
                Name = "txtStudentSearch",
                Location = new Point(leftMargin + labelWidth + 10, y),
                Size = new Size(180, 35),
                Text = "Enter Student ID"
            };
            txtStudentSearch.StateCommon.Content.Color1 = Color.DarkGray;
            txtStudentSearch.Enter += (s, ev) =>
            {
                if (txtStudentSearch.Text == "Enter Student ID")
                {
                    txtStudentSearch.Text = "";
                    txtStudentSearch.StateCommon.Content.Color1 = Color.Black;
                }
            };
            txtStudentSearch.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtStudentSearch.Text))
                {
                    txtStudentSearch.Text = "Enter Student ID";
                    txtStudentSearch.StateCommon.Content.Color1 = Color.DarkGray;
                }
            };
            editPanel.Controls.Add(txtStudentSearch);

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
            btnSearch.Click += (s, ev) => SearchStudent(txtStudentSearch.Text);
            editPanel.Controls.Add(btnSearch);
            y += 60;

            Label lblSeparator = new Label()
            {
                Text = "────────────────────────────────────────────────────────────────────────────────────────────────────────────────────",
                ForeColor = Color.LightGray,
                Location = new Point(leftMargin, y),
                Size = new Size(700, 20)
            };
            editPanel.Controls.Add(lblSeparator);
            y += 30;

            // First Name
            Label lblFirstName = new Label() { Text = "First Name:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblFirstName);
            ReaLTaiizor.Controls.SmallTextBox txtFirstName = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditFirstName", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "First Name", Text = "First Name", ForeColor = Color.DarkGray };
            txtFirstName.Enter += (s, ev) => { if (txtFirstName.Text == "First Name") { txtFirstName.Text = ""; txtFirstName.ForeColor = Color.Black; } };
            txtFirstName.Leave += (s, ev) => { if (string.IsNullOrWhiteSpace(txtFirstName.Text)) { txtFirstName.Text = "First Name"; txtFirstName.ForeColor = Color.DarkGray; } };
            editPanel.Controls.Add(txtFirstName);
            y += 45;

            // Last Name
            Label lblLastName = new Label() { Text = "Last Name:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblLastName);
            ReaLTaiizor.Controls.SmallTextBox txtLastName = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditLastName", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Last Name", Text = "Last Name", ForeColor = Color.DarkGray };
            txtLastName.Enter += (s, ev) => { if (txtLastName.Text == "Last Name") { txtLastName.Text = ""; txtLastName.ForeColor = Color.Black; } };
            txtLastName.Leave += (s, ev) => { if (string.IsNullOrWhiteSpace(txtLastName.Text)) { txtLastName.Text = "Last Name"; txtLastName.ForeColor = Color.DarkGray; } };
            editPanel.Controls.Add(txtLastName);
            y += 45;

            // Date of Birth
            Label lblDOB = new Label() { Text = "Date of Birth:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblDOB);
            DateTimePicker dtpBirth = new DateTimePicker() { Name = "dtpEditBirth", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Format = DateTimePickerFormat.Short };
            editPanel.Controls.Add(dtpBirth);
            y += 45;

            // Email
            Label lblEmail = new Label() { Text = "Email:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblEmail);
            ReaLTaiizor.Controls.SmallTextBox txtEmail = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditEmail", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Email", Text = "Email", ForeColor = Color.DarkGray };
            txtEmail.Enter += (s, ev) => { if (txtEmail.Text == "Email") { txtEmail.Text = ""; txtEmail.ForeColor = Color.Black; } };
            txtEmail.Leave += (s, ev) => { if (string.IsNullOrWhiteSpace(txtEmail.Text)) { txtEmail.Text = "Email"; txtEmail.ForeColor = Color.DarkGray; } };
            editPanel.Controls.Add(txtEmail);
            y += 45;

            // Contact Number
            Label lblContact = new Label() { Text = "Contact No.:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblContact);
            ReaLTaiizor.Controls.SmallTextBox txtContact = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditContact", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Contact No.", Text = "Contact No.", ForeColor = Color.DarkGray };
            txtContact.Enter += (s, ev) => { if (txtContact.Text == "Contact No.") { txtContact.Text = ""; txtContact.ForeColor = Color.Black; } };
            txtContact.Leave += (s, ev) => { if (string.IsNullOrWhiteSpace(txtContact.Text)) { txtContact.Text = "Contact No."; txtContact.ForeColor = Color.DarkGray; } };
            editPanel.Controls.Add(txtContact);
            y += 45;

            // Program
            Label lblProgram = new Label() { Text = "Program:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblProgram);
            ReaLTaiizor.Controls.ComboBoxEdit cmbProgram = new ReaLTaiizor.Controls.ComboBoxEdit() { Name = "cmbEditProgram", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), DropDownStyle = ComboBoxStyle.DropDownList };
            editPanel.Controls.Add(cmbProgram);
            y += 45;

            // Year Level
            Label lblYear = new Label() { Text = "Year Level:", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(leftMargin, y), Size = new Size(labelWidth, 35) };
            editPanel.Controls.Add(lblYear);
            ReaLTaiizor.Controls.SmallTextBox txtYear = new ReaLTaiizor.Controls.SmallTextBox() { Name = "txtEditYear", Location = new Point(leftMargin + labelWidth + 10, y), Size = new Size(controlWidth, 35), Tag = "Year Level", Text = "Year Level", ForeColor = Color.DarkGray };
            txtYear.Enter += (s, ev) => { if (txtYear.Text == "Year Level") { txtYear.Text = ""; txtYear.ForeColor = Color.Black; } };
            txtYear.Leave += (s, ev) => { if (string.IsNullOrWhiteSpace(txtYear.Text)) { txtYear.Text = "Year Level"; txtYear.ForeColor = Color.DarkGray; } };
            editPanel.Controls.Add(txtYear);

            panel3.Controls.Add(editPanel);

            panel3.Tag = new ModifyStudentControls
            {
                txtFirstName = txtFirstName,
                txtLastName = txtLastName,
                dtpBirth = dtpBirth,
                txtEmail = txtEmail,
                txtContact = txtContact,
                cmbProgram = cmbProgram,
                txtYear = txtYear,
                txtSearch = txtStudentSearch
            };
        }

        private void LoadProgramsIntoCombo()
        {
            var controls = panel3.Tag as ModifyStudentControls;
            if (controls?.cmbProgram != null)
            {
                string query = "SELECT Program_Code FROM program ORDER BY Program_Code";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            controls.cmbProgram.Items.Clear();
                            controls.cmbProgram.Items.Add("Select Program");
                            while (reader.Read())
                            {
                                controls.cmbProgram.Items.Add(reader["Program_Code"].ToString());
                            }
                            controls.cmbProgram.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void SearchStudent(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue) || searchValue == "Enter Student ID")
            {
                MessageBox.Show("Please enter a Student ID to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT 
                    s.Student_ID, s.First_Name, s.Last_Name,
                    s.Birth_Date, s.Email, s.Contact_Number, s.Year_Level,
                    p.Program_Code as Program
                FROM student s
                LEFT JOIN program p ON s.Program_ID = p.Program_ID
                WHERE s.Student_ID = @id";

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
                                currentStudentID = reader["Student_ID"].ToString();
                                var controls = panel3.Tag as ModifyStudentControls;
                                if (controls != null)
                                {
                                    controls.txtFirstName.Text = reader["First_Name"].ToString();
                                    controls.txtFirstName.ForeColor = Color.Black;
                                    controls.txtLastName.Text = reader["Last_Name"].ToString();
                                    controls.txtLastName.ForeColor = Color.Black;
                                    controls.dtpBirth.Value = Convert.ToDateTime(reader["Birth_Date"]);
                                    controls.txtEmail.Text = reader["Email"].ToString();
                                    controls.txtEmail.ForeColor = Color.Black;
                                    controls.txtContact.Text = reader["Contact_Number"]?.ToString() ?? "";
                                    controls.txtContact.ForeColor = string.IsNullOrEmpty(reader["Contact_Number"]?.ToString()) ? Color.DarkGray : Color.Black;
                                    controls.txtYear.Text = reader["Year_Level"].ToString();
                                    controls.txtYear.ForeColor = Color.Black;

                                    string program = reader["Program"]?.ToString() ?? "";
                                    int progIndex = 0;
                                    for (int i = 0; i < controls.cmbProgram.Items.Count; i++)
                                    {
                                        if (controls.cmbProgram.Items[i].ToString() == program) { progIndex = i; break; }
                                    }
                                    controls.cmbProgram.SelectedIndex = progIndex;

                                    edit_btn.Enabled = true; edit_btn.Visible = true; edit_btn.PrimaryColor = Color.Maroon;
                                    btn_Archive.Enabled = true; btn_Archive.Visible = true; btn_Archive.PrimaryColor = Color.Maroon;
                                    MessageBox.Show($"Student ID {searchValue} found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Student ID {searchValue} not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error searching student: " + ex.Message); }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentStudentID))
            {
                MessageBox.Show("No student record loaded. Please search for a student first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var controls = panel3.Tag as ModifyStudentControls;
            if (controls == null) return;

            string firstName = controls.txtFirstName.Text.Trim();
            string lastName = controls.txtLastName.Text.Trim();
            string email = controls.txtEmail.Text.Trim();

            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName))
            { MessageBox.Show("Please enter a valid First Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName))
            { MessageBox.Show("Please enter a valid Last Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (email == "Email" || string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            { MessageBox.Show("Please enter a valid Email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int programId = 1;
            string programCode = controls.cmbProgram.SelectedItem?.ToString() ?? "BSIT";
            if (programCode != "Select Program")
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Program_ID FROM program WHERE Program_Code = @code", conn))
                    {
                        cmd.Parameters.AddWithValue("@code", programCode);
                        object result = cmd.ExecuteScalar();
                        if (result != null) programId = Convert.ToInt32(result);
                    }
                }
            }

            if (MessageBox.Show("Save changes to this student record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string updateQuery = @"UPDATE student SET First_Name=@first, Last_Name=@last, Birth_Date=@birthdate, Email=@email, Contact_Number=@contact, Year_Level=@year, Program_ID=@programId WHERE Student_ID=@id";
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@first", firstName);
                            cmd.Parameters.AddWithValue("@last", lastName);
                            cmd.Parameters.AddWithValue("@birthdate", controls.dtpBirth.Value);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@contact", controls.txtContact.Text == "Contact No." ? "" : controls.txtContact.Text.Trim());
                            cmd.Parameters.AddWithValue("@year", controls.txtYear.Text.Trim());
                            cmd.Parameters.AddWithValue("@programId", programId);
                            cmd.Parameters.AddWithValue("@id", currentStudentID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Student record saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearModifyForm();
                    LoadStudentData();
                    LoadModifyData();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btn_Archive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentStudentID))
            { MessageBox.Show("No student record loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"Delete student record {currentStudentID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM student WHERE Student_ID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentStudentID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Student record deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearModifyForm();
                    LoadStudentData();
                    LoadModifyData();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void ClearModifyForm()
        {
            var controls = panel3.Tag as ModifyStudentControls;
            if (controls != null)
            {
                controls.txtFirstName.Text = "First Name"; controls.txtFirstName.ForeColor = Color.DarkGray;
                controls.txtLastName.Text = "Last Name"; controls.txtLastName.ForeColor = Color.DarkGray;
                controls.txtEmail.Text = "Email"; controls.txtEmail.ForeColor = Color.DarkGray;
                controls.txtContact.Text = "Contact No."; controls.txtContact.ForeColor = Color.DarkGray;
                controls.txtYear.Text = "Year Level"; controls.txtYear.ForeColor = Color.DarkGray;
                controls.cmbProgram.SelectedIndex = 0;
                controls.dtpBirth.Value = DateTime.Now;
                controls.txtSearch.Text = "Enter Student ID";
                controls.txtSearch.StateCommon.Content.Color1 = Color.DarkGray;
            }
            currentStudentID = "";
            edit_btn.Enabled = false; edit_btn.Visible = false;
            btn_Archive.Enabled = false; btn_Archive.Visible = false;
        }

        private void InitStudentViewGrid()
        {
            dvgStudentView.Columns.Clear();
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "StudentID", HeaderText = "Student ID", Width = 300 });
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Program", HeaderText = "Program", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dvgStudentView.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "Action", Name = "btnView", Text = "View", Width = 90, UseColumnTextForButtonValue = true });
        }

        private void InitModifyGrid()
        {
            kryptonDataGridView1.Columns.Clear();
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "StudentID", HeaderText = "Student ID", Width = 300 });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Program", HeaderText = "Program", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            kryptonDataGridView1.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "Action", Name = "btnEdit", Text = "Edit", Width = 90, UseColumnTextForButtonValue = true });
        }

        private void LoadStudentData()
        {
            dvgStudentView.Rows.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.Student_ID, CONCAT(COALESCE(s.First_Name,''),' ',COALESCE(s.Last_Name,'')) as FullName, COALESCE(p.Program_Code,'N/A') as Program FROM student s LEFT JOIN program p ON s.Program_ID = p.Program_ID ORDER BY s.Student_ID", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            dvgStudentView.Rows.Add(reader["Student_ID"].ToString(), reader["FullName"].ToString(), reader["Program"].ToString());
                    }
                }
            }
        }

        private void LoadModifyData()
        {
            kryptonDataGridView1.Rows.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.Student_ID, CONCAT(COALESCE(s.First_Name,''),' ',COALESCE(s.Last_Name,'')) as FullName, COALESCE(p.Program_Code,'N/A') as Program FROM student s LEFT JOIN program p ON s.Program_ID = p.Program_ID ORDER BY s.Student_ID", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            kryptonDataGridView1.Rows.Add(reader["Student_ID"].ToString(), reader["FullName"].ToString(), reader["Program"].ToString());
                    }
                }
            }
        }

        private void cmbFilterFacultyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = cmbFilterFacultyView.SelectedItem?.ToString() ?? "All";
            foreach (DataGridViewRow row in dvgStudentView.Rows)
            {
                if (!row.IsNewRow)
                    row.Visible = filter == "All" || (row.Cells["Program"].Value?.ToString() ?? "") == filter;
            }
        }

        private void poisonComboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string filter = poisonComboBox1.SelectedItem?.ToString() ?? "All";
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (!row.IsNewRow)
                    row.Visible = filter == "All" || (row.Cells["Program"].Value?.ToString() ?? "") == filter;
            }
        }

        private void dvgStudentView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dvgStudentView.Columns["btnView"].Index) return;
            string studentID = dvgStudentView.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.Student_ID, s.First_Name, s.Last_Name, s.Birth_Date, s.Email, s.Contact_Number, s.Year_Level, COALESCE(p.Program_Code,'N/A') as Program FROM student s LEFT JOIN program p ON s.Program_ID = p.Program_ID WHERE s.Student_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dvgStudentView.Visible = false;
                            cmbFilterFacultyView.Visible = false;
                            btnClearView.Visible = false;
                            hopeRoundButton2.Visible = true;
                            panel2.Visible = true;
                            panel2.Controls.Clear();

                            Panel mainPanel = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true, Padding = new Padding(20) };
                            int y = 20, leftMargin = 30;
                            mainPanel.Controls.Add(new Label() { Text = "STUDENT INFORMATION", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.Maroon, Location = new Point(leftMargin, y), Size = new Size(400, 40) });
                            y += 60;

                            void AddField(string label, string value)
                            {
                                mainPanel.Controls.Add(new Label() { Text = label, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), Location = new Point(leftMargin, y), Size = new Size(150, 30) });
                                mainPanel.Controls.Add(new Label() { Text = string.IsNullOrEmpty(value) ? "—" : value, Font = new Font("Segoe UI", 11), ForeColor = Color.Black, Location = new Point(leftMargin + 160, y), Size = new Size(350, 30) });
                                y += 35;
                            }

                            AddField("Student ID:", reader["Student_ID"].ToString());
                            AddField("First Name:", reader["First_Name"].ToString());
                            AddField("Last Name:", reader["Last_Name"].ToString());
                            AddField("Program:", reader["Program"].ToString());
                            AddField("Year Level:", reader["Year_Level"].ToString());
                            AddField("Email:", reader["Email"].ToString());
                            AddField("Date of Birth:", Convert.ToDateTime(reader["Birth_Date"]).ToString("MMMM dd, yyyy"));
                            AddField("Contact No.:", reader["Contact_Number"]?.ToString() ?? "");

                            Button btnBackLocal = new Button() { Text = "Back", Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.Maroon, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(120, 40), Location = new Point(leftMargin, y + 20) };
                            btnBackLocal.Click += (s, ev) => { panel2.Visible = false; dvgStudentView.Visible = true; cmbFilterFacultyView.Visible = true; btnClearView.Visible = true; hopeRoundButton2.Visible = false; };
                            mainPanel.Controls.Add(btnBackLocal);
                            panel2.Controls.Add(mainPanel);
                            _activeView = ActiveView.StudentView;
                        }
                    }
                }
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnEdit"].Index) return;
            kryptonDataGridView1.Visible = false;
            poisonComboBox1.Visible = false;
            hopeRoundButton1.Visible = false;
            btnBack.Visible = true;
            panel3.Visible = true;
            _activeView = ActiveView.ModifyEdit;

            string studentID = kryptonDataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
            var controls = panel3.Tag as ModifyStudentControls;
            if (controls != null)
            {
                controls.txtSearch.Text = studentID;
                controls.txtSearch.StateCommon.Content.Color1 = Color.Black;
                SearchStudent(studentID);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) { ReturnToGrid(); }
        private void hopeRoundButton2_Click(object sender, EventArgs e) { ReturnToGrid(); }

        private void ReturnToGrid()
        {
            if (_activeView == ActiveView.StudentView)
            {
                panel2.Controls.Clear(); panel2.Visible = false;
                dvgStudentView.Visible = true; cmbFilterFacultyView.Visible = true; btnClearView.Visible = true; hopeRoundButton2.Visible = false;
            }
            else if (_activeView == ActiveView.ModifyEdit)
            {
                ClearModifyForm(); panel3.Visible = false;
                kryptonDataGridView1.Visible = true; poisonComboBox1.Visible = true; hopeRoundButton1.Visible = true;
                edit_btn.Visible = false; btn_Archive.Visible = false;
            }
            btnBack.Visible = false;
            _activeView = ActiveView.None;
            LoadStudentData(); LoadModifyData();
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim(), lastName = txtLastName.Text.Trim(), email = txtEmail.Text.Trim(), contactNo = txtContactNo.Text.Trim();
            if (firstName == "First Name" || string.IsNullOrWhiteSpace(firstName)) { MessageBox.Show("Please enter First Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (lastName == "Last Name" || string.IsNullOrWhiteSpace(lastName)) { MessageBox.Show("Please enter Last Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (email == "Email" || string.IsNullOrWhiteSpace(email) || !email.Contains("@")) { MessageBox.Show("Please enter valid Email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cmbProgram.SelectedIndex == 0) { MessageBox.Show("Please select Program.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int programId = 1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT Program_ID FROM program WHERE Program_Code = @code", conn))
                {
                    cmd.Parameters.AddWithValue("@code", cmbProgram.SelectedItem.ToString());
                    object result = cmd.ExecuteScalar();
                    if (result != null) programId = Convert.ToInt32(result);
                }
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO student (Program_ID, First_Name, Last_Name, Email, Contact_Number, Birth_Date, Year_Level, Password) VALUES (@programId, @first, @last, @email, @contact, @birthdate, 1, 'student123')", conn))
                {
                    cmd.Parameters.AddWithValue("@programId", programId);
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contact", contactNo == "Contact No." ? "" : contactNo);
                    cmd.Parameters.AddWithValue("@birthdate", dtpBirthDay.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Student created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetCreateForm();
            LoadStudentData(); LoadModifyData();
        }

        private void ResetCreateForm()
        {
            txtFirstName.Text = "First Name"; txtMiddleName.Text = "Middle Name"; txtLastName.Text = "Last Name"; txtSuffix.Text = "Jr., Sr., I, III";
            txtAddress.Text = "Address"; txtContactNo.Text = "Contact No."; txtEmail.Text = "Email"; txtStudentID.Text = "Student ID";
            txtFirstName.ForeColor = txtMiddleName.ForeColor = txtLastName.ForeColor = txtSuffix.ForeColor = txtAddress.ForeColor = txtContactNo.ForeColor = txtEmail.ForeColor = txtStudentID.ForeColor = Color.DarkGray;
            cmbProgram.SelectedIndex = 0; cmbSection.SelectedIndex = 0; cmbSex.SelectedIndex = 0; dtpBirthDay.Value = DateTime.Now;
        }

        private void btnRandomized_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            txtStudentID.Text = $"2024-00{rnd.Next(100, 999)}-SM-{rnd.Next(0, 9)}";
            txtStudentID.ForeColor = Color.Black;
        }

        private void btnUploadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() { Filter = "CSV Files (*.csv)|*.csv", Title = "Select CSV File" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string[] lines = File.ReadAllLines(dlg.FileName);
            dgvPreview.Rows.Clear(); dgvPreview.Columns.Clear();
            string[] headers = lines[0].Split(',');
            foreach (string header in headers) dgvPreview.Columns.Add(header, header);
            for (int i = 1; i < lines.Length; i++) dgvPreview.Rows.Add(lines[i].Split(','));
            dgvPreview.Visible = true; btnConfirm.Visible = true; btnCancel.Visible = true; btnRandomized.Visible = false; btnCreateStudent.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to load this CSV file?", "Confirm Batch Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int successCount = 0;
                foreach (DataGridViewRow row in dgvPreview.Rows)
                {
                    if (row.IsNewRow) continue;
                    try
                    {
                        string firstName = row.Cells[0].Value?.ToString(), lastName = row.Cells[1].Value?.ToString(), email = row.Cells[2].Value?.ToString(), programCode = row.Cells[3].Value?.ToString() ?? "BSIT";
                        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                        {
                            int programId = 1;
                            using (MySqlConnection conn = new MySqlConnection(connectionString))
                            {
                                conn.Open();
                                using (MySqlCommand progCmd = new MySqlCommand("SELECT Program_ID FROM program WHERE Program_Code = @code", conn))
                                {
                                    progCmd.Parameters.AddWithValue("@code", programCode);
                                    object progResult = progCmd.ExecuteScalar();
                                    if (progResult != null) programId = Convert.ToInt32(progResult);
                                }
                                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO student (Program_ID, First_Name, Last_Name, Email, Password, Birth_Date, Year_Level) VALUES (@programId, @first, @last, @email, 'student123', @birthdate, 1)", conn))
                                {
                                    cmd.Parameters.AddWithValue("@programId", programId);
                                    cmd.Parameters.AddWithValue("@first", firstName);
                                    cmd.Parameters.AddWithValue("@last", lastName);
                                    cmd.Parameters.AddWithValue("@email", email ?? "");
                                    cmd.Parameters.AddWithValue("@birthdate", DateTime.Now.AddYears(-20));
                                    cmd.ExecuteNonQuery(); successCount++;
                                }
                            }
                        }
                    }
                    catch { }
                }
                MessageBox.Show($"Successfully loaded {successCount} student records.", "Batch Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetCSVPreview(); LoadStudentData(); LoadModifyData();
        }

        private void btnCancel_Click(object sender, EventArgs e) { ResetCSVPreview(); }
        private void ResetCSVPreview() { dgvPreview.Visible = false; btnConfirm.Visible = false; btnCancel.Visible = false; btnCreateStudent.Visible = true; btnRandomized.Visible = true; }
        private void btnClearView_Click(object sender, EventArgs e) { cmbFilterFacultyView.SelectedIndex = 0; LoadStudentData(); }
        private void hopeRoundButton1_Click(object sender, EventArgs e) { poisonComboBox1.SelectedIndex = 0; LoadModifyData(); }

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

        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }
        private void foreverTabPage1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void btnSeachModify_Click(object sender, EventArgs e) { }
        private void btnSaveChanges_Click(object sender, EventArgs e) { }
        private void btnClear_Click(object sender, EventArgs e) { }
    }
}