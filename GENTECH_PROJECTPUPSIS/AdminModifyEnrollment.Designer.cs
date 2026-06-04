namespace GENTECH_PROJECTPUPSIS
{
    partial class AdminModifyEnrollment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminModifyEnrollment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModify = new System.Windows.Forms.Label();
            this.btnDropSubjects = new ReaLTaiizor.Controls.HopeRoundButton();
            this.btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            this.btnAddSubjects = new ReaLTaiizor.Controls.HopeRoundButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStudentID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dvgModifyEnrollment = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgTodaysSchedCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaysSchedClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaySched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.btnClear = new ReaLTaiizor.Controls.HopeRoundButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUnitsOverload = new System.Windows.Forms.Label();
            this.lblUnitsAllowed = new System.Windows.Forms.Label();
            this.lblUnitsEnrolled = new System.Windows.Forms.Label();
            this.btnSaveChanges = new ReaLTaiizor.Controls.HopeRoundButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgModifyEnrollment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 65);
            this.panel1.TabIndex = 70;
            // 
            // lblModify
            // 
            this.lblModify.AutoSize = true;
            this.lblModify.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModify.ForeColor = System.Drawing.Color.Maroon;
            this.lblModify.Location = new System.Drawing.Point(14, 12);
            this.lblModify.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModify.Name = "lblModify";
            this.lblModify.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblModify.Size = new System.Drawing.Size(259, 41);
            this.lblModify.TabIndex = 36;
            this.lblModify.Text = "Modify Enrollment";
            // 
            // btnDropSubjects
            // 
            this.btnDropSubjects.BackColor = System.Drawing.Color.Transparent;
            this.btnDropSubjects.BorderColor = System.Drawing.Color.Transparent;
            this.btnDropSubjects.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnDropSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDropSubjects.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnDropSubjects.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDropSubjects.Enabled = false;
            this.btnDropSubjects.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDropSubjects.HoverTextColor = System.Drawing.Color.White;
            this.btnDropSubjects.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnDropSubjects.Location = new System.Drawing.Point(845, 549);
            this.btnDropSubjects.Name = "btnDropSubjects";
            this.btnDropSubjects.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDropSubjects.Size = new System.Drawing.Size(136, 32);
            this.btnDropSubjects.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnDropSubjects.TabIndex = 146;
            this.btnDropSubjects.Text = "Drop Subject ";
            this.btnDropSubjects.TextColor = System.Drawing.Color.White;
            this.btnDropSubjects.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnDropSubjects.Click += new System.EventHandler(this.btnDropSubjects_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearch.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSearch.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSearch.HoverTextColor = System.Drawing.Color.White;
            this.btnSearch.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSearch.Location = new System.Drawing.Point(373, 167);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PrimaryColor = System.Drawing.Color.Maroon;
            this.btnSearch.Size = new System.Drawing.Size(88, 29);
            this.btnSearch.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSearch.TabIndex = 145;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSubjects.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddSubjects.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnAddSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSubjects.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnAddSubjects.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddSubjects.Enabled = false;
            this.btnAddSubjects.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddSubjects.HoverTextColor = System.Drawing.Color.White;
            this.btnAddSubjects.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnAddSubjects.Location = new System.Drawing.Point(710, 549);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAddSubjects.Size = new System.Drawing.Size(129, 32);
            this.btnAddSubjects.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnAddSubjects.TabIndex = 141;
            this.btnAddSubjects.Text = "Add Subject ";
            this.btnAddSubjects.TextColor = System.Drawing.Color.White;
            this.btnAddSubjects.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnAddSubjects.Click += new System.EventHandler(this.btnAddSubjects_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(537, 508);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 17);
            this.label10.TabIndex = 140;
            this.label10.Text = "Units Currently Enrolled: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(268, 508);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 17);
            this.label9.TabIndex = 139;
            this.label9.Text = "Approved Overload Units: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(805, 508);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 17);
            this.label8.TabIndex = 138;
            this.label8.Text = "Units Allowed to Enroll:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(18, 508);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 137;
            this.label3.Text = "Academic Status: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(28, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 19);
            this.label4.TabIndex = 148;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(21, 166);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(346, 30);
            this.txtStudentID.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.txtStudentID.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.txtStudentID.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtStudentID.StateCommon.Border.Rounding = 10;
            this.txtStudentID.StateCommon.Content.Color1 = System.Drawing.Color.LightGray;
            this.txtStudentID.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.StateCommon.Content.Padding = new System.Windows.Forms.Padding(30, 2, 10, 2);
            this.txtStudentID.TabIndex = 147;
            this.txtStudentID.Tag = "Student ID";
            this.txtStudentID.Text = "Student ID";
            this.txtStudentID.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtStudentID.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // dvgModifyEnrollment
            // 
            this.dvgModifyEnrollment.AllowUserToAddRows = false;
            this.dvgModifyEnrollment.AllowUserToDeleteRows = false;
            this.dvgModifyEnrollment.AllowUserToResizeColumns = false;
            this.dvgModifyEnrollment.AllowUserToResizeRows = false;
            this.dvgModifyEnrollment.ColumnHeadersHeight = 45;
            this.dvgModifyEnrollment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgTodaysSchedCourse,
            this.dgTodaysSchedClass,
            this.Description,
            this.Units,
            this.dgTodaySched});
            this.dvgModifyEnrollment.Location = new System.Drawing.Point(21, 202);
            this.dvgModifyEnrollment.Name = "dvgModifyEnrollment";
            this.dvgModifyEnrollment.RowHeadersVisible = false;
            this.dvgModifyEnrollment.RowTemplate.Height = 40;
            this.dvgModifyEnrollment.Size = new System.Drawing.Size(933, 303);
            this.dvgModifyEnrollment.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dvgModifyEnrollment.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dvgModifyEnrollment.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dvgModifyEnrollment.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgModifyEnrollment.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgModifyEnrollment.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgModifyEnrollment.TabIndex = 149;
            // 
            // dgTodaysSchedCourse
            // 
            this.dgTodaysSchedCourse.HeaderText = "Select";
            this.dgTodaysSchedCourse.Name = "dgTodaysSchedCourse";
            this.dgTodaysSchedCourse.ReadOnly = true;
            this.dgTodaysSchedCourse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTodaysSchedCourse.Width = 300;
            // 
            // dgTodaysSchedClass
            // 
            this.dgTodaysSchedClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgTodaysSchedClass.HeaderText = "Subject Code";
            this.dgTodaysSchedClass.Name = "dgTodaysSchedClass";
            this.dgTodaysSchedClass.ReadOnly = true;
            this.dgTodaysSchedClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Units
            // 
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            // 
            // dgTodaySched
            // 
            this.dgTodaySched.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgTodaySched.HeaderText = "Schedules";
            this.dgTodaySched.Name = "dgTodaySched";
            this.dgTodaySched.ReadOnly = true;
            this.dgTodaySched.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Maroon;
            this.lblName.Location = new System.Drawing.Point(16, 68);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblName.Size = new System.Drawing.Size(358, 34);
            this.lblName.TabIndex = 37;
            this.lblName.Text = "ONGARIA, MARK JOSEPH REGALA";
            this.lblName.Visible = false;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.Maroon;
            this.lblStudentID.Location = new System.Drawing.Point(765, 120);
            this.lblStudentID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblStudentID.Size = new System.Drawing.Size(189, 34);
            this.lblStudentID.TabIndex = 150;
            this.lblStudentID.Text = "2024-00136-SM-0";
            this.lblStudentID.Visible = false;
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgram.ForeColor = System.Drawing.Color.Maroon;
            this.lblProgram.Location = new System.Drawing.Point(16, 120);
            this.lblProgram.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblProgram.Size = new System.Drawing.Size(719, 34);
            this.lblProgram.TabIndex = 151;
            this.lblProgram.Text = "BACHELOR OF SCIENCE IN INFORMATION TECHNOLOGY (STA. MARIA)";
            this.lblProgram.Visible = false;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.Maroon;
            this.lblSection.Location = new System.Drawing.Point(803, 68);
            this.lblSection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblSection.Size = new System.Drawing.Size(147, 34);
            this.lblSection.TabIndex = 152;
            this.lblSection.Text = "BSIT-SM 2 - 2";
            this.lblSection.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderColor = System.Drawing.Color.Transparent;
            this.btnClear.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnClear.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClear.HoverTextColor = System.Drawing.Color.White;
            this.btnClear.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnClear.Location = new System.Drawing.Point(467, 167);
            this.btnClear.Name = "btnClear";
            this.btnClear.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClear.Size = new System.Drawing.Size(88, 29);
            this.btnClear.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnClear.TabIndex = 153;
            this.btnClear.Text = "Clear";
            this.btnClear.TextColor = System.Drawing.Color.White;
            this.btnClear.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(130, 508);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(18, 17);
            this.lblStatus.TabIndex = 154;
            this.lblStatus.Tag = "--";
            this.lblStatus.Text = "--";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnitsOverload
            // 
            this.lblUnitsOverload.AutoSize = true;
            this.lblUnitsOverload.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnitsOverload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitsOverload.Location = new System.Drawing.Point(435, 508);
            this.lblUnitsOverload.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitsOverload.Name = "lblUnitsOverload";
            this.lblUnitsOverload.Size = new System.Drawing.Size(18, 17);
            this.lblUnitsOverload.TabIndex = 155;
            this.lblUnitsOverload.Tag = "--";
            this.lblUnitsOverload.Text = "--";
            this.lblUnitsOverload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnitsAllowed
            // 
            this.lblUnitsAllowed.AutoSize = true;
            this.lblUnitsAllowed.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnitsAllowed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitsAllowed.Location = new System.Drawing.Point(954, 508);
            this.lblUnitsAllowed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitsAllowed.Name = "lblUnitsAllowed";
            this.lblUnitsAllowed.Size = new System.Drawing.Size(18, 17);
            this.lblUnitsAllowed.TabIndex = 156;
            this.lblUnitsAllowed.Tag = "--";
            this.lblUnitsAllowed.Text = "--";
            this.lblUnitsAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnitsEnrolled
            // 
            this.lblUnitsEnrolled.AutoSize = true;
            this.lblUnitsEnrolled.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnitsEnrolled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitsEnrolled.Location = new System.Drawing.Point(696, 508);
            this.lblUnitsEnrolled.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitsEnrolled.Name = "lblUnitsEnrolled";
            this.lblUnitsEnrolled.Size = new System.Drawing.Size(18, 17);
            this.lblUnitsEnrolled.TabIndex = 157;
            this.lblUnitsEnrolled.Tag = "--";
            this.lblUnitsEnrolled.Text = "--";
            this.lblUnitsEnrolled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveChanges.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveChanges.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanges.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSaveChanges.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSaveChanges.HoverTextColor = System.Drawing.Color.White;
            this.btnSaveChanges.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSaveChanges.Location = new System.Drawing.Point(500, 549);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSaveChanges.Size = new System.Drawing.Size(163, 32);
            this.btnSaveChanges.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSaveChanges.TabIndex = 158;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.TextColor = System.Drawing.Color.White;
            this.btnSaveChanges.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // AdminModifyEnrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.lblUnitsEnrolled);
            this.Controls.Add(this.lblUnitsAllowed);
            this.Controls.Add(this.lblUnitsOverload);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dvgModifyEnrollment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.btnDropSubjects);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddSubjects);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "AdminModifyEnrollment";
            this.Size = new System.Drawing.Size(1002, 609);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgModifyEnrollment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblModify;
        private ReaLTaiizor.Controls.HopeRoundButton btnDropSubjects;
        private ReaLTaiizor.Controls.HopeRoundButton btnSearch;
        private ReaLTaiizor.Controls.HopeRoundButton btnAddSubjects;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtStudentID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dvgModifyEnrollment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaySched;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Label lblSection;
        private ReaLTaiizor.Controls.HopeRoundButton btnClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUnitsOverload;
        private System.Windows.Forms.Label lblUnitsAllowed;
        private System.Windows.Forms.Label lblUnitsEnrolled;
        private ReaLTaiizor.Controls.HopeRoundButton btnSaveChanges;
    }
}
