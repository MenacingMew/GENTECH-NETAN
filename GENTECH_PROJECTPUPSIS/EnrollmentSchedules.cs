using ComponentFactory.Krypton.Toolkit;
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
    public partial class EnrollmentSchedules : UserControl
    {
        public EnrollmentSchedules()
        {
           
            InitializeComponent();
            CreateSchedule();
        }

        private KryptonDataGridView dgv;

        private void CreateSchedule()
        {
            // FORM
            this.Size = new Size(1002, 609);

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = "TIME TABLE SCHEDULE";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(450, 20);
            this.Controls.Add(lblTitle);

            // KRYPTON DATAGRIDVIEW
            dgv = new KryptonDataGridView();

            dgv.Location = new Point(40, 70);
            dgv.Size = new Size(860, 850);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;

            dgv.RowHeadersVisible = false;

            dgv.ColumnCount = 7;

            dgv.Columns[0].Name = "Time";
            dgv.Columns[1].Name = "Monday";
            dgv.Columns[2].Name = "Tuesday";
            dgv.Columns[3].Name = "Wednesday";
            dgv.Columns[4].Name = "Thursday";
            dgv.Columns[5].Name = "Friday";
            dgv.Columns[6].Name = "Saturday";

            // COLUMN WIDTHS
            dgv.Columns[0].Width = 120;

            for (int i = 1; i < 7; i++)
            {
                dgv.Columns[i].Width = 120;
            }

            // HEADER STYLE
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 10, FontStyle.Bold);

            dgv.ColumnHeadersHeight = 40;

            // CREATE TIME ROWS
            DateTime start = DateTime.Parse("5:00 AM");

            for (int i = 0; i < 34; i++)
            {
                DateTime end = start.AddMinutes(30);

                dgv.Rows.Add(
                    $"{start:hh:mm tt} - {end:hh:mm tt}",
                    "", "", "", "", "", ""
                );

                start = end;
            }

            // ROW HEIGHT
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = 45;
            }

            // SAMPLE SUBJECTS
            AddSubject(
                row: 6,
                col: 3,
                text:
                "COMP 012\nNetwork Administration\n\nProf. John Simon Mendoza",
                color: Color.LightBlue
            );

            AddSubject(
                row: 12,
                col: 4,
                text:
                "COMP 009\nObject Oriented Programming\n\nProf. Jayson Hermogenes",
                color: Color.SkyBlue
            );

            AddSubject(
                row: 12,
                col: 6,
                text:
                "COMP 013\nHuman Computer Interaction\n\nProf. Bryan Asistin",
                color: Color.LightPink
            );

            AddSubject(
                row: 10,
                col: 5,
                text:
                "PATHFIT 4\nPhysical Activities Towards Health",
                color: Color.Plum
            );

            AddSubject(
                row: 18,
                col: 1,
                text:
                "COMP 014\nQuantitative Methods with Modeling and Simulation",
                color: Color.MediumTurquoise
            );

            this.Controls.Add(dgv);
        }

        private void AddSubject(
            int row,
            int col,
            string text,
            Color color)
        {
            dgv.Rows[row].Cells[col].Value = text;

            dgv.Rows[row].Cells[col].Style.BackColor = color;

            dgv.Rows[row].Cells[col].Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.Rows[row].Cells[col].Style.Font =
                new Font("Arial", 9, FontStyle.Bold);

            dgv.Rows[row].Height = 120;
        }
    }
}

