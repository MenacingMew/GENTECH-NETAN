namespace GENTECH_PROJECTPUPSIS
{
    partial class AdminUserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUserManagement));
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRole = new ReaLTaiizor.Controls.PoisonComboBox();
            this.cmbStatus = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearchName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dvgEnrollees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnExport = new GENTECH_PROJECTPUPSIS.CustomButton();
            this.asd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnrollees)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(23, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 37);
            this.label8.TabIndex = 86;
            this.label8.Text = "User Management";
            // 
            // cmbRole
            // 
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbRole.ForeColor = System.Drawing.Color.LightGray;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.ItemHeight = 23;
            this.cmbRole.Items.AddRange(new object[] {
            "All",
            "Student",
            "Faculty"});
            this.cmbRole.Location = new System.Drawing.Point(598, 78);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.PromptText = "Role";
            this.cmbRole.Size = new System.Drawing.Size(202, 29);
            this.cmbRole.TabIndex = 95;
            this.cmbRole.Text = "Role";
            this.cmbRole.UseSelectable = true;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbStatus.ForeColor = System.Drawing.Color.LightGray;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 23;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Passed",
            "Failed"});
            this.cmbStatus.Location = new System.Drawing.Point(375, 78);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.PromptText = "Status";
            this.cmbStatus.Size = new System.Drawing.Size(217, 29);
            this.cmbStatus.TabIndex = 94;
            this.cmbStatus.Text = "Status";
            this.cmbStatus.UseSelectable = true;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(30, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 93;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(23, 77);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(346, 30);
            this.txtSearchName.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.txtSearchName.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.txtSearchName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearchName.StateCommon.Border.Rounding = 10;
            this.txtSearchName.StateCommon.Content.Color1 = System.Drawing.Color.LightGray;
            this.txtSearchName.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(30, 2, 10, 2);
            this.txtSearchName.TabIndex = 92;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // dvgEnrollees
            // 
            this.dvgEnrollees.AllowUserToAddRows = false;
            this.dvgEnrollees.AllowUserToDeleteRows = false;
            this.dvgEnrollees.AllowUserToResizeColumns = false;
            this.dvgEnrollees.AllowUserToResizeRows = false;
            this.dvgEnrollees.ColumnHeadersHeight = 45;
            this.dvgEnrollees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.asd,
            this.Role,
            this.Email,
            this.Status});
            this.dvgEnrollees.Location = new System.Drawing.Point(30, 113);
            this.dvgEnrollees.Name = "dvgEnrollees";
            this.dvgEnrollees.RowHeadersVisible = false;
            this.dvgEnrollees.RowTemplate.Height = 40;
            this.dvgEnrollees.Size = new System.Drawing.Size(933, 425);
            this.dvgEnrollees.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dvgEnrollees.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dvgEnrollees.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dvgEnrollees.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgEnrollees.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgEnrollees.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dvgEnrollees.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dvgEnrollees.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dvgEnrollees.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dvgEnrollees.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dvgEnrollees.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dvgEnrollees.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgEnrollees.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgEnrollees.TabIndex = 122;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkRed;
            this.btnExport.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnExport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExport.BorderRadius = 25;
            this.btnExport.BorderSize = 0;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(806, 78);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(173, 29);
            this.btnExport.TabIndex = 123;
            this.btnExport.Text = "Export as Csv";
            this.btnExport.TextColor = System.Drawing.Color.White;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // asd
            // 
            this.asd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.asd.HeaderText = "Name";
            this.asd.Name = "asd";
            this.asd.ReadOnly = true;
            this.asd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            this.Role.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Role.Width = 300;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(372, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 124;
            this.label1.Text = "Filter by Status";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(595, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 125;
            this.label2.Text = "Filter by Role";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(27, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 126;
            this.label3.Text = "Search Name";
            // 
            // AdminUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dvgEnrollees);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label8);
            this.Name = "AdminUserManagement";
            this.Size = new System.Drawing.Size(1002, 609);
            this.Load += new System.EventHandler(this.AdminUserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnrollees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.PoisonComboBox cmbRole;
        private ReaLTaiizor.Controls.PoisonComboBox cmbStatus;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dvgEnrollees;
        private CustomButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn asd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
