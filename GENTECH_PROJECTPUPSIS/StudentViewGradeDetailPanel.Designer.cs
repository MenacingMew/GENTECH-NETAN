namespace GENTECH_PROJECTPUPSIS
{
    partial class StudentViewGradeDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentViewGradeDetailPanel));
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblRemarks = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblFinalGrade = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblInstructor = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCourse = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvStudentViewGradeDetails = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgStudentGradeViewAssessment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeViewMarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeViewTotalMarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentGradeViewDetailsPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentViewGradeDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Location = new System.Drawing.Point(921, 20);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(49, 44);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.TabIndex = 46;
            this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
            this.kryptonButton4.Values.Text = "";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = false;
            this.lblRemarks.Location = new System.Drawing.Point(770, 105);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(168, 35);
            this.lblRemarks.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRemarks.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.TabIndex = 45;
            this.lblRemarks.Values.Text = "Remarks:";
            // 
            // lblFinalGrade
            // 
            this.lblFinalGrade.AutoSize = false;
            this.lblFinalGrade.Location = new System.Drawing.Point(587, 105);
            this.lblFinalGrade.Name = "lblFinalGrade";
            this.lblFinalGrade.Size = new System.Drawing.Size(168, 35);
            this.lblFinalGrade.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFinalGrade.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalGrade.TabIndex = 44;
            this.lblFinalGrade.Values.Text = "Final Grade:";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = false;
            this.lblInstructor.Location = new System.Drawing.Point(227, 105);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(220, 35);
            this.lblInstructor.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInstructor.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.TabIndex = 43;
            this.lblInstructor.Values.Text = "Instructor:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = false;
            this.lblCourse.Location = new System.Drawing.Point(39, 105);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(182, 35);
            this.lblCourse.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCourse.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.TabIndex = 42;
            this.lblCourse.Values.Text = "Course:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(17, 155);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(953, 1);
            this.panel5.TabIndex = 39;
            // 
            // dgvStudentViewGradeDetails
            // 
            this.dgvStudentViewGradeDetails.AllowUserToAddRows = false;
            this.dgvStudentViewGradeDetails.AllowUserToDeleteRows = false;
            this.dgvStudentViewGradeDetails.AllowUserToResizeColumns = false;
            this.dgvStudentViewGradeDetails.AllowUserToResizeRows = false;
            this.dgvStudentViewGradeDetails.ColumnHeadersHeight = 50;
            this.dgvStudentViewGradeDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgStudentGradeViewAssessment,
            this.dgStudentGradeViewMarks,
            this.dgStudentGradeViewTotalMarks,
            this.dgStudentGradeViewDetailsPercentage});
            this.dgvStudentViewGradeDetails.Location = new System.Drawing.Point(39, 172);
            this.dgvStudentViewGradeDetails.Name = "dgvStudentViewGradeDetails";
            this.dgvStudentViewGradeDetails.RowHeadersVisible = false;
            this.dgvStudentViewGradeDetails.RowTemplate.Height = 45;
            this.dgvStudentViewGradeDetails.Size = new System.Drawing.Size(732, 365);
            this.dgvStudentViewGradeDetails.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvStudentViewGradeDetails.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvStudentViewGradeDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvStudentViewGradeDetails.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentViewGradeDetails.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentViewGradeDetails.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvStudentViewGradeDetails.TabIndex = 41;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Location = new System.Drawing.Point(17, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(425, 56);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Maroon;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 40;
            this.kryptonLabel1.Values.Text = "Here\'s your grade overview !";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(17, 564);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(953, 1);
            this.panel3.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(17, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(953, 1);
            this.panel4.TabIndex = 37;
            // 
            // dgStudentGradeViewAssessment
            // 
            this.dgStudentGradeViewAssessment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgStudentGradeViewAssessment.HeaderText = "Assessment";
            this.dgStudentGradeViewAssessment.Name = "dgStudentGradeViewAssessment";
            this.dgStudentGradeViewAssessment.ReadOnly = true;
            this.dgStudentGradeViewAssessment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeViewMarks
            // 
            this.dgStudentGradeViewMarks.HeaderText = "Earned Mark";
            this.dgStudentGradeViewMarks.Name = "dgStudentGradeViewMarks";
            this.dgStudentGradeViewMarks.ReadOnly = true;
            this.dgStudentGradeViewMarks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeViewTotalMarks
            // 
            this.dgStudentGradeViewTotalMarks.HeaderText = "Total Marks";
            this.dgStudentGradeViewTotalMarks.Name = "dgStudentGradeViewTotalMarks";
            this.dgStudentGradeViewTotalMarks.ReadOnly = true;
            this.dgStudentGradeViewTotalMarks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentGradeViewDetailsPercentage
            // 
            this.dgStudentGradeViewDetailsPercentage.HeaderText = "Percentage";
            this.dgStudentGradeViewDetailsPercentage.Name = "dgStudentGradeViewDetailsPercentage";
            this.dgStudentGradeViewDetailsPercentage.ReadOnly = true;
            this.dgStudentGradeViewDetailsPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StudentViewGradeDetailPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblFinalGrade);
            this.Controls.Add(this.lblInstructor);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dgvStudentViewGradeDetails);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Name = "StudentViewGradeDetailPanel";
            this.Size = new System.Drawing.Size(987, 598);
            this.Load += new System.EventHandler(this.StudentViewGradeDetailPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentViewGradeDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFinalGrade;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblInstructor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCourse;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvStudentViewGradeDetails;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeViewAssessment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeViewMarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeViewTotalMarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentGradeViewDetailsPercentage;
    }
}
