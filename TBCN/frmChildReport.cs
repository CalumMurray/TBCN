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

        public frmChildReport(Child childtoDisplay)
        {
            InitializeComponent();
            child = childtoDisplay;
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
            //frmParentReport parentReport = new frmParentReport(child.Parents[0]);
            //parentReport.Show();
        }

        private void lblParent2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmParentReport parentReport = new frmParentReport(child.Parents[1]);
            //parentReport.Show();
        }

        private void lblEC1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmParentReport ecReport = new frmParentReport(child.EmergencyContacts[0]);
            //ecReport.Show();
        }

        private void lblEC2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmParentReport ecReport = new frmParentReport(child.EmergencyContacts[1]);
            //ecReport.Show();
        }

        private void frmChildReport_Load(object sender, EventArgs e)
        {
            lblName.Text = child.FirstName + " " + child.LastName;
            lblRoom.Text = child.RoomAttending;

            if (child.Gender == 'M')
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";

            lblAge.Text = calculateAge(child.DOB);
            lblDOB.Text = child.DOB.ToShortDateString();
            lblLanguage.Text = child.FirstLanguage;
            lblAttendance.Text = showAttendance();

            //lblAddress1.Text = child.Parents[0].HomeAddress.Address1; //Correct?
            //lblCity.Text = child.Parents[0].HomeAddress.City; //Correct?
            //lblCounty.Text = child.Parents[0].HomeAddress.County; //Correct?
            //lblPostCode.Text = child.Parents[0].HomeAddress.PostCode; //Correct?

            //lblParent1.Text = child.Parents[0].FirstName + " " + child.Parents[0].LastName;
            //lblParent2.Text = child.Parents[1].FirstName + " " + child.Parents[1].LastName;

            //lblEC1.Text = child.EmergencyContacts[0].FirstName + " " + child.EmergencyContacts[0].LastName;
            //lblEC2.Text = child.EmergencyContacts[1].FirstName + " " + child.EmergencyContacts[1].LastName;

            //lblMedicalInfo.Text = child.MedicalInfo.ToString();
        }



    }
}
