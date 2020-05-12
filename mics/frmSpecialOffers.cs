using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using MICS.Reports;

namespace MICS
{
    public partial class frmSpecialOffers : frmParent
    {
        private int m_SpecialOfferID = 0;
        DataTable dtProducts;
        public frmSpecialOffers()
        {
            InitializeComponent();
        }

        private void brnSearchProducts_Click(object sender, EventArgs e)
        {
            string where = "activeflag=1 and description like '" + txtProductName.Text + "%'";
            if (cmbProductCategory.Items.Count > 0 && cmbProductCategory.SelectedIndex > 0)
            {
                where += " and ProductSubCategoryID in (select ProductSubCategoryID from ProductSubCategory where ProductCategoryID=" + cmbProductCategory.SelectedValue.ToString() + ")";
            }
            string OrderBy = "Name";
            Product p = new Product();
            try
            {
                DataSet ds = p.GetProductsDataSet(where, OrderBy);
                PopulateProductGrid(ds,false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                p = null;
            }

            
        }
        private void PopulateProductGrid(DataSet ds,bool CheckIt)
        {
            dtProducts = new DataTable();
            dtProducts.Columns.Add(new DataColumn("Check", typeof(bool)));
            dtProducts.Columns.Add(new DataColumn("ID",typeof(Int32)));
            dtProducts.Columns.Add(new DataColumn("Product",typeof(String)));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow row = dtProducts.NewRow();
                row["Check"] = CheckIt;
                row["ID"] = Int32.Parse(dr["ProductID"].ToString());
                row["Product"] = dr["Description"].ToString();
                dtProducts.Rows.Add(row);
            }
            grdProducts.DataSource = dtProducts;
            grdProducts.Columns["ID"].Visible = false;
            grdProducts.Columns[0].Width = 50;
            //grdProducts.Columns[1].Width = 60;
            grdProducts.Columns[2].Width = 300;
            
        }
        private void PopulateGrids()
        {
            //special offer
            SpecialOffer so = new SpecialOffer();
            try
            {
                DataSet ds = new DataSet();
                ds = so.GetAllSpecialOffersDataSet();
                dgSpecialOffers.DataSource = ds.Tables[0];
                dgSpecialOffers.Columns["specialofferid"].HeaderText = "ID";
                dgSpecialOffers.Columns["specialofferid"].Width = 60;
                dgSpecialOffers.Columns["description"].Width = 250;
                dgSpecialOffers.Columns["type"].Width = 40;
                dgSpecialOffers.Columns["startdate"].Width = 150;
                dgSpecialOffers.Columns["enddate"].Width = 150;
                dgSpecialOffers.Columns["startdate"].HeaderText = "Start Date/Time";
                dgSpecialOffers.Columns["enddate"].HeaderText = "End Date/Time";
                dgSpecialOffers.Columns["MinQty"].Width = 70;
                dgSpecialOffers.Columns["MaxQty"].Width = 70;
                dgSpecialOffers.Columns["modifieddate"].Visible = false;
                
                //dgSpecialOffers.Columns[
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                so = null;
            }
        }

