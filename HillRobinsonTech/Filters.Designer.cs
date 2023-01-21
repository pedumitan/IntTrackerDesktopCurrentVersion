namespace HillRobinsonTech
{
    partial class Filters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filters));
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.prioritylbl = new System.Windows.Forms.Label();
            this.reportedBylb = new System.Windows.Forms.Label();
            this.dateCreatedlb = new System.Windows.Forms.Label();
            this.locationlb = new System.Windows.Forms.Label();
            this.statuslb = new System.Windows.Forms.Label();
            this.dateCreatedInTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateCreatedOutTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.statuscheckBox = new System.Windows.Forms.CheckBox();
            this.LocationCheckBox = new System.Windows.Forms.CheckBox();
            this.DateCreatedcBox = new System.Windows.Forms.CheckBox();
            this.ReportedBycheckBox = new System.Windows.Forms.CheckBox();
            this.PrioritycheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typecheckBox = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrackIdcheckBox = new System.Windows.Forms.CheckBox();
            this.tBoxTrackIdfrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxTrackIdTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxSubLocation = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecLocation = new System.Windows.Forms.CheckBox();
            this.checkBoxLocDetails = new System.Windows.Forms.CheckBox();
            this.cBoxDepartmentEsom = new System.Windows.Forms.CheckBox();
            this.cBoxClosingDate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClosingDateOutTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ClosingDateInTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cBoxClosedBy = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cBoxCompBy = new System.Windows.Forms.CheckBox();
            this.lblCompBy = new System.Windows.Forms.Label();
            this.cBoxCompDate = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CompDateOutTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CompDateInTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.CompletedByFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.ClosedByFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.DepartmentEsomFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.LocDetailsFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.SpecLocationFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.SubLocationFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.typeFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.PriorityFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.ReportedByFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.LocationFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.StatusFiltercheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.LocationCheckedComboBox = new HillRobinsonTech.CheckedComboBox();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(431, 619);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 28);
            this.savebtn.TabIndex = 51;
            this.savebtn.Text = "Apply";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(533, 619);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.TabIndex = 52;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // prioritylbl
            // 
            this.prioritylbl.AutoSize = true;
            this.prioritylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prioritylbl.Location = new System.Drawing.Point(43, 170);
            this.prioritylbl.Name = "prioritylbl";
            this.prioritylbl.Size = new System.Drawing.Size(56, 20);
            this.prioritylbl.TabIndex = 61;
            this.prioritylbl.Text = "Priority";
            // 
            // reportedBylb
            // 
            this.reportedBylb.AutoSize = true;
            this.reportedBylb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportedBylb.Location = new System.Drawing.Point(43, 382);
            this.reportedBylb.Name = "reportedBylb";
            this.reportedBylb.Size = new System.Drawing.Size(96, 20);
            this.reportedBylb.TabIndex = 56;
            this.reportedBylb.Text = "Reported by";
            // 
            // dateCreatedlb
            // 
            this.dateCreatedlb.AutoSize = true;
            this.dateCreatedlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreatedlb.Location = new System.Drawing.Point(43, 349);
            this.dateCreatedlb.Name = "dateCreatedlb";
            this.dateCreatedlb.Size = new System.Drawing.Size(102, 20);
            this.dateCreatedlb.TabIndex = 55;
            this.dateCreatedlb.Text = "Date created";
            // 
            // locationlb
            // 
            this.locationlb.AutoSize = true;
            this.locationlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationlb.Location = new System.Drawing.Point(43, 207);
            this.locationlb.Name = "locationlb";
            this.locationlb.Size = new System.Drawing.Size(70, 20);
            this.locationlb.TabIndex = 54;
            this.locationlb.Text = "Location";
            // 
            // statuslb
            // 
            this.statuslb.AutoSize = true;
            this.statuslb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslb.Location = new System.Drawing.Point(43, 130);
            this.statuslb.Name = "statuslb";
            this.statuslb.Size = new System.Drawing.Size(56, 20);
            this.statuslb.TabIndex = 53;
            this.statuslb.Text = "Status";
            // 
            // dateCreatedInTimePicker
            // 
            this.dateCreatedInTimePicker.Enabled = false;
            this.dateCreatedInTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreatedInTimePicker.Location = new System.Drawing.Point(225, 349);
            this.dateCreatedInTimePicker.Name = "dateCreatedInTimePicker";
            this.dateCreatedInTimePicker.Size = new System.Drawing.Size(154, 20);
            this.dateCreatedInTimePicker.TabIndex = 69;
            // 
            // dateCreatedOutTimePicker
            // 
            this.dateCreatedOutTimePicker.Enabled = false;
            this.dateCreatedOutTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreatedOutTimePicker.Location = new System.Drawing.Point(455, 349);
            this.dateCreatedOutTimePicker.Name = "dateCreatedOutTimePicker";
            this.dateCreatedOutTimePicker.Size = new System.Drawing.Size(154, 20);
            this.dateCreatedOutTimePicker.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 73;
            this.label1.Text = "to";
            // 
            // statuscheckBox
            // 
            this.statuscheckBox.AutoSize = true;
            this.statuscheckBox.Location = new System.Drawing.Point(204, 135);
            this.statuscheckBox.Name = "statuscheckBox";
            this.statuscheckBox.Size = new System.Drawing.Size(15, 14);
            this.statuscheckBox.TabIndex = 76;
            this.statuscheckBox.UseVisualStyleBackColor = true;
            this.statuscheckBox.CheckedChanged += new System.EventHandler(this.statuscheckBox_CheckedChanged);
            // 
            // LocationCheckBox
            // 
            this.LocationCheckBox.AutoSize = true;
            this.LocationCheckBox.Location = new System.Drawing.Point(203, 210);
            this.LocationCheckBox.Name = "LocationCheckBox";
            this.LocationCheckBox.Size = new System.Drawing.Size(15, 14);
            this.LocationCheckBox.TabIndex = 77;
            this.LocationCheckBox.UseVisualStyleBackColor = true;
            this.LocationCheckBox.CheckedChanged += new System.EventHandler(this.LocationCheckBox_CheckedChanged);
            // 
            // DateCreatedcBox
            // 
            this.DateCreatedcBox.AutoSize = true;
            this.DateCreatedcBox.Location = new System.Drawing.Point(203, 356);
            this.DateCreatedcBox.Name = "DateCreatedcBox";
            this.DateCreatedcBox.Size = new System.Drawing.Size(15, 14);
            this.DateCreatedcBox.TabIndex = 78;
            this.DateCreatedcBox.UseVisualStyleBackColor = true;
            this.DateCreatedcBox.CheckedChanged += new System.EventHandler(this.DateCreatedcBox_CheckedChanged);
            // 
            // ReportedBycheckBox
            // 
            this.ReportedBycheckBox.AutoSize = true;
            this.ReportedBycheckBox.Location = new System.Drawing.Point(204, 388);
            this.ReportedBycheckBox.Name = "ReportedBycheckBox";
            this.ReportedBycheckBox.Size = new System.Drawing.Size(15, 14);
            this.ReportedBycheckBox.TabIndex = 79;
            this.ReportedBycheckBox.UseVisualStyleBackColor = true;
            this.ReportedBycheckBox.CheckedChanged += new System.EventHandler(this.ReportedBycheckBox_CheckedChanged);
            // 
            // PrioritycheckBox
            // 
            this.PrioritycheckBox.AutoSize = true;
            this.PrioritycheckBox.Location = new System.Drawing.Point(204, 172);
            this.PrioritycheckBox.Name = "PrioritycheckBox";
            this.PrioritycheckBox.Size = new System.Drawing.Size(15, 14);
            this.PrioritycheckBox.TabIndex = 80;
            this.PrioritycheckBox.UseVisualStyleBackColor = true;
            this.PrioritycheckBox.CheckedChanged += new System.EventHandler(this.PrioritycheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(172, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 24);
            this.label3.TabIndex = 86;
            this.label3.Text = "Select filters to be applied";
            // 
            // typecheckBox
            // 
            this.typecheckBox.AutoSize = true;
            this.typecheckBox.Location = new System.Drawing.Point(204, 98);
            this.typecheckBox.Name = "typecheckBox";
            this.typecheckBox.Size = new System.Drawing.Size(15, 14);
            this.typecheckBox.TabIndex = 96;
            this.typecheckBox.UseVisualStyleBackColor = true;
            this.typecheckBox.CheckedChanged += new System.EventHandler(this.typecheckBox_CheckedChanged_1);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(43, 93);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 94;
            this.lblType.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 97;
            this.label2.Text = "Track no from:";
            // 
            // TrackIdcheckBox
            // 
            this.TrackIdcheckBox.AutoSize = true;
            this.TrackIdcheckBox.Location = new System.Drawing.Point(204, 69);
            this.TrackIdcheckBox.Name = "TrackIdcheckBox";
            this.TrackIdcheckBox.Size = new System.Drawing.Size(15, 14);
            this.TrackIdcheckBox.TabIndex = 98;
            this.TrackIdcheckBox.UseVisualStyleBackColor = true;
            this.TrackIdcheckBox.CheckedChanged += new System.EventHandler(this.TrackIdcheckBox_CheckedChanged);
            // 
            // tBoxTrackIdfrom
            // 
            this.tBoxTrackIdfrom.Enabled = false;
            this.tBoxTrackIdfrom.Location = new System.Drawing.Point(225, 66);
            this.tBoxTrackIdfrom.Name = "tBoxTrackIdfrom";
            this.tBoxTrackIdfrom.Size = new System.Drawing.Size(154, 20);
            this.tBoxTrackIdfrom.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 100;
            this.label4.Text = "to";
            // 
            // tBoxTrackIdTo
            // 
            this.tBoxTrackIdTo.Enabled = false;
            this.tBoxTrackIdTo.Location = new System.Drawing.Point(456, 66);
            this.tBoxTrackIdTo.Name = "tBoxTrackIdTo";
            this.tBoxTrackIdTo.Size = new System.Drawing.Size(154, 20);
            this.tBoxTrackIdTo.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 102;
            this.label5.Text = "Sublocation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 103;
            this.label6.Text = "Specific location";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 104;
            this.label7.Text = "Location details";
            // 
            // checkBoxSubLocation
            // 
            this.checkBoxSubLocation.AutoSize = true;
            this.checkBoxSubLocation.Location = new System.Drawing.Point(204, 245);
            this.checkBoxSubLocation.Name = "checkBoxSubLocation";
            this.checkBoxSubLocation.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSubLocation.TabIndex = 105;
            this.checkBoxSubLocation.UseVisualStyleBackColor = true;
            this.checkBoxSubLocation.CheckedChanged += new System.EventHandler(this.checkBoxSubLocation_CheckedChanged);
            // 
            // checkBoxSpecLocation
            // 
            this.checkBoxSpecLocation.AutoSize = true;
            this.checkBoxSpecLocation.Location = new System.Drawing.Point(203, 285);
            this.checkBoxSpecLocation.Name = "checkBoxSpecLocation";
            this.checkBoxSpecLocation.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSpecLocation.TabIndex = 107;
            this.checkBoxSpecLocation.UseVisualStyleBackColor = true;
            this.checkBoxSpecLocation.CheckedChanged += new System.EventHandler(this.checkBoxSpecLocation_CheckedChanged);
            // 
            // checkBoxLocDetails
            // 
            this.checkBoxLocDetails.AutoSize = true;
            this.checkBoxLocDetails.Location = new System.Drawing.Point(203, 318);
            this.checkBoxLocDetails.Name = "checkBoxLocDetails";
            this.checkBoxLocDetails.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLocDetails.TabIndex = 109;
            this.checkBoxLocDetails.UseVisualStyleBackColor = true;
            this.checkBoxLocDetails.CheckedChanged += new System.EventHandler(this.checkBoxLocDetails_CheckedChanged);
            // 
            // cBoxDepartmentEsom
            // 
            this.cBoxDepartmentEsom.AutoSize = true;
            this.cBoxDepartmentEsom.Location = new System.Drawing.Point(204, 571);
            this.cBoxDepartmentEsom.Name = "cBoxDepartmentEsom";
            this.cBoxDepartmentEsom.Size = new System.Drawing.Size(15, 14);
            this.cBoxDepartmentEsom.TabIndex = 117;
            this.cBoxDepartmentEsom.UseVisualStyleBackColor = true;
            this.cBoxDepartmentEsom.CheckedChanged += new System.EventHandler(this.DepartmentEsomcheckBox_CheckedChanged);
            // 
            // cBoxClosingDate
            // 
            this.cBoxClosingDate.AutoSize = true;
            this.cBoxClosingDate.Location = new System.Drawing.Point(203, 501);
            this.cBoxClosingDate.Name = "cBoxClosingDate";
            this.cBoxClosingDate.Size = new System.Drawing.Size(15, 14);
            this.cBoxClosingDate.TabIndex = 116;
            this.cBoxClosingDate.UseVisualStyleBackColor = true;
            this.cBoxClosingDate.CheckedChanged += new System.EventHandler(this.cBoxCloseDate_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 495);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 115;
            this.label8.Text = "to";
            // 
            // ClosingDateOutTimePicker
            // 
            this.ClosingDateOutTimePicker.Enabled = false;
            this.ClosingDateOutTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ClosingDateOutTimePicker.Location = new System.Drawing.Point(455, 494);
            this.ClosingDateOutTimePicker.Name = "ClosingDateOutTimePicker";
            this.ClosingDateOutTimePicker.Size = new System.Drawing.Size(154, 20);
            this.ClosingDateOutTimePicker.TabIndex = 114;
            // 
            // ClosingDateInTimePicker
            // 
            this.ClosingDateInTimePicker.Enabled = false;
            this.ClosingDateInTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ClosingDateInTimePicker.Location = new System.Drawing.Point(225, 494);
            this.ClosingDateInTimePicker.Name = "ClosingDateInTimePicker";
            this.ClosingDateInTimePicker.Size = new System.Drawing.Size(154, 20);
            this.ClosingDateInTimePicker.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(43, 565);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 20);
            this.label9.TabIndex = 112;
            this.label9.Text = "Department (Esom)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(43, 494);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 111;
            this.label10.Text = "Closing Date";
            // 
            // cBoxClosedBy
            // 
            this.cBoxClosedBy.AutoSize = true;
            this.cBoxClosedBy.Location = new System.Drawing.Point(204, 533);
            this.cBoxClosedBy.Name = "cBoxClosedBy";
            this.cBoxClosedBy.Size = new System.Drawing.Size(15, 14);
            this.cBoxClosedBy.TabIndex = 120;
            this.cBoxClosedBy.UseVisualStyleBackColor = true;
            this.cBoxClosedBy.CheckedChanged += new System.EventHandler(this.ClosedBycheckBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(43, 527);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 119;
            this.label11.Text = "Closed by";
            // 
            // cBoxCompBy
            // 
            this.cBoxCompBy.AutoSize = true;
            this.cBoxCompBy.Location = new System.Drawing.Point(204, 459);
            this.cBoxCompBy.Name = "cBoxCompBy";
            this.cBoxCompBy.Size = new System.Drawing.Size(15, 14);
            this.cBoxCompBy.TabIndex = 128;
            this.cBoxCompBy.UseVisualStyleBackColor = true;
            this.cBoxCompBy.CheckedChanged += new System.EventHandler(this.CompBycheckBox_CheckedChanged);
            // 
            // lblCompBy
            // 
            this.lblCompBy.AutoSize = true;
            this.lblCompBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompBy.Location = new System.Drawing.Point(43, 453);
            this.lblCompBy.Name = "lblCompBy";
            this.lblCompBy.Size = new System.Drawing.Size(106, 20);
            this.lblCompBy.TabIndex = 127;
            this.lblCompBy.Text = "Completed by";
            // 
            // cBoxCompDate
            // 
            this.cBoxCompDate.AutoSize = true;
            this.cBoxCompDate.Location = new System.Drawing.Point(203, 427);
            this.cBoxCompDate.Name = "cBoxCompDate";
            this.cBoxCompDate.Size = new System.Drawing.Size(15, 14);
            this.cBoxCompDate.TabIndex = 126;
            this.cBoxCompDate.UseVisualStyleBackColor = true;
            this.cBoxCompDate.CheckedChanged += new System.EventHandler(this.cBoxCompDate_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(405, 421);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 20);
            this.label13.TabIndex = 125;
            this.label13.Text = "to";
            // 
            // CompDateOutTimePicker
            // 
            this.CompDateOutTimePicker.Enabled = false;
            this.CompDateOutTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CompDateOutTimePicker.Location = new System.Drawing.Point(455, 420);
            this.CompDateOutTimePicker.Name = "CompDateOutTimePicker";
            this.CompDateOutTimePicker.Size = new System.Drawing.Size(154, 20);
            this.CompDateOutTimePicker.TabIndex = 124;
            // 
            // CompDateInTimePicker
            // 
            this.CompDateInTimePicker.Enabled = false;
            this.CompDateInTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CompDateInTimePicker.Location = new System.Drawing.Point(225, 420);
            this.CompDateInTimePicker.Name = "CompDateInTimePicker";
            this.CompDateInTimePicker.Size = new System.Drawing.Size(154, 20);
            this.CompDateInTimePicker.TabIndex = 123;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(43, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 20);
            this.label14.TabIndex = 122;
            this.label14.Text = "Completion Date";
            // 
            // CompletedByFiltercheckedComboBox
            // 
            this.CompletedByFiltercheckedComboBox.CheckOnClick = true;
            this.CompletedByFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CompletedByFiltercheckedComboBox.DropDownHeight = 1;
            this.CompletedByFiltercheckedComboBox.Enabled = false;
            this.CompletedByFiltercheckedComboBox.FormattingEnabled = true;
            this.CompletedByFiltercheckedComboBox.IntegralHeight = false;
            this.CompletedByFiltercheckedComboBox.Location = new System.Drawing.Point(225, 455);
            this.CompletedByFiltercheckedComboBox.Name = "CompletedByFiltercheckedComboBox";
            this.CompletedByFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.CompletedByFiltercheckedComboBox.TabIndex = 129;
            this.CompletedByFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // ClosedByFiltercheckedComboBox
            // 
            this.ClosedByFiltercheckedComboBox.CheckOnClick = true;
            this.ClosedByFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ClosedByFiltercheckedComboBox.DropDownHeight = 1;
            this.ClosedByFiltercheckedComboBox.Enabled = false;
            this.ClosedByFiltercheckedComboBox.FormattingEnabled = true;
            this.ClosedByFiltercheckedComboBox.IntegralHeight = false;
            this.ClosedByFiltercheckedComboBox.Location = new System.Drawing.Point(225, 529);
            this.ClosedByFiltercheckedComboBox.Name = "ClosedByFiltercheckedComboBox";
            this.ClosedByFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.ClosedByFiltercheckedComboBox.TabIndex = 121;
            this.ClosedByFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // DepartmentEsomFiltercheckedComboBox
            // 
            this.DepartmentEsomFiltercheckedComboBox.CheckOnClick = true;
            this.DepartmentEsomFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DepartmentEsomFiltercheckedComboBox.DropDownHeight = 1;
            this.DepartmentEsomFiltercheckedComboBox.Enabled = false;
            this.DepartmentEsomFiltercheckedComboBox.FormattingEnabled = true;
            this.DepartmentEsomFiltercheckedComboBox.IntegralHeight = false;
            this.DepartmentEsomFiltercheckedComboBox.Location = new System.Drawing.Point(225, 567);
            this.DepartmentEsomFiltercheckedComboBox.Name = "DepartmentEsomFiltercheckedComboBox";
            this.DepartmentEsomFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.DepartmentEsomFiltercheckedComboBox.TabIndex = 118;
            this.DepartmentEsomFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // LocDetailsFiltercheckedComboBox
            // 
            this.LocDetailsFiltercheckedComboBox.CheckOnClick = true;
            this.LocDetailsFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LocDetailsFiltercheckedComboBox.DropDownHeight = 1;
            this.LocDetailsFiltercheckedComboBox.Enabled = false;
            this.LocDetailsFiltercheckedComboBox.FormattingEnabled = true;
            this.LocDetailsFiltercheckedComboBox.IntegralHeight = false;
            this.LocDetailsFiltercheckedComboBox.Location = new System.Drawing.Point(225, 315);
            this.LocDetailsFiltercheckedComboBox.Name = "LocDetailsFiltercheckedComboBox";
            this.LocDetailsFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.LocDetailsFiltercheckedComboBox.TabIndex = 110;
            this.LocDetailsFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // SpecLocationFiltercheckedComboBox
            // 
            this.SpecLocationFiltercheckedComboBox.CheckOnClick = true;
            this.SpecLocationFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SpecLocationFiltercheckedComboBox.DropDownHeight = 1;
            this.SpecLocationFiltercheckedComboBox.Enabled = false;
            this.SpecLocationFiltercheckedComboBox.FormattingEnabled = true;
            this.SpecLocationFiltercheckedComboBox.IntegralHeight = false;
            this.SpecLocationFiltercheckedComboBox.Location = new System.Drawing.Point(225, 282);
            this.SpecLocationFiltercheckedComboBox.Name = "SpecLocationFiltercheckedComboBox";
            this.SpecLocationFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.SpecLocationFiltercheckedComboBox.TabIndex = 108;
            this.SpecLocationFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // SubLocationFiltercheckedComboBox
            // 
            this.SubLocationFiltercheckedComboBox.CheckOnClick = true;
            this.SubLocationFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SubLocationFiltercheckedComboBox.DropDownHeight = 1;
            this.SubLocationFiltercheckedComboBox.Enabled = false;
            this.SubLocationFiltercheckedComboBox.FormattingEnabled = true;
            this.SubLocationFiltercheckedComboBox.IntegralHeight = false;
            this.SubLocationFiltercheckedComboBox.Location = new System.Drawing.Point(225, 245);
            this.SubLocationFiltercheckedComboBox.Name = "SubLocationFiltercheckedComboBox";
            this.SubLocationFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.SubLocationFiltercheckedComboBox.TabIndex = 106;
            this.SubLocationFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // typeFiltercheckedComboBox
            // 
            this.typeFiltercheckedComboBox.CheckOnClick = true;
            this.typeFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.typeFiltercheckedComboBox.DropDownHeight = 1;
            this.typeFiltercheckedComboBox.Enabled = false;
            this.typeFiltercheckedComboBox.FormattingEnabled = true;
            this.typeFiltercheckedComboBox.IntegralHeight = false;
            this.typeFiltercheckedComboBox.Location = new System.Drawing.Point(225, 95);
            this.typeFiltercheckedComboBox.Name = "typeFiltercheckedComboBox";
            this.typeFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.typeFiltercheckedComboBox.TabIndex = 95;
            this.typeFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // PriorityFiltercheckedComboBox
            // 
            this.PriorityFiltercheckedComboBox.CheckOnClick = true;
            this.PriorityFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.PriorityFiltercheckedComboBox.DropDownHeight = 1;
            this.PriorityFiltercheckedComboBox.Enabled = false;
            this.PriorityFiltercheckedComboBox.FormattingEnabled = true;
            this.PriorityFiltercheckedComboBox.IntegralHeight = false;
            this.PriorityFiltercheckedComboBox.Location = new System.Drawing.Point(225, 169);
            this.PriorityFiltercheckedComboBox.Name = "PriorityFiltercheckedComboBox";
            this.PriorityFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.PriorityFiltercheckedComboBox.TabIndex = 89;
            this.PriorityFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // ReportedByFiltercheckedComboBox
            // 
            this.ReportedByFiltercheckedComboBox.CheckOnClick = true;
            this.ReportedByFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ReportedByFiltercheckedComboBox.DropDownHeight = 1;
            this.ReportedByFiltercheckedComboBox.Enabled = false;
            this.ReportedByFiltercheckedComboBox.FormattingEnabled = true;
            this.ReportedByFiltercheckedComboBox.IntegralHeight = false;
            this.ReportedByFiltercheckedComboBox.Location = new System.Drawing.Point(225, 384);
            this.ReportedByFiltercheckedComboBox.Name = "ReportedByFiltercheckedComboBox";
            this.ReportedByFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.ReportedByFiltercheckedComboBox.TabIndex = 88;
            this.ReportedByFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // LocationFiltercheckedComboBox
            // 
            this.LocationFiltercheckedComboBox.CheckOnClick = true;
            this.LocationFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LocationFiltercheckedComboBox.DropDownHeight = 1;
            this.LocationFiltercheckedComboBox.Enabled = false;
            this.LocationFiltercheckedComboBox.FormattingEnabled = true;
            this.LocationFiltercheckedComboBox.IntegralHeight = false;
            this.LocationFiltercheckedComboBox.Location = new System.Drawing.Point(225, 207);
            this.LocationFiltercheckedComboBox.Name = "LocationFiltercheckedComboBox";
            this.LocationFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.LocationFiltercheckedComboBox.TabIndex = 87;
            this.LocationFiltercheckedComboBox.ValueSeparator = ", ";
            // 
            // StatusFiltercheckedComboBox
            // 
            this.StatusFiltercheckedComboBox.CheckOnClick = true;
            this.StatusFiltercheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.StatusFiltercheckedComboBox.DropDownHeight = 1;
            this.StatusFiltercheckedComboBox.Enabled = false;
            this.StatusFiltercheckedComboBox.FormattingEnabled = true;
            this.StatusFiltercheckedComboBox.IntegralHeight = false;
            this.StatusFiltercheckedComboBox.Location = new System.Drawing.Point(225, 132);
            this.StatusFiltercheckedComboBox.Name = "StatusFiltercheckedComboBox";
            this.StatusFiltercheckedComboBox.Size = new System.Drawing.Size(154, 21);
            this.StatusFiltercheckedComboBox.TabIndex = 68;
            this.StatusFiltercheckedComboBox.ValueSeparator = ", ";
            this.StatusFiltercheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheck);
            this.StatusFiltercheckedComboBox.Click += new System.EventHandler(this.StatusFiltercBox_Click);
            // 
            // LocationCheckedComboBox
            // 
            this.LocationCheckedComboBox.CheckOnClick = true;
            this.LocationCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LocationCheckedComboBox.DropDownHeight = 1;
            this.LocationCheckedComboBox.IntegralHeight = false;
            this.LocationCheckedComboBox.Location = new System.Drawing.Point(0, 0);
            this.LocationCheckedComboBox.Name = "LocationCheckedComboBox";
            this.LocationCheckedComboBox.Size = new System.Drawing.Size(121, 21);
            this.LocationCheckedComboBox.TabIndex = 0;
            this.LocationCheckedComboBox.ValueSeparator = ", ";
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 670);
            this.Controls.Add(this.CompletedByFiltercheckedComboBox);
            this.Controls.Add(this.cBoxCompBy);
            this.Controls.Add(this.lblCompBy);
            this.Controls.Add(this.cBoxCompDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.CompDateOutTimePicker);
            this.Controls.Add(this.CompDateInTimePicker);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ClosedByFiltercheckedComboBox);
            this.Controls.Add(this.cBoxClosedBy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DepartmentEsomFiltercheckedComboBox);
            this.Controls.Add(this.cBoxDepartmentEsom);
            this.Controls.Add(this.cBoxClosingDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ClosingDateOutTimePicker);
            this.Controls.Add(this.ClosingDateInTimePicker);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LocDetailsFiltercheckedComboBox);
            this.Controls.Add(this.checkBoxLocDetails);
            this.Controls.Add(this.SpecLocationFiltercheckedComboBox);
            this.Controls.Add(this.checkBoxSpecLocation);
            this.Controls.Add(this.SubLocationFiltercheckedComboBox);
            this.Controls.Add(this.checkBoxSubLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBoxTrackIdTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxTrackIdfrom);
            this.Controls.Add(this.TrackIdcheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typecheckBox);
            this.Controls.Add(this.typeFiltercheckedComboBox);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.PriorityFiltercheckedComboBox);
            this.Controls.Add(this.ReportedByFiltercheckedComboBox);
            this.Controls.Add(this.LocationFiltercheckedComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrioritycheckBox);
            this.Controls.Add(this.ReportedBycheckBox);
            this.Controls.Add(this.DateCreatedcBox);
            this.Controls.Add(this.LocationCheckBox);
            this.Controls.Add(this.statuscheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCreatedOutTimePicker);
            this.Controls.Add(this.dateCreatedInTimePicker);
            this.Controls.Add(this.StatusFiltercheckedComboBox);
            this.Controls.Add(this.prioritylbl);
            this.Controls.Add(this.reportedBylb);
            this.Controls.Add(this.dateCreatedlb);
            this.Controls.Add(this.locationlb);
            this.Controls.Add(this.statuslb);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filters";
            this.Text = "Filters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label prioritylbl;
        private System.Windows.Forms.Label reportedBylb;
        private System.Windows.Forms.Label dateCreatedlb;
        private System.Windows.Forms.Label locationlb;
        private System.Windows.Forms.Label statuslb;
        
       
        

        private System.Windows.Forms.DateTimePicker dateCreatedInTimePicker;
        private System.Windows.Forms.DateTimePicker dateCreatedOutTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox statuscheckBox;
        private System.Windows.Forms.CheckBox LocationCheckBox;
        private System.Windows.Forms.CheckBox DateCreatedcBox;
        private System.Windows.Forms.CheckBox ReportedBycheckBox;
        private System.Windows.Forms.CheckBox PrioritycheckBox;
        private System.Windows.Forms.Label label3;
        private CheckedComboBox StatusFiltercheckedComboBox;
        private CheckedComboBox LocationCheckedComboBox;
        private CheckedComboBox LocationFiltercheckedComboBox;
        private CheckedComboBox ReportedByFiltercheckedComboBox;
        private CheckedComboBox PriorityFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox typecheckBox;
        private CheckedComboBox typeFiltercheckedComboBox;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox TrackIdcheckBox;
        private System.Windows.Forms.TextBox tBoxTrackIdfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxTrackIdTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CheckedComboBox SubLocationFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox checkBoxSubLocation;
        private CheckedComboBox SpecLocationFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox checkBoxSpecLocation;
        private CheckedComboBox LocDetailsFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox checkBoxLocDetails;
        private CheckedComboBox DepartmentEsomFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox cBoxDepartmentEsom;
        private System.Windows.Forms.CheckBox cBoxClosingDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker ClosingDateOutTimePicker;
        private System.Windows.Forms.DateTimePicker ClosingDateInTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CheckedComboBox ClosedByFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox cBoxClosedBy;
        private System.Windows.Forms.Label label11;
        private CheckedComboBox CompletedByFiltercheckedComboBox;
        private System.Windows.Forms.CheckBox cBoxCompBy;
        private System.Windows.Forms.Label lblCompBy;
        private System.Windows.Forms.CheckBox cBoxCompDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker CompDateOutTimePicker;
        private System.Windows.Forms.DateTimePicker CompDateInTimePicker;
        private System.Windows.Forms.Label label14;

        public object checkedComboBox1 { get; private set; }
    }
}