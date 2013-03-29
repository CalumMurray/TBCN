namespace TBCN
{
    partial class frmParentReport : System.Windows.Forms.Form
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHomeAddress1 = new System.Windows.Forms.Label();
            this.lblHomeCity = new System.Windows.Forms.Label();
            this.lblHomeCounty = new System.Windows.Forms.Label();
            this.lblHomePostCode = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblChild = new System.Windows.Forms.LinkLabel();
            this.lblMobilePhone = new System.Windows.Forms.Label();
            this.lblWorkPostCode = new System.Windows.Forms.Label();
            this.lblWorkCounty = new System.Windows.Forms.Label();
            this.lblWorkCity = new System.Windows.Forms.Label();
            this.lblWorkAddress1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.LinkLabel();
            this.lblWorkPhone = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnParentReportEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(155, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Mr. John Other";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(14, 39);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(30, 13);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Male";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(149, 58);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(69, 13);
            this.lblDOB.TabIndex = 5;
            this.lblDOB.Text = "8 June, 2008";
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.AutoSize = true;
            this.lblHomePhone.Location = new System.Drawing.Point(149, 78);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(76, 13);
            this.lblHomePhone.TabIndex = 6;
            this.lblHomePhone.Text = "01382 123456";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Home Address:";
            // 
            // lblHomeAddress1
            // 
            this.lblHomeAddress1.AutoSize = true;
            this.lblHomeAddress1.Location = new System.Drawing.Point(149, 159);
            this.lblHomeAddress1.Name = "lblHomeAddress1";
            this.lblHomeAddress1.Size = new System.Drawing.Size(75, 13);
            this.lblHomeAddress1.TabIndex = 9;
            this.lblHomeAddress1.Text = "12 High Street";
            // 
            // lblHomeCity
            // 
            this.lblHomeCity.AutoSize = true;
            this.lblHomeCity.Location = new System.Drawing.Point(149, 172);
            this.lblHomeCity.Name = "lblHomeCity";
            this.lblHomeCity.Size = new System.Drawing.Size(45, 13);
            this.lblHomeCity.TabIndex = 10;
            this.lblHomeCity.Text = "Dundee";
            // 
            // lblHomeCounty
            // 
            this.lblHomeCounty.AutoSize = true;
            this.lblHomeCounty.Location = new System.Drawing.Point(149, 185);
            this.lblHomeCounty.Name = "lblHomeCounty";
            this.lblHomeCounty.Size = new System.Drawing.Size(65, 13);
            this.lblHomeCounty.TabIndex = 11;
            this.lblHomeCounty.Text = "Dundee City";
            // 
            // lblHomePostCode
            // 
            this.lblHomePostCode.AutoSize = true;
            this.lblHomePostCode.Location = new System.Drawing.Point(149, 198);
            this.lblHomePostCode.Name = "lblHomePostCode";
            this.lblHomePostCode.Size = new System.Drawing.Size(52, 13);
            this.lblHomePostCode.TabIndex = 12;
            this.lblHomePostCode.Text = "DD1 1XY";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Parent of:";
            // 
            // lblChild
            // 
            this.lblChild.AutoSize = true;
            this.lblChild.Location = new System.Drawing.Point(149, 289);
            this.lblChild.Name = "lblChild";
            this.lblChild.Size = new System.Drawing.Size(61, 13);
            this.lblChild.TabIndex = 14;
            this.lblChild.TabStop = true;
            this.lblChild.Text = "Anne Other";
            this.lblChild.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChild_LinkClicked);
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.AutoSize = true;
            this.lblMobilePhone.Location = new System.Drawing.Point(149, 91);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(76, 13);
            this.lblMobilePhone.TabIndex = 22;
            this.lblMobilePhone.Text = "07445 123456";
            // 
            // lblWorkPostCode
            // 
            this.lblWorkPostCode.AutoSize = true;
            this.lblWorkPostCode.Location = new System.Drawing.Point(149, 265);
            this.lblWorkPostCode.Name = "lblWorkPostCode";
            this.lblWorkPostCode.Size = new System.Drawing.Size(52, 13);
            this.lblWorkPostCode.TabIndex = 27;
            this.lblWorkPostCode.Text = "DD1 1XY";
            // 
            // lblWorkCounty
            // 
            this.lblWorkCounty.AutoSize = true;
            this.lblWorkCounty.Location = new System.Drawing.Point(149, 252);
            this.lblWorkCounty.Name = "lblWorkCounty";
            this.lblWorkCounty.Size = new System.Drawing.Size(65, 13);
            this.lblWorkCounty.TabIndex = 26;
            this.lblWorkCounty.Text = "Dundee City";
            // 
            // lblWorkCity
            // 
            this.lblWorkCity.AutoSize = true;
            this.lblWorkCity.Location = new System.Drawing.Point(149, 239);
            this.lblWorkCity.Name = "lblWorkCity";
            this.lblWorkCity.Size = new System.Drawing.Size(45, 13);
            this.lblWorkCity.TabIndex = 25;
            this.lblWorkCity.Text = "Dundee";
            // 
            // lblWorkAddress1
            // 
            this.lblWorkAddress1.AutoSize = true;
            this.lblWorkAddress1.Location = new System.Drawing.Point(149, 226);
            this.lblWorkAddress1.Name = "lblWorkAddress1";
            this.lblWorkAddress1.Size = new System.Drawing.Size(83, 13);
            this.lblWorkAddress1.TabIndex = 24;
            this.lblWorkAddress1.Text = "18 Brown Street";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 226);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "Work Address:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Email address: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(149, 131);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(85, 13);
            this.lblEmail.TabIndex = 29;
            this.lblEmail.TabStop = true;
            this.lblEmail.Text = "john@other.com";
            // 
            // lblWorkPhone
            // 
            this.lblWorkPhone.AutoSize = true;
            this.lblWorkPhone.Location = new System.Drawing.Point(149, 104);
            this.lblWorkPhone.Name = "lblWorkPhone";
            this.lblWorkPhone.Size = new System.Drawing.Size(49, 13);
            this.lblWorkPhone.TabIndex = 22;
            this.lblWorkPhone.Text = "2321312";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "DOB: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Home Phone No: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mobile Phone No: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Work Phone No.:";
            // 
            // btnParentReportEdit
            // 
            this.btnParentReportEdit.Location = new System.Drawing.Point(76, 318);
            this.btnParentReportEdit.Name = "btnParentReportEdit";
            this.btnParentReportEdit.Size = new System.Drawing.Size(75, 23);
            this.btnParentReportEdit.TabIndex = 30;
            this.btnParentReportEdit.Text = "Edit Parent";
            this.btnParentReportEdit.UseVisualStyleBackColor = true;
            this.btnParentReportEdit.Click += new System.EventHandler(this.btnParentReportEdit_Click);
            // 
            // frmParentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 353);
            this.Controls.Add(this.btnParentReportEdit);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblWorkPostCode);
            this.Controls.Add(this.lblWorkCounty);
            this.Controls.Add(this.lblWorkCity);
            this.Controls.Add(this.lblWorkAddress1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWorkPhone);
            this.Controls.Add(this.lblMobilePhone);
            this.Controls.Add(this.lblChild);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblHomePostCode);
            this.Controls.Add(this.lblHomeCounty);
            this.Controls.Add(this.lblHomeCity);
            this.Controls.Add(this.lblHomeAddress1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHomePhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblName);
            this.Name = "frmParentReport";
            this.Text = "Parent Information";
            this.Load += new System.EventHandler(this.frmParentReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHomeAddress1;
        private System.Windows.Forms.Label lblHomeCity;
        private System.Windows.Forms.Label lblHomeCounty;
        private System.Windows.Forms.Label lblHomePostCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lblChild;
        private System.Windows.Forms.Label lblMobilePhone;
        private System.Windows.Forms.Label lblWorkPostCode;
        private System.Windows.Forms.Label lblWorkCounty;
        private System.Windows.Forms.Label lblWorkCity;
        private System.Windows.Forms.Label lblWorkAddress1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel lblEmail;
        private System.Windows.Forms.Label lblWorkPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnParentReportEdit;
    }
}