using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using MICS.Utilities;
using System.Globalization;

namespace MICS
{
    public partial class frmPurchaseOrder : frmParent
    {
        private bool isDirty = false;
        LogWriter log = new LogWriter();
        DataTable dtBindableTable = new DataTable();
        DataTable dtPendingOrders = new DataTable();
        DataTable dtInvoiceHeader = new DataTable();
        
        public frmPurchaseOrder()
        {
            InitializeComponent();
            InitializePurchaseOrderTable();
        }
        #region POPULATE METHODS
        private void ShowPendingOrders()
        {
            Cursor.Current = Cursors.WaitCursor;
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT [PurchaseOrderHeader].[PurchaseOrderID],";
            sql += "[PurchaseOrderHeader].[RevisionNumber] as 'Order No',[OrderStatus].[Name] as 'Status',";
            sql += "(rtrim([Employee].[FirstName]) + ' ' + rtrim([Employee].[MiddleName])+' '+rtrim([Employee].[LastName])) as 'Sales Person',";
            sql += "[Vendor].[Name] as 'Vendor Name',[PurchaseOrderHeader].[OrderDate],[PurchaseOrderHeader].[ShipDate],";
            sql += "[PurchaseOrderHeader].[TotalDue]";
            sql += " FROM ";
            sql += " [dbo].[PurchaseOrderHeader],[dbo].[SalesPerson],[dbo].[Employee],[dbo].[Vendor], [dbo].[OrderStatus]";
            sql += " WHERE ";
            sql += "[OrderStatus].[ID] = [PurchaseOrderHeader].[Status] and ";
            sql += "[PurchaseOrderHeader].[EmployeeID] = [SalesPerson].[SalesPersonID] and ";
            sql += "[PurchaseOrderHeader].[VendorID] = [Vendor].[VendorID] and ";
            sql += "[Employee].[EmployeeID] = [SalesPerson].[SalesPersonID] And [PurchaseOrderHeader].[Status]= 1";
            // sql += " [PurchaseOrderID] = @PurchaseOrderID ";
            
            try
            {
                ds = gq.GetDataSet(false, sql);
                dgPendingOrdersHeaders.DataSource = ds.Tables[0];
              
                dgPendingOrdersHeaders.Columns["PurchaseOrderID"].Visible = false;
                dgPendingOrdersHeaders.Cursor = Cursors.Hand;
                //txtSOOrderNumber
                this.tcPurchaseOrder.SelectedTab= tpSearchOrder; //search

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Purchase Order",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                gq = null;
                Cursor.Current = Cursors.Default;
            }
        }
        #region Utitilities
        private bool UpdateQuantityIfExist(DataRow row)
        {
            try
            {
                foreach (DataRow dr in dtBindableTable.Rows)
                {
                    if (Int32.Parse(dr["ProductID"].ToString()) == Int32.Parse(row["ProductID"].ToString()))
                    {
                        dr["Quantity"] = Int32.Parse(dr["Quantity"].ToString()) + Int32.Parse(row["Quantity"].ToString());
                        dr["Total"] = Decimal.Parse(dr["Total"].ToString()) + Decimal.Parse(row["Total"].ToString());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void InitializePurchaseOrderTable()
        {

            dtBindableTable.Columns.Add("PRODUCTID");
            dtBindableTable.Columns["PRODUCTID"].ReadOnly = true;

            dtBindableTable.Columns.Add("NAME");
            dtBindableTable.Columns["NAME"].ReadOnly = true;

            dtBindableTable.Columns.Add("PRODUCT_CODE");
            dtBindableTable.Columns["PRODUCT_CODE"].ReadOnly = true;

            dtBindableTable.Columns.Add("REORDERPOINT");
            dtBindableTable.Columns["REORDERPOINT"].ReadOnly = true;

            dtBindableTable.Columns.Add("INSTOCK");
            dtBindableTable.Columns["INSTOCK"].ReadOnly = true;

            dtBindableTable.Columns.Add("PRICE");
            dtBindableTable.Columns["PRICE"].DefaultValue = 0.00m;
            dtBindableTable.Columns["PRICE"].DataType = System.Type.GetType("System.Decimal");


            //dtBindableTable.Columns.Add("No Cases");
            //dtBindableTable.Columns["No Cases"].DataType = System.Type.GetType("System.Int32");
            //dtBindableTable.Columns.Add("Unit/Case");
            //dtBindableTable.Columns["Unit/Case"].DataType = System.Type.GetType("System.Int32");


            dtBindableTable.Columns.Add("Quantity");
            dtBindableTable.Columns["Quantity"].DataType = System.Type.GetType("System.Int32");
            dtBindableTable.Columns.Add("Total");
            dtBindableTable.Columns["Total"].DataType = System.Type.GetType("System.Decimal");

        }
        private void SelectProducts()
        {
            int vendorid = 0;
            if (cmbVendor.SelectedValue != null)
            {
                vendorid = Int32.Parse(cmbVendor.SelectedValue.ToString());
            }
            frmProductPicker pick = new frmProductPicker(OrderType.PurchaseOrder,vendorid);
            DataTable dt = new DataTable();
            dt = pick.GetSelectedProducts();
           
            decimal m_OrderTotal = 0;
            // dt.Columns.Remove("No Cases");
            //dt.Columns.Remove("Unit/Case");

            pick.Close();
            if (dt == null) return;
            if (dt.Rows.Count < 1) return;
            DataTable newtable = dt.Clone();
            DataRow[] selectRows =  dt.Select("total <> 0");
           // newtable.Select("total <> 0");
            
            for (int i = 0; i < selectRows.Length; i++)
            {
                newtable.ImportRow(selectRows[i]);
            }
            foreach (DataRow dr in newtable.Rows)
            {
                int qty = 0;
                try
                {
                    qty = Int32.Parse(dr["Quantity"].ToString());
                }
                catch { continue; }
                if (qty > 0)
                {
                    if (!(dr["Total"] is DBNull))
                        m_OrderTotal += Decimal.Parse(dr["Total"].ToString());
                    if (UpdateQuantityIfExist(dr))
                    {
                        continue;
                    }

                    DataRow row = dtBindableTable.NewRow();

                    if (newtable.Columns["No Cases"] != null)
                    {
                        newtable.Columns.Remove("No Cases");
                        newtable.Columns.Remove("Unit/Case");
                    }
                   // DataTable dummy = newtable.Clone();
                    for (int i = 0; i < newtable.Rows.Count; i++)
                    {
                        dtBindableTable.ImportRow(newtable.Rows[i]);
                    }
                    //for (int i = 0; i < newtable.Columns.Count; i++)
                    //{
                    //    //  if (dt.Columns[i].ColumnName == "No Cases" || dt.Columns[i].ColumnName == "Unit/Case") continue;
                    //    row[i] = dr[i];

                    //}
                    //dtBindableTable.Rows.Add(row);
                    isDirty = true;
                }

            }
            productGrid.DataSource = dtBindableTable;
            productGrid.Columns["ProductID"].Visible = false;
            productGrid.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productGrid.Columns["PRICE"].DefaultCellStyle.Format = "c";
            productGrid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productGrid.Columns["Total"].DefaultCellStyle.Format = "c";
            productGrid.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GetTotal(productGrid);

            txtTotal.Text = String.Format("{0:c}", CalcualteTotal(productGrid));


        }
        private void SelectProducts(DataGridView dgv, TextBox totalTextBox)
        {
            int vendorid = 0;
            if (cmbVendor.SelectedValue != null)
                vendorid = Int32.Parse(cmbVendor.SelectedValue.ToString());
            frmProductPicker pick = new frmProductPicker(OrderType.PurchaseOrder,vendorid);
            DataTable dt = new DataTable();
            decimal m_OrderTotal = 0;
            dt = pick.GetSelectedProducts();
           
            
           
            pick.Close();
           
            if (dt == null) return;
            if (dt.Rows.Count < 1) return;
            dt.Columns.Remove("No Cases");
            dt.Columns.Remove("Unit/Case");
            DataTable newtable = dt.Clone();
            DataRow[] selectedRows = dt.Select("total <> 0");
            for (int i = 0; i < selectedRows.Length; i++)
            {
                newtable.ImportRow(selectedRows[i]);
            }
            foreach (DataRow dr in newtable.Rows)
            {
                int qty = 0;
                try
                {
                    qty = Int32.Parse(dr["Quantity"].ToString());
                }
                catch { continue; }
                if (!(dr["Quantity"] is DBNull) && Int32.Parse(dr["Quantity"].ToString()) > 0)
                {
                    if (!(dr["Total"] is DBNull))
                        m_OrderTotal += Decimal.Parse(dr["Total"].ToString());
                    if (UpdateQuantityIfExist(dr))
                    {
                        continue;
                    }

                    DataRow row = dtBindableTable.NewRow();
                    row["productid"] = dr["productid"];
                    row["Name"] = dr["Name"];
                    row["ReorderPoint"] = dr["ReorderPoint"];
                    row["Quantity"] = qty;// dr["Quantity"];
                    row["INSTOCK"] = dr["INSTOCK"];
                    row["PRODUCT_CODE"] = dr["PRODUCT_CODE"];
                    row["PRICE"] = dr["PRICE"];
                    row["Total"] = dr["total"];

                    dtBindableTable.Rows.Add(row);
                    isDirty = true;
                }

                totalTextBox.Text = String.Format("{0:c}", m_OrderTotal);
            }
            //dtPendingOrders
            dgv.DataSource = dtBindableTable;
            dgv.Columns["ProductID"].Visible = false;
            dgv.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["PRICE"].DefaultCellStyle.Format = "c";
            dgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Total"].DefaultCellStyle.Format = "c";
            dgv.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            totalTextBox.Text = FormatMoney(CalcualteTotal(dgv));
        }
        #endregion
        #region Load
        private void PopulateVendor()
        {
            Cursor.Current = Cursors.WaitCursor;
            PopulateVendor(cmbVendor);
            PopulateVendor(cmbSOVendor);
            PopulateVendor(cmbInvoiceVendor);
            #region MyRegion
            //Vendor v = new Vendor();
            //Vendor vNew = new Vendor();
            //VendorCollection vc = new VendorCollection();
            //try
            //{
            //    vNew.Name = "[Select One]";
            //    vNew.VendorID = 0;
            //    vc = v.GetAllVendorsCollection();
            //    vc.Insert(0, vNew);
            //    cmbVendor.DataSource = vc;
            //    cmbVendor.DisplayMember = "Name";
            //    cmbVendor.ValueMember = "VendorID";

            //    cmbSOVendor.DataSource = vc;
            //    cmbSOVendor.DisplayMember = "Name";
            //    cmbSOVendor.ValueMember = "VendorID";

            //    cmbInvoiceVendor.DataSource = vc;
            //    cmbInvoiceVendor.DisplayMember = "Name";
            //    cmbInvoiceVendor.ValueMember = "VendorID";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Cursor.Current = Cursors.Default;
            //}
            //finally
            //{
            //    v = null;
            //    vc = null;
            //} 
            #endregion
            Cursor.Current = Cursors.Default;
        }
        private void PopulateVendor(ComboBox cmb)
        {
            Cursor.Current = Cursors.WaitCursor;
            Vendor v = new Vendor();
            Vendor vNew = new Vendor();
            VendorCollection vc = new VendorCollection();
            try
            {
                vNew.Name = "[Select One]";
                vNew.VendorID = 0;
                vc = v.GetAllVendorsCollection();
                vc.Insert(0, vNew);
                cmb.DataSource = vc;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "VendorID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                v = null;
                vc = null;
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region Status Comment
        private void PopulateStatus()
        {
            cmbInvoiceStatus.Items.Clear();
           
            List<OrderStatusObject> list = new List<OrderStatusObject>();

            list.Add(new OrderStatusObject(0, "[Select One]"));

            list.Add(new OrderStatusObject(1, "Pending"));
            list.Add(new OrderStatusObject(2, "Received"));
            list.Add(new OrderStatusObject(3, "Rejected"));
            list.Add(new OrderStatusObject(4, "Shipped"));
            list.Add(new OrderStatusObject(5, "Paid"));
            list.Add(new OrderStatusObject(6, "Cancelled"));
            list.Add(new OrderStatusObject(7, "Closed"));

            cmbInvoiceStatus.DataSource = list;
            cmbInvoiceStatus.DisplayMember = "Name";
            cmbInvoiceStatus.ValueMember = "ID";

           

        } 
        #endregion
        private void PopulateEmployees()
        {
            Cursor.Current = Cursors.WaitCursor;
            PopulateEmployees(cmbEmployee);
            PopulateEmployees(cmbSOSalesPerson);
            PopulateEmployees(cmbInvoiceSalesPerson);
            
            Cursor.Current = Cursors.Default;
        }
        private void PopulateEmployees(ComboBox cmb)
        {
            Cursor.Current = Cursors.WaitCursor;
            SalesPerson sp = new SalesPerson();
            SalesPerson newSP = new SalesPerson();
            SalesPersonCollection spc = new SalesPersonCollection();
            try
            {
                spc = sp.GetAllSalesPersonViewCollection();
                newSP.FullName = "[Select One]";
                newSP.SalesPersonID = 0;
                spc.Insert(0, newSP);
                cmb.DataSource = spc;
                cmb.DisplayMember = "FullName";
                cmb.ValueMember = "SalesPersonID";

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                sp = null;
                spc = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void PopulateInvoiceTab(int purchaseOrderID)
        {
            lblInvoicePurchaseOrderID.Text = purchaseOrderID.ToString();

            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
            int invoiceID=0;
            string where = "[purchaseorderid]=" + purchaseOrderID;
            DataSet ds = new DataSet();
            try
            {
                invoiceID=pih.PurchaseInvoiceHeaderExists(purchaseOrderID);
                if (invoiceID >0)
                {
                    pih = pih.GetPurchaseInvoiceHeader(invoiceID);
                    ds = pid.GetPurchaseInvoiceDetailsGridDataSet("[invoiceid]="+invoiceID, String.Empty);

                }
                else
                {
                    poh = poh.GetPurchaseOrderHeader(purchaseOrderID);
                    if (poh != null)
                    {
                        //cmbInvoiceStatus.SelectedValue = poh.Status;
                        cmbInvoiceVendor.SelectedValue = poh.VendorID;
                        cmbSOSalesPerson.SelectedValue = poh.EmployeeID;
                        dtInvoiceDate.Value = poh.OrderDate;

                    }
                    ds = pod.GetPurchaseOrderDetailDataSet(where, String.Empty);

                    ds.Tables[0].Columns.Remove("RejectedQty");
                    ds.Tables[0].Columns.Remove("StockedQty");
                    //ds.Tables[0].Columns.Remove("PurchaseOrderID");
                    ds.Tables[0].Columns.Remove("ModifiedDate");
                    ds.Tables[0].Columns.Remove("DueDate");
                    
                    
                   // ds.Tables[0].Columns.Remove("PurchaseOrderDetailID");
                    ds.Tables[0].Columns.Remove("ReceivedQty");
                    ds.Tables[0].Columns["OrderQty"].ColumnName = "Quantity";
                    ds.Tables[0].Columns["UnitPerCase"].ColumnName = "Unit/Case";
                }
               
               
                
                ds.Tables[0].Columns.Add("Total");
                 
                // grdPendingOrderHeader.Columns["Total"].DefaultCellStyle.Format = "c";
                ds.Tables[0].Columns["UnitPrice"].ColumnName = "Price";
                
                //InvoiceGrid = null;
                
                dgInvoiceDetails.DataSource = ds.Tables[0];
                if (dgInvoiceDetails.Columns["invoiceid"]!=null)   dgInvoiceDetails.Columns["invoiceid"].Visible = false;
                if (dgInvoiceDetails.Columns["invoicedetailid"]!=null) dgInvoiceDetails.Columns["invoicedetailid"].Visible = false;
                if (dgInvoiceDetails.Columns["productid"] != null) dgInvoiceDetails.Columns["productid"].Visible = false;
                if (dgInvoiceDetails.Columns["modifieddate"] != null) dgInvoiceDetails.Columns["modifieddate"].Visible = false;
                if (dgInvoiceDetails.Columns["PurchaseOrderID"] != null) dgInvoiceDetails.Columns["PurchaseOrderID"].Visible = false;

                dgInvoiceDetails.Columns["Price"].DefaultCellStyle.Format = "c";
                dgInvoiceDetails.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgInvoiceDetails.Columns["Total"].DefaultCellStyle.Format = "c";
                dgInvoiceDetails.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgInvoiceDetails.Columns["Quantity"].DefaultCellStyle.Format = "d";
                dgInvoiceDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                poh = null;
                tcPurchaseOrder.SelectedTab = this.tpInvoices;

                // txtTotal.Text =String.Format("{0:c}", m_OrderTotal);
               // GetTotal(InvoiceGrid);
                txtInvoiceTotal.Text = String.Format("{0:c}", CalcualteTotal(dgInvoiceDetails));
            }
        }
        #endregion
        #region EVENTS METHODS
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
        private void ClearNewOrderFields()
        {
            txtRevisionNumber.ReadOnly = false;
            productGrid.DataSource = null;
            txtRevisionNumber.Text = String.Empty;
            txtTotal.Text = String.Empty;
            dtOrderDate.Value = DateTime.Today;
            dtShipmentDate.Value = DateTime.Today;
            cmbVendor.SelectedIndex = 0;
            cmbEmployee.SelectedIndex = 0;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidFields())
            {
                SavePurchaseOrder();
                ClearNewOrderFields();
                isDirty = false;
            }
            else
            {
                MessageBox.Show("Please fill the required field", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            SelectProducts();
        }
        private void txtTotal_Leave(object sender, EventArgs e)
        {
            decimal total = Decimal.Parse(txtTotal.Text);
            txtTotal.Text = String.Format("{0:c}", total);
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            SearchPurchaseOrders();

        }
  
        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
           
            LoadForm();
        }
        public void LoadForm()
        {

            PopulateEmployees();
            PopulateVendor();
            PopulateStatus();
            ShowPendingOrders();
        }
        private void btnInvoiceSave_Click(object sender, EventArgs e)
        {

            SavePurchaseInvoice();
            isDirty = false;
            //int purchaseOrderID = Int32.Parse(lblInvoicePurchaseOrderID.Text );
            //PopulateInvoiceTab(purchaseOrderID);
        }
        private void productGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == productGrid.Columns["Quantity"].Index)
            {
                MessageBox.Show("You must entry a whole number", "Quantity field error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(e.Exception.Message, "Quantity field error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        private void UpdateTotal(int row_index)
        {

            Cursor.Current = Cursors.WaitCursor;
            decimal price = 0.00m;
            int noCase = 0;
            int unitPerCase = 0;
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
                    price = Decimal.Parse(productGrid.Rows[row_index].Cells["PRICE"].Value.ToString());
                    quantity = Int32.Parse(productGrid.Rows[row_index].Cells["Quantity"].Value.ToString());
                    productGrid.Rows[row_index].Cells["Total"].Value = price * quantity;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Product Picker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
            txtTotal.Text = String.Format("{0:c}", GetTotal(productGrid));
            Cursor.Current = Cursors.Default;
        }
        private bool ValidFields()
        {
            if (txtRevisionNumber.Text.Trim() == String.Empty)
            {
                DialogResult result = MessageBox.Show("No order number has been entered\nWould you like the program select one for you?", "Order Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OrderNumber orderno = new OrderNumber();
                    txtRevisionNumber.Text = orderno.GetNextNumber(OrderType.PurchaseOrder);
                    txtRevisionNumber.ReadOnly = true;
                }
                else
                {
                    ValidateEmpty(txtRevisionNumber);
                }

            }
            
            ValidateEmpty(txtTotal);
            ValidateComoBox(cmbEmployee);
            ValidateComoBox(cmbVendor);
            //ValidateComoBox(cmbStatus);
            ValidateDataGridViewEmpty(productGrid);

            if (!ValidateEmpty(txtRevisionNumber)) return false;
            if (!ValidateEmpty(txtTotal)) return false;
            if (!ValidateComoBox(cmbEmployee)) return false;
            if (!ValidateComoBox(cmbVendor)) return false;
            //if (!ValidateComoBox(cmbStatus)) return false;
            if (!ValidateDataGridViewEmpty(productGrid)) return false;
            return true;

        } 
        private void SavePurchaseOrder()
        {
            //save header first
            Cursor.Current = Cursors.WaitCursor;
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            
            
            int purchaseOrderID = 0;
            try
            {
                if (productGrid.Rows.Count < 1)
                {
                    MessageBox.Show("Please select at least one product before you save", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cursor.Current = Cursors.Default;
                    return;
                }

                poh.EmployeeID = Int32.Parse(cmbEmployee.SelectedValue.ToString());
                poh.Freight = 0; // Decimal.Parse(txtFreight.Text.Trim());
                poh.OrderDate = DateTime.Parse(dtOrderDate.Value.ToString());
                poh.RevisionNumber = txtRevisionNumber.Text.Trim();
                poh.ShipDate = DateTime.Parse(dtShipmentDate.Value.ToString());
                poh.Status = (Byte)(OrderStatus.Pending);// Byte.Parse(cmbStatus.SelectedValue.ToString());
                poh.SubTotal = 0;// Decimal.Parse(txtSubTotal.Text.Trim());
                poh.TaxAmt = 0;// Decimal.Parse(txtTaxes.Text.Trim());
                poh.TotalDue = txtTotal.Text.Trim()==String.Empty?0:Decimal.Parse(txtTotal.Text.Trim(),NumberStyles.Currency,null);
                poh.VendorID = Int32.Parse(cmbVendor.SelectedValue.ToString());
                poh.ShipMethodID = 0;// Int32.Parse(cmbShipmentMethod.SelectedValue.ToString());
                purchaseOrderID = poh.AddPurchaseOrderHeader(poh);
                foreach (DataRow dr in dtBindableTable.Rows)
                {
                    PurchaseOrderDetail pod = new PurchaseOrderDetail();
                    pod.PurchaseOrderID = purchaseOrderID;
                    pod.DueDate = DateTime.Parse(dtOrderDate.Value.ToString());
                    pod.ProductID = Int32.Parse(dr["ProductID"].ToString());
                    pod.OrderQty = Int16.Parse(dr["Quantity"].ToString());
                    pod.UnitPerCase = 0; // dr["Unit/Case"].ToString() == String.Empty ? 0 : Int32.Parse(dr["Unit/Case"].ToString());
                    pod.UnitPrice =  dr["Price"].ToString() == String.Empty ? 0 : Decimal.Parse(dr["Price"].ToString());
                    pod.NumberOfCases = 0; // dr["No Cases"].ToString() == String.Empty ? 0 : Double.Parse(dr["No Cases"].ToString());
                    pod.ReceivedQty = 0;
                    pod.RejectedQty = 0;
                    
                    pod.StockedQty = dr["INSTOCK"].ToString()==String.Empty?0:Int64.Parse(dr["INSTOCK"].ToString());
                    pod.AddPurchaseOrderDetail(pod);
                    pod = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                poh = null;
                dtBindableTable.Rows.Clear();
                //pod = null;
            }
            MessageBox.Show("Purchase Order Saved Successfully", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }
        private void SearchPurchaseOrders()
        {
            
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT [PurchaseOrderHeader].[PurchaseOrderID],";
            sql += "[PurchaseOrderHeader].[RevisionNumber] as 'Order No',[OrderStatus].[Name] as 'Status',";
            sql += "(rtrim([Employee].[FirstName]) + ' ' + rtrim([Employee].[MiddleName])+' '+rtrim([Employee].[LastName])) as 'Sales Person',";
            sql += "[Vendor].[Name] as 'Vendor Name',[PurchaseOrderHeader].[OrderDate],[PurchaseOrderHeader].[ShipDate],";
            sql += "[PurchaseOrderHeader].[TotalDue] as Total";
            sql += " FROM ";
            sql += " [dbo].[PurchaseOrderHeader],[dbo].[SalesPerson],[dbo].[Employee],[dbo].[Vendor], [dbo].[OrderStatus]";
            sql += " WHERE ";
            sql += "[OrderStatus].[ID] = [PurchaseOrderHeader].[Status] and ";
            sql += "[PurchaseOrderHeader].[EmployeeID] = [SalesPerson].[SalesPersonID] and ";
            sql += "[PurchaseOrderHeader].[VendorID] = [Vendor].[VendorID] and ";
            sql += "[Employee].[EmployeeID] = [SalesPerson].[SalesPersonID] ";
           // sql += " [PurchaseOrderID] = @PurchaseOrderID ";
            
            sb.Append(sql);
            if (txtSOOrderNumber.Text != String.Empty)
            {
                sb.Append(" And [PurchaseOrderHeader].[RevisionNumber] ='" + txtSOOrderNumber.Text.Trim() + "'");
            }
            if (Int32.Parse(cmbSOSalesPerson.SelectedValue.ToString()) > 0)
            {
                sb.Append(" AND [PurchaseOrderHeader].[EmployeeID]=" + Int32.Parse(cmbSOSalesPerson.SelectedValue.ToString()));
            }
            if (Int32.Parse(cmbSOVendor.SelectedValue.ToString()) > 0)
            {
                sb.Append(" AND [PurchaseOrderHeader].[VendorID]=" + Int32.Parse(cmbSOVendor.SelectedValue.ToString()));
            }
            if ((dtPendingOrderDate.Value != dtSOToDate.Value) && dtSOToDate.Value > dtPendingOrderDate.Value)
            {
                // sb.Append(" AND [PurchaseOrderHeader].[OrderDate] between '" + dtSOFromDate.Value.ToString("MM/dd/yyyy") + "' and '" + dtSOToDate.Value.ToString("MM/dd/yyyy") + " 23:59:59'");
                sb.Append(" AND [PurchaseOrderHeader].[OrderDate] >= '" + dtPendingOrderDate.Value.ToString("MM/dd/yyyy") + "' and [PurchaseOrderHeader].[OrderDate] < '" + dtSOToDate.Value.ToString("MM/dd/yyyy") + " 23:59:59'");
            }
            try
            {
                ds = gq.GetDataSet(false, sb.ToString());
                //dgPendingOrdersHeaders.Dispose();
                //dgPendingOrdersHeaders = new DataGridView();
            
                dgPendingOrdersHeaders.DataSource =ds.Tables[0];
                DataGridViewImageColumn imgEdit = new DataGridViewImageColumn();
                imgEdit.Image = Properties.Resources.editorder;
                imgEdit.HeaderText = "Edit/View";
                imgEdit.Name = "Edit/View";
                imgEdit.DefaultCellStyle.BackColor = Color.FromName("Linen");
                imgEdit.DefaultCellStyle.SelectionBackColor = Color.FromName("Linen");
                
                DataGridViewImageColumn imgInvoice = new DataGridViewImageColumn();
                imgInvoice.Image = Properties.Resources.invoice;
                imgInvoice.HeaderText = "Invoice";
                imgInvoice.Name = "Invoice";
                imgInvoice.DefaultCellStyle.BackColor = Color.FromName("Linen");
                imgInvoice.DefaultCellStyle.SelectionBackColor = Color.FromName("Linen");

                if (dgPendingOrdersHeaders.Columns["Edit/View"].Index < 0)
                {
                    dgPendingOrdersHeaders.Columns.Add(imgEdit);
                    dgPendingOrdersHeaders.Columns.Add(imgInvoice);
                }
                if( dgPendingOrdersHeaders.Columns["PurchaseOrderID"]!=null)   dgPendingOrdersHeaders.Columns["PurchaseOrderID"].Visible = false;
                dgPendingOrdersHeaders.Cursor = Cursors.Hand;
             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            
        }
        private void productGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are sure you want to delete this row?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
 
        }
        private void productGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtTotal.Text = String.Format("{0:c}", GetTotal(productGrid));
        }
        private void btnPendingSearch_Click(object sender, EventArgs e)
        {
            SearchPurchaseOrders();
        }
        private void ClearFields()
        {
        }
        private void ShowPendingOrderDetails()
        {
            if (dgPendingOrdersHeaders.Rows.Count < 1)
            {
                dgPendingOrdersDetails.DataSource = null;
                return;
            }
            DataGridViewRow row = new DataGridViewRow();
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();
            row = dgPendingOrdersHeaders.CurrentRow;
            if (row == null) return;
            ClearFields();
            try
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //MessageBox.Show(cell.OwningColumn.Name);
                    switch (cell.OwningColumn.Name)
                    {
                        case "Order No":
                            txtSOOrderNumber.Text = cell.Value.ToString();
                            break;
                        case "Sales Person":
                            SalesPerson sp = new SalesPerson();
                            sp.FullName = cell.Value.ToString();
                            cmbSOSalesPerson.SelectedIndex = cmbSOSalesPerson.FindStringExact(sp.FullName);
                            break;
                        case "Vendor Name":
                            Vendor v = new Vendor();
                            v.Name = cell.Value.ToString();
                            cmbSOVendor.SelectedIndex = cmbSOVendor.FindStringExact(v.Name);
                            break;
                        case "OrderDate":
                            dtPendingOrderDate.Value = DateTime.Parse(cell.Value.ToString());
                            break;
                        case "ShipDate":
                            dtSOToDate.Value = DateTime.Parse(cell.Value.ToString());
                            break;
                        case "TotalDue":
                            txtPendingTotal.Text = String.Format("{0:c}", Decimal.Parse(cell.Value.ToString()));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #region comment
            /* DataGridViewRow row = new DataGridViewRow();
            row = grdCustomers.CurrentRow;
            if (row == null) return;
            ClearFields();
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.OwningColumn.Name)
                {
                    case "CustomerID":
                        txtCustomerID.Text = cell.Value.ToString();
                        break;
                    case "AccountNumber":
                        txtAccountNumber.Text = cell.Value.ToString();*/

            #endregion
            try
            {
                int poid = Int32.Parse(row.Cells["PurchaseOrderID"].Value.ToString());
                string sql = "select prd.productid as productid,prd.name as Name, pod.purchaseorderid,prd.productnumber as PRODUCT_CODE,prd.ReorderPoint as ReorderPoint, inv.quantity as INSTOCK, pod.purchaseorderdetailid,pod.orderqty as Quantity,pod.unitprice as Price,  (pod.orderqty*pod.unitprice) as Total from ";
                sql += " purchaseorderdetail pod, product prd, productinventory inv where prd.productid = pod.productid and inv.productid=prd.productid and ";
                sql += " purchaseorderid=" + poid;
                ds = gq.GetDataSet(false, sql);

                dgPendingOrdersDetails.DataSource = ds.Tables[0];
               // dtBindableTable = ds.Tables[0];
                dgPendingOrdersDetails.Columns["purchaseorderid"].Visible = false;
                dgPendingOrdersDetails.Columns["purchaseorderdetailid"].Visible = false;
                dgPendingOrdersDetails.Columns["productid"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgPendingOrdersHeaders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnPendingAddItems_Click(object sender, EventArgs e)
        {
            SelectProducts(dgPendingOrdersDetails, txtPendingTotal);
            //txtPendingTotal.Text = String.Format("{0:c}", CalcualteTotal(dgPendingOrdersDetails));
        }
        #region ***************************Pending Orders Tab**************************************
       
        private void SaveInvoiceDetails(int purchaserInvoiceID)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int count = dgInvoiceDetails.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
                    int productID = Int32.Parse(dgInvoiceDetails.Rows[i].Cells["productid"].Value.ToString());
                    pid.InvoiceID = purchaserInvoiceID;
                    try
                    {
                        pid.InvoiceDetailID = Int32.Parse(dgInvoiceDetails.Rows[i].Cells["invoicedetailid"].Value.ToString());
                    }
                    catch
                    {
                        pid.InvoiceDetailID = 0;
                    }
                    pid.ProductID = productID;
                    pid.UnitPrice = Decimal.Parse(dgInvoiceDetails.Rows[i].Cells["Price"].Value.ToString());
                    pid.Quantity = Int64.Parse(dgInvoiceDetails.Rows[i].Cells["Quantity"].Value.ToString());
                    pid.ModifiedDate = DateTime.Now;
                    pid.AddUpdatePurchaseInvoiceDetail(pid);
                    //dtInvoiceHeader.Rows.


                  
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;

            }
            finally
            {
                MessageBox.Show("Invoice saved successfully", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
        }

        private void SavePurchaseInvoice()
        {
            Cursor.Current = Cursors.WaitCursor;
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            int purchaseOrderId = 0;

            //purchaseOrderId = Int32.Parse(lblInvoicePurchaseOrderID.Text.Trim());
            DataGridViewRow row = new DataGridViewRow();
            if (dgInvoiceHeader.Rows.Count < 1)
            {
                MessageBox.Show("No Purchase Invoice", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            row = dgInvoiceHeader.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("No Purchase Invoice is selected", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int purchaseInvoiceID = 0;
            purchaseInvoiceID = Int32.Parse(row.Cells["InvoiceID"].Value.ToString());
            purchaseOrderId = Int32.Parse(row.Cells["PurchaseOrderID"].Value.ToString());
            try
            {
                pih.EmployeeID = Int32.Parse(cmbInvoiceSalesPerson.SelectedValue.ToString());
                pih.VendorID = Int32.Parse(cmbInvoiceVendor.SelectedValue.ToString());
                pih.TaxAmt = 0;
                pih.SubTotal = 0;
                pih.PurchaseOrderID = purchaseOrderId;
                //pih.Status = Byte.Parse(cmbInvoiceStatus.SelectedValue.ToString());
                pih.InvoiceNumber = txtInoviceInvoiceNumber.Text.Trim();
                pih.InvoiceDate = DateTime.Parse(dtInvoiceDate.Value.ToString());
                pih.ModifiedDate = DateTime.Now;

                //lblInvoiceID.Text = purchaseInvoiceID.ToString();
                //purchaseInvoiceID = pih.PurchaseInvoiceHeaderExists(purchaseOrderId);
                if (purchaseInvoiceID > 0)
                {
                    //pih.InvoiceID = purchaseInvoiceID;
                    pih = pih.GetPurchaseInvoiceHeader(purchaseInvoiceID);
                    pih.UpdatePurchaseInvoiceHeader(pih);
                    SaveInvoiceDetails(purchaseInvoiceID);
                    //MessageBox.Show("Purchase Invoice Updated Successfully", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    purchaseInvoiceID = pih.AddPurchaseInvoiceHeader(pih);
                    if (purchaseInvoiceID > 0)
                    {
                        SaveInvoiceDetails(purchaseInvoiceID);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "SaveInvoiceHeader");
                MessageBox.Show(ex.Message, "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                pih = null;
                Cursor.Current = Cursors.Default;
            }
        }
        private void InvoiceGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are sure you want to delete this row?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {

                int invoiceDetailID = Int32.Parse(e.Row.Cells["PurchaseOrderDetailID"].Value.ToString());
                PurchaseInvoiceDetail pod = new PurchaseInvoiceDetail();
                pod.RemovePurchaseInvoiceDetail(invoiceDetailID);
                txtInvoiceTotal.Text = String.Format("{0:c}", GetTotal(dgInvoiceDetails));
                MessageBox.Show("Record deleted successfully", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lblInvoiceID_TextChanged(object sender, EventArgs e)
        {
            int invoiceID = 0;
            try
            {
                invoiceID = Int32.Parse(lblInvoiceID.Text.Trim());
                if (invoiceID > 0)
                {
                    btnInvoicePrint.Enabled = true;
                }
                else
                {
                    btnInvoicePrint.Enabled = false;
                }
            }
            catch
            {
                btnInvoicePrint.Enabled = false;
            }
        }
        private void PurchaseOrderReceived()
        {
            if (dgPendingOrdersHeaders.Rows.Count < 1) return;

            Cursor.Current = Cursors.WaitCursor;
            
            int poid = Int32.Parse(dgPendingOrdersHeaders.CurrentRow.Cells["purchaseorderid"].Value.ToString()); ;
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            PurchaseOrderDetailCollection podColl = new PurchaseOrderDetailCollection();
            PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
            OrderNumber orderNumber = new OrderNumber();

            try
            {
                //update the pruchase order status to received
                poh = poh.GetPurchaseOrderHeader(poid);
                
                if (poh.Status != (byte)OrderStatus.Pending) return;

                poh.Status = (byte)OrderStatus.Received;
                poh.UpdatePurchaseOrderHeader(poh);
                string where = "[PurchaseOrderID]=" + poid;
                podColl = pod.GetPurchaseOrderDetailCollection(where, String.Empty);
                PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader(poh);
                //save the purchase order to the purchase invoice, and get the invoice id
                int invid = pih.AddPurchaseInvoiceHeader(pih);
                foreach (PurchaseOrderDetail p in podColl)
                {
                    pid.InvoiceID = invid;
                    pid.ModifiedDate = DateTime.Now;
                    pid.ProductID = p.ProductID;
                    pid.Quantity = p.OrderQty;
                    pid.UnitPrice = p.UnitPrice;

                    pid.AddPurchaseInvoiceDetail(pid);
                    p.UpdatePurchaseOrderDetail(p);
                }
                
                MessageBox.Show("Status change successful\nPurchase Order has been saved as a purchase Invoice", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowPendingOrders();
                ShowPendingOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                poh =null;
                pod =null;
                podColl =null;
                pid =null;
                Cursor.Current = Cursors.Default;
            }
        }
        private void PurchaseOrderCancelled()
        {
            if (dgPendingOrdersHeaders.Rows.Count < 1) return;
            DialogResult result = MessageBox.Show("Are sure you want to cancel this order?", "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            Cursor.Current = Cursors.WaitCursor;

            int poid = Int32.Parse(dgPendingOrdersHeaders.CurrentRow.Cells["purchaseorderid"].Value.ToString()); ;
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            try
            {
                poh = poh.GetPurchaseOrderHeader(poid);
                poh.Status = (byte)OrderStatus.Cancelled;
                poh.UpdatePurchaseOrderHeader(poh);
                ShowPendingOrders();
                ShowPendingOrderDetails();
                MessageBox.Show("Purchase Order has been cancelled successfully", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                poh = null;
                Cursor.Current = Cursors.Default;
            }

        }
        private void SavePendingPurchaseOrder()
        {
            //dgPendingOrdersDetails
            //dgPendingOrdersHeaders
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            PurchaseOrderDetailCollection podColl = new PurchaseOrderDetailCollection();

            if (dgPendingOrdersHeaders.Rows.Count < 1) return;
            
            try
            {

                ShowPendingOrders();
                ShowPendingOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private void btnPendingOrderReceived_Click(object sender, EventArgs e)
        {
            PurchaseOrderReceived();
        }
        private void btnPendingCancelOrder_Click(object sender, EventArgs e)
        {
            PurchaseOrderCancelled();
        }
        private void btnPendingSaveChanges_Click(object sender, EventArgs e)
        {
            SavePendingPurchaseOrder();
            isDirty = false;
        }
#endregion
        private void tpSearchOrder_Enter(object sender, EventArgs e)
        {
            ShowPendingOrders();
            ShowPendingOrderDetails();
        }
        private void dgPendingOrdersHeaders_SelectionChanged(object sender, EventArgs e)
        {
            ShowPendingOrderDetails();
        }
       
        #region Invoice Tab
        private void dgInvoiceHeader_SelectionChanged(object sender, EventArgs e)
        {
            ShowInvoiceDetails();
        }
        private void ShowInvoiceDetails()
        {
            if (dgInvoiceHeader.Rows.Count < 1)
            {
                dgInvoiceDetails.DataSource = null;
                return;
            }
            DataGridViewRow row = new DataGridViewRow();
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();
            row = dgInvoiceHeader.CurrentRow;
            if (row == null) return;
            //come to this later
            //ClearFields();
            try
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    switch (cell.OwningColumn.Name)
                    {
                        case "Order No":
                            txtInoviceInvoiceNumber.Text = cell.Value.ToString();
                            break;
                        case "Sales Person":
                            SalesPerson sp = new SalesPerson();
                            sp.FullName = cell.Value.ToString();
                            cmbInvoiceSalesPerson.SelectedIndex = cmbSOSalesPerson.FindStringExact(sp.FullName);
                            break;
                        case "Vendor Name":
                            Vendor v = new Vendor();
                            v.Name = cell.Value.ToString();
                            cmbInvoiceVendor.SelectedIndex = cmbSOVendor.FindStringExact(v.Name);
                            break;
                        case "OrderDate":
                            dtInvoiceDate.Value = DateTime.Parse(cell.Value.ToString());
                            break;

                        case "TotalDue":
                            txtInvoiceTotal.Text = String.Format("{0:c}", Decimal.Parse(cell.Value.ToString()));
                            break;
                        case "InvoiceID":
                            lblInvoicePurchaseOrderID.Text = cell.Value.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                int poid = Int32.Parse(row.Cells["InvoiceID"].Value.ToString());
                string sql = "select prd.productid as productid,prd.name as Name, ";
                sql += " pod.invoiceid ,prd.productnumber as PRODUCT_CODE,prd.ReorderPoint as ReorderPoint, ";
                sql += " inv.quantity as INSTOCK, pod.InvoiceDetailID,pod.quantity as Quantity, ";
                sql += " pod.unitprice as Price,  (pod.quantity*pod.unitprice) as Total ";
                sql += " from ";
                sql += " purchaseinvoicedetail pod, product prd, productinventory inv ";
                sql += " where ";
                sql += " prd.productid = pod.productid and ";
                sql += " inv.productid=prd.productid and ";
                sql += " invoiceid=" + poid;
                ds = gq.GetDataSet(false, sql);
                dtBindableTable = ds.Tables[0];
                dgInvoiceDetails.DataSource = dtBindableTable;
                // dtBindableTable = ds.Tables[0];
                dgInvoiceDetails.Columns["InvoiceID"].Visible = false;
                dgInvoiceDetails.Columns["InvoiceDetailID"].Visible = false;
                dgInvoiceDetails.Columns["productid"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void dgInvoiceDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int invoiceDetailID = Int32.Parse(e.Row.Cells["InvoiceDetailID"].Value.ToString());
            if (invoiceDetailID < 1) return;
            DialogResult result = MessageBox.Show("Are sure you want to delete this row?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {

              
                PurchaseInvoiceDetail pod = new PurchaseInvoiceDetail();
                pod.RemovePurchaseInvoiceDetail(invoiceDetailID);
                txtInvoiceTotal.Text = String.Format("{0:c}", GetTotal(dgInvoiceDetails));
                MessageBox.Show("Record deleted successfully", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnInvoiceAddItems_Click(object sender, EventArgs e)
        {
            SelectProducts(dgInvoiceDetails, txtInvoiceTotal);
        }
        private void btnInvoiceSearch_Click(object sender, EventArgs e)
        {
            SearchInvoices();
        }
        private void SearchInvoices()
        {
            
            Cursor.Current = Cursors.WaitCursor;
            GenericQuery gq = new GenericQuery();
            DataSet ds = new DataSet();

            string sql = "SELECT [PurchaseInvoiceHeader].[PurchaseOrderID],[PurchaseInvoiceHeader].[InvoiceID],";
            sql += "[PurchaseInvoiceHeader].[InvoiceNumber] as 'Order No',[OrderStatus].[Name] as 'Status',";
            sql += "(rtrim([Employee].[FirstName]) + ' ' + rtrim([Employee].[MiddleName])+' '+rtrim([Employee].[LastName])) as 'Sales Person',";
            sql += "[Vendor].[Name] as 'Vendor Name',[PurchaseInvoiceHeader].[InvoiceDate],";
            sql += "[PurchaseInvoiceHeader].[TotalDue]";
            sql += " FROM ";
            sql += " [dbo].[PurchaseInvoiceHeader],[dbo].[SalesPerson],[dbo].[Employee],[dbo].[Vendor], [dbo].[OrderStatus]";
            sql += " WHERE ";
            sql += "[OrderStatus].[ID] = [PurchaseInvoiceHeader].[Status] and ";
            sql += "[PurchaseInvoiceHeader].[EmployeeID] = [SalesPerson].[SalesPersonID] and ";
            sql += "[PurchaseInvoiceHeader].[VendorID] = [Vendor].[VendorID] and ";
            sql += "[Employee].[EmployeeID] = [SalesPerson].[SalesPersonID] And [PurchaseInvoiceHeader].InvoiceDate BETWEEN '" + dtInvoiceDate.Value.ToShortDateString() + " 00:00:00' And '" + dtInvoiceDate.Value.ToShortDateString() + " 23:59:59'";
            if (Int32.Parse(cmbInvoiceStatus.SelectedValue.ToString()) > 0)
            {
                sql += " And [PurchaseInvoiceHeader].[Status]=" + cmbInvoiceStatus.SelectedValue;
            }
            if (txtInoviceInvoiceNumber.Text.Trim() != String.Empty)
            {
                sql += " And [PurchaseInvoiceHeader].InvoiceNumber='" + txtInoviceInvoiceNumber.Text.Trim() + "'";
            }
            if (Int32.Parse(cmbInvoiceVendor.SelectedValue.ToString()) > 0)
            {
                sql += " And [PurchaseInvoiceHeader].VendorID=" + cmbInvoiceVendor.SelectedValue;
            }
            if (Int32.Parse(cmbInvoiceSalesPerson.SelectedValue.ToString()) > 0)
            {
                sql += " And [PurchaseInvoiceHeader].EmployeeID=" + cmbInvoiceSalesPerson.SelectedValue;
            }

            try
            {
                ds = gq.GetDataSet(false, sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnInvoiceAddItems.Enabled = true;
                }
                else
                {
                    btnInvoiceAddItems.Enabled = false;
                }
                dtInvoiceHeader = ds.Tables[0];
                dgInvoiceHeader.DataSource = dtInvoiceHeader;
                dgInvoiceHeader.Columns["InvoiceID"].Visible = false;
                dgInvoiceHeader.Columns["PurchaseOrderID"].Visible = false;
                dgInvoiceHeader.Cursor = Cursors.Hand;
                if (dgInvoiceHeader.Rows.Count  < 1)
                {
                    dgInvoiceDetails.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                gq = null;
                Cursor.Current = Cursors.Default;
            }

        }
        #endregion

        private void tpNewOrder_Validating(object sender, CancelEventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Data has changed.\nWould you like to save the data?","MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    productGrid.DataSource = null;
                    isDirty = false;
                }

            }
        }

        private void tpSearchOrder_Validating(object sender, CancelEventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Data has changed.\nWould you like to save the data?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    //dgPendingOrdersDetails.DataSource = null;
                    isDirty = false;
                }

            }
        }
        private void tpInvoices_Validating(object sender, CancelEventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Data has changed.\nWould you like to save the data?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    //dgInvoiceDetails.DataSource = null;
                    isDirty = false;
                }

            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        
        private void ClearOrderNumber()
        {
            txtInoviceInvoiceNumber.Text = string.Empty;
        }

      

        private void cmbInvoiceStatus_TextChanged(object sender, EventArgs e)
        {
            //ClearOrderNumber();
        }

        private void cmbInvoiceSalesPerson_TextChanged(object sender, EventArgs e)
        {
            //ClearOrderNumber();
        }

        private void cmbInvoiceVendor_TextChanged(object sender, EventArgs e)
        {
            //ClearOrderNumber();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
           

            //purchaseOrderId = Int32.Parse(lblInvoicePurchaseOrderID.Text.Trim());
            DataGridViewRow row = new DataGridViewRow();
            if (dgInvoiceHeader.Rows.Count < 1)
            {
                MessageBox.Show("No Purchase Invoice", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            row = dgInvoiceHeader.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("No Purchase Invoice is selected", "Purchase Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int purchaseInvoiceID = 0;
            purchaseInvoiceID = Int32.Parse(row.Cells["InvoiceID"].Value.ToString());
            
            try
            {
                if (purchaseInvoiceID > 0)
                {
                    pih = pih.GetPurchaseInvoiceHeader(purchaseInvoiceID);
                    pih.Status =(byte) OrderStatus.Paid;
                    pih.ModifiedDate = DateTime.Now;
                    pih.UpdatePurchaseInvoiceHeader(pih);
                }

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Invoice Paid");
                MessageBox.Show(ex.Message, "Purchase Invoice Paid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                pih = null;
                Cursor.Current = Cursors.Default;
            }
        }

        private void dtShipmentDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}