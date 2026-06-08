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
using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminCourseManagement : UserControl
    {
        public AdminCourseManagement()
        {
            InitializeComponent();
        }

        // Connection string can be set by the parent form or read from config key "MySqlConnectionString"
        public string MySqlConnectionString { get; set; } = string.Empty;

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Show the AdminAddCourse user control inside the parent form's panel if available
            try
            {
                AdminAddCourse addCourse = new AdminAddCourse();

                // If this control is hosted inside AdminMainForm, use its LoadControl method
                Form parentForm = this.FindForm();
                if (parentForm is AdminMainForm adminMain)
                {
                    adminMain.LoadControl(addCourse);
                    return;
                }

                // Otherwise, show the AdminAddCourse as a top-level form inside a new Form wrapper
                Form wrapper = new Form();
                wrapper.Text = "Add Course";
                wrapper.StartPosition = FormStartPosition.CenterParent;
                wrapper.Size = new Size(800, 600);
                addCourse.Dock = DockStyle.Fill;
                wrapper.Controls.Add(addCourse);
                wrapper.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Add Course: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminCourseManagement_Load(object sender, EventArgs e)
        {
            // Attempt to load courses from database on control load
            try
            {
                // If not explicitly provided, try to read from config
                if (string.IsNullOrWhiteSpace(MySqlConnectionString))
                {
                    // first try connectionStrings section, then appSettings
                    var cs = ConfigurationManager.ConnectionStrings["MySql"];
                    if (cs != null && !string.IsNullOrWhiteSpace(cs.ConnectionString))
                        MySqlConnectionString = cs.ConnectionString;
                    else
                    {
                        var app = ConfigurationManager.AppSettings["MySqlConnectionString"];
                        if (!string.IsNullOrWhiteSpace(app))
                            MySqlConnectionString = app;
                    }
                }

                if (!string.IsNullOrWhiteSpace(MySqlConnectionString))
                    LoadCoursesFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load courses from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Public helper to refresh grid from database
        public void RefreshCoursesFromDatabase()
        {
            LoadCoursesFromDatabase();
        }

        // Loads course rows from a MySQL database into dgvCourses.
        // Expects a table with columns: course_name, course_code, category, status (adjust query if your schema is different)
        private void LoadCoursesFromDatabase()
        {
            if (string.IsNullOrWhiteSpace(MySqlConnectionString))
            {
                // nothing to do
                return;
            }

            try
            {
                dgvCourses.Rows.Clear();

                using (var conn = new MySqlConnection(MySqlConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    // adjust the table name and column names to match your database schema
                    cmd.CommandText = "SELECT course_name, course_code, category, status FROM courses";
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string name = rdr.IsDBNull(0) ? string.Empty : rdr.GetString(0);
                            string code = rdr.FieldCount > 1 && !rdr.IsDBNull(1) ? rdr.GetString(1) : string.Empty;
                            string category = rdr.FieldCount > 2 && !rdr.IsDBNull(2) ? rdr.GetString(2) : string.Empty;
                            string status = rdr.FieldCount > 3 && !rdr.IsDBNull(3) ? rdr.GetString(3) : string.Empty;

                            // use existing helper to add rows (ensures Action column if present)
                            AddCourse(name, code, category, status);
                        }
                    }
                }

                // remove any accidental duplicates
                DeduplicateExistingRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void DeduplicateExistingRows()
        {
            HashSet<string> seen = new HashSet<string>();
            // iterate from bottom so we keep the first/top-most occurrence
            for (int i = dgvCourses.Rows.Count - 1; i >= 0; i--)
            {
                var row = dgvCourses.Rows[i];
                string code = (row.Cells[1].Value ?? string.Empty).ToString().Trim().ToLower();
                string name = (row.Cells[0].Value ?? string.Empty).ToString().Trim().ToLower();
                string key = !string.IsNullOrEmpty(code) ? code : name;
                if (string.IsNullOrEmpty(key))
                    continue;

                if (seen.Contains(key))
                {
                    dgvCourses.Rows.RemoveAt(i);
                }
                else
                {
                    seen.Add(key);
                }
            }
        }

        private HashSet<string> GetExistingKeys()
        {
            HashSet<string> keys = new HashSet<string>();
            foreach (DataGridViewRow row in dgvCourses.Rows)
            {
                string code = (row.Cells[1].Value ?? string.Empty).ToString().Trim().ToLower();
                string name = (row.Cells[0].Value ?? string.Empty).ToString().Trim().ToLower();
                string key = !string.IsNullOrEmpty(code) ? code : name;
                if (!string.IsNullOrEmpty(key))
                    keys.Add(key);
            }
            return keys;
        }

        // Public helper to expose existing course keys (course code or course name) for other controls
        public HashSet<string> GetExistingCourseKeys()
        {
            return GetExistingKeys();
        }

        // Public helper to add a course row to the grid. Ensures the action column value is set.
        public void AddCourse(string courseName, string courseCode, string category, string status)
        {
            // If the grid has 5 columns (including Action), add the action value
            if (dgvCourses.Columns.Count >= 5)
            {
                dgvCourses.Rows.Add(courseName, courseCode, category, status, "Edit");
            }
            else
            {
                dgvCourses.Rows.Add(courseName, courseCode, category, status);
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Course File";
            ofd.Filter = "CSV Files|*.csv|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string ext = Path.GetExtension(filePath)?.ToLower();
                if (ext != ".csv")
                {
                    MessageBox.Show("Please select a CSV file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Parse CSV into a dictionary so imported rows overwrite earlier ones (prefer imported rows)
                    Dictionary<string, string[]> importMap = new Dictionary<string, string[]>();
                    using (TextFieldParser parser = new TextFieldParser(filePath))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        parser.HasFieldsEnclosedInQuotes = true;

                        while (!parser.EndOfData)
                        {
                            string[] fields = parser.ReadFields();
                            if (fields == null || fields.Length == 0)
                                continue;

                            string courseName = fields.Length > 0 ? fields[0].Trim() : string.Empty;
                            string courseCode = fields.Length > 1 ? fields[1].Trim() : string.Empty;
                            string category = fields.Length > 2 ? fields[2].Trim() : string.Empty;
                            string status = fields.Length > 3 ? fields[3].Trim() : "Active";

                            string key = !string.IsNullOrEmpty(courseCode) ? courseCode.ToLower() : courseName.ToLower();
                            if (string.IsNullOrWhiteSpace(key))
                                continue;

                            // store/overwrite so later rows in the CSV take precedence
                            importMap[key] = new string[] { courseName, courseCode, category, status };
                        }
                    }

                    // For each imported entry, remove any existing rows with the same key (prefer imported rows), then add imported row
                    int added = 0;
                    foreach (var kvp in importMap)
                    {
                        string key = kvp.Key;
                        string courseName = kvp.Value[0];
                        string courseCode = kvp.Value[1];
                        string category = kvp.Value[2];
                        string status = kvp.Value[3];

                        // remove existing rows that match the key
                        for (int i = dgvCourses.Rows.Count - 1; i >= 0; i--)
                        {
                            var row = dgvCourses.Rows[i];
                            string existingCode = (row.Cells[1].Value ?? string.Empty).ToString().Trim().ToLower();
                            string existingName = (row.Cells[0].Value ?? string.Empty).ToString().Trim().ToLower();
                            string existingKey = !string.IsNullOrEmpty(existingCode) ? existingCode : existingName;
                            if (existingKey == key)
                            {
                                dgvCourses.Rows.RemoveAt(i);
                            }
                        }

                        // add the imported row
                        if (dgvCourses.Columns.Count >= 5)
                            dgvCourses.Rows.Add(courseName, courseCode, category, status, "Edit");
                        else
                            dgvCourses.Rows.Add(courseName, courseCode, category, status);

                        added++;
                    }

                    MessageBox.Show($"Import completed. {added} row(s) imported (duplicates replaced by imported rows).", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to import file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
