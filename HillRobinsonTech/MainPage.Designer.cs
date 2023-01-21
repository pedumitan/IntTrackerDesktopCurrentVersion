namespace HillRobinsonTech
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.btIntTrackerAY = new System.Windows.Forms.Button();
            this.btContacts = new System.Windows.Forms.Button();
            this.ceas = new System.Windows.Forms.Timer(this.components);
            this.Clocklbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbcopyright = new System.Windows.Forms.Label();
            this.lbversiune = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btIntTrackerSharma = new System.Windows.Forms.Button();
            this.lbSession = new System.Windows.Forms.Label();
            this.pBoxIntTrackerSharma = new System.Windows.Forms.PictureBox();
            this.pBoxContacts = new System.Windows.Forms.PictureBox();
            this.pBoxIntTrackerAY = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionHillRobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentSession = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIntTrackerSharma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIntTrackerAY)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btIntTrackerAY
            // 
            this.btIntTrackerAY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btIntTrackerAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btIntTrackerAY.Location = new System.Drawing.Point(256, 392);
            this.btIntTrackerAY.MaximumSize = new System.Drawing.Size(134, 54);
            this.btIntTrackerAY.Name = "btIntTrackerAY";
            this.btIntTrackerAY.Size = new System.Drawing.Size(134, 54);
            this.btIntTrackerAY.TabIndex = 1;
            this.btIntTrackerAY.Text = " Int Tracker\r\nAl Yamamah";
            this.btIntTrackerAY.UseVisualStyleBackColor = true;
            this.btIntTrackerAY.Click += new System.EventHandler(this.IntTrackerbtn_Click);
            // 
            // btContacts
            // 
            this.btContacts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btContacts.Location = new System.Drawing.Point(712, 392);
            this.btContacts.MaximumSize = new System.Drawing.Size(134, 54);
            this.btContacts.Name = "btContacts";
            this.btContacts.Size = new System.Drawing.Size(134, 54);
            this.btContacts.TabIndex = 5;
            this.btContacts.Text = "Contacts";
            this.btContacts.UseVisualStyleBackColor = true;
            this.btContacts.Click += new System.EventHandler(this.ContactsBtn_Click);
            // 
            // ceas
            // 
            this.ceas.Enabled = true;
            this.ceas.Interval = 1000;
            this.ceas.Tick += new System.EventHandler(this.lblClock_Click);
            // 
            // Clocklbl
            // 
            this.Clocklbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clocklbl.BackColor = System.Drawing.Color.Transparent;
            this.Clocklbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Clocklbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clocklbl.Location = new System.Drawing.Point(1333, 57);
            this.Clocklbl.Name = "Clocklbl";
            this.Clocklbl.Size = new System.Drawing.Size(169, 40);
            this.Clocklbl.TabIndex = 7;
            this.Clocklbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Clocklbl.Click += new System.EventHandler(this.lblClock_Click);
            this.Clocklbl.Validated += new System.EventHandler(this.lblClock_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1579, 702);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "@PeduSoft";
            // 
            // lbcopyright
            // 
            this.lbcopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbcopyright.AutoSize = true;
            this.lbcopyright.BackColor = System.Drawing.Color.Transparent;
            this.lbcopyright.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbcopyright.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbcopyright.Location = new System.Drawing.Point(533, 672);
            this.lbcopyright.Name = "lbcopyright";
            this.lbcopyright.Size = new System.Drawing.Size(420, 44);
            this.lbcopyright.TabIndex = 12;
            this.lbcopyright.Text = "  © 2020 - 2023 Tech Int Tracker by Florentin Mitan\r\n                            " +
    "  All Rights Reserved\r\n";
            // 
            // lbversiune
            // 
            this.lbversiune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbversiune.AutoSize = true;
            this.lbversiune.BackColor = System.Drawing.Color.Transparent;
            this.lbversiune.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbversiune.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbversiune.Location = new System.Drawing.Point(1405, 724);
            this.lbversiune.Name = "lbversiune";
            this.lbversiune.Size = new System.Drawing.Size(0, 22);
            this.lbversiune.TabIndex = 13;
            this.lbversiune.VisibleChanged += new System.EventHandler(this.lbversiune_VisibleChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btIntTrackerSharma
            // 
            this.btIntTrackerSharma.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btIntTrackerSharma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btIntTrackerSharma.Location = new System.Drawing.Point(1167, 392);
            this.btIntTrackerSharma.MaximumSize = new System.Drawing.Size(134, 54);
            this.btIntTrackerSharma.Name = "btIntTrackerSharma";
            this.btIntTrackerSharma.Size = new System.Drawing.Size(134, 54);
            this.btIntTrackerSharma.TabIndex = 14;
            this.btIntTrackerSharma.Text = "Int Tracker\r\n  Neom";
            this.btIntTrackerSharma.UseVisualStyleBackColor = true;
            this.btIntTrackerSharma.Click += new System.EventHandler(this.btIntTrackerSharma_Click);
            // 
            // lbSession
            // 
            this.lbSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSession.AutoSize = true;
            this.lbSession.BackColor = System.Drawing.Color.White;
            this.lbSession.Location = new System.Drawing.Point(1005, 9);
            this.lbSession.Name = "lbSession";
            this.lbSession.Size = new System.Drawing.Size(124, 20);
            this.lbSession.TabIndex = 80;
            this.lbSession.Text = "Current session:";
            // 
            // pBoxIntTrackerSharma
            // 
            this.pBoxIntTrackerSharma.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pBoxIntTrackerSharma.Image = ((System.Drawing.Image)(resources.GetObject("pBoxIntTrackerSharma.Image")));
            this.pBoxIntTrackerSharma.Location = new System.Drawing.Point(1123, 200);
            this.pBoxIntTrackerSharma.MaximumSize = new System.Drawing.Size(224, 157);
            this.pBoxIntTrackerSharma.Name = "pBoxIntTrackerSharma";
            this.pBoxIntTrackerSharma.Size = new System.Drawing.Size(224, 157);
            this.pBoxIntTrackerSharma.TabIndex = 15;
            this.pBoxIntTrackerSharma.TabStop = false;
            this.pBoxIntTrackerSharma.Click += new System.EventHandler(this.pBoxIntTrackerSharma_Click);
            // 
            // pBoxContacts
            // 
            this.pBoxContacts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pBoxContacts.Image = ((System.Drawing.Image)(resources.GetObject("pBoxContacts.Image")));
            this.pBoxContacts.Location = new System.Drawing.Point(663, 200);
            this.pBoxContacts.MaximumSize = new System.Drawing.Size(224, 157);
            this.pBoxContacts.Name = "pBoxContacts";
            this.pBoxContacts.Size = new System.Drawing.Size(224, 157);
            this.pBoxContacts.TabIndex = 6;
            this.pBoxContacts.TabStop = false;
            this.pBoxContacts.Click += new System.EventHandler(this.pBoxContacts_Click);
            // 
            // pBoxIntTrackerAY
            // 
            this.pBoxIntTrackerAY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pBoxIntTrackerAY.Image = ((System.Drawing.Image)(resources.GetObject("pBoxIntTrackerAY.Image")));
            this.pBoxIntTrackerAY.Location = new System.Drawing.Point(212, 200);
            this.pBoxIntTrackerAY.MaximumSize = new System.Drawing.Size(224, 157);
            this.pBoxIntTrackerAY.Name = "pBoxIntTrackerAY";
            this.pBoxIntTrackerAY.Size = new System.Drawing.Size(224, 157);
            this.pBoxIntTrackerAY.TabIndex = 2;
            this.pBoxIntTrackerAY.TabStop = false;
            this.pBoxIntTrackerAY.Click += new System.EventHandler(this.pBoxIntTrackerAY_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.signInToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.AdminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1525, 31);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elevToolStripMenuItem,
            this.ContactsToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.addToolStripMenuItem.Text = "Open";
            // 
            // elevToolStripMenuItem
            // 
            this.elevToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aYToolStripMenuItem,
            this.sharmaToolStripMenuItem});
            this.elevToolStripMenuItem.Name = "elevToolStripMenuItem";
            this.elevToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.elevToolStripMenuItem.Text = "Int Tracker";
            // 
            // aYToolStripMenuItem
            // 
            this.aYToolStripMenuItem.Name = "aYToolStripMenuItem";
            this.aYToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.aYToolStripMenuItem.Text = "AY";
            this.aYToolStripMenuItem.Click += new System.EventHandler(this.aYToolStripMenuItem_Click);
            // 
            // sharmaToolStripMenuItem
            // 
            this.sharmaToolStripMenuItem.Name = "sharmaToolStripMenuItem";
            this.sharmaToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.sharmaToolStripMenuItem.Text = "Sharma";
            this.sharmaToolStripMenuItem.Click += new System.EventHandler(this.sharmaToolStripMenuItem_Click);
            // 
            // ContactsToolStripMenuItem
            // 
            this.ContactsToolStripMenuItem.Name = "ContactsToolStripMenuItem";
            this.ContactsToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.ContactsToolStripMenuItem.Text = "Contacts";
            this.ContactsToolStripMenuItem.Click += new System.EventHandler(this.ContactsToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Visible = false;
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Visible = false;
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.signInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageAccountToolStripMenuItem,
            this.signOutToolStripMenuItem1});
            this.signInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signInToolStripMenuItem.Image")));
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.signInToolStripMenuItem.Text = "Account";
            this.signInToolStripMenuItem.Click += new System.EventHandler(this.signInToolStripMenuItem_Click);
            // 
            // manageAccountToolStripMenuItem
            // 
            this.manageAccountToolStripMenuItem.Name = "manageAccountToolStripMenuItem";
            this.manageAccountToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.manageAccountToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.manageAccountToolStripMenuItem.Text = "Manage your account";
            this.manageAccountToolStripMenuItem.Click += new System.EventHandler(this.manageAccountToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem1
            // 
            this.signOutToolStripMenuItem1.Name = "signOutToolStripMenuItem1";
            this.signOutToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.signOutToolStripMenuItem1.Text = "Sign out";
            this.signOutToolStripMenuItem1.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionHillRobToolStripMenuItem,
            this.howToUseToolStripMenuItem,
            this.liToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.helpToolStripMenuItem.Text = "About";
            // 
            // versionHillRobToolStripMenuItem
            // 
            this.versionHillRobToolStripMenuItem.Name = "versionHillRobToolStripMenuItem";
            this.versionHillRobToolStripMenuItem.Size = new System.Drawing.Size(324, 26);
            this.versionHillRobToolStripMenuItem.Text = "Int Tracker System Desktop Version";
            this.versionHillRobToolStripMenuItem.Click += new System.EventHandler(this.versionHillRobToolStripMenuItem_Click);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(324, 26);
            this.howToUseToolStripMenuItem.Text = "How to use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // liToolStripMenuItem
            // 
            this.liToolStripMenuItem.Enabled = false;
            this.liToolStripMenuItem.Name = "liToolStripMenuItem";
            this.liToolStripMenuItem.Size = new System.Drawing.Size(324, 26);
            this.liToolStripMenuItem.Text = "License";
            this.liToolStripMenuItem.Click += new System.EventHandler(this.liToolStripMenuItem_Click);
            // 
            // AdminToolStripMenuItem
            // 
            this.AdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem1,
            this.rolesToolStripMenuItem,
            this.permissionsToolStripMenuItem1,
            this.locationsToolStripMenuItem,
            this.departmentsToolStripMenuItem,
            this.historyLogToolStripMenuItem});
            this.AdminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem";
            this.AdminToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.AdminToolStripMenuItem.Text = "Admin";
            this.AdminToolStripMenuItem.Visible = false;
            this.AdminToolStripMenuItem.Click += new System.EventHandler(this.AdminToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.usersToolStripMenuItem1.Text = "Users";
            this.usersToolStripMenuItem1.Click += new System.EventHandler(this.usersToolStripMenuItem1_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Visible = false;
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // permissionsToolStripMenuItem1
            // 
            this.permissionsToolStripMenuItem1.Name = "permissionsToolStripMenuItem1";
            this.permissionsToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.permissionsToolStripMenuItem1.Text = "Permissions";
            this.permissionsToolStripMenuItem1.Visible = false;
            this.permissionsToolStripMenuItem1.Click += new System.EventHandler(this.permissionsToolStripMenuItem1_Click);
            // 
            // locationsToolStripMenuItem
            // 
            this.locationsToolStripMenuItem.Name = "locationsToolStripMenuItem";
            this.locationsToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.locationsToolStripMenuItem.Text = "Locations";
            this.locationsToolStripMenuItem.Visible = false;
            this.locationsToolStripMenuItem.Click += new System.EventHandler(this.locationsToolStripMenuItem_Click);
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.departmentsToolStripMenuItem.Text = "Departments";
            this.departmentsToolStripMenuItem.Visible = false;
            // 
            // historyLogToolStripMenuItem
            // 
            this.historyLogToolStripMenuItem.Name = "historyLogToolStripMenuItem";
            this.historyLogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.historyLogToolStripMenuItem.Text = "History Log";
            this.historyLogToolStripMenuItem.Visible = false;
            // 
            // lblCurrentSession
            // 
            this.lblCurrentSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentSession.AutoSize = true;
            this.lblCurrentSession.BackColor = System.Drawing.Color.White;
            this.lblCurrentSession.Location = new System.Drawing.Point(763, 9);
            this.lblCurrentSession.Name = "lblCurrentSession";
            this.lblCurrentSession.Size = new System.Drawing.Size(124, 20);
            this.lblCurrentSession.TabIndex = 81;
            this.lblCurrentSession.Text = "Current session:";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1525, 746);
            this.Controls.Add(this.lblCurrentSession);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbSession);
            this.Controls.Add(this.pBoxIntTrackerSharma);
            this.Controls.Add(this.btIntTrackerSharma);
            this.Controls.Add(this.lbversiune);
            this.Controls.Add(this.lbcopyright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clocklbl);
            this.Controls.Add(this.pBoxContacts);
            this.Controls.Add(this.btContacts);
            this.Controls.Add(this.pBoxIntTrackerAY);
            this.Controls.Add(this.btIntTrackerAY);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "Main Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIntTrackerSharma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIntTrackerAY)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btIntTrackerAY;
        private System.Windows.Forms.PictureBox pBoxIntTrackerAY;
        private System.Windows.Forms.PictureBox pBoxContacts;
        private System.Windows.Forms.Button btContacts;
        private System.Windows.Forms.Timer ceas;
        private System.Windows.Forms.Label Clocklbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbcopyright;
        private System.Windows.Forms.Label lbversiune;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pBoxIntTrackerSharma;
        private System.Windows.Forms.Button btIntTrackerSharma;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionHillRobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.Label lbSession;
        private System.Windows.Forms.Label lblCurrentSession;
        private System.Windows.Forms.ToolStripMenuItem historyLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        //private System.Windows.Forms.Label lbconnect;
        //private System.Windows.Forms.Label label2;
    }
}

