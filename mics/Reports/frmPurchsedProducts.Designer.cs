namespace MICS.Reports
{
    partial class frmPurchsedProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchsedProducts));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.monthlyPurchasedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchasedProducts = new MICS.Reports.PurchasedProducts();
            this.chartProductPurchasedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthlyPurchasedTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.MonthlyPurchasedTableAdapter();
            this.chartProductPurchasedTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.ChartProductPurchasedTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyPurchasedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductPurchasedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PurchasedProducts_MonthlyPurchased";
            reportDataSource1.Value = this.monthlyPurchasedBindingSource;
            reportDataSource2.Name = "PurchasedProducts_ChartProductPurchased";
            reportDataSource2.Value = this.chartProductPurchasedBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.MonthlyPP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(292, 266);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // monthlyPurchasedBindingSource
            // 
            this.monthlyPurchasedBindingSource.DataMember = "MonthlyPurchased";
            this.monthlyPurchasedBindingSource.DataSource = this.purchasedProducts;
            // 
            // purchasedProducts
            // 
            this.purchasedProducts.DataSetName = "PurchasedProducts";
            this.purchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartProductPurchasedBindingSource
            // 
            this.chartProductPurchasedBindingSource.DataMember = "ChartProductPurchased";
            this.chartProductPurchasedBindingSource.DataSource = this.purchasedProducts;
            // 
            // monthlyPurchasedTableAdapter
            // 
            this.monthlyPurchasedTableAdapter.ClearBeforeFill = true;
            // 
            // chartProductPurchasedTableAdapter
            // 
            this.chartProductPurchasedTableAdapter.ClearBeforeFill = true;
            // 
            // frmPurchsedProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchsedProducts";
            this.Text = "Purchsed Products Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchsedProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyPurchasedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductPurchasedBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PurchasedProducts purchasedProducts;
        private System.Windows.Forms.BindingSource monthlyPurchasedBindingSource;
        private MICS.Reports.PurchasedProductsTableAdapters.MonthlyPurchasedTableAdapter monthlyPurchasedTableAdapter;
        private System.Windows.Forms.BindingSource chartProductPurchasedBindingSource;
        private MICS.Reports.PurchasedProductsTableAdapters.ChartProductPurchasedTableAdapter chartProductPurchasedTableAdapter;

    }
}