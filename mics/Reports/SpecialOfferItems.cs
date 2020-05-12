using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS.Reports
{
    public partial class SpecialOfferItems : Form
    {
        private int m_SpecialOfferId = 0;
        public SpecialOfferItems()
        {
            InitializeComponent();
        }

        private void SpecialOfferItems_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.SpecialOffer' table. You can move, or remove it, as needed.
            this.SpecialOfferTableAdapter.FillBySpecialOfferId(this.PurchasedProducts.SpecialOffer,m_SpecialOfferId);

            this.reportViewer1.RefreshReport();
        }
        public int SpecialOfferID
        {
            set { m_SpecialOfferId = value; }
            get { return m_SpecialOfferId; }
        }
    }
}