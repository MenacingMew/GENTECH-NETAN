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
    public partial class StudentHomePagePanel : UserControl
    {
        public StudentHomePagePanel()
        {
            InitializeComponent();
        }

        private void LoadStudentModules()
        {
            dgvStudentModules.Rows.Add("Week 1: Introduction Introduction", "View");
            dgvStudentModules.Rows.Add("Week 2: Algorithms", "View");
            dgvStudentModules.Rows.Add("Week 3: CSS Styling", "View");
            dgvStudentModules.Rows.Add("Week 5: Sparring Session - Square Bati", "View");
        }

        private void LoadAnnouncements()
        {
            dgvStudentAnnouncement.Rows.Add("Welcome! Welcome to the course. Please check all modules. April 1, 2026");
            dgvStudentAnnouncement.Rows.Add("Deadline Reminder", "Assignment 1 is due tomorrow.", "April 3, 2026");
            dgvStudentAnnouncement.Rows.Add("New Module Released Module 3 is now available. April 4, 2026");
            dgvStudentAnnouncement.Rows.Add("System Maintenance LMS will be down from 10PM–12AM. April 5, 2026");
            dgvStudentAnnouncement.Rows.Add("Exam Notice Midterm exam scheduled on April 12. April 7, 2026");
        }

        private void StudentHomePagePanel_Load(object sender, EventArgs e)
        {
            LoadStudentModules();
            LoadAnnouncements();
        }

        private void dgvStudentModules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvStudentModules.Columns["dgStudentHomePageAction"].Index && e.RowIndex >= 0)
            {
                StudentMainForm main = (StudentMainForm)this.FindForm();
                main.LoadControl(new StudentModulePanel());
            }
        }
    }
}
