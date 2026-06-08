using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Drawing2D;
using MySqlConnector;


namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentHome : UserControl
    {

        public EnrollmentHome()
        {
            InitializeComponent();
            this.VisibleChanged += EnrollmentHome_VisibleChanged;
        }
        private void EnrollmentHome_VisibleChanged(object sender, EventArgs e)
        {
            
            RefreshStudentData();
  
        }
        private void RoundedPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void RefreshStudentData()
        {
           
            DisplayStaffInfo();
            LoadEnrollmentStats();  
        }
        private void EnrollmentHome_Load(object sender, EventArgs e)
        {
            kryptonPanel1.Paint += RoundedPanel_Paint;
            kryptonPanel2.Paint += RoundedPanel_Paint;
            kryptonPanel3.Paint += RoundedPanel_Paint;
            DisplayStaffInfo();
            DisplayCurrentDate();
            LoadEnrolledSubjects();
            LoadEnrollmentStats();
            LoadStudentGWA();
        }

        private void DisplayStaffInfo()
        {
            if (!UserSession.IsLoggedIn || !UserSession.IsEnrollmentStaff())
            {
                MessageBox.Show("Session expired. Please login again.",
                    "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ADD NAME DISPLAY
            if (lblEnrollmentName != null)
                lblEnrollmentName.Text = $"Welcome, {UserSession.GetFullName()}!";


            if (lblCourseSection != null)
            {
                string sectionDisplay = UserSession.SectionName ?? UserSession.Section?.ToString() ?? "?";
                lblCourseSection.Text = $"{UserSession.ProgramCode} {UserSession.YearLevel}-{sectionDisplay}";
            }
        }

        private void DisplayCurrentDate()
        {
            // Add date display if needed
        }

        private void LoadEnrolledSubjects()
        {
            if (!UserSession.IsEnrollmentStaff()) return;
            LoadSubjectsFromDatabase(UserSession.EnrollmentStudentID ?? 0);
        }

        private void LoadSubjectsFromDatabase(int studentId)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                        c.Course_Code,
                                        c.Course_Name,
                                        c.Units
                                    FROM enrolled_subjects es
                                    JOIN enrollment e ON es.Enrollment_ID = e.Enrollment_ID
                                    JOIN course c ON es.Course_ID = c.Course_ID
                                    WHERE e.Student_ID = @studentId
                                    ORDER BY c.Course_Code";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dvgEnrolled.Rows.Clear();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string code = reader["Course_Code"].ToString();
                                    string name = reader["Course_Name"].ToString();
                                    int units = Convert.ToInt32(reader["Units"]);

                                    DummiesBasicToKungfu(code, name, units);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentGWA()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;

                    string query = @"SELECT GWA, Remarks
                            FROM grade_overview
                            WHERE Student_ID = @studentId
                            ORDER BY Grade_Overview_ID DESC
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["GWA"] != DBNull.Value)
                            {
                                decimal gwa = Convert.ToDecimal(reader["GWA"]);
                                string remarks = reader["Remarks"]?.ToString() ?? "";

                                lblGWA.Text = $"{gwa:N2}";
                            }
                            else
                            {
                                lblGWA.Text = "N/A";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading GWA: {ex.Message}");
                lblGWA.Text = "Error";
            }
        }

        private void LoadEnrollmentStats()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;

                    string query = @"SELECT soa.Total_Amount_Due, sem.Semester_Name, sem.Academic_Year
                                    FROM statement_of_account soa
                                    JOIN semester sem ON soa.Semester_ID = sem.Semester_ID
                                    WHERE soa.Student_ID = @studentId
                                    ORDER BY soa.Statement_Of_Account_ID DESC
                                    LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal totalDue = Convert.ToDecimal(reader["Total_Amount_Due"]);
                                string semester = reader["Semester_Name"].ToString();
                                string academicYear = reader["Academic_Year"].ToString();

                                lblTotalAmount.Text = $"₱{totalDue:N2}";
                                lblSemester.Text = $"A.Y {academicYear} | {semester}";
                            }
                            else
                            {
                                lblTotalAmount.Text = "No SOA";
                            }
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading stats: {ex.Message}");
            }
        }

        private void DummiesBasicToKungfu(string code, string description, int unit)
        {
            int index = dvgEnrolled.Rows.Add();
            DataGridViewRow row = dvgEnrolled.Rows[index];

            row.Cells[0].Value = code;
            row.Cells[1].Value = description;
            row.Cells[2].Value = unit;
        }

 
        private void lblDownload_Click(object sender, EventArgs e)
        {

            if (dvgEnrolled.Rows.Count == 0)
            {
                MessageBox.Show("You have no enrolled subjects. Cannot download COR.",
                    "No Enrolled Subjects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask where to save
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF File|*.pdf";
            save.Title = "Save Certificate of Registration";
            save.FileName = $"COR_{UserSession.EnrollmentStudentID}_{DateTime.Now:yyyyMMdd}.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                GenerateCORPDF(save.FileName);
            }
        }

        private void GenerateCORPDF(string filePath)
        {
            try
            {
                Document doc = new Document(PageSize.LETTER, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Fonts
                BaseFont arial = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(arial, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arial, 11, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font smallFont = new iTextSharp.text.Font(arial, 8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.BOLD);

                // Header
                Paragraph republic = new Paragraph("Republic of the Philippines", titleFont);
                republic.Alignment = Element.ALIGN_CENTER;
                doc.Add(republic);

                Paragraph pup = new Paragraph("POLYTECHNIC UNIVERSITY OF THE PHILIPPINES", headerFont);
                pup.Alignment = Element.ALIGN_CENTER;
                doc.Add(pup);

                Paragraph cor = new Paragraph("CERTIFICATE OF REGISTRATION", titleFont);
                cor.Alignment = Element.ALIGN_CENTER;
                doc.Add(cor);

                doc.Add(new Paragraph(" ")); // Spacer

                // Student Info
                string studentName = UserSession.GetFullName().ToUpper();
                string studentId = UserSession.FormattedID ?? UserSession.EnrollmentStudentID?.ToString() ?? "";
                string programDesc = $"{UserSession.ProgramName}";
                string programCode = UserSession.ProgramCode ?? "";
                string yearLevel = UserSession.YearLevel?.ToString() ?? "";
                string section = UserSession.Section?.ToString() ?? "";
                string address = "Address Here"; // Add from database if available
                string contactNo = UserSession.ContactNumber ?? "";

                Paragraph studentInfo = new Paragraph();
                studentInfo.Add(new Chunk($"{studentName}\n", boldFont));
                studentInfo.Add(new Chunk($"{studentId}  A.Y.: 2024-2025  TERM: 1st Semester\n", normalFont));
                studentInfo.Add(new Chunk($"PROGRAM DESCRIPTION: {programDesc}  PROGRAM CODE: {programCode}\n", normalFont));
                studentInfo.Add(new Chunk($"YEAR LEVEL: {yearLevel}  SECTION: {section}\n", normalFont));
                studentInfo.Add(new Chunk($"CONTACT NO: {contactNo}\n", normalFont));
                doc.Add(studentInfo);

                doc.Add(new Paragraph(" ")); // Spacer

                // Table for Subjects
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 2f, 5f, 2f, 2f });

                // Table Headers
                table.AddCell(new PdfPCell(new Phrase("CODE", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("SUBJECT TITLE", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("SECTION", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("UNITS", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Add subjects from DataGridView
                foreach (DataGridViewRow row in dvgEnrolled.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string code = row.Cells[0].Value.ToString();
                        string title = row.Cells[1].Value?.ToString() ?? "";
                        string sec = section;
                        string units = row.Cells[2].Value?.ToString() ?? "";

                        table.AddCell(new PdfPCell(new Phrase(code, normalFont)));
                        table.AddCell(new PdfPCell(new Phrase(title, normalFont)));
                        table.AddCell(new PdfPCell(new Phrase(sec, normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(units, normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    }
                }

                doc.Add(table);

                doc.Add(new Paragraph(" ")); // Spacer

                // Separator
                Paragraph separator = new Paragraph("x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x Nothing Follows x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x - x", smallFont);
                separator.Alignment = Element.ALIGN_CENTER;
                doc.Add(separator);

                // Total Units and Assessment
                int totalUnits = 0;
                foreach (DataGridViewRow row in dvgEnrolled.Rows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        totalUnits += Convert.ToInt32(row.Cells[2].Value);
                    }
                }

                Paragraph totals = new Paragraph();
                totals.Add(new Chunk($"TOTAL UNITS ENROLLED: {totalUnits}\n", boldFont));
                totals.Add(new Chunk($"TOTAL ASSESSMENT: {lblTotalAmount.Text}\n", boldFont));
                doc.Add(totals);

                doc.Add(new Paragraph(" "));
                Paragraph registrar = new Paragraph("REGISTRAR: This is system-generated, signature is not required", smallFont);
                registrar.Alignment = Element.ALIGN_CENTER;
                doc.Add(registrar);

                doc.Close();

                MessageBox.Show("COR PDF saved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEnrollNow_Click(object sender, EventArgs e)
        {
            bool hasPaymentDue = await CheckIfStudentHasPaymentDue();

            if (hasPaymentDue)
            {
                DialogResult result = MessageBox.Show(
                    "You have an outstanding balance. Please settle your payment before enrolling.\n\n" +
                    "Would you like to go to the Accounts section now?",
                    "Payment Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    EnrollmentMainForm main2 = (EnrollmentMainForm)this.FindForm();
                    if (main2 != null)
                    {
                        main2.LoadControl(new EnrollmentAccounts());
                    }
                }
                return;
            }

            // Check if already enrolled
            bool isAlreadyEnrolled = await CheckIfAlreadyEnrolled();

            if (isAlreadyEnrolled)
            {
                MessageBox.Show("You are already enrolled for the current semester.",
                    "Already Enrolled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            EnrollmentMainForm mainForm = (EnrollmentMainForm)this.FindForm();
            if (mainForm != null)
            {
                mainForm.LoadControl(new EnrollmentConfirmation());
            }
        }

        private async Task<bool> CheckIfAlreadyEnrolled()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    await conn.OpenAsync();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;
                    int semesterId = GetCurrentSemesterID();

                    string query = @"SELECT COUNT(*) FROM enrollment 
                            WHERE Student_ID = @studentId 
                            AND Semester_ID = @semesterId 
                            AND Enrollment_Status = 'Enrolled'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semesterId", semesterId);

                        int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking enrollment: {ex.Message}");
                return false;
            }
        }
        private int GetCurrentSemesterID()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    DateTime today = DateTime.Now;

                    
                    string query = @"SELECT Semester_ID 
                            FROM semester 
                            WHERE Start_Date <= @today AND End_Date >= @today
                            ORDER BY Semester_ID DESC 
                            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }

                   
                    string fallbackQuery = "SELECT Semester_ID FROM semester ORDER BY Start_Date DESC LIMIT 1";
                    using (MySqlCommand fallbackCmd = new MySqlCommand(fallbackQuery, conn))
                    {
                        object result = fallbackCmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting semester: {ex.Message}");
            }

            return 1; 
        }

        private async Task<bool> CheckIfStudentHasPaymentDue()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    await conn.OpenAsync();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;
                    int semesterId = GetCurrentSemesterID();

                    string query = @"SELECT Total_Amount_Due FROM statement_of_account 
                            WHERE Student_ID = @studentId 
                            AND Semester_ID = @semesterId
                            ORDER BY Statement_Of_Account_ID DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semesterId", semesterId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal totalDue = Convert.ToDecimal(result);
                            return totalDue > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking payment: {ex.Message}");
                return false;
            }

            return false;
        }

        private string GetCurrentSemester()
        {
            int month = DateTime.Now.Month;
            if (month >= 8 && month <= 12) return "1st Semester";
            else if (month >= 1 && month <= 5) return "2nd Semester";
            else return "Summer";
        }

        private string GetCurrentAcademicYear()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month >= 6) return $"{year}-{year + 1}";
            else return $"{year - 1}-{year}";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EnrollmentHome_Load(sender, e);
        }



    }
}