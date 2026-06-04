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
    public partial class StudentActivityList : UserControl
    {
        public StudentActivityList()
        {
            InitializeComponent();
        }

        private void LoadAssignmentList()
        {
            dgvStudentAssignmentList.Rows.Add("Assignment 1: HTML Page", "Assignment", 50, "April 3, 2026", "Closed", "Submitted", "View");
            dgvStudentAssignmentList.Rows.Add("Activity 1: CSS Styling", "Activity", 20, "April 4, 2026", "Closed", "Submitted", "View");
            dgvStudentAssignmentList.Rows.Add("Assignment 2: JavaScript Basics", "Assignment", 60, "April 6, 2026", "Open", "Not Submitted", "Submit");
            dgvStudentAssignmentList.Rows.Add("Activity 2: Debugging Exercise", "Activity", 25, "April 7, 2026", "Open", "In Progress", "Continue");
            dgvStudentAssignmentList.Rows.Add("Assignment 3: Form Validation", "Assignment", 70, "April 9, 2026", "Open", "Not Submitted", "Submit");
            dgvStudentAssignmentList.Rows.Add("Activity 3: DOM Manipulation", "Activity", 30, "April 10, 2026", "Open", "Not Submitted", "Start");
            dgvStudentAssignmentList.Rows.Add("Assignment 4: Mini Project", "Assignment", 100, "April 15, 2026", "Open", "In Progress", "Continue");
            dgvStudentAssignmentList.Rows.Add("Activity 4: Code Review", "Activity", 20, "April 16, 2026", "Open", "Not Submitted", "Start");
        }
        private void StudentActivityList_Load(object sender, EventArgs e)
        {
            LoadAssignmentList();
        }

        private void dgvStudentAssignmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvStudentAssignmentList.Columns["dgStudentTaskAction"].Index && e.RowIndex >= 0)
            {
                StudentMainForm main = (StudentMainForm)this.FindForm();
                main.LoadControl(new StudentActivitySubmissionPanel());
            }
        }
    }
}
