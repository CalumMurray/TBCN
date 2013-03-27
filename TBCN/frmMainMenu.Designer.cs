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
            this.components = new System.ComponentModel.Container();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._12ac3d03DataSet = new TBCN._12ac3d03DataSet();
            this.childBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.childTableAdapter = new TBCN._12ac3d03DataSetTableAdapters.childTableAdapter();
            this.tableAdapterManager = new TBCN._12ac3d03DataSetTableAdapters.TableAdapterManager();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._12ac3d03DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(655, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parents/Contacts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Staff";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Children";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 409);
            this.tabControl1.TabIndex = 0;
            // 
            // _12ac3d03DataSet
            // 
            this._12ac3d03DataSet.DataSetName = "_12ac3d03DataSet";
            this._12ac3d03DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // childBindingSource
            // 
            this.childBindingSource.DataMember = "child";
            this.childBindingSource.DataSource = this._12ac3d03DataSet;
            // 
            // childTableAdapter
            // 
            this.childTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.addressTableAdapter = null;
            this.tableAdapterManager.attendanceTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.child_has_emergency_contactTableAdapter = null;
            this.tableAdapterManager.child_has_parent_guardianTableAdapter = null;
            this.tableAdapterManager.childTableAdapter = this.childTableAdapter;
            this.tableAdapterManager.departmentTableAdapter = null;
            this.tableAdapterManager.emergency_contactTableAdapter = null;
            this.tableAdapterManager.employeeTableAdapter = null;
            this.tableAdapterManager.invoiceTableAdapter = null;
            this.tableAdapterManager.medical_informationTableAdapter = null;
            this.tableAdapterManager.parent_guardianTableAdapter = null;
            this.tableAdapterManager.roomTableAdapter = null;
            this.tableAdapterManager.supplier_invoiceTableAdapter = null;
            this.tableAdapterManager.supplierTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TBCN._12ac3d03DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 434);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMainMenu";
            this.Text = "Teddy Bear Club Nursery";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._12ac3d03DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private _12ac3d03DataSet _12ac3d03DataSet;
        private System.Windows.Forms.BindingSource childBindingSource;
        private _12ac3d03DataSetTableAdapters.childTableAdapter childTableAdapter;
        private _12ac3d03DataSetTableAdapters.TableAdapterManager tableAdapterManager;



    }
}