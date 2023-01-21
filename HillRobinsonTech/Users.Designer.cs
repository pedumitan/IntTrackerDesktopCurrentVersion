namespace HillRobinsonTech
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.UserView = new System.Windows.Forms.ListView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.showlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchcBox = new System.Windows.Forms.ComboBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.ClearSearchBtn = new System.Windows.Forms.Button();
            this.SearchApplybtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.containinglbl = new System.Windows.Forms.Label();
            this.TechnicalcBox = new System.Windows.Forms.CheckBox();
            this.HKckBox = new System.Windows.Forms.CheckBox();
            this.FBcBox = new System.Windows.Forms.CheckBox();
            this.cBoxProcurement = new System.Windows.Forms.CheckBox();
            this.cBoxAll = new System.Windows.Forms.CheckBox();
            this.lbSession = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DeleteUsermenuStrip = new System.Windows.Forms.MenuStrip();
            this.cBoxCulinary = new System.Windows.Forms.CheckBox();
            this.lastLbl = new System.Windows.Forms.Label();
            this.prevLbl = new System.Windows.Forms.Label();
            this.nextLbl = new System.Windows.Forms.Label();
            this.firstLbl = new System.Windows.Forms.Label();
            this.totalPageslbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pagelbl = new System.Windows.Forms.Label();
            this.pgNrTbox = new System.Windows.Forms.TextBox();
            this.gBoxAll = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.gBoxAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserView
            // 
            this.UserView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.UserView.AllowColumnReorder = true;
            this.UserView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserView.FullRowSelect = true;
            this.UserView.GridLines = true;
            this.UserView.HideSelection = false;
            this.UserView.LabelEdit = true;
            this.UserView.Location = new System.Drawing.Point(31, 114);
            this.UserView.Name = "UserView";
            this.UserView.Size = new System.Drawing.Size(1180, 605);
            this.UserView.TabIndex = 0;
            this.UserView.UseCompatibleStateImageBehavior = false;
            this.UserView.VisibleChanged += new System.EventHandler(this.Users_Load);
            this.UserView.DoubleClick += new System.EventHandler(this.UserView_DoubleClick);
            this.UserView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserView_MouseClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(392, 34);
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
            this.refreshBtn.Location = new System.Drawing.Point(297, 34);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 28);
            this.refreshBtn.TabIndex = 31;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // showlbl
            // 
            this.showlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showlbl.AutoSize = true;
            this.showlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showlbl.Location = new System.Drawing.Point(1006, 747);
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
            // TechnicalcBox
            // 
            this.TechnicalcBox.AutoSize = true;
            this.TechnicalcBox.Enabled = false;
            this.TechnicalcBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TechnicalcBox.Location = new System.Drawing.Point(47, 10);
            this.TechnicalcBox.Name = "TechnicalcBox";
            this.TechnicalcBox.Size = new System.Drawing.Size(73, 17);
            this.TechnicalcBox.TabIndex = 57;
            this.TechnicalcBox.Text = "Technical";
            this.TechnicalcBox.UseVisualStyleBackColor = true;
            this.TechnicalcBox.CheckedChanged += new System.EventHandler(this.TechnicalcBox_CheckedChanged);
            // 
            // HKckBox
            // 
            this.HKckBox.AutoSize = true;
            this.HKckBox.Enabled = false;
            this.HKckBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HKckBox.Location = new System.Drawing.Point(135, 10);
            this.HKckBox.Name = "HKckBox";
            this.HKckBox.Size = new System.Drawing.Size(95, 17);
            this.HKckBox.TabIndex = 58;
            this.HKckBox.Text = "Housekeeping";
            this.HKckBox.UseVisualStyleBackColor = true;
            this.HKckBox.CheckedChanged += new System.EventHandler(this.HKckBox_CheckedChanged);
            // 
            // FBcBox
            // 
            this.FBcBox.AutoSize = true;
            this.FBcBox.Enabled = false;
            this.FBcBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FBcBox.Location = new System.Drawing.Point(236, 10);
            this.FBcBox.Name = "FBcBox";
            this.FBcBox.Size = new System.Drawing.Size(45, 17);
            this.FBcBox.TabIndex = 59;
            this.FBcBox.Text = "F&&B";
            this.FBcBox.UseVisualStyleBackColor = true;
            this.FBcBox.CheckedChanged += new System.EventHandler(this.FBcBox_CheckedChanged);
            // 
            // cBoxProcurement
            // 
            this.cBoxProcurement.AutoSize = true;
            this.cBoxProcurement.Enabled = false;
            this.cBoxProcurement.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cBoxProcurement.Location = new System.Drawing.Point(281, 10);
            this.cBoxProcurement.Name = "cBoxProcurement";
            this.cBoxProcurement.Size = new System.Drawing.Size(86, 17);
            this.cBoxProcurement.TabIndex = 61;
            this.cBoxProcurement.Text = "Procurement";
            this.cBoxProcurement.UseVisualStyleBackColor = true;
            this.cBoxProcurement.CheckedChanged += new System.EventHandler(this.cBoxProcurement_CheckedChanged);
            // 
            // cBoxAll
            // 
            this.cBoxAll.AutoSize = true;
            this.cBoxAll.Enabled = false;
            this.cBoxAll.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cBoxAll.Location = new System.Drawing.Point(9, 10);
            this.cBoxAll.Name = "cBoxAll";
            this.cBoxAll.Size = new System.Drawing.Size(37, 17);
            this.cBoxAll.TabIndex = 62;
            this.cBoxAll.Text = "All";
            this.cBoxAll.UseVisualStyleBackColor = true;
            this.cBoxAll.Click += new System.EventHandler(this.cBoxAll_Click);
            // 
            // lbSession
            // 
            this.lbSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSession.AutoSize = true;
            this.lbSession.BackColor = System.Drawing.Color.White;
            this.lbSession.Location = new System.Drawing.Point(924, 98);
            this.lbSession.Name = "lbSession";
            this.lbSession.Size = new System.Drawing.Size(82, 13);
            this.lbSession.TabIndex = 80;
            this.lbSession.Text = "Current session:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DeleteUsermenuStrip
            // 
            this.DeleteUsermenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteUsermenuStrip.Location = new System.Drawing.Point(0, 0);
            this.DeleteUsermenuStrip.Name = "DeleteUsermenuStrip";
            this.DeleteUsermenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.DeleteUsermenuStrip.ShowItemToolTips = true;
            this.DeleteUsermenuStrip.Size = new System.Drawing.Size(1253, 24);
            this.DeleteUsermenuStrip.TabIndex = 82;
            this.DeleteUsermenuStrip.Text = "Delete user";
            this.DeleteUsermenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DeleteUsermenuStrip_ItemClicked);
            // 
            // cBoxCulinary
            // 
            this.cBoxCulinary.AutoSize = true;
            this.cBoxCulinary.Enabled = false;
            this.cBoxCulinary.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cBoxCulinary.Location = new System.Drawing.Point(373, 10);
            this.cBoxCulinary.Name = "cBoxCulinary";
            this.cBoxCulinary.Size = new System.Drawing.Size(63, 17);
            this.cBoxCulinary.TabIndex = 83;
            this.cBoxCulinary.Text = "Culinary";
            this.cBoxCulinary.UseVisualStyleBackColor = true;
            this.cBoxCulinary.CheckedChanged += new System.EventHandler(this.cBoxCulinary_CheckedChanged);
            // 
            // lastLbl
            // 
            this.lastLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastLbl.AutoSize = true;
            this.lastLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lastLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lastLbl.Location = new System.Drawing.Point(176, 734);
            this.lastLbl.Name = "lastLbl";
            this.lastLbl.Size = new System.Drawing.Size(31, 13);
            this.lastLbl.TabIndex = 91;
            this.lastLbl.Text = "Last";
            this.lastLbl.Click += new System.EventHandler(this.lastLbl_Click);
            // 
            // prevLbl
            // 
            this.prevLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevLbl.AutoSize = true;
            this.prevLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.prevLbl.Location = new System.Drawing.Point(114, 734);
            this.prevLbl.Name = "prevLbl";
            this.prevLbl.Size = new System.Drawing.Size(56, 13);
            this.prevLbl.TabIndex = 90;
            this.prevLbl.Text = "Previous";
            this.prevLbl.Click += new System.EventHandler(this.prevLbl_Click);
            // 
            // nextLbl
            // 
            this.nextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextLbl.AutoSize = true;
            this.nextLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nextLbl.Location = new System.Drawing.Point(74, 734);
            this.nextLbl.Name = "nextLbl";
            this.nextLbl.Size = new System.Drawing.Size(33, 13);
            this.nextLbl.TabIndex = 89;
            this.nextLbl.Text = "Next";
            this.nextLbl.Click += new System.EventHandler(this.nextLbl_Click);
            // 
            // firstLbl
            // 
            this.firstLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstLbl.AutoSize = true;
            this.firstLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firstLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.firstLbl.Location = new System.Drawing.Point(37, 734);
            this.firstLbl.Name = "firstLbl";
            this.firstLbl.Size = new System.Drawing.Size(31, 13);
            this.firstLbl.TabIndex = 88;
            this.firstLbl.Text = "First";
            this.firstLbl.Click += new System.EventHandler(this.firstLbl_Click);
            // 
            // totalPageslbl
            // 
            this.totalPageslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPageslbl.AutoSize = true;
            this.totalPageslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPageslbl.Location = new System.Drawing.Point(150, 761);
            this.totalPageslbl.Name = "totalPageslbl";
            this.totalPageslbl.Size = new System.Drawing.Size(0, 13);
            this.totalPageslbl.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 761);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "of";
            // 
            // pagelbl
            // 
            this.pagelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pagelbl.AutoSize = true;
            this.pagelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagelbl.Location = new System.Drawing.Point(37, 761);
            this.pagelbl.Name = "pagelbl";
            this.pagelbl.Size = new System.Drawing.Size(36, 13);
            this.pagelbl.TabIndex = 85;
            this.pagelbl.Text = "Page";
            // 
            // pgNrTbox
            // 
            this.pgNrTbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgNrTbox.Location = new System.Drawing.Point(79, 758);
            this.pgNrTbox.Name = "pgNrTbox";
            this.pgNrTbox.Size = new System.Drawing.Size(33, 20);
            this.pgNrTbox.TabIndex = 84;
            this.pgNrTbox.Text = "1";
            // 
            // gBoxAll
            // 
            this.gBoxAll.Controls.Add(this.FBcBox);
            this.gBoxAll.Controls.Add(this.TechnicalcBox);
            this.gBoxAll.Controls.Add(this.HKckBox);
            this.gBoxAll.Controls.Add(this.cBoxProcurement);
            this.gBoxAll.Controls.Add(this.cBoxAll);
            this.gBoxAll.Controls.Add(this.cBoxCulinary);
            this.gBoxAll.Location = new System.Drawing.Point(31, 68);
            this.gBoxAll.Name = "gBoxAll";
            this.gBoxAll.Size = new System.Drawing.Size(436, 33);
            this.gBoxAll.TabIndex = 92;
            this.gBoxAll.TabStop = false;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 792);
            this.Controls.Add(this.gBoxAll);
            this.Controls.Add(this.lastLbl);
            this.Controls.Add(this.prevLbl);
            this.Controls.Add(this.nextLbl);
            this.Controls.Add(this.firstLbl);
            this.Controls.Add(this.totalPageslbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pagelbl);
            this.Controls.Add(this.pgNrTbox);
            this.Controls.Add(this.DeleteUsermenuStrip);
            this.Controls.Add(this.lbSession);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.showlbl);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.UserView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DeleteUsermenuStrip;
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.IntTracker_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gBoxAll.ResumeLayout(false);
            this.gBoxAll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView UserView;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label showlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchcBox;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Button ClearSearchBtn;
        private System.Windows.Forms.Button SearchApplybtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label containinglbl;
        private System.Windows.Forms.CheckBox TechnicalcBox;
        private System.Windows.Forms.CheckBox HKckBox;
        private System.Windows.Forms.CheckBox FBcBox;
        private System.Windows.Forms.CheckBox cBoxProcurement;
        private System.Windows.Forms.CheckBox cBoxAll;
        private System.Windows.Forms.Label lbSession;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip DeleteUsermenuStrip;
        private System.Windows.Forms.CheckBox cBoxCulinary;
        private System.Windows.Forms.Label lastLbl;
        private System.Windows.Forms.Label prevLbl;
        private System.Windows.Forms.Label nextLbl;
        private System.Windows.Forms.Label firstLbl;
        private System.Windows.Forms.Label totalPageslbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label pagelbl;
        private System.Windows.Forms.TextBox pgNrTbox;
        private System.Windows.Forms.GroupBox gBoxAll;
    }
}

