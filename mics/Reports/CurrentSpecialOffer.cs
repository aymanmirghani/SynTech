using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace MICS.Reports
{
    public partial class CurrentSpecialOffer : Form
    {
        public CurrentSpecialOffer()
        {
            InitializeComponent();
        }

        private void CurrentSpecialOffer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.SpecialOffer' table. You can move, or remove it, as needed.
            this.SpecialOfferTableAdapter.FillByCurrentSpecialOffer(this.PurchasedProducts.SpecialOffer);
            SetReportParameter();
            this.reportViewer1.RefreshReport();
        }
        private void SetReportParameter()
        {
            ReportParameter[] p = new ReportParameter[4];
            string company = System.Configuration.ConfigurationManager.AppSettings["CompanyName"].ToString();
            string companyAddress = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress1"].ToString();
            string companyCityState = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress2"].ToString();
            string companyPhone = System.Configuration.ConfigurationManager.AppSettings["CompanyPhone"].ToString();

            p[0] = new ReportParameter("CompanyName", company);
            p[1] = new ReportParameter("CompanyAddress", companyAddress);
            p[2] = new ReportParameter("CompanyCityState", companyCityState);
            p[3] = new ReportParameter("CompanyPhone", companyPhone);
            this.reportViewer1.LocalReport.SetParameters(p);
        }
    }
}