namespace TBCN
{
    partial class frmChildReport : System.Windows.Forms.Form
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblAddressTitle = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblParentsTitle = new System.Windows.Forms.Label();
            this.lblParent1 = new System.Windows.Forms.LinkLabel();
            this.lblParent2 = new System.Windows.Forms.LinkLabel();
            this.lblMedical = new System.Windows.Forms.Label();
            this.lblMedicalInfo = new System.Windows.Forms.Label();
            this.lblEC2 = new System.Windows.Forms.LinkLabel();
            this.lblEC1 = new System.Windows.Forms.LinkLabel();
            this.lblECsTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChildReportEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(162, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 100);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(121, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Anne Other";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(14, 43);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(69, 13);
            this.lblRoom.TabIndex = 2;
            this.lblRoom.Text = "Panda Room";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(14, 65);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(41, 13);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Female";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(14, 87);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(128, 13);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "4 Years and 7 Months old";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(159, 123);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(69, 13);
            this.lblDOB.TabIndex = 5;
            this.lblDOB.Text = "8 June, 2008";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(159, 145);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(41, 13);
            this.lblLanguage.TabIndex = 6;
            this.lblLanguage.Text = "English";
            // 
            // lblAttendance
            // 
            this.lblAttendance.AutoSize = true;
            this.lblAttendance.Location = new System.Drawing.Point(159, 169);
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Size = new System.Drawing.Size(85, 13);
            this.lblAttendance.TabIndex = 7;
            this.lblAttendance.Text = "4 days per week";
            // 
            // lblAddressTitle
            // 
            this.lblAddressTitle.AutoSize = true;
            this.lblAddressTitle.Location = new System.Drawing.Point(14, 198);
            this.lblAddressTitle.Name = "lblAddressTitle";
            this.lblAddressTitle.Size = new System.Drawing.Size(89, 13);
            this.lblAddressTitle.TabIndex = 8;
            this.lblAddressTitle.Text = "Parent\'s Address:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(159, 198);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(75, 13);
            this.lblAddress1.TabIndex = 9;
            this.lblAddress1.Text = "12 High Street";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(159, 211);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(45, 13);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "Dundee";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Location = new System.Drawing.Point(159, 224);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(65, 13);
            this.lblCounty.TabIndex = 11;
            this.lblCounty.Text = "Dundee City";
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(159, 237);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(52, 13);
            this.lblPostCode.TabIndex = 12;
            this.lblPostCode.Text = "DD1 1XY";
            // 
            // lblParentsTitle
            // 
            this.lblParentsTitle.AutoSize = true;
            this.lblParentsTitle.Location = new System.Drawing.Point(14, 258);
            this.lblParentsTitle.Name = "lblParentsTitle";
            this.lblParentsTitle.Size = new System.Drawing.Size(46, 13);
            this.lblParentsTitle.TabIndex = 13;
            this.lblParentsTitle.Text = "Parents:";
            // 
            // lblParent1
            // 
            this.lblParent1.AutoSize = true;
            this.lblParent1.Location = new System.Drawing.Point(159, 257);
            this.lblParent1.Name = "lblParent1";
            this.lblParent1.Size = new System.Drawing.Size(59, 13);
            this.lblParent1.TabIndex = 14;
            this.lblParent1.TabStop = true;
            this.lblParent1.Text = "John Other";
            this.lblParent1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblParent1_LinkClicked);
            // 
            // lblParent2
            // 
            this.lblParent2.AutoSize = true;
            this.lblParent2.Location = new System.Drawing.Point(159, 270);
            this.lblParent2.Name = "lblParent2";
            this.lblParent2.Size = new System.Drawing.Size(0, 13);
            this.lblParent2.TabIndex = 15;
            // 
            // lblMedical
            // 
            this.lblMedical.AutoSize = true;
            this.lblMedical.Location = new System.Drawing.Point(14, 327);
            this.lblMedical.Name = "lblMedical";
            this.lblMedical.Size = new System.Drawing.Size(101, 13);
            this.lblMedical.TabIndex = 16;
            this.lblMedical.Text = "Medical information:";
            // 
            // lblMedicalInfo
            // 
            this.lblMedicalInfo.AutoSize = true;
            this.lblMedicalInfo.Location = new System.Drawing.Point(159, 327);
            this.lblMedicalInfo.Name = "lblMedicalInfo";
            this.lblMedicalInfo.Size = new System.Drawing.Size(63, 13);
            this.lblMedicalInfo.TabIndex = 17;
            this.lblMedicalInfo.Text = "Has asthma";
            // 
            // lblEC2
            // 
            this.lblEC2.AutoSize = true;
            this.lblEC2.Location = new System.Drawing.Point(159, 303);
            this.lblEC2.Name = "lblEC2";
            this.lblEC2.Size = new System.Drawing.Size(0, 13);
            this.lblEC2.TabIndex = 21;
            // 
            // lblEC1
            // 
            this.lblEC1.AutoSize = true;
            this.lblEC1.Location = new System.Drawing.Point(159, 290);
            this.lblEC1.Name = "lblEC1";
            this.lblEC1.Size = new System.Drawing.Size(59, 13);
            this.lblEC1.TabIndex = 20;
            this.lblEC1.TabStop = true;
            this.lblEC1.Text = "Joe Bloggs";
            // 
            // lblECsTitle
            // 
            this.lblECsTitle.AutoSize = true;
            this.lblECsTitle.Location = new System.Drawing.Point(14, 291);
            this.lblECsTitle.Name = "lblECsTitle";
            this.lblECsTitle.Size = new System.Drawing.Size(107, 13);
            this.lblECsTitle.TabIndex = 19;
            this.lblECsTitle.Text = "Emergency contacts:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Attendance:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DOB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "FirstLanguage:";
            // 
            // btnChildReportEdit
            // 
            this.btnChildReportEdit.Location = new System.Drawing.Point(92, 370);
            this.btnChildReportEdit.Name = "btnChildReportEdit";
            this.btnChildReportEdit.Size = new System.Drawing.Size(75, 23);
            this.btnChildReportEdit.TabIndex = 22;
            this.btnChildReportEdit.Text = "Edit Child";
            this.btnChildReportEdit.UseVisualStyleBackColor = true;
            this.btnChildReportEdit.Click += new System.EventHandler(this.btnChildReportEdit_Click);
            // 
            // frmChildReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 405);
            this.Controls.Add(this.btnChildReportEdit);
            this.Controls.Add(this.lblEC2);
            this.Controls.Add(this.lblEC1);
            this.Controls.Add(this.lblECsTitle);
            this.Controls.Add(this.lblMedicalInfo);
            this.Controls.Add(this.lblMedical);
            this.Controls.Add(this.lblParent2);
            this.Controls.Add(this.lblParent1);
            this.Controls.Add(this.lblParentsTitle);
            this.Controls.Add(this.lblPostCode);
            this.Controls.Add(this.lblCounty);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lblAddressTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picImage);
            this.Name = "frmChildReport";
            this.Text = "Child Information";
            this.Load += new System.EventHandler(this.frmChildReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblAddressTitle;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.Label lblParentsTitle;
        private System.Windows.Forms.LinkLabel lblParent1;
        private System.Windows.Forms.LinkLabel lblParent2;
        private System.Windows.Forms.Label lblMedical;
        private System.Windows.Forms.Label lblMedicalInfo;
        private System.Windows.Forms.LinkLabel lblEC2;
        private System.Windows.Forms.LinkLabel lblEC1;
        private System.Windows.Forms.Label lblECsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChildReportEdit;
    }
}