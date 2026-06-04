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
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentMainForm : Form
    {
        private EnrollmentHome home = new EnrollmentHome();
        private EnrollmentGrades grades = new EnrollmentGrades();
        private EnrollmentAccounts accounts = new EnrollmentAccounts();
        private EnrollmentSchedules schedule = new EnrollmentSchedules();
        private EnrollmentConfirmation selectSubjects = new EnrollmentConfirmation();


        public EnrollmentMainForm()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            pnlEnrollmentNavigator.SuspendLayout();
            pnlEnrollmentNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlEnrollmentNavigator.Controls.Add(control);
            pnlEnrollmentNavigator.ResumeLayout();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(home);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            LoadControl(accounts);
        }

        private void btnEnrollmentForm_Click(object sender, EventArgs e)
        {
            LoadControl(selectSubjects);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadControl(schedule);
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            LoadControl(grades);
        }

        private void EnrollmentMainForm_Load(object sender, EventArgs e)
        {
            LoadControl(home);
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
    }
}
