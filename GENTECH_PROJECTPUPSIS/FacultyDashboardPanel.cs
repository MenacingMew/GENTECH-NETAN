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
    public partial class FacultyDashboardPanel : UserControl
    {
        public event EventHandler ToggleDropdownClicked;
        public FacultyDashboardPanel()
        {
            InitializeComponent();
        }

        private void customPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFacultyOpenClass_Click(object sender, EventArgs e)
        {
            FacultyMainForm main = (FacultyMainForm)this.FindForm();
            main.LoadControl(new FacultyHomePagePanel());
            ToggleDropdownClicked?.Invoke(this, EventArgs.Empty);
        }

        private void FacultyDashboardPanel_Load(object sender, EventArgs e)
        {
            dgvWeeklySched.Rows.Clear();

            dgvWeeklySched.Rows.Add("INTE 201 - Object Oriented Programming", "BSIT 2-1", "Monday", "9:00 AM - 12:00 NN");
            dgvWeeklySched.Rows.Add("COMP 010 - Information Management", "BSIT 2-2", "Monday", "2:00 PM - 5:00 PM");
            dgvWeeklySched.Rows.Add("INTE 101 - Human Computer Interaction", "BSIT 1-3", "Monday", "3:00 AM - 11:59 PM");
            dgvWeeklySched.Rows.Add("INTE 207 - Network Administration", "BSIT 1-2", "Monday", "1:00 PM - 3:00 PM");
        }

        private void dgvWeeklySched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
