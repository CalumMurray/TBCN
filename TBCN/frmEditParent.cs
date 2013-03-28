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
    public partial class frmEditParent : Form
    {
        private Database dbConnection;

        //private static Parent parent;
        //public static Parent AddedParent { get; set;}

        

        public frmEditParent(String title)
        {
            InitializeComponent();
            this.Text = title;
            dbConnection = new Database();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Parent createdParent = new Parent();

            createdParent = constructParent();

            dbConnection.insertParent(createdParent);
        }

        private Parent constructParent()
        {
            Parent createdParent = new Parent();
            createdParent.Title = txtTitle.Text;
            createdParent.FirstName = txtFirstName.Text;
            createdParent.LastName = txtLastName.Text;
            createdParent.Gender = cmbGender.Text[0];
            createdParent.HomePhone = txtHomePhone.Text;
            createdParent.WorkPhone = txtWorkPhone.Text;
            createdParent.MobilePhone = txtMobilePhone.Text;


            createdParent.HomeAddress = constructHomeAddress();
            createdParent.WorkAddress = constructWorkAddress();

            return createdParent;
            
        }

        private Address constructHomeAddress()
        {
            Address newAddress = new Address();
            newAddress.Address1 = txtHomeAddress1.Text;
            newAddress.City = txtHomeTown.Text;
            newAddress.County = txtHomeCounty.Text;
            newAddress.PostCode = txtHomePostCode.Text;
            newAddress.Country = "UK";
            return newAddress;
        }

        private Address constructWorkAddress()
        {
            Address newAddress = new Address();
            newAddress.Address1 = txtWorkAddress1.Text;
            newAddress.City = txtWorkTown.Text;
            newAddress.County = txtWorkCounty.Text;
            newAddress.PostCode = txtWorkPostCode.Text;
            newAddress.Country = "UK";
            return newAddress;
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditParent_Load(object sender, EventArgs e)
        {

        }
    }
}
