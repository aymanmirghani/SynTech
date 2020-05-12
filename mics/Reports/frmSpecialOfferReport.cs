using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS.Reports
{
    public partial class frmSpecialOfferReport : Form
    {
        public frmSpecialOfferReport()
        {
            InitializeComponent();
        }

        private void frmSpecialOfferReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.SpecialOffer' table. You can move, or remove it, as needed.
            this.SpecialOfferTableAdapter.Fill(this.PurchasedProducts.SpecialOffer);

            this.reportViewer1.RefreshReport();
        }
    }
}