        private void frmSpecialOffers_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();
            PopulateGrids();
            dtStartDate.Value = DateTime.Today;
            dtEndDate.Value = DateTime.Today;
        }
        private void PopulateComboBoxes()
        {
            
            ProductCategory cat = new ProductCategory();
            try
            {
                //Product category
                DataSet ds = cat.GetAllProductCategoryDataSet();
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["ProductCategoryID"] = 0;
                dr["Name"] = "<Select One>";
                dt.Rows.InsertAt(dr, 0);
                cmbProductCategory.DataSource = dt;
                cmbProductCategory.DisplayMember = "Name";
                cmbProductCategory.ValueMember = "ProductCategoryID";

                //Discount type (P: percentage, V:value)
                string[,] strDiscArray = { {"0","<Select One>"},{ "P", "Percentage"}, {"V", "Value"} };
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("ID", typeof(String)));
                dt.Columns.Add(new DataColumn("Desc", typeof(String)));
                for (int i = 0; i <= strDiscArray.Length/3; i++)
                {
                    dr = dt.NewRow();
                    dr["ID"] = strDiscArray[i,0];
                    dr["Desc"] = strDiscArray[i,1];
                    dt.Rows.Add(dr);
                }
                cmbDiscountType.DataSource = dt;
                cmbDiscountType.DisplayMember = "Desc";
                cmbDiscountType.ValueMember = "ID";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cat = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
            SpecialOffer so = new SpecialOffer();
            SpecialOfferProduct sp = new SpecialOfferProduct();
            try
            {
                so.Description = txtDescription.Text;
                so.SpecialOfferID = m_SpecialOfferID;
                so.Type = cmbDiscountType.SelectedValue.ToString();
                so.DiscountPct = decimal.Parse(txtDiscount.Text);
                so.StartDate = DateTime.Parse(dtStartDate.Value.ToShortDateString() + " 06:00:00 AM");
                so.EndDate = DateTime.Parse(dtEndDate.Value.ToShortDateString() + " 06:00:00 AM");
                if(txtMinQuantity.Text.Trim() != String.Empty)
                    so.MinQty = Int32.Parse(txtMinQuantity.Text);
                if(txtMaxQuantity.Text.Trim() != String.Empty)
                    so.MaxQty = Int32.Parse(txtMaxQuantity.Text);
                so.Category = "";
                if (so.SpecialOfferID == 0)
                {
                    //new record
                    so.SpecialOfferID = so.AddSpecialOffer(so);
                    //If there are selected products add them to specialofferproduct table
                    //First delete, then insert.
                    sp.RemoveSpecialOfferProduct(so.SpecialOfferID);
                    foreach (DataGridViewRow row in grdProducts.Rows)
                    {
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            sp.ProductID = Int32.Parse(row.Cells[1].Value.ToString());
                            sp.SpecialOfferID = so.SpecialOfferID;
                            sp.AddSpecialOfferProduct(sp);
                        }
                    }


                }
                else
                {
                    //exsiting record.
                    so.UpdateSpecialOffer(so);
                    sp.RemoveSpecialOfferProduct(so.SpecialOfferID);
                    foreach (DataGridViewRow row in grdProducts.Rows)
                    {
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            sp.ProductID = Int32.Parse(row.Cells[1].Value.ToString());
                            sp.SpecialOfferID = so.SpecialOfferID;
                            sp.AddSpecialOfferProduct(sp);
                        }
                    }
                }
                MessageBox.Show("Record saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                so = null;
                sp = null;
            }

        }
        private bool ValidateFields()
        {
            bool ret=true;
            if(!ValidateEmpty(txtDescription) ||
               !ValidateDecimal(txtDiscount) ||
               !ValidateComoBox(cmbDiscountType))
            {
                ret=false;
            }
             return ret;

        }
        private void PopulateSpecialOffer(int specialofferid)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgSpecialOffers.CurrentRow;
            if (row == null) return;
            ClearFields();
            try
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    switch (cell.OwningColumn.Name)
                    {
                        case "SpecialOfferID":
                            m_SpecialOfferID = Int32.Parse(cell.Value.ToString());
                            break;
                        case "Description":
                            txtDescription.Text = cell.Value.ToString();
                            break;
                        case "DiscountPct":
                            txtDiscount.Text = cell.Value.ToString();
                            break;
                        case "Type":
                            int index = cmbDiscountType.FindString(cell.Value.ToString());
                            cmbDiscountType.SelectedIndex = index;
                            break;
                        case "StartDate":
                            if (cell.Value != null & cell.Value.ToString() != "")
                            {
                                dtStartDate.Value = DateTime.Parse(cell.Value.ToString());
                            }
                            break;
                        case "EndDate":
                            if (cell.Value != null & cell.Value.ToString() != "")
                            {
                                dtEndDate.Value = DateTime.Parse(cell.Value.ToString());
                            }
                            break;
                        case "MinQty":
                            txtMinQuantity.Text = cell.Value.ToString();
                            break;
                        case "MaxQty":
                            txtMaxQuantity.Text = cell.Value.ToString();
                            break;
                    }
                }
                //Get special offer products
                if (m_SpecialOfferID != 0)
                {
                    SpecialOfferProduct sop = new SpecialOfferProduct();
                    Product p = new Product();
                    string where = " SpecialOfferID=" + m_SpecialOfferID.ToString();
                    string OrderBy = " ProductID";
                    DataSet ds = new DataSet();
                    ds = sop.GetSpecialOfferProductsDataSet(where, OrderBy);
                    int count = ds.Tables[0].Rows.Count;
                    string[] ProdutIdArray = new string[count];
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProdutIdArray[i++] = dr["ProductID"].ToString();
                    }
                    where = "ProductId in (";
                    for (i = 0; i < count; i++)
                    {
                        where += ProdutIdArray[i].ToString() + ",";
                    }
                    where += "0)";
                    OrderBy = "p.Description";
                    ds = p.GetProductsDataSet(where, OrderBy);
                    PopulateProductGrid(ds, true);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }
        private void dgSpecialOffers_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateSpecialOffer(-1);
        }
        private void ClearFields()
        {
            foreach (Control ctrl in groupData.Controls)
            {
                if (ctrl.Name.StartsWith("txt"))
                {
                    ctrl.Text = "";
                }
            }
            foreach (Control ctrl in groupProducts.Controls)
            {
                if (ctrl.Name.StartsWith("txt"))
                {
                    ctrl.Text = "";
                }
            }
            m_SpecialOfferID = 0;
            cmbDiscountType.SelectedIndex = 0;
            cmbProductCategory.SelectedIndex = 0;
            grdProducts.DataSource = null;
            dtStartDate.Value = DateTime.Today;
            dtEndDate.Value = DateTime.Today;
            //grdProducts.Rows.Clear();
            
        }
        private void RefreshForm()
        {
            PopulateGrids();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //RefreshForm();
            ClearFields();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                if (dtProducts != null)
                {
                    foreach (DataRow dRow in dtProducts.Rows)
                    {
                        dRow["Check"] = true;
                    }
                }
            }
            else
            {
                if (dtProducts != null)
                {
                    foreach (DataRow dRow in dtProducts.Rows)
                    {
                        dRow["Check"] = false;
                    }
                }
            }
        }

        private void dgSpecialOffers_SelectionChanged(object sender, EventArgs e)
        {
            PopulateSpecialOffer(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MICS.Reports.SpecialOfferItems soi = new SpecialOfferItems();
           // int cur_row = dgSpecialOffers.CurrentRow.Index;
            soi.SpecialOfferID = m_SpecialOfferID;
            soi.Show();
            
        }
    }
}