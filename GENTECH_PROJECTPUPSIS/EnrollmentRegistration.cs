using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using MySqlConnector;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1
{
    public partial class EnrollmentRegistration : Form
    {
        private string connString = "server=127.0.0.1;uid=root;pwd=;database=wawa;";
        public EnrollmentRegistration()
        {
            InitializeComponent();
            SetupBirthdatePicker(poisonDateTime1);
            SetupBirthdatePicker(poisonDateTime2);
        }
        public long GenerateNextStudentID(string connectionString)
        {
            long defaultStartingID = 2024000010;

            string query = "SELECT MAX(Student_ID) FROM student WHERE Student_ID >= 2024000000 AND Student_ID <= 2024999999;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        long currentMaxID = Convert.ToInt64(result);

                        long sequence = currentMaxID / 10; 
                        sequence++;                        
                        long nextID = sequence * 10;       

                        return nextID;
                    }
                }
            }

            return defaultStartingID;
        }


        private void SetupBirthdatePicker(DateTimePicker dtp)
        {
            // Set date range
            dtp.MinDate = new DateTime(1950, 1, 1);
            dtp.MaxDate = DateTime.Today;

            // Start with a blank look using a label overlay (clean method)
            dtp.Value = dtp.MinDate;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";  // Single space - this won't show garbled text

            // Add a label overlay for "Birthdate" text
            Label lblPlaceholder = new Label();
            lblPlaceholder.Text = "Birthdate";
            lblPlaceholder.ForeColor = Color.Gray;
            lblPlaceholder.BackColor = dtp.BackColor;
            lblPlaceholder.Location = new Point(3, 4);
            lblPlaceholder.AutoSize = true;

            // Make label click through to the date picker
            lblPlaceholder.Click += (s, e) =>
            {
                dtp.Focus();
                dtp.Format = DateTimePickerFormat.Short;
                dtp.Value = new DateTime(2000, 1, 1);
                dtp.CustomFormat = null;
                lblPlaceholder.Visible = false;
            };

            dtp.Controls.Add(lblPlaceholder);

            // When date is selected, hide placeholder
            dtp.ValueChanged += (s, e) =>
            {
                if (dtp.Value.Year > 1950)
                {
                    lblPlaceholder.Visible = false;
                    dtp.Format = DateTimePickerFormat.Short;
                    dtp.CustomFormat = null;
                }
            };
        }

        bool allowChange = false;

        private void txtConfirm_Click(object sender, EventArgs e)
        {
            if (!cbxConfirm.Checked) 
            {
                MessageBox.Show("You must read and agree to the Terms and Conditions before submitting your application.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long newStudentID = GenerateNextStudentID(connString);

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string studentQuery = @"INSERT INTO student
                    (Student_ID, First_Name, Last_Name, Email, Birth_Date)
                                     VALUES
                    (@StudentID, @FirstName, @LastName, @Email, @BirthDate);";

                    using (MySqlCommand cmdStudent = new MySqlCommand(studentQuery, conn))
                    {
                        cmdStudent.Parameters.AddWithValue("@StudentID", newStudentID);
                        cmdStudent.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmdStudent.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmdStudent.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmdStudent.Parameters.AddWithValue("@BirthDate", poisonDateTime1.Value);

                        cmdStudent.ExecuteNonQuery();
                    }

                  

                }

                MessageBox.Show($"Application Submitted Successfully!\n\n" +
                                $"Your assigned Student ID is: {newStudentID}\n" +
                                $"Status: Pending Verification",
                                "Submission Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit student application: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!cbxConfirm.Checked || txtNameSchool.ForeColor == Color.DarkGray || txtAddressSchool.ForeColor == Color.DarkGray ||
                numGWA12.Value == 0 || numGWA11.Value == 0 || cmbTypeSchool.ForeColor == Color.DarkGray || pictureBox1.Image == null ||
                txtNameSchool.Text == "" || txtAddressSchool.Text == ""
                )
            {

                if (!cbxConfirm.Checked)
                    lblConfirmWarning.Visible = true;
                if (txtNameSchool.ForeColor == Color.DarkGray || txtNameSchool.Text == "")
                    lblNameSchoolWarning.Visible = true;
                if (txtAddressSchool.ForeColor == Color.DarkGray || txtAddressSchool.Text == "")
                    lblAddressSchoolWarning.Visible = true;
                if (numGWA11.Value == 0)
                    lblGWA11Warning.Visible = true;
                if (numGWA12.Value == 0)
                    lblGWA11Warning.Visible = true;
                if (cmbTypeSchool.ForeColor == Color.DarkGray || cmbTypeSchool.SelectedIndex == 0)
                    lblTypeSchoolWarning.Visible = true;
                if (pictureBox1.Image == null)
                    lblGradeCardWarning.Visible = true;

            }
            else
            {
                LoginFormPUPSIS loginForm = new LoginFormPUPSIS();
                loginForm.Show();
                this.Close();
            }

        }

        private void foreverTabPage1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowChange)
            {
                e.Cancel = true;
            }
        }

        
        private void btmNext2_Click(object sender, EventArgs e)
        {
          
            // 1. Hide all warnings first to "reset" the view
            lblFirstWarning.Visible = false;
            lblMiddleWarning.Visible = false;
            lblLastWarning.Visible = false;
            lblEmailWarning.Visible = false;
            lblCivilWarning.Visible = false;
            lblPictureWarning.Visible = false;
            lblCityWarning.Visible = false;
            lblRegionWarning.Visible = false;
            lblCountryWarning.Visible = false;
            lblSexWarning.Visible = false;

            bool isValid = true;

            // 2. Validate each field individually
            if (txtFirstName.Text == "" || txtFirstName.ForeColor == Color.DarkGray) { lblFirstWarning.Visible = true; isValid = false; }
            if (txtMiddleName.Text == "" || txtMiddleName.ForeColor == Color.DarkGray) { lblMiddleWarning.Visible = true; isValid = false; }
            if (txtLastName.Text == "" || txtLastName.ForeColor == Color.DarkGray) { lblLastWarning.Visible = true; isValid = false; }
            if (txtEmail.Text == "" || txtEmail.ForeColor == Color.DarkGray) { lblEmailWarning.Visible = true; isValid = false; }

            if (cmbCivil.SelectedIndex <= 0) { lblCivilWarning.Visible = true; isValid = false; }
            if (cmbSex.SelectedIndex <= 0) { lblSexWarning.Visible = true; isValid = false; }
            if (cmbCountry.SelectedIndex <= 0) { lblCountryWarning.Visible = true; isValid = false; }
            if (cmbRegion.SelectedIndex <= 0) { lblRegionWarning.Visible = true; isValid = false; }
            if (cmbCity.SelectedIndex <= 0) { lblCityWarning.Visible = true; isValid = false; }

            if (pictureBox2.Image == null) { lblPictureWarning.Visible = true; isValid = false; }

            // 3. The Decision
            if (!isValid)
            {
                MessageBox.Show(
                    "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                    "Application Incomplete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                // Success! Move to the next tab
                allowChange = true;
                tabAll.SelectedIndex = 1;
                allowChange = false;
            }

        }


        private void btnNext4_Click(object sender, EventArgs e)
        {
            if (
                txtNumber.ForeColor == Color.DarkGray || cmbRegion3.ForeColor == Color.DarkGray ||
                cmbCity3.ForeColor == Color.DarkGray || txtBarangay.ForeColor == Color.DarkGray ||
                txtStreet.ForeColor == Color.DarkGray || txtContactPerson.ForeColor == Color.DarkGray ||
                cmbRegion31.ForeColor == Color.DarkGray || cmbCity31.ForeColor == Color.DarkGray ||
                txtEmailPerson.ForeColor == Color.DarkGray || txtContactNumber.ForeColor == Color.DarkGray ||
                txtStreetPerson.ForeColor == Color.DarkGray ||
                txtNumber.Text == "" || cmbRegion3.SelectedIndex == 0 || cmbCity3.SelectedIndex == 0 || txtBarangay.Text == "" ||
                txtStreet.Text == "" || txtContactPerson.Text == "" ||
                txtEmailPerson.Text == ""
                )
            {
                if (txtNumber.ForeColor == Color.DarkGray || txtNumber.Text == "")
                    lblContactNumberWarning.Visible = true;
                if (cmbRegion3.ForeColor == Color.DarkGray || cmbRegion3.SelectedIndex == 0)
                    lblRegion3Warning.Visible = true;
                if (cmbCity3.ForeColor == Color.DarkGray || cmbCity3.SelectedIndex == 0)
                    lblCity3Warning.Visible = true;
                if (txtBarangay.ForeColor == Color.DarkGray || txtBarangay.Text == "")
                    lblBarangayWarning.Visible = true;
                if (txtStreet.ForeColor == Color.DarkGray || txtStreet.Text == "")
                    lblStreetWarning.Visible = true;
                if (txtContactPerson.ForeColor == Color.DarkGray || txtContactPerson.Text == "")
                    lblContactPersonWarning.Visible = true;
                if (cmbCity31.ForeColor == Color.DarkGray || cmbCity31.SelectedIndex == 0)
                    lblCity31Warning.Visible = true;
                if (cmbRegion31.ForeColor == Color.DarkGray || cmbRegion31.SelectedIndex == 0)
                    lblRegion31Warning.Visible = true;
                if (txtEmailPerson.ForeColor == Color.DarkGray || txtEmailPerson.Text == "")
                    lblEmailPersonWarning.Visible = true;
                if (txtContactNumber.ForeColor == Color.DarkGray || txtContactNumber.Text == "")
                    lblContactWarning2.Visible = true;
                if (txtStreetPerson.ForeColor == Color.DarkGray || txtStreetPerson.Text == "")
                    lblStreetPersonWarning.Visible = true;




                MessageBox.Show(
                                "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                                "Application Incomplete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
            }
            else
            {
                allowChange = true;
                tabAll.SelectedIndex = 2;
                allowChange = false;
            }

        }

        private void btnNext5_Click(object sender, EventArgs e)
        {
            if (cmbTypeEmployment.ForeColor == Color.DarkGray || txtNameCompany.ForeColor == Color.DarkGray ||
                txtCompanyAddress.ForeColor == Color.DarkGray || txtCompanyContact.ForeColor == Color.DarkGray ||
                txtNameCompany.Text == "" || txtCompanyAddress.Text == "" || txtCompanyContact.Text == ""
                )
            {

                if (cmbTypeEmployment.ForeColor == Color.DarkGray || cmbTypeEmployment.SelectedIndex == 0)
                    lblTypeEmploymentWarning.Visible = true;
                if (txtNameCompany.ForeColor == Color.DarkGray || txtNameCompany.Text == "")
                    lblNameCompanyWarning.Visible = true;
                if (txtCompanyAddress.ForeColor == Color.DarkGray || txtCompanyAddress.Text == "")
                    lblCompanyAddressWarning.Visible = true;
                if (txtCompanyContact.ForeColor == Color.DarkGray || txtCompanyContact.Text == "")
                    lblCompanyContactWarning.Visible = true;



                MessageBox.Show(
                                "Your application cannot proceed because some required information is missing.\n\nPlease complete all fields and review your details before continuing.",
                                "Application Incomplete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
            }
            else
            {
                allowChange = true;
                tabAll.SelectedIndex = 3;
                allowChange = false;
            }

        }

        private void btnExit5_Click(object sender, EventArgs e)
        {
            allowChange = true;
            tabAll.SelectedIndex = 2;
            allowChange = false;
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            allowChange = true;
            tabAll.SelectedIndex = 1;
            allowChange = false;
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            allowChange = true;
            tabAll.SelectedIndex = 0;
            allowChange = false;
        }

        private void btn2x2_Click(object sender, EventArgs e)
        {
            lblPictureWarning.Visible = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Image|*.jpg;*.jpeg";
            openFileDialog1.Title = "Select a 2x2 Picture (JPEG)";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnGradeCard_Click(object sender, EventArgs e)
        {
            lblGradeCardWarning.Visible = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Image|*.jpg;*.jpeg";
            openFileDialog1.Title = "Select your Grade 11 and Grade 12 Image (JPEG)";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            allowChange = true;
            tabAll.SelectedIndex = 0;
            allowChange = false;
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            lblFirstWarning.Visible = false;
            if (txtFirstName.ForeColor != System.Drawing.Color.Black)
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtMiddleName_Enter(object sender, EventArgs e)
        {
            lblMiddleWarning.Visible = false;
            if (txtMiddleName.ForeColor != System.Drawing.Color.Black)
            {
                txtMiddleName.Text = "";
                txtMiddleName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            lblLastWarning.Visible = false;
            if (txtLastName.ForeColor != System.Drawing.Color.Black)
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            lblEmailWarning.Visible = false;
            if (txtEmail.ForeColor != System.Drawing.Color.Black)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
            }
        }



        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCountryWarning.Visible = false;
            if (cmbCountry.SelectedIndex == 0)
            {
                cmbCountry.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCountry.ForeColor = Color.Black;
            }

        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRegionWarning.Visible = false;
            if (cmbRegion.SelectedIndex == 0)
            {
                cmbRegion.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbRegion.ForeColor = Color.Black;
            }

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCityWarning.Visible = false;
            if (cmbCity.SelectedIndex == 0)
            {
                cmbCity.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCity.ForeColor = Color.Black;
            }

        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSexWarning.Visible = false;
            if (cmbSex.SelectedIndex == 0)
            {
                cmbSex.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbSex.ForeColor = Color.Black;
            }

        }

        private void txtNumber_Enter(object sender, EventArgs e)
        {
            lblContactNumberWarning.Visible = false;
            if (txtNumber.ForeColor == Color.DarkGray)
            {
                txtNumber.Text = "";
                txtNumber.ForeColor = Color.Black;
            }
        }

        private void txtBarangay_Enter(object sender, EventArgs e)
        {
            lblBarangayWarning.Visible = false;
            if (txtBarangay.ForeColor == Color.DarkGray)
            {
                txtBarangay.Text = "";
                txtBarangay.ForeColor = Color.Black;
            }
        }

        private void txtStreet_Enter(object sender, EventArgs e)
        {
            lblStreetWarning.Visible = false;
            if (txtStreet.ForeColor == Color.DarkGray)
            {
                txtStreet.Text = "";
                txtStreet.ForeColor = Color.Black;
            }
        }

        private void txtContactPerson_Enter(object sender, EventArgs e)
        {
            lblContactPersonWarning.Visible = false;
            if (txtContactPerson.ForeColor == Color.DarkGray)
            {
                txtContactPerson.Text = "";
                txtContactPerson.ForeColor = Color.Black;
            }
        }

        private void txtEmailPerson_Enter(object sender, EventArgs e)
        {
            lblEmailPersonWarning.Visible = false;
            if (txtEmailPerson.ForeColor == Color.DarkGray)
            {
                txtEmailPerson.Text = "";
                txtEmailPerson.ForeColor = Color.Black;
            }
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            lblContactWarning2.Visible = false;
            if (txtContactNumber.ForeColor == Color.DarkGray)
            {
                txtContactNumber.Text = "";
                txtContactNumber.ForeColor = Color.Black;
            }
        }

        private void txtStreetPerson_Enter(object sender, EventArgs e)
        {
            lblStreetPersonWarning.Visible = false;
            if (txtStreetPerson.ForeColor == Color.DarkGray)
            {
                txtStreetPerson.Text = "";
                txtStreetPerson.ForeColor = Color.Black;
            }
        }

        private void cmbRegion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRegion3Warning.Visible = false;
            if (cmbRegion3.SelectedIndex == 0)
            {
                cmbRegion3.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbRegion3.ForeColor = Color.Black;
            }

        }

        private void cmbCity3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCity3Warning.Visible = false;
            if (cmbCity3.SelectedIndex == 0)
            {
                cmbCity3.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCity3.ForeColor = Color.Black;
            }

        }

        private void cmbRegion31_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRegion31Warning.Visible = false;
            if (cmbRegion31.SelectedIndex == 0)
            {
                cmbRegion31.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbRegion31.ForeColor = Color.Black;
            }

        }

        private void cmbCity31_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCity31Warning.Visible = false;
            if (cmbCity31.SelectedIndex == 0)
            {
                cmbCity31.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCity31.ForeColor = Color.Black;
            }

        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbFirstToEnterCollege_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbPDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbIncome_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContactNumber.Enabled = false;
                txtContactNumber.Text = "";
                txtContactNumber.ForeColor = Color.Black;
                lblContactWarning2.Visible = false;
            }
            else
            {

                txtContactNumber.Enabled = true;
                txtContactNumber.Text = "Contact Number";
                txtContactNumber.ForeColor = Color.DarkGray;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtStreetPerson.Enabled = false;
                txtStreetPerson.Text = "";
                txtStreetPerson.ForeColor = Color.Black;
                cmbRegion31.Enabled = false;
                cmbRegion31.ForeColor = Color.Black;
                cmbCity31.Enabled = false;
                cmbCity31.ForeColor = Color.Black;
                lblCity31Warning.Visible = false;
                lblRegion31Warning.Visible = false;
                lblStreetPersonWarning.Visible = false;
            }
            else
            {
                txtStreetPerson.Enabled = true;
                txtStreetPerson.Text = "Unit#, Street";
                txtStreetPerson.ForeColor = Color.DarkGray;
                cmbRegion31.Enabled = true;
                cmbRegion31.SelectedIndex = 0;
                cmbRegion31.ForeColor = Color.DarkGray;
                cmbCity31.Enabled = true;
                cmbCity31.ForeColor = Color.DarkGray;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                cmbTypeEmployment.Enabled = false;
                cmbTypeEmployment.ForeColor = Color.Black;
                txtNameCompany.Enabled = false;
                txtNameCompany.ForeColor = Color.Black;
                txtCompanyAddress.Enabled = false;
                txtCompanyAddress.ForeColor = Color.Black;
                txtCompanyContact.Enabled = false;
                txtCompanyContact.ForeColor = Color.Black;
                lblTypeEmploymentWarning.Visible = false;
                lblNameCompanyWarning.Visible = false;
                lblCompanyAddressWarning.Visible = false;
                lblCompanyContactWarning.Visible = false;

            }
            else
            {
                cmbTypeEmployment.Enabled = true;
                cmbTypeEmployment.SelectedIndex = 0;
                cmbTypeEmployment.ForeColor = Color.DarkGray;

                txtNameCompany.Enabled = true;
                txtNameCompany.Text = "Complete Name of Company";
                txtNameCompany.ForeColor = Color.DarkGray;

                txtCompanyAddress.Enabled = true;
                txtCompanyAddress.Text = "Address";
                txtCompanyAddress.ForeColor = Color.DarkGray;

                txtCompanyContact.Enabled = true;
                txtCompanyContact.Text = "Contact No. of the company";
                txtCompanyContact.ForeColor = Color.DarkGray;
            }
        }

        private void txtNameCompany_Enter(object sender, EventArgs e)
        {
            lblNameCompanyWarning.Visible = false;
            if (txtNameCompany.ForeColor == Color.DarkGray)
            {
                txtNameCompany.Text = "";
                txtNameCompany.ForeColor = Color.Black;
            }

        }

        private void txtCompanyAddress_Enter(object sender, EventArgs e)
        {
            lblCompanyAddressWarning.Visible = false;
            if (txtCompanyAddress.ForeColor == Color.DarkGray)
            {
                txtCompanyAddress.Text = "";
                txtCompanyAddress.ForeColor = Color.Black;
            }
        }

        private void txtCompanyContact_Enter(object sender, EventArgs e)
        {
            lblCompanyContactWarning.Visible = false;
            if (txtCompanyContact.ForeColor == Color.DarkGray)
            {
                txtCompanyContact.Text = "";
                txtCompanyContact.ForeColor = Color.Black;
            }
        }


        private void txtNameSchool_Enter(object sender, EventArgs e)
        {
            lblNameSchoolWarning.Visible = false;
            if (txtNameSchool.ForeColor == Color.DarkGray)
            {
                txtNameSchool.Text = "";
                txtNameSchool.ForeColor = Color.Black;
            }
        }

        private void txtAddressSchool_Enter(object sender, EventArgs e)
        {
            lblAddressSchoolWarning.Visible = false;
            if (txtAddressSchool.ForeColor == Color.DarkGray)
            {
                txtAddressSchool.Text = "";
                txtAddressSchool.ForeColor = Color.Black;
            }
        }

        private void cmbTypeSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTypeSchoolWarning.Visible = false;
            if (cmbTypeSchool.SelectedIndex == 0)
            {
                cmbTypeSchool.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbTypeSchool.ForeColor = Color.Black;
            }

        }





        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            string noSpace = txtFirstName.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtFirstName.Text = "First Name";
                txtFirstName.ForeColor = Color.DarkGray;
            }
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            string noSpace = txtMiddleName.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtMiddleName.Text = "Middle Name";
                txtMiddleName.ForeColor = Color.DarkGray;
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            string noSpace = txtLastName.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtLastName.Text = "Last Name";
                txtLastName.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string noSpace = txtEmail.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtEmail.Text = "Address";
                txtEmail.ForeColor = Color.DarkGray;
            }
        }

        private void cmbCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCivilWarning.Visible = false;
            if (cmbCivil.SelectedIndex == 0)
            {
                cmbCivil.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCivil.ForeColor = Color.Black;
            }
        }

        private void txtBarangay_Leave(object sender, EventArgs e)
        {

            string noSpace = txtBarangay.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtBarangay.Text = "Address";
                txtBarangay.ForeColor = Color.DarkGray;
            }
        }

        private void txtStreet_Leave(object sender, EventArgs e)
        {

            string noSpace = txtStreet.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtStreet.Text = "Religion";
                txtStreet.ForeColor = Color.DarkGray;
            }
        }

        private void txtContactPerson_Leave(object sender, EventArgs e)
        {

            string noSpace = txtContactPerson.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtContactPerson.Text = "Full Name";
                txtContactPerson.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmailPerson_Leave(object sender, EventArgs e)
        {

            string noSpace = txtEmailPerson.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtEmailPerson.Text = "Address";
                txtEmailPerson.ForeColor = Color.DarkGray;
            }
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {

            string noSpace = txtContactNumber.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtContactNumber.Text = "Contact";
                txtContactNumber.ForeColor = Color.DarkGray;
            }
        }

        private void txtStreetPerson_Leave(object sender, EventArgs e)
        {

            string noSpace = txtStreetPerson.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtStreetPerson.Text = "Unit#, Street";
                txtStreetPerson.ForeColor = Color.DarkGray;
            }
        }

        private void txtNameCompany_Leave(object sender, EventArgs e)
        {
            string noSpace = txtNameCompany.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtNameCompany.Text = "Complete Name of Company";
                txtNameCompany.ForeColor = Color.DarkGray;
            }
        }

        private void txtCompanyAddress_Leave(object sender, EventArgs e)
        {
            string noSpace = txtCompanyAddress.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtCompanyAddress.Text = "Address";
                txtCompanyAddress.ForeColor = Color.DarkGray;
            }
        }

        private void txtCompanyContact_Leave(object sender, EventArgs e)
        {
            string noSpace = txtCompanyContact.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtCompanyContact.Text = "Contact No. of the company";
                txtCompanyContact.ForeColor = Color.DarkGray;
            }
        }

        private void txtNameSchool_Leave(object sender, EventArgs e)
        {
            string noSpace = txtNameSchool.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtNameSchool.Text = "Name of School Where You Graduated";
                txtNameSchool.ForeColor = Color.DarkGray;
            }
        }

        private void txtAddressSchool_Leave(object sender, EventArgs e)
        {
            string noSpace = txtAddressSchool.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtAddressSchool.Text = "Address of The School You Graduated At";
                txtAddressSchool.ForeColor = Color.DarkGray;
            }
        }

        private void cmbTypeEmployment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTypeEmploymentWarning.Visible = false;
            if (cmbTypeEmployment.SelectedIndex == 0)
            {
                cmbTypeEmployment.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbTypeEmployment.ForeColor = Color.Black;
            }
        }
        private void txtNumber_Leave(object sender, EventArgs e)
        {

            string noSpace = txtNumber.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtNumber.Text = "Mobile Number";
                txtNumber.ForeColor = Color.DarkGray;
            }
        }

        private void numGWA11_Enter(object sender, EventArgs e)
        {
            lblGWA11Warning.Visible = false;
        }

        private void numGWA12_Enter(object sender, EventArgs e)
        {
            lblGWA12Warning.Visible = false;
        }

        private void cbxConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxConfirm.Checked)
            {
                lblConfirmWarning.Visible = false;
                txtConfirm.Visible = true;
            }

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? Changes cannot be saved.", "Exit", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                LoginFormPUPSIS login = new LoginFormPUPSIS();
                login.Show();
                this.Hide();
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
            if (cmbCity.SelectedIndex == 0)
            {
                cmbCity.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbCity.ForeColor = Color.Black;
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void richTextBoxEdit1_Enter(object sender, EventArgs e)
        {
            cbxConfirm.Visible = true;
            label78.Visible = true;
        }

        private void richTextBoxEdit1_MouseUp(object sender, MouseEventArgs e)
        {
         
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

     
        private void richTextBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            var rtb = richTextBoxEdit1.Controls[0] as RichTextBox;

            if (rtb == null) return;

            bool isAtEnd =
                rtb.SelectionStart + rtb.SelectionLength >= rtb.TextLength;

            if (isAtEnd)
            {
                cbxConfirm.Visible = true;
                label78.Visible = true;
            }
        
        }

        private void poisonDateTime2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtReligion_Enter(object sender, EventArgs e)
        {
            txtReligion.ForeColor = Color.Black;
            if (txtReligion.Text == "Religion")
            {
                txtReligion.Text = "";
            }
        }

        private void txtReligion_Leave(object sender, EventArgs e)
        {
            string noSpace = txtReligion.Text.Replace(" ", "");
            if (noSpace == "")
            {
                txtReligion.Text = "Religion";
                txtReligion.ForeColor = Color.DarkGray;
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCityWarning.Visible = false;
            if (cmbProvince.SelectedIndex == 0)
            {
                cmbProvince.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbProvince.ForeColor = Color.Black;
            }
        }
    }
}

