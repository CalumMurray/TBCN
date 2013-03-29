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
        DataContainer data;
        List<int> childIDList;
        List<string> staffIDList;
        List<int> parentIDList;
        Database db;
        public frmMainMenu()
        {
            InitializeComponent();
            data = new DataContainer();
            db = new Database();

            childIDList = new List<int>();
            staffIDList = new List<string>();
            parentIDList = new List<int>();
            data.loadItems();
        }

        //Search for children by name
        private void btnChildren_Click(object sender, EventArgs e)
        {
            bool found = false;
            String childName = txtChildren.Text;
            List<Child> foundChildren = new List<Child>();
            foreach (Child child in data.children)
            {
                if (child.FirstName == childName || child.LastName == childName)
                {
                    found = true;
                    foundChildren.Add(child);
                    
                }
            }
            if (found)
            {
                lstChildren.Items.Clear();
                lstChildren.Items.AddRange(foundChildren.ToArray());
            }
            else
                MessageBox.Show("No children were found.");

        }

        //Search for staff by name
        private void btnStaff_Click(object sender, EventArgs e)
        {
            bool found = false;
            String employeeName = txtStaff.Text;
            List<Employee> foundEmployees = new List<Employee>();
            foreach (Employee employee in data.employees)
            {
                if (employee.FirstName == employeeName || employee.LastName == employeeName)
                {
                    found = true;
                    foundEmployees.Add(employee);

                }
            }
            if (found)
            {
                lstChildren.Items.Clear();
                lstChildren.Items.AddRange(foundEmployees.ToArray());
            }
            else
                MessageBox.Show("No staff members were found.");
        }

        //Search for parents by name
        private void btnParents_Click(object sender, EventArgs e)
        {
            bool found = false;
            String parentName = txtStaff.Text;
            List<Parent> foundParents = new List<Parent>();
            foreach (Parent parent in data.parents)
            {
                if (parent.FirstName == parentName || parent.LastName == parentName)
                {
                    found = true;
                    foundParents.Add(parent);

                }
            }
            if (found)
            {
                lstChildren.Items.Clear();
                lstChildren.Items.AddRange(foundParents.ToArray());
            }
            else
                MessageBox.Show("No parents were found.");
        }

        //Check for children required to move room
        private void btnCheckAges_Click(object sender, EventArgs e)
        {
            
            List<Child> childrenToMove = db.childrenToMoveRoom();
            if (childrenToMove.Count == 0)
                MessageBox.Show("No children are scheduled to move to an older room.");
            else
            {
                lstChildren.Items.Clear();
                lstChildren.Items.AddRange(childrenToMove.ToArray());
            }
        }

        //Show all children
        private void tabChildren_Enter(object sender, EventArgs e)
        {
            lstChildren.Items.Clear();
            childIDList = new List<int>();
            foreach (Child child in data.children)
            {
                lstChildren.Items.Add(child.FirstName + " " + child.LastName);
                childIDList.Add(child.ChildID);
            }
        }

        //Show all parents
        private void tabParents_Enter(object sender, EventArgs e)
        {
            lstParents.Items.Clear();
            parentIDList = new List<int>();
            foreach (Parent parent in data.parents)
            {
                lstParents.Items.Add(parent.FirstName + " " + parent.LastName);
                parentIDList.Add(parent.ParentID);
            }
        }

        //Show all employees
        private void tabStaff_Enter(object sender, EventArgs e)
        {
            lstStaff.Items.Clear();
            staffIDList = new List<string>();
            foreach (Employee employee in data.employees)
            {
                lstStaff.Items.Add(employee.FirstName + " " + employee.LastName);
                staffIDList.Add(employee.NINo);
            }
        }

        //Select single child - view report
        private void lstChildren_DoubleClick(object sender, EventArgs e)
        {
            Child selectedChild = null;

            try
            {
                int childID = childIDList[lstChildren.SelectedIndex];

                foreach (Child child in data.children)
                {
                    if (child.ChildID == childID)
                    {
                        selectedChild = child;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedChild = null;
            }

            if (selectedChild != null)
            {
                Form childReport = new frmChildReport(selectedChild);
                childReport.ShowDialog();
            }
        }

        //Select single employee - view report
        private void lstStaff_DoubleClick(object sender, EventArgs e)
        {
            Employee selectedEmployee = null;

            try
            {
                string employeeID = staffIDList[lstStaff.SelectedIndex];

                foreach (Employee employee in data.employees)
                {
                    if (employee.NINo == employeeID)
                    {
                        selectedEmployee = employee;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedEmployee = null;
            }

            if (selectedEmployee != null)
            {
                Form employeeReport = new frmEmployeeReport(selectedEmployee);
                employeeReport.ShowDialog();
            }
        }

        //Select single parent - view report
        private void lstParents_DoubleClick(object sender, EventArgs e)
        {
            Parent selectedParent = null;

            try
            {
                int parentID = parentIDList[lstParents.SelectedIndex];

                foreach (Parent parent in data.parents)
                {
                    if (parent.ParentID == parentID)
                    {
                        selectedParent = parent;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedParent = null;
            }

            if (selectedParent != null)
            {
                Form parentReport = new frmParentReport(selectedParent);
                parentReport.ShowDialog();
            }
        }

        //Add new persons to database...

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            new frmEditParent("Add a Parent").ShowDialog();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            new frmEditEmployee().ShowDialog();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            new frmEditChild().ShowDialog();
        }

        private void btnCheckPVGDate_Click(object sender, EventArgs e)
        {
            List<Employee> employeesToRenew = db.pvgRenewals();
            if (employeesToRenew.Count == 0)
                MessageBox.Show("No employees due for PVG renewal.");
            else
            {
                lstChildren.Items.Clear();
                lstChildren.Items.AddRange(employeesToRenew.ToArray());
            }
        }

        



        





    }
}