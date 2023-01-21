namespace HillRobinsonTech
{
    partial class LocationEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationEdit));
            this.lblBuildingId = new System.Windows.Forms.Label();
            this.tBoxBuildingId = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.tboxId = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.gBoxCDesc = new System.Windows.Forms.GroupBox();
            this.tBoxFBAlias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxICT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxHKAlias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxAHU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxLocationDetails = new System.Windows.Forms.TextBox();
            this.lbLocationDetails = new System.Windows.Forms.Label();
            this.tBoxOtherInfo = new System.Windows.Forms.TextBox();
            this.lbOtherInfo = new System.Windows.Forms.Label();
            this.tBoxSpecLocation = new System.Windows.Forms.TextBox();
            this.lbSpeclocation = new System.Windows.Forms.Label();
            this.tBoxSublocation = new System.Windows.Forms.TextBox();
            this.lbSublocation = new System.Windows.Forms.Label();
            this.tBoxProject = new System.Windows.Forms.TextBox();
            this.btbDelete = new System.Windows.Forms.Button();
            this.gBoxCDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBuildingId
            // 
            this.lblBuildingId.AutoSize = true;
            this.lblBuildingId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildingId.Location = new System.Drawing.Point(24, 102);
            this.lblBuildingId.Name = "lblBuildingId";
            this.lblBuildingId.Size = new System.Drawing.Size(83, 20);
            this.lblBuildingId.TabIndex = 20;
            this.lblBuildingId.Text = "Building Id";
            // 
            // tBoxBuildingId
            // 
            this.tBoxBuildingId.Location = new System.Drawing.Point(160, 104);
            this.tBoxBuildingId.Name = "tBoxBuildingId";
            this.tBoxBuildingId.Size = new System.Drawing.Size(209, 20);
            this.tBoxBuildingId.TabIndex = 103;
            this.tBoxBuildingId.TextChanged += new System.EventHandler(this.tBoxLName_TextChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(25, 65);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(58, 20);
            this.lblProject.TabIndex = 18;
            this.lblProject.Text = "Project";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(25, 30);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(23, 20);
            this.lbId.TabIndex = 17;
            this.lbId.Text = "Id";
            // 
            // tboxId
            // 
            this.tboxId.Enabled = false;
            this.tboxId.Location = new System.Drawing.Point(161, 32);
            this.tboxId.Name = "tboxId";
            this.tboxId.Size = new System.Drawing.Size(67, 20);
            this.tboxId.TabIndex = 100;
            this.tboxId.VisibleChanged += new System.EventHandler(this.LocationEdit_Load);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(363, 460);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.TabIndex = 116;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(261, 460);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 28);
            this.savebtn.TabIndex = 115;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // gBoxCDesc
            // 
            this.gBoxCDesc.Controls.Add(this.tBoxFBAlias);
            this.gBoxCDesc.Controls.Add(this.label4);
            this.gBoxCDesc.Controls.Add(this.cBoxICT);
            this.gBoxCDesc.Controls.Add(this.label3);
            this.gBoxCDesc.Controls.Add(this.tBoxHKAlias);
            this.gBoxCDesc.Controls.Add(this.label2);
            this.gBoxCDesc.Controls.Add(this.tBoxAHU);
            this.gBoxCDesc.Controls.Add(this.label1);
            this.gBoxCDesc.Controls.Add(this.tBoxLocationDetails);
            this.gBoxCDesc.Controls.Add(this.lbLocationDetails);
            this.gBoxCDesc.Controls.Add(this.tBoxOtherInfo);
            this.gBoxCDesc.Controls.Add(this.lbOtherInfo);
            this.gBoxCDesc.Controls.Add(this.tBoxSpecLocation);
            this.gBoxCDesc.Controls.Add(this.lbSpeclocation);
            this.gBoxCDesc.Controls.Add(this.tBoxSublocation);
            this.gBoxCDesc.Controls.Add(this.lbSublocation);
            this.gBoxCDesc.Controls.Add(this.tBoxProject);
            this.gBoxCDesc.Controls.Add(this.lbId);
            this.gBoxCDesc.Controls.Add(this.tboxId);
            this.gBoxCDesc.Controls.Add(this.lblProject);
            this.gBoxCDesc.Controls.Add(this.tBoxBuildingId);
            this.gBoxCDesc.Controls.Add(this.lblBuildingId);
            this.gBoxCDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxCDesc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gBoxCDesc.Location = new System.Drawing.Point(28, 12);
            this.gBoxCDesc.Name = "gBoxCDesc";
            this.gBoxCDesc.Size = new System.Drawing.Size(411, 427);
            this.gBoxCDesc.TabIndex = 50;
            this.gBoxCDesc.TabStop = false;
            this.gBoxCDesc.Text = "Location Description";
            // 
            // tBoxFBAlias
            // 
            this.tBoxFBAlias.Location = new System.Drawing.Point(160, 290);
            this.tBoxFBAlias.Name = "tBoxFBAlias";
            this.tBoxFBAlias.Size = new System.Drawing.Size(209, 20);
            this.tBoxFBAlias.TabIndex = 141;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "F&B alias";
            // 
            // cBoxICT
            // 
            this.cBoxICT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxICT.FormattingEnabled = true;
            this.cBoxICT.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cBoxICT.Location = new System.Drawing.Point(161, 358);
            this.cBoxICT.Name = "cBoxICT";
            this.cBoxICT.Size = new System.Drawing.Size(208, 21);
            this.cBoxICT.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 138;
            this.label3.Text = "ICT";
            // 
            // tBoxHKAlias
            // 
            this.tBoxHKAlias.Location = new System.Drawing.Point(160, 254);
            this.tBoxHKAlias.Name = "tBoxHKAlias";
            this.tBoxHKAlias.Size = new System.Drawing.Size(209, 20);
            this.tBoxHKAlias.TabIndex = 137;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 136;
            this.label2.Text = "HK alias";
            // 
            // tBoxAHU
            // 
            this.tBoxAHU.Location = new System.Drawing.Point(160, 322);
            this.tBoxAHU.Name = "tBoxAHU";
            this.tBoxAHU.Size = new System.Drawing.Size(209, 20);
            this.tBoxAHU.TabIndex = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 134;
            this.label1.Text = "AHU details";
            // 
            // tBoxLocationDetails
            // 
            this.tBoxLocationDetails.Location = new System.Drawing.Point(160, 214);
            this.tBoxLocationDetails.Name = "tBoxLocationDetails";
            this.tBoxLocationDetails.Size = new System.Drawing.Size(209, 20);
            this.tBoxLocationDetails.TabIndex = 133;
            // 
            // lbLocationDetails
            // 
            this.lbLocationDetails.AutoSize = true;
            this.lbLocationDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocationDetails.Location = new System.Drawing.Point(24, 212);
            this.lbLocationDetails.Name = "lbLocationDetails";
            this.lbLocationDetails.Size = new System.Drawing.Size(123, 20);
            this.lbLocationDetails.TabIndex = 132;
            this.lbLocationDetails.Text = "Location Details";
            // 
            // tBoxOtherInfo
            // 
            this.tBoxOtherInfo.Location = new System.Drawing.Point(160, 396);
            this.tBoxOtherInfo.Name = "tBoxOtherInfo";
            this.tBoxOtherInfo.Size = new System.Drawing.Size(209, 20);
            this.tBoxOtherInfo.TabIndex = 131;
            // 
            // lbOtherInfo
            // 
            this.lbOtherInfo.AutoSize = true;
            this.lbOtherInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOtherInfo.Location = new System.Drawing.Point(24, 394);
            this.lbOtherInfo.Name = "lbOtherInfo";
            this.lbOtherInfo.Size = new System.Drawing.Size(81, 20);
            this.lbOtherInfo.TabIndex = 130;
            this.lbOtherInfo.Text = "Other Info";
            // 
            // tBoxSpecLocation
            // 
            this.tBoxSpecLocation.Location = new System.Drawing.Point(160, 177);
            this.tBoxSpecLocation.Name = "tBoxSpecLocation";
            this.tBoxSpecLocation.Size = new System.Drawing.Size(209, 20);
            this.tBoxSpecLocation.TabIndex = 129;
            // 
            // lbSpeclocation
            // 
            this.lbSpeclocation.AutoSize = true;
            this.lbSpeclocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeclocation.Location = new System.Drawing.Point(24, 175);
            this.lbSpeclocation.Name = "lbSpeclocation";
            this.lbSpeclocation.Size = new System.Drawing.Size(124, 20);
            this.lbSpeclocation.TabIndex = 128;
            this.lbSpeclocation.Text = "Specific location";
            // 
            // tBoxSublocation
            // 
            this.tBoxSublocation.Location = new System.Drawing.Point(160, 138);
            this.tBoxSublocation.Name = "tBoxSublocation";
            this.tBoxSublocation.Size = new System.Drawing.Size(209, 20);
            this.tBoxSublocation.TabIndex = 125;
            // 
            // lbSublocation
            // 
            this.lbSublocation.AutoSize = true;
            this.lbSublocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSublocation.Location = new System.Drawing.Point(24, 136);
            this.lbSublocation.Name = "lbSublocation";
            this.lbSublocation.Size = new System.Drawing.Size(93, 20);
            this.lbSublocation.TabIndex = 53;
            this.lbSublocation.Text = "Sublocation";
            // 
            // tBoxProject
            // 
            this.tBoxProject.Location = new System.Drawing.Point(161, 67);
            this.tBoxProject.Name = "tBoxProject";
            this.tBoxProject.Size = new System.Drawing.Size(209, 20);
            this.tBoxProject.TabIndex = 101;
            this.tBoxProject.TextChanged += new System.EventHandler(this.tBoxFName_TextChanged);
            // 
            // btbDelete
            // 
            this.btbDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btbDelete.Enabled = false;
            this.btbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbDelete.ForeColor = System.Drawing.Color.Red;
            this.btbDelete.Location = new System.Drawing.Point(161, 460);
            this.btbDelete.Name = "btbDelete";
            this.btbDelete.Size = new System.Drawing.Size(75, 28);
            this.btbDelete.TabIndex = 117;
            this.btbDelete.Text = "Delete";
            this.btbDelete.UseVisualStyleBackColor = false;
            this.btbDelete.Click += new System.EventHandler(this.btbDelete_Click);
            // 
            // LocationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 500);
            this.Controls.Add(this.btbDelete);
            this.Controls.Add(this.gBoxCDesc);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LocationEdit";
            this.Text = "Location Edit";
            this.gBoxCDesc.ResumeLayout(false);
            this.gBoxCDesc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblBuildingId;
        private System.Windows.Forms.TextBox tBoxBuildingId;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TextBox tboxId;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.GroupBox gBoxCDesc;
        private System.Windows.Forms.TextBox tBoxProject;
        private System.Windows.Forms.TextBox tBoxSublocation;
        private System.Windows.Forms.Label lbSublocation;
        private System.Windows.Forms.Button btbDelete;
        private System.Windows.Forms.TextBox tBoxOtherInfo;
        private System.Windows.Forms.Label lbOtherInfo;
        private System.Windows.Forms.TextBox tBoxSpecLocation;
        private System.Windows.Forms.Label lbSpeclocation;
        private System.Windows.Forms.TextBox tBoxLocationDetails;
        private System.Windows.Forms.Label lbLocationDetails;
        private System.Windows.Forms.TextBox tBoxAHU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxHKAlias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxFBAlias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxICT;
        private System.Windows.Forms.Label label3;
    }
}