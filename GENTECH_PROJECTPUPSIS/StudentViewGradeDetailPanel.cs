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
    public partial class StudentViewGradeDetailPanel : UserControl
    {
        public StudentViewGradeDetailPanel()
        {
            InitializeComponent();
        }
        private void LoadGradeViewDetails()
        {
            dgvStudentViewGradeDetails.Rows.Add("Activity 1", 18, 20, "90%");
            dgvStudentViewGradeDetails.Rows.Add("Activity 2", 17, 20, "85%");
            dgvStudentViewGradeDetails.Rows.Add("Activity 3", 20, 20, "100%");
            dgvStudentViewGradeDetails.Rows.Add("Quiz 1", 15, 20, "75%");
            dgvStudentViewGradeDetails.Rows.Add("Quiz 2", 16, 20, "70%");
            dgvStudentViewGradeDetails.Rows.Add("Quiz 3", 18, 20, "90%");
            dgvStudentViewGradeDetails.Rows.Add("Assignment 1", 45, 50, "90%");
            dgvStudentViewGradeDetails.Rows.Add("Assignment 2", 48, 50, "96%");
            dgvStudentViewGradeDetails.Rows.Add("Midterm Exam", 78, 100, "78%");
            dgvStudentViewGradeDetails.Rows.Add("Final Exam", 85, 100, "85%");
        }
        private void StudentViewGradeDetailPanel_Load(object sender, EventArgs e)
        {
            LoadGradeViewDetails();
        }
    }
}
