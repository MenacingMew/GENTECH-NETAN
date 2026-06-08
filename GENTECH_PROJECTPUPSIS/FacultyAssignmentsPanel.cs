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
    public partial class FacultyAssignmentsPanel : UserControl
    {
        public FacultyAssignmentsPanel()
        {
            InitializeComponent();
        }

        private void LoadAssActList()
        {
            dgvAssActList.Rows.Add("Essay: Climate Change Impact", "Assignment", "Apr 05, 2026, 11:59 PM", "Submitted");
            dgvAssActList.Rows.Add("Activity 1: Math Drill", "Activity", "Apr 07, 2026, 10:00 AM", "Completed");
            dgvAssActList.Rows.Add("Research Paper Draft", "Assignment", "Apr 10, 2026, 05:00 PM", "In Progress");
            dgvAssActList.Rows.Add("Activity 2: Programming Basics", "Activity", "Apr 12, 2026, 09:30 AM", "Not Started");
            dgvAssActList.Rows.Add("Activity 3: Science Experiment", "Activity", "Apr 18, 2026, 01:00 PM", "Completed");
            dgvAssActList.Rows.Add("Reflection Paper", "Assignment", "Apr 20, 2026, 06:00 PM", "Submitted");
            dgvAssActList.Rows.Add("Activity 4: Database Practice", "Activity", "Apr 22, 2026, 08:30 AM", "In Progress");
            dgvAssActList.Rows.Add("Final Project Proposal", "Assignment", "Apr 25, 2026, 11:59 PM", "Not Started");
            dgvAssActList.Rows.Add("Activity 5: UI Design Task", "Activity", "Apr 28, 2026, 03:00 PM", "Pending");
        }

        private void FacultyAssignmentsPanel_Load(object sender, EventArgs e)
        {
            LoadAssActList();
        }
    }
}
