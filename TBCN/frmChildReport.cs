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
        private DataContainer data;

        public frmChildReport(Child childtoDisplay)
        {
            InitializeComponent();
            child = childtoDisplay;
            data = new DataContainer();
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
            return age + " years old";
        }

        private void lblParent1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parent clickedParent = null;

            try
            {
                foreach (Parent parent in data.parents)
                {
                    if (parent.ParentID == child.ParentsIDs[0])
                    {
                        clickedParent = parent;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            if (clickedParent != null)
            {
                frmParentReport parentReport = new frmParentReport(clickedParent);
                parentReport.Show();
            }
        }

        private void lblParent2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parent clickedParent = null;

            try
            {
                foreach (Parent parent in data.parents)
                {
                    if (parent.ParentID == child.ParentsIDs[1])
                    {
                        clickedParent = parent;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            if (clickedParent != null)
            {
                frmParentReport parentReport = new frmParentReport(clickedParent);
                parentReport.Show();
            }
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

            try
            {
                lblAddress1.Text = data.parents[child.ParentsIDs[0]-1].HomeAddress.Address1; //Correct?
                lblCity.Text = data.parents[child.ParentsIDs[0]-1].HomeAddress.City; //Correct?
                lblCounty.Text = data.parents[child.ParentsIDs[0]-1].HomeAddress.County; //Correct?
                lblPostCode.Text = data.parents[child.ParentsIDs[0]-1].HomeAddress.PostCode; //Correct?
            }
            catch (ArgumentOutOfRangeException)
            {
                lblAddress1.Text = "";
                lblCity.Text = "";
                lblCounty.Text = "";
                lblPostCode.Text = "";
            }
            catch (NullReferenceException)
            {
                lblAddress1.Text = "";
                lblCity.Text = "";
                lblCounty.Text = "";
                lblPostCode.Text = "";
            }

            try
            {
                lblParent1.Text = data.parents[child.ParentsIDs[0]-1].FirstName + " " + data.parents[child.ParentsIDs[0]-1].LastName;
            }
            catch (ArgumentOutOfRangeException)
            {
                lblParent1.Text = "";
            }
            catch (NullReferenceException)
            {
                lblParent1.Text = "";
            }

            try
            {
                lblParent2.Text = data.parents[child.ParentsIDs[1]-1].FirstName + " " + data.parents[child.ParentsIDs[1]-1].LastName;
            }
            catch (ArgumentOutOfRangeException)
            {
                lblParent2.Text = "";
            }
            catch (NullReferenceException)
            {
                lblParent2.Text = "";
            }

            //lblEC1.Text = child.EmergencyContacts[0].FirstName + " " + child.EmergencyContacts[0].LastName;
            //lblEC2.Text = child.EmergencyContacts[1].FirstName + " " + child.EmergencyContacts[1].LastName;

            //lblMedicalInfo.Text = child.MedicalInfo.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditChild editForm = new frmEditChild(child);
            editForm.ShowDialog();
            data = new DataContainer();
        }
    }
}
