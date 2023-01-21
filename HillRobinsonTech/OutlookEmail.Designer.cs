namespace HillRobinsonTech
{
    partial class OutlookEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutlookEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxFrom = new System.Windows.Forms.TextBox();
            this.ToLbl = new System.Windows.Forms.Label();
            this.tBoxTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxSubject = new System.Windows.Forms.TextBox();
            this.tBoxCc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxBody = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnClearAttachment = new System.Windows.Forms.Button();
            this.tBoxAttachments = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send email                  ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 53);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // tBoxFrom
            // 
            this.tBoxFrom.Location = new System.Drawing.Point(88, 99);
            this.tBoxFrom.Name = "tBoxFrom";
            this.tBoxFrom.Size = new System.Drawing.Size(344, 20);
            this.tBoxFrom.TabIndex = 3;
            // 
            // ToLbl
            // 
            this.ToLbl.AutoSize = true;
            this.ToLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToLbl.Location = new System.Drawing.Point(19, 140);
            this.ToLbl.Name = "ToLbl";
            this.ToLbl.Size = new System.Drawing.Size(27, 20);
            this.ToLbl.TabIndex = 4;
            this.ToLbl.Text = "To";
            // 
            // tBoxTo
            // 
            this.tBoxTo.Location = new System.Drawing.Point(88, 142);
            this.tBoxTo.Name = "tBoxTo";
            this.tBoxTo.Size = new System.Drawing.Size(344, 20);
            this.tBoxTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subject";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tBoxSubject
            // 
            this.tBoxSubject.Location = new System.Drawing.Point(88, 228);
            this.tBoxSubject.Multiline = true;
            this.tBoxSubject.Name = "tBoxSubject";
            this.tBoxSubject.Size = new System.Drawing.Size(344, 36);
            this.tBoxSubject.TabIndex = 7;
            this.tBoxSubject.TextChanged += new System.EventHandler(this.tBoxSubject_TextChanged);
            // 
            // tBoxCc
            // 
            this.tBoxCc.Location = new System.Drawing.Point(88, 186);
            this.tBoxCc.Name = "tBoxCc";
            this.tBoxCc.Size = new System.Drawing.Size(344, 20);
            this.tBoxCc.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Body";
            // 
            // tBoxBody
            // 
            this.tBoxBody.Location = new System.Drawing.Point(88, 295);
            this.tBoxBody.Multiline = true;
            this.tBoxBody.Name = "tBoxBody";
            this.tBoxBody.Size = new System.Drawing.Size(344, 113);
            this.tBoxBody.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(357, 700);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(12, 427);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(63, 23);
            this.btnAttach.TabIndex = 15;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // lblAttachment
            // 
            this.lblAttachment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAttachment.AutoEllipsis = true;
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(36, 511);
            this.lblAttachment.MaximumSize = new System.Drawing.Size(370, 250);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(0, 13);
            this.lblAttachment.TabIndex = 16;
            // 
            // btnClearAttachment
            // 
            this.btnClearAttachment.Location = new System.Drawing.Point(12, 470);
            this.btnClearAttachment.Name = "btnClearAttachment";
            this.btnClearAttachment.Size = new System.Drawing.Size(63, 23);
            this.btnClearAttachment.TabIndex = 17;
            this.btnClearAttachment.Text = "Clear";
            this.btnClearAttachment.UseVisualStyleBackColor = true;
            this.btnClearAttachment.Click += new System.EventHandler(this.btnClearAttachment_Click);
            // 
            // tBoxAttachments
            // 
            this.tBoxAttachments.Location = new System.Drawing.Point(88, 429);
            this.tBoxAttachments.Multiline = true;
            this.tBoxAttachments.Name = "tBoxAttachments";
            this.tBoxAttachments.ReadOnly = true;
            this.tBoxAttachments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxAttachments.Size = new System.Drawing.Size(344, 250);
            this.tBoxAttachments.TabIndex = 18;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 780);
            this.Controls.Add(this.tBoxAttachments);
            this.Controls.Add(this.btnClearAttachment);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tBoxBody);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBoxCc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBoxTo);
            this.Controls.Add(this.ToLbl);
            this.Controls.Add(this.tBoxFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Email";
            this.Text = "Email";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxFrom;
        private System.Windows.Forms.Label ToLbl;
        private System.Windows.Forms.TextBox tBoxTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxSubject;
        private System.Windows.Forms.TextBox tBoxCc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBoxBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnClearAttachment;
        private System.Windows.Forms.TextBox tBoxAttachments;
    }
}