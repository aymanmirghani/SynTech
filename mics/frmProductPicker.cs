using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MICS.BLL;
using MICS.Utilities;
namespace MICS
{
   
    public partial class frmProductPicker : frmParent
    {
        DataTable dtProducts = new DataTable();
        int m_OrderType = 0;
        int m_VendorID = 0;
        //decimal.partial(txt.trim, NumberStyles.currency,Nullable)
        public frmProductPicker()
        {
        }
        public frmProductPicker(OrderType order,int vendorid)
        {
            InitializeComponent();
            m_OrderType = (int)order;
            switch (order)
            {
                
                case OrderType.SaleOrder:
                    SetupSaleOrderGrid();
                    break;
                case OrderType.PurchaseOrder:
                    m_VendorID = vendorid;
                    break;
            }
        }
        private void LoadProductCategories()
        {
            ProductCategory cat = new ProductCategory();
            ProductCategoryCollection col = new ProductCategoryCollection();
            ProductCategory selectNew = new ProductCategory();
            selectNew.ProductCategoryID = 0;
            selectNew.Name = "[Select Category]";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                col = cat.GetAllProductCategoryCollection();
                col.Insert(0, selectNew);
                cmbCategory.DataSource = col;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "ProductCategoryID";

                int catID = Int32.Parse(cmbCategory.SelectedValue.ToString());
                LoadProductSubCategories(catID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                cat = null;

            }
            Cursor.Current = Cursors.Default;
        }
        private void LoadProductSubCategories(int catID)
        {
            ProductSubcategory sub = new ProductSubcategory();
            ProductSubcategory selectNew = new ProductSubcategory();
            ProductSubcategoryCollection col = new ProductSubcategoryCollection();
            selectNew.ProductSubcategoryID = 0;
            selectNew.Name = "[Select One]";
            string where = "[ProductCategoryID] = " + catID;
            string orderBy = "Name";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                col = sub.GetProductSubcategoryCollection(where, orderBy);
                col.Insert(0, selectNew);
                cmbSubCategory.DataSource = col;
                cmbSubCategory.DisplayMember = "Name";
                cmbSubCategory.ValueMember = "ProductSubCategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                sub = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void SetupSaleOrderGrid()
        {

        }
        public DataTable GetSelectedProducts()
        {
            this.ShowDialog();
            return dtProducts;
        }
        public DataTable GetSaleOrderProducts()
        {
            this.ShowDialog();
            return dtProducts;
        }
        private void SearchProducts()
        {
            Cursor.Current = Cursors.WaitCursor;
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Image = Properties.Resources.user_go;
            //img.Name=
            button.HeaderText = "Last 6 Orders";
            button.Text ="Orders";
            button.UseColumnTextForButtonValue = true;
            button.DisplayIndex = 0;
            button.FlatStyle = FlatStyle.System;
            string searchedProduct = txtProductCode.Text.Trim();
            int productSubcategoryID=0;
            int productCategoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            if (productCategoryId > 0)
            {
                productSubcategoryID = Int32.Parse(cmbSubCategory.SelectedValue.ToString());
            }

            string sql = "SELECT [Product].[ProductID],	[Product].[Description] AS Name, ";
            sql += "[Product].[ProductNumber] PRODUCT_CODE,	[Product].[ReorderPoint],";
            sql += "[ProductInventory].[QUANTITY] as INSTOCK,";
            //sql += "max([so].specialofferid)specialofferid,[so].description as SpecialOfferDesc,";
            sql += "(select max([so].specialofferid) from specialoffer so join specialofferproduct sop on sop.SpecialOfferID=so.SpecialOfferID";
            sql += " where sop.productid=product.productid and so.StartDate <= getdate() and so.EndDate > getdate())specialofferid,";
            sql+= " (select [so].description from specialoffer so join specialofferproduct sop on sop.SpecialOfferID=so.SpecialOfferID ";
            sql += " where sop.productid=product.productid and so.StartDate <= getdate() and so.EndDate > getdate()) SpecialOfferDesc,";
            if(m_OrderType == (int)OrderType.SaleOrder)
            {
                sql += "max([Product].[ListPrice]) AS PRICE ";
            }
            else
            {
                sql += "max([Product].[StandardCost]) AS PRICE ";
            }
            sql += " FROM Product";
            sql += " INNER JOIN  ProductSubcategory ON Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID ";
            sql += " LEFT OUTER JOIN ProductInventory ON Product.ProductID = ProductInventory.ProductID ";
           // sql += " LEFT OUTER JOIN SpecialOfferProduct sop on Product.ProductID=sop.ProductID";
           // sql += " LEFT OUTER JOIN SpecialOffer so on sop.SpecialOfferID=so.SpecialOfferID and so.StartDate <= getdate() and so.EndDate > getdate()";
            sql += " WHERE ";
            if (!chkInactive.Checked)
                sql += "activeflag=1 and ";
            if (productSubcategoryID > 0)
            {
                sql += "(Product.ProductSubcategoryID =" + productSubcategoryID + ") AND ";
            }
            if (productCategoryId > 0)
            {
                sql += " (ProductSubcategory.ProductCategoryID = " + productCategoryId + ") AND ";
            }
            if (chkCriticalInvenotry.Checked)
            {
                sql += "(Product.ReorderPoint > ProductInventory.Quantity) AND ";
            }
            if (m_VendorID > 0)
            {
                sql += "(product.primaryvendorid=" + m_VendorID + " or product.secondaryvendorid=" + m_VendorID + ") AND ";
            }
            if (searchedProduct.Trim() == String.Empty)
            {
                sql += " (Product.Description LIKE '%')";
            }
            else
            {
                sql += " (Product.Description LIKE '" + searchedProduct + "%')";
            }
            sql += " group by [Product].[ProductID],[Product].[Description], [Product].[ProductNumber],[Product].[ReorderPoint],[ProductInventory].[QUANTITY]";
            sql += " Order by product.Description";
            
            try
            {
                ds = gq.GetDataSet(false,sql);
                dtProducts = ds.Tables[0];
                /*  if (SearchedOrdersGrid.Columns["Edit/View"].Index < 0)
                {
                    SearchedOrdersGrid.Columns.Add(imgEdit);
                    SearchedOrdersGrid.Columns.Add(imgInvoice);
                }*/
                
                dtProducts.Columns.Add("No Cases");
                dtProducts.Columns.Add("Unit/Case");
                dtProducts.Columns.Add(new DataColumn("Quantity",typeof(int)));
                dtProducts.Columns.Add(new DataColumn("Total", typeof(decimal)));
                dtProducts.AcceptChanges();
                
                productGrid.DataSource = dtProducts;
               // productGrid.Columns.Add(img);
                productGrid.Columns["ProductID"].Visible = false;
                //DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["PRODUCTID"].ReadOnly = true;

                if (m_OrderType == (int)OrderType.SaleOrder)
                {
                    productGrid.Columns["REORDERPOINT"].Visible = false;

                }
                else
                {
                    productGrid.Columns["SpecialOfferDesc"].Visible = false;
                }
                productGrid.Columns["REORDERPOINT"].ReadOnly = true;
                productGrid.Columns["REORDERPOINT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["REORDERPOINT"].HeaderText = "Reorder Point";
                productGrid.Columns["REORDERPOINT"].Width = 70;
                productGrid.Columns["INSTOCK"].ReadOnly = true;
                productGrid.Columns["INSTOCK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["INSTOCK"].HeaderText = "In Stock";
                productGrid.Columns["INSTOCK"].Width = 60;
                productGrid.Columns["specialofferid"].Visible = false;
                productGrid.Columns["SpecialOfferDesc"].HeaderText = "Special Offer";
                productGrid.Columns["SpecialOfferDesc"].ReadOnly = true;
                productGrid.Columns["SpecialOfferDesc"].Width = 180;
                productGrid.Columns["NAME"].ReadOnly = true;
                productGrid.Columns["NAME"].Width = 280;
                productGrid.Columns["PRODUCT_CODE"].Visible  = false;
                productGrid.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["PRICE"].DefaultCellStyle.Format = "c";
                productGrid.Columns["PRICE"].Width = 70;
                productGrid.Columns["No Cases"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["Unit/Case"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["Total"].DefaultCellStyle.Format = "c";
                productGrid.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                productGrid.Columns["Quantity"].Width = 70;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Picker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                gq = null;
            }
            Cursor.Current = Cursors.Default;
        }

      
        private void FormatRows()
        {
            if (productGrid.Rows.Count < 1) return;
            for (int i = 0; i < productGrid.Rows.Count; i++)
            {
                int reorderPoint = Int32.Parse(productGrid.Rows[i].Cells["REORDERPOINT"].Value.ToString());
                int inStock = 0;
                if(productGrid.Rows[i].Cells["INSTOCK"].Value != DBNull.Value)
                    inStock = Int32.Parse(productGrid.Rows[i].Cells["INSTOCK"].Value.ToString());
                if ( reorderPoint> inStock )
                {
                    productGrid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                    productGrid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
                    

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           // dtProducts = GetFilledLines();
            this.Hide();
        }

        private void productGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateTotal(int row_index)
        {
          
            Cursor.Current = Cursors.WaitCursor;
            decimal price = 0.00m;
            int noCase = 0;
            int unitPerCase = 0;
            decimal total = 0.00m;
            int quantity = 0;
            if ((productGrid.Rows[row_index].Cells["Unit/Case"].Value.ToString() != String.Empty) && (productGrid.Rows[row_index].Cells["No Cases"].Value.ToString() != String.Empty))
            {
                noCase = Int32.Parse(productGrid.Rows[row_index].Cells["No Cases"].Value.ToString());
                unitPerCase = Int32.Parse(productGrid.Rows[row_index].Cells["Unit/Case"].Value.ToString());
                quantity = noCase * unitPerCase;
                productGrid.Rows[row_index].Cells["Quantity"].Value = quantity;
            }
            if ((productGrid.Rows[row_index].Cells["PRICE"].Value.ToString() != String.Empty) && (productGrid.Rows[row_index].Cells["Quantity"].Value.ToString() != String.Empty))
            {
                try
                {
                    /* dtProducts.Columns.Add("No Cases");
                dtProducts.Columns.Add("Unit/Case");*/
                   

                    price = Decimal.Parse(productGrid.Rows[row_index].Cells["PRICE"].Value.ToString());
                    quantity = Int32.Parse(productGrid.Rows[row_index].Cells["Quantity"].Value.ToString());
                    total = price * quantity;
                    productGrid.Rows[row_index].Cells["Total"].Value = total;

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Product Picker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void productGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (productGrid.Rows.Count < 1) return;
            if (e.ColumnIndex == productGrid.Columns["Quantity"].Index)
            {
                UpdateTotal(productGrid.CurrentRow.Index);
            }
            if ((e.ColumnIndex == productGrid.Columns["Unit/Case"].Index) || (e.ColumnIndex == productGrid.Columns["No Cases"].Index))
            {
                UpdateTotal(productGrid.CurrentRow.Index);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmProductPicker_Load(object sender, EventArgs e)
        {
            LoadProductCategories();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = 0;
            try
            {
               catid= Int32.Parse(cmbCategory.SelectedValue.ToString());
            }
            catch
            {
                return;
            }
            LoadProductSubCategories(catid);
        }

        private void productGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnPSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
            FormatRows();
        }

    }
}