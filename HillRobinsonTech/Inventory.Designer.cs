namespace HillRobinsonTech
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.InventorySharmaView = new System.Windows.Forms.ListView();
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
            this.Delbtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventorySharmaView
            // 
            this.InventorySharmaView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.InventorySharmaView.AllowColumnReorder = true;
            this.InventorySharmaView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InventorySharmaView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventorySharmaView.FullRowSelect = true;
            this.InventorySharmaView.GridLines = true;
            this.InventorySharmaView.LabelEdit = true;
            this.InventorySharmaView.Location = new System.Drawing.Point(31, 114);
            this.InventorySharmaView.Name = "InventorySharmaView";
            this.InventorySharmaView.Size = new System.Drawing.Size(1180, 735);
            this.InventorySharmaView.TabIndex = 0;
            this.InventorySharmaView.UseCompatibleStateImageBehavior = false;
            this.InventorySharmaView.VisibleChanged += new System.EventHandler(this.InventorySharma_Load);
           // this.InventorySharmaView.DoubleClick += new System.EventHandler(this.UserView_DoubleClick);
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
            // Delbtn
            // 
            this.Delbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Delbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delbtn.ForeColor = System.Drawing.Color.Red;
            this.Delbtn.Location = new System.Drawing.Point(134, 34);
            this.Delbtn.Name = "Delbtn";
            this.Delbtn.Size = new System.Drawing.Size(84, 28);
            this.Delbtn.TabIndex = 63;
            this.Delbtn.Text = "Delete";
            this.Delbtn.UseVisualStyleBackColor = false;
            this.Delbtn.Click += new System.EventHandler(this.Delbtn_Click);
            // 
            // InventorySharma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 912);
            this.Controls.Add(this.Delbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.showlbl);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.InventorySharmaView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventorySharma";
            this.Text = "Inventory";
           // this.Load += new System.EventHandler(this.IntTracker_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView InventorySharmaView;
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
        private System.Windows.Forms.Button Delbtn;
    }
}

