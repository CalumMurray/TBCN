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
    public partial class frmEmployeeReport : Form
    {
        Employee employee;
        public frmEmployeeReport(Employee employeeToDisplay)
        {
            InitializeComponent();
            this.employee = employeeToDisplay;
        }

        private void frmEmployeeReport_Load(object sender, EventArgs e)
        {
            //Fill in fields
            lblName.Text = employee.FirstName + " " + employee.LastName;
            lblPosition.Text = employee.Position;

            if (employee.Gender == 'M')
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";


            lblHomePhone.Text = employee.HomePhone;
            lblMobilePhone.Text = employee.MobilePhone;
            lblEmail.Text = employee.Email;

            lblDOB.Text = employee.DOB.ToShortDateString();
            lblDateStarted.Text = employee.DateStarted.ToShortDateString();

            if (employee.DateFinished == null)
                lblDateLeft.Text = "Currently Employed";
            else
                lblDateLeft.Text = employee.DateFinished.ToShortDateString();

            lblPVGDate.Text = employee.PVGDate.ToShortDateString();
            lblHolidaysEntitled.Text = Convert.ToString(employee.HolidaysEntitled);
            lblHolidaysTaken.Text = Convert.ToString(employee.HolidaysTaken);
            lblHours.Text = Convert.ToString(employee.WeeksHours);
            lblSalary.Text = "£" + Convert.ToString(employee.Salary);

            lblTraining.Text = employee.Training;

            lblAddress1.Text = employee.Address.Address1;
            lblCity.Text = employee.Address.City;
            lblCounty.Text = employee.Address.County;
            lblPostCode.Text = employee.Address.PostCode; 

            //lblEC1.Text = employee.EmergencyContact.FirstName + " " + employee.EmergencyContact.LastName;

            lblMedical.Text = employee.Medical.Allergies + "\n";
            lblMedical.Text += employee.Medical.Medication + "\n";
            lblMedical.Text += employee.Medical.Other + "\n\n";
            lblMedical.Text += employee.Medical.Doctor + "\n";
            lblMedical.Text += employee.Medical.DoctorAddress.Address1 + "\n";
            lblMedical.Text += employee.Medical.DoctorAddress.City + "\n";
            lblMedical.Text += employee.Medical.DoctorAddress.County + "\n";
            lblMedical.Text += employee.Medical.DoctorAddress.PostCode;
        }

        private void btnEmployeeReportEdit_Click(object sender, EventArgs e)
        {
            frmEditEmployee editDialog = new frmEditEmployee(employee);
            editDialog.ShowDialog();
        }
    }
}
