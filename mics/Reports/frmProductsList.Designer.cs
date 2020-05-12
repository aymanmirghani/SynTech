namespace MICS.Reports
{
    partial class frmProductsList
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ddlCategory = new System.Windows.Forms.ComboBox();
            this.ddlSubCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.ProductListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchasedProducts = new MICS.Reports.PurchasedProducts();
            this.ProductListTableAdapter = new MICS.Reports.PurchasedProductsTableAdapters.ProductListTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProductListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PurchasedProducts_ProductList";
            reportDataSource1.Value = this.ProductListBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MICS.Reports.ProductList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1107, 574);
            this.reportViewer1.TabIndex = 0;
            // 
            // ddlCategory
            // 
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Location = new System.Drawing.Point(70, 12);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(208, 21);
            this.ddlCategory.TabIndex = 1;
            this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // ddlSubCategory
            // 
            this.ddlSubCategory.FormattingEnabled = true;
            this.ddlSubCategory.Location = new System.Drawing.Point(409, 15);
            this.ddlSubCategory.Name = "ddlSubCategory";
            this.ddlSubCategory.Size = new System.Drawing.Size(246, 21);
            this.ddlSubCategory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Category";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(678, 15);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // ProductListBindingSource
            // 
            this.ProductListBindingSource.DataMember = "ProductList";
            this.ProductListBindingSource.DataSource = this.PurchasedProducts;
            // 
            // PurchasedProducts
            // 
            this.PurchasedProducts.DataSetName = "PurchasedProducts";
            this.PurchasedProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProductListTableAdapter
            // 
            this.ProductListTableAdapter.ClearBeforeFill = true;
            // 
            // frmProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 657);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlSubCategory);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmProductsList";
            this.Text = "Product List";
            this.Load += new System.EventHandler(this.frmProductsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasedProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductListBindingSource;
        private PurchasedProducts PurchasedProducts;
        private MICS.Reports.PurchasedProductsTableAdapters.ProductListTableAdapter ProductListTableAdapter;
        private System.Windows.Forms.ComboBox ddlCategory;
        private System.Windows.Forms.ComboBox ddlSubCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
    }
}