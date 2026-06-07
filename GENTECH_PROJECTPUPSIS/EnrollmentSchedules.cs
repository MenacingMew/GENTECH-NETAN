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
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentSchedules : UserControl
    {

        public EnrollmentSchedules()
        {
            InitializeComponent();
            BuildCalendarGrid();
            LoadScheduleFromDatabase();
        }

        private KryptonDataGridView dgv;

        private void BuildCalendarGrid()
        {
            this.Size = new Size(1002, 609);

            Label title = new Label
            {
                Text = "CLASS SCHEDULE",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(420, 20)
            };

            this.Controls.Add(title);

            dgv = new KryptonDataGridView
            {
                Location = new Point(40, 70),
                Size = new Size(900, 480),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                ScrollBars = ScrollBars.Both
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            dgv.EnableHeadersVisualStyles = false;

            // Columns (Calendar style)
            dgv.Columns.Add("Time", "Time");
            dgv.Columns.Add("Mon", "Monday");
            dgv.Columns.Add("Tue", "Tuesday");
            dgv.Columns.Add("Wed", "Wednesday");
            dgv.Columns.Add("Thu", "Thursday");
            dgv.Columns.Add("Fri", "Friday");
            dgv.Columns.Add("Sat", "Saturday");

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            GenerateTimeRows();

            this.Controls.Add(dgv);
        }
        private void GenerateTimeRows()
        {
            DateTime start = DateTime.Parse("05:00 AM");

            for (int i = 0; i < 30; i++)
            {
                DateTime end = start.AddMinutes(30);

                dgv.Rows.Add(
                    $"{start:hh:mm tt} - {end:hh:mm tt}",
                    "", "", "", "", "", ""
                );

                start = end;
            }
        }
        private void LoadScheduleFromDatabase()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT 
                Day,
                Start_Time,
                End_Time,
                c.Course_Name,
                CONCAT(f.First_Name, ' ', f.Last_Name) AS Faculty
            FROM schedule s
            LEFT JOIN course c ON s.Course_ID = c.Course_ID
            LEFT JOIN faculty f ON s.Faculty_ID = f.Faculty_ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Skip if start or end time is missing
                            if (reader["Start_Time"] == DBNull.Value || reader["End_Time"] == DBNull.Value)
                                continue;

                            string day = reader["Day"].ToString();
                            int col = GetDayColumn(day);

                            TimeSpan startTime = (TimeSpan)reader["Start_Time"];
                            TimeSpan endTime = (TimeSpan)reader["End_Time"];

                            if (col != -1)
                            {
                                TimeSpan currentSlot = startTime;
                                bool isFirstSlot = true;

                                // Loop through all 30-minute blocks between Start_Time and End_Time
                                while (currentSlot < endTime)
                                {
                                    string timeKey = currentSlot.ToString(@"hh\:mm");
                                    int row = FindRowByTime(timeKey);

                                    if (row != -1)
                                    {
                                        var cell = dgv.Rows[row].Cells[col];

                                        // Only write the course text in the first block to keep it clean
                                        if (isFirstSlot)
                                        {
                                            cell.Value = $"{reader["Course_Name"]}\n{reader["Faculty"]}";
                                            isFirstSlot = false;
                                        }

                                        // Color all blocks the class occupies
                                        cell.Style = new DataGridViewCellStyle
                                        {
                                            Alignment = DataGridViewContentAlignment.MiddleCenter,
                                            Font = new Font("Arial", 9, FontStyle.Bold),
                                            BackColor = Color.LightSkyBlue
                                        };
                                    }

                                    // Advance to the next 30-minute slot
                                    currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Schedule load failed: " + ex.Message);
            }
        }
        private int FindRowByTime(string timeKey)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[0].Value != null)
                {
                    string cell = dgv.Rows[i].Cells[0].Value.ToString();

                    // extract start time from "05:00 AM - 05:30 AM"
                    string rowTime = cell.Split('-')[0].Trim();

                    if (DateTime.TryParse(rowTime, out DateTime parsedRow))
                    {
                        // FIX: Used "HH:mm" to ensure PM times format as 13:00, 14:00, etc.
                        string rowKey = parsedRow.ToString("HH:mm");

                        if (rowKey == timeKey)
                            return i;
                    }
                }
            }
            return -1;
        }

        private int GetDayColumn(string day)
        {
            switch (day.ToLower())
            {
                case "monday": return 1;
                case "tuesday": return 2;
                case "wednesday": return 3;
                case "thursday": return 4;
                case "friday": return 5;
                case "saturday": return 6;
                default: return -1;
            }
        }
        private void ShowEmptyState()
        {
            Label empty = new Label();
            empty.Text = "No schedules available yet";
            empty.Font = new Font("Arial", 12, FontStyle.Italic);
            empty.ForeColor = Color.Gray;
            empty.AutoSize = true;
            empty.Location = new Point(380, 300);

            this.Controls.Add(empty);
        }
        private void EnrollmentSchedules_Load(object sender, EventArgs e)
        {

        }
    }
}

