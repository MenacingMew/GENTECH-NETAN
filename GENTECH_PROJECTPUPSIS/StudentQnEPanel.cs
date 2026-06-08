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
    public partial class StudentQnEPanel : UserControl
    {
        public StudentQnEPanel()
        {
            InitializeComponent();
        }

        private void LoadQnEList()
        {
            dgvQneList.Rows.Add("Quiz 1: Intro to Computing", 15, "April 3, 2026", "13/15", "View");
            dgvQneList.Rows.Add("Long Quiz 1: Programming Basics", 40, "April 6, 2026", "35/40", "View");
            dgvQneList.Rows.Add("Midterm Exam: IT Fundamentals", 60, "April 10, 2026", "In Progress", "Take Exam");
            dgvQneList.Rows.Add("Quiz 2: Data Structures", 20, "April 13, 2026", "In Progress", "Take Quiz");
            dgvQneList.Rows.Add("Final Exam: Systems & Networking", 80, "April 20, 2026", "In Progress", "Take Exam");
        }
        private void StudentQnEPanel_Load(object sender, EventArgs e)
        {
            LoadQnEList();
        }

        private void dgvQneList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQneList.Columns["dgStudentAction"].Index && e.RowIndex >= 0)
            {
                StudentMainForm main = (StudentMainForm)this.FindForm();
                main.LoadControl(new StudentAnswerFormPanel());
            }
        }
    }
}
