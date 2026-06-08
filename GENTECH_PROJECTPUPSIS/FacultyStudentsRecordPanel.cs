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
    public partial class FacultyStudentsRecordPanel : UserControl
    {
        public FacultyStudentsRecordPanel()
        {
            InitializeComponent();
        }

        private void LoadFacultyStudentRecords()
        {
            dgvFacultyStudentRecords.Rows.Add("2026-001", "John Cruz", 95, 88, 90, 92, 89, 91);
            dgvFacultyStudentRecords.Rows.Add("2026-002", "Maria Santos", 90, 85, 87, 88, 86, 89);
            dgvFacultyStudentRecords.Rows.Add("2026-003", "James Reyes", 85, 78, 80, 82, 79, 81);
            dgvFacultyStudentRecords.Rows.Add("2026-004", "Anna Lopez", 98, 92, 94, 96, 93, 95);
            dgvFacultyStudentRecords.Rows.Add("2026-005", "Michael Tan", 80, 70, 72, 75, 73, 74);
            dgvFacultyStudentRecords.Rows.Add("2026-006", "Sophia Garcia", 92, 86, 88, 90, 87, 89);
            dgvFacultyStudentRecords.Rows.Add("2026-007", "Daniel Lim", 88, 80, 82, 84, 81, 83);
            dgvFacultyStudentRecords.Rows.Add("2026-008", "Isabella Ramos", 94, 89, 91, 93, 90, 92);
            dgvFacultyStudentRecords.Rows.Add("2026-009", "Ethan Villanueva", 75, 65, 68, 70, 67, 69);
            dgvFacultyStudentRecords.Rows.Add("2026-010", "Chloe Bautista", 89, 83, 85, 87, 84, 86);
        }
        private void FacultyStudentsRecordPanel_Load(object sender, EventArgs e)
        {
            LoadFacultyStudentRecords();
        }
    }
}
