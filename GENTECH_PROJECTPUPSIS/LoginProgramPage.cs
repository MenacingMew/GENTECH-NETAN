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
    public partial class LoginProgramPage : UserControl
    {
        private LoginProgramPageDOMT DOMTPage = new LoginProgramPageDOMT();
        private LoginProgramPageAccounting AccountingPage = new LoginProgramPageAccounting();
        private LoginProgramPageAFT AFTPage = new LoginProgramPageAFT();
        private LoginProgramPageCEM CEMPage = new LoginProgramPageCEM();
        private LoginProgramPageCPE CPEPage = new LoginProgramPageCPE();
        private LoginProgramPageHMSOC HMSOCPage = new LoginProgramPageHMSOC();
        private LoginProgramPageIT ITPage = new LoginProgramPageIT();

        public LoginProgramPage()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            ProgramPageNav.SuspendLayout();
            ProgramPageNav.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            ProgramPageNav.Controls.Add(control);
            ProgramPageNav.ResumeLayout();
        }

        private void pnlDOMT_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(DOMTPage);
        }

        private void pnlCPE_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(CEMPage);
        }

        private void pnlAFT_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(AFTPage);
        }

        private void pnlEntrep_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(CPEPage);
        }

        private void pnlIT_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(ITPage);
        }

        private void kryptonPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(AccountingPage);
        }

        private void pnlHMSOC_MouseClick(object sender, MouseEventArgs e)
        {
            LoadControl(HMSOCPage);
        }

        private void lblDOMT_Click(object sender, EventArgs e)
        {
            LoadControl(DOMTPage);
        }

        private void lblEntrep_Click(object sender, EventArgs e)
        {
            LoadControl(CEMPage);
        }

        private void lblAFT_Click(object sender, EventArgs e)
        {
            LoadControl(AFTPage);
        }

        private void lblCPE_Click(object sender, EventArgs e)
        {
            LoadControl(CPEPage);
        }

        private void lblIT_Click(object sender, EventArgs e)
        {
            LoadControl(ITPage);
        }

        private void lblHMSOC_Click(object sender, EventArgs e)
        {
            LoadControl(HMSOCPage);
        }

        private void lblAccountancy_Click(object sender, EventArgs e)
        {
            LoadControl(AccountingPage);
        }
    }
}
