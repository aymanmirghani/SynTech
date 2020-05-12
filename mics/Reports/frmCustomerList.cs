using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MICS.DAL;
using MICS.BLL;

namespace MICS.Reports
{
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.Customer' table. You can move, or remove it, as needed.
            LoadTerritories();
            ShowReport();
            //this.reportViewer1.LocalReport.SetParameters(
        }
        private void ShowReport()
        {
            if (cmbTerritory.SelectedIndex == 0)
            {
                this.CustomerTableAdapter.Fill(this.PurchasedProducts.Customer);
            }
            else
            {
                int id = Int32.Parse(cmbTerritory.SelectedValue.ToString());
                this.CustomerTableAdapter.FillByTerritory(this.PurchasedProducts.Customer, id);
            }
            SetReportParameter();
            this.reportViewer1.RefreshReport();
        }
        public void SetReportParameters(CheckedListBox list)
        {
            for(int i=0; i<list.CheckedItems.Count; i++)
            {
                ReportParameter p = new ReportParameter(list.CheckedItems[i].ToString(), "Y");
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
            }
            this.reportViewer1.RefreshReport();
            
        }
        private void LoadTerritories()
        {
            SalesTerritory st = new SalesTerritory();
            DataSet ds = st.GetAllSalesTerritoryDataSet();
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "<All Territories>";
            dt.Rows.InsertAt(dr, 0);
            cmbTerritory.DataSource = dt;
            cmbTerritory.DisplayMember = "Name";
            cmbTerritory.ValueMember = "TerritoryID";
        }
        public ReportParameterInfoCollection GetReportParamters()
        {
            ReportParameterInfoCollection p = this.reportViewer1.LocalReport.GetParameters();
            return (p);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ShowReport();
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