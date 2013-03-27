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

        private void childBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.childBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._12ac3d03DataSet);

        }

        private void frmMainSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_12ac3d03DataSet.child' table. You can move, or remove it, as needed.
            this.childTableAdapter.Fill(this._12ac3d03DataSet.child);

        }





    }
}
