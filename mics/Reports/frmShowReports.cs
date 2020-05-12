using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS.Reports
{
    public partial class frmShowReports : Form
    {
        string[,] ReportsName =
        {   //Report name                        //rdlc file                                    //dataset name
            {"Year To Date Sales Summary",      "MICS.Reports.DashBoard.rdlc",                  "YearSaleByMonth"},
            {"Sales By Customer",               "MICS.Reports.ProductSalesByCustomer.rdlc",      "ProductSalesByCustomer"  }
        };
        Microsoft.Reporting.WinForms.ReportDataSource ds = new Microsoft.Reporting.WinForms.ReportDataSource();
        public frmShowReports()
        {
            InitializeComponent();
        }

        private void frmShowReports_Load(object sender, EventArgs e)
        {
            FillReportTypes();
        }
        private void FillReportTypes()
        {
            for (int i = 0; i < ReportsName.Length / 3; i++)
            {
                cmbReportName.Items.Add(ReportsName[i,0]);
            }
        }
        private void ShowReport()
        {
            string report = cmbReportName.Text;
            rptViewer.Reset();
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.Clear();
            ds = new Microsoft.Reporting.WinForms.ReportDataSource();
            for (int i = 0; i < ReportsName.Length / 3; i++)
            {
                if (report == ReportsName[i,0])
                {
                    bindingSource1.DataMember = ReportsName[i, 2];
                    ds.Name = "PurchasedProducts_" + ReportsName[i, 2];
                    ds.Value = bindingSource1;
                    FillDataSet(report);
                    rptViewer.LocalReport.DataSources.Add(ds);
                    this.rptViewer.LocalReport.ReportEmbeddedResource = ReportsName[i, 1];
                    this.rptViewer.RefreshReport();
                    break;
                }
            }

        }
        private void FillDataSet(string name)
        {
            switch (name)
            {
                case "Year To Date Sales Summary":
                //     MICS.Reports.PurchasedProductsTableAdapters.YearSaleByMonthTableAdapter TableAdaptor = new MICS.Reports.PurchasedProductsTableAdapters.YearSaleByMonthTableAdapter();
                //     TableAdaptor.Fill(purchasedProducts.YearSaleByMonth);
                     break;
                case "Sales By Customer":
                 //   MICS.Reports.PurchasedProductsTableAdapters.ProductSalesByCustomerTableAdapter SaleByCustAdp = new MICS.Reports.PurchasedProductsTableAdapters.ProductSalesByCustomerTableAdapter();
                //    SaleByCustAdp.Fill(purchasedProducts.ProductSalesByCustomer,DateTime.Parse("01/01/2007"),DateTime.Parse("12/31/2007"),101);
                    break;
                default:
                    break;
            }
        }
        private void btnViewReport_Click_1(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}