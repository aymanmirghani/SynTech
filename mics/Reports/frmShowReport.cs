using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.Reports.PurchasedProductsTableAdapters;
using MICS.Reports;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting;

namespace MICS.Reports
{
    public partial class frmShowReport : Form
    {
        private int m_ReportId = 0;
        MICS.Reports.PurchasedProducts PurchasedProducts = new PurchasedProducts();
        public frmShowReport()
        {
            InitializeComponent();
        }
        public frmShowReport(int reportid)
        {
            InitializeComponent();
            m_ReportId = reportid;
        }
        private void frmShowReport_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }
        private void ShowReport()
        {
            switch (m_ReportId)
            {
                case 1:     //YearToDateSale
                    YearToDateSaleTableAdapter ad = new YearToDateSaleTableAdapter();
                    PurchasedProducts.YearToDateSaleDataTable dt= new PurchasedProducts.YearToDateSaleDataTable();
                   // ad.Fill(PurchasedProducts.YearToDateSaleDataTable);
                   // ReportDataSource("Ds", PurchasedProducts.Tables["YearSaleByMonth"]);
                    ReportDataSource ds = new ReportDataSource("Ds", PurchasedProducts.Tables["YearToDateSale"]);
                    break;
                case 2:
                    break;
            }
        }

        public int ReportID
        {
            set { m_ReportId = value; }
            get { return m_ReportId; }
        }
    }
}