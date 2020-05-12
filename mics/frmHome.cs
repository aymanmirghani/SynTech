using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS
{
    public partial class frmHome : Form
    {
        private Form _form = null;
        public frmHome(System.Windows.Forms.Form obj)
        {
            InitializeComponent();
            this._form = obj;

        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder frm = new frmPurchaseOrder();
            frmMICS m = new frmMICS();
            frm.MdiParent = _form;
            frm.Show();

        }

      //  private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    //    {

    //    }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            frmSaleOrder frm = new frmSaleOrder();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            frmVendor frm = new frmVendor();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports.frmReports frm = new MICS.Reports.frmReports();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void btnTerritory_Click(object sender, EventArgs e)
        {
            frmSalesTerritory frm = new frmSalesTerritory();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void frmHome_Resize(object sender, EventArgs e)
        {
           /* this.Width = MdiParent.Width;
            this.Height = MdiParent.Height;
            this.Top = MdiParent.Top;
            this.Left = MdiParent.Left;*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmInventoryAdjustment frm = new frmInventoryAdjustment();
            frm.MdiParent = _form;
            frm.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCompanyName_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblCompanyName.Text = System.Configuration.ConfigurationManager.AppSettings["CompanyName"];
            //if (lblCompanyName.Text.ToUpper().Contains("COLUMBUS"))
            //{
            //    if (DateTime.Today >= DateTime.Parse("01/01/2010"))
            //    {
            //        MessageBox.Show("Your License has expired. Please contact Synergy Tech for a new license");
            //        Application.Exit();
            //    }
            //}
        }

    }
}