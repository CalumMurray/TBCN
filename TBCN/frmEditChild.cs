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

        public Child ChildToAdd { get; set;  }
        public Child ChildToEdit {get; set;}
        private bool editing = false;
        
        public frmEditChild()
        {
            InitializeComponent();
            dbConnection = new Database();

        }

        public frmEditChild(Child childToEdit)
        {
            InitializeComponent();
            dbConnection = new Database();
            ChildToEdit = childToEdit;
            editing = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!validateForm())
                return;

            ChildToAdd = constructChild();
            ChildToEdit = constructChild();

            if (ChildToAdd.ParentsIDs[0] == 0)
            {
                MessageBox.Show("Add a parent first");
            }

            if (editing)
            {
                //Update to Database
                if (dbConnection.updateChild(ChildToAdd))
                    MessageBox.Show("Child updated successfully");
                else
                    MessageBox.Show("Problem occurred while updating child");
            }
            else
            {
                //Add to Database
                if (dbConnection.insertChild(ChildToAdd))
                    MessageBox.Show("Child added successfully");
                else
                    MessageBox.Show("Problem occurred while adding child");
            }
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
            
            //new frmEditParent("Add an Emergency Contact").ShowDialog();

            //DataContainer data = new DataContainer(); //Refresh Data from DB
            //ChildToAdd.EmergencyContactsIDs[0] = data.contacts[(data.contacts.Count - 1].ContactID;
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {

            frmEditParent addParentForm = new frmEditParent("Add a Parent");
            addParentForm.ShowDialog();

            DataContainer data = new DataContainer(); //Refresh Data from DB
            ChildToAdd.ParentsIDs[0] = data.parents[data.parents.Count - 1].ParentID;

        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attach photograph.");
        }

        private void btnAddMedical_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Medical Information form.");
        }


    }
}
