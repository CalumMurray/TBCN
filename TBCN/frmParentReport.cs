﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TBCN
{
    public partial class frmParentReport : Form
    {
        public frmParentReport(String title, Parent parent)
        {
            InitializeComponent();
            this.Text = title;
        }

        public frmParentReport(String title, EmergencyContact ec)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void frmParentReport_Load(object sender, EventArgs e)
        {

        }



    }
}
