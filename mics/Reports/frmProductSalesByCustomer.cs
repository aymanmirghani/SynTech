using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace MICS.Reports
{
    public partial class frmProductSalesByCustomer : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int productID = 0;
        private string pName = String.Empty;

        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }


        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public frmProductSalesByCustomer()
        {
            InitializeComponent();
        }

        private void frmProductSalesByCustomer_Load(object sender, EventArgs e)
        {
            this.ProductSalesByCustomerTableAdapter.Fill(this.PurchasedProducts.ProductSalesByCustomer, fromDate, toDate, productID);
            ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate.ToShortDateString());
            ReportParameter paramToDate = new ReportParameter("ToDate", toDate.ToShortDateString());
            ReportParameter paramProductId = new ReportParameter("ProductID", productID.ToString());
            ReportParameter paramPName = new ReportParameter("ProductName", pName.ToString());
            ReportParameter[] param = new ReportParameter[4] { paramFromdate, paramToDate,paramProductId,paramPName };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
            /*  this.productTrackingReportTableAdapter.Fill(this.PurchasedProducts.ProductTrackingReport, fromDate, ToDate);
             ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate.ToShortDateString());
             ReportParameter paramToDate = new ReportParameter("ToDate", toDate.ToShortDateString());
             ReportParameter[] param = new ReportParameter[2] { paramFromdate, paramToDate };
             this.reportViewer1.LocalReport.SetParameters(param);
             this.reportViewer1.RefreshReport();*/
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}