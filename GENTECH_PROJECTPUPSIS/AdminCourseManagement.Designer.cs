namespace GENTECH_PROJECTPUPSIS
{
    partial class AdminCourseManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCourseManagement));
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCourses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgCourseManageCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageCourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddCourse = new GENTECH_PROJECTPUPSIS.CustomButton();
            this.BtnImport = new GENTECH_PROJECTPUPSIS.CustomButton();
            this.poisonComboBox3 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.poisonComboBox4 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(31, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 37);
            this.label8.TabIndex = 79;
            this.label8.Text = "Course Management";
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AllowUserToResizeColumns = false;
            this.dgvCourses.AllowUserToResizeRows = false;
            this.dgvCourses.ColumnHeadersHeight = 45;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgCourseManageCourseName,
            this.dgCourseManageCourseCode,
            this.dgCourseManageCategory,
            this.dgCourseManageStatus,
            this.dgCourseManageAction});
            this.dgvCourses.Location = new System.Drawing.Point(31, 116);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 40;
            this.dgvCourses.Size = new System.Drawing.Size(941, 478);
            this.dgvCourses.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvCourses.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvCourses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvCourses.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCourses.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dgvCourses.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvCourses.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvCourses.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvCourses.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvCourses.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvCourses.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvCourses.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvCourses.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCourses.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvCourses.TabIndex = 84;
            this.dgvCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellContentClick);
            // 
            // dgCourseManageCourseName
            // 
            this.dgCourseManageCourseName.HeaderText = "Course Name";
            this.dgCourseManageCourseName.Name = "dgCourseManageCourseName";
            this.dgCourseManageCourseName.ReadOnly = true;
            this.dgCourseManageCourseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCourseManageCourseName.Width = 300;
            // 
            // dgCourseManageCourseCode
            // 
            this.dgCourseManageCourseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgCourseManageCourseCode.HeaderText = "Course Code";
            this.dgCourseManageCourseCode.Name = "dgCourseManageCourseCode";
            this.dgCourseManageCourseCode.ReadOnly = true;
            this.dgCourseManageCourseCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgCourseManageCategory
            // 
            this.dgCourseManageCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgCourseManageCategory.HeaderText = "Category";
            this.dgCourseManageCategory.Name = "dgCourseManageCategory";
            this.dgCourseManageCategory.ReadOnly = true;
            this.dgCourseManageCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgCourseManageStatus
            // 
            this.dgCourseManageStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgCourseManageStatus.HeaderText = "Status";
            this.dgCourseManageStatus.Name = "dgCourseManageStatus";
            this.dgCourseManageStatus.ReadOnly = true;
            this.dgCourseManageStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgCourseManageAction
            // 
            this.dgCourseManageAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgCourseManageAction.HeaderText = "Action";
            this.dgCourseManageAction.Name = "dgCourseManageAction";
            this.dgCourseManageAction.ReadOnly = true;
            this.dgCourseManageAction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCourseManageAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgCourseManageAction.Text = "View";
            this.dgCourseManageAction.UseColumnTextForButtonValue = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(38, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 87;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddCourse.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnAddCourse.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddCourse.BorderRadius = 25;
            this.btnAddCourse.BorderSize = 0;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Location = new System.Drawing.Point(698, 82);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(134, 29);
            this.btnAddCourse.TabIndex = 94;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.TextColor = System.Drawing.Color.White;
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.BackColor = System.Drawing.Color.DarkRed;
            this.BtnImport.BackgroundColor = System.Drawing.Color.DarkRed;
            this.BtnImport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnImport.BorderRadius = 25;
            this.BtnImport.BorderSize = 0;
            this.BtnImport.FlatAppearance.BorderSize = 0;
            this.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImport.ForeColor = System.Drawing.Color.White;
            this.BtnImport.Location = new System.Drawing.Point(838, 81);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(134, 29);
            this.BtnImport.TabIndex = 93;
            this.BtnImport.Text = "Import";
            this.BtnImport.TextColor = System.Drawing.Color.White;
            this.BtnImport.UseVisualStyleBackColor = false;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // poisonComboBox3
            // 
            this.poisonComboBox3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox3.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox3.FormattingEnabled = true;
            this.poisonComboBox3.ItemHeight = 23;
            this.poisonComboBox3.Location = new System.Drawing.Point(490, 82);
            this.poisonComboBox3.Name = "poisonComboBox3";
            this.poisonComboBox3.PromptText = "Filter By";
            this.poisonComboBox3.Size = new System.Drawing.Size(202, 29);
            this.poisonComboBox3.TabIndex = 97;
            this.poisonComboBox3.Text = "Filter By";
            this.poisonComboBox3.UseSelectable = true;
            // 
            // poisonComboBox4
            // 
            this.poisonComboBox4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox4.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox4.FormattingEnabled = true;
            this.poisonComboBox4.ItemHeight = 23;
            this.poisonComboBox4.Location = new System.Drawing.Point(282, 82);
            this.poisonComboBox4.Name = "poisonComboBox4";
            this.poisonComboBox4.PromptText = "Status";
            this.poisonComboBox4.Size = new System.Drawing.Size(202, 29);
            this.poisonComboBox4.TabIndex = 96;
            this.poisonComboBox4.Text = "Status";
            this.poisonComboBox4.UseSelectable = true;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(32, 82);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(244, 30);
            this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(30, 2, 10, 2);
            this.kryptonTextBox1.TabIndex = 95;
            this.kryptonTextBox1.Text = "Search";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(39, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 19);
            this.label1.TabIndex = 98;
            // 
            // AdminCourseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.poisonComboBox3);
            this.Controls.Add(this.poisonComboBox4);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvCourses);
            this.Name = "AdminCourseManagement";
            this.Size = new System.Drawing.Size(1002, 609);
            this.Load += new System.EventHandler(this.AdminCourseManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCourses;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageStatus;
        private System.Windows.Forms.DataGridViewButtonColumn dgCourseManageAction;
        private CustomButton btnAddCourse;
        private CustomButton BtnImport;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox3;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.Label label1;
    }
}
