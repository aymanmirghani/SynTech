using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS
{
    public partial class frmSaleOrderProducts : frmParent
    {
        private DataSet dsProducts = null;
        private DataTable dtProducts = null;
        public frmSaleOrderProducts()
        {
            InitializeComponent();
        }

        /*private void frmSaleOrderProducts_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }*/
        public DataTable ShowSalesProducts()
        {
            PopulateGrid();
            this.ShowDialog();
            return dtProducts;
        }
        public DataSet ProductDataSet
        {
            get{return dsProducts;}
            set{dsProducts=value;}
        }
        public DataTable ProductDataTable
        {
            get { return dtProducts; }
        }
        private void PopulateGrid()
        {
            if (dsProducts == null)
            {
                MessageBox.Show("No records found", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dtProducts = dsProducts.Tables[0];
            grdProducts.DataSource = dsProducts;

        }
    }
}