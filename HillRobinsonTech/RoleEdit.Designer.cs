namespace HillRobinsonTech
{
    partial class RoleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleEdit));
            this.lblDescription = new System.Windows.Forms.Label();
            this.RoleIdlb = new System.Windows.Forms.Label();
            this.RoleIdtbox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tBoxDescription = new System.Windows.Forms.TextBox();
            this.tBoxRoleName = new System.Windows.Forms.TextBox();
            this.tabCtrlRole = new System.Windows.Forms.TabControl();
            this.tabRole = new System.Windows.Forms.TabPage();
            this.tabPermissions = new System.Windows.Forms.TabPage();
            this.checkedListBoxPermissions = new System.Windows.Forms.CheckedListBox();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.checkedListBoxRoleUsers = new System.Windows.Forms.CheckedListBox();
            this.tabCtrlRole.SuspendLayout();
            this.tabRole.SuspendLayout();
            this.tabPermissions.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(22, 119);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDescription.TabIndex = 57;
            this.lblDescription.Text = "Description";
            // 
            // RoleIdlb
            // 
            this.RoleIdlb.AutoSize = true;
            this.RoleIdlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleIdlb.Location = new System.Drawing.Point(22, 47);
            this.RoleIdlb.Name = "RoleIdlb";
            this.RoleIdlb.Size = new System.Drawing.Size(23, 20);
            this.RoleIdlb.TabIndex = 55;
            this.RoleIdlb.Text = "Id";
            // 
            // RoleIdtbox
            // 
            this.RoleIdtbox.Location = new System.Drawing.Point(158, 49);
            this.RoleIdtbox.Name = "RoleIdtbox";
            this.RoleIdtbox.Size = new System.Drawing.Size(67, 20);
            this.RoleIdtbox.TabIndex = 10;
            this.RoleIdtbox.VisibleChanged += new System.EventHandler(this.RoleEdit_Load);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(394, 481);
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
            this.savebtn.Location = new System.Drawing.Point(292, 481);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 28);
            this.savebtn.TabIndex = 25;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(22, 86);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(51, 20);
            this.lbName.TabIndex = 75;
            this.lbName.Text = "Name";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(192, 481);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 76;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btbDelete_Click);
            // 
            // tBoxDescription
            // 
            this.tBoxDescription.Location = new System.Drawing.Point(158, 121);
            this.tBoxDescription.Multiline = true;
            this.tBoxDescription.Name = "tBoxDescription";
            this.tBoxDescription.Size = new System.Drawing.Size(237, 44);
            this.tBoxDescription.TabIndex = 77;
            // 
            // tBoxRoleName
            // 
            this.tBoxRoleName.Location = new System.Drawing.Point(158, 88);
            this.tBoxRoleName.Name = "tBoxRoleName";
            this.tBoxRoleName.Size = new System.Drawing.Size(237, 20);
            this.tBoxRoleName.TabIndex = 78;
            // 
            // tabCtrlRole
            // 
            this.tabCtrlRole.Controls.Add(this.tabRole);
            this.tabCtrlRole.Controls.Add(this.tabPermissions);
            this.tabCtrlRole.Controls.Add(this.tabUsers);
            this.tabCtrlRole.Location = new System.Drawing.Point(29, 12);
            this.tabCtrlRole.Name = "tabCtrlRole";
            this.tabCtrlRole.SelectedIndex = 0;
            this.tabCtrlRole.Size = new System.Drawing.Size(444, 463);
            this.tabCtrlRole.TabIndex = 79;
            // 
            // tabRole
            // 
            this.tabRole.Controls.Add(this.RoleIdlb);
            this.tabRole.Controls.Add(this.tBoxRoleName);
            this.tabRole.Controls.Add(this.lblDescription);
            this.tabRole.Controls.Add(this.tBoxDescription);
            this.tabRole.Controls.Add(this.RoleIdtbox);
            this.tabRole.Controls.Add(this.lbName);
            this.tabRole.Location = new System.Drawing.Point(4, 22);
            this.tabRole.Name = "tabRole";
            this.tabRole.Padding = new System.Windows.Forms.Padding(3);
            this.tabRole.Size = new System.Drawing.Size(436, 437);
            this.tabRole.TabIndex = 0;
            this.tabRole.Text = "Role";
            this.tabRole.UseVisualStyleBackColor = true;
            // 
            // tabPermissions
            // 
            this.tabPermissions.Controls.Add(this.checkedListBoxPermissions);
            this.tabPermissions.Location = new System.Drawing.Point(4, 22);
            this.tabPermissions.Name = "tabPermissions";
            this.tabPermissions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermissions.Size = new System.Drawing.Size(436, 437);
            this.tabPermissions.TabIndex = 1;
            this.tabPermissions.Text = "Permissions";
            this.tabPermissions.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxPermissions
            // 
            this.checkedListBoxPermissions.FormattingEnabled = true;
            this.checkedListBoxPermissions.Location = new System.Drawing.Point(6, 13);
            this.checkedListBoxPermissions.Name = "checkedListBoxPermissions";
            this.checkedListBoxPermissions.Size = new System.Drawing.Size(424, 409);
            this.checkedListBoxPermissions.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.checkedListBoxRoleUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(436, 437);
            this.tabUsers.TabIndex = 2;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxRoleUsers
            // 
            this.checkedListBoxRoleUsers.FormattingEnabled = true;
            this.checkedListBoxRoleUsers.Location = new System.Drawing.Point(6, 14);
            this.checkedListBoxRoleUsers.Name = "checkedListBoxRoleUsers";
            this.checkedListBoxRoleUsers.Size = new System.Drawing.Size(424, 409);
            this.checkedListBoxRoleUsers.TabIndex = 1;
            // 
            // RoleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 531);
            this.Controls.Add(this.tabCtrlRole);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoleEdit";
            this.Text = "Role Edit";
            this.tabCtrlRole.ResumeLayout(false);
            this.tabRole.ResumeLayout(false);
            this.tabRole.PerformLayout();
            this.tabPermissions.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label RoleIdlb;
        private System.Windows.Forms.TextBox RoleIdtbox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tBoxDescription;
        private System.Windows.Forms.TextBox tBoxRoleName;
        private System.Windows.Forms.TabControl tabCtrlRole;
        private System.Windows.Forms.TabPage tabRole;
        private System.Windows.Forms.TabPage tabPermissions;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
        private System.Windows.Forms.CheckedListBox checkedListBoxRoleUsers;
    }
}