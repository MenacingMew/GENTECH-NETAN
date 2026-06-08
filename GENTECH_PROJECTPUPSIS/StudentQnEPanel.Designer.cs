namespace GENTECH_PROJECTPUPSIS
{
    partial class StudentQnEPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentQnEPanel));
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvQneList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgQuizInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTotalItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEarnedMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStudentAction = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQneList)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(21, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(547, 37);
            this.label4.TabIndex = 64;
            this.label4.Text = "INTE 201 - Object Oriented Programming";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(25, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(356, 27);
            this.label19.TabIndex = 63;
            this.label19.Text = "Here is the list of quizzes and exams that you can take.\r\n\r\n";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvQneList
            // 
            this.dgvQneList.AllowUserToAddRows = false;
            this.dgvQneList.AllowUserToDeleteRows = false;
            this.dgvQneList.AllowUserToResizeColumns = false;
            this.dgvQneList.AllowUserToResizeRows = false;
            this.dgvQneList.ColumnHeadersHeight = 50;
            this.dgvQneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgQuizInfo,
            this.dgTotalItems,
            this.dgStudentDeadline,
            this.dgEarnedMark,
            this.dgStudentAction});
            this.dgvQneList.Location = new System.Drawing.Point(28, 166);
            this.dgvQneList.Name = "dgvQneList";
            this.dgvQneList.RowHeadersVisible = false;
            this.dgvQneList.RowTemplate.Height = 50;
            this.dgvQneList.Size = new System.Drawing.Size(930, 413);
            this.dgvQneList.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvQneList.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvQneList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvQneList.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvQneList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQneList.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dgvQneList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvQneList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvQneList.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvQneList.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvQneList.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvQneList.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvQneList.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvQneList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQneList.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvQneList.TabIndex = 66;
            this.dgvQneList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQneList_CellContentClick);
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Location = new System.Drawing.Point(465, 130);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter";
            this.poisonComboBox1.Size = new System.Drawing.Size(280, 29);
            this.poisonComboBox1.TabIndex = 69;
            this.poisonComboBox1.Text = "Filter";
            this.poisonComboBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(35, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 68;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(28, 130);
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
            this.kryptonTextBox1.TabIndex = 67;
            this.kryptonTextBox1.Text = "Search Materials";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Location = new System.Drawing.Point(909, 13);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(49, 46);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.TabIndex = 70;
            this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
            this.kryptonButton4.Values.Text = "";
            // 
            // dgQuizInfo
            // 
            this.dgQuizInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgQuizInfo.HeaderText = "Quiz Info";
            this.dgQuizInfo.Name = "dgQuizInfo";
            this.dgQuizInfo.ReadOnly = true;
            this.dgQuizInfo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgTotalItems
            // 
            this.dgTotalItems.HeaderText = "Total Items";
            this.dgTotalItems.Name = "dgTotalItems";
            this.dgTotalItems.ReadOnly = true;
            this.dgTotalItems.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentDeadline
            // 
            this.dgStudentDeadline.HeaderText = "Deadline";
            this.dgStudentDeadline.Name = "dgStudentDeadline";
            this.dgStudentDeadline.ReadOnly = true;
            this.dgStudentDeadline.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudentDeadline.Width = 200;
            // 
            // dgEarnedMark
            // 
            this.dgEarnedMark.HeaderText = "Earned Mark";
            this.dgEarnedMark.Name = "dgEarnedMark";
            this.dgEarnedMark.ReadOnly = true;
            this.dgEarnedMark.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgStudentAction
            // 
            this.dgStudentAction.HeaderText = "Action";
            this.dgStudentAction.Name = "dgStudentAction";
            this.dgStudentAction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudentAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgStudentAction.Width = 150;
            // 
            // StudentQnEPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.poisonComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.dgvQneList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label19);
            this.Name = "StudentQnEPanel";
            this.Size = new System.Drawing.Size(987, 598);
            this.Load += new System.EventHandler(this.StudentQnEPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQneList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvQneList;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuizInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTotalItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStudentDeadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEarnedMark;
        private System.Windows.Forms.DataGridViewButtonColumn dgStudentAction;
    }
}
