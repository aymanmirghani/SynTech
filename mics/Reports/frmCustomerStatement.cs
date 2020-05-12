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
    public partial class frmCustomerStatement : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int customerId = 0;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
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

        public frmCustomerStatement()
        {
            InitializeComponent();
        }

        private void frmCustomerStatement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.CustomerStatemenet' table. You can move, or remove it, as needed.
            this.CustomerStatemenetTableAdapter.Fill(this.PurchasedProducts.CustomerStatemenet, CustomerId);
            //this.CustomerStatemenetTableAdapter.Fill(this.PurchasedProducts.CustomerStatemenet,fromDate,toDate,customerId);
            //ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate.ToShortDateString());
            //ReportParameter paramToDate = new ReportParameter("ToDate", toDate.ToShortDateString());
            //ReportParameter paramCustId = new ReportParameter("CustomerID", customerId.ToString());
            //ReportParameter[] param = new ReportParameter[3] { paramFromdate, paramToDate, paramCustId };
            //this.reportViewer1.LocalReport.SetParameters(param);
            SetReportParameter();
            this.reportViewer1.RefreshReport();
            /* this.productTrackingReportTableAdapter.Fill(this.PurchasedProducts.ProductTrackingReport, fromDate, ToDate);
            ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate.ToShortDateString());
            ReportParameter paramToDate = new ReportParameter("ToDate", toDate.ToShortDateString());
            ReportParameter[] param = new ReportParameter[2] { paramFromdate, paramToDate };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();*/
        }
        private void SetReportParameter()
        {
            ReportParameter[] p = new ReportParameter[7];
            string company = System.Configuration.ConfigurationManager.AppSettings["CompanyName"].ToString();
            string companyAddress = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress1"].ToString();
            string companyCityState = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress2"].ToString();
            string companyPhone = System.Configuration.ConfigurationManager.AppSettings["CompanyPhone"].ToString();

            p[0] = new ReportParameter("CompanyName", company);
            p[1] = new ReportParameter("CompanyAddress", companyAddress);
            p[2] = new ReportParameter("CompanyCityState", companyCityState);
            p[3] = new ReportParameter("CompanyPhone", companyPhone);
            p[4] = new ReportParameter("FromDate", fromDate.ToShortDateString());
            p[5] = new ReportParameter("ToDate", toDate.ToShortDateString());
            p[6] = new ReportParameter("CustomerID", customerId.ToString());
            this.reportViewer1.LocalReport.SetParameters(p);
        }
    }
}