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
    public partial class AdminFacultyReport : UserControl
    {
        public AdminFacultyReport()
        {
            InitializeComponent();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvIndivReport.Columns["dgFacReportAction"].Index && e.RowIndex >= 0)
            {
                AdminMainForm main = (AdminMainForm)this.FindForm();
                main.LoadControl(new AdminFacultyReportView());
            }
        }

        private void LoadIndivReport()
        {
            dgvIndivReport.Rows.Add("F001", "John Smith", "Computer Science", 120, "Programming, Databases", "92%", "Edit");
            dgvIndivReport.Rows.Add("F002", "Emily Johnson", "Mathematics", 95, "Calculus, Algebra", "88%", "Edit");
            dgvIndivReport.Rows.Add("F003", "Michael Brown", "Physics", 80, "Mechanics, Thermodynamics", "85%", "Edit");
            dgvIndivReport.Rows.Add("F004", "Sarah Davis", "English", 110, "Literature, Writing", "90%", "Edit");
            dgvIndivReport.Rows.Add("F005", "David Wilson", "Business", 130, "Marketing, Management", "87%", "Edit");
            dgvIndivReport.Rows.Add("F006", "Laura Martinez", "Chemistry", 75, "Organic, Inorganic", "83%", "Edit");
            dgvIndivReport.Rows.Add("F007", "James Anderson", "IT", 140, "Networking, Security", "91%", "Edit");
            dgvIndivReport.Rows.Add("F008", "Sophia Taylor", "Biology", 100, "Genetics, Ecology", "89%", "Edit");
        }

        private void AdminFacultyReport_Load(object sender, EventArgs e)
        {
            LoadIndivReport();
        }
    }
}
