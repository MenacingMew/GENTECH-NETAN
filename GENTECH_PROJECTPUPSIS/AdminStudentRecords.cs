using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void AdminStudentRecords_Load(object sender, EventArgs e)
        {
            InitStudentViewGrid();
            InitModifyGrid();
            btnBack.Visible = false;


        }

        // ─────────────────────────────────────────────
        // INIT HELPERS
        // ─────────────────────────────────────────────
        private void InitStudentViewGrid()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnView";
            btn.Text = "View";
            btn.Width = 90;
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Standard;
            dvgStudentView.Columns.Add(btn);

            AddStudentViewRow("2024-00138-SM-0", "Juan Miguel Dela Cruz", "BSIT");
            AddStudentViewRow("2024-00139-SM-0", "Andrea Louise Ramirez", "BSCS");
            AddStudentViewRow("2024-00140-SM-0", "Christian Paul Navarro", "BSIT");
            AddStudentViewRow("2024-00141-SM-0", "Nicole Anne Garcia", "BSIT");
            AddStudentViewRow("2024-00142-SM-0", "Mark Anthony Reyes", "BSCS");
            AddStudentViewRow("2024-00143-SM-0", "Paula Sofia Lim", "BSIT");
            AddStudentViewRow("2024-00144-SM-0", "Joshua Daniel Mendoza", "BSCS");
            AddStudentViewRow("2024-00145-SM-0", "Kimberly Rose Santos", "BSIT");
            AddStudentViewRow("2024-00146-SM-0", "Gabriel Enrique Bautista", "BSCS");
            AddStudentViewRow("2024-00147-SM-0", "Angelica Mae Villanueva", "BSIT");
        }

        private void AddStudentViewRow(string studentID, string name, string program)
        {
            int index = dvgStudentView.Rows.Add();
            DataGridViewRow row = dvgStudentView.Rows[index];
            row.Cells[0].Value = studentID;
            row.Cells[1].Value = name;
            row.Cells[2].Value = program;
        }

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
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnEdit";
            btn.Text = "Edit";
            btn.Width = 90;
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Standard;
            kryptonDataGridView1.Columns.Add(btn);

            AddStudentRow("2024-00138-SM-0", "Juan Miguel Dela Cruz", "BSIT");
            AddStudentRow("2024-00139-SM-0", "Andrea Louise Ramirez", "BSCS");
            AddStudentRow("2024-00140-SM-0", "Christian Paul Navarro", "BSIT");
            AddStudentRow("2024-00141-SM-0", "Nicole Anne Garcia", "BSIT");
            AddStudentRow("2024-00142-SM-0", "Mark Anthony Reyes", "BSCS");
            AddStudentRow("2024-00143-SM-0", "Paula Sofia Lim", "BSIT");
            AddStudentRow("2024-00144-SM-0", "Joshua Daniel Mendoza", "BSCS");
            AddStudentRow("2024-00145-SM-0", "Kimberly Rose Santos", "BSIT");
            AddStudentRow("2024-00146-SM-0", "Gabriel Enrique Bautista", "BSCS");
            AddStudentRow("2024-00147-SM-0", "Angelica Mae Villanueva", "BSIT");

            ShowAllColumnsInModifyView();
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

            dgvPreview.Rows.Clear();
            dgvPreview.Columns.Clear();

            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
                dgvPreview.Columns.Add(header, header);

            for (int i = 1; i < lines.Length; i++)
                dgvPreview.Rows.Add(lines[i].Split(','));

            dgvPreview.Visible = true;
            btnConfirm.Visible = true;
            btnCancel.Visible = true;
            btnRandomized.Visible = false;
            btnCreateStudent.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to load this CSV file?\n\nMake sure the file format is correct before proceeding.",
                "Confirm Batch Upload",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "The CSV file has been successfully loaded.",
                    "Batch Upload Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ResetCSVPreview();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetCSVPreview();
        }

        private void ResetCSVPreview()
        {
            dgvPreview.Visible = false;
            btnConfirm.Visible = false;
            btnCancel.Visible = false;
            btnCreateStudent.Visible = true;
            btnRandomized.Visible = true;
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

            string selectedProgram = cmbFilterFacultyView.Text;

            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string program = row.Cells[2].Value?.ToString() ?? "";

                bool programMatch =
                    selectedProgram == "All" || program == selectedProgram;

                row.Visible = programMatch;
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
            if (e.RowIndex < 0 || e.ColumnIndex != dvgStudentView.Columns["btnView"].Index)
                return;

            string id = dvgStudentView.Rows[e.RowIndex].Cells[0].Value.ToString();
            OpenStudentView(id, panel2);

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

            id = kryptonDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
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
            else if (id == "2024 - 00138 - SM - 0")
            {

            }
                //Save Changes logic here (same as btnSaveChanges_Click)
                MessageBox.Show(
                        "The student record has been successfully updated.",
                        "Changes Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

            // After saving, return to the modify grid view
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
    }
    
}