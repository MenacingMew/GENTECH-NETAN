using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class LoginAboutPage : UserControl
    {
        private LoginAboutPUP aboutPUP = new LoginAboutPUP();
        private LoginMissionandVision missionandVision = new LoginMissionandVision();

        public LoginAboutPage()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            pnlAboutNavigator.SuspendLayout();
            pnlAboutNavigator.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            pnlAboutNavigator.Controls.Add(control);
            pnlAboutNavigator.ResumeLayout();
        }

        private void btnAboutPUP_Click(object sender, EventArgs e)
        {
            LoadControl(aboutPUP);
        }

        private void btnMissionVision_Click(object sender, EventArgs e)
        {
            LoadControl(missionandVision);
        }

        private void LoginAboutPage_Load(object sender, EventArgs e)
        {
            LoadControl(aboutPUP);
        }
    }
}
