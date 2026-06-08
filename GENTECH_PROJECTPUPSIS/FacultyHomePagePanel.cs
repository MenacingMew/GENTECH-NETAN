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
    public partial class FacultyHomePagePanel : UserControl
    {
        public FacultyHomePagePanel()
        {
            InitializeComponent();
        }
        private void LoadLatestSubmissions()
        {
            dgvLatestSubmissions.Rows.Add("Juan Dela Cruz", "Assignment");
            dgvLatestSubmissions.Rows.Add("Maria Santos", "Activity");
            dgvLatestSubmissions.Rows.Add("Carlos Reyes", "Assignment");
            dgvLatestSubmissions.Rows.Add("Jade Isabel Napigkit", "Assignment");
            dgvLatestSubmissions.Rows.Add("Carmina Marie Egipto", "Assignment");
        }

        private void LoadGradingProgress()
        {
            gdvGradingProgress.Rows.Add("Assignment No. 1", "20/52");
            gdvGradingProgress.Rows.Add("Activity No. 1", "15/52");
            gdvGradingProgress.Rows.Add("Assignment No. 2", "10/52");
            gdvGradingProgress.Rows.Add("Activity No. 2", "5/52");

        }

        private void FacultyHomePagePanel_Load(object sender, EventArgs e)
        {
            LoadLatestSubmissions();
            LoadGradingProgress();
        }

        private void dgvLatestSubmissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLatestSubmissions.Columns["dgFacultyLatestSubmissions"].Index && e.RowIndex >= 0)
            {
                FacultyMainForm main = (FacultyMainForm)this.FindForm();
                main.LoadControl(new FacultySubmissionPanel());
            }
        }
    }
}
