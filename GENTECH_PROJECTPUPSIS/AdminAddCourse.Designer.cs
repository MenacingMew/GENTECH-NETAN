namespace GENTECH_PROJECTPUPSIS
{
    partial class AdminAddCourse
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
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCourses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgCourseManageCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageCourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCourseManageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCourseCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddCourse = new GENTECH_PROJECTPUPSIS.CustomButton();
            this.btnTransfer = new GENTECH_PROJECTPUPSIS.CustomButton();
            this.dgdSemester = new System.Windows.Forms.ComboBox();
            this.dgdStatus = new System.Windows.Forms.ComboBox();
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
            this.label8.Size = new System.Drawing.Size(177, 37);
            this.label8.TabIndex = 80;
            this.label8.Text = "Add Courses";
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
            this.dgCourseManageStatus});
            this.dgvCourses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCourses.Location = new System.Drawing.Point(14, 77);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 40;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(729, 516);
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
            this.dgvCourses.TabIndex = 85;
            // 
            // dgCourseManageCourseName
            // 
            this.dgCourseManageCourseName.HeaderText = "Course Name";
            this.dgCourseManageCourseName.Name = "dgCourseManageCourseName";
            this.dgCourseManageCourseName.ReadOnly = true;
            this.dgCourseManageCourseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCourseManageCourseName.Width = 200;
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(747, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 30);
            this.label1.TabIndex = 86;
            this.label1.Text = "Add Additional Courses";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(748, 171);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(241, 27);
            this.txtCourseName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCourseName.StateCommon.Border.Rounding = 10;
            this.txtCourseName.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseName.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(748, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "Course Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(748, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "Course Code";
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Location = new System.Drawing.Point(748, 232);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(241, 27);
            this.txtCourseCode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCourseCode.StateCommon.Border.Rounding = 10;
            this.txtCourseCode.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseCode.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(748, 269);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "Term";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(748, 332);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 94;
            this.label5.Text = "Status";
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
            this.btnAddCourse.Location = new System.Drawing.Point(749, 495);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(120, 46);
            this.btnAddCourse.TabIndex = 95;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.TextColor = System.Drawing.Color.White;
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.DarkRed;
            this.btnTransfer.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnTransfer.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTransfer.BorderRadius = 25;
            this.btnTransfer.BorderSize = 0;
            this.btnTransfer.FlatAppearance.BorderSize = 0;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(875, 495);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 46);
            this.btnTransfer.TabIndex = 96;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.TextColor = System.Drawing.Color.White;
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // dgdSemester
            // 
            this.dgdSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgdSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dgdSemester.FormattingEnabled = true;
            this.dgdSemester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester",
            "3rd Semester (Summer Class)"});
            this.dgdSemester.Location = new System.Drawing.Point(748, 296);
            this.dgdSemester.Name = "dgdSemester";
            this.dgdSemester.Size = new System.Drawing.Size(237, 23);
            this.dgdSemester.TabIndex = 97;
            // 
            // dgdStatus
            // 
            this.dgdStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgdStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dgdStatus.FormattingEnabled = true;
            this.dgdStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.dgdStatus.Location = new System.Drawing.Point(748, 355);
            this.dgdStatus.Name = "dgdStatus";
            this.dgdStatus.Size = new System.Drawing.Size(237, 23);
            this.dgdStatus.TabIndex = 98;
            // 
            // AdminAddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dgdStatus);
            this.Controls.Add(this.dgdSemester);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCourseCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.label8);
            this.Name = "AdminAddCourse";
            this.Size = new System.Drawing.Size(1002, 609);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvCourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCourseManageStatus;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCourseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCourseCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomButton btnAddCourse;
        private CustomButton btnTransfer;
        private System.Windows.Forms.ComboBox dgdSemester;
        private System.Windows.Forms.ComboBox dgdStatus;
    }
}
