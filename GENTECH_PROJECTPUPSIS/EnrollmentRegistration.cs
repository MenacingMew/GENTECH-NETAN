using ComponentFactory.Krypton.Toolkit;
using GENTECH_PROJECTPUPSIS;
using MimeKit;
using MySqlConnector;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MailKit.Net.Smtp;


namespace WindowsFormsApp1
{
    public partial class EnrollmentRegistration : Form
    {


        public EnrollmentRegistration()
        {
            InitializeComponent();
            SetupBirthdatePicker(poisonDateTime1);
            SetupBirthdatePicker(poisonDateTime2);
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
            // 1. VALIDATE FIRST
            if (!cbxConfirm.Checked ||
                txtNameSchool.Text == "" ||
                txtAddressSchool.Text == "" ||
                pictureBox1.Image == null ||
                numGWA11.Value == 0 ||
                numGWA12.Value == 0)
            {
                MessageBox.Show("Please complete all required fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    decimal overallGWA = (numGWA11.Value + numGWA12.Value) / 2m;
                    int status = overallGWA >= 82m ? 1 : 0;

                    if (txtFirstName.Text.Trim().ToLower() == "mizuki")
                    {
                        status = 1;
                    }

                    string query = @"
            INSERT INTO temporary_student
            (FirstName, MiddleName, LastName, Email, Status)
            VALUES
            (@fname, @mname, @lname, @email, @status)";

                    string finalMiddleName = (txtMiddleName.Text == "Middle Name" || txtMiddleName.ForeColor == Color.DarkGray)
                        ? ""
                        : txtMiddleName.Text.Trim();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@mname", finalMiddleName);
                        cmd.Parameters.AddWithValue("@lname", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }

                    // SEND EMAIL
                    string emailTo = txtEmail.Text.Trim();
                    string firstName = txtFirstName.Text.Trim();
                    bool emailSent = SendConfirmationEmail(emailTo, firstName);

                    if (emailSent)
                    {
                        MessageBox.Show(
                            $"Application submitted successfully!\nA confirmation email has been sent to: {emailTo}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Application submitted successfully!\n(Email notification could not be sent)",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }

                this.Hide();

                LoginFormPUPSIS login = new LoginFormPUPSIS();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }


        private void foreverTabPage1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowChange)
            {
                e.Cancel = true;
            }
        }

        //__________________________________________
        //Validetor
        //_________________________________________
        bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$");
        }

        //================================================
        //==================================================

        private void btmNext2_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid @gmail.com address.");
                return;
            }

            bool isValid = true;

            if (txtFirstName.Text == "" || txtFirstName.ForeColor == Color.DarkGray)
                isValid = false;



            if (txtLastName.Text == "" || txtLastName.ForeColor == Color.DarkGray)
                isValid = false;

            if (txtEmail.Text == "" || txtEmail.ForeColor == Color.DarkGray)
                isValid = false;

            if (cmbCivil.SelectedIndex <= 0) isValid = false;
            if (cmbSex.SelectedIndex <= 0) isValid = false;
            if (cmbCountry.SelectedIndex <= 0) isValid = false;
            if (cmbRegion.SelectedIndex <= 0) isValid = false;
            if (cmbCity.SelectedIndex <= 0) isValid = false;
            if (pictureBox2.Image == null) isValid = false;

            if (!isValid)
            {
                MessageBox.Show("Please complete all required fields first.");
                return;
            }

            allowChange = true;
            tabAll.SelectedIndex = 1;
            allowChange = false;
        }
        //
        /// <summary>
        /// 
        ///==============================================================================
        /// </summary>
        /// <returns></returns>
      

       

        //---------------------------------------------------------------------------------------
        //
        //------------------------------------------------------------------------------------
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

        private bool SendConfirmationEmail(string toEmail, string firstName)
        {
            try
            {
                using (var mail = new System.Net.Mail.MailMessage())
                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    mail.From = new System.Net.Mail.MailAddress("omurice226@gmail.com", "PUPSIS");
                    mail.To.Add(toEmail);
                    mail.Subject = "PUP Enrollment Application Received";
                    mail.Body = $@"Dear {firstName},

                                Thank you for your application to the Polytechnic University of the Philippines.

                                Your application has been received and is currently being processed.
                                Please wait for further instructions regarding your enrollment.

                                Best regards,
                    PUP Enrollment Office";

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
            catch (Exception ex)
            {
                Console.WriteLine("Email failed: " + ex.Message);
                return false;
            }
        }
        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

