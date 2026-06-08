namespace GENTECH_PROJECTPUPSIS
{
    partial class StudentMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMainForm));
            this.pnlStudentTopNav = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSignout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.pnlStudentSideMenu = new System.Windows.Forms.Panel();
            this.flpnlStudentRec = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStudentRecord = new System.Windows.Forms.Button();
            this.flpnStudentButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnModule = new System.Windows.Forms.Button();
            this.btnQnE = new System.Windows.Forms.Button();
            this.btnAssignments = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblSMBC = new System.Windows.Forms.Label();
            this.lblPUPSIS = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnMinimizeSideBar = new System.Windows.Forms.Button();
            this.pnlStudentNavigator = new System.Windows.Forms.Panel();
            this.tmrStudentSideBar = new System.Windows.Forms.Timer(this.components);
            this.tmrStudentClassClick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlStudentTopNav)).BeginInit();
            this.pnlStudentTopNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlStudentSideMenu.SuspendLayout();
            this.flpnlStudentRec.SuspendLayout();
            this.flpnStudentButtons.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStudentTopNav
            // 
            this.pnlStudentTopNav.Controls.Add(this.btnSignout);
            this.pnlStudentTopNav.Controls.Add(this.pictureBox1);
            this.pnlStudentTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStudentTopNav.Location = new System.Drawing.Point(0, 33);
            this.pnlStudentTopNav.Name = "pnlStudentTopNav";
            this.pnlStudentTopNav.Size = new System.Drawing.Size(1200, 50);
            this.pnlStudentTopNav.StateCommon.Color1 = System.Drawing.Color.DarkRed;
            this.pnlStudentTopNav.StateCommon.Color2 = System.Drawing.Color.Maroon;
            this.pnlStudentTopNav.TabIndex = 3;
            // 
            // btnSignout
            // 
            this.btnSignout.BackColor = System.Drawing.Color.Transparent;
            this.btnSignout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSignout.FlatAppearance.BorderSize = 0;
            this.btnSignout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSignout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignout.ForeColor = System.Drawing.Color.White;
            this.btnSignout.Image = ((System.Drawing.Image)(resources.GetObject("btnSignout.Image")));
            this.btnSignout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignout.Location = new System.Drawing.Point(1089, 0);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnSignout.Size = new System.Drawing.Size(111, 50);
            this.btnSignout.TabIndex = 47;
            this.btnSignout.Text = "SIGN-OUT";
            this.btnSignout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignout.UseVisualStyleBackColor = false;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.nightControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 33);
            this.panel1.TabIndex = 2;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(1061, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 0;
            // 
            // pnlStudentSideMenu
            // 
            this.pnlStudentSideMenu.BackColor = System.Drawing.Color.White;
            this.pnlStudentSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStudentSideMenu.Controls.Add(this.flpnlStudentRec);
            this.pnlStudentSideMenu.Controls.Add(this.flpnStudentButtons);
            this.pnlStudentSideMenu.Controls.Add(this.panel2);
            this.pnlStudentSideMenu.Controls.Add(this.panel6);
            this.pnlStudentSideMenu.Controls.Add(this.lblPUPSIS);
            this.pnlStudentSideMenu.Controls.Add(this.panel7);
            this.pnlStudentSideMenu.Controls.Add(this.panel8);
            this.pnlStudentSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStudentSideMenu.Location = new System.Drawing.Point(0, 83);
            this.pnlStudentSideMenu.Name = "pnlStudentSideMenu";
            this.pnlStudentSideMenu.Size = new System.Drawing.Size(198, 609);
            this.pnlStudentSideMenu.TabIndex = 73;
            // 
            // flpnlStudentRec
            // 
            this.flpnlStudentRec.Controls.Add(this.btnStudentRecord);
            this.flpnlStudentRec.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnlStudentRec.Location = new System.Drawing.Point(0, 230);
            this.flpnlStudentRec.Margin = new System.Windows.Forms.Padding(0);
            this.flpnlStudentRec.Name = "flpnlStudentRec";
            this.flpnlStudentRec.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpnlStudentRec.Size = new System.Drawing.Size(196, 56);
            this.flpnlStudentRec.TabIndex = 80;
            this.flpnlStudentRec.WrapContents = false;
            // 
            // btnStudentRecord
            // 
            this.btnStudentRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStudentRecord.FlatAppearance.BorderSize = 0;
            this.btnStudentRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnStudentRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentRecord.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStudentRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnStudentRecord.Image")));
            this.btnStudentRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentRecord.Location = new System.Drawing.Point(0, 5);
            this.btnStudentRecord.Margin = new System.Windows.Forms.Padding(0);
            this.btnStudentRecord.Name = "btnStudentRecord";
            this.btnStudentRecord.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStudentRecord.Size = new System.Drawing.Size(199, 51);
            this.btnStudentRecord.TabIndex = 46;
            this.btnStudentRecord.Text = "    View Grades";
            this.btnStudentRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudentRecord.UseVisualStyleBackColor = false;
            this.btnStudentRecord.Click += new System.EventHandler(this.btnStudentRecord_Click);
            // 
            // flpnStudentButtons
            // 
            this.flpnStudentButtons.Controls.Add(this.btnDashboard);
            this.flpnStudentButtons.Controls.Add(this.btnHome);
            this.flpnStudentButtons.Controls.Add(this.btnModule);
            this.flpnStudentButtons.Controls.Add(this.btnQnE);
            this.flpnStudentButtons.Controls.Add(this.btnAssignments);
            this.flpnStudentButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpnStudentButtons.Location = new System.Drawing.Point(0, 174);
            this.flpnStudentButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpnStudentButtons.Name = "flpnStudentButtons";
            this.flpnStudentButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpnStudentButtons.Size = new System.Drawing.Size(196, 56);
            this.flpnStudentButtons.TabIndex = 79;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 5);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnDashboard.Size = new System.Drawing.Size(199, 51);
            this.btnDashboard.TabIndex = 43;
            this.btnDashboard.Text = "    Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 61);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnHome.Size = new System.Drawing.Size(203, 51);
            this.btnHome.TabIndex = 47;
            this.btnHome.Text = "    Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // btnModule
            // 
            this.btnModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModule.FlatAppearance.BorderSize = 0;
            this.btnModule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModule.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModule.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModule.Image = ((System.Drawing.Image)(resources.GetObject("btnModule.Image")));
            this.btnModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModule.Location = new System.Drawing.Point(0, 117);
            this.btnModule.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnModule.Name = "btnModule";
            this.btnModule.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnModule.Size = new System.Drawing.Size(200, 51);
            this.btnModule.TabIndex = 52;
            this.btnModule.Text = "    Module";
            this.btnModule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModule.UseVisualStyleBackColor = false;
            this.btnModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnQnE
            // 
            this.btnQnE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQnE.FlatAppearance.BorderSize = 0;
            this.btnQnE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnQnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQnE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQnE.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQnE.Image = ((System.Drawing.Image)(resources.GetObject("btnQnE.Image")));
            this.btnQnE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQnE.Location = new System.Drawing.Point(0, 173);
            this.btnQnE.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnQnE.Name = "btnQnE";
            this.btnQnE.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnQnE.Size = new System.Drawing.Size(198, 51);
            this.btnQnE.TabIndex = 79;
            this.btnQnE.Text = "    Quizzes and Exams";
            this.btnQnE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQnE.UseVisualStyleBackColor = false;
            this.btnQnE.Click += new System.EventHandler(this.btnQnE_Click);
            // 
            // btnAssignments
            // 
            this.btnAssignments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAssignments.FlatAppearance.BorderSize = 0;
            this.btnAssignments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignments.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignments.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAssignments.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignments.Image")));
            this.btnAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignments.Location = new System.Drawing.Point(0, 229);
            this.btnAssignments.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnAssignments.Name = "btnAssignments";
            this.btnAssignments.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAssignments.Size = new System.Drawing.Size(198, 51);
            this.btnAssignments.TabIndex = 41;
            this.btnAssignments.Text = "    Assignments";
            this.btnAssignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignments.UseVisualStyleBackColor = false;
            this.btnAssignments.Click += new System.EventHandler(this.btnAssignments_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 25);
            this.panel2.TabIndex = 76;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblSMBC);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 131);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(196, 18);
            this.panel6.TabIndex = 72;
            // 
            // lblSMBC
            // 
            this.lblSMBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSMBC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSMBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSMBC.Location = new System.Drawing.Point(0, 0);
            this.lblSMBC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSMBC.Name = "lblSMBC";
            this.lblSMBC.Size = new System.Drawing.Size(196, 18);
            this.lblSMBC.TabIndex = 37;
            this.lblSMBC.Text = "Sta. Maria, Bulacan Campus";
            this.lblSMBC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPUPSIS
            // 
            this.lblPUPSIS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPUPSIS.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblPUPSIS.ForeColor = System.Drawing.Color.Maroon;
            this.lblPUPSIS.Location = new System.Drawing.Point(0, 83);
            this.lblPUPSIS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPUPSIS.Name = "lblPUPSIS";
            this.lblPUPSIS.Size = new System.Drawing.Size(196, 48);
            this.lblPUPSIS.TabIndex = 73;
            this.lblPUPSIS.Text = "PUPSIS";
            this.lblPUPSIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(196, 53);
            this.panel7.TabIndex = 72;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pictureBox3.Size = new System.Drawing.Size(196, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnMinimizeSideBar);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(196, 30);
            this.panel8.TabIndex = 71;
            // 
            // btnMinimizeSideBar
            // 
            this.btnMinimizeSideBar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeSideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizeSideBar.FlatAppearance.BorderSize = 0;
            this.btnMinimizeSideBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeSideBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeSideBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeSideBar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizeSideBar.Image")));
            this.btnMinimizeSideBar.Location = new System.Drawing.Point(137, 0);
            this.btnMinimizeSideBar.Name = "btnMinimizeSideBar";
            this.btnMinimizeSideBar.Size = new System.Drawing.Size(59, 30);
            this.btnMinimizeSideBar.TabIndex = 0;
            this.btnMinimizeSideBar.UseVisualStyleBackColor = false;
            this.btnMinimizeSideBar.Click += new System.EventHandler(this.btnMinimizeSideBar_Click);
            // 
            // pnlStudentNavigator
            // 
            this.pnlStudentNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudentNavigator.Location = new System.Drawing.Point(198, 83);
            this.pnlStudentNavigator.Name = "pnlStudentNavigator";
            this.pnlStudentNavigator.Size = new System.Drawing.Size(1002, 609);
            this.pnlStudentNavigator.TabIndex = 74;
            // 
            // tmrStudentSideBar
            // 
            this.tmrStudentSideBar.Interval = 10;
            this.tmrStudentSideBar.Tick += new System.EventHandler(this.tmrStudentSideBar_Tick);
            // 
            // tmrStudentClassClick
            // 
            this.tmrStudentClassClick.Interval = 5;
            this.tmrStudentClassClick.Tick += new System.EventHandler(this.tmrStudentClassClick_Tick);
            // 
            // StudentMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.ControlBox = false;
            this.Controls.Add(this.pnlStudentNavigator);
            this.Controls.Add(this.pnlStudentSideMenu);
            this.Controls.Add(this.pnlStudentTopNav);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentMainForm";
            this.Load += new System.EventHandler(this.StudentMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlStudentTopNav)).EndInit();
            this.pnlStudentTopNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlStudentSideMenu.ResumeLayout(false);
            this.flpnlStudentRec.ResumeLayout(false);
            this.flpnStudentButtons.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlStudentTopNav;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.Panel pnlStudentSideMenu;
        private System.Windows.Forms.Button btnModule;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.FlowLayoutPanel flpnStudentButtons;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblSMBC;
        private System.Windows.Forms.Label lblPUPSIS;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnMinimizeSideBar;
        private System.Windows.Forms.FlowLayoutPanel flpnlStudentRec;
        private System.Windows.Forms.Button btnStudentRecord;
        private System.Windows.Forms.Button btnAssignments;
        private System.Windows.Forms.Button btnQnE;
        private System.Windows.Forms.Panel pnlStudentNavigator;
        private System.Windows.Forms.Timer tmrStudentSideBar;
        private System.Windows.Forms.Timer tmrStudentClassClick;
    }
}