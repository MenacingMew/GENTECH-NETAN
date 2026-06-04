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
    public partial class StudentDashboardPanel : UserControl
    {
        public event EventHandler ToggleDropdownClicked;
        public StudentDashboardPanel()
        {
            InitializeComponent();
        }

        private void btnStudentOpenClass_Click(object sender, EventArgs e)
        {
            StudentMainForm main = (StudentMainForm)this.FindForm();
            main.LoadControl(new StudentHomePagePanel());
            ToggleDropdownClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LoadStudentSchedule()
        {
            dgvStudentDailySchedule.Rows.Clear();
            dgvStudentDailySchedule.Rows.Add("INTE 201 - Object Oriented Programming", "BSIT 2-1", "Monday", "9:00 AM - 12:00 NN");
            dgvStudentDailySchedule.Rows.Add("COMP 010 - Information Management", "BSIT 2-2", "Monday", "2:00 PM - 5:00 PM");
            dgvStudentDailySchedule.Rows.Add("INTE 101 - Human Computer Interaction", "BSIT 1-3", "Monday", "3:00 AM - 11:59 PM");
            dgvStudentDailySchedule.Rows.Add("INTE 207 - Network Administration", "BSIT 1-2", "Monday", "1:00 PM - 3:00 PM");
        }

        private void StudentDashboardPanel_Load(object sender, EventArgs e)
        {
            LoadStudentSchedule();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
