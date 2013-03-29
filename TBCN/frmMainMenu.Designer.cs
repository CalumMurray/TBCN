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
            this.btnCheckPVGDate = new System.Windows.Forms.Button();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.tabChildren = new System.Windows.Forms.TabPage();
            this.btnCheckAges = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnChildren = new System.Windows.Forms.Button();
            this.txtChildren = new System.Windows.Forms.TextBox();
            this.lstChildren = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
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
            this.tabParents.Size = new System.Drawing.Size(450, 230);
            this.tabParents.TabIndex = 2;
            this.tabParents.Text = "Parents/Contacts";
            this.tabParents.UseVisualStyleBackColor = true;
            this.tabParents.Enter += new System.EventHandler(this.tabParents_Enter);
            // 
            // btnAddParent
            // 
            this.btnAddParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddParent.Location = new System.Drawing.Point(370, 197);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(74, 23);
            this.btnAddParent.TabIndex = 8;
            this.btnAddParent.Text = "Add Parent";
            this.btnAddParent.UseVisualStyleBackColor = true;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // btnParents
            // 
            this.btnParents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParents.Location = new System.Drawing.Point(370, 8);
            this.btnParents.Name = "btnParents";
            this.btnParents.Size = new System.Drawing.Size(74, 20);
            this.btnParents.TabIndex = 7;
            this.btnParents.Text = "Search";
            this.btnParents.UseVisualStyleBackColor = true;
            this.btnParents.Click += new System.EventHandler(this.btnParents_Click);
            // 
            // txtParents
            // 
            this.txtParents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParents.ForeColor = System.Drawing.Color.Gray;
            this.txtParents.Location = new System.Drawing.Point(5, 8);
            this.txtParents.Name = "txtParents";
            this.txtParents.Size = new System.Drawing.Size(359, 20);
            this.txtParents.TabIndex = 6;
            this.txtParents.Text = "Enter parent name to search for...";
            // 
            // lstParents
            // 
            this.lstParents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParents.FormattingEnabled = true;
            this.lstParents.Location = new System.Drawing.Point(5, 34);
            this.lstParents.Name = "lstParents";
            this.lstParents.Size = new System.Drawing.Size(359, 186);
            this.lstParents.TabIndex = 5;
            this.lstParents.DoubleClick += new System.EventHandler(this.lstParents_DoubleClick);
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.btnCheckPVGDate);
            this.tabStaff.Controls.Add(this.btnAddStaff);
            this.tabStaff.Controls.Add(this.btnStaff);
            this.tabStaff.Controls.Add(this.txtStaff);
            this.tabStaff.Controls.Add(this.lstStaff);
            this.tabStaff.Location = new System.Drawing.Point(4, 22);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tabStaff.Size = new System.Drawing.Size(450, 230);
            this.tabStaff.TabIndex = 1;
            this.tabStaff.Text = "Staff";
            this.tabStaff.UseVisualStyleBackColor = true;
            this.tabStaff.Enter += new System.EventHandler(this.tabStaff_Enter);
            // 
            // btnCheckPVGDate
            // 
            this.btnCheckPVGDate.Location = new System.Drawing.Point(369, 168);
            this.btnCheckPVGDate.Name = "btnCheckPVGDate";
            this.btnCheckPVGDate.Size = new System.Drawing.Size(75, 23);
            this.btnCheckPVGDate.TabIndex = 9;
            this.btnCheckPVGDate.Text = "Check PVG";
            this.btnCheckPVGDate.UseVisualStyleBackColor = true;
            this.btnCheckPVGDate.Click += new System.EventHandler(this.btnCheckPVGDate_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStaff.Location = new System.Drawing.Point(370, 197);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(74, 23);
            this.btnAddStaff.TabIndex = 8;
            this.btnAddStaff.Text = "Add Staff";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaff.Location = new System.Drawing.Point(370, 8);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(74, 20);
            this.btnStaff.TabIndex = 7;
            this.btnStaff.Text = "Search";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // txtStaff
            // 
            this.txtStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaff.ForeColor = System.Drawing.Color.Gray;
            this.txtStaff.Location = new System.Drawing.Point(5, 8);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(359, 20);
            this.txtStaff.TabIndex = 6;
            this.txtStaff.Text = "Enter employee name to search for...";
            // 
            // lstStaff
            // 
            this.lstStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.Location = new System.Drawing.Point(5, 34);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.Size = new System.Drawing.Size(359, 186);
            this.lstStaff.TabIndex = 5;
            this.lstStaff.DoubleClick += new System.EventHandler(this.lstStaff_DoubleClick);
            // 
            // tabChildren
            // 
            this.tabChildren.Controls.Add(this.btnCheckAges);
            this.tabChildren.Controls.Add(this.btnAddChild);
            this.tabChildren.Controls.Add(this.btnChildren);
            this.tabChildren.Controls.Add(this.txtChildren);
            this.tabChildren.Controls.Add(this.lstChildren);
            this.tabChildren.Location = new System.Drawing.Point(4, 22);
            this.tabChildren.Name = "tabChildren";
            this.tabChildren.Padding = new System.Windows.Forms.Padding(3);
            this.tabChildren.Size = new System.Drawing.Size(450, 230);
            this.tabChildren.TabIndex = 0;
            this.tabChildren.Text = "Children";
            this.tabChildren.UseVisualStyleBackColor = true;
            this.tabChildren.Enter += new System.EventHandler(this.tabChildren_Enter);
            // 
            // btnCheckAges
            // 
            this.btnCheckAges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAges.Location = new System.Drawing.Point(370, 166);
            this.btnCheckAges.Name = "btnCheckAges";
            this.btnCheckAges.Size = new System.Drawing.Size(74, 23);
            this.btnCheckAges.TabIndex = 4;
            this.btnCheckAges.Text = "Check Ages";
            this.btnCheckAges.UseVisualStyleBackColor = true;
            this.btnCheckAges.Click += new System.EventHandler(this.btnCheckAges_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChild.Location = new System.Drawing.Point(370, 195);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 3;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnChildren
            // 
            this.btnChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChildren.Location = new System.Drawing.Point(370, 6);
            this.btnChildren.Name = "btnChildren";
            this.btnChildren.Size = new System.Drawing.Size(74, 20);
            this.btnChildren.TabIndex = 2;
            this.btnChildren.Text = "Search";
            this.btnChildren.UseVisualStyleBackColor = true;
            this.btnChildren.Click += new System.EventHandler(this.btnChildren_Click);
            // 
            // txtChildren
            // 
            this.txtChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChildren.ForeColor = System.Drawing.Color.Gray;
            this.txtChildren.Location = new System.Drawing.Point(6, 6);
            this.txtChildren.Name = "txtChildren";
            this.txtChildren.Size = new System.Drawing.Size(358, 20);
            this.txtChildren.TabIndex = 1;
            this.txtChildren.Text = "Enter child name to search for...";
            this.txtChildren.TextChanged += new System.EventHandler(this.txtChildren_TextChanged);
            this.txtChildren.Enter += new System.EventHandler(this.txtChildren_Enter);
            // 
            // lstChildren
            // 
            this.lstChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChildren.FormattingEnabled = true;
            this.lstChildren.Location = new System.Drawing.Point(6, 32);
            this.lstChildren.Name = "lstChildren";
            this.lstChildren.Size = new System.Drawing.Size(358, 186);
            this.lstChildren.TabIndex = 0;
            this.lstChildren.DoubleClick += new System.EventHandler(this.lstChildren_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabChildren);
            this.tabControl1.Controls.Add(this.tabStaff);
            this.tabControl1.Controls.Add(this.tabParents);
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 256);
            this.tabControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teddy Bear Club Nursery";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(396, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 315);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(319, 251);
            this.Name = "frmMainMenu";
            this.Text = "Teddy Bear Club Nursery";
            this.tabParents.ResumeLayout(false);
            this.tabParents.PerformLayout();
            this.tabStaff.ResumeLayout(false);
            this.tabStaff.PerformLayout();
            this.tabChildren.ResumeLayout(false);
            this.tabChildren.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabParents;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.TabPage tabChildren;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox lstChildren;
        private System.Windows.Forms.Button btnChildren;
        private System.Windows.Forms.TextBox txtChildren;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckAges;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.Button btnParents;
        private System.Windows.Forms.TextBox txtParents;
        private System.Windows.Forms.ListBox lstParents;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.ListBox lstStaff;
        private System.Windows.Forms.Button btnCheckPVGDate;
        private System.Windows.Forms.Button btnRefresh;



    }
}