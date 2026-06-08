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
    public partial class FacultyResultViewPanel : UserControl
    {
        public FacultyResultViewPanel()
        {
            InitializeComponent();
        }

        private void LoadAssessmentResults()
        {
            dgvAssessmentResult.Rows.Add("John Cruz", "92%", "Excellent Performance", "25 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Maria Santos", "85%", "Good", "28 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("James Reyes", "78%", "Satisfactory", "30 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Anna Lopez", "95%", "Outstanding", "22 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Michael Tan", "67%", "Needs Improvement", "30 mins", "Timeout");
            dgvAssessmentResult.Rows.Add("Sophia Garcia", "88%", "Very Good", "27 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Daniel Lim", "73%", "Fair", "29 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Isabella Ramos", "90%", "Excellent", "26 mins", "Submitted");
            dgvAssessmentResult.Rows.Add("Ethan Villanueva", "60%", "Poor", "30 mins", "Timeout");
            dgvAssessmentResult.Rows.Add("Chloe Bautista", "82%", "Good", "28 mins", "Submitted");
        }

        private void FacultyResultViewPanel_Load(object sender, EventArgs e)
        {
            LoadAssessmentResults();
        }

        private void poisonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
