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
    public partial class EnrollmentGrades : UserControl
    {
        public EnrollmentGrades()
        {
            InitializeComponent();

            DummiesBasicToKungfu("COMP 009", "Object Oriented Programming", 3.0, "HERMOGENES, JAYSON", 5.0, "Failed");
            DummiesBasicToKungfu("COMP 010", "Information Management", 3.0, "BANTOG, JAREV", 5.0, "Failed");
            DummiesBasicToKungfu("COMP 012", "Network Administration", 3.0, "MENDOZA, JOHN SIMON", 5.0, "Failed");
            DummiesBasicToKungfu("COMP 013", "Human Computer Interaction", 3.0, "ASISTIN, BRYAN LAWRENCE", 5.0, "Failed");
            DummiesBasicToKungfu("COMP 014", "Quantitative Methods with Modeling and Simulation", 3.0, "MENDOZA, JOHN SIMON", 5.0, "Failed");
            DummiesBasicToKungfu("ELEC IT-FE2", "BSIT Free Elective 2", 3.0, "PASCUAL, MARK JONATHAN", 5.0, "Failed");
            DummiesBasicToKungfu("INTE 202", "Integrative Programming and Technologies 1", 3.0, "SARMIENTO, PHILIP LORENZ", 5.0, "INC");
            DummiesBasicToKungfu("PATHFIT 4", "Physical Activity Towards Health and Fitness 4", 2.0, "MIRANDA JR., MANUEL", 1.0, "Passed");

        }

        private void DummiesBasicToKungfu(string code, string description, double units, string faculty, double grades, string stat)
        {
            int index = kryptonDataGridView2.Rows.Add();
            DataGridViewRow row = kryptonDataGridView2.Rows[index];
            
            row.Cells[0].Value = code;
            row.Cells[1].Value = description;
            row.Cells[2].Value = units;
            row.Cells[3].Value = faculty;
            row.Cells[4].Value = grades;
            row.Cells[5].Value = stat;

        }


    }
}
