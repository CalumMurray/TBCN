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
    public partial class frmParentReport : Form
    {
        Parent parent;
        DataContainer data;
        public frmParentReport(Parent parent)
        {
            InitializeComponent();
            //this.Text = title;
            this.parent = parent;
            data = new DataContainer();
        }

        public frmParentReport(EmergencyContact ec)
        {
            InitializeComponent();
            //this.Text = title;
        }

        private void frmParentReport_Load(object sender, EventArgs e)
        {
            lblName.Text = parent.Title + " " + parent.FirstName + " " + parent.LastName;

            if (parent.Gender == 'M')
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";

            lblHomePhone.Text = parent.HomePhone;
            lblWorkPhone.Text = parent.WorkPhone;
            lblMobilePhone.Text = parent.MobilePhone;

            lblHomeAddress1.Text = parent.HomeAddress.Address1;
            lblHomeCity.Text = parent.HomeAddress.City;
            lblHomeCounty.Text = parent.HomeAddress.County;
            lblHomePostCode.Text = parent.HomeAddress.PostCode;

            lblWorkAddress1.Text = parent.WorkAddress.Address1;
            lblWorkCity.Text = parent.WorkAddress.City;
            lblWorkCounty.Text = parent.WorkAddress.County;
            lblWorkPostCode.Text = parent.WorkAddress.PostCode; 

            lblChild.Text = data.children[parent.ChildrenAttending[0] - 1].FirstName + " " + data.children[parent.ChildrenAttending[0] - 1].LastName;
        }

        private void btnParentReportEdit_Click(object sender, EventArgs e)
        {
            frmEditParent editDialog = new frmEditParent("Edit Parent",parent);
            editDialog.ShowDialog();
        }

        //Parent's Child selected - Show report.
        private void lblChild_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Child parentsChild = null;
            foreach (Child child in data.children)
            {
                if (child.ChildID == parent.ChildrenAttending[0])
                {
                    parentsChild = child;
                }
            }
            if (parentsChild != null)
                new frmChildReport(parentsChild).ShowDialog();
        }




    }
}
