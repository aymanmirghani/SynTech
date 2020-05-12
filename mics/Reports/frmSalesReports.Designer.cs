namespace MICS.Reports
{
    partial class frmSalesReports
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
            this.YTDSalesByTerritoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchasedProducts = new MICS.Reports.PurchasedProducts();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.rdCurYear = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.rdCurMonth = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomerVendor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMeasures = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.YTDSalesByTerritoryTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.YTDSalesByTerritoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.YTDSalesByTerritoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // YTDSalesByTerritoryBindingSource
            // 
            this.YTDSalesByTerritoryBindingSource.DataMember = "YTDSalesByTerritory";
            this.YTDSalesByTerritoryBindingSource.DataSource = this.PurchasedProducts;
            // 
            // PurchasedProducts
            // 
            this.PurchasedProducts.DataSetName = "PurchasedProducts";
            this.PurchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(93, 41);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(186, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(379, 44);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(212, 21);
            this.cmbSubCategory.TabIndex = 1;
            this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
            // 
            // cmbProductName
            // 
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(662, 41);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(237, 21);
            this.cmbProductName.TabIndex = 2;
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(93, 68);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(186, 21);
            this.cmbTerritory.TabIndex = 3;
            this.cmbTerritory.SelectedIndexChanged += new System.EventHandler(this.cmbTerritory_SelectedIndexChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(379, 68);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(212, 21);
            this.cmbCustomer.TabIndex = 4;
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Location = new System.Drawing.Point(662, 68);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(237, 21);
            this.cmbGroupBy.TabIndex = 5;
            // 
            // rdCurYear
            // 
            this.rdCurYear.AutoSize = true;
            this.rdCurYear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCurYear.Location = new System.Drawing.Point(17, 21);
            this.rdCurYear.Name = "rdCurYear";
            this.rdCurYear.Size = new System.Drawing.Size(99, 18);
            this.rdCurYear.TabIndex = 6;
            this.rdCurYear.Text = "Year To Date";
            this.rdCurYear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.Controls.Add(this.rdCurMonth);
            this.groupBox1.Controls.Add(this.rdCurYear);
            this.groupBox1.Location = new System.Drawing.Point(37, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Period";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(358, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(100, 21);
            this.cmbYear.TabIndex = 10;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(252, 19);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(100, 21);
            this.cmbMonth.TabIndex = 9;
            // 
            // rdCurMonth
            // 
            this.rdCurMonth.AutoSize = true;
            this.rdCurMonth.Checked = true;
            this.rdCurMonth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCurMonth.Location = new System.Drawing.Point(137, 21);
            this.rdCurMonth.Name = "rdCurMonth";
            this.rdCurMonth.Size = new System.Drawing.Size(109, 18);
            this.rdCurMonth.TabIndex = 7;
            this.rdCurMonth.TabStop = true;
            this.rdCurMonth.Text = "Month To Date";
            this.rdCurMonth.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sub Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Territory";
            // 
            // lblCustomerVendor
            // 
            this.lblCustomerVendor.AutoSize = true;
            this.lblCustomerVendor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerVendor.Location = new System.Drawing.Point(314, 76);
            this.lblCustomerVendor.Name = "lblCustomerVendor";
            this.lblCustomerVendor.Size = new System.Drawing.Size(59, 14);
            this.lblCustomerVendor.TabIndex = 12;
            this.lblCustomerVendor.Text = "Customer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(605, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Group By";
            // 
            // cmbMeasures
            // 
            this.cmbMeasures.FormattingEnabled = true;
            this.cmbMeasures.Location = new System.Drawing.Point(93, 14);
            this.cmbMeasures.Name = "cmbMeasures";
            this.cmbMeasures.Size = new System.Drawing.Size(186, 21);
            this.cmbMeasures.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Measures";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(793, 112);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(106, 23);
            this.btnViewReport.TabIndex = 17;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // rptView
            // 
            reportDataSource1.Name = "PurchasedProducts_YTDSalesByTerritory";
            reportDataSource1.Value = this.YTDSalesByTerritoryBindingSource;
            this.rptView.LocalReport.DataSources.Add(reportDataSource1);
            this.rptView.LocalReport.ReportEmbeddedResource = "MICS.Reports.SalesByTerritory.rdlc";
            this.rptView.Location = new System.Drawing.Point(33, 155);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(972, 498);
            this.rptView.TabIndex = 18;
            this.rptView.Drillthrough += new Microsoft.Reporting.WinForms.DrillthroughEventHandler(this.rptView_Drillthrough);
            // 
            // YTDSalesByTerritoryTableAdapter
            // 
            this.YTDSalesByTerritoryTableAdapter.ClearBeforeFill = true;
            // 
            // frmSalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 708);
            this.Controls.Add(this.rptView);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbMeasures);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCustomerVendor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbGroupBy);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.cmbProductName);
            this.Controls.Add(this.cmbSubCategory);
            this.Controls.Add(this.cmbCategory);
            this.Name = "frmSalesReports";
            this.Text = "Sales Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YTDSalesByTerritoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.RadioButton rdCurYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdCurMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustomerVendor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMeasures;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnViewReport;
        private PurchasedProducts PurchasedProducts;
        private Microsoft.Reporting.WinForms.ReportViewer rptView;
        private System.Windows.Forms.BindingSource YTDSalesByTerritoryBindingSource;
        private MICS.Reports.PurchasedProductsTableAdapters.YTDSalesByTerritoryTableAdapter YTDSalesByTerritoryTableAdapter;
    }
}