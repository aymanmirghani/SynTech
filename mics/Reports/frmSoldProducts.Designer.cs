namespace MICS.Reports
{
    partial class frmSoldProducts
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
            this.productSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchasedProducts = new MICS.Reports.PurchasedProducts();
            this.chartProductSoldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.productSoldTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.ProductSoldTableAdapter();
            this.chartProductSoldTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.ChartProductSoldTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.productSoldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductSoldBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productSoldBindingSource
            // 
            this.productSoldBindingSource.DataMember = "ProductSold";
            this.productSoldBindingSource.DataSource = this.purchasedProducts;
            // 
            // purchasedProducts
            // 
            this.purchasedProducts.DataSetName = "PurchasedProducts";
            this.purchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartProductSoldBindingSource
            // 
            this.chartProductSoldBindingSource.DataMember = "ChartProductSold";
            this.chartProductSoldBindingSource.DataSource = this.purchasedProducts;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PurchasedProducts_ProductSold";
            reportDataSource1.Value = this.productSoldBindingSource;
            reportDataSource2.Name = "PurchasedProducts_ChartProductSold";
            reportDataSource2.Value = this.chartProductSoldBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.productSold.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(292, 266);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // productSoldTableAdapter
            // 
            this.productSoldTableAdapter.ClearBeforeFill = true;
            // 
            // chartProductSoldTableAdapter
            // 
            this.chartProductSoldTableAdapter.ClearBeforeFill = true;
            // 
            // frmSoldProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmSoldProducts";
            this.Text = "frmSoldProducts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSoldProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productSoldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductSoldBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource productSoldBindingSource;
        private PurchasedProducts purchasedProducts;
        private MICS.Reports.PurchasedProductsTableAdapters.ProductSoldTableAdapter productSoldTableAdapter;
        private System.Windows.Forms.BindingSource chartProductSoldBindingSource;
        private MICS.Reports.PurchasedProductsTableAdapters.ChartProductSoldTableAdapter chartProductSoldTableAdapter;
    }
}