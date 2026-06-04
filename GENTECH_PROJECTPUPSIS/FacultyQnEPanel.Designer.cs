namespace GENTECH_PROJECTPUPSIS
{
    partial class FacultyQnEPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyQnEPanel));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvQnEList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgFacultryQneTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyQneType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyQneItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyQneTimeLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyQneDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFacultyQneStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQnEList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "BSIT 2-2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(547, 37);
            this.label4.TabIndex = 71;
            this.label4.Text = "INTE 201 - Object Oriented Programming";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(23, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(356, 27);
            this.label19.TabIndex = 70;
            this.label19.Text = "Here\'s the list of your created exams and quizzes\r\n\r\n";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvQnEList
            // 
            this.dgvQnEList.AllowUserToAddRows = false;
            this.dgvQnEList.AllowUserToDeleteRows = false;
            this.dgvQnEList.AllowUserToResizeColumns = false;
            this.dgvQnEList.AllowUserToResizeRows = false;
            this.dgvQnEList.ColumnHeadersHeight = 50;
            this.dgvQnEList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgFacultryQneTitle,
            this.dgFacultyQneType,
            this.dgFacultyQneItems,
            this.dgFacultyQneTimeLimit,
            this.dgFacultyQneDeadline,
            this.dgFacultyQneStatus});
            this.dgvQnEList.Location = new System.Drawing.Point(26, 166);
            this.dgvQnEList.Name = "dgvQnEList";
            this.dgvQnEList.RowHeadersVisible = false;
            this.dgvQnEList.RowTemplate.Height = 40;
            this.dgvQnEList.Size = new System.Drawing.Size(955, 427);
            this.dgvQnEList.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvQnEList.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvQnEList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvQnEList.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvQnEList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQnEList.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvQnEList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DarkRed;
            this.dgvQnEList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Maroon;
            this.dgvQnEList.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear40;
            this.dgvQnEList.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.DarkRed;
            this.dgvQnEList.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Maroon;
            this.dgvQnEList.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvQnEList.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvQnEList.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvQnEList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQnEList.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.dgvQnEList.TabIndex = 63;
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Location = new System.Drawing.Point(932, 18);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(49, 44);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.TabIndex = 68;
            this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
            this.kryptonButton4.Values.Text = "";
            // 
            // poisonComboBox1
            // 
            this.poisonComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonComboBox1.ForeColor = System.Drawing.Color.LightGray;
            this.poisonComboBox1.FormattingEnabled = true;
            this.poisonComboBox1.ItemHeight = 23;
            this.poisonComboBox1.Location = new System.Drawing.Point(463, 130);
            this.poisonComboBox1.Name = "poisonComboBox1";
            this.poisonComboBox1.PromptText = "Filter By";
            this.poisonComboBox1.Size = new System.Drawing.Size(220, 29);
            this.poisonComboBox1.TabIndex = 78;
            this.poisonComboBox1.Text = "Filter By";
            this.poisonComboBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(33, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 77;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(26, 130);
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
            this.kryptonTextBox1.TabIndex = 76;
            this.kryptonTextBox1.Text = "Search";
            // 
            // dgFacultryQneTitle
            // 
            this.dgFacultryQneTitle.FillWeight = 523.8578F;
            this.dgFacultryQneTitle.HeaderText = "Title";
            this.dgFacultryQneTitle.Name = "dgFacultryQneTitle";
            this.dgFacultryQneTitle.ReadOnly = true;
            this.dgFacultryQneTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFacultryQneTitle.Width = 200;
            // 
            // dgFacultyQneType
            // 
            this.dgFacultyQneType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyQneType.FillWeight = 15.22843F;
            this.dgFacultyQneType.HeaderText = "Type";
            this.dgFacultyQneType.Name = "dgFacultyQneType";
            this.dgFacultyQneType.ReadOnly = true;
            this.dgFacultyQneType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyQneItems
            // 
            this.dgFacultyQneItems.FillWeight = 15.22843F;
            this.dgFacultyQneItems.HeaderText = "Items";
            this.dgFacultyQneItems.Name = "dgFacultyQneItems";
            this.dgFacultyQneItems.ReadOnly = true;
            this.dgFacultyQneItems.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyQneTimeLimit
            // 
            this.dgFacultyQneTimeLimit.FillWeight = 15.22843F;
            this.dgFacultyQneTimeLimit.HeaderText = "Time Limit";
            this.dgFacultyQneTimeLimit.Name = "dgFacultyQneTimeLimit";
            this.dgFacultyQneTimeLimit.ReadOnly = true;
            this.dgFacultyQneTimeLimit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyQneDeadline
            // 
            this.dgFacultyQneDeadline.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyQneDeadline.FillWeight = 15.22843F;
            this.dgFacultyQneDeadline.HeaderText = "Deadline";
            this.dgFacultyQneDeadline.Name = "dgFacultyQneDeadline";
            this.dgFacultyQneDeadline.ReadOnly = true;
            this.dgFacultyQneDeadline.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgFacultyQneStatus
            // 
            this.dgFacultyQneStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgFacultyQneStatus.FillWeight = 15.22843F;
            this.dgFacultyQneStatus.HeaderText = "Status";
            this.dgFacultyQneStatus.Name = "dgFacultyQneStatus";
            this.dgFacultyQneStatus.ReadOnly = true;
            this.dgFacultyQneStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FacultyQnEPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.poisonComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dgvQnEList);
            this.Controls.Add(this.kryptonButton4);
            this.Name = "FacultyQnEPanel";
            this.Size = new System.Drawing.Size(1002, 609);
            this.Load += new System.EventHandler(this.FacultyQnEPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQnEList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvQnEList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultryQneTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyQneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyQneItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyQneTimeLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyQneDeadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFacultyQneStatus;
    }
}
