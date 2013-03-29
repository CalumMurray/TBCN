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
    public partial class frmMedicalInformation : Form
    {
        MedicalInformation medicalToAdd;
        public frmMedicalInformation()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            medicalToAdd.Allergies = txtAllergies.Text;
            medicalToAdd.Medication = txtMedication.Text;
            medicalToAdd.Other = txtOther.Text;
            medicalToAdd.Doctor = txtDocname.Text;
            medicalToAdd.DoctorAddress = constructAddress();
            Database db = new Database();
            db.insertAddress(medicalToAdd.DoctorAddress);
            db.insertMedical(medicalToAdd);
        }

        private Address constructAddress()
        {
            Address newAddress = new Address();
            newAddress.Address1 = txtAddress1.Text;
            newAddress.City = txtCity.Text;
            newAddress.County = txtCounty.Text;
            newAddress.PostCode = txtPostcode.Text;
            newAddress.Country = "UK";
            return newAddress;
        }

      
    }
}
