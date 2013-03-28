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
    public partial class frmMainMenu : Form
    {
        public DataContainer DataContainer { get; set; }
        List<int> childIDList;
        List<string> staffIDList;
        List<int> parentIDList;

        public frmMainMenu()
        {
            InitializeComponent();
            DataContainer = new DataContainer();

            childIDList = new List<int>();
            staffIDList = new List<string>();
            parentIDList = new List<int>();
            DataContainer.loadItems();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads DataContainer into the '_12ac3d03DataSet.child' table. You can move, or remove it, as needed.
            
            //TOOD: Issue Invoice every month.

            //TODO: Check children for room moves

            //TODO: Check renewal of PVG (3 years)


            
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
           // String childName = txtChildren.Text;
           //List<Child> foundChildren = db.searchChildren(childName);
           //lstChildren.Items.Add(foundChildren);

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            //String staffSearchString = txtStaff.Text;
            //List<Employee> foundStaff = db.searchStaff(staffSearchString);
            //lstStaff.Items.Add(foundStaff);
        }

        private void btnParents_Click(object sender, EventArgs e)
        {
            //String parentSearchString = txtParents.Text;
            //List<Parent> foundParents = db.searchParent(parentSearchString);
            //lstParents.Items.Add(foundParents);
        }

        private void btnCheckAges_Click(object sender, EventArgs e)
        {
            //List<Child> childrenToMove = db.childrenToMoveRoom();
            //if (childrenToMove.Count == 0)
            //    MessageBox.Show("No children are scheduled to move to an older room.");
            //else
            //    lstChildren.Items.AddRange(childrenToMove.ToArray());
        }

        private void tabChildren_Enter(object sender, EventArgs e)
        {
            lstChildren.Items.Clear();
            childIDList = new List<int>();
            foreach (Child child in DataContainer.children)
            {
                lstChildren.Items.Add(child.FirstName + " " + child.LastName);
                childIDList.Add(child.ChildID);
            }
        }

        private void lstChildren_DoubleClick(object sender, EventArgs e)
        {
            Child selectedChild = null;
            Parent childsParent = null;
            EmergencyContact childsContact = null;

            try
            {
                int childID = childIDList[lstChildren.SelectedIndex];

                foreach (Child child in DataContainer.children)
                {
                    if (child.ChildID == childID)
                        selectedChild = child;
                }
                foreach (Parent parent in DataContainer.parents)
                {
                    if (parent.ParentID == selectedChild.ParentsIDs[0])
                        childsParent = parent;
                }
                //foreach (EmergencyContact contact in DataContainer.emergencyContacts)
                //{
                //    if (contact.ContactID == selectedChild.EmergencyContactsIDs[0])
                //        childsContact = contact;
                //}
            }
            catch (ArgumentOutOfRangeException error)
            {
                selectedChild = null;
            }

            if (selectedChild != null)
            {
                Form childReport = new frmChildReport(selectedChild, childsParent /*, childsContact*/);
                childReport.ShowDialog();
            }
        }

        private void lstStaff_DoubleClick(object sender, EventArgs e)
        {
            Employee selectedEmployee = null;

            try
            {
                string employeeID = staffIDList[lstStaff.SelectedIndex];

                foreach (Employee employee in DataContainer.employees)
                {
                    if (employee.NINo == employeeID)
                    {
                        selectedEmployee = employee;
                    }
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                selectedEmployee= null;
            }

            if (selectedEmployee != null)
            {
                Form employeeReport = new frmEmployeeReport(selectedEmployee);
                employeeReport.ShowDialog();
            }
        }

        private void lstParents_DoubleClick(object sender, EventArgs e)
        {
            Parent selectedParent = null;
            Child parentsChild = null;
            try
            {
                int parentID = parentIDList[lstParents.SelectedIndex];

                foreach (Parent parent in DataContainer.parents)
                {
                    if (parent.ParentID == parentID)
                        selectedParent = parent;
                }
                foreach (Child child in DataContainer.children)
                {
                    if (child.ChildID == selectedParent.ChildrenAttending[0])
                        parentsChild = child;
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                selectedParent = null;
            }

            if (selectedParent != null)
            {
                Form parentReport = new frmParentReport(selectedParent, parentsChild);
                parentReport.ShowDialog();
            }
        }

        private void tabParents_Enter(object sender, EventArgs e)
        {
            lstParents.Items.Clear();
            parentIDList = new List<int>();
            foreach (Parent parent in DataContainer.parents)
            {
                lstParents.Items.Add(parent.FirstName + " " + parent.LastName);
                parentIDList.Add(parent.ParentID);
            }
        }

        private void tabStaff_Enter(object sender, EventArgs e)
        {
            lstStaff.Items.Clear();
            staffIDList = new List<string>();
            foreach (Employee employee in DataContainer.employees)
            {
                lstStaff.Items.Add(employee.FirstName + " " + employee.LastName);
                staffIDList.Add(employee.NINo);
            }
        }

        private void frmMainMenu_Load_1(object sender, EventArgs e)
        {

        }



    }
}
