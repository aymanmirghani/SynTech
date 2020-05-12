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
    public partial class frmProducts : frmParent
    {
        LogWriter log = new LogWriter();
        DataSet dsProducts;
        DataSet dsSpeicalOffer;
        public frmProducts()
        {
            InitializeComponent();
            this.ActiveControl = lblProductID;
        }
        
        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductCategories(null, 0);
            LoadVendors(0, 0);
            Search();
            //PopulateGrid("activeFlag=1", "Name",0);
            // worker.RunWorkerAsync();
           
            
        }
        private void LoadVendors(int PrimaryVendor, int SecondaryVendor)
        {
            Vendor v = new Vendor();
            VendorCollection Primary = new VendorCollection();
            VendorCollection Secondary = new VendorCollection();
            try
            {

                Primary = v.GetAllVendorsCollection();
                //Secondary = v.GetAllVendorsCollection();
                Primary.Insert(0, new Vendor(0, 0, "", "<Select One>", "", 1, false, "", "", "", false, DateTime.Today, "", ""));
                cmbPrimaryVendor.DataSource = Primary;
                cmbPrimaryVendor.DisplayMember = "Name";
                cmbPrimaryVendor.ValueMember = "VendorId";

                foreach (Vendor vend in Primary)
                {
                    Secondary.Add(vend);
                }
                //Primary.Insert(0, new Vendor(0, 0, "", "<Select One>", "", 1, false, "", "", "", false, DateTime.Today, "", ""));
                cmbSecondaryVendor.DataSource = Secondary;
                cmbSecondaryVendor.DisplayMember = "Name";
                cmbSecondaryVendor.ValueMember = "VendorId";
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                v = null;
                Primary = null;
                Secondary = null;

            }
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
                cmbProductSubCategories.DataSource = col;
                cmbProductSubCategories.DisplayMember = "Name";
                cmbProductSubCategories.ValueMember = "ProductSubCategoryID";
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
        private void LoadProductCategories(string categoryName,int categoryid)
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
            if (categoryName != null)
            {
                int selectedIndex = cmbCategory.FindStringExact(categoryName, 0);
                cmbCategory.SelectedIndex = selectedIndex;
            }
            Cursor.Current = Cursors.Default;
        }
       

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex ==0)
            {
                return;
            }
            int catID = Int32.Parse(cmbCategory.SelectedValue.ToString());

            LoadProductSubCategories(catID);
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGrid(String.Empty, String.Empty,0);
        }
        private void SetupProductGrid()
        {
            dsProducts = new DataSet();
            try
            {
                DataTable dt = new DataTable("products");
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("Category", typeof(String)));
                dt.Columns.Add(new DataColumn("Name", typeof(String)));
                dt.Columns.Add(new DataColumn("Description", typeof(String)));
                dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Cost", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Primary Vendor", typeof(String)));
                dt.Columns.Add(new DataColumn("Sec. Vendor", typeof(String)));
                dt.Columns.Add(new DataColumn("Active", typeof(Boolean)));
                dt.Columns.Add(new DataColumn("Comments", typeof(String)));
                dt.Columns.Add(new DataColumn("Sub Category", typeof(String)));
                dt.Columns.Add(new DataColumn("SafetyStockLevel", typeof(int)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
                dt.Columns.Add(new DataColumn("ReorderPoint", typeof(int)));
                dt.Columns.Add(new DataColumn("DaysToManufacture", typeof(int)));
                dt.Columns.Add(new DataColumn("ProductNumber", typeof(String)));

                dsProducts.Tables.Add(dt);
                ProductGrid.DataSource = dsProducts.Tables[0];
                SetupGridProperties();                 


                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "SetupProductGrid");
                MessageBox.Show(ex.Message);
                
            }
        }
        private void SetupGridProperties()
        {
            //ProductGrid.DefaultCellStyle.Font.Name = "Tahoma";
            //ProductGrid.DefaultCellStyle.Font.Size = 8;
            //ProductGrid.Columns["Category"].Width = 130;
            ProductGrid.Columns["Name"].Width =180;
            ProductGrid.Columns["Description"].Width = 190;
            ProductGrid.Columns["Price"].Width = 50;
            ProductGrid.Columns["Cost"].Width = 50;
            ProductGrid.Columns["Price"].DefaultCellStyle.Format = "c";
            ProductGrid.Columns["Cost"].DefaultCellStyle.Format = "c";
            //ProductGrid.Columns["Primary Vendor"].Width = 150;
            //ProductGrid.Columns["Sec. Vendor"].Width = 150;
            ProductGrid.Columns["Active"].Width = 50;

            ProductGrid.Columns["ID"].Visible = false;
            ProductGrid.Columns["Comments"].Visible = false;
            ProductGrid.Columns["SafetyStockLevel"].Visible = false;
            ProductGrid.Columns["Quantity"].Visible = false;
            ProductGrid.Columns["ReorderPoint"].Visible = false;
            ProductGrid.Columns["DaysToManufacture"].Visible = false;
            ProductGrid.Columns["ProductNumber"].Visible = false;
            ProductGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        private void SetupSpecialOfferGrid()
        {
          
            using (dsSpeicalOffer = new DataSet())
            {
                try
                {
                    DataTable dt = new DataTable("SpecialOffer");
                    dt.Columns.Add(new DataColumn("Description", typeof(String)));
                    dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));

                    dsSpeicalOffer.Tables.Add(dt);
                    grdSpeicalOffers.DataSource = dsSpeicalOffer.Tables[0];

                   // grdSpeicalOffers.Width = 300;
                    grdSpeicalOffers.Columns["Description"].Width = 200;
                    grdSpeicalOffers.Columns["Amount"].Width = 80;
                    grdSpeicalOffers.Columns["Amount"].DefaultCellStyle.Format = "c";
                    grdSpeicalOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;





                }
                catch (Exception ex)
                {
                    log.Write(ex.Message, "SetupProductGrid");
                    MessageBox.Show(ex.Message);

                }
            }
        
        }
        private void PopulateGrid(string where, string orderBy, int selectedID)
        {
            Product p = new Product();
            SetupProductGrid();
            DataSet ds = new DataSet();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (where == String.Empty)
                {
                    ds = p.GetProductsDataSet("1=1", "name"); // p.GetAllProductsDataSet();
                }
                else
                {
                    ds = p.GetProductsDataSet(where, orderBy);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow drow = dsProducts.Tables[0].NewRow();
                    drow["ID"] = dr["ProductID"];
                    drow["Name"] = dr["Name"];
                    drow["Description"] = dr["Description"];
                    drow["Category"] = dr["Category"];//GetCateogryNameFromSubCategory(Int32.Parse(dr["productsubcategoryid"].ToString()));
                    drow["Price"] =  dr["ListPrice"];
                    drow["Cost"] =  dr["StandardCost"];
                    if (dr["PrimaryVendorId"] != DBNull.Value)
                        drow["Primary Vendor"] = dr["PrimaryVendor"];//GetVendorName(Int32.Parse(dr["PrimaryVendorId"].ToString()));
                    else
                        drow["Primary Vendor"] = "";
                    if (dr["SecondaryVendorId"] != DBNull.Value)
                        drow["Sec. Vendor"] = dr["SecondaryVendor"];//GetVendorName(Int32.Parse(dr["SecondaryVendorId"].ToString()));
                    else
                        drow["Sec. Vendor"] = "";
                    drow["Active"] = dr["ActiveFlag"];
                    drow["Comments"] = dr["Comments"];
                    drow["Sub Category"] = dr["SubCategory"]; //GetSubCategoryName(Int32.Parse(dr["ProductSubCategoryId"].ToString()));
                    drow["SafetyStockLevel"] = dr["SafetyStockLevel"];
                    drow["Quantity"] = dr["Quantity"];
                    drow["ReorderPoint"] = dr["ReorderPoint"];
                    drow["DaysToManufacture"] = dr["DaysToManufacture"];
                    drow["ProductNumber"] = dr["ProductNumber"];

                    dsProducts.Tables[0].Rows.Add(drow);
                }
                
                int i = 0;
                if (selectedID > 0)
                {
                    foreach (DataRow dr in dsProducts.Tables[0].Rows)
                    {
                        if (selectedID == Int32.Parse(dr["ID"].ToString()))
                        {
                            if (i != 0)
                                ProductGrid.Rows[0].Selected = false;
                            ProductGrid.Rows[i].Selected = true;
                            ProductGrid.FirstDisplayedScrollingRowIndex = i;
                            GridRowChanged(i);
                            break;
                        }
                        i++;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                p = null;
                ds = null;
                Cursor.Current = Cursors.Default;
            }
        }
        private void PopulateSpecialOfferGrid(int productID)
        {
            SpecialOfferProduct sop = new SpecialOfferProduct();
            SpecialOffer so = new SpecialOffer();
            
            try
            {
                SetupSpecialOfferGrid();
                string where = string.Format("startDate <= getdate() and endDate >= getdate() and exists(select 1 from SpecialOfferProduct where specialofferid=SpecialOffer.specialofferid and productID={0})", productID);
                string orderBy = "enddate";
                SpecialOfferCollection soc = so.GetSpecialOffersCollection(where, orderBy);
                DataTable dt = new DataTable();
                foreach (SpecialOffer s in soc)
                {
                    DataRow dr = dsSpeicalOffer.Tables[0].NewRow();
                    dr[0] = s.Description;
                    dr[1] = s.DiscountPct;
                    dsSpeicalOffer.Tables[0].Rows.Add(dr);
                }
            
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. Failed to load Speical Offers for this product");
                MessageBox.Show(ex.ToString());
            }
        }
        private string GetCateogryNameFromSubCategory(int SubCatId)
        {
            string ret = "";
            ProductCategory cat = new ProductCategory();
            ret = cat.GetCategoryNameBySubCategory(SubCatId);
            return ret;
        }
        private string GetVendorName(int VendorId)
        {
            string ret = "";
            VendorCollection vend = (VendorCollection)cmbPrimaryVendor.DataSource;
            foreach (Vendor v in vend)
            {
                if (v.VendorID == VendorId)
                {
                    ret = v.Name;
                }
            }
           // DataSet dt = (DataSet)cmbPrimaryVendor.DataSource;
            //for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            //{
            //    if (VendorId == Int32.Parse(dt.Tables[0].Rows[i]["VendorId"].ToString()))
            //    {
            //        ret = dt.Tables[0].Rows[i]["Name"].ToString();
            //    }
            //}
            return ret;
        }
        private string GetSubCategoryName(int SubCatId)
        {
            string ret = "";


            return ret;
        }
        #region comment
        //private void PopulateGrid()
        //{
        //    Product p = new Product();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = p.GetAllProductsDataSet();
        //        ProductGrid.DataSource = ds.Tables[0];
        //        //vendorGrid.Columns.Remove("Fax");
        //        ProductGrid.Columns.Remove("MakeFlag");
        //        ProductGrid.Columns.Remove("FinishedGoodsFlag");
        //        ProductGrid.Columns.Remove("Color");
        //        ProductGrid.Columns.Remove("Size");
        //        ProductGrid.Columns.Remove("SizeUnitMeasureCode");
        //        ProductGrid.Columns.Remove("WeightUnitMeasureCode");
        //        ProductGrid.Columns.Remove("Weight");
        //        ProductGrid.Columns.Remove("Class");
        //        ProductGrid.Columns.Remove("Style");
        //        ProductGrid.Columns.Remove("ProductModelID");
        //        ProductGrid.Columns["ProductID"].Visible=false;
        //        //ProductGrid.Columns.Remove("");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        p = null;
        //        ds = null;
        //    }
        //}
        #endregion
        private void SaveProduct()
        {
            if (lblProductID.Text == String.Empty)
            {
                AddProduct();
            }
            else
            {
                UpdateProduct();
            }
        }
        private Product SetProduct()
        {
            Product p = new Product();
            
            try
            {
                p.Class = String.Empty;
                p.Color = String.Empty;
                p.DaysToManufacture = 0;
                p.Description = txtDescription.Text.Trim();
                p.DiscontinuedDate = DateTime.Parse("01/01/1970");
                p.FinishedGoodsFlag = false;
                p.ListPrice = Decimal.Parse(txtListPrice.Text.Trim());
                p.MakeFlag = false;
                p.ModifiedDate = DateTime.Now;
                p.Name = txtName.Text.Trim();
                p.ProductLine = String.Empty;
                p.ProductModelID = 0;
                p.ProductNumber = txtProductNumber.Text.Trim();
                p.ProductSubcategoryID = Int32.Parse(cmbProductSubCategories.SelectedValue.ToString());
                if (txtReorderPoint.Text.Trim().Length > 0)
                    p.ReorderPoint = Int16.Parse(txtReorderPoint.Text.Trim());
                else
                    p.ReorderPoint = 0;
                if (txtSafetyStockLevel.Text.Trim().Length > 0)
                    p.SafetyStockLevel = Int16.Parse(txtSafetyStockLevel.Text.Trim());
                else
                    p.SafetyStockLevel = 0;
                p.SellEndDate = DateTime.Parse("01/01/1970");
                p.SellStartDate = DateTime.Parse("01/01/1970");
                p.Size = String.Empty;
                p.SizeUnitMeasureCode = String.Empty;
                p.StandardCost = Decimal.Parse(txtStandardCost.Text.Trim());
                p.Style = String.Empty;
                p.Weight = 0.00M;
                p.WeightUnitMeasureCode = String.Empty;
                if(lblProductID.Text != String.Empty)
                    p.ProductID = Int32.Parse(lblProductID.Text);
                p.PrimaryVendorId = Int32.Parse(cmbPrimaryVendor.SelectedValue.ToString());
                p.SecondaryVendorId = Int32.Parse(cmbSecondaryVendor.SelectedValue.ToString());
                p.ActiveFlag = chkActive.Checked;
                p.Comments = txtComments.Text;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return p;
        }
        private void UpdateProduct()
        {
            Product p = new Product();
            int cur_row = cur_row = ProductGrid.CurrentRow.Index;
            try
            {
                p = SetProduct();
                if (p.UpdateProduct(p))
                {
                    MessageBox.Show("Product Updated", "Product Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateGrid(String.Empty, String.Empty,p.ProductID);
                }
                else
                {
                    MessageBox.Show("Unable to update product", "Product Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Product Update",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                p = null;
               // product = null;
            }
        }
        private void ClearFields()
        {
            lblProductID.Text = String.Empty;
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtProductNumber.Text = String.Empty;
            cmbCategory.SelectedIndex = 0;
            cmbProductSubCategories.SelectedIndex = 0;
            txtListPrice.Text = String.Empty;
            txtStandardCost.Text = String.Empty;
            txtSafetyStockLevel.Text = String.Empty;
            txtReorderPoint.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            txtComments.Text = String.Empty;
            chkActive.Checked = true;
            cmbPrimaryVendor.SelectedIndex = 0;
            cmbSecondaryVendor.SelectedIndex = 0;
            if (dsSpeicalOffer != null)
            {
                dsSpeicalOffer.Tables[0].Rows.Clear();
            }
        
           // txtProductLine.Text = String.Empty;
        }
        private void AddProduct()
        {
            Product p = new Product();
            Product product = new Product();
            ProductInventory pi = new ProductInventory();
            ProductAdjustmentHistory pah = new ProductAdjustmentHistory();
            
            try
            {
                p = SetProduct();
                
                //pi.ProductID = p.ProductID;
                string qty = txtQuantity.Text.Trim() == string.Empty?"0" : txtQuantity.Text.Trim();
                pi.Quantity = Int32.Parse(qty);
                pi.ModifiedDate = DateTime.Now;
                pi.Shelf = "2";
                pi.LocationID = 1;
                pi.Bin = 1;
                p.ProductInventory = pi;
                int productid = p.Exists(p.Name,p.Description); 
                if (productid > 0 )
                {
                    DialogResult result = MessageBox.Show("The product " + p.Name + " already exists\nWould you like to update it?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        p.ProductID = productid;
                        p.UpdateProduct(p);
                        PopulateGrid(String.Empty, String.Empty, p.ProductID);
                        MessageBox.Show("Record updated successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record is not saved", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return;
                }
                p.ProductID = product.AddProduct(p);
                if (p.ProductID > 0)
                {
                    
                    MessageBox.Show("Product Added");
                    PopulateGrid(String.Empty, String.Empty,p.ProductID);
                }
                else
                {
                    MessageBox.Show("Unable to add product");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                p = null;
            }

           // PopulateGrid(String.Empty, String.Empty,p.ProductID);
        }

       

        private void DeleteProduct()
        {
            int productID = Int32.Parse(lblProductID.Text);
            int cur_row = ProductGrid.CurrentRow.Index;
            //productID = Int32.Parse(ProductGrid.Rows[cur_row].Cells["ID"].ToString());

            int last_row = ProductGrid.Rows.Count;
            if (cur_row == last_row)
                cur_row = 0;
            Product p = new Product();
            try
            {
                if (p.RemoveProduct(productID))
                {
                    MessageBox.Show("Product Deleted");
                    PopulateGrid(String.Empty, String.Empty, cur_row);
                   // Search(0);
                    if (cur_row != 0)
                    {
                        ProductGrid.Rows[0].Selected = false;
                        ProductGrid.Rows[cur_row].Selected = true;
                    }    
                    ProductGrid.FirstDisplayedScrollingRowIndex = cur_row;
                    GridRowChanged(cur_row);
                }
                else
                {
                    MessageBox.Show("Unable to delete product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                p = null;
            }
        }

        private void ProductGrid_MouseClick(object sender, MouseEventArgs e)
        {
            GridRowChanged(-1);
        }

        private void GridRowChanged(int rowindex)
        {
            DataGridViewRow row = new DataGridViewRow();
            ProductSubcategory sub = new ProductSubcategory();
            ProductCategory pc = new ProductCategory();
            ProductSubcategory psc = new ProductSubcategory();

            if(rowindex < 0)
                row = ProductGrid.CurrentRow;
            else
                row = ProductGrid.Rows[rowindex];

            if (row == null) return;
            foreach (DataGridViewCell cell in row.Cells)
            {
                int index = 0;
                switch (cell.OwningColumn.Name)
                {
                    case "ID":
                        lblProductID.Text = cell.Value.ToString();
                        break;
                    case "Description":
                        txtDescription.Text = cell.Value.ToString();
                        break;
                    case "Name":
                        txtName.Text = cell.Value.ToString();
                        break;
                    case "ProductNumber":
                        txtProductNumber.Text = cell.Value.ToString();
                        break;
                    case "SafetyStockLevel":
                        txtSafetyStockLevel.Text = cell.Value.ToString();
                        break;
                    case "Price":
                        txtListPrice.Text = String.Format("{0:##.00}", cell.Value);
                        break;
                  //  case "DaysToManufacture":
                      //  txtDaysToManufacture.Text = cell.Value.ToString();
                   //     break;
                    case "Cost":
                        txtStandardCost.Text = String.Format("{0:##.00}", cell.Value);
                        break;
                    case "Quantity":
                        txtQuantity.Text = cell.Value.ToString();
                        break;
                    case "ReorderPoint":
                        txtReorderPoint.Text = cell.Value.ToString();
                        break;
                    case "ProductSubcategoryID":
                        int subCatID = Int32.Parse(cell.Value.ToString());

                        sub = psc.GetProductSubcategory(subCatID);
                        int productCategoryID = Int32.Parse(sub.ProductCategoryID.ToString());
                        string catName = pc.GetProductCategory(productCategoryID).Name;
                        int catIndex = cmbCategory.FindStringExact(catName);

                        cmbCategory.SelectedIndex = catIndex;
                        LoadProductSubCategories(productCategoryID);
                        int subIndex = cmbProductSubCategories.FindStringExact(sub.Name);
                        cmbProductSubCategories.SelectedIndex = subIndex;

                        break;
                    case "Active":
                        if (cell.Value != DBNull.Value)
                            chkActive.Checked = Boolean.Parse(cell.Value.ToString());
                        else
                            chkActive.Checked = false;
                        break;
                    case "Category":
                        index = cmbCategory.FindString(cell.Value.ToString());
                        cmbCategory.SelectedIndex = index;
                        break;
                    case "Sub Category":
                        index = cmbProductSubCategories.FindString(cell.Value.ToString());
                        cmbProductSubCategories.SelectedIndex = index;
                        break;
                    case "Primary Vendor":
                        index = cmbPrimaryVendor.FindString(cell.Value.ToString());
                        cmbPrimaryVendor.SelectedIndex = index;
                        break;
                    case "Sec. Vendor":
                        index = cmbSecondaryVendor.FindString(cell.Value.ToString());
                        cmbSecondaryVendor.SelectedIndex = index;
                        break;
                    case "Comments":
                        if (cell.Value != DBNull.Value)
                            txtComments.Text = cell.Value.ToString();
                        else
                            txtComments.Text = "";
                        break;

                    //case "SellStartDate":
                    //    dtSellingStartsDate.Value = DateTime.Parse(cell.Value.ToString());
                    //    break;
                    //case "SellEndDate":
                    //    dtSellingEndsDate.Value = DateTime.Parse(cell.Value.ToString());
                    //    break;
                    //case "DiscontinuedDate":
                    //    dtDiscontinuedDate.Value = DateTime.Parse(cell.Value.ToString());
                    //    break;
                }
            }
            int pid = string.IsNullOrEmpty(lblProductID.Text) ? 0 : Convert.ToInt32(lblProductID.Text);
            PopulateSpecialOfferGrid(pid);
            
        }
        private void New_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        

        private void Delete()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the record", "Product Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteProduct();
            }
        }

       
        private void Search()
        {
            ProductSubcategory sub = new ProductSubcategory();
            ProductSubcategory psc = new ProductSubcategory();
            StringBuilder sb = new StringBuilder();
            if (txtDescription.Text.Trim() != String.Empty)
            {
                if (sb.Length > 0)
                    sb.Append(" and description like '" + txtDescription.Text.Trim() + "%'");
                else
                    sb.Append(" description like '" + txtDescription.Text.Trim() + "%'");
            }
            if (txtProductNumber.Text.Trim() != String.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" AND [ProductNumber]='" + txtProductNumber.Text.Trim() + "'");
                }
                else
                {
                    sb.Append("[ProductNumber]='" + txtProductNumber.Text.Trim() + "'");
                }
            }
            if (cmbProductSubCategories.SelectedIndex > 0)
            {
                int subCatID = Int32.Parse(cmbProductSubCategories.SelectedValue.ToString());
                if (sb.Length > 0)
                {
                    sb.Append(" AND [ProductSubcategoryID]=" + subCatID);
                }
                else
                {
                    sb.Append("[ProductSubcategoryID]=" + subCatID);
                }
                
                
            }
            if (cmbCategory.SelectedIndex > 0)
            {
                int CatId = Int32.Parse(cmbCategory.SelectedValue.ToString());
                if (sb.Length > 0)
                {
                    sb.Append(" AND ProductSubcategoryID in (select productsubcategoryid from productcategory where productcategoryid=" + CatId.ToString() + ")"); 
                }
                else
                {
                    sb.Append(" ProductSubcategoryID in (select productsubcategoryid from productsubcategory where productcategoryid=" + CatId.ToString() + ")"); 
                }

            }
            if (cmbPrimaryVendor.SelectedIndex > 0)
            {
                string pVend = cmbPrimaryVendor.SelectedValue.ToString();
                if (sb.Length > 0)
                    sb.Append(" and primaryvendorid in (select vendorid from vendor where vendorid=" + pVend + ")");
                else
                    sb.Append(" primaryvendorid in (select vendorid from vendor where vendorid=" + pVend + ")");
            }
            if (cmbSecondaryVendor.SelectedIndex > 0)
            {
                string sVend = cmbSecondaryVendor.SelectedValue.ToString();
                if (sb.Length > 0)
                    sb.Append(" and secondaryvendorid in (select vendorid from vendor where vendorid=" + sVend + ")");
                else
                    sb.Append(" secondaryvendorid in (select vendorid from vendor where vendorid=" + sVend + ")");
            }
            if (chkActive.Checked)
            {
                if (sb.Length > 0)
                    sb.Append(" and p.activeFlag=1");
                else
                    sb.Append("p.activeFlag=1");
            }
            else
            {
                if (sb.Length > 0)
                    sb.Append(" and p.activeFlag=0");
                else
                    sb.Append("p.activeFlag=0");
            }
            if (txtName.Text.Trim() != String.Empty)
            {
                sb.Append(" and p.name like '" + txtName.Text.Trim()+"%'");
            }
            if (sb.Length > 0)
            {
                PopulateGrid(sb.ToString(), "p.Name", 0);
            }
            else
            {
                PopulateGrid(String.Empty, String.Empty, 0);
            }
            

        }
        

        private void Save()
        {
            if (ValidateForm())
            {
                SaveProduct();
            }
        }

        private void frmProducts_Activated(object sender, EventArgs e)
        {
           // PopulateGrid(String.Empty, String.Empty);
        }
       
        private bool ValidateForm()
        {
            ValidateEmpty(txtName) ;
            //ValidateEmpty(txtProductNumber) ;
            ValidateComoBox(cmbCategory) ;
            ValidateComoBox(cmbProductSubCategories) ;
            ValidateEmpty(txtStandardCost) ;
            ValidateEmpty(txtListPrice);
            ValidateDecimal(txtListPrice);
            ValidateDecimal(txtStandardCost);
            
            if (ValidateEmpty(txtName) && 
                ValidateComoBox(cmbCategory) &&
                ValidateComoBox(cmbProductSubCategories) &&
                ValidateEmpty(txtStandardCost) &&
                ValidateEmpty(txtListPrice) &&
                ValidateDecimal(txtStandardCost) &&
                ValidateDecimal(txtListPrice))
                return true;
            return false;
        }

        private void frmProducts_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void picAddCategory_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.ShowDialog();
            int categoryid = 0;
            string categoryName = cmbCategory.Text;
            if (cmbCategory.SelectedIndex > 0)
            {
                categoryid = Int32.Parse(cmbCategory.SelectedValue.ToString());
                
            }
            LoadProductCategories(categoryName, categoryid);
            
        }

        private void picSubCategories_Click(object sender, EventArgs e)
        {
            frmSubCategories frm = new frmSubCategories();
            frm.ShowDialog();
            int categoryid = 0;
            string categoryName = cmbCategory.Text;
            if (cmbCategory.SelectedIndex > 0)
            {
                categoryid = Int32.Parse(cmbCategory.SelectedValue.ToString());

            }
            LoadProductCategories(categoryName, categoryid);
        }

        private void btnFNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnFSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnFDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnFSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ProductGrid_SelectionChanged(object sender, EventArgs e)
        {
            GridRowChanged(-1);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void lblProductID_TextChanged(object sender, EventArgs e)
        {
            if (lblProductID.Text == string.Empty)
            {
                txtQuantity.Enabled = true;
            }
            else
            {
                txtQuantity.Enabled = false;
            }
            txtQuantity.Text = "";
        }

        
       
    }
}