namespace HillRobinsonTech
{
    partial class UserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEdit));
            this.passlb = new System.Windows.Forms.Label();
            this.issueDesclb = new System.Windows.Forms.Label();
            this.PassTBox = new System.Windows.Forms.TextBox();
            this.statuslb = new System.Windows.Forms.Label();
            this.TrackIdlb = new System.Windows.Forms.Label();
            this.UserIdtbox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.prioritylbl = new System.Windows.Forms.Label();
            this.departmentCBox = new System.Windows.Forms.ComboBox();
            this.UsertBox = new System.Windows.Forms.TextBox();
            this.NametBox = new System.Windows.Forms.TextBox();
            this.EmailtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confPassTBox = new System.Windows.Forms.TextBox();
            this.TypeCBox = new System.Windows.Forms.ComboBox();
            this.oldPasslb = new System.Windows.Forms.Label();
            this.oldPassTBox = new System.Windows.Forms.TextBox();
            this.genRanPasslLabel = new System.Windows.Forms.LinkLabel();
            this.lbActive = new System.Windows.Forms.Label();
            this.cBoxActive = new System.Windows.Forms.CheckBox();
            this.inValidationPicBox = new System.Windows.Forms.PictureBox();
            this.validationPicBox = new System.Windows.Forms.PictureBox();
            this.cBoxProject = new System.Windows.Forms.ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cBoxPosition = new System.Windows.Forms.ComboBox();
            this.llbPosition = new System.Windows.Forms.Label();
            this.btbDelete = new System.Windows.Forms.Button();
            this.cBoxRole = new System.Windows.Forms.ComboBox();
            this.lbRole = new System.Windows.Forms.Label();
            this.tabControlUsers = new System.Windows.Forms.TabControl();
            this.tabUserEdit = new System.Windows.Forms.TabPage();
            this.tabUserPermission = new System.Windows.Forms.TabPage();
            this.checkedListBoxPermissions = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.inValidationPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validationPicBox)).BeginInit();
            this.tabControlUsers.SuspendLayout();
            this.tabUserEdit.SuspendLayout();
            this.tabUserPermission.SuspendLayout();
            this.SuspendLayout();
            // 
            // passlb
            // 
            this.passlb.AutoSize = true;
            this.passlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passlb.Location = new System.Drawing.Point(25, 185);
            this.passlb.Name = "passlb";
            this.passlb.Size = new System.Drawing.Size(112, 20);
            this.passlb.TabIndex = 63;
            this.passlb.Text = "New password";
            // 
            // issueDesclb
            // 
            this.issueDesclb.AutoSize = true;
            this.issueDesclb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueDesclb.Location = new System.Drawing.Point(25, 258);
            this.issueDesclb.Name = "issueDesclb";
            this.issueDesclb.Size = new System.Drawing.Size(78, 20);
            this.issueDesclb.TabIndex = 67;
            this.issueDesclb.Text = "Full name";
            // 
            // PassTBox
            // 
            this.PassTBox.Enabled = false;
            this.PassTBox.Location = new System.Drawing.Point(161, 185);
            this.PassTBox.Name = "PassTBox";
            this.PassTBox.Size = new System.Drawing.Size(209, 20);
            this.PassTBox.TabIndex = 14;
            this.PassTBox.UseSystemPasswordChar = true;
            // 
            // statuslb
            // 
            this.statuslb.AutoSize = true;
            this.statuslb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslb.Location = new System.Drawing.Point(25, 49);
            this.statuslb.Name = "statuslb";
            this.statuslb.Size = new System.Drawing.Size(94, 20);
            this.statuslb.TabIndex = 57;
            this.statuslb.Text = "Department";
            // 
            // TrackIdlb
            // 
            this.TrackIdlb.AutoSize = true;
            this.TrackIdlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackIdlb.Location = new System.Drawing.Point(25, 14);
            this.TrackIdlb.Name = "TrackIdlb";
            this.TrackIdlb.Size = new System.Drawing.Size(23, 20);
            this.TrackIdlb.TabIndex = 55;
            this.TrackIdlb.Text = "Id";
            // 
            // UserIdtbox
            // 
            this.UserIdtbox.Enabled = false;
            this.UserIdtbox.Location = new System.Drawing.Point(161, 16);
            this.UserIdtbox.Name = "UserIdtbox";
            this.UserIdtbox.Size = new System.Drawing.Size(67, 20);
            this.UserIdtbox.TabIndex = 10;
            this.UserIdtbox.VisibleChanged += new System.EventHandler(this.UserEdit_Load);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(399, 514);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(297, 514);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 28);
            this.savebtn.TabIndex = 25;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // prioritylbl
            // 
            this.prioritylbl.AutoSize = true;
            this.prioritylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prioritylbl.Location = new System.Drawing.Point(25, 113);
            this.prioritylbl.Name = "prioritylbl";
            this.prioritylbl.Size = new System.Drawing.Size(43, 20);
            this.prioritylbl.TabIndex = 59;
            this.prioritylbl.Text = "User";
            // 
            // departmentCBox
            // 
            this.departmentCBox.FormattingEnabled = true;
            this.departmentCBox.ItemHeight = 13;
            this.departmentCBox.Items.AddRange(new object[] {
            "Technical",
            "F&B",
            "Housekeeping",
            "Procurement",
            "Culinary"});
            this.departmentCBox.Location = new System.Drawing.Point(161, 52);
            this.departmentCBox.Name = "departmentCBox";
            this.departmentCBox.Size = new System.Drawing.Size(209, 21);
            this.departmentCBox.TabIndex = 11;
            // 
            // UsertBox
            // 
            this.UsertBox.Location = new System.Drawing.Point(161, 116);
            this.UsertBox.Name = "UsertBox";
            this.UsertBox.Size = new System.Drawing.Size(209, 20);
            this.UsertBox.TabIndex = 12;
            // 
            // NametBox
            // 
            this.NametBox.Location = new System.Drawing.Point(161, 258);
            this.NametBox.Name = "NametBox";
            this.NametBox.Size = new System.Drawing.Size(209, 20);
            this.NametBox.TabIndex = 16;
            // 
            // EmailtBox
            // 
            this.EmailtBox.Location = new System.Drawing.Point(161, 292);
            this.EmailtBox.Name = "EmailtBox";
            this.EmailtBox.Size = new System.Drawing.Size(209, 20);
            this.EmailtBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "User type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 40);
            this.label3.TabIndex = 65;
            this.label3.Text = "Confirm \r\npassword";
            // 
            // confPassTBox
            // 
            this.confPassTBox.Enabled = false;
            this.confPassTBox.Location = new System.Drawing.Point(161, 222);
            this.confPassTBox.Name = "confPassTBox";
            this.confPassTBox.Size = new System.Drawing.Size(209, 20);
            this.confPassTBox.TabIndex = 15;
            this.confPassTBox.UseSystemPasswordChar = true;
            this.confPassTBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TypeCBox
            // 
            this.TypeCBox.FormattingEnabled = true;
            this.TypeCBox.Items.AddRange(new object[] {
            "admin",
            "guest",
            "user"});
            this.TypeCBox.Location = new System.Drawing.Point(161, 327);
            this.TypeCBox.Name = "TypeCBox";
            this.TypeCBox.Size = new System.Drawing.Size(209, 21);
            this.TypeCBox.TabIndex = 19;
            // 
            // oldPasslb
            // 
            this.oldPasslb.AutoSize = true;
            this.oldPasslb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldPasslb.Location = new System.Drawing.Point(25, 149);
            this.oldPasslb.Name = "oldPasslb";
            this.oldPasslb.Size = new System.Drawing.Size(105, 20);
            this.oldPasslb.TabIndex = 61;
            this.oldPasslb.Text = "Old password";
            // 
            // oldPassTBox
            // 
            this.oldPassTBox.Enabled = false;
            this.oldPassTBox.Location = new System.Drawing.Point(161, 149);
            this.oldPassTBox.Name = "oldPassTBox";
            this.oldPassTBox.Size = new System.Drawing.Size(209, 20);
            this.oldPassTBox.TabIndex = 13;
            this.oldPassTBox.UseSystemPasswordChar = true;
            this.oldPassTBox.TextChanged += new System.EventHandler(this.oldPassTBox_TextChanged);
            // 
            // genRanPasslLabel
            // 
            this.genRanPasslLabel.AutoSize = true;
            this.genRanPasslLabel.Location = new System.Drawing.Point(161, 206);
            this.genRanPasslLabel.Name = "genRanPasslLabel";
            this.genRanPasslLabel.Size = new System.Drawing.Size(137, 13);
            this.genRanPasslLabel.TabIndex = 62;
            this.genRanPasslLabel.TabStop = true;
            this.genRanPasslLabel.Text = "Generate random password";
            this.genRanPasslLabel.Visible = false;
            this.genRanPasslLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActive.Location = new System.Drawing.Point(25, 395);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(52, 20);
            this.lbActive.TabIndex = 73;
            this.lbActive.Text = "Active";
            // 
            // cBoxActive
            // 
            this.cBoxActive.AutoSize = true;
            this.cBoxActive.Location = new System.Drawing.Point(160, 399);
            this.cBoxActive.Name = "cBoxActive";
            this.cBoxActive.Size = new System.Drawing.Size(15, 14);
            this.cBoxActive.TabIndex = 23;
            this.cBoxActive.UseVisualStyleBackColor = true;
            // 
            // inValidationPicBox
            // 
            this.inValidationPicBox.Image = ((System.Drawing.Image)(resources.GetObject("inValidationPicBox.Image")));
            this.inValidationPicBox.InitialImage = null;
            this.inValidationPicBox.Location = new System.Drawing.Point(418, 225);
            this.inValidationPicBox.Name = "inValidationPicBox";
            this.inValidationPicBox.Size = new System.Drawing.Size(19, 17);
            this.inValidationPicBox.TabIndex = 61;
            this.inValidationPicBox.TabStop = false;
            this.inValidationPicBox.Visible = false;
            // 
            // validationPicBox
            // 
            this.validationPicBox.Image = ((System.Drawing.Image)(resources.GetObject("validationPicBox.Image")));
            this.validationPicBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("validationPicBox.InitialImage")));
            this.validationPicBox.Location = new System.Drawing.Point(393, 225);
            this.validationPicBox.Name = "validationPicBox";
            this.validationPicBox.Size = new System.Drawing.Size(19, 17);
            this.validationPicBox.TabIndex = 60;
            this.validationPicBox.TabStop = false;
            this.validationPicBox.Visible = false;
            // 
            // cBoxProject
            // 
            this.cBoxProject.FormattingEnabled = true;
            this.cBoxProject.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cBoxProject.Location = new System.Drawing.Point(161, 362);
            this.cBoxProject.Name = "cBoxProject";
            this.cBoxProject.Size = new System.Drawing.Size(209, 21);
            this.cBoxProject.TabIndex = 21;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(25, 363);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(113, 20);
            this.lblProject.TabIndex = 73;
            this.lblProject.Text = "Default project";
            // 
            // cBoxPosition
            // 
            this.cBoxPosition.FormattingEnabled = true;
            this.cBoxPosition.ItemHeight = 13;
            this.cBoxPosition.Items.AddRange(new object[] {
            "AVIT",
            "Technical",
            "Safety Officer",
            "Helpdesk"});
            this.cBoxPosition.Location = new System.Drawing.Point(161, 85);
            this.cBoxPosition.Name = "cBoxPosition";
            this.cBoxPosition.Size = new System.Drawing.Size(209, 21);
            this.cBoxPosition.TabIndex = 74;
            // 
            // llbPosition
            // 
            this.llbPosition.AutoSize = true;
            this.llbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbPosition.Location = new System.Drawing.Point(25, 82);
            this.llbPosition.Name = "llbPosition";
            this.llbPosition.Size = new System.Drawing.Size(65, 20);
            this.llbPosition.TabIndex = 75;
            this.llbPosition.Text = "Position";
            // 
            // btbDelete
            // 
            this.btbDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btbDelete.Enabled = false;
            this.btbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbDelete.ForeColor = System.Drawing.Color.Red;
            this.btbDelete.Location = new System.Drawing.Point(197, 514);
            this.btbDelete.Name = "btbDelete";
            this.btbDelete.Size = new System.Drawing.Size(75, 28);
            this.btbDelete.TabIndex = 76;
            this.btbDelete.Text = "Delete";
            this.btbDelete.UseVisualStyleBackColor = false;
            this.btbDelete.Click += new System.EventHandler(this.btbDelete_Click);
            // 
            // cBoxRole
            // 
            this.cBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxRole.FormattingEnabled = true;
            this.cBoxRole.Location = new System.Drawing.Point(160, 426);
            this.cBoxRole.Name = "cBoxRole";
            this.cBoxRole.Size = new System.Drawing.Size(209, 21);
            this.cBoxRole.TabIndex = 77;
            this.cBoxRole.Visible = false;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.Location = new System.Drawing.Point(24, 427);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(42, 20);
            this.lbRole.TabIndex = 78;
            this.lbRole.Text = "Role";
            this.lbRole.Visible = false;
            // 
            // tabControlUsers
            // 
            this.tabControlUsers.Controls.Add(this.tabUserEdit);
            this.tabControlUsers.Controls.Add(this.tabUserPermission);
            this.tabControlUsers.Location = new System.Drawing.Point(12, 12);
            this.tabControlUsers.Name = "tabControlUsers";
            this.tabControlUsers.SelectedIndex = 0;
            this.tabControlUsers.Size = new System.Drawing.Size(468, 485);
            this.tabControlUsers.TabIndex = 79;
            // 
            // tabUserEdit
            // 
            this.tabUserEdit.Controls.Add(this.statuslb);
            this.tabUserEdit.Controls.Add(this.cBoxRole);
            this.tabUserEdit.Controls.Add(this.PassTBox);
            this.tabUserEdit.Controls.Add(this.lbRole);
            this.tabUserEdit.Controls.Add(this.issueDesclb);
            this.tabUserEdit.Controls.Add(this.UserIdtbox);
            this.tabUserEdit.Controls.Add(this.cBoxPosition);
            this.tabUserEdit.Controls.Add(this.passlb);
            this.tabUserEdit.Controls.Add(this.llbPosition);
            this.tabUserEdit.Controls.Add(this.prioritylbl);
            this.tabUserEdit.Controls.Add(this.cBoxProject);
            this.tabUserEdit.Controls.Add(this.UsertBox);
            this.tabUserEdit.Controls.Add(this.lblProject);
            this.tabUserEdit.Controls.Add(this.departmentCBox);
            this.tabUserEdit.Controls.Add(this.cBoxActive);
            this.tabUserEdit.Controls.Add(this.NametBox);
            this.tabUserEdit.Controls.Add(this.lbActive);
            this.tabUserEdit.Controls.Add(this.TrackIdlb);
            this.tabUserEdit.Controls.Add(this.genRanPasslLabel);
            this.tabUserEdit.Controls.Add(this.label1);
            this.tabUserEdit.Controls.Add(this.inValidationPicBox);
            this.tabUserEdit.Controls.Add(this.EmailtBox);
            this.tabUserEdit.Controls.Add(this.validationPicBox);
            this.tabUserEdit.Controls.Add(this.label2);
            this.tabUserEdit.Controls.Add(this.oldPasslb);
            this.tabUserEdit.Controls.Add(this.confPassTBox);
            this.tabUserEdit.Controls.Add(this.oldPassTBox);
            this.tabUserEdit.Controls.Add(this.label3);
            this.tabUserEdit.Controls.Add(this.TypeCBox);
            this.tabUserEdit.Location = new System.Drawing.Point(4, 22);
            this.tabUserEdit.Name = "tabUserEdit";
            this.tabUserEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserEdit.Size = new System.Drawing.Size(460, 459);
            this.tabUserEdit.TabIndex = 0;
            this.tabUserEdit.Text = "User";
            this.tabUserEdit.UseVisualStyleBackColor = true;
            // 
            // tabUserPermission
            // 
            this.tabUserPermission.Controls.Add(this.checkedListBoxPermissions);
            this.tabUserPermission.Location = new System.Drawing.Point(4, 22);
            this.tabUserPermission.Name = "tabUserPermission";
            this.tabUserPermission.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserPermission.Size = new System.Drawing.Size(460, 459);
            this.tabUserPermission.TabIndex = 1;
            this.tabUserPermission.Text = "Permissions";
            this.tabUserPermission.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxPermissions
            // 
            this.checkedListBoxPermissions.FormattingEnabled = true;
            this.checkedListBoxPermissions.Location = new System.Drawing.Point(6, 5);
            this.checkedListBoxPermissions.Name = "checkedListBoxPermissions";
            this.checkedListBoxPermissions.Size = new System.Drawing.Size(448, 439);
            this.checkedListBoxPermissions.TabIndex = 1;
            // 
            // UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 568);
            this.Controls.Add(this.tabControlUsers);
            this.Controls.Add(this.btbDelete);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserEdit";
            this.Text = "User Edit";
            ((System.ComponentModel.ISupportInitialize)(this.inValidationPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validationPicBox)).EndInit();
            this.tabControlUsers.ResumeLayout(false);
            this.tabUserEdit.ResumeLayout(false);
            this.tabUserEdit.PerformLayout();
            this.tabUserPermission.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label passlb;
        private System.Windows.Forms.Label issueDesclb;
        private System.Windows.Forms.TextBox PassTBox;
        private System.Windows.Forms.Label statuslb;
        private System.Windows.Forms.Label TrackIdlb;
        private System.Windows.Forms.TextBox UserIdtbox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label prioritylbl;
        private System.Windows.Forms.ComboBox departmentCBox;
        private System.Windows.Forms.TextBox UsertBox;
        private System.Windows.Forms.TextBox NametBox;
        private System.Windows.Forms.TextBox EmailtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox confPassTBox;
        private System.Windows.Forms.ComboBox TypeCBox;
        private System.Windows.Forms.Label oldPasslb;
        private System.Windows.Forms.TextBox oldPassTBox;
        private System.Windows.Forms.PictureBox validationPicBox;
        private System.Windows.Forms.PictureBox inValidationPicBox;
        private System.Windows.Forms.LinkLabel genRanPasslLabel;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.CheckBox cBoxActive;
        private System.Windows.Forms.ComboBox cBoxProject;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cBoxPosition;
        private System.Windows.Forms.Label llbPosition;
        private System.Windows.Forms.Button btbDelete;
        private System.Windows.Forms.ComboBox cBoxRole;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.TabControl tabControlUsers;
        private System.Windows.Forms.TabPage tabUserEdit;
        private System.Windows.Forms.TabPage tabUserPermission;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
    }
}