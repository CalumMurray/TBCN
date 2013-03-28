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
        Database db;

        public frmMainMenu()
        {
            InitializeComponent();
            db = new Database();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_12ac3d03DataSet.child' table. You can move, or remove it, as needed.
            
            //TOOD: Issue Invoice every month.

            //TODO: Check children for room moves

            //TODO: Check renewal of PVG (3 years)
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            String childName = txtChildren.Text;
            List<Child> foundChildren = db.searchChildren(childName);
            lstChildren.Items.Add(foundChildren);

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            String staffSearchString = txtStaff.Text;
            List<Employee> foundStaff = db.searchStaff(staffSearchString);
            lstStaff.Items.Add(foundStaff);
        }

        private void btnParents_Click(object sender, EventArgs e)
        {
            String parentSearchString = txtParents.Text;
            List<Parent> foundParents = db.searchParent(parentSearchString);
            lstParents.Items.Add(foundParents);
        }

        private void tabControl_SelectIndexChanged(object sender, EventArgs e) 
        {
            //if (((TabControl)sender).SelectedIndex == 0/1/2)

        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            new frmEditChild().ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            new frmEditEmployee().ShowDialog();
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            new frmEditParent("Add a Parent/Contact").ShowDialog();
        }

        private void lstChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            new frmChildReport((Child)lstChildren.SelectedItem).ShowDialog();
        }

        private void lstStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            new frmEmployeeReport((Employee)lstStaff.SelectedItem).ShowDialog();
        }

        private void lstParents_SelectedIndexChanged(object sender, EventArgs e)
        {
            new frmParentReport("Parent", (Parent)lstParents.SelectedItem).ShowDialog();
        }

        private void btnCheckAges_Click(object sender, EventArgs e)
        {
            List<Child> childrenToMove = db.childrenToMoveRoom();
            if (childrenToMove.Count == 0)
                MessageBox.Show("No children are scheduled to move to an older room.");
            else
                lstChildren.Items.AddRange(childrenToMove.ToArray());
        }



        
    }
}
