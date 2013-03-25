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
    public partial class frmMainSearch : Form
    {
        private Database dbConnection;

        public frmMainSearch()
        {
            InitializeComponent();
            dbConnection = new Database();
        }

        private void btnChildSearch_Click(object sender, EventArgs e)
        {

        }



        private void btnAddChild_Click(object sender, EventArgs e)
        {
            frmEditChild addChildForm = new frmEditChild();
            addChildForm.ShowDialog();
        }




    }
}
