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
    public partial class frmEditParent : Form
    {
        private Database dbConnection;

        //private static Parent parent;
        public static Parent AddedParent { get; set;}

        

        public frmEditParent(String title)
        {
            InitializeComponent();
            this.Text = title;
            dbConnection = new Database();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddedParent = new Parent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
