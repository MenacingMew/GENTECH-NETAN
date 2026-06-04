namespace GENTECH_PROJECTPUPSIS
{
    partial class FacultyAssignmentsPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyAssignmentsPanel));
            this.dgvAssActList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgFacultyTasksTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyAssignmentTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyAssignmentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyAssignmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssActList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssActList
            // 
            this.dgvAssActList.AllowUserToAddRows = false;
            this.dgvAssActList.AllowUserToDeleteRows = false;
            this.dgvAssActList.AllowUserToResizeColumns = false;
            this.dgvAssActList.AllowUserToResizeRows = false;
            this.dgvAssActList.ColumnHeadersHeight = 50;
            this.dgvAssActList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgFacultyTasksTitle,
            this.dgFacultyAssignmentTypes,
            this.dgFacultyAssignmentDue,
            this.dgFacultyAssignmentStatus});
            this.dgvAssActList.Location = new System.Drawing.Point(22, 122);
            this.dgvAssActList.Name = "dgvAssActList";
            this.dgvAssActList.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAssActList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssActList.RowTemplate.Height = 40;
            this.dgvAssActList.Size = new System.Drawing.Size(945, 454);
            this.dgvAssActList.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvAssActList.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvAssActList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvAssActList.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvAssActList.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvAssActList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAssActList.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvAssActList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvAssActList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvAssActList.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear40;
            this.dgvAssActList.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvAssActList.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvAssActList.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvAssActList.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvAssActList.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvAssActList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAssActList.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvAssActList.TabIndex = 29;
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Location = new System.Drawing.Point(918, 17);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(49, 44);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.TabIndex = 73;
            this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
            this.kryptonButton4.Values.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 37);
            this.label3.TabIndex = 74;
            this.label3.Text = "Assignments and Activities";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Location = new System.Drawing.Point(459, 86);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter By";
            this.poisonComboBox1.Size = new System.Drawing.Size(220, 29);
            this.poisonComboBox1.TabIndex = 81;
            this.poisonComboBox1.Text = "Filter By";
            this.poisonComboBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(29, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 80;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(22, 86);
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
            this.kryptonTextBox1.TabIndex = 79;
            this.kryptonTextBox1.Text = "Search";
            // 
            // dgFacultyTasksTitle
            // 
            this.dgFacultyTasksTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyTasksTitle.HeaderText = "Title";
            this.dgFacultyTasksTitle.Name = "dgFacultyTasksTitle";
            this.dgFacultyTasksTitle.ReadOnly = true;
            this.dgFacultyTasksTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyAssignmentTypes
            // 
            this.dgFacultyAssignmentTypes.HeaderText = "Type";
            this.dgFacultyAssignmentTypes.Name = "dgFacultyAssignmentTypes";
            this.dgFacultyAssignmentTypes.ReadOnly = true;
            this.dgFacultyAssignmentTypes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyAssignmentDue
            // 
            this.dgFacultyAssignmentDue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyAssignmentDue.HeaderText = "Due Date";
            this.dgFacultyAssignmentDue.Name = "dgFacultyAssignmentDue";
            this.dgFacultyAssignmentDue.ReadOnly = true;
            this.dgFacultyAssignmentDue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyAssignmentStatus
            // 
            this.dgFacultyAssignmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyAssignmentStatus.HeaderText = "Status";
            this.dgFacultyAssignmentStatus.Name = "dgFacultyAssignmentStatus";
            this.dgFacultyAssignmentStatus.ReadOnly = true;
            this.dgFacultyAssignmentStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FacultyAssignmentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.poisonComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.dgvAssActList);
            this.Name = "FacultyAssignmentsPanel";
            this.Size = new System.Drawing.Size(987, 598);
            this.Load += new System.EventHandler(this.FacultyAssignmentsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssActList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAssActList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyTasksTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyAssignmentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyAssignmentDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyAssignmentStatus;
    }
}
