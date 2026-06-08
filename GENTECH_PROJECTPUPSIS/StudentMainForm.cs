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
    public partial class StudentMainForm : Form
    {
        bool StudentButtonsExpanded = false;
        bool sideStudentMenuExpanded = true;
        public StudentMainForm()
        {
            InitializeComponent();
        }

        private StudentDashboardPanel dashboardPanel = new StudentDashboardPanel();
        private StudentHomePagePanel homePanel = new StudentHomePagePanel();
        private StudentModulePanel modulePanel = new StudentModulePanel();
        private StudentAnswerFormPanel answerFormPanel = new StudentAnswerFormPanel();
        private StudentActivityList activityListPanel = new StudentActivityList();
        private StudentActivitySubmissionPanel activitySubmissionPanel = new StudentActivitySubmissionPanel();
        private StudentQnEPanel qnePanel = new StudentQnEPanel();
        private StudentViewGradePanel viewGradePanel = new StudentViewGradePanel();
        private StudentViewGradeDetailPanel viewGradeDetailPanel = new StudentViewGradeDetailPanel();

        public void LoadControl(UserControl control)
        {
            pnlStudentNavigator.SuspendLayout();
            pnlStudentNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlStudentNavigator.Controls.Add(control);
            pnlStudentNavigator.ResumeLayout();
        }

        private void tmrStudentSideBar_Tick(object sender, EventArgs e)
        {
            if (sideStudentMenuExpanded)
            {
                pnlStudentSideMenu.Width -= 5;
                if (pnlStudentSideMenu.Width <= 58)
                {
                    sideStudentMenuExpanded = false;
                    tmrStudentSideBar.Stop();
                    lblPUPSIS.Text = "PUP";
                    lblPUPSIS.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                    lblSMBC.Visible = false;
                }
            }
            else
            {
                pnlStudentSideMenu.Width += 5;
                if (pnlStudentSideMenu.Width >= 198)
                {
                    sideStudentMenuExpanded = true;
                    tmrStudentSideBar.Stop();
                    lblPUPSIS.Text = "PUPSIS";
                    lblPUPSIS.Font = new Font("Segoe UI", 30, FontStyle.Bold);
                    lblSMBC.Visible = true;

                }
            }
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            LoadControl(dashboardPanel);
            dashboardPanel.ToggleDropdownClicked += DashboardPanel_ToggleDropdownClicked;
        }
        private void DashboardPanel_ToggleDropdownClicked(object sender, EventArgs e)
        {
            tmrStudentClassClick.Start();
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            LoadControl(modulePanel);
        }

        private void btnQnE_Click(object sender, EventArgs e)
        {
            LoadControl(qnePanel);
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            LoadControl(activityListPanel);
        }

        private void btnStudentRecord_Click(object sender, EventArgs e)
        {
            LoadControl(viewGradePanel);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadControl(dashboardPanel);
            if (StudentButtonsExpanded == true)
            {
                flpnStudentButtons.Height = 56;
                tmrStudentClassClick.Stop();
                StudentButtonsExpanded = false;
            }
        }

        private void btnMinimizeSideBar_Click(object sender, EventArgs e)
        {
            tmrStudentSideBar.Start();
        }

        private void tmrStudentClassClick_Tick(object sender, EventArgs e)
        {
            if (StudentButtonsExpanded == false)
            {
                flpnStudentButtons.Height += 15;
                if (flpnStudentButtons.Height >= 280)
                {
                    StudentButtonsExpanded = true;
                    tmrStudentClassClick.Stop();
                }
            }
            else
            {
                flpnStudentButtons.Height -= 15;
                if (flpnStudentButtons.Height <= 56)
                {
                    StudentButtonsExpanded = false;
                    tmrStudentClassClick.Stop();
                }
            }
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            LoadControl(homePanel);
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
    }
}
