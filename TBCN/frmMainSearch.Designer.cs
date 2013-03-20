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
            this.txtChildSearch = new System.Windows.Forms.TextBox();
            this.btnParentSearch = new System.Windows.Forms.Button();
            this.txtParentSearch = new System.Windows.Forms.TextBox();
            this.btnSearchEmpolyee = new System.Windows.Forms.Button();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChildSearch
            // 
            this.btnChildSearch.Location = new System.Drawing.Point(241, 21);
            this.btnChildSearch.Name = "btnChildSearch";
            this.btnChildSearch.Size = new System.Drawing.Size(106, 23);
            this.btnChildSearch.TabIndex = 0;
            this.btnChildSearch.Text = "Search Children";
            this.btnChildSearch.UseVisualStyleBackColor = true;
            // 
            // txtChildSearch
            // 
            this.txtChildSearch.Location = new System.Drawing.Point(13, 24);
            this.txtChildSearch.Name = "txtChildSearch";
            this.txtChildSearch.Size = new System.Drawing.Size(222, 20);
            this.txtChildSearch.TabIndex = 1;
            // 
            // btnParentSearch
            // 
            this.btnParentSearch.Location = new System.Drawing.Point(241, 50);
            this.btnParentSearch.Name = "btnParentSearch";
            this.btnParentSearch.Size = new System.Drawing.Size(106, 23);
            this.btnParentSearch.TabIndex = 0;
            this.btnParentSearch.Text = "Search Parents";
            this.btnParentSearch.UseVisualStyleBackColor = true;
            // 
            // txtParentSearch
            // 
            this.txtParentSearch.Location = new System.Drawing.Point(13, 53);
            this.txtParentSearch.Name = "txtParentSearch";
            this.txtParentSearch.Size = new System.Drawing.Size(222, 20);
            this.txtParentSearch.TabIndex = 1;
            // 
            // btnSearchEmpolyee
            // 
            this.btnSearchEmpolyee.Location = new System.Drawing.Point(241, 79);
            this.btnSearchEmpolyee.Name = "btnSearchEmpolyee";
            this.btnSearchEmpolyee.Size = new System.Drawing.Size(106, 23);
            this.btnSearchEmpolyee.TabIndex = 0;
            this.btnSearchEmpolyee.Text = "Search Employees";
            this.btnSearchEmpolyee.UseVisualStyleBackColor = true;
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(13, 82);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(222, 20);
            this.txtSearchEmployee.TabIndex = 1;
            // 
            // frmMainSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 192);
            this.Controls.Add(this.txtSearchEmployee);
            this.Controls.Add(this.txtParentSearch);
            this.Controls.Add(this.txtChildSearch);
            this.Controls.Add(this.btnSearchEmpolyee);
            this.Controls.Add(this.btnParentSearch);
            this.Controls.Add(this.btnChildSearch);
            this.Name = "frmMainSearch";
            this.Text = "frmMainSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChildSearch;
        private System.Windows.Forms.TextBox txtChildSearch;
        private System.Windows.Forms.Button btnParentSearch;
        private System.Windows.Forms.TextBox txtParentSearch;
        private System.Windows.Forms.Button btnSearchEmpolyee;
        private System.Windows.Forms.TextBox txtSearchEmployee;
    }
}