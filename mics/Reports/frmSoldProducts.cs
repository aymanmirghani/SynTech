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
    public partial class frmSoldProducts : Form
    {
        private string fromDate = String.Empty;

        public string FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private string toDate = String.Empty;

        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public frmSoldProducts()
        {
            InitializeComponent();
        }

        private void frmSoldProducts_Load(object sender, EventArgs e)
        {
            this.productSoldTableAdapter.Fill(this.purchasedProducts.ProductSold,DateTime.Parse(fromDate),DateTime.Parse(toDate));
            this.chartProductSoldTableAdapter.Fill(this.purchasedProducts.ChartProductSold, DateTime.Parse(fromDate), DateTime.Parse(toDate));
            ReportParameter paramFromdate = new ReportParameter("FromDate", fromDate);
            ReportParameter paramToDate = new ReportParameter("ToDate", ToDate);
            ReportParameter[] param = new ReportParameter[2] { paramFromdate, paramToDate };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        
    }
}