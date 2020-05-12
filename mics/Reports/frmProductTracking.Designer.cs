namespace MICS.Reports
{
    partial class frmProductTracking
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductTracking));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.productTrackingReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchasedProducts = new MICS.Reports.PurchasedProducts();
            this.productTrackingReportTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.ProductTrackingReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.productTrackingReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PurchasedProducts_ProductTracking";
            reportDataSource1.Value = this.productTrackingReportBindingSource;
            reportDataSource2.Name = "PurchasedProducts_ProductTrackingReport";
            reportDataSource2.Value = this.productTrackingReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.productTracking.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(292, 266);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // productTrackingReportBindingSource
            // 
            this.productTrackingReportBindingSource.DataMember = "ProductTrackingReport";
            this.productTrackingReportBindingSource.DataSource = this.PurchasedProducts;
            // 
            // PurchasedProducts
            // 
            this.PurchasedProducts.DataSetName = "PurchasedProducts";
            this.PurchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTrackingReportTableAdapter
            // 
            this.productTrackingReportTableAdapter.ClearBeforeFill = true;
            // 
            // frmProductTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductTracking";
            this.Text = "Product Tracking Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductTracking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productTrackingReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource productTrackingReportBindingSource;
        private PurchasedProducts PurchasedProducts;
        private MICS.Reports.PurchasedProductsTableAdapters.ProductTrackingReportTableAdapter productTrackingReportTableAdapter;
    }
}