namespace HillRobinsonTech
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btreset = new System.Windows.Forms.Button();
            this.cBoxguest = new System.Windows.Forms.CheckBox();
            this.btlogin = new System.Windows.Forms.Button();
            this.tBoxpass = new System.Windows.Forms.TextBox();
            this.tBoxuser = new System.Windows.Forms.TextBox();
            this.lbpass = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.cBoxCredentials = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnLocalServer = new System.Windows.Forms.RadioButton();
            this.rbtnCloudServer = new System.Windows.Forms.RadioButton();
            this.cBoxLocalList = new System.Windows.Forms.ComboBox();
            this.cBoxCloudList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btreset
            // 
            this.btreset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btreset.Location = new System.Drawing.Point(287, 304);
            this.btreset.Name = "btreset";
            this.btreset.Size = new System.Drawing.Size(87, 41);
            this.btreset.TabIndex = 28;
            this.btreset.Text = "Reset";
            this.btreset.UseVisualStyleBackColor = false;
            this.btreset.Click += new System.EventHandler(this.btreset_Click);
            // 
            // cBoxguest
            // 
            this.cBoxguest.AutoSize = true;
            this.cBoxguest.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cBoxguest.Location = new System.Drawing.Point(162, 178);
            this.cBoxguest.Name = "cBoxguest";
            this.cBoxguest.Size = new System.Drawing.Size(118, 17);
            this.cBoxguest.TabIndex = 27;
            this.cBoxguest.Text = "Connect as a guest";
            this.cBoxguest.UseVisualStyleBackColor = true;
            this.cBoxguest.CheckStateChanged += new System.EventHandler(this.cBoxguest_CheckStateChanged_1);
            // 
            // btlogin
            // 
            this.btlogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlogin.Location = new System.Drawing.Point(127, 304);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(87, 41);
            this.btlogin.TabIndex = 26;
            this.btlogin.Text = "Login";
            this.btlogin.UseVisualStyleBackColor = false;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // tBoxpass
            // 
            this.tBoxpass.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxpass.Location = new System.Drawing.Point(162, 134);
            this.tBoxpass.Name = "tBoxpass";
            this.tBoxpass.PasswordChar = '*';
            this.tBoxpass.Size = new System.Drawing.Size(190, 26);
            this.tBoxpass.TabIndex = 25;
            this.tBoxpass.UseSystemPasswordChar = true;
            this.tBoxpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxuser_KeyDown);
            // 
            // tBoxuser
            // 
            this.tBoxuser.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxuser.Location = new System.Drawing.Point(162, 86);
            this.tBoxuser.Name = "tBoxuser";
            this.tBoxuser.Size = new System.Drawing.Size(190, 26);
            this.tBoxuser.TabIndex = 24;
            this.tBoxuser.Click += new System.EventHandler(this.tBoxuser_Click);
            this.tBoxuser.TextChanged += new System.EventHandler(this.tBoxuser_TextChanged);
            this.tBoxuser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxuser_KeyDown);
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Font = new System.Drawing.Font("Centaur", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass.Location = new System.Drawing.Point(69, 139);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(62, 18);
            this.lbpass.TabIndex = 23;
            this.lbpass.Text = "Password";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Font = new System.Drawing.Font("Centaur", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbuser.Location = new System.Drawing.Point(69, 94);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(65, 18);
            this.lbuser.TabIndex = 22;
            this.lbuser.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(146, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Int Tracker Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Int Tracker Desktop version:  ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(109, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(177, 368);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(145, 13);
            this.linkLabel1.TabIndex = 32;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot password? New user?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(305, 398);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(54, 13);
            this.lblVersion.TabIndex = 33;
            this.lblVersion.Text = "4.2.3.23";
            // 
            // cBoxCredentials
            // 
            this.cBoxCredentials.AutoSize = true;
            this.cBoxCredentials.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cBoxCredentials.Location = new System.Drawing.Point(162, 201);
            this.cBoxCredentials.Name = "cBoxCredentials";
            this.cBoxCredentials.Size = new System.Drawing.Size(147, 17);
            this.cBoxCredentials.TabIndex = 34;
            this.cBoxCredentials.Text = "Remember my credentials";
            this.cBoxCredentials.UseVisualStyleBackColor = true;
            this.cBoxCredentials.CheckedChanged += new System.EventHandler(this.cBoxCredentials_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnCloudServer);
            this.groupBox1.Controls.Add(this.rbtnLocalServer);
            this.groupBox1.Location = new System.Drawing.Point(150, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 74);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rbtnLocalServer
            // 
            this.rbtnLocalServer.AutoSize = true;
            this.rbtnLocalServer.Checked = true;
            this.rbtnLocalServer.Location = new System.Drawing.Point(7, 10);
            this.rbtnLocalServer.Name = "rbtnLocalServer";
            this.rbtnLocalServer.Size = new System.Drawing.Size(51, 17);
            this.rbtnLocalServer.TabIndex = 36;
            this.rbtnLocalServer.TabStop = true;
            this.rbtnLocalServer.Text = "Local";
            this.rbtnLocalServer.UseVisualStyleBackColor = true;
            this.rbtnLocalServer.CheckedChanged += new System.EventHandler(this.rbtnLocalServer_CheckedChanged);
            // 
            // rbtnCloudServer
            // 
            this.rbtnCloudServer.AutoSize = true;
            this.rbtnCloudServer.Location = new System.Drawing.Point(6, 42);
            this.rbtnCloudServer.Name = "rbtnCloudServer";
            this.rbtnCloudServer.Size = new System.Drawing.Size(52, 17);
            this.rbtnCloudServer.TabIndex = 37;
            this.rbtnCloudServer.Text = "Cloud";
            this.rbtnCloudServer.UseVisualStyleBackColor = true;
            this.rbtnCloudServer.CheckedChanged += new System.EventHandler(this.rbtnCloudServer_CheckedChanged);
            // 
            // cBoxLocalList
            // 
            this.cBoxLocalList.FormattingEnabled = true;
            this.cBoxLocalList.Items.AddRange(new object[] {
            "10.19.107.154"});
            this.cBoxLocalList.Location = new System.Drawing.Point(231, 234);
            this.cBoxLocalList.Name = "cBoxLocalList";
            this.cBoxLocalList.Size = new System.Drawing.Size(121, 21);
            this.cBoxLocalList.TabIndex = 36;
            this.cBoxLocalList.Visible = false;
            // 
            // cBoxCloudList
            // 
            this.cBoxCloudList.FormattingEnabled = true;
            this.cBoxCloudList.Items.AddRange(new object[] {
            "188.213.133.2,1533"});
            this.cBoxCloudList.Location = new System.Drawing.Point(231, 266);
            this.cBoxCloudList.Name = "cBoxCloudList";
            this.cBoxCloudList.Size = new System.Drawing.Size(121, 21);
            this.cBoxCloudList.TabIndex = 37;
            this.cBoxCloudList.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 431);
            this.Controls.Add(this.cBoxCloudList);
            this.Controls.Add(this.cBoxLocalList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cBoxCredentials);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btreset);
            this.Controls.Add(this.cBoxguest);
            this.Controls.Add(this.btlogin);
            this.Controls.Add(this.tBoxpass);
            this.Controls.Add(this.tBoxuser);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbuser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btreset;
        private System.Windows.Forms.CheckBox cBoxguest;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.TextBox tBoxpass;
        private System.Windows.Forms.TextBox tBoxuser;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox cBoxCredentials;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCloudServer;
        private System.Windows.Forms.RadioButton rbtnLocalServer;
        private System.Windows.Forms.ComboBox cBoxLocalList;
        private System.Windows.Forms.ComboBox cBoxCloudList;
    }
}