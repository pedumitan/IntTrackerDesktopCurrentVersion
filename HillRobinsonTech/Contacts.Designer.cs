namespace HillRobinsonTech
{
    partial class Contacts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contacts));
            this.ContactsView = new System.Windows.Forms.ListView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.showlbl = new System.Windows.Forms.Label();
            this.ResetFilterbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchcBox = new System.Windows.Forms.ComboBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.ClearSearchBtn = new System.Windows.Forms.Button();
            this.SearchApplybtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.containinglbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentPageExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wholeListExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pgNrTbox = new System.Windows.Forms.TextBox();
            this.pagelbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalPageslbl = new System.Windows.Forms.Label();
            this.firstLbl = new System.Windows.Forms.Label();
            this.nextLbl = new System.Windows.Forms.Label();
            this.prevLbl = new System.Windows.Forms.Label();
            this.lastLbl = new System.Windows.Forms.Label();
            this.infoBtn = new System.Windows.Forms.Button();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxLocations = new System.Windows.Forms.GroupBox();
            this.rBtnSharma = new System.Windows.Forms.RadioButton();
            this.rBtnAlYamama = new System.Windows.Forms.RadioButton();
            this.gBoxQfilter = new System.Windows.Forms.GroupBox();
            this.cBoxAll = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gBoxLocations.SuspendLayout();
            this.gBoxQfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactsView
            // 
            this.ContactsView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ContactsView.AllowColumnReorder = true;
            this.ContactsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsView.AutoArrange = false;
            this.ContactsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactsView.FullRowSelect = true;
            this.ContactsView.GridLines = true;
            this.ContactsView.HideSelection = false;
            this.ContactsView.LabelEdit = true;
            this.ContactsView.Location = new System.Drawing.Point(31, 151);
            this.ContactsView.Name = "ContactsView";
            this.ContactsView.Size = new System.Drawing.Size(1297, 522);
            this.ContactsView.TabIndex = 0;
            this.ContactsView.UseCompatibleStateImageBehavior = false;
            this.ContactsView.View = System.Windows.Forms.View.Details;
            this.ContactsView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ContactsView_ColumnClick);
            this.ContactsView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ContactsView_ItemChecked);
            this.ContactsView.SelectedIndexChanged += new System.EventHandler(this.ContactsView_SelectedIndexChanged);
            this.ContactsView.VisibleChanged += new System.EventHandler(this.Contacts_Load);
            this.ContactsView.DoubleClick += new System.EventHandler(this.ContactsView_DoubleClick);
            this.ContactsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContactsView_MouseClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(1203, 47);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(1107, 47);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 41;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showlbl
            // 
            this.showlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showlbl.AutoSize = true;
            this.showlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showlbl.Location = new System.Drawing.Point(1082, 710);
            this.showlbl.Name = "showlbl";
            this.showlbl.Size = new System.Drawing.Size(0, 16);
            this.showlbl.TabIndex = 42;
            // 
            // ResetFilterbtn
            // 
            this.ResetFilterbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ResetFilterbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetFilterbtn.ForeColor = System.Drawing.Color.Red;
            this.ResetFilterbtn.Location = new System.Drawing.Point(122, 19);
            this.ResetFilterbtn.Name = "ResetFilterbtn";
            this.ResetFilterbtn.Size = new System.Drawing.Size(84, 28);
            this.ResetFilterbtn.TabIndex = 43;
            this.ResetFilterbtn.Text = "Reset";
            this.ResetFilterbtn.UseVisualStyleBackColor = false;
            this.ResetFilterbtn.Click += new System.EventHandler(this.ResetFilterbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Search in";
            // 
            // SearchcBox
            // 
            this.SearchcBox.FormattingEnabled = true;
            this.SearchcBox.Items.AddRange(new object[] {
            "ALL",
            "Status",
            "Location",
            "Reported by",
            "Priority",
            "Department Ref",
            "Assigned to",
            "Escalated to",
            "Department"});
            this.SearchcBox.Location = new System.Drawing.Point(97, 24);
            this.SearchcBox.Name = "SearchcBox";
            this.SearchcBox.Size = new System.Drawing.Size(140, 21);
            this.SearchcBox.TabIndex = 45;
            // 
            // SearchTBox
            // 
            this.SearchTBox.Location = new System.Drawing.Point(361, 20);
            this.SearchTBox.Multiline = true;
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(163, 23);
            this.SearchTBox.TabIndex = 46;
            this.SearchTBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTBox_KeyDown);
            // 
            // ClearSearchBtn
            // 
            this.ClearSearchBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ResetFilterbtn);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(779, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 57);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multi filters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.containinglbl);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SearchcBox);
            this.groupBox2.Controls.Add(this.SearchTBox);
            this.groupBox2.Controls.Add(this.ClearSearchBtn);
            this.groupBox2.Controls.Add(this.SearchApplybtn);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(31, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 57);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extended search";
            // 
            // containinglbl
            // 
            this.containinglbl.AutoSize = true;
            this.containinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containinglbl.Location = new System.Drawing.Point(252, 24);
            this.containinglbl.Name = "containinglbl";
            this.containinglbl.Size = new System.Drawing.Size(95, 20);
            this.containinglbl.TabIndex = 49;
            this.containinglbl.Text = "Containing";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.ExportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1370, 29);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.AutoToolTip = true;
            this.addNewToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addNewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(57, 25);
            this.addNewToolStripMenuItem.Text = "New";
            this.addNewToolStripMenuItem.ToolTipText = "Insert new record";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.pDFToolStripMenuItem});
            this.ExportToolStripMenuItem.Enabled = false;
            this.ExportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.ExportToolStripMenuItem.Text = "Export";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentPageExcelToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.wholeListExcelToolStripMenuItem});
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.excelToolStripMenuItem.Text = "Excel";
            // 
            // currentPageExcelToolStripMenuItem
            // 
            this.currentPageExcelToolStripMenuItem.Name = "currentPageExcelToolStripMenuItem";
            this.currentPageExcelToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.currentPageExcelToolStripMenuItem.Text = "Current page";
            this.currentPageExcelToolStripMenuItem.Click += new System.EventHandler(this.currentPageToolStripMenuItem_Click);
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Enabled = false;
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // wholeListExcelToolStripMenuItem
            // 
            this.wholeListExcelToolStripMenuItem.Name = "wholeListExcelToolStripMenuItem";
            this.wholeListExcelToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.wholeListExcelToolStripMenuItem.Text = "Whole list";
            this.wholeListExcelToolStripMenuItem.Click += new System.EventHandler(this.wholeListExcelToolStripMenuItem_Click);
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Enabled = false;
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.pDFToolStripMenuItem.Text = "PDF";
            // 
            // pgNrTbox
            // 
            this.pgNrTbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgNrTbox.Location = new System.Drawing.Point(80, 724);
            this.pgNrTbox.Name = "pgNrTbox";
            this.pgNrTbox.Size = new System.Drawing.Size(33, 20);
            this.pgNrTbox.TabIndex = 64;
            this.pgNrTbox.Text = "1";
            this.pgNrTbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pgNrTbox_KeyDown);
            // 
            // pagelbl
            // 
            this.pagelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pagelbl.AutoSize = true;
            this.pagelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagelbl.Location = new System.Drawing.Point(38, 727);
            this.pagelbl.Name = "pagelbl";
            this.pagelbl.Size = new System.Drawing.Size(36, 13);
            this.pagelbl.TabIndex = 65;
            this.pagelbl.Text = "Page";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 727);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "of";
            // 
            // totalPageslbl
            // 
            this.totalPageslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPageslbl.AutoSize = true;
            this.totalPageslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPageslbl.Location = new System.Drawing.Point(151, 727);
            this.totalPageslbl.Name = "totalPageslbl";
            this.totalPageslbl.Size = new System.Drawing.Size(0, 13);
            this.totalPageslbl.TabIndex = 69;
            // 
            // firstLbl
            // 
            this.firstLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstLbl.AutoSize = true;
            this.firstLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firstLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.firstLbl.Location = new System.Drawing.Point(38, 700);
            this.firstLbl.Name = "firstLbl";
            this.firstLbl.Size = new System.Drawing.Size(31, 13);
            this.firstLbl.TabIndex = 72;
            this.firstLbl.Text = "First";
            this.firstLbl.Click += new System.EventHandler(this.firstLbl_Click);
            // 
            // nextLbl
            // 
            this.nextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextLbl.AutoSize = true;
            this.nextLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nextLbl.Location = new System.Drawing.Point(75, 700);
            this.nextLbl.Name = "nextLbl";
            this.nextLbl.Size = new System.Drawing.Size(33, 13);
            this.nextLbl.TabIndex = 73;
            this.nextLbl.Text = "Next";
            this.nextLbl.Click += new System.EventHandler(this.nextLbl_Click);
            // 
            // prevLbl
            // 
            this.prevLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevLbl.AutoSize = true;
            this.prevLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.prevLbl.Location = new System.Drawing.Point(115, 700);
            this.prevLbl.Name = "prevLbl";
            this.prevLbl.Size = new System.Drawing.Size(56, 13);
            this.prevLbl.TabIndex = 74;
            this.prevLbl.Text = "Previous";
            this.prevLbl.Click += new System.EventHandler(this.prevLbl_Click);
            // 
            // lastLbl
            // 
            this.lastLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastLbl.AutoSize = true;
            this.lastLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lastLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lastLbl.Location = new System.Drawing.Point(177, 700);
            this.lastLbl.Name = "lastLbl";
            this.lastLbl.Size = new System.Drawing.Size(31, 13);
            this.lastLbl.TabIndex = 75;
            this.lastLbl.Text = "Last";
            this.lastLbl.Click += new System.EventHandler(this.lastLbl_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoBtn.Enabled = false;
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.Location = new System.Drawing.Point(1320, 44);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(38, 37);
            this.infoBtn.TabIndex = 76;
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            this.infoBtn.MouseHover += new System.EventHandler(this.infoBtn_MouseHover);
            // 
            // gBoxLocations
            // 
            this.gBoxLocations.Controls.Add(this.rBtnSharma);
            this.gBoxLocations.Controls.Add(this.rBtnAlYamama);
            this.gBoxLocations.Enabled = false;
            this.gBoxLocations.Location = new System.Drawing.Point(31, 95);
            this.gBoxLocations.Name = "gBoxLocations";
            this.gBoxLocations.Size = new System.Drawing.Size(232, 45);
            this.gBoxLocations.TabIndex = 77;
            this.gBoxLocations.TabStop = false;
            this.gBoxLocations.Text = "Location";
            // 
            // rBtnSharma
            // 
            this.rBtnSharma.AutoSize = true;
            this.rBtnSharma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnSharma.Location = new System.Drawing.Point(123, 18);
            this.rBtnSharma.Name = "rBtnSharma";
            this.rBtnSharma.Size = new System.Drawing.Size(67, 17);
            this.rBtnSharma.TabIndex = 79;
            this.rBtnSharma.Text = "Sharma";
            this.rBtnSharma.UseVisualStyleBackColor = true;
            this.rBtnSharma.CheckedChanged += new System.EventHandler(this.rBtnSharma_CheckedChanged);
            // 
            // rBtnAlYamama
            // 
            this.rBtnAlYamama.AutoSize = true;
            this.rBtnAlYamama.Checked = true;
            this.rBtnAlYamama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnAlYamama.Location = new System.Drawing.Point(6, 18);
            this.rBtnAlYamama.Name = "rBtnAlYamama";
            this.rBtnAlYamama.Size = new System.Drawing.Size(87, 17);
            this.rBtnAlYamama.TabIndex = 78;
            this.rBtnAlYamama.TabStop = true;
            this.rBtnAlYamama.Text = "Al Yamama";
            this.rBtnAlYamama.UseVisualStyleBackColor = true;
            this.rBtnAlYamama.CheckedChanged += new System.EventHandler(this.rBtnAlYamama_CheckedChanged);
            // 
            // gBoxQfilter
            // 
            this.gBoxQfilter.Controls.Add(this.cBoxAll);
            this.gBoxQfilter.Enabled = false;
            this.gBoxQfilter.Location = new System.Drawing.Point(269, 95);
            this.gBoxQfilter.Name = "gBoxQfilter";
            this.gBoxQfilter.Size = new System.Drawing.Size(733, 45);
            this.gBoxQfilter.TabIndex = 78;
            this.gBoxQfilter.TabStop = false;
            this.gBoxQfilter.Text = "Quick filter";
            // 
            // cBoxAll
            // 
            this.cBoxAll.AutoSize = true;
            this.cBoxAll.Enabled = false;
            this.cBoxAll.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cBoxAll.Location = new System.Drawing.Point(305, 17);
            this.cBoxAll.Name = "cBoxAll";
            this.cBoxAll.Size = new System.Drawing.Size(37, 17);
            this.cBoxAll.TabIndex = 85;
            this.cBoxAll.Text = "All";
            this.cBoxAll.UseVisualStyleBackColor = true;
            this.cBoxAll.CheckedChanged += new System.EventHandler(this.cBoxAll_CheckedChanged);
            // 
            // Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.gBoxQfilter);
            this.Controls.Add(this.gBoxLocations);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.lastLbl);
            this.Controls.Add(this.prevLbl);
            this.Controls.Add(this.nextLbl);
            this.Controls.Add(this.firstLbl);
            this.Controls.Add(this.totalPageslbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pagelbl);
            this.Controls.Add(this.pgNrTbox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showlbl);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ContactsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Contacts";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.Contacts_Load_1);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBoxLocations.ResumeLayout(false);
            this.gBoxLocations.PerformLayout();
            this.gBoxQfilter.ResumeLayout(false);
            this.gBoxQfilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ContactsView;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label showlbl;
        private System.Windows.Forms.Button ResetFilterbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchcBox;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Button ClearSearchBtn;
        private System.Windows.Forms.Button SearchApplybtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label containinglbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.TextBox pgNrTbox;
        private System.Windows.Forms.Label pagelbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalPageslbl;
        private System.Windows.Forms.Label firstLbl;
        private System.Windows.Forms.Label nextLbl;
        private System.Windows.Forms.Label prevLbl;
        private System.Windows.Forms.Label lastLbl;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.ToolTip infoToolTip;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentPageExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wholeListExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBoxLocations;
        private System.Windows.Forms.RadioButton rBtnSharma;
        private System.Windows.Forms.RadioButton rBtnAlYamama;
        private System.Windows.Forms.GroupBox gBoxQfilter;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.CheckBox cBoxAll;
    }
}

