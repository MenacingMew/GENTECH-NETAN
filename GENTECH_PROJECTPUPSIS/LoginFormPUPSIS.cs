using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class LoginFormPUPSIS : Form
    {
        private LoginAboutPage LoginAboutPage = new LoginAboutPage();
        private LoginSignInPage signInPage = new LoginSignInPage();
        private LoginProgramPage programPage = new LoginProgramPage();

        public LoginFormPUPSIS()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            pnlLoginNavigator.SuspendLayout();
            pnlLoginNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlLoginNavigator.Controls.Add(control);
            pnlLoginNavigator.ResumeLayout();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            EnrollmentRegistration enrollment = new EnrollmentRegistration();
            enrollment.Show();
            this.Hide();
        }

        private void LoginFormPUPSIS_Load(object sender, EventArgs e)
        {
            LoadControl(signInPage);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadControl(programPage);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadControl(LoginAboutPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(signInPage);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.pup.edu.ph/events/");
        }
        private void OpenUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _)) return;

            try
            {
                Process.Start(url); // works on .NET Framework 4.8
            }
            catch
            {
                // Robust fallback
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
        }

    }
}
