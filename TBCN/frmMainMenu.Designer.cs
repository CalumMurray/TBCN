namespace TBCN
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabParents = new System.Windows.Forms.TabPage();
            this.btnAddParent = new System.Windows.Forms.Button();
            this.btnParents = new System.Windows.Forms.Button();
            this.txtParents = new System.Windows.Forms.TextBox();
            this.lstParents = new System.Windows.Forms.ListBox();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.tabChildren = new System.Windows.Forms.TabPage();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnChildren = new System.Windows.Forms.Button();
            this.txtChildren = new System.Windows.Forms.TextBox();
            this.lstChildren = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabParents.SuspendLayout();
            this.tabStaff.SuspendLayout();
            this.tabChildren.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabParents
            // 
            this.tabParents.Controls.Add(this.btnAddParent);
            this.tabParents.Controls.Add(this.btnParents);
            this.tabParents.Controls.Add(this.txtParents);
            this.tabParents.Controls.Add(this.lstParents);
            this.tabParents.Location = new System.Drawing.Point(4, 22);
            this.tabParents.Name = "tabParents";
            this.tabParents.Padding = new System.Windows.Forms.Padding(3);
            this.tabParents.Size = new System.Drawing.Size(655, 383);
            this.tabParents.TabIndex = 2;
            this.tabParents.Text = "Parents/Contacts";
            this.tabParents.UseVisualStyleBackColor = true;
            // 
            // btnAddParent
            // 
            this.btnAddParent.Location = new System.Drawing.Point(368, 289);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(112, 23);
            this.btnAddParent.TabIndex = 6;
            this.btnAddParent.Text = "Add Parent/Contact";
            this.btnAddParent.UseVisualStyleBackColor = true;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // btnParents
            // 
            this.btnParents.Location = new System.Drawing.Point(388, 263);
            this.btnParents.Name = "btnParents";
            this.btnParents.Size = new System.Drawing.Size(74, 20);
            this.btnParents.TabIndex = 5;
            this.btnParents.Text = "Search";
            this.btnParents.UseVisualStyleBackColor = true;
            this.btnParents.Click += new System.EventHandler(this.btnParents_Click);
            // 
            // txtParents
            // 
            this.txtParents.ForeColor = System.Drawing.Color.Gray;
            this.txtParents.Location = new System.Drawing.Point(6, 263);
            this.txtParents.Name = "txtParents";
            this.txtParents.Size = new System.Drawing.Size(376, 20);
            this.txtParents.TabIndex = 4;
            this.txtParents.Text = "Enter parent name to search for...";
            // 
            // lstParents
            // 
            this.lstParents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParents.FormattingEnabled = true;
            this.lstParents.Location = new System.Drawing.Point(6, 6);
            this.lstParents.Name = "lstParents";
            this.lstParents.Size = new System.Drawing.Size(457, 251);
            this.lstParents.TabIndex = 3;
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.btnAddEmployee);
            this.tabStaff.Controls.Add(this.btnStaff);
            this.tabStaff.Controls.Add(this.txtStaff);
            this.tabStaff.Controls.Add(this.lstStaff);
            this.tabStaff.Location = new System.Drawing.Point(4, 22);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tabStaff.Size = new System.Drawing.Size(655, 383);
            this.tabStaff.TabIndex = 1;
            this.tabStaff.Text = "Staff";
            this.tabStaff.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(376, 289);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(98, 23);
            this.btnAddEmployee.TabIndex = 6;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(388, 263);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(74, 20);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "Search";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // txtStaff
            // 
            this.txtStaff.ForeColor = System.Drawing.Color.Gray;
            this.txtStaff.Location = new System.Drawing.Point(6, 263);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(376, 20);
            this.txtStaff.TabIndex = 4;
            this.txtStaff.Text = "Enter staff member name to search for...";
            // 
            // lstStaff
            // 
            this.lstStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.Location = new System.Drawing.Point(6, 6);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.Size = new System.Drawing.Size(457, 251);
            this.lstStaff.TabIndex = 3;
            // 
            // tabChildren
            // 
            this.tabChildren.Controls.Add(this.btnAddChild);
            this.tabChildren.Controls.Add(this.btnChildren);
            this.tabChildren.Controls.Add(this.txtChildren);
            this.tabChildren.Controls.Add(this.lstChildren);
            this.tabChildren.Location = new System.Drawing.Point(4, 22);
            this.tabChildren.Name = "tabChildren";
            this.tabChildren.Padding = new System.Windows.Forms.Padding(3);
            this.tabChildren.Size = new System.Drawing.Size(655, 383);
            this.tabChildren.TabIndex = 0;
            this.tabChildren.Text = "Children";
            this.tabChildren.UseVisualStyleBackColor = true;
            this.tabChildren.Click += new System.EventHandler(this.tabChildren_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(388, 289);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 3;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnChildren
            // 
            this.btnChildren.Location = new System.Drawing.Point(388, 263);
            this.btnChildren.Name = "btnChildren";
            this.btnChildren.Size = new System.Drawing.Size(74, 20);
            this.btnChildren.TabIndex = 2;
            this.btnChildren.Text = "Search";
            this.btnChildren.UseVisualStyleBackColor = true;
            this.btnChildren.Click += new System.EventHandler(this.btnChildren_Click);
            // 
            // txtChildren
            // 
            this.txtChildren.ForeColor = System.Drawing.Color.Gray;
            this.txtChildren.Location = new System.Drawing.Point(6, 263);
            this.txtChildren.Name = "txtChildren";
            this.txtChildren.Size = new System.Drawing.Size(376, 20);
            this.txtChildren.TabIndex = 1;
            this.txtChildren.Text = "Enter child name to search for...";
            // 
            // lstChildren
            // 
            this.lstChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChildren.FormattingEnabled = true;
            this.lstChildren.Location = new System.Drawing.Point(6, 6);
            this.lstChildren.Name = "lstChildren";
            this.lstChildren.Size = new System.Drawing.Size(457, 251);
            this.lstChildren.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabChildren);
            this.tabControl1.Controls.Add(this.tabStaff);
            this.tabControl1.Controls.Add(this.tabParents);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 409);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectIndexChanged);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 434);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMainMenu";
            this.Text = "Teddy Bear Club Nursery";
            this.Load += new System.EventHandler(this.frmMainMenu_Load_1);
            this.tabParents.ResumeLayout(false);
            this.tabParents.PerformLayout();
            this.tabStaff.ResumeLayout(false);
            this.tabStaff.PerformLayout();
            this.tabChildren.ResumeLayout(false);
            this.tabChildren.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabParents;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.TabPage tabChildren;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox lstChildren;
        private System.Windows.Forms.Button btnChildren;
        private System.Windows.Forms.TextBox txtChildren;
        private System.Windows.Forms.Button btnParents;
        private System.Windows.Forms.TextBox txtParents;
        private System.Windows.Forms.ListBox lstParents;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.ListBox lstStaff;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnAddChild;



    }
}