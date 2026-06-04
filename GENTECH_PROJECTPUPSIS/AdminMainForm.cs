using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;



namespace GENTECH_PROJECTPUPSIS
{
    

    public partial class AdminMainForm : Form
    {
        bool sideMenuExpanded = true;
        bool UserManagementMenuExpanded = false;
        private AdminDashboardPanel dashboardPanel = new AdminDashboardPanel();
        private AdminCourseManagement courseManagement = new AdminCourseManagement();
        private AdminFacultynAdminCreate facultynAdminCreate = new AdminFacultynAdminCreate();
        private AdminFacultyReport facultyReport = new AdminFacultyReport();
        private AdminModifyEnrollment modifyEnrollment = new AdminModifyEnrollment();
        private AdminStudentRecords studentRecords = new AdminStudentRecords();
        private AdminStudentReportPanel studentReport = new AdminStudentReportPanel();
        private AdminUserManagement userManagement = new AdminUserManagement();
        private AdminFacultyReportView facultyReportView = new AdminFacultyReportView();
        bool isOn = true;
        public AdminMainForm()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );
        public void LoadControl(UserControl control)
        {
            pnlAdminNavigator.SuspendLayout();
            pnlAdminNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlAdminNavigator.Controls.Add(control);
            pnlAdminNavigator.ResumeLayout();
        }

        private void btnAdminSR_Click(object sender, EventArgs e)
        {
            LoadControl(studentReport);
        }

        private void btnAdminFR_Click(object sender, EventArgs e)
        {
            LoadControl(facultyReport);
        }

        private void btnAdminCM_Click(object sender, EventArgs e)
        {
            LoadControl(courseManagement);
        }

        private void btnAdminUM_Click(object sender, EventArgs e)
        {
            LoadControl(userManagement);
            tmrUserManagement.Start();
        }

        private void btnCreateAssignments_Click(object sender, EventArgs e)
        {
            LoadControl(studentRecords);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(facultynAdminCreate);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadControl(facultynAdminCreate);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            LoadControl(modifyEnrollment);
        }

        private void tmrUserManagement_Tick(object sender, EventArgs e)
        {
            if (UserManagementMenuExpanded == false)
            {
                fpnlUserManagementMenu.Height += 5;
                if (fpnlUserManagementMenu.Height >= 128)
                {
                    UserManagementMenuExpanded = true;
                    tmrUserManagement.Stop();
                }
            }
            else
            {
                fpnlUserManagementMenu.Height -= 5;
                if (fpnlUserManagementMenu.Height <= 56)
                {
                    UserManagementMenuExpanded = false;
                    tmrUserManagement.Stop();
                }
            }
        }

        private void tmrEnrollmentSideBar_Tick(object sender, EventArgs e)
        {
            if (sideMenuExpanded)
            {
                pnlAdminSideMenu.Width -= 5;
                if (pnlAdminSideMenu.Width <= 58)
                {
                    sideMenuExpanded = false;
                    tmrEnrollmentSideBar.Stop();
                    lblPUPSIS.Text = "PUP";
                    lblPUPSIS.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                    lblSMBC.Visible = false;
                }
            }
            else
            {
                pnlAdminSideMenu.Width += 5;
                if (pnlAdminSideMenu.Width >= 198)
                {
                    sideMenuExpanded = true;
                    tmrEnrollmentSideBar.Stop();
                    lblPUPSIS.Text = "PUPSIS";
                    lblPUPSIS.Font = new Font("Segoe UI", 30, FontStyle.Bold);
                    lblSMBC.Visible = true;

                }
            }
        }

        private void btnMinimizeSideBar_Click(object sender, EventArgs e)
        {
            tmrEnrollmentSideBar.Start();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginFormPUPSIS loginForm = new LoginFormPUPSIS();
                loginForm.Show();
                this.Close();
            }
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            LoadControl(studentReport);
            pnlSwitch.Width = 60;
            pnlSwitch.Height = 30;
            pnlSwitch.BackColor = Color.Firebrick;

            pnlCircle.Width = 26;
            pnlCircle.Height = 26;
            pnlCircle.BackColor = Color.White;

            pnlCircle.Location = new Point(32, 2);

            MakeRounded(pnlSwitch, 30);
            MakeRounded(pnlCircle, 26);

            pnlSwitch.Cursor = Cursors.Hand;
            pnlCircle.Cursor = Cursors.Hand;

        }
        private void MakeRounded(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(
                0,
                0,
                control.Width,
                control.Height,
                radius,
                radius));
        }
        private void ToggleSwitch()
        {
            isOn = !isOn;

            if (isOn)
            {
                pnlSwitch.BackColor = Color.Firebrick;
                pnlCircle.Location = new Point(32, 2);
            }
            else
            {
                pnlSwitch.BackColor = Color.Gray;
                pnlCircle.Location = new Point(2, 2);
            }
        }
        private void pnlSwitch_Click(object sender, EventArgs e)
        {
            ToggleSwitch();
        }

        private void pnlCircle_Click(object sender, EventArgs e)
        {
            ToggleSwitch();
        }


    }
}
