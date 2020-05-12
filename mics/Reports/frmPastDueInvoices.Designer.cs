namespace MICS.Reports
{
    partial class frmPastDueInvoices
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PurchasedProducts = new MICS.Reports.PurchasedProducts();
            this.OverDueInvoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OverDueInvoicesTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.OverDueInvoicesTableAdapter();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverDueInvoicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "PurchasedProducts_OverDueInvoices";
            reportDataSource2.Value = this.OverDueInvoicesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.OverDueInvoices.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 49);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(977, 615);
            this.reportViewer1.TabIndex = 0;
            // 
            // PurchasedProducts
            // 
            this.PurchasedProducts.DataSetName = "PurchasedProducts";
            this.PurchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OverDueInvoicesBindingSource
            // 
            this.OverDueInvoicesBindingSource.DataMember = "OverDueInvoices";
            this.OverDueInvoicesBindingSource.DataSource = this.PurchasedProducts;
            // 
            // OverDueInvoicesTableAdapter
            // 
            this.OverDueInvoicesTableAdapter.ClearBeforeFill = true;
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(28, 20);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(183, 21);
            this.cmbTerritory.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Filter";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Territories";
            // 
            // frmPastDueInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 716);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPastDueInvoices";
            this.Text = "frmPastDueInvoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPastDueInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverDueInvoicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OverDueInvoicesBindingSource;
        private PurchasedProducts PurchasedProducts;
        private MICS.Reports.PurchasedProductsTableAdapters.OverDueInvoicesTableAdapter OverDueInvoicesTableAdapter;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}