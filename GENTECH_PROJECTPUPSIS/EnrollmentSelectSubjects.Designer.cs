namespace GENTECH_PROJECTPUPSIS
{
    partial class EnrollmentSelectSubjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollmentSelectSubjects));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProceedEnroll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dvgEnrollment = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgTodaysSchedCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaysSchedClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTodaySched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnrollment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnProceedEnroll);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 65);
            this.panel1.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(229, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 23, 0, 0);
            this.label1.Size = new System.Drawing.Size(168, 53);
            this.label1.TabIndex = 38;
            this.label1.Text = "Select Subjects";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProceedEnroll
            // 
            this.btnProceedEnroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnProceedEnroll.FlatAppearance.BorderSize = 0;
            this.btnProceedEnroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProceedEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedEnroll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProceedEnroll.ForeColor = System.Drawing.Color.Maroon;
            this.btnProceedEnroll.Image = ((System.Drawing.Image)(resources.GetObject("btnProceedEnroll.Image")));
            this.btnProceedEnroll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProceedEnroll.Location = new System.Drawing.Point(888, 0);
            this.btnProceedEnroll.Margin = new System.Windows.Forms.Padding(2);
            this.btnProceedEnroll.Name = "btnProceedEnroll";
            this.btnProceedEnroll.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnProceedEnroll.Size = new System.Drawing.Size(114, 65);
            this.btnProceedEnroll.TabIndex = 37;
            this.btnProceedEnroll.Text = "Proceed";
            this.btnProceedEnroll.UseVisualStyleBackColor = true;
            this.btnProceedEnroll.Click += new System.EventHandler(this.btnProceedEnroll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label4.Size = new System.Drawing.Size(229, 58);
            this.label4.TabIndex = 36;
            this.label4.Text = "Enrollment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(30, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 28);
            this.label5.TabIndex = 56;
            this.label5.Text = "Available Subjects";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dvgEnrollment
            // 
            this.dvgEnrollment.AllowUserToAddRows = false;
            this.dvgEnrollment.AllowUserToDeleteRows = false;
            this.dvgEnrollment.AllowUserToResizeColumns = false;
            this.dvgEnrollment.AllowUserToResizeRows = false;
            this.dvgEnrollment.ColumnHeadersHeight = 45;
            this.dvgEnrollment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgTodaysSchedCourse,
            this.dgTodaysSchedClass,
            this.Description,
            this.Units,
            this.dgTodaySched});
            this.dvgEnrollment.Location = new System.Drawing.Point(35, 120);
            this.dvgEnrollment.Name = "dvgEnrollment";
            this.dvgEnrollment.RowHeadersVisible = false;
            this.dvgEnrollment.RowTemplate.Height = 40;
            this.dvgEnrollment.Size = new System.Drawing.Size(933, 444);
            this.dvgEnrollment.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dvgEnrollment.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dvgEnrollment.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dvgEnrollment.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgEnrollment.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgEnrollment.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dvgEnrollment.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dvgEnrollment.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dvgEnrollment.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dvgEnrollment.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dvgEnrollment.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dvgEnrollment.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgEnrollment.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dvgEnrollment.TabIndex = 150;
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
            // EnrollmentSelectSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dvgEnrollment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Name = "EnrollmentSelectSubjects";
            this.Size = new System.Drawing.Size(1002, 609);
            this.Load += new System.EventHandler(this.EnrollmentSelectSubjects_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnrollment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProceedEnroll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dvgEnrollment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaysSchedClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTodaySched;
    }
}
