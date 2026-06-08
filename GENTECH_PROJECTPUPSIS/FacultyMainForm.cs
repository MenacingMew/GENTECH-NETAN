using StudentEnrollmentDraft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class FacultyMainForm : Form
    {
        bool QnEMenuExpanded = false;
        bool AssignmentMenuExpanded = false;
        bool sideMenuExpanded = true;
        bool ButtonsExpanded = false;
        public FacultyMainForm()
        {
            InitializeComponent();
        }

        private FacultyDashboardPanel dashboardPanel = new FacultyDashboardPanel();
        private FacultyHomePagePanel homePanel = new FacultyHomePagePanel();
        private FacultyQnEPanel qnePanel = new FacultyQnEPanel();
        private FacultyAssignmentsPanel assignmentsPanel = new FacultyAssignmentsPanel();
        private FacultyCreateAssignmentPanel createAssignmentPanel = new FacultyCreateAssignmentPanel();
        private FacultyCreateQnEPanel createQnEPanel = new FacultyCreateQnEPanel();
        private FacultyModulePanel modulePanel = new FacultyModulePanel();
        private FacultyResultViewPanel resultViewPanel = new FacultyResultViewPanel();
        private FacultyStudentsRecordPanel studentsRecordPanel = new FacultyStudentsRecordPanel();
        private FacultySubmissionPanel submissionPanel = new FacultySubmissionPanel();
        private FcultyClassScheduleView facultysched = new FcultyClassScheduleView();
        public void LoadControl(UserControl control)
        {
            pnlNavigator.SuspendLayout();
            pnlNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlNavigator.Controls.Add(control);
            pnlNavigator.ResumeLayout();
        }

        private void tmrQneMenu_Tick(object sender, EventArgs e)
        {
            if (QnEMenuExpanded == false)
            {
                fpnlMenuContainerQnE.Height += 5;
                if (fpnlMenuContainerQnE.Height >= 122)
                {
                    QnEMenuExpanded = true;
                    tmrQneMenu.Stop();
                }
            }
            else
            {
                fpnlMenuContainerQnE.Height -= 5;
                if (fpnlMenuContainerQnE.Height <= 56)
                {
                    QnEMenuExpanded = false;
                    tmrQneMenu.Stop();
                }
            }
        }

        private void tmrAssingmentMenu_Tick(object sender, EventArgs e)
        {
            if (AssignmentMenuExpanded == false)
            {
                fpnlMenuContainerAssignments.Height += 5;
                if (fpnlMenuContainerAssignments.Height >= 122)
                {
                    AssignmentMenuExpanded = true;
                    tmrAssingmentMenu.Stop();
                }
            }
            else
            {
                fpnlMenuContainerAssignments.Height -= 5;
                if (fpnlMenuContainerAssignments.Height <= 56)
                {
                    AssignmentMenuExpanded = false;
                    tmrAssingmentMenu.Stop();
                }
            }
        }

        private void tmrSideBarMenu_Tick(object sender, EventArgs e)
        {
            if (sideMenuExpanded)
            {
                pnlSideMenu.Width -= 5;
                if (pnlSideMenu.Width <= 58)
                {
                    sideMenuExpanded = false;
                    tmrSideBarMenu.Stop();
                    lblPUPSIS.Text = "PUP";
                    lblPUPSIS.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                    lblSMBC.Visible = false;
                }
            }
            else
            {
                pnlSideMenu.Width += 5;
                if (pnlSideMenu.Width >= 198)
                {
                    sideMenuExpanded = true;
                    tmrSideBarMenu.Stop();
                    lblPUPSIS.Text = "PUPSIS";
                    lblPUPSIS.Font = new Font("Segoe UI", 30, FontStyle.Bold);
                    lblSMBC.Visible = true;

                }
            }
        }

        private void btnMinimizeSideBar_Click(object sender, EventArgs e)
        {
            tmrSideBarMenu.Start();
        }

        private void btnQnE_Click(object sender, EventArgs e)
        {
            tmrQneMenu.Start();
            if (AssignmentMenuExpanded == true)
            {
                fpnlMenuContainerAssignments.Height = 56;
                if (fpnlMenuContainerAssignments.Height <= 56)
                {
                    tmrAssingmentMenu.Stop();
                    AssignmentMenuExpanded = false;
                }
            }
            LoadControl(qnePanel);
        }
        private void btnAssignments_Click(object sender, EventArgs e)
        {
            tmrAssingmentMenu.Start();
            if (QnEMenuExpanded == true)
            {
                fpnlMenuContainerQnE.Height = 56;
                if (fpnlMenuContainerQnE.Height <= 56)
                {
                    tmrQneMenu.Stop();
                    QnEMenuExpanded = false;
                }
            }
            LoadControl(assignmentsPanel);
        }

        private void FacultyMainForm_Load(object sender, EventArgs e)
        {
            LoadControl(dashboardPanel);
            dashboardPanel.ToggleDropdownClicked += DashboardPanel_ToggleDropdownClicked;
        }
        private void DashboardPanel_ToggleDropdownClicked(object sender, EventArgs e)
        {
            tmrClassClick.Start();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadControl(dashboardPanel);
            if (ButtonsExpanded == true)
            {
                flpnFacultyDashboard.Height = 56;
                tmrClassClick.Stop();
                ButtonsExpanded = false;
            }
            if (AssignmentMenuExpanded == true)
            {
                fpnlMenuContainerAssignments.Height = 56;
                tmrAssingmentMenu.Stop();
                AssignmentMenuExpanded = false;

            }
            else if (QnEMenuExpanded == true)
            {
                fpnlMenuContainerQnE.Height = 56;
                tmrQneMenu.Stop();
                QnEMenuExpanded = false;
            }
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            LoadControl(modulePanel);
            if (AssignmentMenuExpanded == true)
            {
                fpnlMenuContainerAssignments.Height = 56;
                tmrAssingmentMenu.Stop();
                AssignmentMenuExpanded = false;

            }
            else if (QnEMenuExpanded == true)
            {
                fpnlMenuContainerQnE.Height = 56;
                tmrQneMenu.Stop();
                QnEMenuExpanded = false;
            }
        }

        private void btnStudentRecord_Click(object sender, EventArgs e)
        {
            LoadControl(studentsRecordPanel);
            if (AssignmentMenuExpanded == true)
            {
                fpnlMenuContainerAssignments.Height = 56;
                tmrAssingmentMenu.Stop();
                AssignmentMenuExpanded = false;

            }
            else if (QnEMenuExpanded == true)
            {
                fpnlMenuContainerQnE.Height = 56;
                tmrQneMenu.Stop();
                QnEMenuExpanded = false;
            }
        }

        private void btnCreateAssignments_Click(object sender, EventArgs e)
        {
            LoadControl(createAssignmentPanel);
        }

        private void btnSubmissions_Click(object sender, EventArgs e)
        {
            LoadControl(submissionPanel);
        }

        private void btnCreateQnE_Click(object sender, EventArgs e)
        {
            LoadControl(createQnEPanel);
        }

        private void btnQneResult_Click(object sender, EventArgs e)
        {
            LoadControl(resultViewPanel);
        }

        private void tmrClassClick_Tick(object sender, EventArgs e)
        {
            if (ButtonsExpanded == false)
            {
                flpnFacultyDashboard.Height += 15;
                if (flpnFacultyDashboard.Height >= 433)
                {
                    ButtonsExpanded = true;
                    tmrClassClick.Stop();
                }
            }
            else
            {
                flpnFacultyDashboard.Height -= 15;
                if (flpnFacultyDashboard.Height <= 56)
                {
                    ButtonsExpanded = false;
                    tmrClassClick.Stop();
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(homePanel);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginFormPUPSIS loginForm = new LoginFormPUPSIS();
                loginForm.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(facultysched);
        }
    }
}