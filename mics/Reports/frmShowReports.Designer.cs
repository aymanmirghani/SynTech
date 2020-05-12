namespace MICS.Reports
{
    partial class frmShowReports
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
            this.cmbReportName = new System.Windows.Forms.ComboBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnViewReport = new System.Windows.Forms.Button();
            this.purchasedProducts = new MICS.Reports.PurchasedProducts();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReportName
            // 
            this.cmbReportName.FormattingEnabled = true;
            this.cmbReportName.Location = new System.Drawing.Point(100, 12);
            this.cmbReportName.Name = "cmbReportName";
            this.cmbReportName.Size = new System.Drawing.Size(200, 21);
            this.cmbReportName.TabIndex = 0;
            // 
            // rptViewer
            // 
            this.rptViewer.Location = new System.Drawing.Point(12, 73);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Size = new System.Drawing.Size(687, 250);
            this.rptViewer.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.purchasedProducts;
            this.bindingSource1.Position = 0;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(546, 9);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(75, 23);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click_1);
            // 
            // purchasedProducts
            // 
            this.purchasedProducts.DataSetName = "PurchasedProducts";
            this.purchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmShowReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 421);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.rptViewer);
            this.Controls.Add(this.cmbReportName);
            this.Name = "frmShowReports";
            this.Text = "MICS Reports";
            this.Load += new System.EventHandler(this.frmShowReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportName;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnViewReport;
        private PurchasedProducts purchasedProducts;
    }
}