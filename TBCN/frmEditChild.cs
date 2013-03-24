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
    public partial class frmEditChild : Form
    {
        public frmEditChild()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Create a child from data
            Child newChild = new Child();


            // Input validation
            bool invalidFields = false;
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    invalidFields = validateTextBox(control as TextBox); //TODO: Mark boxes to be corrected?
                    
                    if (invalidFields)
                    {
                        MessageBox.Show("There are some errors in fields.");
                        return;
                    }
                }
            }

            newChild.FirstName = txtFirstName.Text;
            newChild.LastName = txtLastName.Text;
            newChild.Gender = cmbGender.Text[0];
            //newChild.DOB = dtpDOB.Text; //TODO: To Date
            newChild.FirstLanguage = cmbLanguage.Text;
            newChild.RoomAttending = cmbRoom.Text;
            //newChild.DateApplied = dtpStartDate.Text;//TODO: To Date
            //newChild.DateLeft = dtpLeaveDate.Text;//TODO: To Date
            newChild.ExtraDays = Convert.ToInt16(txtExtra.Text); //TODO: Number or specific days
            newChild.Teas = Convert.ToInt16(txtTeas.Text);
            
            ////Get attendance //TODO: Number or specific days
            //Control[] attendanceBoxes = this.Controls.Find("chk", false);
            //bool[] days = new bool[5];
            //int i = 0;
            //foreach (Control checkBox in attendanceBoxes)
            //{
            //    if (((CheckBox)checkBox).Checked)
            //        i++;
            //}
            //newChild.Attendance = i;

           
        }


        private bool validateTextBox(TextBox textBox)
        {
            return (textBox.Text.Length == 0);



        }

        private void frmEditChild_Load(object sender, EventArgs e)
        {

        }

       

    }
}
