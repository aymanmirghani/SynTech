namespace MICS
{
    partial class frmPurchaseInvoiceReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PurchaseInvoiceDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseInvoiceDetailCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseInvoiceHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseOrderHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceDetailCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderHeaderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MICS_BLL_PurchaseInvoiceHeader";
            reportDataSource1.Value = this.PurchaseInvoiceHeaderBindingSource;
            reportDataSource2.Name = "MICS_BLL_PurchaseOrderDetail";
            reportDataSource2.Value = this.PurchaseOrderDetailBindingSource;
            reportDataSource3.Name = "MICS_BLL_PurchaseInvoiceDetail";
            reportDataSource3.Value = this.PurchaseInvoiceDetailBindingSource;
            reportDataSource4.Name = "MICS_BLL_PurchaseInvoiceDetailCollection";
            reportDataSource4.Value = this.PurchaseInvoiceDetailCollectionBindingSource;
            reportDataSource5.Name = "MICS_BLL_PurchaseOrderHeader";
            reportDataSource5.Value = this.PurchaseOrderHeaderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.PurchaseInvoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(643, 510);
            this.reportViewer1.TabIndex = 0;
            // 
            // PurchaseInvoiceDetailBindingSource
            // 
            this.PurchaseInvoiceDetailBindingSource.DataSource = typeof(MICS.BLL.PurchaseInvoiceDetail);
            // 
            // PurchaseInvoiceDetailCollectionBindingSource
            // 
            this.PurchaseInvoiceDetailCollectionBindingSource.DataSource = typeof(MICS.BLL.PurchaseInvoiceDetailCollection);
            // 
            // PurchaseInvoiceHeaderBindingSource
            // 
            this.PurchaseInvoiceHeaderBindingSource.DataSource = typeof(MICS.BLL.PurchaseInvoiceHeader);
            // 
            // PurchaseOrderDetailBindingSource
            // 
            this.PurchaseOrderDetailBindingSource.DataSource = typeof(MICS.BLL.PurchaseOrderDetail);
            // 
            // PurchaseOrderHeaderBindingSource
            // 
            this.PurchaseOrderHeaderBindingSource.DataSource = typeof(MICS.BLL.PurchaseOrderHeader);
            // 
            // frmPurchaseInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 510);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPurchaseInvoiceReport";
            this.Text = "frmPurchaseInvoice";
            this.Load += new System.EventHandler(this.frmPurchaseInvoiceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceDetailCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseInvoiceHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderHeaderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PurchaseInvoiceDetailBindingSource;
        private System.Windows.Forms.BindingSource PurchaseInvoiceDetailCollectionBindingSource;
        private System.Windows.Forms.BindingSource PurchaseInvoiceHeaderBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderDetailBindingSource;
        private System.Windows.Forms.BindingSource PurchaseOrderHeaderBindingSource;

    }
}