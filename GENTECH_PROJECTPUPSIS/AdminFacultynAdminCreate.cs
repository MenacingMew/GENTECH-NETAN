using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class AdminFacultynAdminCreate : UserControl
    {
        public AdminFacultynAdminCreate()
        {
            InitializeComponent();
        }

        string firstName, middleName, lastName, suffix, address, contactNo, email, facultyID;
        int sexIndex;
        DateTime birthday;


        int sexAdminIndex;
        DateTime birthDateAdmin;

        string firstAdminName, middleAdminName, lastAdminName, suffixAdminName, addressAdmin, contactAdmin, emailAdmin, adminID;

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;

            if (txt.Text == "Faculty ID")
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
           
        }

        private void kryptonTextBox11_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt.Text == "Admin ID")
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;

            string noSpace = txt.Text.Replace(" ", "");

            if (noSpace == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AdminFacultynAdminCreate_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "View";
            btn.Name = "btnView";
            btn.Text = "View";
            btn.Width = 90;
          
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Standard;
            DummiesBasicToKungfu("FAC-001", "Brylle", "Computer Science");
            
           
            DummiesBasicToKungfu("FAC-002", "Angela", "Information Technology");
            DummiesBasicToKungfu("FAC-003", "Michael", "Software Engineering");
            DummiesBasicToKungfu("FAC-004", "Sophia", "Computer Engineering");
            DummiesBasicToKungfu("FAC-005", "Daniel", "Cybersecurity");
            DummiesBasicToKungfu("FAC-006", "Isabella", "Data Science");
            DummiesBasicToKungfu("FAC-007", "Joshua", "Information Systems");
            DummiesBasicToKungfu("FAC-008", "Camille", "Artificial Intelligence");
            DummiesBasicToKungfu("FAC-009", "Ethan", "Game Development");
            DummiesBasicToKungfu("FAC-010", "Nicole", "Web Development");
            dvgFacultyView.Columns.Add(btn);
        }

        private void dvgFacultyView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dvgFacultyView.Columns["btnView"].Index
           && e.RowIndex >= 0)
            {
                panel2.Visible = true;
                string id = dvgFacultyView.Rows[e.RowIndex].Cells[0].Value.ToString();

                AdminFacultyView view = new AdminFacultyView(id, "View");
                view.TopLevel = false;
                view.Dock = DockStyle.Fill;
                view.FormBorderStyle = FormBorderStyle.None;

                panel2.Controls.Clear();
                panel2.Controls.Add(view);
                view.Show();
                btnClearView.Visible = true;
                cmbFilterFacultyView.Visible = false;
            }

        }


      
        private void dvgFacultyView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClearView_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            panel2.Visible = false;
            cmbFilterFacultyView.Visible = true;
            btnClearView.Visible = false;
        }

        private void txtFirstModify_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (txtAdminSearchModify.StateCommon.Content.Color1 == Color.Black)
            {
                MessageBox.Show(
                               "The admin record has been archived successfully.",
                               "Admin Archived",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information
                           );
                txtFirstAdminModify.Text = txtFirstModify.Tag.ToString();
                txtMiddleAdminModify.Text = txtMiddleModify.Tag.ToString();
                txtLastAdminModify.Text = txtLastModify.Tag.ToString();
                txtSuffixAdminModify.Text = txtSuffixModify.Tag.ToString();
                txtAddressAdminModify.Text = txtAddressModify.Tag.ToString();
                txtContactAdminModify.Text = txtContactModify.Tag.ToString();
                txtEmailAdminModify.Text = txtEmailModify.Tag.ToString();
                txtAdminIDModify.Text = txtAdminIDModify.Tag.ToString();
                txtAdminSearchModify.Text = txtAdminSearchModify.Tag.ToString();
                cmbSexAdminModify.SelectedIndex = 0;
                dtpBirthdayAdminModify.Value = DateTime.Now;

                txtFirstAdminModify.ForeColor = Color.DarkGray;
                txtMiddleAdminModify.ForeColor = Color.DarkGray;
                txtLastAdminModify.ForeColor = Color.DarkGray;
                txtSuffixAdminModify.ForeColor = Color.DarkGray;
                txtAddressAdminModify.ForeColor = Color.DarkGray;
                txtContactAdminModify.ForeColor = Color.DarkGray;
                txtEmailAdminModify.ForeColor = Color.DarkGray;
                txtAdminIDModify.ForeColor = Color.DarkGray;
                cmbSexAdminModify.ForeColor = Color.DarkGray;
                dtpBirthdayAdminModify.ForeColor = Color.DarkGray;
                txtAdminSearchModify.ForeColor = Color.DarkGray;
            }
            else
            {

            }
        
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelCSV_Click(object sender, EventArgs e)
        {
            dgvPreview.Visible = false;
            btnCreateCSV.Visible = false;
            btnCancelCSV.Visible = false;
            btnCreate.Visible = true;
        }

        private void btnCreateCSV_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show(
                 "Are you sure you want to load this CSV file?\n\nMake sure the file format is correct before proceeding.",
                 "Confirm Batch Upload",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
 );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "The CSV file has been successfully loaded and is ready for preview.",
                    "Batch Upload Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            dgvPreview.Visible = false;
            btnCreateCSV.Visible = false;
            btnCancelCSV.Visible = false;
            btnCreate.Visible = true;
        }

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Title = "Select CSV File";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnCreate.Visible = false;
                btnCreateCSV.Visible = true;
                btnCancelCSV.Visible = true;
                dgvPreview.Visible = true;
                string path = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(path);

                dgvPreview.Rows.Clear();
                dgvPreview.Columns.Clear();

                // Create columns from header
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dgvPreview.Columns.Add(header, header);
                }

                // Add rows
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dgvPreview.Rows.Add(data);
                }

                
            }
        }
        

        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            if (btnSaveAdmin.Enabled)
            {

                if (MessageBox.Show(
                  "Do you want to save the changes?",
                  "Confirm Save",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(
                    "The admin information has been saved successfully.",
                    "Saved Changes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                                    );
                    
                    firstAdminName = txtFirstAdminModify.Text;
                    middleAdminName = txtMiddleAdminModify.Text;
                    lastAdminName = txtLastAdminModify.Text;
                    suffixAdminName = txtSuffixAdminModify.Text;
                    addressAdmin = txtAddressAdminModify.Text;
                    contactAdmin = txtContactAdminModify.Text;
                    emailAdmin = txtEmailAdminModify.Text;
                    adminID = txtAdminIDModify.Text;
                    birthDateAdmin = dtpBirthdayAdminModify.Value;
                    sexAdminIndex = cmbSexAdminModify.SelectedIndex;


                    txtAdminSearchModify.Text = txtAdminSearchModify.Tag.ToString();
                    txtFirstAdminModify.Text = txtFirstModify.Tag.ToString();
                    txtMiddleAdminModify.Text = txtMiddleModify.Tag.ToString();
                    txtLastAdminModify.Text = txtLastModify.Tag.ToString();
                    txtSuffixAdminModify.Text = txtSuffixModify.Tag.ToString();
                    txtAddressAdminModify.Text = txtAddressModify.Tag.ToString();
                    txtContactAdminModify.Text = txtContactModify.Tag.ToString();
                    txtEmailAdminModify.Text = txtEmailModify.Tag.ToString();
                    txtAdminIDModify.Text = txtAdminIDModify.Tag.ToString();
                    cmbSexAdminModify.SelectedIndex = 0;
                    dtpBirthdayAdminModify.Value = DateTime.Now;



                    txtFirstAdminModify.ForeColor = Color.DarkGray;
                    txtMiddleAdminModify.ForeColor = Color.DarkGray;
                    txtLastAdminModify.ForeColor = Color.DarkGray;
                    txtSuffixAdminModify.ForeColor = Color.DarkGray;
                    txtAddressAdminModify.ForeColor = Color.DarkGray;
                    txtContactAdminModify.ForeColor = Color.DarkGray;
                    txtEmailAdminModify.ForeColor = Color.DarkGray;
                    txtAdminIDModify.ForeColor = Color.DarkGray;
                    cmbSexAdminModify.ForeColor = Color.DarkGray;
                    dtpBirthdayAdminModify.ForeColor = Color.DarkGray;
                    txtAdminSearchModify.ForeColor = Color.DarkGray;

                    btnSaveAdmin.Enabled = false;
                    btnSaveAdmin.PrimaryColor = Color.Gray;
                }
            }
        }

        private void btnAdminSearchModify_Click(object sender, EventArgs e)
        {
            if (txtAdminSearchModify.Text == adminID)
            {

                txtFirstAdminModify.Text = firstAdminName;
                txtMiddleAdminModify.Text = middleAdminName;
                txtLastAdminModify.Text = lastAdminName;
                txtSuffixAdminModify.Text = suffixAdminName;
                txtAddressAdminModify.Text = addressAdmin;
                txtContactAdminModify.Text = contactAdmin;
                txtEmailAdminModify.Text = emailAdmin;
                cmbSexAdminModify.SelectedIndex = sexAdminIndex;
                dtpBirthdayAdminModify.Value = birthDateAdmin;
                txtAdminIDModify.Text = adminID;


                txtFirstAdminModify.ForeColor = Color.Black;
                txtMiddleAdminModify.ForeColor = Color.Black;
                txtLastAdminModify.ForeColor = Color.Black;
                txtSuffixAdminModify.ForeColor = Color.Black;
                txtAddressAdminModify.ForeColor = Color.Black;
                txtContactAdminModify.ForeColor = Color.Black;
                txtEmailAdminModify.ForeColor = Color.Black;
                cmbSexAdminModify.ForeColor = Color.Black;
                txtAdminIDModify.ForeColor = Color.Black;
                dtpBirthdayAdminModify.CalendarTrailingForeColor = Color.Black;
                btnSaveAdmin.Enabled = true;
                btnSaveAdmin.PrimaryColor = Color.Maroon;
                btnArchive.PrimaryColor = Color.Maroon;
                btnArchive.Enabled = true;
            }
            else
            {
                MessageBox.Show(
                               "No admin found with the provided Admin ID.\n\nPlease check the Admin ID and try again.",
                               "Admin Not Found",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning
                           );
            }
        }
            
            
       

        


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

            string noSpace = txt.Text.Replace(" ", "");

            if (noSpace == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ReaLTaiizor.Controls.ComboBoxEdit;
            if (comboBox.SelectedIndex == 0)
                comboBox.ForeColor = Color.DarkGray;
            else
                comboBox.ForeColor = Color.Black;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" || txtSuffix.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "" ||
                txtEmail.Text == "" || txtFacultyID.Text == "" ||

                txtFirstName.ForeColor == Color.DarkGray || txtMiddleName.ForeColor == Color.DarkGray || txtLastName.ForeColor == Color.DarkGray ||
                txtSuffix.ForeColor == Color.DarkGray || txtAddress.ForeColor == Color.DarkGray || txtContactNo.ForeColor == Color.DarkGray ||
                txtEmail.ForeColor == Color.DarkGray || cmbSex.ForeColor == Color.DarkGray 
                )
            {
                MessageBox.Show(
                               "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                               "Application Incomplete",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning
                           );
            }
            else
            {
                MessageBox.Show(
                                "The student has been successfully created.",
                                "Student Created",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );

                

                firstName = txtFirstName.Text;
                middleName = txtMiddleName.Text;
                lastName = txtLastName.Text;
                suffix = txtSuffix.Text;
                address = txtAddress.Text;
                contactNo = txtContactNo.Text;
                email = txtEmail.Text;
                facultyID = txtFacultyID.Text;
                sexIndex = cmbSex.SelectedIndex;
                birthday = dtpBirthday.Value;

                txtFirstName.Text = txtFirstName.Tag.ToString();
                txtMiddleName.Text = txtMiddleName.Tag.ToString();
                txtLastName.Text = txtLastName.Tag.ToString();
                txtSuffix.Text = txtSuffix.Tag.ToString();
                txtAddress.Text = txtAddress.Tag.ToString();
                txtContactNo.Text = txtContactNo.Tag.ToString();
                txtEmail.Text = txtEmail.Tag.ToString();
                txtFacultyID.Text = txtFacultyID.Tag.ToString();


                txtFirstName.ForeColor = Color.DarkGray;
                txtMiddleName.ForeColor = Color.DarkGray;
                txtLastName.ForeColor = Color.DarkGray;
                txtSuffix.ForeColor = Color.DarkGray;
                txtAddress.ForeColor = Color.DarkGray;
                txtContactNo.ForeColor = Color.DarkGray;
                txtEmail.ForeColor = Color.DarkGray;
                txtFacultyID.ForeColor = Color.DarkGray;
                cmbSex.SelectedIndex = 0;

            }


        }

        private void btnSearchFaculty_Click(object sender, EventArgs e)
        {
            if (txtFacultySearch.Text == "FAC-550")
            {
                txtFirstModify.Text = "Karl";
                txtMiddleModify.Text = "Dela Cruz";
                txtLastModify.Text = "Angelo";
                txtSuffixModify.Text = "N/A";
                txtAddressModify.Text = "123 Main Street";
                txtContactModify.Text = "091234567890";
                txtEmailModify.Text = "karldelacruzangelo@gmail.com";
                cmbSexModify.SelectedIndex = 1;
                dtpBirthday.Value = new DateTime(2006, 11, 15);
                txtFacultyID.Text = "FAC-550";

                txtFirstModify.ForeColor = Color.Black;
                txtMiddleModify.ForeColor = Color.Black;
                txtLastModify.ForeColor = Color.Black;
                txtSuffixModify.ForeColor = Color.Black;
                txtAddressModify.ForeColor = Color.Black;
                txtContactModify.ForeColor = Color.Black;
                txtEmailModify.ForeColor = Color.Black;
                cmbSexModify.ForeColor = Color.Black;
                txtFacultyID.ForeColor = Color.Black;
                btnSaveFaculty.Enabled = true;
                btnSaveFaculty.PrimaryColor = Color.Maroon;
                btnDeleteFaculty.PrimaryColor = Color.Maroon;
                btnDeleteFaculty.Enabled = true;
                

            }
        }

        private void btnSaveFaculty_Click(object sender, EventArgs e)
        {
            if (btnSaveFaculty.Enabled)
            {

                if (MessageBox.Show(
                  "Do you want to save the changes?",
                  "Confirm Save",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(
                    "The faculty record has been saved successfully.",
                    "Faculty Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                                    );

                    firstName = txtFirstModify.Text;
                    middleName = txtMiddleModify.Text;
                    lastName = txtLastModify.Text;
                    suffix = txtSuffixModify.Text;
                    address = txtAddressModify.Text;
                    contactNo = txtContactModify.Text;
                    email = txtEmailModify.Text;
                    sexIndex = cmbSexModify.SelectedIndex;
                    birthday = dtpBirthday.Value;


                    txtFirstModify.Text = txtFirstModify.Tag.ToString();
                    txtMiddleModify.Text = txtMiddleModify.Tag.ToString();
                    txtLastModify.Text = txtLastModify.Tag.ToString();
                    txtSuffixModify.Text = txtSuffixModify.Tag.ToString();
                    txtAddressModify.Text = txtAddressModify.Tag.ToString();
                    txtContactModify.Text = txtContactModify.Tag.ToString();
                    txtEmailModify.Text = txtEmailModify.Tag.ToString();
                    cmbSexModify.SelectedIndex = 0;
                    dtpBirthday.Value = DateTime.Now;
                    txtFirstModify.ForeColor = Color.DarkGray;
                    txtMiddleModify.ForeColor = Color.DarkGray;
                    txtLastModify.ForeColor = Color.DarkGray;
                    txtSuffixModify.ForeColor = Color.DarkGray;
                    txtAddressModify.ForeColor = Color.DarkGray;
                    txtContactModify.ForeColor = Color.DarkGray;
                    txtEmailModify.ForeColor = Color.DarkGray;
                    cmbSexModify.ForeColor = Color.DarkGray;
                    btnSaveFaculty.Enabled = false;
                    btnSaveFaculty.PrimaryColor = Color.Gray;
                }
            }
        }

        private void btnDeleteFaculty_Click(object sender, EventArgs e)
        {
            if (txtFacultySearch.StateCommon.Content.Color1 == Color.Black)
            {
                MessageBox.Show(
                               "The faculty record has been archived successfully.",
                               "Faculty Archived",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information
                           );
                txtFirstModify.Text = txtFirstModify.Tag.ToString();
                txtMiddleModify.Text = txtMiddleModify.Tag.ToString();
                txtLastModify.Text = txtLastModify.Tag.ToString();
                txtSuffixModify.Text = txtSuffixModify.Tag.ToString();
                txtAddressModify.Text = txtAddressModify.Tag.ToString();
                txtContactModify.Text = txtContactModify.Tag.ToString();
                txtEmailModify.Text = txtEmailModify.Tag.ToString();
                cmbSexModify.SelectedIndex = 0;
                dtpBirthday.Value = DateTime.Now;
                txtFirstModify.ForeColor = Color.DarkGray;
                txtMiddleModify.ForeColor = Color.DarkGray;
                txtLastModify.ForeColor = Color.DarkGray;
                txtSuffixModify.ForeColor = Color.DarkGray;
                txtAddressModify.ForeColor = Color.DarkGray;
                txtContactModify.ForeColor = Color.DarkGray;
                txtEmailModify.ForeColor = Color.DarkGray;
                cmbSexModify.ForeColor = Color.DarkGray;
                btnSaveFaculty.Enabled = false;
                btnSaveFaculty.PrimaryColor = Color.Gray;

            }
        }
        private void DummiesBasicToKungfu(string FacultyID, string Name, string Department)
        {
            int index = dvgFacultyView.Rows.Add();
            DataGridViewRow row = dvgFacultyView.Rows[index];
           
            row.Cells[0].Value = FacultyID;
            row.Cells[1].Value = Name;
            row.Cells[2].Value = Department;


            
        }
        private void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            if (txtFirstAdminCreate.Text == "" || txtMiddleAdminCreate.Text == "" || txtLastAdminCreate.Text == "" || txtSuffixAdminCreate.Text == "" ||
                txtAddressAdminCreate.Text == "" || txtContactAdminCreate.Text == "" ||
                txtEmailAdminCreate.Text == "" || txtAddressAdminCreate.Text == "" ||

                txtFirstAdminCreate.ForeColor == Color.DarkGray || txtMiddleAdminCreate.ForeColor == Color.DarkGray || txtLastAdminCreate.ForeColor == Color.DarkGray ||
                txtSuffixAdminCreate.ForeColor == Color.DarkGray || txtAddressAdminCreate.ForeColor == Color.DarkGray || txtContactAdminCreate.ForeColor == Color.DarkGray ||
                txtEmailAdminCreate.ForeColor == Color.DarkGray || txtAddressAdminCreate.ForeColor == Color.DarkGray
                )
            {
                MessageBox.Show(
                               "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                               "Application Incomplete",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning
                           );
            }
            else
            {
                MessageBox.Show(
                                "The admin has been successfully created.",
                                "Admin Created",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );




                firstAdminName = txtFirstAdminCreate.Text;
                middleAdminName = txtMiddleAdminCreate.Text;
                lastAdminName = txtLastAdminCreate.Text;
                suffixAdminName = txtSuffixAdminCreate.Text;
                addressAdmin = txtAddressAdminCreate.Text;
                contactAdmin = txtContactAdminCreate.Text;
                emailAdmin = txtEmailAdminCreate.Text;
                adminID = txtAdminIDCreate.Text;
                birthDateAdmin = dtpBirthdayAdminCreate.Value;
                sexAdminIndex = cmbSexAdminCreate.SelectedIndex;



                txtFirstAdminCreate.Text = txtFirstAdminCreate.Tag.ToString();
                txtMiddleAdminCreate.Text = txtMiddleAdminCreate.Tag.ToString();
                txtLastAdminCreate.Text = txtLastAdminCreate.Tag.ToString();
                txtSuffixAdminCreate.Text = txtSuffixAdminCreate.Tag.ToString();
                txtAddressAdminCreate.Text = txtAddressAdminCreate.Tag.ToString();
                txtContactAdminCreate.Text = txtContactAdminCreate.Tag.ToString();
                txtEmailAdminCreate.Text = txtEmailAdminCreate.Tag.ToString();
                txtAdminIDCreate.Text = txtAdminIDCreate.Tag.ToString();
                dtpBirthdayAdminCreate.Value = DateTime.Now;


                txtFirstAdminCreate.ForeColor = Color.DarkGray;
                txtMiddleAdminCreate.ForeColor = Color.DarkGray;
                txtLastAdminCreate.ForeColor = Color.DarkGray;
                txtSuffixAdminCreate.ForeColor = Color.DarkGray;
                txtAddressAdminCreate.ForeColor = Color.DarkGray;
                txtContactAdminCreate.ForeColor = Color.DarkGray;
                txtEmailAdminCreate.ForeColor = Color.DarkGray;
                txtAdminIDCreate.ForeColor = Color.DarkGray;
                cmbSexAdminCreate.SelectedIndex = 0;

            }
        }
    }
}


