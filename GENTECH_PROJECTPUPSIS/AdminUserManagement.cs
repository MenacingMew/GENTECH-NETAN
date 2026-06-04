using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminUserManagement : UserControl
    {
        public AdminUserManagement()
        {
            InitializeComponent();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminUserManagement_Load(object sender, EventArgs e)
        {

            DummiesBasicToKungfu("John Doe", "Student", "john.doe@example.com", "Passed");
            DummiesBasicToKungfu("Jane Smith", "Student", "jane.smith@example.com", "Passed");
            DummiesBasicToKungfu("Michael Johnson", "Student", "michael.johnson@example.com", "Failed");
            DummiesBasicToKungfu("Emily Davis", "Student", "emily.davis@example.com", "Passed");
            DummiesBasicToKungfu("Chris Wilson", "Student", "chris.wilson@example.com", "Passed");
            DummiesBasicToKungfu("Sarah Brown", "Student", "sarah.brown@example.com", "Failed");
            DummiesBasicToKungfu("David Martinez", "Student", "david.martinez@example.com", "Passed");
            DummiesBasicToKungfu("Ashley Garcia", "Student", "ashley.garcia@example.com", "Passed");
            DummiesBasicToKungfu("Daniel Anderson", "Student", "daniel.anderson@example.com", "Failed");
            DummiesBasicToKungfu("Sophia Taylor", "Student", "sophia.taylor@example.com", "Passed");
            DummiesBasicToKungfu("James Carter", "Faculty", "james.carter@example.com", "Passed");
            DummiesBasicToKungfu("Emily Johnson", "Faculty", "emily.johnson@example.com", "Passed");
            DummiesBasicToKungfu("Michael Smith", "Faculty", "michael.smith@example.com", "Passed");
            DummiesBasicToKungfu("Olivia Brown", "Faculty", "olivia.brown@example.com", "Passed");
            DummiesBasicToKungfu("Daniel Wilson", "Faculty", "daniel.wilson@example.com", "Passed");
            DummiesBasicToKungfu("Sophia Martinez", "Faculty", "sophia.martinez@example.com", "Passed");
            DummiesBasicToKungfu("Ethan Davis", "Faculty", "ethan.davis@example.com", "Passed");
            DummiesBasicToKungfu("Isabella Garcia", "Faculty", "isabella.garcia@example.com", "Passed");
            DummiesBasicToKungfu("Liam Anderson", "Faculty", "liam.anderson@example.com", "Passed");
            DummiesBasicToKungfu("Ava Thomas", "Faculty", "ava.thomas@example.com", "Passed");
            txtSearchName.StateCommon.Content.Color1 = Color.Black;
            dvgEnrollees.Sort(dvgEnrollees.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            cmbRole.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }
        private void DummiesBasicToKungfu(string Name, string Role, string Email, string Status)
        {
            int index = dvgEnrollees.Rows.Add();
            DataGridViewRow row = dvgEnrollees.Rows[index];

            row.Cells[0].Value = Name;
            row.Cells[1].Value = Role;
            row.Cells[2].Value = Email;
            row.Cells[3].Value = Status;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV File (*.csv)|*.csv";

            if (cmbRole.SelectedItem.ToString() != "All")
            {
                saveFileDialog.FileName = $"{cmbRole.SelectedItem}_Passed.csv";
            }
            else
            {
                //Can't export when role is all, because it will include both faculty and students
                MessageBox.Show("Please select a specific role (Student or Faculty) to export.",
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }



            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csv = new StringBuilder();

                // Column Headers
                csv.AppendLine("Name,Role,Email,Status");

                // Loop through DataGridView rows
                foreach (DataGridViewRow row in dvgEnrollees.Rows)
                {
                    // Skip empty row
                    if (row.IsNewRow)
                        continue;

                    string status = row.Cells["Status"].Value?.ToString();

                    // Export only passed students
                    if (status == "Passed")
                    {
                        string name = row.Cells[0].Value?.ToString();
                        string role = row.Cells[1].Value?.ToString();
                        string email = row.Cells[2].Value?.ToString();

                        csv.AppendLine($"{name},{role},{email},{status}");
                    }
                }

                // Save CSV File
                File.WriteAllText(saveFileDialog.FileName, csv.ToString());

                MessageBox.Show("Passed students exported successfully!",
                                "Export Complete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

        }
        private void FilterData()
        {
            string selectedStatus = cmbStatus.Text;
            string selectedRole = cmbRole.Text;
            string searchText = txtSearchName.Text.ToLower();

            foreach (DataGridViewRow row in dvgEnrollees.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string role = row.Cells[1].Value?.ToString() ?? "";
                string name = row.Cells[0].Value?.ToString() ?? "";
                string status = row.Cells[3].Value?.ToString() ?? "";

                bool statusMatch =
                    selectedStatus == "All" || status == selectedStatus;

                bool roleMatch =
                    selectedRole == "All" || role == selectedRole;

                bool searchMatch =
                    name.ToLower().Contains(searchText);

                row.Visible = statusMatch && roleMatch && searchMatch;
            }
        }



        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Search by name...")
                return;
            FilterData();
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && txt.Text == "Search by name...")
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "Search by name...";
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }
    }
}
