namespace GENTECH_PROJECTPUPSIS
{
    partial class StudentActivityList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentActivityList));
            this.dgvStudentAssignmentList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgTaskInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentTotalPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentTaskDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGradingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSubmissionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentTaskAction = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAssignmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentAssignmentList
            // 
            this.dgvStudentAssignmentList.AllowUserToAddRows = false;
            this.dgvStudentAssignmentList.AllowUserToDeleteRows = false;
            this.dgvStudentAssignmentList.AllowUserToResizeColumns = false;
            this.dgvStudentAssignmentList.AllowUserToResizeRows = false;
            this.dgvStudentAssignmentList.ColumnHeadersHeight = 50;
            this.dgvStudentAssignmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgTaskInfo,
            this.dgStudentTaskType,
            this.dgStudentTotalPoints,
            this.dgStudentTaskDue,
            this.dgGradingStatus,
            this.dgSubmissionStatus,
            this.dgStudentTaskAction});
            this.dgvStudentAssignmentList.Location = new System.Drawing.Point(15, 184);
            this.dgvStudentAssignmentList.Name = "dgvStudentAssignmentList";
            this.dgvStudentAssignmentList.RowHeadersVisible = false;
            this.dgvStudentAssignmentList.RowTemplate.Height = 40;
            this.dgvStudentAssignmentList.Size = new System.Drawing.Size(957, 399);
            this.dgvStudentAssignmentList.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvStudentAssignmentList.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvStudentAssignmentList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvStudentAssignmentList.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvStudentAssignmentList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentAssignmentList.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudentAssignmentList.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, -1);
            this.dgvStudentAssignmentList.TabIndex = 32;
            this.dgvStudentAssignmentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentAssignmentList_CellContentClick);
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Location = new System.Drawing.Point(452, 148);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter";
            this.poisonComboBox1.Size = new System.Drawing.Size(280, 29);
            this.poisonComboBox1.TabIndex = 72;
            this.poisonComboBox1.Text = "Filter";
            this.poisonComboBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(22, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 71;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(15, 148);
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
            this.kryptonTextBox1.TabIndex = 70;
            this.kryptonTextBox1.Text = "Search Materials";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 37);
            this.label2.TabIndex = 74;
            this.label2.Text = "INTE 201 - Object Oriented Programming";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(22, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(415, 27);
            this.label19.TabIndex = 73;
            this.label19.Text = "Here is the list of Activities and Assignments that you can take.\r\n\r\n";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Location = new System.Drawing.Point(914, 18);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(49, 44);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.TabIndex = 75;
            this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
            this.kryptonButton4.Values.Text = "";
            // 
            // dgTaskInfo
            // 
            this.dgTaskInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgTaskInfo.HeaderText = "Task Name";
            this.dgTaskInfo.Name = "dgTaskInfo";
            // 
            // dgStudentTaskType
            // 
            this.dgStudentTaskType.HeaderText = "Type";
            this.dgStudentTaskType.Name = "dgStudentTaskType";
            // 
            // dgStudentTotalPoints
            // 
            this.dgStudentTotalPoints.HeaderText = "Total Points";
            this.dgStudentTotalPoints.Name = "dgStudentTotalPoints";
            this.dgStudentTotalPoints.Width = 80;
            // 
            // dgStudentTaskDue
            // 
            this.dgStudentTaskDue.HeaderText = "Deadline";
            this.dgStudentTaskDue.Name = "dgStudentTaskDue";
            this.dgStudentTaskDue.Width = 120;
            // 
            // dgGradingStatus
            // 
            this.dgGradingStatus.HeaderText = "Status";
            this.dgGradingStatus.Name = "dgGradingStatus";
            this.dgGradingStatus.Width = 80;
            // 
            // dgSubmissionStatus
            // 
            this.dgSubmissionStatus.HeaderText = "Submission Status";
            this.dgSubmissionStatus.Name = "dgSubmissionStatus";
            this.dgSubmissionStatus.Width = 150;
            // 
            // dgStudentTaskAction
            // 
            this.dgStudentTaskAction.HeaderText = "Action";
            this.dgStudentTaskAction.Name = "dgStudentTaskAction";
            this.dgStudentTaskAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStudentTaskAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgStudentTaskAction.Width = 120;
            // 
            // StudentActivityList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.poisonComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.dgvStudentAssignmentList);
            this.Name = "StudentActivityList";
            this.Size = new System.Drawing.Size(987, 598);
            this.Load += new System.EventHandler(this.StudentActivityList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAssignmentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvStudentAssignmentList;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTaskInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentTotalPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentTaskDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGradingStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSubmissionStatus;
        private System.Windows.Forms.DataGridViewButtonColumn dgStudentTaskAction;
    }
}
