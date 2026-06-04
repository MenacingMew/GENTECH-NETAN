namespace WindowsFormsApp1
{
    partial class AdminStudentRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hopeRoundButton2 = new ReaLTaiizor.Controls.HopeRoundButton();
            this.btnClearView = new ReaLTaiizor.Controls.HopeRoundButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbFilterFacultyView = new ReaLTaiizor.Controls.PoisonComboBox();
            this.dvgStudentView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgTodaysSchedCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaysSchedClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaySched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnConfirm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRandomized = new ReaLTaiizor.Controls.HopeRoundButton();
            this.btnUploadCSV = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCreateStudent = new ReaLTaiizor.Controls.HopeRoundButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.txtStudentID = new ReaLTaiizor.Controls.SmallTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSex = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.txtEmail = new ReaLTaiizor.Controls.SmallTextBox();
            this.txtSuffix = new ReaLTaiizor.Controls.SmallTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProgram = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSection = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactNo = new ReaLTaiizor.Controls.SmallTextBox();
            this.txtLastName = new ReaLTaiizor.Controls.SmallTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMiddleName = new ReaLTaiizor.Controls.SmallTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFirstName = new ReaLTaiizor.Controls.SmallTextBox();
            this.txtAddress = new ReaLTaiizor.Controls.SmallTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpBirthDay = new ReaLTaiizor.Controls.PoisonDateTime();
            this.label3 = new System.Windows.Forms.Label();
            this.foreverTabPage1 = new ReaLTaiizor.Controls.ForeverTabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.btn_Archive = new ReaLTaiizor.Controls.HopeRoundButton();
            this.edit_btn = new ReaLTaiizor.Controls.HopeRoundButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new ReaLTaiizor.Controls.HopeRoundButton();
            this.label27 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgStudentView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.foreverTabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.hopeRoundButton2);
            this.tabPage2.Controls.Add(this.btnClearView);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.cmbFilterFacultyView);
            this.tabPage2.Controls.Add(this.dvgStudentView);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(994, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Student ";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // hopeRoundButton2
            // 
            this.hopeRoundButton2.BackColor = System.Drawing.Color.Transparent;
            this.hopeRoundButton2.BorderColor = System.Drawing.Color.Transparent;
            this.hopeRoundButton2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeRoundButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeRoundButton2.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeRoundButton2.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeRoundButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeRoundButton2.HoverTextColor = System.Drawing.Color.White;
            this.hopeRoundButton2.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeRoundButton2.Location = new System.Drawing.Point(849, 456);
            this.hopeRoundButton2.Name = "hopeRoundButton2";
            this.hopeRoundButton2.PrimaryColor = System.Drawing.Color.Maroon;
            this.hopeRoundButton2.Size = new System.Drawing.Size(105, 32);
            this.hopeRoundButton2.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeRoundButton2.TabIndex = 126;
            this.hopeRoundButton2.Text = "Back";
            this.hopeRoundButton2.TextColor = System.Drawing.Color.White;
            this.hopeRoundButton2.Visible = false;
            this.hopeRoundButton2.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeRoundButton2.Click += new System.EventHandler(this.hopeRoundButton2_Click);
            // 
            // btnClearView
            // 
            this.btnClearView.BackColor = System.Drawing.Color.Transparent;
            this.btnClearView.BorderColor = System.Drawing.Color.Transparent;
            this.btnClearView.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnClearView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearView.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnClearView.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClearView.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClearView.HoverTextColor = System.Drawing.Color.White;
            this.btnClearView.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnClearView.Location = new System.Drawing.Point(866, 33);
            this.btnClearView.Name = "btnClearView";
            this.btnClearView.PrimaryColor = System.Drawing.Color.Maroon;
            this.btnClearView.Size = new System.Drawing.Size(88, 29);
            this.btnClearView.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnClearView.TabIndex = 125;
            this.btnClearView.Text = "Clear";
            this.btnClearView.TextColor = System.Drawing.Color.White;
            this.btnClearView.Visible = false;
            this.btnClearView.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnClearView.Click += new System.EventHandler(this.btnClearView_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(21, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 361);
            this.panel2.TabIndex = 124;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cmbFilterFacultyView
            // 
            this.cmbFilterFacultyView.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbFilterFacultyView.ForeColor = System.Drawing.Color.LightGray;
            this.cmbFilterFacultyView.FormattingEnabled = true;
            this.cmbFilterFacultyView.ItemHeight = 23;
            this.cmbFilterFacultyView.Items.AddRange(new object[] {
            "All",
            "BSIT",
            "BSCS"});
            this.cmbFilterFacultyView.Location = new System.Drawing.Point(734, 33);
            this.cmbFilterFacultyView.Name = "cmbFilterFacultyView";
            this.cmbFilterFacultyView.PromptText = "Filter By";
            this.cmbFilterFacultyView.Size = new System.Drawing.Size(220, 29);
            this.cmbFilterFacultyView.TabIndex = 123;
            this.cmbFilterFacultyView.Text = "Filter By";
            this.cmbFilterFacultyView.UseSelectable = true;
            this.cmbFilterFacultyView.SelectedIndexChanged += new System.EventHandler(this.cmbFilterFacultyView_SelectedIndexChanged);
            // 
            // dvgStudentView
            // 
            this.dvgStudentView.AllowUserToAddRows = false;
            this.dvgStudentView.AllowUserToDeleteRows = false;
            this.dvgStudentView.AllowUserToResizeColumns = false;
            this.dvgStudentView.AllowUserToResizeRows = false;
            this.dvgStudentView.ColumnHeadersHeight = 45;
            this.dvgStudentView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgTodaysSchedCourse,
            this.dgTodaysSchedClass,
            this.dgTodaySched});
            this.dvgStudentView.Location = new System.Drawing.Point(21, 68);
            this.dvgStudentView.Name = "dvgStudentView";
            this.dvgStudentView.RowHeadersVisible = false;
            this.dvgStudentView.RowTemplate.Height = 40;
            this.dvgStudentView.Size = new System.Drawing.Size(933, 361);
            this.dvgStudentView.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dvgStudentView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dvgStudentView.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dvgStudentView.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgStudentView.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgStudentView.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dvgStudentView.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dvgStudentView.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dvgStudentView.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dvgStudentView.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dvgStudentView.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dvgStudentView.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgStudentView.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgStudentView.TabIndex = 122;
            this.dvgStudentView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgStudentView_CellContentClick);
            // 
            // dgTodaysSchedCourse
            // 
            this.dgTodaysSchedCourse.HeaderText = "Student ID";
            this.dgTodaysSchedCourse.Name = "dgTodaysSchedCourse";
            this.dgTodaysSchedCourse.ReadOnly = true;
            this.dgTodaysSchedCourse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTodaysSchedCourse.Width = 300;
            // 
            // dgTodaysSchedClass
            // 
            this.dgTodaysSchedClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgTodaysSchedClass.HeaderText = "Name";
            this.dgTodaysSchedClass.Name = "dgTodaysSchedClass";
            this.dgTodaysSchedClass.ReadOnly = true;
            this.dgTodaysSchedClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgTodaySched
            // 
            this.dgTodaySched.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgTodaySched.HeaderText = "Program";
            this.dgTodaySched.Name = "dgTodaySched";
            this.dgTodaySched.ReadOnly = true;
            this.dgTodaySched.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.Location = new System.Drawing.Point(16, 17);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 25);
            this.label15.TabIndex = 121;
            this.label15.Text = "View Faculty";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnConfirm);
            this.tabPage1.Controls.Add(this.btnRandomized);
            this.tabPage1.Controls.Add(this.btnUploadCSV);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnCreateStudent);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Student";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(20, 405);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCancel.Size = new System.Drawing.Size(217, 40);
            this.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnCancel.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.btnCancel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateCommon.Border.Rounding = 15;
            this.btnCancel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.StatePressed.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnCancel.StatePressed.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnCancel.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCancel.StateTracking.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnCancel.StateTracking.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnCancel.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.TabIndex = 120;
            this.btnCancel.Values.Text = "Cancel using .csv file";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirm.Location = new System.Drawing.Point(244, 405);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnConfirm.Size = new System.Drawing.Size(187, 40);
            this.btnConfirm.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnConfirm.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnConfirm.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.btnConfirm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnConfirm.StateCommon.Border.Rounding = 15;
            this.btnConfirm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.btnConfirm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConfirm.StatePressed.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnConfirm.StatePressed.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnConfirm.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnConfirm.StateTracking.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnConfirm.StateTracking.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnConfirm.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnConfirm.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConfirm.TabIndex = 119;
            this.btnConfirm.Values.Text = "Confirm using .csv file";
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnRandomized
            // 
            this.btnRandomized.BackColor = System.Drawing.Color.Transparent;
            this.btnRandomized.BorderColor = System.Drawing.Color.Transparent;
            this.btnRandomized.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnRandomized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRandomized.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnRandomized.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRandomized.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRandomized.HoverTextColor = System.Drawing.Color.White;
            this.btnRandomized.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnRandomized.Location = new System.Drawing.Point(20, 405);
            this.btnRandomized.Name = "btnRandomized";
            this.btnRandomized.PrimaryColor = System.Drawing.Color.Maroon;
            this.btnRandomized.Size = new System.Drawing.Size(217, 40);
            this.btnRandomized.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnRandomized.TabIndex = 118;
            this.btnRandomized.Text = "Randomize Student ID";
            this.btnRandomized.TextColor = System.Drawing.Color.White;
            this.btnRandomized.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnRandomized.Click += new System.EventHandler(this.btnRandomized_Click);
            // 
            // btnUploadCSV
            // 
            this.btnUploadCSV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUploadCSV.Location = new System.Drawing.Point(805, 405);
            this.btnUploadCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadCSV.Name = "btnUploadCSV";
            this.btnUploadCSV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnUploadCSV.Size = new System.Drawing.Size(169, 40);
            this.btnUploadCSV.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnUploadCSV.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnUploadCSV.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUploadCSV.StateCommon.Border.Rounding = 15;
            this.btnUploadCSV.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUploadCSV.StatePressed.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StatePressed.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUploadCSV.StateTracking.Back.Color1 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StateTracking.Back.Color2 = System.Drawing.Color.Maroon;
            this.btnUploadCSV.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUploadCSV.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUploadCSV.TabIndex = 117;
            this.btnUploadCSV.Values.Text = "Upload .csv file";
            this.btnUploadCSV.Click += new System.EventHandler(this.btnUploadCSV_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(16, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 25);
            this.label11.TabIndex = 101;
            this.label11.Text = "Create Student";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCreateStudent
            // 
            this.btnCreateStudent.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateStudent.BorderColor = System.Drawing.Color.Transparent;
            this.btnCreateStudent.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnCreateStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateStudent.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnCreateStudent.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCreateStudent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateStudent.HoverTextColor = System.Drawing.Color.White;
            this.btnCreateStudent.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnCreateStudent.Location = new System.Drawing.Point(867, 405);
            this.btnCreateStudent.Name = "btnCreateStudent";
            this.btnCreateStudent.PrimaryColor = System.Drawing.Color.Maroon;
            this.btnCreateStudent.Size = new System.Drawing.Size(107, 40);
            this.btnCreateStudent.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnCreateStudent.TabIndex = 100;
            this.btnCreateStudent.Text = "Create";
            this.btnCreateStudent.TextColor = System.Drawing.Color.White;
            this.btnCreateStudent.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnCreateStudent.Click += new System.EventHandler(this.btnCreateStudent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPreview);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.txtStudentID);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSex);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtSuffix);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbProgram);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContactNo);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtMiddleName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpBirthDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(97, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 266);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            // 
            // dgvPreview
            // 
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(-77, -46);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.Size = new System.Drawing.Size(953, 345);
            this.dgvPreview.TabIndex = 110;
            this.dgvPreview.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.ForeColor = System.Drawing.Color.DarkGray;
            this.label36.Location = new System.Drawing.Point(3, 157);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(718, 21);
            this.label36.TabIndex = 109;
            this.label36.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------";
            // 
            // txtStudentID
            // 
            this.txtStudentID.BackColor = System.Drawing.Color.Transparent;
            this.txtStudentID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtStudentID.CustomBGColor = System.Drawing.Color.White;
            this.txtStudentID.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtStudentID.ForeColor = System.Drawing.Color.DarkGray;
            this.txtStudentID.Location = new System.Drawing.Point(218, 211);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStudentID.MaxLength = 32767;
            this.txtStudentID.Multiline = false;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = false;
            this.txtStudentID.Size = new System.Drawing.Size(148, 29);
            this.txtStudentID.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtStudentID.TabIndex = 83;
            this.txtStudentID.Tag = "Student ID";
            this.txtStudentID.Text = "Student ID";
            this.txtStudentID.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStudentID.UseSystemPasswordChar = false;
            this.txtStudentID.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtStudentID.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(541, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 21);
            this.label14.TabIndex = 108;
            this.label14.Text = "Suffix";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(214, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 92;
            this.label2.Text = "Student ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSex
            // 
            this.cmbSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cmbSex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSex.DropDownHeight = 100;
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSex.ForeColor = System.Drawing.Color.DarkGray;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cmbSex.IntegralHeight = false;
            this.cmbSex.ItemHeight = 20;
            this.cmbSex.Items.AddRange(new object[] {
            "Not Selected",
            "Male",
            "Female"});
            this.cmbSex.Location = new System.Drawing.Point(389, 114);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(132, 26);
            this.cmbSex.StartIndex = 0;
            this.cmbSex.TabIndex = 89;
            this.cmbSex.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEmail.CustomBGColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.DarkGray;
            this.txtEmail.Location = new System.Drawing.Point(17, 211);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(172, 29);
            this.txtEmail.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtEmail.TabIndex = 86;
            this.txtEmail.Tag = "Email";
            this.txtEmail.Text = "Email";
            this.txtEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtSuffix
            // 
            this.txtSuffix.BackColor = System.Drawing.Color.Transparent;
            this.txtSuffix.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSuffix.CustomBGColor = System.Drawing.Color.White;
            this.txtSuffix.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtSuffix.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSuffix.Location = new System.Drawing.Point(545, 49);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSuffix.MaxLength = 32767;
            this.txtSuffix.Multiline = false;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.ReadOnly = false;
            this.txtSuffix.Size = new System.Drawing.Size(148, 29);
            this.txtSuffix.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtSuffix.TabIndex = 107;
            this.txtSuffix.Tag = "Jr., Sr., III";
            this.txtSuffix.Text = "Jr., Sr., I, III";
            this.txtSuffix.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSuffix.UseSystemPasswordChar = false;
            this.txtSuffix.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtSuffix.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(13, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 21);
            this.label7.TabIndex = 97;
            this.label7.Text = "Email";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(557, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 21);
            this.label5.TabIndex = 95;
            this.label5.Text = "Section";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(540, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 21);
            this.label9.TabIndex = 99;
            this.label9.Text = "Contact No.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProgram
            // 
            this.cmbProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cmbProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbProgram.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProgram.DropDownHeight = 100;
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProgram.ForeColor = System.Drawing.Color.DarkGray;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cmbProgram.IntegralHeight = false;
            this.cmbProgram.ItemHeight = 20;
            this.cmbProgram.Items.AddRange(new object[] {
            "Not Selected",
            "BSIT",
            "HM",
            "BSCPE"});
            this.cmbProgram.Location = new System.Drawing.Point(372, 214);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(183, 26);
            this.cmbProgram.StartIndex = 0;
            this.cmbProgram.TabIndex = 87;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(235, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 21);
            this.label6.TabIndex = 96;
            this.label6.Text = "Address";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSection
            // 
            this.cmbSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cmbSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSection.DropDownHeight = 100;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSection.ForeColor = System.Drawing.Color.DarkGray;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cmbSection.IntegralHeight = false;
            this.cmbSection.ItemHeight = 20;
            this.cmbSection.Items.AddRange(new object[] {
            "Not Selected",
            "1-1",
            "1-2"});
            this.cmbSection.Location = new System.Drawing.Point(561, 214);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(132, 26);
            this.cmbSection.StartIndex = 0;
            this.cmbSection.TabIndex = 88;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(369, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 21);
            this.label13.TabIndex = 106;
            this.label13.Text = "Last Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(368, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 94;
            this.label1.Text = "Program";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.Transparent;
            this.txtContactNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtContactNo.CustomBGColor = System.Drawing.Color.White;
            this.txtContactNo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtContactNo.ForeColor = System.Drawing.Color.DarkGray;
            this.txtContactNo.Location = new System.Drawing.Point(544, 113);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContactNo.MaxLength = 32767;
            this.txtContactNo.Multiline = false;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.ReadOnly = false;
            this.txtContactNo.Size = new System.Drawing.Size(132, 29);
            this.txtContactNo.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtContactNo.TabIndex = 85;
            this.txtContactNo.Tag = "Contact No.";
            this.txtContactNo.Text = "Contact No.";
            this.txtContactNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContactNo.UseSystemPasswordChar = false;
            this.txtContactNo.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtContactNo.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtLastName.CustomBGColor = System.Drawing.Color.White;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtLastName.ForeColor = System.Drawing.Color.DarkGray;
            this.txtLastName.Location = new System.Drawing.Point(373, 49);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.MaxLength = 32767;
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = false;
            this.txtLastName.Size = new System.Drawing.Size(148, 29);
            this.txtLastName.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtLastName.TabIndex = 105;
            this.txtLastName.Tag = "Last Name";
            this.txtLastName.Text = "Last Name";
            this.txtLastName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLastName.UseSystemPasswordChar = false;
            this.txtLastName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(191, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 21);
            this.label12.TabIndex = 104;
            this.label12.Text = "Middle Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.Transparent;
            this.txtMiddleName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMiddleName.CustomBGColor = System.Drawing.Color.White;
            this.txtMiddleName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtMiddleName.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMiddleName.Location = new System.Drawing.Point(195, 48);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiddleName.MaxLength = 32767;
            this.txtMiddleName.Multiline = false;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.ReadOnly = false;
            this.txtMiddleName.Size = new System.Drawing.Size(148, 29);
            this.txtMiddleName.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtMiddleName.TabIndex = 103;
            this.txtMiddleName.Tag = "Middle Name";
            this.txtMiddleName.Text = "Middle Name";
            this.txtMiddleName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMiddleName.UseSystemPasswordChar = false;
            this.txtMiddleName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtMiddleName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(13, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 21);
            this.label10.TabIndex = 91;
            this.label10.Text = "First Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtFirstName.CustomBGColor = System.Drawing.Color.White;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFirstName.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.Location = new System.Drawing.Point(17, 49);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.MaxLength = 32767;
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = false;
            this.txtFirstName.Size = new System.Drawing.Size(148, 29);
            this.txtFirstName.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtFirstName.TabIndex = 82;
            this.txtFirstName.Tag = "First Name";
            this.txtFirstName.Text = "First Name";
            this.txtFirstName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFirstName.UseSystemPasswordChar = false;
            this.txtFirstName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtAddress.CustomBGColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtAddress.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAddress.Location = new System.Drawing.Point(234, 114);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = false;
            this.txtAddress.Size = new System.Drawing.Size(132, 29);
            this.txtAddress.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtAddress.TabIndex = 84;
            this.txtAddress.Tag = "Address";
            this.txtAddress.Text = "Address";
            this.txtAddress.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAddress.UseSystemPasswordChar = false;
            this.txtAddress.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtAddress.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(380, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 21);
            this.label8.TabIndex = 98;
            this.label8.Text = "Sex";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Small;
            this.dtpBirthDay.Location = new System.Drawing.Point(17, 114);
            this.dtpBirthDay.MinimumSize = new System.Drawing.Size(4, 25);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(193, 29);
            this.dtpBirthDay.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 93;
            this.label3.Text = "Birthday";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // foreverTabPage1
            // 
            this.foreverTabPage1.ActiveColor = System.Drawing.Color.Maroon;
            this.foreverTabPage1.ActiveFontColor = System.Drawing.Color.White;
            this.foreverTabPage1.BaseColor = System.Drawing.SystemColors.Control;
            this.foreverTabPage1.BGColor = System.Drawing.Color.White;
            this.foreverTabPage1.Controls.Add(this.tabPage1);
            this.foreverTabPage1.Controls.Add(this.tabPage2);
            this.foreverTabPage1.Controls.Add(this.tabPage4);
            this.foreverTabPage1.DeactiveFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.foreverTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foreverTabPage1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverTabPage1.ItemSize = new System.Drawing.Size(120, 40);
            this.foreverTabPage1.Location = new System.Drawing.Point(0, 60);
            this.foreverTabPage1.Name = "foreverTabPage1";
            this.foreverTabPage1.SelectedIndex = 0;
            this.foreverTabPage1.Size = new System.Drawing.Size(1002, 549);
            this.foreverTabPage1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.foreverTabPage1.TabIndex = 90;
            this.foreverTabPage1.SelectedIndexChanged += new System.EventHandler(this.foreverTabPage1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.hopeRoundButton1);
            this.tabPage4.Controls.Add(this.poisonComboBox1);
            this.tabPage4.Controls.Add(this.btn_Archive);
            this.tabPage4.Controls.Add(this.edit_btn);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.kryptonDataGridView1);
            this.tabPage4.Controls.Add(this.btnBack);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(994, 501);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Modify Student";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // hopeRoundButton1
            // 
            this.hopeRoundButton1.BackColor = System.Drawing.Color.Transparent;
            this.hopeRoundButton1.BorderColor = System.Drawing.Color.Transparent;
            this.hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeRoundButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeRoundButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeRoundButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeRoundButton1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.hopeRoundButton1.HoverTextColor = System.Drawing.Color.White;
            this.hopeRoundButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeRoundButton1.Location = new System.Drawing.Point(866, 29);
            this.hopeRoundButton1.Name = "hopeRoundButton1";
            this.hopeRoundButton1.PrimaryColor = System.Drawing.Color.Maroon;
            this.hopeRoundButton1.Size = new System.Drawing.Size(88, 29);
            this.hopeRoundButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeRoundButton1.TabIndex = 129;
            this.hopeRoundButton1.Text = "Clear";
            this.hopeRoundButton1.TextColor = System.Drawing.Color.White;
            this.hopeRoundButton1.Visible = false;
            this.hopeRoundButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeRoundButton1.Click += new System.EventHandler(this.hopeRoundButton1_Click);
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Items.AddRange(new object[] {
            "All",
            "BSIT",
            "BSCS"});
            this.poisonComboBox1.Location = new System.Drawing.Point(732, 29);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter By";
            this.poisonComboBox1.Size = new System.Drawing.Size(220, 29);
            this.poisonComboBox1.TabIndex = 132;
            this.poisonComboBox1.Text = "Filter By";
            this.poisonComboBox1.UseSelectable = true;
            this.poisonComboBox1.SelectedIndexChanged += new System.EventHandler(this.poisonComboBox1_SelectedIndexChanged_2);
            // 
            // btn_Archive
            // 
            this.btn_Archive.BackColor = System.Drawing.Color.Transparent;
            this.btn_Archive.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Archive.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btn_Archive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Archive.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btn_Archive.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_Archive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_Archive.HoverTextColor = System.Drawing.Color.White;
            this.btn_Archive.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btn_Archive.Location = new System.Drawing.Point(627, 436);
            this.btn_Archive.Name = "btn_Archive";
            this.btn_Archive.PrimaryColor = System.Drawing.Color.Maroon;
            this.btn_Archive.Size = new System.Drawing.Size(105, 32);
            this.btn_Archive.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btn_Archive.TabIndex = 131;
            this.btn_Archive.Text = "Archive";
            this.btn_Archive.TextColor = System.Drawing.Color.White;
            this.btn_Archive.Visible = false;
            this.btn_Archive.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btn_Archive.Click += new System.EventHandler(this.btn_Archive_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.BackColor = System.Drawing.Color.Transparent;
            this.edit_btn.BorderColor = System.Drawing.Color.Transparent;
            this.edit_btn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.edit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_btn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.edit_btn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.edit_btn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.edit_btn.HoverTextColor = System.Drawing.Color.White;
            this.edit_btn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.edit_btn.Location = new System.Drawing.Point(738, 436);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.PrimaryColor = System.Drawing.Color.Maroon;
            this.edit_btn.Size = new System.Drawing.Size(105, 32);
            this.edit_btn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.edit_btn.TabIndex = 130;
            this.edit_btn.Text = "Edit";
            this.edit_btn.TextColor = System.Drawing.Color.White;
            this.edit_btn.Visible = false;
            this.edit_btn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(19, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 351);
            this.panel3.TabIndex = 128;
            this.panel3.Visible = false;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AllowUserToResizeColumns = false;
            this.kryptonDataGridView1.AllowUserToResizeRows = false;
            this.kryptonDataGridView1.ColumnHeadersHeight = 45;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.kryptonDataGridView1.Location = new System.Drawing.Point(21, 64);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersVisible = false;
            this.kryptonDataGridView1.RowTemplate.Height = 40;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(933, 366);
            this.kryptonDataGridView1.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryptonDataGridView1.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.kryptonDataGridView1.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonDataGridView1.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.kryptonDataGridView1.TabIndex = 126;
            this.kryptonDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Student ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Program";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Transparent;
            this.btnBack.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnBack.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.HoverTextColor = System.Drawing.Color.White;
            this.btnBack.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnBack.Location = new System.Drawing.Point(849, 436);
            this.btnBack.Name = "btnBack";
            this.btnBack.PrimaryColor = System.Drawing.Color.Maroon;
            this.btnBack.Size = new System.Drawing.Size(105, 32);
            this.btnBack.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnBack.TabIndex = 122;
            this.btnBack.Text = "Back";
            this.btnBack.TextColor = System.Drawing.Color.White;
            this.btnBack.Visible = false;
            this.btnBack.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnBack.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Maroon;
            this.label27.Location = new System.Drawing.Point(14, 14);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(152, 25);
            this.label27.TabIndex = 116;
            this.label27.Text = "Modify Student";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 60);
            this.panel1.TabIndex = 91;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(18, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(404, 37);
            this.label4.TabIndex = 121;
            this.label4.Text = "Student Records Management";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdminStudentRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.foreverTabPage1);
            this.Controls.Add(this.panel1);
            this.Name = "AdminStudentRecords";
            this.Size = new System.Drawing.Size(1002, 609);
            this.Load += new System.EventHandler(this.AdminStudentRecords_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgStudentView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.foreverTabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private ReaLTaiizor.Controls.HopeRoundButton btnCreateStudent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private ReaLTaiizor.Controls.ComboBoxEdit cmbSex;
        private ReaLTaiizor.Controls.SmallTextBox txtSuffix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private ReaLTaiizor.Controls.SmallTextBox txtContactNo;
        private ReaLTaiizor.Controls.SmallTextBox txtLastName;
        private System.Windows.Forms.Label label12;
        private ReaLTaiizor.Controls.SmallTextBox txtMiddleName;
        private System.Windows.Forms.Label label10;
        private ReaLTaiizor.Controls.SmallTextBox txtFirstName;
        private ReaLTaiizor.Controls.SmallTextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.PoisonDateTime dtpBirthDay;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.SmallTextBox txtStudentID;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.SmallTextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.ComboBoxEdit cmbProgram;
        private ReaLTaiizor.Controls.ComboBoxEdit cmbSection;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.ForeverTabPage foreverTabPage1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUploadCSV;
        private ReaLTaiizor.Controls.HopeRoundButton btnRandomized;
        private System.Windows.Forms.TabPage tabPage4;
        private ReaLTaiizor.Controls.HopeRoundButton btnBack;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.DataGridView dgvPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.HopeRoundButton btnClearView;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.PoisonComboBox cmbFilterFacultyView;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dvgStudentView;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaySched;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton2;
        private ReaLTaiizor.Controls.HopeRoundButton edit_btn;
        private ReaLTaiizor.Controls.HopeRoundButton btn_Archive;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
    }
}