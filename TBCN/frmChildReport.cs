using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TBCN
{
    public partial class frmChildReport : Form
    {
        private Child child;
        private Parent childsParent; 
        private EmergencyContact childsContact;

        public frmChildReport(Child childtoDisplay, Parent childsParent /*, EmergencyContact childsContact*/)
        {
            InitializeComponent();
            child = childtoDisplay;
            this.childsParent = childsParent;
            this.childsContact = childsContact;
        }


        private string showAttendance()
        {
            String attendance = "";
            if (child.Attendance[0]) attendance += "M ";
            if (child.Attendance[1]) attendance += "Tu ";
            if (child.Attendance[2]) attendance += "W ";
            if (child.Attendance[3]) attendance += "Th ";
            if (child.Attendance[4]) attendance += "F";
            return attendance;

        }

        private string calculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age + "years old";
        }

        private void lblParent1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmParentReport parentReport = new frmParentReport(childsParent, child);
            parentReport.Show();
        }

        private void lblParent2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmParentReport parentReport = new frmParentReport(childsParent, child);
            parentReport.Show();
        }

        private void lblEC1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmParentReport ecReport = new frmParentReport(childsContact, child);
            //ecReport.Show();
        }

        private void lblEC2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmParentReport ecReport = new frmParentReport(childsContact, child);
            //ecReport.Show();
        }

        private void frmChildReport_Load(object sender, EventArgs e)
        {
            lblName.Text = child.FirstName + " " + child.LastName;
            lblRoom.Text = child.RoomAttending;

            if (child.Gender == 'M' || child.Gender == 'm')
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";

            lblAge.Text = calculateAge(child.DOB);
            lblDOB.Text = child.DOB.ToShortDateString();
            lblLanguage.Text = child.FirstLanguage;
            lblAttendance.Text = showAttendance();

            
            lblAddress1.Text = childsParent.HomeAddress.Address1; //Correct?
            lblCity.Text = childsParent.HomeAddress.City; //Correct?
            lblCounty.Text = childsParent.HomeAddress.County; //Correct?
            lblPostCode.Text = childsParent.HomeAddress.PostCode; //Correct?

            lblParent1.Text = childsParent.FirstName + " " + childsParent.LastName;
            lblParent2.Text = childsParent.FirstName + " " + childsParent.LastName;

            lblEC1.Text = childsContact.FirstName + " " + childsContact.LastName;
            lblEC2.Text = childsContact.FirstName + " " + childsContact.LastName;

            lblMedicalInfo.Text = child.MedicalInfo.ToString();
        }



    }
}
