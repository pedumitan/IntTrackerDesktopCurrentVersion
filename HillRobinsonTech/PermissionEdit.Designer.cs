namespace HillRobinsonTech
{
    partial class PermissionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionEdit));
            this.lblDescription = new System.Windows.Forms.Label();
            this.TrackIdlb = new System.Windows.Forms.Label();
            this.PermissionIdtbox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.llbName = new System.Windows.Forms.Label();
            this.btbDelete = new System.Windows.Forms.Button();
            this.tBoxDescription = new System.Windows.Forms.TextBox();
            this.tBoxPName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(79, 155);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(109, 25);
            this.lblDescription.TabIndex = 57;
            this.lblDescription.Text = "Description";
            // 
            // TrackIdlb
            // 
            this.TrackIdlb.AutoSize = true;
            this.TrackIdlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackIdlb.Location = new System.Drawing.Point(79, 66);
            this.TrackIdlb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TrackIdlb.Name = "TrackIdlb";
            this.TrackIdlb.Size = new System.Drawing.Size(28, 25);
            this.TrackIdlb.TabIndex = 55;
            this.TrackIdlb.Text = "Id";
            // 
            // PermissionIdtbox
            // 
            this.PermissionIdtbox.Location = new System.Drawing.Point(260, 69);
            this.PermissionIdtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PermissionIdtbox.Name = "PermissionIdtbox";
            this.PermissionIdtbox.Size = new System.Drawing.Size(88, 22);
            this.PermissionIdtbox.TabIndex = 10;
            this.PermissionIdtbox.VisibleChanged += new System.EventHandler(this.PermissionEdit_Load);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(587, 592);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 34);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(451, 592);
            this.savebtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(100, 34);
            this.savebtn.TabIndex = 25;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // llbName
            // 
            this.llbName.AutoSize = true;
            this.llbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbName.Location = new System.Drawing.Point(79, 114);
            this.llbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbName.Name = "llbName";
            this.llbName.Size = new System.Drawing.Size(64, 25);
            this.llbName.TabIndex = 75;
            this.llbName.Text = "Name";
            // 
            // btbDelete
            // 
            this.btbDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btbDelete.Enabled = false;
            this.btbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbDelete.ForeColor = System.Drawing.Color.Red;
            this.btbDelete.Location = new System.Drawing.Point(317, 592);
            this.btbDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btbDelete.Name = "btbDelete";
            this.btbDelete.Size = new System.Drawing.Size(100, 34);
            this.btbDelete.TabIndex = 76;
            this.btbDelete.Text = "Delete";
            this.btbDelete.UseVisualStyleBackColor = false;
            this.btbDelete.Click += new System.EventHandler(this.btbDelete_Click);
            // 
            // tBoxDescription
            // 
            this.tBoxDescription.Location = new System.Drawing.Point(260, 158);
            this.tBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxDescription.Multiline = true;
            this.tBoxDescription.Name = "tBoxDescription";
            this.tBoxDescription.Size = new System.Drawing.Size(315, 53);
            this.tBoxDescription.TabIndex = 77;
            // 
            // tBoxPName
            // 
            this.tBoxPName.Location = new System.Drawing.Point(260, 117);
            this.tBoxPName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxPName.Name = "tBoxPName";
            this.tBoxPName.Size = new System.Drawing.Size(315, 22);
            this.tBoxPName.TabIndex = 78;
            // 
            // PermissionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 654);
            this.Controls.Add(this.tBoxPName);
            this.Controls.Add(this.tBoxDescription);
            this.Controls.Add(this.btbDelete);
            this.Controls.Add(this.llbName);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.TrackIdlb);
            this.Controls.Add(this.PermissionIdtbox);
            this.Controls.Add(this.lblDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PermissionEdit";
            this.Text = "Permission Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label TrackIdlb;
        private System.Windows.Forms.TextBox PermissionIdtbox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label llbName;
        private System.Windows.Forms.Button btbDelete;
        private System.Windows.Forms.TextBox tBoxDescription;
        private System.Windows.Forms.TextBox tBoxPName;
    }
}