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
    public partial class frmEditEmployee : Form
    {
        private Database dbConnection;

        //private Employee createdEmployee;

        public frmEditEmployee()
        {
            InitializeComponent();
            dbConnection = new Database();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Validate form

            Employee createdEmployee = constructEmployee();

            dbConnection.insertEmployee(createdEmployee);
        }

        private Employee constructEmployee()
        {
            Employee createdEmployee = new Employee();
            createdEmployee.NINo = txtNINo.Text;
            createdEmployee.FirstName = txtFirstName.Text;
            createdEmployee.LastName = txtLastName.Text;
            createdEmployee.Gender = cmbGender.Text[0];
            createdEmployee.DOB = dtpDOB.Value;
            createdEmployee.DateStarted = dtpStartDate.Value;
            createdEmployee.DateFinished = dtpLeaveDate.Value;
            createdEmployee.PVGDate = dtpPVGDate.Value;
            createdEmployee.HolidaysEntitled = Convert.ToInt16(txtEntitledHolidays.Text);
            createdEmployee.HolidaysTaken = Convert.ToInt16(txtHolidaysTaken.Text);
            createdEmployee.WeeksHours = Convert.ToInt16(txtHours.Text);
            createdEmployee.Salary = Convert.ToInt16(txtSalary.Text);

            createdEmployee.HomePhone = txtPhone.Text;
            createdEmployee.MobilePhone = txtMobile.Text;
            createdEmployee.Email = txtEmail.Text;

            createdEmployee.Address = constructAddress();
            
            //Medical
            //EmergencyContact
            return createdEmployee;
            
        }

        private Address constructAddress()
        {
            Address newAddress = new Address();
            newAddress.Address1 = txtAddress1.Text;
            newAddress.City = txtCity.Text;
            newAddress.County = txtCounty.Text;
            newAddress.PostCode = txtPostCode.Text;
            newAddress.Country = "UK";
            return newAddress;
        }


        private void btnAddEC_Click(object sender, EventArgs e)
        {
            new frmEditParent("Add Employee's Emergency Contact").ShowDialog();
        }

        private void btnAddMedical_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Employee's Medical Information");
        }

        private void btnAddTraining_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Additional Training");
        }




    }
}
