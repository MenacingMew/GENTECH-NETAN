namespace GENTECH_PROJECTPUPSIS
{
    partial class StudentViewGradePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentViewGradePanel));
            this.dgvStudentViewGrades = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.poisonComboBox2 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgGradeCourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGradeCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGradeInstructor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeFinalGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentViewGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentViewGrades
            // 
            this.dgvStudentViewGrades.AllowUserToAddRows = false;
            this.dgvStudentViewGrades.AllowUserToDeleteRows = false;
            this.dgvStudentViewGrades.AllowUserToResizeColumns = false;
            this.dgvStudentViewGrades.AllowUserToResizeRows = false;
            this.dgvStudentViewGrades.ColumnHeadersHeight = 50;
            this.dgvStudentViewGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgGradeCourseCode,
            this.dgGradeCourseName,
            this.dgGradeInstructor,
            this.dgStudentGradeUnits,
            this.dgStudentGradeFinalGrade,
            this.dgStudentGradeRemarks,
            this.dgStudentGradeDetails});
            this.dgvStudentViewGrades.Location = new System.Drawing.Point(13, 136);
            this.dgvStudentViewGrades.Name = "dgvStudentViewGrades";
            this.dgvStudentViewGrades.RowHeadersVisible = false;
            this.dgvStudentViewGrades.RowTemplate.Height = 40;
            this.dgvStudentViewGrades.Size = new System.Drawing.Size(958, 444);
            this.dgvStudentViewGrades.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvStudentViewGrades.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvStudentViewGrades.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvStudentViewGrades.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvStudentViewGrades.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentViewGrades.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentViewGrades.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, -1);
            this.dgvStudentViewGrades.TabIndex = 23;
            this.dgvStudentViewGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentViewGrades_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Grade formula: Attendance - (10%, Recitation - 10%, Activities - 20%, Quizzes - 3" +
    "0%, Major Examinations - 30%)";
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Location = new System.Drawing.Point(450, 100);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter By";
            this.poisonComboBox1.Size = new System.Drawing.Size(220, 29);
            this.poisonComboBox1.TabIndex = 75;
            this.poisonComboBox1.Text = "Filter By";
            this.poisonComboBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(20, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 74;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(13, 100);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(431, 30);
            this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.LightGray;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(30, 2, 10, 2);
            this.kryptonTextBox1.TabIndex = 73;
            this.kryptonTextBox1.Text = "Search Materials";
            // 
            // poisonComboBox2
            // 
            this.poisonComboBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox2.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox2.FormattingEnabled = true;
            this.poisonComboBox2.ItemHeight = 23;
            this.poisonComboBox2.Items.AddRange(new object[] {
            "1st Semester Mid Term",
            "1st Semester Final Term",
            "2nd Semester Mid Term",
            "2nd Semester Final Term"});
            this.poisonComboBox2.Location = new System.Drawing.Point(676, 99);
            this.poisonComboBox2.Name = "poisonComboBox2";
            this.poisonComboBox2.PromptText = "Semester";
            this.poisonComboBox2.Size = new System.Drawing.Size(220, 29);
            this.poisonComboBox2.TabIndex = 76;
            this.poisonComboBox2.Text = "Semester";
            this.poisonComboBox2.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 37);
            this.label2.TabIndex = 77;
            this.label2.Text = "View Grades";
            // 
            // dgGradeCourseCode
            // 
            this.dgGradeCourseCode.HeaderText = "Course Code";
            this.dgGradeCourseCode.Name = "dgGradeCourseCode";
            this.dgGradeCourseCode.ReadOnly = true;
            this.dgGradeCourseCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgGradeCourseName
            // 
            this.dgGradeCourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgGradeCourseName.HeaderText = "Course Name";
            this.dgGradeCourseName.Name = "dgGradeCourseName";
            this.dgGradeCourseName.ReadOnly = true;
            this.dgGradeCourseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgGradeInstructor
            // 
            this.dgGradeInstructor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgGradeInstructor.HeaderText = "Instructor";
            this.dgGradeInstructor.Name = "dgGradeInstructor";
            this.dgGradeInstructor.ReadOnly = true;
            this.dgGradeInstructor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeUnits
            // 
            this.dgStudentGradeUnits.HeaderText = "Units";
            this.dgStudentGradeUnits.Name = "dgStudentGradeUnits";
            this.dgStudentGradeUnits.ReadOnly = true;
            this.dgStudentGradeUnits.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudentGradeUnits.Width = 50;
            // 
            // dgStudentGradeFinalGrade
            // 
            this.dgStudentGradeFinalGrade.HeaderText = "Final Grade";
            this.dgStudentGradeFinalGrade.Name = "dgStudentGradeFinalGrade";
            this.dgStudentGradeFinalGrade.ReadOnly = true;
            this.dgStudentGradeFinalGrade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeRemarks
            // 
            this.dgStudentGradeRemarks.HeaderText = "Remarks";
            this.dgStudentGradeRemarks.Name = "dgStudentGradeRemarks";
            this.dgStudentGradeRemarks.ReadOnly = true;
            this.dgStudentGradeRemarks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeDetails
            // 
            this.dgStudentGradeDetails.HeaderText = "Details";
            this.dgStudentGradeDetails.Name = "dgStudentGradeDetails";
            this.dgStudentGradeDetails.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudentGradeDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgStudentGradeDetails.Text = "View";
            this.dgStudentGradeDetails.UseColumnTextForButtonValue = true;
            // 
            // StudentViewGradePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.poisonComboBox2);
            this.Controls.Add(this.poisonComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.dgvStudentViewGrades);
            this.Controls.Add(this.label4);
            this.Name = "StudentViewGradePanel";
            this.Size = new System.Drawing.Size(987, 598);
            this.Load += new System.EventHandler(this.StudentViewGradePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentViewGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvStudentViewGrades;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGradeCourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGradeCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGradeInstructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeFinalGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeRemarks;
        private System.Windows.Forms.DataGridViewButtonColumn dgStudentGradeDetails;
    }
}
