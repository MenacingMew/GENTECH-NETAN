using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentConfirmation : UserControl
    {
        public EnrollmentConfirmation()
        {
            InitializeComponent();
        }



        private void EnrollmentConfirmation_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            dvgEnrollment.Rows.Add(false, "IT101", "Introduction to Computing", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgEnrollment.Rows.Add(false, "CS102", "Programming 1", 3, "TTH • 1:00 PM - 2:30 PM");

            dvgEnrollment.Rows.Add(false, "MATH101", "College Algebra", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgEnrollment.Rows.Add(false, "ENG101", "Purposive Communication", 3, "TTH • 1:00 PM - 2:30 PM");

            dvgEnrollment.Rows.Add(false, "NSTP101", "National Service Training Program", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgEnrollment.Rows.Add(false, "PE101", "Physical Fitness", 2, "TTH • 1:00 PM - 2:30 PM");

            dvgEnrollment.Rows.Add(false, "HIST101", "Readings in Philippine History", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgEnrollment.Rows.Add(false, "SCI101", "General Biology", 3, "TTH • 1:00 PM - 2:30 PM");
        }

        private void UpdateTotals()
        {
            int totalUnits = 0;
            int totalSubjects = 0;

            foreach (DataGridViewRow row in dvgEnrollment.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool isChecked = row.Cells[0].Value != null && (bool)row.Cells[0].Value;

                if (isChecked)
                {
                    totalSubjects++;

                    int units;
                    if (int.TryParse(row.Cells[3].Value?.ToString(), out units))
                    {
                        totalUnits += units;
                    }
                }
            }

            lblTotalSubjects.Text = totalSubjects.ToString();
            lblTotalUnits.Text = totalUnits.ToString();
        }
        private void SetupDataGridView()
        {
            dvgEnrollment.Columns.Clear();

            // =========================================
            // DESIGN
            // =========================================
            dvgEnrollment.AllowUserToAddRows = false;
            dvgEnrollment.RowHeadersVisible = false;
            dvgEnrollment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgEnrollment.MultiSelect = false;
            dvgEnrollment.RowTemplate.Height = 38;
            dvgEnrollment.BorderStyle = BorderStyle.None;
            dvgEnrollment.BackgroundColor = Color.White;
            dvgEnrollment.GridColor = Color.Gainsboro;

            // =========================================
            // HEADER STYLE
            // =========================================
            dvgEnrollment.EnableHeadersVisualStyles = false;
            dvgEnrollment.ColumnHeadersHeight = 42;
            dvgEnrollment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dvgEnrollment.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dvgEnrollment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvgEnrollment.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // =========================================
            // CELL STYLE
            // =========================================
            dvgEnrollment.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dvgEnrollment.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);

            dvgEnrollment.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            // =========================================
            // CHECKBOX COLUMN
            // =========================================
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Width = 50;

            // =========================================
            // SUBJECT CODE
            // =========================================
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.HeaderText = "Subject Code";
            code.Width = 160;

            // =========================================
            // DESCRIPTION
            // =========================================
            DataGridViewTextBoxColumn desc = new DataGridViewTextBoxColumn();
            desc.HeaderText = "Description";
            desc.Width = 280;

            // =========================================
            // UNITS
            // =========================================
            DataGridViewTextBoxColumn units = new DataGridViewTextBoxColumn();
            units.HeaderText = "Units";
            units.Width = 80;

            // =========================================
            // CLEANER COMBOBOX COLUMN
            // =========================================
            DataGridViewComboBoxColumn sched = new DataGridViewComboBoxColumn();

            sched.HeaderText = "Schedules";
            sched.Width = 260;
            sched.FlatStyle = FlatStyle.Flat;

            // Cleaner schedule options
            sched.Items.Add("MWF • 8:00 AM - 9:00 AM");
            sched.Items.Add("TTH • 1:00 PM - 2:30 PM");

            // =========================================
            // ADD COLUMNS
            // =========================================
            dvgEnrollment.Columns.Add(chk);
            dvgEnrollment.Columns.Add(code);
            dvgEnrollment.Columns.Add(desc);
            dvgEnrollment.Columns.Add(units);
            dvgEnrollment.Columns.Add(sched);
        }

        private void dvgEnrollment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotals();
        }

        private void dvgEnrollment_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgEnrollment.IsCurrentCellDirty)
            {
                dvgEnrollment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
            main.LoadControl(new EnrollmentHome());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!cxbConfirm.Checked)
            {
                MessageBox.Show(
                    "Please check the confimation box before you can continue",
                    "Confirmation Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            // Get total units from your label or recompute
            int totalUnits = int.Parse(lblTotalUnits.Text.Replace("Total Units: ", ""));

            // ❗ Check required units first
            if (totalUnits != 23)
            {
                MessageBox.Show(
                    "You must have exactly 23 units to submit your enrollment.",
                    "Invalid Units",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // ✔ Confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to submit your enrollment?",
                "Confirm Enrollment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Proceed with submission
                MessageBox.Show(
                    "Enrollment successfully submitted!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
                main.LoadControl(new EnrollmentHome());
            }
        }
    }
}
