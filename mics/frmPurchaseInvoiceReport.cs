using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
namespace MICS
{
    public partial class frmPurchaseInvoiceReport : Form
    {
     //   private PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
        private PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
        private string _where = String.Empty;
        private string _orderBy = String.Empty;
        public frmPurchaseInvoiceReport(string where,string orderBy)
        {
            this._where = where;
            this._orderBy = orderBy;
            InitializeComponent();
        }

        private void frmPurchaseInvoiceReport_Load(object sender, EventArgs e)
        {
            
            this.PurchaseInvoiceDetailCollectionBindingSource.DataSource = pid.GetPurchaseInvoiceDetailsCollection(_where, String.Empty);
           // this.PurchaseInvoiceHeaderBindingSource = pih.GetPurchaseInvoiceHeaders(_where, String.Empty);
            this.reportViewer1.RefreshReport();
        
        }
    }
}