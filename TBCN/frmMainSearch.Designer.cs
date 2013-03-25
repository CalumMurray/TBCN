namespace TBCN
{
    partial class frmMainSearch
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
            this.btnChildSearch = new System.Windows.Forms.Button();
            this.txtSearchChild = new System.Windows.Forms.TextBox();
            this.btnSearchParentEC = new System.Windows.Forms.Button();
            this.txtSearchParent = new System.Windows.Forms.TextBox();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChildSearch
            // 
            this.btnChildSearch.Location = new System.Drawing.Point(241, 21);
            this.btnChildSearch.Name = "btnChildSearch";
            this.btnChildSearch.Size = new System.Drawing.Size(198, 23);
            this.btnChildSearch.TabIndex = 0;
            this.btnChildSearch.Text = "Search Children";
            this.btnChildSearch.UseVisualStyleBackColor = true;
            this.btnChildSearch.Click += new System.EventHandler(this.btnChildSearch_Click);
            // 
            // txtSearchChild
            // 
            this.txtSearchChild.Location = new System.Drawing.Point(13, 24);
            this.txtSearchChild.Name = "txtSearchChild";
            this.txtSearchChild.Size = new System.Drawing.Size(222, 20);
            this.txtSearchChild.TabIndex = 1;
            // 
            // btnSearchParentEC
            // 
            this.btnSearchParentEC.Location = new System.Drawing.Point(241, 50);
            this.btnSearchParentEC.Name = "btnSearchParentEC";
            this.btnSearchParentEC.Size = new System.Drawing.Size(198, 23);
            this.btnSearchParentEC.TabIndex = 0;
            this.btnSearchParentEC.Text = "Search Parents/Emergency Contacts";
            this.btnSearchParentEC.UseVisualStyleBackColor = true;
            // 
            // txtSearchParent
            // 
            this.txtSearchParent.Location = new System.Drawing.Point(13, 53);
            this.txtSearchParent.Name = "txtSearchParent";
            this.txtSearchParent.Size = new System.Drawing.Size(222, 20);
            this.txtSearchParent.TabIndex = 1;
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Location = new System.Drawing.Point(241, 79);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(198, 23);
            this.btnSearchEmployee.TabIndex = 0;
            this.btnSearchEmployee.Text = "Search Employees";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(13, 82);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(222, 20);
            this.txtSearchEmployee.TabIndex = 1;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(200, 142);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 2;
            this.btnAddChild.Text = "Add a child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // frmMainSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 192);
            this.Controls.Add(this.btnAddChild);
            this.Controls.Add(this.txtSearchEmployee);
            this.Controls.Add(this.txtSearchParent);
            this.Controls.Add(this.txtSearchChild);
            this.Controls.Add(this.btnSearchEmployee);
            this.Controls.Add(this.btnSearchParentEC);
            this.Controls.Add(this.btnChildSearch);
            this.Name = "frmMainSearch";
            this.Text = "Teddy Bear Club Nursery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChildSearch;
        private System.Windows.Forms.TextBox txtSearchChild;
        private System.Windows.Forms.Button btnSearchParentEC;
        private System.Windows.Forms.TextBox txtSearchParent;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.Button btnAddChild;
    }
}