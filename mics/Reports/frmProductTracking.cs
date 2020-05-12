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
    public partial class frmProductTracking : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
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


        public frmProductTracking()
        {
            InitializeComponent();
        }

        private void frmProductTracking_Load(object sender, EventArgs e)
        {
            this.productTrackingReportTableAdapter.Fill(this.PurchasedProducts.ProductTrackingReport, fromDate, ToDate);
            ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate.ToShortDateString());
            ReportParameter paramToDate = new ReportParameter("ToDate", toDate.ToShortDateString());
            ReportParameter[] param = new ReportParameter[2] { paramFromdate, paramToDate };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
            /*this.monthlyPurchasedTableAdapter.Fill(this.purchasedProducts.MonthlyPurchased,fromDate,toDate);
            this.chartProductPurchasedTableAdapter.Fill(this.purchasedProducts.ChartProductPurchased,fromDate,toDate);
            ReportParameter paramFromdate= new ReportParameter("FromDate",fromDate.ToShortDateString());
            ReportParameter paramToDate = new ReportParameter("ToDate",ToDate.ToShortDateString());
            ReportParameter [] param = new ReportParameter[2]{paramFromdate,paramToDate};
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();*/

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}