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
    public partial class FacultyQnEPanel : UserControl
    {
        public FacultyQnEPanel()
        {
            InitializeComponent();
        }

        private void LoadQnEList()
        {
            dgvQnEList.Rows.Add("Quiz 1: Basic Concepts", "Quiz", "10 items", "20 mins", "Apr 05, 2026 - 11:59 PM", "Completed");
            dgvQnEList.Rows.Add("Quiz 2: Variables", "Quiz", "15 items", "25 mins", "Apr 08, 2026 - 10:00 AM", "Completed");
            dgvQnEList.Rows.Add("Long Quiz 1: Algebra", "Long Quiz", "30 items", "1 hr", "Apr 12, 2026 - 3:00 PM", "Submitted");
            dgvQnEList.Rows.Add("Midterm Exam", "Exam", "60 items", "1.5 hrs", "Apr 18, 2026 - 8:00 AM", "Pending");
            dgvQnEList.Rows.Add("Quiz 3: Functions", "Quiz", "12 items", "20 mins", "Apr 20, 2026 - 10:00 AM", "Not Started");
            dgvQnEList.Rows.Add("Long Quiz 2: Programming", "Long Quiz", "35 items", "1 hr", "Apr 25, 2026 - 12:00 NN", "In Progress");
            dgvQnEList.Rows.Add("Final Exam", "Exam", "100 items", "2 hrs", "May 05, 2026 - 3:00 PM", "Not Started");
            dgvQnEList.Rows.Add("Long Quiz 3: Data Structures", "Long Quiz", "40 items", "1.5 hrs", "May 02, 2026 - 11:59 AM", "Pending");
        }
        private void FacultyQnEPanel_Load(object sender, EventArgs e)
        {
            LoadQnEList();
        }
    }
}
