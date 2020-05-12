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
    public partial class frmPurchsedProducts : Form
    {
        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public frmPurchsedProducts()
        {
            InitializeComponent();
        }

        private void frmPurchsedProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'purchasedProducts.MonthlyPurchased' table. You can move, or remove it, as needed.
            
            this.monthlyPurchasedTableAdapter.Fill(this.purchasedProducts.MonthlyPurchased,fromDate,toDate);
            this.chartProductPurchasedTableAdapter.Fill(this.purchasedProducts.ChartProductPurchased,fromDate,toDate);
            ReportParameter paramFromdate= new ReportParameter("FromDate",fromDate.ToShortDateString());
            ReportParameter paramToDate = new ReportParameter("ToDate",ToDate.ToShortDateString());
            ReportParameter [] param = new ReportParameter[2]{paramFromdate,paramToDate};
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}