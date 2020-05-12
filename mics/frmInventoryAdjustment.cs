using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using MICS.Utilities;

namespace MICS
{
    public partial class frmInventoryAdjustment : frmParent
    {
        DataSet dsProductInventory = null;
        int InventoryAdjustmentCount = 0;
        public frmInventoryAdjustment()
        {
            InitializeComponent();
        }

        private void frmInventoryAdjustment_Load(object sender, EventArgs e)
        {
            InventoryAdjustmentCount = 0;
            PopulateCategories();
            PopulateProductCategories();
            Search(0);
        }
        private void Search(int selectedIndex)
        {
            InventoryAdjustmentCount = 0;
            Cursor.Current = Cursors.WaitCursor;
            GenericQuery gq = new GenericQuery();
            int categoryid = Int32.Parse(cmbCategories.SelectedValue.ToString());
            int subcategoryid = 0;
            if(cmbSubCategory.Items.Count > 0)
                subcategoryid = Int32.Parse(cmbSubCategory.SelectedValue.ToString());
            string item = txtProduct.Text.Trim();
            string sql = String.Empty;
            sql = "select p.productid,c.name as Category,s.name as Subcategory,rtrim(p.Description) as Product,";
             sql += "(select sum(v.quantity) from productinventory v where v.productid=p.productid) as Quantity,";
             sql += "(null) as AdjustedQuantity,";
             sql += "('') as Reason";
             sql += " from  product p ,productcategory c,productsubcategory s";
             string where = " where p.productsubcategoryid = s.productsubcategoryid and s.productcategoryid=c.productcategoryid";
             where += " and p.description like '" + item + "%'";
             if (subcategoryid > 0)
             {
                 where += " and p.productsubcategoryid =" + subcategoryid;
             }
             else if (categoryid > 0)
             {
                 where += " and c.productcategoryid =" + categoryid;
             }
             string groupby = " group by p.productid,p.Description ,c.name ,s.name";
             string orderyby = " order by p.description";
             sql += where + groupby + orderyby;

            // if (categoryid == 0)
            //{
                
            //    sql = "select p.productid,p.Description as Product,c.name as Category,s.name as Subcategory,";
            //    sql += " v.quantity as Quantity,(select adjustedquantity from productadjustmenthistory where productid = p.productid and id=(select max(id) from productadjustmenthistory where productid =p.productid )) as AdjustedQuanity,";
            //    sql += "(select reason from productadjustmenthistory where productid = p.productid and id=(select max(id) from productadjustmenthistory where productid =p.productid )) as Reason, ";
            //    sql += " v.ModifiedDate as LastModified ";
            //    sql += " from  ";
            //    sql += " product p ,productinventory v,productcategory c,productsubcategory s ";
            //    sql += " where description like '" + item + "%' and" ;
            //    sql += " p.productid=v.productid and p.productsubcategoryid = s.productsubcategoryid and s.productcategoryid=c.productcategoryid";
            //    sql += " order by p.Description";
            //}
            //if(categoryid >=1)
            //{
            //    where += " and c.productcategoryid =" + categoryid;
            //    if (subcategoryid > 0)
            //    {
            //        where += " and p.productsubcategoryid = " + subcategoryid;
            //    }
            //    sql = "select p.productid,p.Description as Product,c.name as Category,s.name as Subcategory,";
            //    sql += " v.quantity as Quantity,(select adjustedquantity from productadjustmenthistory where productid = p.productid and id=(select max(id) from productadjustmenthistory where productid =p.productid )) as AdjustedQuanity,";
            //    sql += "(select reason from productadjustmenthistory where productid = p.productid and id=(select max(id) from productadjustmenthistory where productid =p.productid )) as Reason ,";
            //    sql += " v.ModifiedDate as LastModified ";
            //    sql += " from  ";
            //    sql += " product p ,productinventory v,productcategory c,productsubcategory s ";
            //    sql += " where  ";
            //    sql += " p.productid=v.productid and p.productsubcategoryid = s.productsubcategoryid and s.productcategoryid=c.productcategoryid";
            //    sql += " and c.productcategoryid =" + categoryid;
            //    sql += " order by p.description ";
            //}
            try
            {
                dsProductInventory = new DataSet();
                dsProductInventory = gq.GetDataSet(false, sql);
                dgInventory.DataSource = dsProductInventory.Tables[0];
                dgInventory.Columns["productid"].Visible = false;
                dgInventory.Columns["Category"].ReadOnly = true;
                dgInventory.Columns["Subcategory"].ReadOnly = true;
                dgInventory.Columns["Product"].ReadOnly = true;
                dgInventory.Columns["Quantity"].ReadOnly = true;

                if (dsProductInventory.Tables[0].Rows.Count > 0)
                {
                    dgInventory.Rows[0].Selected = false;
                    dgInventory.Rows[selectedIndex].Selected = true;
                    dgInventory.FirstDisplayedScrollingRowIndex = selectedIndex;
                    GridClick(selectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                gq = null;
                Cursor.Current = Cursors.Default;
            }
        }

        private void PopulateCategories()
        {
            Cursor.Current = Cursors.WaitCursor;
            ProductCategory selectNew = new ProductCategory();
            ProductCategoryCollection col = new ProductCategoryCollection();
            ProductCategory pc = new ProductCategory();
            try
            {
                selectNew.Name = "[Show All]";
                selectNew.ProductCategoryID = 0;
                col = pc.GetAllProductCategoryCollection();
                col.Insert(0, selectNew);
                cmbCategories.DataSource = col;
                cmbCategories.DisplayMember = "Name";
                cmbCategories.ValueMember = "ProductCategoryID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Subcategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }

            Cursor.Current = Cursors.Default;
        }
        private void PopulateProductCategories()
        {
            Cursor.Current = Cursors.WaitCursor;
            ProductCategory selectNew = new ProductCategory();
            ProductCategoryCollection col = new ProductCategoryCollection();
            ProductCategory pc = new ProductCategory();
            try
            {
                selectNew.Name = "[Select One]";
                selectNew.ProductCategoryID = 0;
                col = pc.GetAllProductCategoryCollection();
                col.Insert(0, selectNew);
                cmbProductCategories.DataSource = col;
                cmbProductCategories.DisplayMember = "Name";
                cmbProductCategories.ValueMember = "ProductCategoryID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Subcategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }

            Cursor.Current = Cursors.Default;
        }
        private void PopulateProductSubCategories(int catID,ComboBox cmb)
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
                cmb.DataSource = col;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "ProductSubCategoryID";
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
        //private void PopulatePorducts(int subID)
        //{
        //    Product prod = new Product();
        //    Product newProd = new Product();
        //    ProductCollection col = new ProductCollection();
        //    newProd.ProductID = 0;
            
        //    newProd.Name = "[Select One]";
        //    string where = "[ProductSubCategoryId]=" + subID;
        //    string orderBy = "[Name]";
        //    Cursor.Current = Cursors.WaitCursor;
        //    try
        //    {
        //        col = prod.GetProductsCollection(where, orderBy);
        //        col.Insert(0, newProd);
        //        cmbProducts.DataSource = col;
        //        cmbProducts.DisplayMember = "Name";
        //        cmbProducts.ValueMember = "Productid";


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        Cursor.Current = Cursors.Default;
        //    }
        //    finally
        //    {
        //        prod = null;
        //        newProd = null;
        //        Cursor.Current = Cursors.Default;
        //    }
                

            

        //}
        private void dgInventory_MouseClick(object sender, MouseEventArgs e)
        {
           // GridClick(-1);
        }
        private void GridClick(int rowIndex)
        {
            
            //DataGridViewRow row = new DataGridViewRow();
            //if (rowIndex < 0)
            //    row = dgInventory.CurrentRow;
            //else
            //    row = dgInventory.Rows[rowIndex];
            //if (row == null) return;
            //foreach (DataGridViewCell cell in row.Cells)
            //{
            //    switch (cell.OwningColumn.Name)
            //    {
            //        case "Product":
            //            txtProduct.Text = cell.Value.ToString();
            //            break;
            //        case "AdjustedQuanity":
            //            txtAdjustedQuanity.Text = cell.Value.ToString();
            //            break;
            //        case "Reason":
            //            txtReason.Text = cell.Value.ToString();
            //            break;
            //    }

            //}
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(0);
        }
        private bool ValidateFields()
        {
            //ValidateEmpty(txtProduct);
           // ValidateEmpty(txtAdjustedQuanity);
           // ValidateEmpty(txtReason);
           // if (ValidateEmpty(txtProduct) == false) return false;
          //  if (ValidateEmpty(txtAdjustedQuanity) == false) return false;
          //  if (ValidateEmpty(txtReason )==false) return false;
            
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields ()== false) return;
            if (dgInventory.Rows.Count < 1 || InventoryAdjustmentCount == 0) return;
           // int selectedRows = dgInventory.SelectedRows.Count;

            int selectedCount = 0;
            DialogResult result = MessageBox.Show("You are about to adjust the inventory for " + InventoryAdjustmentCount.ToString() + " item(s). Are you sure you want proceed.?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            int curIndex = 0;
            bool success = true;
            for (int row = 0; row < dgInventory.Rows.Count; row++ )
            {
                if (dsProductInventory.Tables[0].Rows[row]["AdjustedQuantity"] == DBNull.Value)
                    continue;
                if (selectedCount > InventoryAdjustmentCount)
                    break;
                selectedCount++;
                //DataGridViewRow row = dgInventory.CurrentRow;
                //int curIndex = dgInventory.CurrentRow.Index;
                curIndex = row;
                //if (row == null) return;
               

                Cursor.Current = Cursors.WaitCursor;
                ProductInventory pi = new ProductInventory();
                ProductAdjustmentHistory pah = new ProductAdjustmentHistory();
                // int adjustedQuantity = Int32.Parse(txtAdjustedQuanity.Text.Trim());
                //   string reason = txtReason.Text.Trim();

                
                try
                {
                    int productid = Int32.Parse(dsProductInventory.Tables[0].Rows[row]["productid"].ToString()); //Int32.Parse(dgInventory.CurrentRow.Cells["productid"].Value.ToString());
                    int CurQuantity = 0;
                    int NewQuantity = 0;
                    if (dsProductInventory.Tables[0].Rows[row]["AdjustedQuantity"] != DBNull.Value)
                        NewQuantity = Int32.Parse(dsProductInventory.Tables[0].Rows[row]["AdjustedQuantity"].ToString());
                    if(dsProductInventory.Tables[0].Rows[row]["Quantity"] != DBNull.Value)
                        CurQuantity = Int32.Parse(dsProductInventory.Tables[0].Rows[row]["Quantity"].ToString());


                    pah.ProductID = productid;
                    pah.AdjustedQuantity = NewQuantity - CurQuantity;
                    if (dsProductInventory.Tables[0].Rows[row]["Reason"] != DBNull.Value)
                        pah.Reason = dsProductInventory.Tables[0].Rows[row]["Reason"].ToString();
                    else
                        pah.Reason = "";
                    // pah.AdjustedQuantity = adjustedQuantity;
                    pah.ModifiedDate = DateTime.Now;
                    pah.AddProductAdjustmentHistory(pah);


                    pi.ProductID = productid;
                    pi.Quantity = NewQuantity;
                    pi.LocationID = 0;
                    pi.ModifiedDate = DateTime.Now;
                    pi.Shelf = "";
                    pi.Bin = 0;
                    ProductInventory inv = new ProductInventory();
                    inv = inv.GetProductInventorys(productid);
                    //  pi.Quantity = (long) adjustedQuantity;
                    //pi.ModifiedDate = DateTime.Now;
                    if (inv.ProductID > 0)
                        pi.UpdateProductInventory(pi);
                    else
                        pi.AddProductInventory(pi);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Product Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                    success = false;
                    break;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            if(success)
                MessageBox.Show("Inventory Adjusted successfully.", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Inventory Adjustment failed.", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Search(curIndex);
        }

        private void cmbProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductCategories.SelectedIndex < 1)
            {
               // cmbProducts.DataSource = null;
                cmbProductSubCategories.DataSource = null;
               // cmbProducts.Items.Clear();
                cmbProductSubCategories.Items.Clear();
                return;
            }
            int catID = Int32.Parse(cmbProductCategories.SelectedValue.ToString());

            PopulateProductSubCategories(catID, cmbProductSubCategories);

        }

        private void cmbProductSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductSubCategories.SelectedIndex < 1)
            {
               // cmbProducts.DataSource = null;
               // cmbProducts.Items.Clear();
                return;
            }
            int subid = Int32.Parse(cmbProductSubCategories.SelectedValue.ToString());
            
           // PopulatePorducts(subid);
        }

        private void btnHSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
         //   int productid = Int32.Parse(cmbProducts.SelectedValue.ToString());
            GenericQuery q = new GenericQuery();
            DataSet ds = new DataSet();
            string productDesc = txtHProduct.Text;
            string sql = "select p.productid,c.name as Category,s.name as Subcategory,p.description as Product,";
            sql += " v.quantity as Quantity, h.adjustedquantity as AdjustedQuanity,";
            sql += "h.reason as Reason, ";
            sql += " h.ModifiedDate as LastModified ";
            sql += " from  ";
            sql += " product p ,productinventory v,productcategory c,productsubcategory s, productadjustmenthistory h ";
            sql += " where  ";
            sql += " p.productid=v.productid and p.productid=h.productid and p.productsubcategoryid = s.productsubcategoryid and s.productcategoryid=c.productcategoryid";
            string where = " and p.description like '" + productDesc + "%'";
            if (cmbProductSubCategories.SelectedIndex > 0)
            {
                where += " and p.productsubcategoryid=" + cmbProductSubCategories.SelectedValue.ToString();
            }
            else if (cmbProductCategories.SelectedIndex > 0)
            {
                where += " and s.productcategoryid=" + cmbProductCategories.SelectedValue.ToString();
            }
            string OrderBy = " order by p.description,LastModified desc ";
            sql += where + OrderBy;
            try
            {
                ds = q.GetDataSet(false, sql);
                dgHisotry.DataSource = ds.Tables[0];
                dgHisotry.Columns["Quantity"].Visible=false;
                dgHisotry.Columns["productid"].Visible = false;
                if (dgHisotry.Rows.Count > 0)
                {
                    txtQuantity.Text = dgHisotry.Rows[0].Cells["Quantity"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Product doesn't have adjustment history", "Product Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                ds = null;
                q = null;
                Cursor.Current = Cursors.Default;
            }

        }

        //private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    EnableButton();
        //}
        //private void EnableButton()
        //{
        //    if (cmbProducts.SelectedIndex > 0)
        //    {
        //        btnHSearch.Enabled = true;
        //    }
        //    else
        //    {
        //        btnHSearch.Enabled = false;
        //    }
        //}

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void txtAdjustedQuanity_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedIndex < 1)
            {
                cmbSubCategory.DataSource = null;
                cmbProductSubCategories.Items.Clear();
                return;
            }
            int catID = Int32.Parse(cmbCategories.SelectedValue.ToString());
            PopulateProductSubCategories(catID, cmbSubCategory);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            txtProduct.Text = "";
            if (cmbCategories.Items.Count > 0)
            {
                cmbCategories.SelectedIndex = 0;
            }
            if (cmbSubCategory.Items.Count > 0)
            {
                cmbSubCategory.SelectedIndex = 0;
            }
        }

        private void dgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgInventory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int quant = 0;
            int currow = dgInventory.CurrentRow.Index;
            try
            {
                quant = Int32.Parse(dsProductInventory.Tables[0].Rows[currow]["AdjustedQuantity"].ToString());
                InventoryAdjustmentCount++;
            }
            catch
            {
                quant = 0;
            }
        }

        private void tpAdjustmentHisotry_Click(object sender, EventArgs e)
        {

        }

        private void btnHSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearHistorySearch();
        }
        private void ClearHistorySearch()
        {
            txtHProduct.Text = "";
            cmbProductCategories.SelectedIndex = 0;
            if (cmbProductSubCategories.Items.Count > 0)
            {
                cmbProductSubCategories.SelectedIndex = 0;
            }
        }

        private void dgHisotry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgHisotry_SelectionChanged(object sender, EventArgs e)
        {
            int cur_row = dgHisotry.CurrentRow.Index;
            txtQuantity.Text = dgHisotry.Rows[cur_row].Cells["Quantity"].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tcInventoryAdjustment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcInventoryAdjustment.SelectedIndex == 0)
                this.AcceptButton = this.btnSearch;
            else if (tcInventoryAdjustment.SelectedIndex == 1)
                this.AcceptButton = this.btnHSearch;
            else
                this.AcceptButton = null;
        }

       
    }
}