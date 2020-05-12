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
    public partial class frmVendorsList : Form
    {
        public frmVendorsList()
        {
            InitializeComponent();
        }

        private void frmVendorsList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.Vendor' table. You can move, or remove it, as needed.
            this.VendorTableAdapter.Fill(this.PurchasedProducts.Vendor);

            this.reportViewer1.RefreshReport();
        }
        public void SetReportParameters(CheckedListBox list)
        {
            string[] strValues;
            int count = list.Items.Count;
            strValues = new string[count];
            for (int i = 0; i < count; i++)
            {
                bool selected = false;
                for (int j = 0; j < list.CheckedItems.Count; j++)
                {
                    if (list.Items[i] == list.CheckedItems[j])
                    {
                        strValues[i] = list.CheckedItems[j].ToString();
                        selected = true;
                        break;
                    }
                }
                if(!selected)
                  strValues[i] = "";
                         
            }
            ReportParameter rp = new ReportParameter("ReportColumns", strValues);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.RefreshReport();

        }
        public ReportParameterInfoCollection GetReportParamters()
        {
            ReportParameterInfoCollection p = this.reportViewer1.LocalReport.GetParameters();
            return (p);
        }
    }
}