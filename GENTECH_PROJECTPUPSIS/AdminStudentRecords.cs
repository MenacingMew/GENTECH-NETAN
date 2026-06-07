using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public partial class AdminStudentRecords : UserControl
    {
        private string id;
        // Tracks which tab opened the detail view so btnBack knows what to restore
        private enum ActiveView { None, StudentView, ModifyEdit }
        private ActiveView _activeView = ActiveView.None;

        public AdminStudentRecords()
        {
            InitializeComponent();

        }

        private void AdminStudentRecords_Load(object sender, EventArgs e)
        {
            InitStudentViewGrid();   // sets up columns + btnView
            LoadStudentViewGrid();   // binds data only

            InitModifyGrid();        // sets up columns + btnEdit
            LoadModifyGrid();        // binds data only

            InitStudentViewFilter();
        }
        private void LoadStudentViewGrid()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                TempStudent_ID                                AS `Student ID`,
                CONCAT_WS(' ', FirstName, NULLIF(MiddleName, ''), LastName) AS `Full Name`,
                Email,
                ApplicationDate                               AS `Application Date`
            FROM temporary_student";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dvgStudentView.DataSource = dt;
                }
            }
        }
        private void LoadModifyGrid()
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                TempStudent_ID                                AS `Student ID`,
                CONCAT_WS(' ', FirstName, NULLIF(MiddleName, ''), LastName) AS `Full Name`,
                Email,
                ApplicationDate                               AS `Application Date`
            FROM temporary_student";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                }
            }
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────

        // ─────────────────────────────────────────────
        // INIT HELPERS
        // ─────────────────────────────────────────────
        private void InitStudentViewGrid()
        {
            dvgStudentView.Columns.Clear();
            dvgStudentView.AutoGenerateColumns = false;

            // Data columns first
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Student ID", HeaderText = "Student ID", Name = "Student ID", Width = 150 });
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Full Name", HeaderText = "Full Name", Name = "Full Name", Width = 200 });
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email", Width = 200 });
            dvgStudentView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Application Date", HeaderText = "Application Date", Name = "Application Date", Width = 130 });

            // Action button LAST
            dvgStudentView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Name = "btnView",
                Text = "View",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Standard
            });
        }

        /*private void AddStudentViewRow(string studentID, string name, string program)
        {
            int index = dvgStudentView.Rows.Add();
            DataGridViewRow row = dvgStudentView.Rows[index];
            row.Cells[0].Value = studentID;
            row.Cells[1].Value = name;
            row.Cells[2].Value = program;
        }
        */
        private void InitStudentViewFilter()
        {
            cmbFilterFacultyView.Items.Clear();
            cmbFilterFacultyView.Items.Add("All");
            cmbFilterFacultyView.Items.Add("Name");
            cmbFilterFacultyView.Items.Add("Student ID");
            cmbFilterFacultyView.Items.Add("Program");
            cmbFilterFacultyView.SelectedIndex = 0;

            ShowAllColumnsInStudentView();
        }

        private void InitModifyViewFilter()
        {
            cmbFilterFacultyView.Items.Clear();
            cmbFilterFacultyView.Items.Add("All");
            cmbFilterFacultyView.Items.Add("Name");
            cmbFilterFacultyView.Items.Add("Student ID");
            cmbFilterFacultyView.Items.Add("Program");
            cmbFilterFacultyView.SelectedIndex = 0;
        }

        private void InitModifyGrid()
        {
            kryptonDataGridView1.Columns.Clear();
            kryptonDataGridView1.AutoGenerateColumns = false;

            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Student ID", HeaderText = "Student ID", Name = "Student ID", Width = 150 });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Full Name", HeaderText = "Full Name", Name = "Full Name", Width = 200 });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email", Width = 200 });
            kryptonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Application Date", HeaderText = "Application Date", Name = "Application Date", Width = 130 });

            // Action button LAST
            kryptonDataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Name = "btnEdit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 80
            });
        }
        private void AddStudentRow(string studentID, string name, string program)
        {
            int index = kryptonDataGridView1.Rows.Add();
            DataGridViewRow row = kryptonDataGridView1.Rows[index];
            row.Cells[0].Value = studentID;
            row.Cells[1].Value = name;
            row.Cells[2].Value = program;
        }

        // ─────────────────────────────────────────────
        // PLACEHOLDER TEXTBOX BEHAVIOR
        // ─────────────────────────────────────────────
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt.Text.Replace(" ", "") == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void KryptonTextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as KryptonTextBox;
            if (txt.StateCommon.Content.Color1 == Color.DarkGray)
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void KryptonTextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as KryptonTextBox;
            if (txt.Text.Replace(" ", "") == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ReaLTaiizor.Controls.ComboBoxEdit;
            comboBox.ForeColor = comboBox.SelectedIndex == 0 ? Color.DarkGray : Color.Black;
        }

        // ─────────────────────────────────────────────
        // CREATE TAB
        // ─────────────────────────────────────────────
        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            bool hasEmpty =
                txtFirstName.ForeColor == Color.DarkGray ||
                txtMiddleName.ForeColor == Color.DarkGray ||
                txtLastName.ForeColor == Color.DarkGray ||
                txtSuffix.ForeColor == Color.DarkGray ||
                txtAddress.ForeColor == Color.DarkGray ||
                txtContactNo.ForeColor == Color.DarkGray ||
                txtEmail.ForeColor == Color.DarkGray ||
                txtStudentID.ForeColor == Color.DarkGray ||
                cmbProgram.SelectedIndex == 0 ||
                cmbSex.SelectedIndex == 0 ||
                cmbSection.SelectedIndex == 0;

            if (hasEmpty)
            {
                MessageBox.Show(
                    "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                    "Application Incomplete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "The student has been successfully created.",
                "Student Created",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetCreateForm();
        }

        private void ResetCreateForm()
        {
            ResetTextBox(txtFirstName);
            ResetTextBox(txtMiddleName);
            ResetTextBox(txtLastName);
            ResetTextBox(txtSuffix);
            ResetTextBox(txtAddress);
            ResetTextBox(txtContactNo);
            ResetTextBox(txtEmail);
            ResetTextBox(txtStudentID);
            dtpBirthDay.Value = DateTime.Now;
            cmbProgram.SelectedIndex = 0;
            cmbSection.SelectedIndex = 0;
            cmbSex.SelectedIndex = 0;
        }

        private void ResetTextBox(ReaLTaiizor.Controls.SmallTextBox txt)
        {
            txt.Text = txt.Tag.ToString();
            txt.ForeColor = Color.DarkGray;
        }

        private void btnRandomized_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            txtStudentID.Text = $"2024-00{rnd.Next(100, 999)}-SM-{rnd.Next(0, 9)}";
            txtStudentID.ForeColor = Color.Black;
        }

        // ─────────────────────────────────────────────
        // CSV BATCH UPLOAD (Create Tab)
        // ─────────────────────────────────────────────
        private void btnUploadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select CSV File"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            string[] lines = File.ReadAllLines(dlg.FileName);

            if (lines.Length == 0)
            {
                MessageBox.Show("The selected CSV file is empty.", "Invalid File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate headers
            string[] headers = lines[0].Split(',');
            bool headersValid =
                headers.Length >= 4 &&
                headers[0].Trim() == "FirstName" &&
                headers[1].Trim() == "MiddleName" &&
                headers[2].Trim() == "LastName" &&
                headers[3].Trim() == "Email";

            if (!headersValid)
            {
                MessageBox.Show(
                    "Invalid CSV format. Please use the correct import template.\n\n" +
                    "Expected columns:\n  FirstName, MiddleName, LastName, Email\n\n" +
                    "Note: Do not use the exported CSV — that is a different format.",
                    "Wrong CSV Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ── Setup grid ──────────────────────────────────
            dgvPreview.Rows.Clear();
            dgvPreview.Columns.Clear();



            dgvPreview.Columns.Add("FirstName", "First Name");
            dgvPreview.Columns.Add("MiddleName", "Middle Name");
            dgvPreview.Columns.Add("LastName", "Last Name");
            dgvPreview.Columns.Add("Email", "Email");

            // ── Add rows, skip blank lines ───────────────────
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] values = line.Split(',');
                if (values.Length < 4) continue;

                // Skip if ALL four values are empty
                if (string.IsNullOrWhiteSpace(values[0]) &&
                    string.IsNullOrWhiteSpace(values[1]) &&
                    string.IsNullOrWhiteSpace(values[2]) &&
                    string.IsNullOrWhiteSpace(values[3])) continue;
                
                dgvPreview.Rows.Add(values[0].Trim(), values[1].Trim(),
                                    values[2].Trim(), values[3].Trim());
            }

            // ── Style ────────────────────────────────────────
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
            Control parent = groupBox1.Parent;
            parent.Controls.Add(dgvPreview);
            // ── Center in parent ─────────────────────────────
            int gridWidth = parent.Width - 100;
            int gridX = (parent.Width - gridWidth) / 2;
            int gridY = 80; // push down below the "Create Student" title // adjust this number until it sits below the form fields
                            // At the bottom of btnUploadCSV_Click, before dgvPreview.Visible = true
            dgvPreview.Parent.Height = dgvPreview.Location.Y + dgvPreview.Height + 20;
            dgvPreview.Location = new Point(gridX, gridY);
            dgvPreview.Width = gridWidth;
            dgvPreview.Height = (dgvPreview.Rows.Count + 1) * dgvPreview.RowTemplate.Height
                                  + dgvPreview.ColumnHeadersHeight + 20;

            // ── Show/hide controls ───────────────────────────

            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.Visible = true;
            btnConfirm.Visible = true;
            btnCancel.Visible = true;
            btnRandomized.Visible = false;
            btnCreateStudent.Visible = false;

            groupBox1.Visible = false;
            dgvPreview.Visible = true;
            btnConfirm.Visible = true;
            btnCancel.Visible = true;
            btnRandomized.Visible = false;
            btnCreateStudent.Visible = false;
        }

        // In AdminStudentRecords.cs — replace the old btnConfirm_Click
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to import these students into the database?\n\nMake sure the file format is correct before proceeding.",
                "Confirm Import",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            int successCount = 0;
            int failCount = 0;

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvPreview.Rows)
                    {
                        if (row.IsNewRow) continue;

                        try
                        {
                            string firstName = row.Cells[0].Value?.ToString();
                            string middleName = row.Cells[1].Value?.ToString();
                            string lastName = row.Cells[2].Value?.ToString();
                            string email = row.Cells[3].Value?.ToString();

                            if (string.IsNullOrWhiteSpace(firstName) ||
                                string.IsNullOrWhiteSpace(lastName) ||
                                string.IsNullOrWhiteSpace(email))
                            {
                                failCount++;
                                continue;
                            }

                            string query = @"
                        INSERT INTO temporary_student 
                            (Credential_ID, PasswordHash, FirstName, MiddleName, LastName, Email, Status)
                        VALUES 
                            (0, '', @FirstName, @MiddleName, @LastName, @Email, 0)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@FirstName", firstName);
                                cmd.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
                                cmd.Parameters.AddWithValue("@LastName", lastName);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.ExecuteNonQuery();
                                successCount++;
                            }
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Database error:\n\n{ex.Message}",
                    "Import Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                $"Import complete.\n\n✔ {successCount} inserted\n✘ {failCount} skipped",
                "Import Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetCSVPreview();
            LoadStudentViewGrid();
            LoadModifyGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetCSVPreview();
        }

        private void ResetCSVPreview()
        {
            groupBox1.Controls.Add(dgvPreview);
            dgvPreview.Visible = false;
            btnConfirm.Visible = false;
            btnCancel.Visible = false;
            btnCreateStudent.Visible = true;
            btnRandomized.Visible = true;
            groupBox1.Visible = true;

            dgvPreview.Parent.Height = 315; // ← replace with the original panel height from the designer
        }

        // ─────────────────────────────────────────────
        // STUDENT VIEW TAB — FILTER
        // ─────────────────────────────────────────────
        private void cmbFilterFacultyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {

            string selectedProgram = cmbFilterFacultyView.Text;

            foreach (DataGridViewRow row in dvgStudentView.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string program = row.Cells[2].Value?.ToString() ?? "";

                bool programMatch =
                    selectedProgram == "All" || program == selectedProgram;

                row.Visible = programMatch;
            }
        }

        private void FilterDataModify()
        {
            string selected = cmbFilterFacultyView.Text;

            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells[1].Value?.ToString() ?? "";

                bool match =
                    selected == "All" ||
                    name.Contains(selected);

                row.Visible = match;
            }
        }


        private void ShowAllColumnsInStudentView()
        {
            foreach (DataGridViewColumn col in dvgStudentView.Columns)
                col.Visible = true;
        }

        private void SetStudentViewColumnVisibility(bool studentId, bool name, bool program)
        {
            SetColumnVisible(dvgStudentView, "StudentID", studentId);
            SetColumnVisible(dvgStudentView, "StudentName", name);
            SetColumnVisible(dvgStudentView, "Program", program);
        }

        // ─────────────────────────────────────────────
        // STUDENT VIEW TAB — VIEW BUTTON
        // ─────────────────────────────────────────────
        private void dvgStudentView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !dvgStudentView.Columns.Contains("btnView"))
                return;
            if (e.ColumnIndex != dvgStudentView.Columns["btnView"].Index)
                return;

            var cellValue = dvgStudentView.Rows[e.RowIndex].Cells["Student ID"].Value;
            if (cellValue == null) return;

            string studentId = cellValue.ToString();
            OpenStudentView(studentId, panel2);

            dvgStudentView.Visible = false;
            cmbFilterFacultyView.Visible = false;
            hopeRoundButton2.Visible = true;
            _activeView = ActiveView.StudentView;
        }

        // ─────────────────────────────────────────────
        // MODIFY TAB — FILTER
        // ─────────────────────────────────────────────
        private void poisonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyColumnFilter(
                cmbFilterFacultyView.SelectedItem?.ToString() ?? string.Empty,
                isModifyGrid: true);
        }

        private void ShowAllColumnsInModifyView()
        {
            foreach (DataGridViewColumn col in kryptonDataGridView1.Columns)
                col.Visible = true;
        }

        private void SetModifyViewColumnVisibility(bool studentId, bool name, bool program)
        {
            if (kryptonDataGridView1.Columns.Count > 0)
                kryptonDataGridView1.Columns[0].Visible = studentId;
            if (kryptonDataGridView1.Columns.Count > 1)
                kryptonDataGridView1.Columns[1].Visible = name;
            if (kryptonDataGridView1.Columns.Count > 2)
                kryptonDataGridView1.Columns[2].Visible = program;

            if (kryptonDataGridView1.Columns.Contains("btnEdit"))
                kryptonDataGridView1.Columns["btnEdit"].Visible = true;
        }

        // ─────────────────────────────────────────────
        // MODIFY TAB — EDIT BUTTON
        // ─────────────────────────────────────────────
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnEdit"].Index)
                return;

            var cellValue = kryptonDataGridView1.Rows[e.RowIndex].Cells[0].Value;

            if (cellValue == null) return;

            id = cellValue.ToString();

            OpenStudentEdit(id, panel3);

            kryptonDataGridView1.Visible = false;
            cmbFilterFacultyView.Visible = false;

            btnBack.Visible = true;
            edit_btn.Visible = true;
            btn_Archive.Visible = true;

            _activeView = ActiveView.ModifyEdit;
        }

        // ─────────────────────────────────────────────
        // BACK BUTTON
        // ─────────────────────────────────────────────
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_activeView == ActiveView.StudentView)
            {
                panel2.Controls.Clear();
                panel2.Visible = false;
                dvgStudentView.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }
            else if (_activeView == ActiveView.ModifyEdit)
            {
                panel3.Controls.Clear();
                panel3.Visible = false;
                kryptonDataGridView1.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }

            btnBack.Visible = false;
            _activeView = ActiveView.None;
        }

        // ─────────────────────────────────────────────
        // MODIFY TAB — SEARCH / SAVE / DELETE / CLEAR
        // ─────────────────────────────────────────────
        private void btnSeachModify_Click(object sender, EventArgs e)
        {
            // TODO: search kryptonDataGridView1 by txtStudentIDModifySearch
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // TODO: validate and save changes for selected student
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_activeView == ActiveView.StudentView)
            {
                panel2.Controls.Clear();
                panel2.Visible = false;
                dvgStudentView.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }
            else if (_activeView == ActiveView.ModifyEdit)
            {
                panel3.Controls.Clear();
                panel3.Visible = false;
                kryptonDataGridView1.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }

            edit_btn.Visible = false;
            hopeRoundButton2.Visible = false;
            btn_Archive.Visible = false;
            btnBack.Visible = false;
            _activeView = ActiveView.None;

        }
        private void AddEditButtonColumn()
        {
            if (!kryptonDataGridView1.Columns.Contains("btnEdit"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Action";
                btn.Name = "btnEdit";
                btn.Text = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 80;

                kryptonDataGridView1.Columns.Add(btn);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // TODO: clear modify form fields
        }

        // ─────────────────────────────────────────────
        // SHARED HELPERS
        // ─────────────────────────────────────────────
        private void ApplyColumnFilter(string selection, bool isModifyGrid)
        {
            switch (selection)
            {
                case "Name":
                    if (isModifyGrid) SetModifyViewColumnVisibility(false, true, false);
                    else SetStudentViewColumnVisibility(false, true, false);
                    break;
                case "Student ID":
                    if (isModifyGrid) SetModifyViewColumnVisibility(true, false, false);
                    else SetStudentViewColumnVisibility(true, false, false);
                    break;
                case "Program":
                    if (isModifyGrid) SetModifyViewColumnVisibility(false, false, true);
                    else SetStudentViewColumnVisibility(false, false, true);
                    break;
                default:
                    if (isModifyGrid) ShowAllColumnsInModifyView();
                    else ShowAllColumnsInStudentView();
                    break;
            }
        }

        private void SetColumnVisible(DataGridView grid, string columnName, bool visible)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].Visible = visible;
        }

        private void OpenStudentView(string studentId, Panel targetPanel)
        {
            AdminFacultyView view = new AdminFacultyView(studentId, "View");
            view.TopLevel = false;
            view.Dock = DockStyle.Fill;
            view.FormBorderStyle = FormBorderStyle.None;

            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(view);
            targetPanel.Visible = true;
            view.Show();
        }

      
        private void OpenStudentEdit(string studentId, Panel targetPanel)
        {
            // TODO: replace AdminFacultyView with your Edit form when ready
            AdminFacultyView edit = new AdminFacultyView(studentId, "Edit");
            edit.TopLevel = false;
            edit.Dock = DockStyle.Fill;
            edit.FormBorderStyle = FormBorderStyle.None;

            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(edit);
            targetPanel.Visible = true;
            edit.Show();
        }

        // ─────────────────────────────────────────────
        // DESIGNER-REQUIRED STUBS
        // ─────────────────────────────────────────────
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }
        private void foreverTabPage1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void hopeRoundButton1_Click(object sender, EventArgs e) { }
        private void btnClearView_Click(object sender, EventArgs e) { }
        private void poisonComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            poisonComboBox1_SelectedIndexChanged(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hopeRoundButton2_Click(object sender, EventArgs e)
        {
            if (_activeView == ActiveView.StudentView)
            {
                panel2.Controls.Clear();
                panel2.Visible = false;
                dvgStudentView.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }
            else if (_activeView == ActiveView.ModifyEdit)
            {
                panel3.Controls.Clear();
                panel3.Visible = false;
                kryptonDataGridView1.Visible = true;
                cmbFilterFacultyView.Visible = true;
            }

            edit_btn.Visible = false;
            btnBack.Visible = false;
            hopeRoundButton2.Visible = false;
            _activeView = ActiveView.None;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                MessageBox.Show(
                    "No student record is currently loaded for editing.",
                    "No Record Loaded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // TODO: actual save-to-DB logic here using `id`

            MessageBox.Show(
                "The student record has been successfully updated.",
                "Changes Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            panel3.Controls.Clear();
            panel3.Visible = false;
            kryptonDataGridView1.Visible = true;
            cmbFilterFacultyView.Visible = true;
            edit_btn.Visible = false;
            btnBack.Visible = false;
            btn_Archive.Visible = false;
            _activeView = ActiveView.None;
        }

        private void btn_Archive_Click(object sender, EventArgs e)
        {
            //Archive logic here (e.g., mark as archived in database, remove from grid, etc.)
            MessageBox.Show(
                "The student record has been archived.",
                "Student Archived",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            panel3.Controls.Clear();
            panel3.Visible = false;
            kryptonDataGridView1.Visible = true;
            cmbFilterFacultyView.Visible = true;
            edit_btn.Visible = false;
            btnBack.Visible = false;
            btn_Archive.Visible = false;
            _activeView = ActiveView.None;
            

        }

        private void poisonComboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            FilterDataModify();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSuffix_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    
}