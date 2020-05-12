using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.DAL;
using MICS.BLL;
using Microsoft.Reporting.WinForms;
namespace MICS.Reports
{
    public partial class frmPastDueInvoices : Form
    {
        public frmPastDueInvoices()
        {
            InitializeComponent();
        }

        private void frmPastDueInvoices_Load(object sender, EventArgs e)
        {
            LoadTerritoris();
            // TODO: This line of code loads data into the 'PurchasedProducts.OverDueInvoices' table. You can move, or remove it, as needed.
            this.OverDueInvoicesTableAdapter.Fill(this.PurchasedProducts.OverDueInvoices);
            this.reportViewer1.RefreshReport();
        }
        private void LoadTerritoris()
        {
            SalesTerritory terr = new SalesTerritory();
            SalesTerritoryCollection terrCol = new SalesTerritoryCollection();
            try
            {
                terrCol = terr.GetAllSalesTerritoryCollection();
                terr.TerritoryID = 0;
                terr.Name = "All";
                terr.ModifiedDate = DateTime.Now;
                terrCol.Insert(0, terr);
                cmbTerritory.DataSource = terrCol;
                cmbTerritory.DisplayMember = "Name";
                cmbTerritory.ValueMember = "TerritoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                terr = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string where = cmbTerritory.SelectedIndex > 0 ? " and cus.territoryid=" + cmbTerritory.SelectedValue.ToString() : "";
            
            this.OverDueInvoicesTableAdapter.FillByWhere(this.PurchasedProducts.OverDueInvoices,where);
            this.reportViewer1.RefreshReport();

          //  ReportParameter[] p = new ReportParameter[1];
            
           // p[1] = cmbTerritory.SelectedIndex > 0 ? new ReportParameter("territoryid", cmbTerritory.SelectedValue.ToString()) : new ReportParameter("territoryid", "");

        }
    }
}