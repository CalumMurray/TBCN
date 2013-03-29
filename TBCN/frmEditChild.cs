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
        private DataContainer data;
        
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

            txtFirstName.Text = ChildToEdit.FirstName;
            txtLastName.Text = ChildToEdit.LastName;
            txtExtra.Text = ChildToEdit.ExtraDays.ToString();
            txtTeas.Text = ChildToEdit.Teas.ToString();
            if (ChildToEdit.Gender == 'M' )
            {
                cmbGender.Text = "Male";
            }
            else if (ChildToEdit.Gender == 'F')
            {
                cmbGender.Text = "Female";
            }
            cmbLanguage.Text = ChildToEdit.FirstLanguage;
            cmbRoom.Text = ChildToEdit.RoomAttending;
            dtpDOB.Value = ChildToEdit.DOB;
            if (ChildToEdit.DateLeft != new DateTime(0001, 1, 1, 0, 0, 0))
            {
                dtpLeaveDate.Value = ChildToEdit.DateLeft;
            }
            dtpStartDate.Value = ChildToEdit.DateApplied;

            chk1.Checked = ChildToEdit.Attendance[0];
            chk2.Checked = ChildToEdit.Attendance[1];
            chk3.Checked = ChildToEdit.Attendance[2];
            chk4.Checked = ChildToEdit.Attendance[3];
            chk5.Checked = ChildToEdit.Attendance[4];


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!validateForm())
                return;

            
            

            if (ChildToAdd.ParentsIDs[0] == 0)
            {
                MessageBox.Show("Add a parent first");
            }

            if (editing)
            {
                ChildToEdit = constructChild();
                //Update to Database
                if (dbConnection.updateChild(ChildToAdd))
                    MessageBox.Show("Child updated successfully");
                else
                    MessageBox.Show("Problem occurred while updating child");
            }
            else
            {
                ChildToAdd = constructChild();
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
            newChild.ExtraDays = Convert.ToInt16(txtExtra.Text); 
            newChild.Teas = Convert.ToInt16(txtTeas.Text);
            
            Control[] attendanceBoxes = this.Controls.Find("chk", false);

            newChild.Attendance[0] = chk1.Checked;
            newChild.Attendance[1] = chk2.Checked;
            newChild.Attendance[2] = chk3.Checked;
            newChild.Attendance[3] = chk4.Checked;
            newChild.Attendance[4] = chk5.Checked;


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

            data = new DataContainer(); //Refresh Data from DB
            ChildToAdd.EmergencyContactsIDs[0] = data.contacts[(data.contacts.Count - 1)].ContactID;
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {

            frmEditParent addParentForm = new frmEditParent("Add a Parent");
            addParentForm.ShowDialog();

            data = new DataContainer(); //Refresh Data from DB
            ChildToAdd.ParentsIDs[0] = data.parents[data.parents.Count - 1].ParentID;

        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attach photograph.");
        }

        private void btnAddMedical_Click(object sender, EventArgs e)
        {
            new frmMedicalInformation().ShowDialog();

            data = new DataContainer();
            
            
        }


    }
}
