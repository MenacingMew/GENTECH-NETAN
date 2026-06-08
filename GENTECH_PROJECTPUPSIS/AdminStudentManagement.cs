using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class SRM : Form
    {
        public SRM()
        {
            InitializeComponent();
        }

        string firstName = "Antonio Jamir";
        string middleName = "Regala";
        string lastName = "Tadaya";
        string suffix = "N/A";
        string address = "67 Kalabasa St., Brgy. Tumana, Sta. Maria, Bulacan";
        string contactNo = "0965-123-4567";
        string email = "antoniojamirtadaya@gmail.com";
        string studentID = "2024-00136-SM-0";
        DateTime birthDay = new DateTime(2006, 11, 16);
        int sexIndex = 1;
        int programIndex = 1;
        int sectionIndex = 1;

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

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" || txtSuffix.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "" ||
                txtEmail.Text == "" || txtStudentID.Text == "" ||

                txtFirstName.ForeColor == Color.DarkGray || txtMiddleName.ForeColor == Color.DarkGray || txtLastName.ForeColor == Color.DarkGray ||
                txtSuffix.ForeColor == Color.DarkGray || txtAddress.ForeColor == Color.DarkGray || txtContactNo.ForeColor == Color.DarkGray ||
                txtEmail.ForeColor == Color.DarkGray || txtStudentID.ForeColor == Color.DarkGray || cmbProgram.SelectedIndex == 0 || cmbSex.SelectedIndex == 0 ||
                cmbSection.SelectedIndex == 0
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

                txtFirstName.Text = txtFirstName.Tag.ToString();
                txtMiddleName.Text = txtMiddleName.Tag.ToString();
                txtLastName.Text = txtLastName.Tag.ToString();
                txtSuffix.Text = txtSuffix.Tag.ToString();
                txtAddress.Text = txtAddress.Tag.ToString();
                txtContactNo.Text = txtContactNo.Tag.ToString();
                txtEmail.Text = txtEmail.Tag.ToString();
                txtStudentID.Text = txtStudentID.Tag.ToString();
                txtFirstName.ForeColor = Color.DarkGray;
                txtMiddleName.ForeColor = Color.DarkGray;
                txtLastName.ForeColor = Color.DarkGray;
                txtSuffix.ForeColor = Color.DarkGray;
                txtAddress.ForeColor = Color.DarkGray;
                txtContactNo.ForeColor = Color.DarkGray;
                txtEmail.ForeColor = Color.DarkGray;
                txtStudentID.ForeColor = Color.DarkGray;
                dtpBirthDay.Value = DateTime.Now;
                cmbProgram.SelectedIndex = 0;
                cmbSection.SelectedIndex = 0;
                cmbSex.SelectedIndex = 0;

            }


        }

        private void txtStudentIDSearch_Enter(object sender, EventArgs e)
        {
            if (txtStudentIDSearch.ForeColor == Color.DarkGray)
            {
                txtStudentIDSearch.Text = "";
                txtStudentIDSearch.ForeColor = Color.Black;
            }
        }

        private void txtStudentIDSearch_Leave(object sender, EventArgs e)
        {
            string noSpace = txtStudentIDSearch.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtStudentIDSearch.Text = txtStudentIDSearch.Tag.ToString();
                txtStudentIDSearch.ForeColor = Color.DarkGray;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStudentIDSearch.Text == studentID)
            {
                txtName.Text = $"{firstName} {middleName[0]}. {lastName}";
                txtStudentIDRead.Text = "2024-00136-SM-0";
                txtProgram.Text = cmbProgramModify.Items[programIndex].ToString();
                txtSection.Text = cmbSectionModify.Items[sectionIndex].ToString();
                txtEmailRead.Text = email;
                txtBirthDay.Text = birthDay.ToString("MMMM dd, yyyy");
                txtContact.Text = contactNo;
                txtAddressRead.Text = address;
                txtSexRead.Text = cmbSexModify.Items[sexIndex].ToString();


                txtName.ForeColor = Color.Black;
                txtStudentIDRead.ForeColor = Color.Black;
                txtProgram.ForeColor = Color.Black;
                txtSection.ForeColor = Color.Black;
                txtEmailRead.ForeColor = Color.Black;
                txtBirthDay.ForeColor = Color.Black;
                txtContact.ForeColor = Color.Black;
                txtAddressRead.ForeColor = Color.Black;
                txtSexRead.ForeColor = Color.Black;
                txtSection.ForeColor = Color.Black;
                txtProgram.ForeColor = Color.Black;


            }
            else
            {
                MessageBox.Show(
                               "No student found with the provided Student ID.\n\nPlease check the Student ID and try again.",
                               "Student Not Found",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning
                           );
            }
        }

        private void txtStudentIDModifySearch_Enter(object sender, EventArgs e)
        {
            if (txtStudentIDModifySearch.ForeColor == Color.DarkGray)
            {
                txtStudentIDModifySearch.Text = "";
                txtStudentIDModifySearch.ForeColor = Color.Black;
            }
        }

        private void txtStudentIDModifySearch_Leave(object sender, EventArgs e)
        {
            string noSpace = txtStudentIDModifySearch.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtStudentIDModifySearch.Text = txtStudentIDModifySearch.Tag.ToString();
                txtStudentIDModifySearch.ForeColor = Color.DarkGray;
            }
        }

        private void btnSeachModify_Click(object sender, EventArgs e)
        {
            if (txtStudentIDModifySearch.Text == studentID)
            {

                txtNameModify.Text = firstName;
                txtMiddleModify.Text = middleName;
                txtLastModify.Text = lastName;
                txtModifySuffix.Text = "N/A";
                txtAddressModify.Text = address;
                txtContactModify.Text = contactNo;
                txtEmailModify.Text = email;
                dtpBirthdayModify.Value = new DateTime(2006, 11, 16);
                cmbSexModify.SelectedIndex = sexIndex;
                cmbProgramModify.SelectedIndex = programIndex;
                cmbSectionModify.SelectedIndex = sectionIndex;

                txtNameModify.ForeColor = Color.Black;
                txtMiddleModify.ForeColor = Color.Black;
                txtLastModify.ForeColor = Color.Black;
                txtModifySuffix.ForeColor = Color.Black;
                txtAddressModify.ForeColor = Color.Black;
                txtContactModify.ForeColor = Color.Black;
                txtEmailModify.ForeColor = Color.Black;
                cmbSexModify.ForeColor = Color.Black;
                cmbProgramModify.ForeColor = Color.Black;
                cmbSectionModify.ForeColor = Color.Black;

                btnSaveChanges.Enabled = true;
                btnSaveChanges.PrimaryColor = Color.Maroon;
            }
            else
            {
                MessageBox.Show(
                               "No student found with the provided Student ID.\n\nPlease check the Student ID and try again.",
                               "Student Not Found",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning
                           );
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (btnSaveChanges.PrimaryColor == Color.Maroon)
            {
                firstName = txtNameModify.Text;
                middleName = txtMiddleModify.Text;
                lastName = txtLastModify.Text;
                suffix = txtModifySuffix.Text;
                address = txtAddressModify.Text;
                contactNo = txtContactModify.Text;
                email = txtEmailModify.Text;
                sexIndex = cmbSexModify.SelectedIndex;
                programIndex = cmbProgramModify.SelectedIndex;
                sectionIndex = cmbSectionModify.SelectedIndex;
                birthDay = dtpBirthdayModify.Value;

                MessageBox.Show(
                "Your changes have been saved successfully.",
                "Changes Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                                );

                txtNameModify.Text = txtNameModify.Tag.ToString();
                txtMiddleModify.Text = txtMiddleModify.Tag.ToString();
                txtLastModify.Text = txtLastModify.Tag.ToString();
                txtModifySuffix.Text = txtModifySuffix.Tag.ToString();
                txtAddressModify.Text = txtAddressModify.Tag.ToString();
                txtContactModify.Text = txtContactModify.Tag.ToString();
                txtEmailModify.Text = txtEmailModify.Tag.ToString();
                dtpBirthdayModify.Value = DateTime.Now;
                cmbSexModify.SelectedIndex = 0;
                cmbProgramModify.SelectedIndex = 0;
                cmbSectionModify.SelectedIndex = 0;

                txtNameModify.ForeColor = Color.DarkGray;
                txtMiddleModify.ForeColor = Color.DarkGray;
                txtLastModify.ForeColor = Color.DarkGray;
                txtModifySuffix.ForeColor = Color.DarkGray;
                txtAddressModify.ForeColor = Color.DarkGray;
                txtContactModify.ForeColor = Color.DarkGray;
                txtEmailModify.ForeColor = Color.DarkGray;
                cmbSexModify.ForeColor = Color.DarkGray;
                cmbProgramModify.ForeColor = Color.DarkGray;
                cmbSectionModify.ForeColor = Color.DarkGray;

                btnSaveChanges.Enabled = false;
                btnSaveChanges.PrimaryColor = Color.Gray;
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnSaveChanges.PrimaryColor == Color.Maroon)
            {

                if (MessageBox.Show(
                    "Do you want to save the changes?",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(
                    "The student record has been deleted successfully.",
                    "Student Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                                    );

                    studentID = "";
                    txtNameModify.Text = txtNameModify.Tag.ToString();
                    txtMiddleModify.Text = txtMiddleModify.Tag.ToString();
                    txtLastModify.Text = txtLastModify.Tag.ToString();
                    txtModifySuffix.Text = txtModifySuffix.Tag.ToString();
                    txtAddressModify.Text = txtAddressModify.Tag.ToString();
                    txtContactModify.Text = txtContactModify.Tag.ToString();
                    txtEmailModify.Text = txtEmailModify.Tag.ToString();
                    dtpBirthdayModify.Value = DateTime.Now;
                    cmbSexModify.SelectedIndex = 0;
                    cmbProgramModify.SelectedIndex = 0;
                    cmbSectionModify.SelectedIndex = 0;
                    txtNameModify.ForeColor = Color.DarkGray;
                    txtMiddleModify.ForeColor = Color.DarkGray;
                    txtLastModify.ForeColor = Color.DarkGray;
                    txtModifySuffix.ForeColor = Color.DarkGray;
                    txtAddressModify.ForeColor = Color.DarkGray;
                    txtContactModify.ForeColor = Color.DarkGray;
                    txtEmailModify.ForeColor = Color.DarkGray;
                    cmbSexModify.ForeColor = Color.DarkGray;
                    cmbProgramModify.ForeColor = Color.DarkGray;
                    cmbSectionModify.ForeColor = Color.DarkGray;
                    btnSaveChanges.Enabled = false;
                    btnSaveChanges.PrimaryColor = Color.Gray;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "Name";
            txtStudentIDRead.Text = "Student ID";
            txtProgram.Text = "Program";
            txtSection.Text = "Section";
            txtEmailRead.Text = "Email";
            txtBirthDay.Text = "Birthday";
            txtContact.Text = "Contact No.";
            txtAddressRead.Text = "Address";
            txtSexRead.Text = "Sex";


            txtName.ForeColor = Color.DarkGray;
            txtStudentIDRead.ForeColor = Color.DarkGray;
            txtProgram.ForeColor = Color.DarkGray;
            txtSection.ForeColor = Color.DarkGray;
            txtEmailRead.ForeColor = Color.DarkGray;
            txtBirthDay.ForeColor = Color.DarkGray;
            txtContact.ForeColor = Color.DarkGray;
            txtAddressRead.ForeColor = Color.DarkGray;
            txtSexRead.ForeColor = Color.DarkGray;
            txtSection.ForeColor = Color.DarkGray;
            txtProgram.ForeColor = Color.DarkGray;

        }

        private void btnUploadCSV_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Title = "Select CSV File";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnConfirm.Visible = true;
                btnCancel.Visible = true;
                btnRandomized.Visible = false;
                btnCreateStudent.Visible = false;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvPreview.Visible = false;
            btnRandomized.Visible = true;
            btnCreateStudent.Visible = true;
            btnCancel.Visible = false;
            btnConfirm.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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
            btnConfirm.Visible = false;
            btnCancel.Visible = false;
            btnCreateStudent.Visible = true;
            btnRandomized.Visible = true;
        }

        private void btnRandomized_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            string randomizedID = $"2024-00{rnd.Next(100, 999)}-SM-{rnd.Next(0, 9)}";
            txtStudentID.Text = randomizedID;
            txtStudentID.ForeColor = Color.Black;
        }
    }
}

