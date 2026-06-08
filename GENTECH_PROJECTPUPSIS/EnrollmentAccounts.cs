using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector; // Using ONLY this to prevent compiler conflicts
using QRCoder;
using QRCoderQRCode = QRCoder.QRCode;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentAccounts : UserControl
    {
        private string pickedMethod = "";

        public EnrollmentAccounts()
        {
            InitializeComponent();
        }

        private void EnrollmentAccounts_Load(object sender, EventArgs e)
        {
            LoadStatementOfAccount();
        }

        private void LoadStatementOfAccount()
        {
            try
            {
                // Using centralized DbConnection instead of raw string
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    int studentId = UserSession.EnrollmentStudentID ?? 0;
                    string currentSemester = GetCurrentSemester();
                    string currentAcademicYear = GetCurrentAcademicYear();

                    string query = @"SELECT 
                                        soa.Tuition_Fee,
                                        soa.Miscellaneous_Fee,
                                        soa.Registration_Fee,
                                        soa.Laboratory_Fee,
                                        soa.Total_Amount_Due,
                                        sem.Semester_Name,
                                        sem.Academic_Year
                                    FROM statement_of_account soa
                                    JOIN semester sem ON soa.Semester_ID = sem.Semester_ID
                                    WHERE soa.Student_ID = @studentId
                                    AND sem.Semester_Name = @semester
                                    AND sem.Academic_Year = @academicYear
                                    ORDER BY soa.Statement_Of_Account_ID DESC
                                    LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@semester", currentSemester);
                        cmd.Parameters.AddWithValue("@academicYear", currentAcademicYear);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal tuition = Convert.ToDecimal(reader["Tuition_Fee"]);
                                decimal misc = Convert.ToDecimal(reader["Miscellaneous_Fee"]);
                                decimal registration = Convert.ToDecimal(reader["Registration_Fee"]);
                                decimal lab = Convert.ToDecimal(reader["Laboratory_Fee"]);
                                decimal totalDue = Convert.ToDecimal(reader["Total_Amount_Due"]);

                                if (totalDue == 0)
                                {
                                    lbl_misc.Text = "No fees to display";
                                    lbl_totalAmount.Text = "Covered by Free Higher Education Act";
                                    btnProceed.Visible = false;
                                    kryptonPanel2.Visible = false;
                                }
                                else
                                {
                                    lbl_misc.Text = $"Tuition Fee: ₱{tuition:N2}\n\n" +
                                                   $"Miscellaneous Fee: ₱{misc:N2}\n\n" +
                                                   $"Registration Fee: ₱{registration:N2}\n\n" +
                                                   $"Laboratory Fee: ₱{lab:N2}";
                                    lbl_totalAmount.Text = $"Total Amount Due: ₱{totalDue:N2}";
                                    btnProceed.Visible = true;
                                    kryptonPanel2.Visible = true;
                                }
                            }
                            else
                            {
                                lbl_misc.Text = "No statement of account found";
                                lbl_totalAmount.Text = "₱0.00";
                                btnProceed.Visible = false;
                                kryptonPanel2.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading account: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCurrentSemester()
        {
            int month = DateTime.Now.Month;
            if (month >= 8 && month <= 12)
                return "1st Semester";
            else if (month >= 1 && month <= 5)
                return "2nd Semester";
            else
                return "Summer";
        }

        private string GetCurrentAcademicYear()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month >= 6)
                return $"{year}-{year + 1}";
            else
                return $"{year - 1}-{year}";
        }

        private void btnGCash_Click(object sender, EventArgs e)
        {
            if (pickedMethod == "GCash")
            {
                pickedMethod = "";
                btnGCash.BackColor = Color.Transparent;
                btnGCash.FlatAppearance.BorderColor = Color.White;

                if (btnOverTheCounter != null)
                {
                    btnOverTheCounter.StateCommon.Back.Color1 = Color.White;
                    btnOverTheCounter.StateCommon.Back.Color2 = Color.White;
                    btnOverTheCounter.OverrideDefault.Back.Color1 = Color.White;
                }
            }
            else
            {
                pickedMethod = "GCash";
                btnGCash.BackColor = Color.FromArgb(0, 120, 215);
                btnGCash.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);

                if (btnOverTheCounter != null)
                {
                    btnOverTheCounter.StateCommon.Back.Color1 = Color.White;
                    btnOverTheCounter.StateCommon.Back.Color2 = Color.White;
                    btnOverTheCounter.OverrideDefault.Back.Color1 = Color.White;
                }
            }
        }

        private void btnOverTheCounter_Click(object sender, EventArgs e)
        {
            if (pickedMethod == "Over-the-Counter")
            {
                pickedMethod = "";
                btnOverTheCounter.StateCommon.Back.Color1 = Color.White;
                btnOverTheCounter.StateCommon.Back.Color2 = Color.White;
                btnOverTheCounter.OverrideDefault.Back.Color1 = Color.White;

                btnGCash.BackColor = Color.Transparent;
                btnGCash.FlatAppearance.BorderColor = Color.White;
            }
            else
            {
                pickedMethod = "Over-the-Counter";
                btnOverTheCounter.StateCommon.Back.Color1 = Color.FromArgb(0, 120, 215);
                btnOverTheCounter.StateCommon.Back.Color2 = Color.FromArgb(0, 120, 215);
                btnOverTheCounter.OverrideDefault.Back.Color1 = Color.FromArgb(0, 120, 215);
                btnGCash.BackColor = Color.Transparent;
                btnGCash.FlatAppearance.BorderColor = Color.White;
            }
        }

        private async void btnProceed_Click(object sender, EventArgs e)
        {
            decimal totalAmount = GetTotalAmountFromSOA();

            if (totalAmount <= 0)
            {
                MessageBox.Show("No payment amount due. Your fees are covered by the Free Higher Education Act.",
                    "No Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(pickedMethod))
            {
                MessageBox.Show("Please select a payment method first (GCash or Over-the-Counter).",
                    "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnProceed.Enabled = false; // Disable button immediately to prevent double submission

            if (pickedMethod == "GCash")
            {
                DialogResult confirm = MessageBox.Show(
                    $"Proceed to GCash payment?\n\nAmount Due: ₱{totalAmount:N2}\n\nClick YES to continue.",
                    "Confirm GCash Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    await ProcessGCashPaymentAsync(totalAmount);
                }
            }
            else if (pickedMethod == "Over-the-Counter")
            {
                // Correctly awaiting the renamed safe async Task method
                await ProcessOverTheCounterPaymentAsync(totalAmount);
            }

            btnProceed.Enabled = true;
        }

        private decimal GetTotalAmountFromSOA()
        {
            try
            {
                string totalText = lbl_totalAmount.Text;

                if (string.IsNullOrEmpty(totalText) || totalText == "₱0.00")
                    return 0;

                string amountPart = totalText.Replace("Total Amount Due:", "")
                                             .Replace("₱", "")
                                             .Replace(",", "")
                                             .Trim();

                if (decimal.TryParse(amountPart, out decimal amount))
                    return amount;

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private async Task ProcessGCashPaymentAsync(decimal amount)
        {
            try
            {
                string transactionId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                string referenceNumber = $"GCASH-{DateTime.Now:yyyyMMddHHmmss}-{transactionId}";

                bool paymentCompleted = await ShowGCashQRPayment(amount, referenceNumber);

                if (paymentCompleted)
                {
                    bool recorded = await RecordPayment("GCash", amount, referenceNumber, "Completed");

                    if (recorded)
                    {
                        MessageBox.Show(
                            $"✓ Payment Successful!\n\n" +
                            $"Amount: ₱{amount:N2}\n" +
                            $"Reference: {referenceNumber}\n" +
                            $"Time: {DateTime.Now:hh:mm:ss tt}\n\n" +
                            $"Your payment has been recorded.",
                            "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadStatementOfAccount();
                    }
                    else
                    {
                        MessageBox.Show("Payment was processed but failed to record. Please contact support.",
                            "Recording Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Payment was cancelled or not completed.",
                        "Payment Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GCash payment error: {ex.Message}",
                    "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fixed: Changed from async void to async Task to allow safe execution flows
        private async Task ProcessOverTheCounterPaymentAsync(decimal amount)
        {
            string referenceNumber = GenerateOTCReferenceNumber();

            await RecordOverTheCounterPayment(amount, referenceNumber);

            string paymentInstructions =
                "═══════════════════════════════════════\n" +
                "    OVER-THE-COUNTER PAYMENT INSTRUCTIONS\n" +
                "═══════════════════════════════════════\n\n" +
                $"1. Go to the PUPSMB Registrar\n" +
                $"2. Provide your Reference Number: {referenceNumber}\n" +
                $"3. Pay amount: ₱{amount:N2}\n" +
                $"4. Keep the receipt as proof of payment\n\n" +
                "═══════════════════════════════════════\n" +
                "IMPORTANT REMINDERS:\n" +
                "• Payment will be verified within 24-48 hours\n" +
                "• You will receive a confirmation once verified\n" +
                "• Please keep your reference number for tracking\n" +
                "• Your balance will be updated after verification\n" +
                "═══════════════════════════════════════";

            DialogResult result = MessageBox.Show(
                paymentInstructions + "\n\n[TEST MODE] Simulate payment verification?",
                "Over-the-Counter Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await SimulatePaymentVerification(referenceNumber, amount);
            }
            else
            {
                MessageBox.Show(
                    "Thank you! Please complete your payment at the registrar.\n\n" +
                    $"Reference Number: {referenceNumber}",
                    "Payment Initiated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task SimulatePaymentVerification(string referenceNumber, decimal amount)
        {
            MessageBox.Show("Verifying payment... Please wait.", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await Task.Delay(2000); // Simulate processing delay

            bool verified = await VerifyAndCompletePayment(referenceNumber, amount);

            if (verified)
            {
                MessageBox.Show(
                    "✓ PAYMENT VERIFIED SUCCESSFULLY! (SIMULATION)\n\n" +
                    $"Amount: ₱{amount:N2}\n" +
                    $"Reference: {referenceNumber}\n\n" +
                    "Your balance has been updated.",
                    "Payment Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStatementOfAccount();
            }
        }

        private async Task<bool> VerifyAndCompletePayment(string referenceNumber, decimal amount)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    await conn.OpenAsync();

                    using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                    {
                        try
                        {
                            string selectQuery = @"SELECT p.Payment_ID, p.Statement_Of_Account_ID, soa.Total_Amount_Due as CurrentBalance
                                                  FROM payment p
                                                  JOIN statement_of_account soa ON p.Statement_Of_Account_ID = soa.Statement_Of_Account_ID
                                                  WHERE p.Reference_Number = @refNo 
                                                  AND p.Payment_Status = 'Pending'
                                                  ORDER BY p.Payment_ID DESC LIMIT 1";

                            int paymentId = 0;
                            int statementOfAccountId = 0;
                            decimal currentBalance = 0;

                            using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@refNo", referenceNumber);

                                using (var reader = await cmd.ExecuteReaderAsync())
                                {
                                    if (await reader.ReadAsync())
                                    {
                                        paymentId = Convert.ToInt32(reader["Payment_ID"]);
                                        statementOfAccountId = Convert.ToInt32(reader["Statement_Of_Account_ID"]);
                                        currentBalance = Convert.ToDecimal(reader["CurrentBalance"]);
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }

                            decimal newBalance = currentBalance - amount;
                            string paymentStatus = newBalance <= 0 ? "Fully Paid" : "Partial";

                            string updatePaymentQuery = @"UPDATE payment 
                                                         SET Payment_Status = @status, 
                                                             Balance_Due = @newBalance
                                                         WHERE Payment_ID = @paymentId";

                            using (MySqlCommand cmd = new MySqlCommand(updatePaymentQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@status", paymentStatus);
                                cmd.Parameters.AddWithValue("@newBalance", newBalance);
                                cmd.Parameters.AddWithValue("@paymentId", paymentId);
                                await cmd.ExecuteNonQueryAsync();
                            }

                            string updateSOAQuery = @"UPDATE statement_of_account 
                                                     SET Total_Amount_Due = @newBalance 
                                                     WHERE Statement_Of_Account_ID = @soaId";

                            using (MySqlCommand cmd = new MySqlCommand(updateSOAQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@newBalance", newBalance);
                                cmd.Parameters.AddWithValue("@soaId", statementOfAccountId);
                                await cmd.ExecuteNonQueryAsync();
                            }

                            await transaction.CommitAsync();
                            return true;
                        }
                        catch
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GenerateOTCReferenceNumber()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = new Random().Next(100000, 999999).ToString();
            string studentCode = (UserSession.EnrollmentStudentID ?? 0).ToString().PadLeft(6, '0');

            return $"OTC-{datePart}-{randomPart}-{studentCode}";
        }

        private async Task RecordOverTheCounterPayment(decimal amount, string referenceNumber)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    await conn.OpenAsync();

                    int statementOfAccountId = await GetCurrentStatementOfAccountId(conn, null);

                    if (statementOfAccountId == 0)
                    {
                        MessageBox.Show("No statement of account found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal currentBalance = await GetCurrentBalanceDue(conn, null, statementOfAccountId);

                    string insertQuery = @"INSERT INTO payment 
                                            (Statement_Of_Account_ID, Student_ID, Payment_Date, 
                                             Payment_Method, Amount_Paid, Payment_Status, Balance_Due, Reference_Number)
                                            VALUES 
                                            (@statementOfAccountId, @studentId, @paymentDate, 
                                             @paymentMethod, @amountPaid, @paymentStatus, @balanceDue, @referenceNumber)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@statementOfAccountId", statementOfAccountId);
                        cmd.Parameters.AddWithValue("@studentId", UserSession.EnrollmentStudentID ?? 0);
                        cmd.Parameters.AddWithValue("@paymentDate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@paymentMethod", "Over-the-Counter");
                        cmd.Parameters.AddWithValue("@amountPaid", amount);
                        cmd.Parameters.AddWithValue("@paymentStatus", "Pending");
                        cmd.Parameters.AddWithValue("@balanceDue", currentBalance);
                        cmd.Parameters.AddWithValue("@referenceNumber", referenceNumber);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording OTC payment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> RecordPayment(string paymentMethod, decimal amount, string referenceNumber, string status)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    await conn.OpenAsync();

                    using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                    {
                        try
                        {
                            int statementOfAccountId = await GetCurrentStatementOfAccountId(conn, transaction);

                            if (statementOfAccountId == 0)
                            {
                                MessageBox.Show("No statement of account found for current semester.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            decimal currentBalance = await GetCurrentBalanceDue(conn, transaction, statementOfAccountId);

                            if (currentBalance <= 0)
                            {
                                MessageBox.Show("No outstanding balance to pay.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                            decimal newBalance = currentBalance - amount;
                            string paymentStatus = newBalance <= 0 ? "Fully Paid" : "Partial";

                            string insertQuery = @"INSERT INTO payment 
                                                    (Statement_Of_Account_ID, Student_ID, Payment_Date, 
                                                     Payment_Method, Amount_Paid, Payment_Status, Balance_Due, Reference_Number)
                                                    VALUES 
                                                    (@statementOfAccountId, @studentId, @paymentDate, 
                                                     @paymentMethod, @amountPaid, @paymentStatus, @balanceDue, @referenceNumber)";

                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@statementOfAccountId", statementOfAccountId);
                                cmd.Parameters.AddWithValue("@studentId", UserSession.EnrollmentStudentID ?? 0);
                                cmd.Parameters.AddWithValue("@paymentDate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                                cmd.Parameters.AddWithValue("@amountPaid", amount);
                                cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                                cmd.Parameters.AddWithValue("@balanceDue", newBalance);
                                cmd.Parameters.AddWithValue("@referenceNumber", referenceNumber);

                                int result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    bool updateSuccess = await UpdateStatementOfAccountBalance(conn, transaction, statementOfAccountId, newBalance);

                                    if (updateSuccess)
                                    {
                                        await transaction.CommitAsync();
                                        return true;
                                    }
                                }

                                await transaction.RollbackAsync();
                                return false;
                            }
                        }
                        catch
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording payment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async Task<int> GetCurrentStatementOfAccountId(MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = @"SELECT soa.Statement_Of_Account_ID 
                             FROM statement_of_account soa
                             JOIN semester sem ON soa.Semester_ID = sem.Semester_ID
                             WHERE soa.Student_ID = @studentId
                             AND sem.Semester_Name = @semester
                             AND sem.Academic_Year = @academicYear
                             ORDER BY soa.Statement_Of_Account_ID DESC
                             LIMIT 1";

            string currentSemester = GetCurrentSemester();
            string currentAcademicYear = GetCurrentAcademicYear();

            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@studentId", UserSession.EnrollmentStudentID ?? 0);
                cmd.Parameters.AddWithValue("@semester", currentSemester);
                cmd.Parameters.AddWithValue("@academicYear", currentAcademicYear);

                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private async Task<decimal> GetCurrentBalanceDue(MySqlConnection conn, MySqlTransaction transaction, int statementOfAccountId)
        {
            string query = @"SELECT Total_Amount_Due 
                             FROM statement_of_account 
                             WHERE Statement_Of_Account_ID = @statementOfAccountId";

            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@statementOfAccountId", statementOfAccountId);
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        private async Task<bool> UpdateStatementOfAccountBalance(MySqlConnection conn, MySqlTransaction transaction, int statementOfAccountId, decimal newBalance)
        {
            string query = @"UPDATE statement_of_account 
                             SET Total_Amount_Due = @newBalance 
                             WHERE Statement_Of_Account_ID = @statementOfAccountId";

            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@newBalance", newBalance);
                cmd.Parameters.AddWithValue("@statementOfAccountId", statementOfAccountId);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        // Fixed: Added the missing initialization and layout logic that was truncated
        private async Task<bool> ShowGCashQRPayment(decimal amount, string reference)
        {
            Form qrForm = new Form();
            qrForm.Text = "GCash Payment";
            qrForm.Size = new Size(400, 550);
            qrForm.StartPosition = FormStartPosition.CenterParent;
            qrForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            qrForm.MaximizeBox = false;
            qrForm.MinimizeBox = false;

            string qrPayload = $"GCASH|MERCHANT123|{amount}|{reference}|{DateTime.Now.AddMinutes(15):yyyyMMddHHmmss}";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrPayload, QRCodeGenerator.ECCLevel.Q);
                using (QRCoderQRCode qrCode = new QRCoderQRCode(qrCodeData))
                {
                    Bitmap qrBitmap = qrCode.GetGraphic(20);

                    PictureBox pbQR = new PictureBox()
                    {
                        Image = qrBitmap,
                        Size = new Size(250, 250),
                        Location = new Point(65, 30),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    Label lblInstruction = new Label()
                    {
                        Text = $"1. Open GCash App\n2. Tap 'Pay QR'\n3. Scan this QR code\n4. Pay ₱{amount:N2}",
                        Location = new Point(30, 290),
                        Size = new Size(320, 80),
                        Font = new Font("Segoe UI", 10, FontStyle.Regular)
                    };

                    Label lblReference = new Label()
                    {
                        Text = $"Reference: {reference}",
                        Location = new Point(30, 380),
                        Size = new Size(320, 25),
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    };

                    Button btnClose = new Button()
                    {
                        Text = "I Have Paid",
                        Location = new Point(140, 430),
                        Size = new Size(120, 40),
                        DialogResult = DialogResult.OK
                    };

                    qrForm.Controls.Add(pbQR);
                    qrForm.Controls.Add(lblInstruction);
                    qrForm.Controls.Add(lblReference);
                    qrForm.Controls.Add(btnClose);

                    // If user clicks "I Have Paid" (OK), return true. Otherwise false.
                    return qrForm.ShowDialog(this) == DialogResult.OK;
                }
            }
        }
    }
}