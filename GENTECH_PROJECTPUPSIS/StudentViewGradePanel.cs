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
    public partial class StudentViewGradePanel : UserControl
    {
        public StudentViewGradePanel()
        {
            InitializeComponent();
        }

        private void LoadViewGrades()
        {
            dgvStudentViewGrades.Rows.Add("CS101", "Introduction to Programming", "Dr. Maria Santos", 3, 1.75, "Passed");
            dgvStudentViewGrades.Rows.Add("CS102", "Data Structures", "Engr. John Cruz", 3, 2.00, "Passed");
            dgvStudentViewGrades.Rows.Add("IT201", "Database Management Systems", "Prof. Angela Reyes", 3, 1.50, "Passed");
            dgvStudentViewGrades.Rows.Add("IT202", "Web Development", "Mr. Carlo Mendoza", 3, 2.25, "Passed");
            dgvStudentViewGrades.Rows.Add("CS201", "Object-Oriented Programming", "Ms. Liza Garcia", 3, 1.75, "Passed");
            dgvStudentViewGrades.Rows.Add("MATH101", "Discrete Mathematics", "Dr. Ramon Villanueva", 3, 2.50, "Passed");
            dgvStudentViewGrades.Rows.Add("ENG101", "Technical Writing", "Ms. Patricia Lopez", 2, 1.25, "Passed");
            dgvStudentViewGrades.Rows.Add("HIST101", "Philippine History", "Mr. Jose Bautista", 2, 2.75, "Passed");
        }
        private void StudentViewGradePanel_Load(object sender, EventArgs e)
        {
            LoadViewGrades();
        }

        private void dgvStudentViewGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvStudentViewGrades.Columns["dgStudentGradeDetails"].Index && e.RowIndex >= 0)
            {
                StudentMainForm main = (StudentMainForm)this.FindForm();
                main.LoadControl(new StudentViewGradeDetailPanel());
            }
        }
    }
}
