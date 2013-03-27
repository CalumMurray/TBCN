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

        private void frmMainMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            String childName = txtChildren.Text;
            List<Child> foundChildren = db.searchChildren(childName);


        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            String staffSearchString = txtStaff.Text;
            List<Employee> foundStaff = db.searchStaff(staffSearchString);
        }

        private void btnParents_Click(object sender, EventArgs e)
        {
            String parentSearchString = txtParents.Text;
            //List<Parent> foundStaff = db.searchParent(parentSearchString);
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

        
    }
}
