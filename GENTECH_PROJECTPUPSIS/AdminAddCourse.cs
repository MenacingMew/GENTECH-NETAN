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
    public partial class AdminAddCourse : UserControl
    {
        public AdminAddCourse()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Validate input fields
            string name = txtCourseName.Text?.Trim();
            string code = txtCourseCode.Text?.Trim();
            string category = dgdSemester.Text?.Trim();
            string status = dgdStatus.Text?.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill Course Name, Course Code, Category and Status.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add to this control's dgvCourses
            dgvCourses.Rows.Add(name, code, category, status);

            // Clear inputs for next entry
            txtCourseName.Text = string.Empty;
            txtCourseCode.Text = string.Empty;
            dgdSemester.Text = string.Empty;
            dgdStatus.Text = string.Empty;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            // If there are no rows to transfer, show message
            if (dgvCourses.Rows.Count == 0)
            {
                MessageBox.Show("There are no course(s) to be transferred.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Prepare set of keys from destination if hosted inside AdminMainForm
            Form parentForm = this.FindForm();
            AdminMainForm adminMain = parentForm as AdminMainForm;

            if (adminMain != null)
            {
                // Find the AdminCourseManagement control inside the main form's navigator panel
                // We will create a new AdminCourseManagement instance only if none exists currently
                AdminCourseManagement dest = null;
                foreach (Control c in adminMain.Controls)
                {
                    if (c is AdminCourseManagement)
                    {
                        dest = c as AdminCourseManagement;
                        break;
                    }
                }

                // If not found, try to access via the loaded control in the panel
                if (dest == null)
                {
                    foreach (Control c in adminMain.Controls)
                    {
                        // fallback: nothing
                    }
                }

                // If we still don't have a direct reference, create one but do not replace current UI
                if (dest == null)
                {
                    dest = new AdminCourseManagement();
                }

                // Deduplicate destination first and collect existing keys
                var existing = dest.GetExistingCourseKeys();

                // Transfer rows, skipping duplicates
                int added = 0;
                foreach (DataGridViewRow r in dgvCourses.Rows)
                {
                    string name = (r.Cells[0].Value ?? string.Empty).ToString().Trim();
                    string code = (r.Cells[1].Value ?? string.Empty).ToString().Trim();
                    string category = (r.Cells[2].Value ?? string.Empty).ToString().Trim();
                    string status = (r.Cells[3].Value ?? string.Empty).ToString().Trim();

                    string key = !string.IsNullOrEmpty(code) ? code.ToLower() : name.ToLower();
                    if (string.IsNullOrEmpty(key)) continue;
                    if (existing.Contains(key)) continue;

                    dest.AddCourse(name, code, category, status);
                    existing.Add(key);
                    added++;
                }

                if (added > 0)
                {
                    MessageBox.Show(added + " course(s) transferred.", "Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally, instruct main form to load the course management control so user sees the result
                    adminMain.LoadControl(dest);
                    // Clear local grid after transfer
                    dgvCourses.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("There was no course(s) to be transferred.", "No Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            // If not hosted in AdminMainForm, attempt to locate an open AdminCourseManagement control in parent chain
            Control p = this.Parent;
            AdminCourseManagement found = null;
            while (p != null)
            {
                foreach (Control c in p.Controls)
                {
                    if (c is AdminCourseManagement acm)
                    {
                        found = acm;
                        break;
                    }
                }
                if (found != null) break;
                p = p.Parent;
            }

            if (found != null)
            {
                var existing = found.GetExistingCourseKeys();

                int added = 0;
                foreach (DataGridViewRow r in dgvCourses.Rows)
                {
                    string name = (r.Cells[0].Value ?? string.Empty).ToString().Trim();
                    string code = (r.Cells[1].Value ?? string.Empty).ToString().Trim();
                    string category = (r.Cells[2].Value ?? string.Empty).ToString().Trim();
                    string status = (r.Cells[3].Value ?? string.Empty).ToString().Trim();

                    string key = !string.IsNullOrEmpty(code) ? code.ToLower() : name.ToLower();
                    if (string.IsNullOrEmpty(key)) continue;
                    if (existing.Contains(key)) continue;

                    found.AddCourse(name, code, category, status);
                    existing.Add(key);
                    added++;
                }

                if (added > 0)
                {
                    MessageBox.Show(added + " course(s) transferred.", "Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCourses.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("There was no course(s) to be transferred.", "No Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Unable to locate destination for transfer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
