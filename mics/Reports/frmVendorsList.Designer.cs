namespace MICS.Reports
{
    partial class frmVendorsList
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.VendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchasedProducts = new MICS.Reports.PurchasedProducts();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VendorTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.VendorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.VendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // VendorBindingSource
            // 
            this.VendorBindingSource.DataMember = "Vendor";
            this.VendorBindingSource.DataSource = this.PurchasedProducts;
            // 
            // PurchasedProducts
            // 
            this.PurchasedProducts.DataSetName = "PurchasedProducts";
            this.PurchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PurchasedProducts_Vendor";
            reportDataSource1.Value = this.VendorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.VendorList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 11);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(668, 490);
            this.reportViewer1.TabIndex = 0;
            // 
            // VendorTableAdapter
            // 
            this.VendorTableAdapter.ClearBeforeFill = true;
            // 
            // frmVendorsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 513);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmVendorsList";
            this.Text = "Vendor List";
            this.Load += new System.EventHandler(this.frmVendorsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VendorBindingSource;
        private PurchasedProducts PurchasedProducts;
        private MICS.Reports.PurchasedProductsTableAdapters.VendorTableAdapter VendorTableAdapter;
    }
}