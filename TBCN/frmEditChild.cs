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
        private Database dbConnection;

        //private static Child newChild;
        public static Child ChildAdded { get; set;  }


        //Test parents & ECs
        Parent parent1 = new Parent();
        Parent parent2 = new Parent();
        EmergencyContact ec1 = new EmergencyContact();
        EmergencyContact ec2 = new EmergencyContact();


        private List<Parent> parents;
        private List<EmergencyContact> emergencyContacts;

        public frmEditChild()
        {
            InitializeComponent();
            dbConnection = new Database();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!validateForm())
                return;

            ChildAdded = constructChild();

            testParents();

            //if (frmEditParent.AddedParent == null)
            //{
            //    MessageBox.Show("Please add parents and emergency contacts first");
            //    return;
            //}
            //parents.Add(frmEditParent.AddedParent);

            //Add to Database
            if (dbConnection.insertChild(ChildAdded))
                MessageBox.Show("Child added successfully");
            else
                MessageBox.Show("Problem occurred while adding child");
        }

        private bool validateForm()
        {

            // Input validation
            bool invalidFields = false;
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    invalidFields = validateTextBox(control as TextBox); //TODO: Mark boxes to be corrected?
                    
                    if (invalidFields)
                    {
                        MessageBox.Show("There are errors in certain fields.");
                        return false;
                    }
                }
            }
            return true;
        }

        private Child constructChild()
        {
            Child newChild = new Child();
            newChild.FirstName = txtFirstName.Text;
            newChild.LastName = txtLastName.Text;
            newChild.Gender = cmbGender.Text[0];
            newChild.DOB = dtpDOB.Value; 
            newChild.FirstLanguage = cmbLanguage.Text;
            newChild.RoomAttending = cmbRoom.Text;
            newChild.DateApplied = dtpStartDate.Value;
            newChild.DateLeft = dtpLeaveDate.Value;
            newChild.ExtraDays = Convert.ToInt16(txtExtra.Text); //TODO: Number or specific days
            newChild.Teas = Convert.ToInt16(txtTeas.Text);
            
            //Get attendance //TODO: Number of specific days
            Control[] attendanceBoxes = this.Controls.Find("chk", false);
            
            for (int i = 0; i < attendanceBoxes.Length; i++)
                newChild.Attendance[i] = ((CheckBox)attendanceBoxes[i]).Checked;


            return newChild;
        }


        private bool validateTextBox(TextBox textBox)
        {
            return (textBox.Text.Length == 0);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        //TODO: Make Child Form so we can keep reference to created Parent
        private void btnAddEC_Click(object sender, EventArgs e)
        {
            
            new frmEditParent("Add an Emergency Contact").ShowDialog();
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {

            frmEditParent addParentForm = new frmEditParent("Add a Parent");
            addParentForm.FormClosed += new FormClosedEventHandler(frmAddParent_Closed);    //Register to be notified when parent closed
            addParentForm.ShowDialog();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attach photograph.");
        }

        private void btnAddMedical_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Medical Information form.");
        }

        private void frmAddParent_Closed(object sender, FormClosedEventArgs e)
        {

        }


        private void testParents()
        {
            parent1.FirstName = "Calum";
            parent1.LastName = "Murray";
            parent1.Title = "Mr";
            parent1.Gender = 'M';
            parent1.WorkPhone = "120338194";
            parent1.HomePhone = "843975823";
            parent1.MobilePhone = "234345434";
            //parent1.HomeAddress = 1;
            //parent1.WorkAddress = 2;
            //parent1.Spouse = 4;
            parent1.Email = "Calum@email.com";

            parent2.FirstName = "Joyce";
            parent2.LastName = "Murray";
            parent2.Title = "Mrs";
            parent2.Gender = 'F';
            parent2.WorkPhone = "120338194";
            parent2.HomePhone = "843975823";
            parent2.MobilePhone = "234345434";
            //parent2.HomeAddress = 1;
            //parent2.WorkAddress = 3;
            //parent2.Spouse = 3;
            parent2.Email = "Joyce@email.com";

        }

    }
}
