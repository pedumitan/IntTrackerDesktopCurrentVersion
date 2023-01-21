namespace HillRobinsonTech
{
    partial class Permissions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permissions));
            this.PermissionView = new System.Windows.Forms.ListView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchcBox = new System.Windows.Forms.ComboBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.ClearSearchBtn = new System.Windows.Forms.Button();
            this.SearchApplybtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.containinglbl = new System.Windows.Forms.Label();
            this.TodaycheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentWeekcheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentMonthcheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PermissionView
            // 
            this.PermissionView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PermissionView.AllowColumnReorder = true;
            this.PermissionView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PermissionView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PermissionView.FullRowSelect = true;
            this.PermissionView.GridLines = true;
            this.PermissionView.HideSelection = false;
            this.PermissionView.LabelEdit = true;
            this.PermissionView.Location = new System.Drawing.Point(31, 114);
            this.PermissionView.Name = "PermissionView";
            this.PermissionView.Size = new System.Drawing.Size(1180, 699);
            this.PermissionView.TabIndex = 0;
            this.PermissionView.UseCompatibleStateImageBehavior = false;
            this.PermissionView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.IntTrackerView_ColumnClick);
            this.PermissionView.VisibleChanged += new System.EventHandler(this.Permissions_Load);
            this.PermissionView.DoubleClick += new System.EventHandler(this.PermissionView_DoubleClick);
            this.PermissionView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IntTrackerView_MouseClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(328, 34);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newbtn.Location = new System.Drawing.Point(31, 34);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(84, 28);
            this.newbtn.TabIndex = 29;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = false;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(237, 34);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 28);
            this.refreshBtn.TabIndex = 31;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "Internal Escalation - pdf";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem2.Text = "Contractor escalation - pdf";
            this.toolStripMenuItem2.Visible = false;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // showlbl
            // 
            this.showlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showlbl.AutoSize = true;
            this.showlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showlbl.Location = new System.Drawing.Point(1022, 870);
            this.showlbl.Name = "showlbl";
            this.showlbl.Size = new System.Drawing.Size(0, 16);
            this.showlbl.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Search in";
            // 
            // SearchcBox
            // 
            this.SearchcBox.Enabled = false;
            this.SearchcBox.FormattingEnabled = true;
            this.SearchcBox.Items.AddRange(new object[] {
            "ALL",
            "User",
            "Department",
            "Name",
            "Type"});
            this.SearchcBox.Location = new System.Drawing.Point(97, 24);
            this.SearchcBox.Name = "SearchcBox";
            this.SearchcBox.Size = new System.Drawing.Size(140, 21);
            this.SearchcBox.TabIndex = 45;
            // 
            // SearchTBox
            // 
            this.SearchTBox.Enabled = false;
            this.SearchTBox.Location = new System.Drawing.Point(361, 20);
            this.SearchTBox.Multiline = true;
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(163, 23);
            this.SearchTBox.TabIndex = 46;
            // 
            // ClearSearchBtn
            // 
            this.ClearSearchBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClearSearchBtn.Enabled = false;
            this.ClearSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearSearchBtn.ForeColor = System.Drawing.Color.Red;
            this.ClearSearchBtn.Location = new System.Drawing.Point(634, 17);
            this.ClearSearchBtn.Name = "ClearSearchBtn";
            this.ClearSearchBtn.Size = new System.Drawing.Size(75, 28);
            this.ClearSearchBtn.TabIndex = 47;
            this.ClearSearchBtn.Text = "Clear";
            this.ClearSearchBtn.UseVisualStyleBackColor = false;
            this.ClearSearchBtn.Click += new System.EventHandler(this.ClearSearchBtn_Click);
            // 
            // SearchApplybtn
            // 
            this.SearchApplybtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SearchApplybtn.Enabled = false;
            this.SearchApplybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchApplybtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.SearchApplybtn.Location = new System.Drawing.Point(543, 17);
            this.SearchApplybtn.Name = "SearchApplybtn";
            this.SearchApplybtn.Size = new System.Drawing.Size(75, 28);
            this.SearchApplybtn.TabIndex = 48;
            this.SearchApplybtn.Text = "Apply";
            this.SearchApplybtn.UseVisualStyleBackColor = false;
            this.SearchApplybtn.Click += new System.EventHandler(this.SearchApplybtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.containinglbl);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SearchcBox);
            this.groupBox2.Controls.Add(this.SearchTBox);
            this.groupBox2.Controls.Add(this.ClearSearchBtn);
            this.groupBox2.Controls.Add(this.SearchApplybtn);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(482, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 57);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extended search";
            // 
            // containinglbl
            // 
            this.containinglbl.AutoSize = true;
            this.containinglbl.Enabled = false;
            this.containinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containinglbl.Location = new System.Drawing.Point(252, 24);
            this.containinglbl.Name = "containinglbl";
            this.containinglbl.Size = new System.Drawing.Size(95, 20);
            this.containinglbl.TabIndex = 49;
            this.containinglbl.Text = "Containing";
            // 
            // TodaycheckBox
            // 
            this.TodaycheckBox.AutoSize = true;
            this.TodaycheckBox.Checked = true;
            this.TodaycheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodaycheckBox.Enabled = false;
            this.TodaycheckBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TodaycheckBox.Location = new System.Drawing.Point(74, 74);
            this.TodaycheckBox.Name = "TodaycheckBox";
            this.TodaycheckBox.Size = new System.Drawing.Size(73, 17);
            this.TodaycheckBox.TabIndex = 57;
            this.TodaycheckBox.Text = "Technical";
            this.TodaycheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentWeekcheckBox
            // 
            this.CurrentWeekcheckBox.AutoSize = true;
            this.CurrentWeekcheckBox.Checked = true;
            this.CurrentWeekcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CurrentWeekcheckBox.Enabled = false;
            this.CurrentWeekcheckBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentWeekcheckBox.Location = new System.Drawing.Point(162, 74);
            this.CurrentWeekcheckBox.Name = "CurrentWeekcheckBox";
            this.CurrentWeekcheckBox.Size = new System.Drawing.Size(95, 17);
            this.CurrentWeekcheckBox.TabIndex = 58;
            this.CurrentWeekcheckBox.Text = "Housekeeping";
            this.CurrentWeekcheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentMonthcheckBox
            // 
            this.CurrentMonthcheckBox.AutoSize = true;
            this.CurrentMonthcheckBox.Checked = true;
            this.CurrentMonthcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CurrentMonthcheckBox.Enabled = false;
            this.CurrentMonthcheckBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentMonthcheckBox.Location = new System.Drawing.Point(263, 74);
            this.CurrentMonthcheckBox.Name = "CurrentMonthcheckBox";
            this.CurrentMonthcheckBox.Size = new System.Drawing.Size(39, 17);
            this.CurrentMonthcheckBox.TabIndex = 59;
            this.CurrentMonthcheckBox.Text = "F&B";
            this.CurrentMonthcheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkBox1.Location = new System.Drawing.Point(308, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 60;
            this.checkBox1.Text = "Butlers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkBox2.Location = new System.Drawing.Point(372, 74);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(86, 17);
            this.checkBox2.TabIndex = 61;
            this.checkBox2.Text = "Procurement";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkBox3.Location = new System.Drawing.Point(31, 74);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(37, 17);
            this.checkBox3.TabIndex = 62;
            this.checkBox3.Text = "All";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 857);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CurrentMonthcheckBox);
            this.Controls.Add(this.CurrentWeekcheckBox);
            this.Controls.Add(this.TodaycheckBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.showlbl);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.PermissionView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Permissions";
            this.Text = "Permissions";
            this.Load += new System.EventHandler(this.IntTracker_Load_1);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView PermissionView;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label showlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchcBox;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Button ClearSearchBtn;
        private System.Windows.Forms.Button SearchApplybtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label containinglbl;
        private System.Windows.Forms.CheckBox TodaycheckBox;
        private System.Windows.Forms.CheckBox CurrentWeekcheckBox;
        private System.Windows.Forms.CheckBox CurrentMonthcheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

