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
        TestMain data;

        public frmMainMenu()
        {
            InitializeComponent();
            data = new TestMain();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtChildren.Text == "Enter child name to search for...")
            {
                txtChildren.Clear();
                txtChildren.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtChildren.Text == "")
            {
                txtChildren.ForeColor = Color.Gray;
                txtChildren.Text = "Enter child name to search for...";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtStaff.Text == "Enter staff member name to search for...")
            {
                txtStaff.Clear();
                txtStaff.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtStaff.Text == "")
            {
                txtStaff.ForeColor = Color.Gray;
                txtStaff.Text = "Enter staff member name to search for...";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtParents.Text == "Enter parent name to search for...")
            {
                txtParents.Clear();
                txtParents.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtParents.Text == "")
            {
                txtParents.ForeColor = Color.Gray;
                txtParents.Text = "Enter parent name to search for...";
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            lstChildren.Items.Clear();

            foreach (Child child in data.children)
            {
                lstChildren.Items.Add(child.FirstName + " " + child.LastName);
            }
        }

        private void tabParents_Enter(object sender, EventArgs e)
        {
            lstParents.Items.Clear();

            foreach (Parent parent in data.parents)
            {
                lstParents.Items.Add(parent.FirstName + " " + parent.LastName);
            }
        }

        private void tabStaff_Enter(object sender, EventArgs e)
        {
            lstStaff.Items.Clear();

            foreach (Employee employee in data.employees)
            {
                lstParents.Items.Add(employee.FirstName + " " + employee.LastName);
            }
        }
    }
}
