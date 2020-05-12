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
    public partial class frmSaleOrder : frmParent
    {
        LogWriter log = new LogWriter();
        private CustomerCollection m_CustomerCollection = null;
        private AddressCollection m_AddressCollection = null;
        private Customer InvoiceCustomer = new Customer();
        private SalesOrderHeaderCollection PendingOrders = null;
        private SalesOrderDetailCollection PendingOrdersDetails = null;
        private SalesOrderHeaderCollection ViewOrders = null;
        private SalesInvoiceHeaderCollection InvoiceHeader = null;
        //private SalesOrderDetailCollection ViewOrdersDetails = null;
        private Customer m_Customer = new Customer();
        //private DataTable dtPendingOrders = new DataTable();
        private DataTable dtViewOrders = new DataTable();
        private DataTable dtOrderStatus = new DataTable();
        private DataTable dtInvoiceHeader = new DataTable();
        private DataTable dtInvoicePayments = new DataTable();
        //private DataTable dtViewOrdersDetails = new DataTable();
        //private DataTable dtPendingOrdersDetail = null;
        private int m_CustomerID = 0;
        private int m_AddressID = 0;
        private int m_InvoiceID = 0;
        private bool m_loading = false;
        //private int m_BillingAddressID = 0;
        private decimal m_OrderTotal = 0;
        int m_PendingOrderShippingAddressID = 0;
        int m_PendingOrderBillingAddressID = 0;
        //DataTable dtProducts = new DataTable();
       
        public frmSaleOrder()
        {
            InitializeComponent();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {

            //SearchCustomer();
        }
        
        private void tabNewOrders_Click(object sender, EventArgs e)
        {

        }

        private void frmSaleOrder_Load(object sender, EventArgs e)
        {
            m_loading = true;
            LoadFormData(0);
            m_loading = false;
        }
        private void LoadFormData(int cur_row)
        {
            using (new CursorHandler())
            {
                dtProducts.Rows.Clear();
                m_OrderTotal = 0;
                txtOrderTotal.Text = "";
                PopulateComboBoxes();
                LoadPendingOrders(cur_row);
                LoadTerritories(cmbEditViewTerritory);
                LoadTerritories(cmbNewOrderTerritory);
                LoadTerritories(cmbInvoiceTerritory);
              //LoadPendingOrdersDetails();
                LoadOrderStatus();
             //   LoadPastDueInvoices();
              //  PendingOrderClick(0);
            }
        }
        private void LoadTerritories(ComboBox cmb)
        {
            SalesTerritory st = new SalesTerritory();
            try
            {
                //Sales Territory
                DataSet ds = st.GetAllSalesTerritoryDataSet();
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[0] = "0";
                dr[1] = "<Select One>";
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "TerritoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadOrderStatus()
        {
            try
            {
                dtOrderStatus = new DataTable();
                GenericQuery q = new GenericQuery();
                string sql = "select * from OrderStatus";
                DataSet ds = q.GetDataSet(false, sql);
                dtOrderStatus.Columns.Add(new DataColumn("ID", typeof(int)));
                dtOrderStatus.Columns.Add(new DataColumn("Name", typeof(string)));
                dtOrderStatus = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateComboBoxes()
        {
            try
            {
                //customers
                Customer cus = new Customer();
                cus.CustomerID = 0;
                cus.Name = "<Select One>";
                m_CustomerCollection = new CustomerCollection();
                string where = "activeflag=1";
                string orderby = "name";
                m_CustomerCollection = cus.GetCustomersCollection(where, orderby);
                //m_CustomerCollection = cus.GetAllCustomerCollection();
                m_CustomerCollection.Insert(0, cus);
                cmbCustomerName.DataSource = m_CustomerCollection;
                cmbCustomerName.DisplayMember = "Name";
                cmbCustomerName.ValueMember = "CustomerID";
                
                //Pending Orders customers
                Customer cust = new Customer();
                cust.CustomerID = 0;
                cust.Name = "<All Customers>";
                CustomerCollection col = new CustomerCollection();
                col = cust.GetAllCustomerCollection();
                col.Insert(0, cust);
                cmbPendingOrderCustomer.DataSource = col;
                cmbPendingOrderCustomer.DisplayMember = "Name";
                cmbPendingOrderCustomer.ValueMember = "CustomerID";

                //view/edit orders customers
                cust = new Customer();
                cust.CustomerID = 0;
                cust.Name = "<All Customers>";
                col = new CustomerCollection();
                col = cust.GetAllCustomerCollection();
                col.Insert(0, cust);
                cmbViewOrderCustomers.DataSource = col;
                cmbViewOrderCustomers.DisplayMember = "Name";
                cmbViewOrderCustomers.ValueMember = "CustomerID";

                //invoice customers
                cust = new Customer();
                cust.CustomerID = 0;
                cust.Name = "<All Customers>";
                col = new CustomerCollection();
                col = cust.GetAllCustomerCollection();
                col.Insert(0, cust);
                cmbInvoiceCustomers.DataSource = col;
                cmbInvoiceCustomers.DisplayMember = "Name";
                cmbInvoiceCustomers.ValueMember = "CustomerID";

                //print territories
                SalesTerritory ter = new SalesTerritory();
                SalesTerritoryCollection terCol = new SalesTerritoryCollection();
                terCol = ter.GetAllSalesTerritoryCollection();
                ter.TerritoryID = 0;
                ter.Name = "<All Territories>";
                ter.ModifiedDate = DateTime.Now;
                terCol.Insert(0, ter);
                cmbPrintTerritory.DataSource = terCol;
                cmbPrintTerritory.DisplayMember = "Name";
                cmbPrintTerritory.ValueMember = "TerritoryID";

                //load addresses
                Address add = new Address();
                m_AddressCollection = new AddressCollection();
                m_AddressCollection = add.GetAllAddresssCollection();

                //Payment method
                PaymentMethod method = new PaymentMethod();
                PaymentMethodCollection methods = new PaymentMethodCollection();
                method.PaymentMethodID = 0;
                method.Name = "<Select One>";
                methods.Add(method);
                method = new PaymentMethod();
                method.PaymentMethodID = (int)PaymentType.Cash;
                method.Name="Cash";
                methods.Add(method);
                method = new PaymentMethod();
                method.PaymentMethodID = (int)PaymentType.Check;
                method.Name="Chech";
                methods.Add(method);
                method = new PaymentMethod();
                method.PaymentMethodID = (int)PaymentType.Credit;
                method.Name="Credit";
                methods.Add(method);
                

                cmbPaymentMethod.DataSource = methods;
                cmbPaymentMethod.DisplayMember = "Name";
                cmbPaymentMethod.ValueMember = "PaymentMethodID";

                CustomerCollection dummy = new CustomerCollection();
                string[] actions = { "<Select One>", "Selected Shipping Orders", "All Shipping Orders", "Selected Invoices", "All Invoices" };
                for (int i = 0; i < actions.Length; i++)
                {
                    dummy.Add(new Customer());
                    dummy[i].CustomerID = i;
                    dummy[i].Name = actions[i];
                }
                cmbPendingOrderPrint.DataSource = dummy;
                cmbPendingOrderPrint.DisplayMember = "Name";
                cmbPendingOrderPrint.ValueMember = "CustomerID";
                btnPedingOrderPrint.Enabled = false;

                //invoice status
                dummy = new CustomerCollection();
                string[] InvoiceStatus = { "Past Due", "Paid", "All Invoices" };
                for (int i = 0; i < InvoiceStatus.Length; i++)
                {
                    dummy.Add(new Customer());
                    dummy[i].CustomerID = i;
                    dummy[i].Name = InvoiceStatus[i];
                }
                cmbInvoiceStatus.DataSource = dummy;
                cmbInvoiceStatus.DisplayMember = "Name";
                cmbInvoiceStatus.ValueMember = "CustomerID";

                //invoice payment type
                 Payment pay = new Payment();
                string[,] TypesArray = pay.PaymentCode;
                List<SimplePair> pair = new List<SimplePair>();
                pair.Add(new SimplePair("", "<Select One>"));
                for(int i=0; i<TypesArray.Length/2; i++)
                {
                    if (TypesArray[i, 0] != "P")
                    {
                        string value = TypesArray[i, 0];
                        string display = TypesArray[i, 1];
                        pair.Add(new SimplePair(value,display ));
                    }
                }
                cmbPaymentType.DataSource = pair;
                cmbPaymentType.DisplayMember = "DisplayMember";
                cmbPaymentType.ValueMember = "StrValueMember";
                           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        private void LoadViewOrders()
        {
            SalesOrderHeader soh = new SalesOrderHeader();
            dtViewOrders = new DataTable();
           
            try
            {
                int PendStat = (int)OrderStatus.Pending;
                int CancStat = (int)OrderStatus.Cancelled;
                dtViewOrdersDetails.Rows.Clear();

                string where = "Status not in ('" + PendStat.ToString() + "','" + CancStat.ToString() + "')";
                if (cmbViewOrderCustomers.SelectedIndex > 0)
                {
                    where += " and CustomerID=" + cmbViewOrderCustomers.SelectedValue.ToString();
                }
                if (txtFromDate.Text.Trim() != String.Empty)
                {
                    where += " and OrderDate >='" + txtFromDate.Text + "'";
                }
                if (txtToDate.Text.Trim() != String.Empty)
                {
                    where += " and OrderDate <= '" + txtToDate.Text + "'";
                }
                if (txtViewOrdersOrderID.Text.Trim() != string.Empty)
                {
                    where = "SalesOrderID=" + txtViewOrdersOrderID.Text + " and Status not in ('" + PendStat.ToString() + "','" + CancStat.ToString() + "')";
                }
                if (cmbEditViewTerritory.SelectedIndex > 0 && cmbViewOrderCustomers.SelectedIndex == 0)
                {
                    where += " and customerid in (select customerid from customer where territoryid=" + cmbEditViewTerritory.SelectedValue.ToString() + ")";
                }
                string OrderBy = "OrderDate,SalesOrderID";
                ViewOrders = soh.GetSalesOrderHeaderCollection(where, OrderBy);
                SetupViewOrdersGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                soh = null;
            }
        }
        private void LoadPendingOrders(int selected)
        {
            SalesOrderHeader soh = new SalesOrderHeader();
            dtPendingOrders = new DataTable();
            int territoryid = 0;
            try
            {
                if (cmbPrintTerritory.Items.Count > 0)
                {
                    territoryid = Int32.Parse(cmbPrintTerritory.SelectedValue.ToString());
                }
                int status = (int)OrderStatus.Pending;
                string where = "Status='" + status + "'";
                if (territoryid != 0)
                {
                    where += " and customerid in(select customerid from customer where territoryid=" + territoryid + ")";
                }
                string OrderBy = "DueDate,SalesOrderID";
                PendingOrders = soh.GetSalesOrderHeaderCollection(where,OrderBy);
                if (PendingOrders.Count == 0)
                {
                    lblMessage.Text = "Currently there are no pending ordres";
                    if (territoryid == 0)
                    {
                        groupPendingOrder.Visible = false;
                        groupPendingOrdersDetails.Visible = false;
                    }
                    else
                    {
                        groupPendingOrder.Visible = true;
                        groupPendingOrdersDetails.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "";
                    groupPendingOrder.Visible = true;
                    groupPendingOrdersDetails.Visible= true;
                }
                SetupPendingOrdersGrid(selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                soh = null;
            }
        }
        private void LoadPastDueInvoices()
        {
            try
            {
                InvoiceHeader = new SalesInvoiceHeaderCollection();
                SalesInvoiceHeader sih = new SalesInvoiceHeader();
                string today = DateTime.Today.ToShortDateString();
                string where = "status != 5 and status !=6 and DueDate <= '" + today + "'";
                string OrderBy = "DueDate";
                InvoiceHeader = sih.GetSalesInvoiceHeadersCollection(where, OrderBy);
                SetupInvoiceHeaderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             


            
        }
        private void LoadPendingOrdersDetails()
        {
            try
            {
                SalesOrderDetail sod = new SalesOrderDetail();
                string where = "SalesOrderID in (select SalesOrderID from SalesOrderHeader where status='1')";
                string OrderBy = "SalesOrderID";
                PendingOrdersDetails = sod.GetSalesOrderDetailCollection(where, OrderBy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
          
        }
        private void SetupSalesOrderDetailsGrid( DataTable dt)
        {
            if (dt.Columns.Count > 0)
                return;
            dt.Columns.Add(new DataColumn("Nbr", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Product", typeof(string)));
            dt.Columns.Add(new DataColumn("Specail Offer", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(short)));
            dt.Columns.Add(new DataColumn("Total", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Grand Total", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SalesOrderDetailID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("SalesOrderID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("SpecialOfferID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("CarrierTrackingNumber", typeof(String)));

            
            

        }
        private void SetupViewOrderDetailGrid()
        {
            SetupSalesOrderDetailsGrid(dtViewOrdersDetails);
            //if (dtViewOrdersDetails.Columns.Count > 0)
            //    return;
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Nbr", typeof(int)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("ID", typeof(int)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Product", typeof(string)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Specail Offer", typeof(string)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Price", typeof(decimal)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Quantity", typeof(short)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Total", typeof(decimal)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            //dtViewOrdersDetails.Columns.Add(new DataColumn("Grand Total", typeof(decimal)));

        }
        private void FillSalesOrdersDetailsGrid(int order_id, DataTable dt, DataGridView grd)
        {
            Product p = new Product();
            SalesOrderDetail sod = new SalesOrderDetail();
            string where = "SalesOrderID=" + order_id;
            string order_by = "SalesOrderID,description";
            //dtPendingOrdersDetail = new DataTable();
            dt.Rows.Clear();
            SetupSalesOrderDetailsGrid(dt);
            //DataSet ds = sod.GetSalesOrderDetailDataSet(where, order_by);
            try
            {
                SalesOrderDetailCollection col = sod.GetSalesOrderDetailCollection(where, order_by);
                for (int i = 0; i < col.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Nbr"] = i + 1;
                    int prod_id = col[i].ProductID;
                    dr["ID"] = prod_id;
                    dr["Product"] = col[i].Description; //p.GetProduct(prod_id).Description;
                    dr["SpecialOfferID"] = col[i].SpecialOfferID;
                    dr["Specail Offer"] = col[i].SpecialOfferDesc;
                    dr["Price"] = col[i].UnitPrice;
                    dr["Quantity"] = col[i].OrderQty;
                    dr["Total"] = decimal.Parse(dr["Quantity"].ToString()) * decimal.Parse(dr["Price"].ToString());
                    dr["Discount"] = col[i].UnitPriceDiscount;
                    dr["Grand Total"] = col[i].LineTotal;

                    dr["SalesOrderDetailID"] = col[i].SalesOrderDetailID;
                    dr["SalesOrderID"] = col[i].SalesOrderID;
                    dr["SpecialOfferID"] = col[i].SpecialOfferID;
                    dr["CarrierTrackingNumber"] = col[i].CarrierTrackingNumber;
                    
                    dt.Rows.Add(dr);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grd.DataSource = dt;
            grd.Columns["SalesOrderDetailID"].Visible = false;
            grd.Columns["SalesOrderID"].Visible = false;
            grd.Columns["SpecialOfferID"].Visible = false;
            grd.Columns["CarrierTrackingNumber"].Visible = false;
            grd.Columns["SpecialOfferID"].Visible = false;

            dt.AcceptChanges();
            FormatPendingOrderGridColumns(grd);
        }
        private void FormatPendingOrderGridColumns(DataGridView grd)
        {
            grd.Columns["Nbr"].Width = 40;
            grd.Columns["ID"].Width = 50;
            grd.Columns["Product"].Width = 250;
            grd.Columns["Price"].Width = 70;
            grd.Columns["Quantity"].Width = 50;
            grd.Columns["Discount"].Width = 50;

            grd.Columns["Nbr"].ReadOnly = true;
            grd.Columns["ID"].ReadOnly = true;
            grd.Columns["Product"].ReadOnly = true;
            grd.Columns["Specail Offer"].ReadOnly = true;
            grd.Columns["Specail Offer"].Width = 150;
            grd.Columns["Total"].ReadOnly = true;
            grd.Columns["Grand Total"].ReadOnly = true;

            grd.Columns["Price"].DefaultCellStyle.Format = "c";
            grd.Columns["Total"].DefaultCellStyle.Format = "c";
            grd.Columns["Grand Total"].DefaultCellStyle.Format = "c";
            grd.Columns["Discount"].DefaultCellStyle.Format = "c";
        }
        private void PopulatePendingOrdersDetailGrid(int order_id)
        {
            //This function is not used.
            Product product = new Product();
            dtPendingOrdersDetail = new DataTable();
            //SetupPendingOrderDetailsGrid();
            if (PendingOrdersDetails == null)
                return;
            try
            {
                for (int i = 0; i < PendingOrdersDetails.Count; i++)
                {
                    if (PendingOrdersDetails[i].SalesOrderID == order_id)
                    {
                        DataRow dr = dtPendingOrdersDetail.NewRow();
                        dr["Nbr"] = i + 1;
                        dr["ID"] = PendingOrdersDetails[i].SalesOrderDetailID;
                        int prod_id = PendingOrdersDetails[i].ProductID;
                        dr["Product"] = product.GetProduct(prod_id).Description;
                        dr["Price"] = PendingOrdersDetails[i].UnitPrice;
                        dr["Quantity"] = PendingOrdersDetails[i].OrderQty;
                        dr["Total"] = PendingOrdersDetails[i].LineTotal;
                        dr["Discount"] = PendingOrdersDetails[i].UnitPriceDiscount;
                        dr["Grand Total"] = decimal.Parse(dr["Total"].ToString()) - decimal.Parse(dr["Discount"].ToString());
                        dtPendingOrdersDetail.Rows.Add(dr);
                        
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grdPendingOrderDetails.DataSource = dtPendingOrdersDetail;
            dtPendingOrdersDetail.AcceptChanges();
        }

        private void SetupPendingOrdersGrid(int selected)
        {
            if (dtPendingOrders == null)
                dtPendingOrders = new DataTable();
            dtPendingOrders.Columns.Add(new DataColumn("Nbr", typeof(int)));
            dtPendingOrders.Columns.Add(new DataColumn("ID", typeof(int)));
            dtPendingOrders.Columns.Add(new DataColumn("Customer", typeof(string)));
            dtPendingOrders.Columns.Add(new DataColumn("Order Date", typeof(DateTime)));
            dtPendingOrders.Columns.Add(new DataColumn("Due Date", typeof(DateTime)));
            dtPendingOrders.Columns.Add(new DataColumn("Ship Date", typeof(DateTime)));
            dtPendingOrders.Columns.Add(new DataColumn("Total", typeof(decimal)));
            dtPendingOrders.Columns.Add(new DataColumn("Balance", typeof(decimal)));
            dtPendingOrders.Columns.Add(new DataColumn("AddressID", typeof(int)));
            dtPendingOrders.Columns.Add(new DataColumn("CustomerID", typeof(int)));
            dtPendingOrders.Columns.Add(new DataColumn("BillToAddressID", typeof(int)));
            dtPendingOrders.Columns.Add(new DataColumn("Comment", typeof(string)));
            for (int i = 0; i < PendingOrders.Count; i++)
            {
                DataRow dr = dtPendingOrders.NewRow();
                dr["Nbr"] = i+1;
                dr["ID"] = PendingOrders[i].SalesOrderID;
                m_Customer = GetCustomer(PendingOrders[i].CustomerID);
                dr["Customer"] = m_Customer.Name;
                dr["Order Date"] = PendingOrders[i].OrderDate;
                dr["Due Date"] = PendingOrders[i].DueDate;
                dr["Ship Date"] = PendingOrders[i].ShipDate;
                dr["Total"] = PendingOrders[i].SubTotal;
                dr["Balance"] = GetCustomerBalance(PendingOrders[i].CustomerID, PendingOrders[i].ShipDate);
                dr["CustomerID"] = PendingOrders[i].CustomerID;
                dr["AddressID"] = PendingOrders[i].ShipToAddressID;
                dr["BillToAddressID"] = PendingOrders[i].BillToAddressID;
                if (PendingOrders[i].Comment == "Mobile Order")
                    dr["Comment"] = "";
                else
                    dr["Comment"] = PendingOrders[i].Comment;
                dtPendingOrders.Rows.Add(dr);
            }
            int rows = dtPendingOrders.Rows.Count;
            if (rows == 0)
                return;
            int cols = dtPendingOrders.Columns.Count;
            grdPendingOrderHeader.DataSource = dtPendingOrders;
            dtPendingOrders.AcceptChanges();
            grdPendingOrderHeader.Rows[0].Selected = false;
            grdPendingOrderHeader.Rows[selected].Selected = true;
            grdPendingOrderHeader.FirstDisplayedScrollingRowIndex = selected;
            grdPendingOrderHeader.Columns["Nbr"].Width = 30;
            grdPendingOrderHeader.Columns["ID"].Width = 60;
            grdPendingOrderHeader.Columns["Customer"].Width = 180;
            grdPendingOrderHeader.Columns["Comment"].Width = 140;
            grdPendingOrderHeader.Columns["Total"].DefaultCellStyle.Format = "c";
            grdPendingOrderHeader.Columns["Balance"].DefaultCellStyle.Format = "c";
            grdPendingOrderHeader.Columns["AddressID"].Visible = false;
            grdPendingOrderHeader.Columns["CustomerID"].Visible = false;
            grdPendingOrderHeader.Columns["BillToAddressID"].Visible = false;

            grdPendingOrderHeader.Columns["Nbr"].ReadOnly = true;
            grdPendingOrderHeader.Columns["ID"].ReadOnly = true;
            grdPendingOrderHeader.Columns["Customer"].ReadOnly = true;
            grdPendingOrderHeader.Columns["Total"].ReadOnly = true;
            grdPendingOrderHeader.Columns["Balance"].ReadOnly = true;
            PendingOrderClick(grdPendingOrderHeader.Rows[0]);

            
        }
        private void SetupViewOrdersGrid()
        {
            if (dtViewOrders == null)
                dtViewOrders = new DataTable();
            dtViewOrders.Columns.Add(new DataColumn("Nbr", typeof(int)));
            dtViewOrders.Columns.Add(new DataColumn("ID", typeof(int)));
            dtViewOrders.Columns.Add(new DataColumn("Customer", typeof(string)));
            dtViewOrders.Columns.Add(new DataColumn("Order Date", typeof(DateTime)));
            dtViewOrders.Columns.Add(new DataColumn("Due Date", typeof(DateTime)));
            dtViewOrders.Columns.Add(new DataColumn("Ship Date", typeof(DateTime)));
            dtViewOrders.Columns.Add(new DataColumn("Total", typeof(decimal)));
            dtViewOrders.Columns.Add(new DataColumn("Balance", typeof(decimal)));
            dtViewOrders.Columns.Add(new DataColumn("Status", typeof(string)));
            dtViewOrders.Columns.Add(new DataColumn("AddressID", typeof(int)));
            dtViewOrders.Columns.Add(new DataColumn("CustomerID", typeof(int)));
            dtViewOrders.Columns.Add(new DataColumn("BillToAddressID", typeof(int)));
            dtViewOrders.Columns.Add(new DataColumn("Comment", typeof(string)));
            for (int i = 0; i < ViewOrders.Count; i++)
            {
                DataRow dr = dtViewOrders.NewRow();
                dr["Nbr"] = i + 1;
                dr["ID"] = ViewOrders[i].SalesOrderID;
                m_Customer = GetCustomer(ViewOrders[i].CustomerID);
                dr["Customer"] = m_Customer.Name;
                dr["Order Date"] = ViewOrders[i].OrderDate;
                dr["Due Date"] = ViewOrders[i].DueDate;
                dr["Ship Date"] = ViewOrders[i].ShipDate;
                dr["Total"] = ViewOrders[i].SubTotal;
                dr["Balance"] = GetCustomerBalance(ViewOrders[i].CustomerID, ViewOrders[i].ShipDate);
                dr["Status"] = GetOrderStatus((int)ViewOrders[i].Status);
                dr["AddressID"] = ViewOrders[i].ShipToAddressID;
                dr["CustomerID"] = ViewOrders[i].CustomerID;
                dr["BillToAddressID"] = ViewOrders[i].BillToAddressID;
                dr["Comment"] = ViewOrders[i].Comment;
                dtViewOrders.Rows.Add(dr);
            }
            int rows = dtViewOrders.Rows.Count;
            int cols = dtViewOrders.Columns.Count;
            grdViewOrderHeader.DataSource = dtViewOrders;
            grdViewOrderHeader.Columns["Nbr"].Width = 30;
            grdViewOrderHeader.Columns["ID"].Width = 50;
            grdViewOrderHeader.Columns["Customer"].Width = 180;
            grdViewOrderHeader.Columns["Total"].DefaultCellStyle.Format = "c";
            grdViewOrderHeader.Columns["Balance"].DefaultCellStyle.Format = "c";
            grdViewOrderHeader.Columns["AddressID"].Visible = false;
            grdViewOrderHeader.Columns["CustomerID"].Visible = false;
            grdViewOrderHeader.Columns["BillToAddressID"].Visible = false;

            grdViewOrderHeader.Columns["Nbr"].ReadOnly = true;
            grdViewOrderHeader.Columns["ID"].ReadOnly = true;
            grdViewOrderHeader.Columns["Customer"].ReadOnly = true;
            grdViewOrderHeader.Columns["Total"].ReadOnly = true;
            grdViewOrderHeader.Columns["Balance"].ReadOnly = true;
        }
        private void SetupInvoiceHeaderGrid()
        {
            try
            {
               // if (dtInvoiceHeader == null)
                dtInvoiceHeader = new DataTable();
                //dtInvoiceHeader.Rows.Clear();
                //dtInvoiceHeader.Columns.Clear();
                dtInvoiceHeader.Columns.Add(new DataColumn("Nbr", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("InvoiceID", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Customer", typeof(string)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Invoice Nbr", typeof(string)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Order ID", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Invoice Date", typeof(DateTime)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Due Date", typeof(DateTime)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Payments", typeof(decimal)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Balance", typeof(decimal)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Cus. Balance", typeof(decimal)));
                dtInvoiceHeader.Columns.Add(new DataColumn("AddressID", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("BillToAddressID", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Comment", typeof(string)));
                dtInvoiceHeader.Columns.Add(new DataColumn("CustomerID", typeof(int)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Ship Date", typeof(DateTime)));
                dtInvoiceHeader.Columns.Add(new DataColumn("Total", typeof(decimal)));
                dtInvoiceHeader.Columns.Add(new DataColumn("ID", typeof(int)));
                

                for (int i = 0; i < InvoiceHeader.Count; i++)
                {
                    DataRow dr = dtInvoiceHeader.NewRow();
                    dr["Nbr"] = i + 1;
                    dr["InvoiceID"] = InvoiceHeader[i].InvoiceID;
                    InvoiceCustomer = GetCustomerByOrderId(InvoiceHeader[i].SaleOrderID);
                    dr["Customer"] = InvoiceCustomer.Name;
                    dr["CustomerID"] = InvoiceCustomer.CustomerID;
                    dr["Invoice Nbr"] = InvoiceHeader[i].InvoiceNumber;
                    dr["Order ID"] = InvoiceHeader[i].SaleOrderID;
                    dr["ID"] = InvoiceHeader[i].SaleOrderID;
                    dr["Invoice Date"] = InvoiceHeader[i].InvoiceDate;
                    dr["Due Date"] = InvoiceHeader[i].DueDate;
                    dr["Ship Date"] = InvoiceHeader[i].DueDate;
                    dr["Amount"] = InvoiceHeader[i].SubTotal;
                    dr["Total"] = InvoiceHeader[i].SubTotal;
                    Payment p = new Payment();
                    decimal tot_payments = p.GetTotalPaymentsByInvoiceId(InvoiceHeader[i].InvoiceID);
                    dr["Payments"] = tot_payments;
                    dr["Balance"] = InvoiceHeader[i].SubTotal - tot_payments;
                    dr["Cus. Balance"] = GetCustomerBalance(InvoiceCustomer.CustomerID, InvoiceHeader[i].InvoiceDate);
                    dr["AddressID"] =  InvoiceHeader[i].BillToAddressID;
                    dr["BillToAddressID"] = InvoiceHeader[i].BillToAddressID;
                    dr["Comment"] = InvoiceHeader[i].Comment;
                    
                    p = null;
                    dtInvoiceHeader.Rows.Add(dr);
                }
                int rows = dtInvoiceHeader.Rows.Count;
                int cols = dtInvoiceHeader.Columns.Count;
                grdInvoices.DataSource = dtInvoiceHeader;
               
                grdInvoices.Columns["Nbr"].Width = 40;
                grdInvoices.Columns["Invoice Nbr"].Width = 100;
                grdInvoices.Columns["Customer"].Width = 260;
                grdInvoices.Columns["Amount"].DefaultCellStyle.Format = "c";
                grdInvoices.Columns["Amount"].Width = 70;
                grdInvoices.Columns["Payments"].DefaultCellStyle.Format = "c";
                grdInvoices.Columns["Payments"].Width = 70;
                grdInvoices.Columns["Balance"].DefaultCellStyle.Format = "c";
                grdInvoices.Columns["Balance"].HeaderText = "Inv. Balance";
                grdInvoices.Columns["Cus. Balance"].DefaultCellStyle.Format = "c";
                grdInvoices.Columns["Balance"].Width = 70;
                grdInvoices.Columns["Cus. Balance"].Width = 70;
                grdInvoices.Columns["Order ID"].Visible = false;
                grdInvoices.Columns["InvoiceID"].Visible = false;
                grdInvoices.Columns["AddressID"].Visible = false;
                grdInvoices.Columns["BillToAddressID"].Visible = false;
                grdInvoices.Columns["Comment"].Visible = false;
                grdInvoices.Columns["CustomerID"].Visible = false;
                grdInvoices.Columns["Ship Date"].Visible = false;
                grdInvoices.Columns["Total"].Visible = false;
                grdInvoices.Columns["ID"].Visible = false;


                grdInvoices.Columns["Nbr"].ReadOnly = true;
                grdInvoices.Columns["Customer"].ReadOnly = true;
                grdInvoices.Columns["Amount"].ReadOnly = true;
                grdInvoices.Columns["Balance"].ReadOnly = true;
                grdInvoices.Columns["Cus. Balance"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupPaymentsGrid()
        {
            dtInvoicePayments = new DataTable();
            string invoiceid = "0";
            if (dtInvoiceHeader.Rows.Count > 0)
            {
                DataGridViewRow row = grdInvoices.CurrentRow;
                invoiceid = row.Cells["InvoiceID"].Value.ToString();
            }
            Payment p = new Payment();
            DataSet ds = new DataSet();

            try
            {
                dtInvoicePayments.Columns.Add(new DataColumn("Nbr", typeof(int)));
                dtInvoicePayments.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                dtInvoicePayments.Columns.Add(new DataColumn("Pay. Type", typeof(string)));
                dtInvoicePayments.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dtInvoicePayments.Columns.Add(new DataColumn("Check Nbr", typeof(string)));

                string where = "invoiceid=" + invoiceid;
                string orderby = "paymentid";
                ds = p.GetPaymentsDataSet(where, orderby);
                int i = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow dRow = dtInvoicePayments.NewRow();
                    dRow["Nbr"] = i++;
                    dRow["Date"] = dr["PaymentDate"];
                    dRow["Pay. Type"] = p.GetPaymentCodeDescription(dr["PaymentType"].ToString());
                    dRow["Amount"] = dr["Amount"];
                    dRow["Check Nbr"] = dr["CheckNumber"];
                    dtInvoicePayments.Rows.Add(dRow);
                }
                grdInvoicePayments.DataSource = dtInvoicePayments;
                grdInvoicePayments.Columns["Nbr"].Width = 40;
                grdInvoicePayments.Columns["Pay. Type"].Width = 100;
                grdInvoicePayments.Columns["Amount"].Width = 70;
                grdInvoicePayments.Columns["Check Nbr"].Width = 270;
                grdInvoicePayments.Columns["Check Nbr"].HeaderText = "Check Info";
                grdInvoicePayments.Columns["Date"].Width = 70;
                grdInvoicePayments.Columns["Amount"].DefaultCellStyle.Format = "c";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                p = null;
                ds = null;
            }
        }
        private Customer GetCustomerByOrderId(int order_id)
        {
            Customer cus = new Customer();
            try
            {
                SalesInvoiceHeader sih = new SalesInvoiceHeader();
                cus = sih.GetCustomerByOrderID(order_id);
                return (cus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (cus);
        }
        private string GetOrderStatus(int status)
        {
            string strStatus = "";
            foreach (DataRow dr in dtOrderStatus.Rows)
            {
                if (Int32.Parse(dr["ID"].ToString()) == status)
                {
                    strStatus = dr["Name"].ToString();
                    break;
                }
            }
            return (strStatus);
        }
        private Customer GetCustomer(int CustID)
        {
            for (int i = 0; i < m_CustomerCollection.Count; i++)
            {
                if(CustID == m_CustomerCollection[i].CustomerID)
                {
                    return m_CustomerCollection[i];
                }
            }
            return (new Customer());
        }
        
        private Address GetCustomerAddress()
        {
            Address add = new Address();
            try
            {
                for (int i = 0; i < m_AddressCollection.Count; i++)
                {
                    if (m_AddressID == m_AddressCollection[i].AddressID)
                    {
                        return (m_AddressCollection[i]);
                    }
                }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return add;
           }
            return add;
        }
        private Address GetCustomerAddress(int address_id)
        {
            Address add = new Address();
            try
            {
                for (int i = 0; i < m_AddressCollection.Count; i++)
                {
                    if (address_id == m_AddressCollection[i].AddressID)
                    {
                        return (m_AddressCollection[i]);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return add;
            }
            return add;
        }
        private void AddressToTextBoxes(Address add)
        {
            try
            {
                txtStreetAddress.Text = add.AddressLine1;
                txtCity.Text = add.City;
                txtState.Text = add.StateProvince;
                txtPostalCode.Text  = add.PostalCode;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            
        }
        private void UpdateOrderHeaderTotal(DataTable dtDetails, DataTable dtHeader, int OrderId, DataRowState state)
        {
            decimal tot = 0;
            foreach (DataRow row in dtDetails.Rows)
            {
                tot += decimal.Parse(row["Grand Total"].ToString());
            }
            foreach (DataRow dRow in dtHeader.Rows)
            {
                if (OrderId == Int32.Parse(dRow["ID"].ToString()))
                {
                    dRow["Total"] = tot;
                }
            }
            
        }
        private void DeleteOrderDetails(DataTable detail,DataTable header, DataGridView grdHeader, DataGridView grdDetails, SalesOrderHeaderCollection HeaderCol)
        {
            try
            {
                UpdateOrderHeaderTotal(detail, header, grdHeader, HeaderCol);
                int rowindex = grdDetails.CurrentRow.Index;
                if (rowindex >= grdDetails.Rows.Count)
                    rowindex = 0;
                header.AcceptChanges();
                grdDetails.Rows[rowindex].Selected = true;
              //  grdDetails.CurrentRow.Index = rowindex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtPendingOrdersDetail_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            DeleteOrderDetails(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader, grdPendingOrderDetails, PendingOrders);
            //UpdateOrderHeaderTotal(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader,PendingOrders);
            //int rowindex = grdPendingOrderDetails.CurrentRow.Index;
            //if (rowindex >= grdPendingOrderDetails.Rows.Count)
            //    rowindex = 0;
            //dtPendingOrders.AcceptChanges();
            //grdPendingOrderDetails.Rows[rowindex].Selected = true;
      
        }
        private void dtPendingOrdersDetail_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            SalesOrderDetail sod = new SalesOrderDetail();
            try
            {
                string id = e.Row["SalesOrderDetailID"].ToString();
                if (id == "")
                {
                    MessageBox.Show("Row can't be deleted at this time. Try refreshing the data");
                    return;
                }
                int SalesOrderId = Int32.Parse(e.Row["SalesOrderID"].ToString());

                string where = "SalesOrderDetailID=" + id;
                sod.DeleteSalesOrderDetailsDynamic(where);
                //UpdateOrderAfterDelete(e, (DataTable)sender, grdPendingOrderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sod = null;
            }
            
        }
        private void dtPendingOrders_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                string id = e.Row["ID"].ToString();
                DataGridViewRow row = grdPendingOrderHeader.CurrentRow;
                SavePendingOrderHeader(dtPendingOrdersDetail, dtPendingOrders, row,PendingOrders);


                //dr["ID"] = PendingOrders[i].SalesOrderID;
                //m_Customer = GetCustomer(PendingOrders[i].CustomerID);
                //dr["Customer"] = m_Customer.Name;
                //dr["Order Date"] = PendingOrders[i].OrderDate;
                //dr["Due Date"] = PendingOrders[i].DueDate;
                //dr["Ship Date"] = PendingOrders[i].ShipDate;
                //dr["Total"] = PendingOrders[i].SubTotal;
                //dr["CustomerID"] = PendingOrders[i].CustomerID;
                //dr["BillToAddressID"] = PendingOrders[i].BillToAddressID;
                //dr["Comment"] = PendingOrders[i].Comment;
                // UpdateOrderHeaderTotal(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader);

            }
        }
        private void dtPendingOrdersDetail_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                string id = e.Row["SalesOrderDetailID"].ToString();
                string orderid = e.Row["SalesOrderID"].ToString();
                UpdatePendingOrderDetails(e.Row);
                foreach (DataRow r in dtPendingOrders.Rows)
                {
                    if (orderid == r["ID"].ToString())
                    {
                        int customerid = Int32.Parse(r["CustomerID"].ToString());
                        DateTime shipdate = DateTime.Parse(r["Ship Date"].ToString());
                        r["Balance"] = GetCustomerBalance(customerid, shipdate);
                        txtPendingOrderBalance.Text = String.Format("{0:c}", GetCustomerBalance(customerid, shipdate));
                        break;
                    }
                }
                               
                // dtPendingOrdersDetail.AcceptChanges();
               // grdPendingOrderDetails.Refresh();
               // UpdateOrderHeaderTotal(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader);
                
            }
            else if (e.Row.RowState == DataRowState.Added)
            {
               // string id = e.Row["ID"].ToString();


            }
            else if (e.Row.RowState == DataRowState.Deleted)
            {
              //  string id = e.Row["ID"].ToString();
            }
            
        }
        private void AddPendingOrderDetails(DataRow row)
        {
            SalesOrderDetail sod = new SalesOrderDetail();
            try
            {
                sod.SalesOrderID = Int32.Parse(row["SalesOrderID"].ToString());
                sod.CarrierTrackingNumber = row["CarrierTrackingNumber"].ToString();
                if (row["SpecialOfferID"] != DBNull.Value)
                    sod.SpecialOfferID = Int32.Parse(row["SpecialOfferID"].ToString());
                else
                    sod.SpecialOfferID = 0;
                sod.ProductID = Int32.Parse(row["ID"].ToString());
                sod.OrderQty = short.Parse(row["Quantity"].ToString());
                sod.UnitPrice = decimal.Parse(row["Price"].ToString());
                sod.UnitPriceDiscount = decimal.Parse(row["Discount"].ToString());
                sod.LineTotal = decimal.Parse(row["Grand Total"].ToString());
                sod.AddSalesOrderDetail(sod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sod = null;
            }
        }
        private void UpdatePendingOrderDetails(DataRow row)
        {
            if (row.RowState == DataRowState.Deleted)
                return;
            SalesOrderDetail sod = new SalesOrderDetail();
            try
            {
                sod.SalesOrderDetailID = Int32.Parse(row["SalesOrderDetailID"].ToString());
                sod.SalesOrderID = Int32.Parse(row["SalesOrderID"].ToString());
                sod.CarrierTrackingNumber = row["CarrierTrackingNumber"].ToString();
                if (row["SpecialOfferID"] != DBNull.Value)
                    sod.SpecialOfferID = Int32.Parse(row["SpecialOfferID"].ToString());
                else
                    sod.SpecialOfferID = 0;
                sod.ProductID = Int32.Parse(row["ID"].ToString());
                sod.OrderQty = short.Parse(row["Quantity"].ToString());
                sod.UnitPrice = decimal.Parse(row["Price"].ToString());
                sod.UnitPriceDiscount = decimal.Parse(row["Discount"].ToString());
                sod.LineTotal = decimal.Parse(row["Grand Total"].ToString());
                sod.UpdateSalesOrderDetail(sod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sod = null;
            }

            //dbm.AddParameters(0, "@SalesOrderID", SOD.SalesOrderID);
            //dbm.AddParameters(1, "@SalesOrderDetailID", SOD.SalesOrderDetailID);
            //dbm.AddParameters(2, "@CarrierTrackingNumber", SOD.CarrierTrackingNumber);
            //dbm.AddParameters(3, "@OrderQty", SOD.OrderQty);
            //dbm.AddParameters(4, "@ProductID", SOD.ProductID);
            //dbm.AddParameters(5, "@SpecialOfferID", SOD.SpecialOfferID);
            //dbm.AddParameters(6, "@UnitPrice", SOD.UnitPrice);
            //dbm.AddParameters(7, "@UnitPriceDiscount", SOD.UnitPriceDiscount);
            //dbm.AddParameters(8, "@LineTotal", SOD.LineTotal);
            //dbm.AddParameters(9, "@ModifiedDate", DateTime.Now);

            //dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            //dt.Columns.Add(new DataColumn("Quantity", typeof(short)));
            //dt.Columns.Add(new DataColumn("Total", typeof(decimal)));
            //dt.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            //dt.Columns.Add(new DataColumn("Grand Total", typeof(decimal)));
        }
        private void btnAdditems_Click(object sender, EventArgs e)
        {
            frmProductPicker pick = new frmProductPicker(OrderType.SaleOrder,0);
            DataTable dt = new DataTable();
            try
            {
                dt = pick.GetSelectedProducts();
                if (dt == null) return;
                if (dt.Rows.Count < 1) return;
                pick.Close();
                SetupGrid(dt);
                DataTable newtable = dt.Clone();
                DataRow[] selectedRows = dt.Select("Quantity <> 0");
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    newtable.ImportRow(selectedRows[i]);
                }
                foreach (DataRow dr in newtable.Rows)
                {
                    int qty = 0;
                    try { qty = Int32.Parse(dr["Quantity"].ToString()); }
                    catch { qty = 0; }
                    if ( qty > 0)
                    {
                        if (!(dr["Total"] is DBNull))
                            m_OrderTotal += decimal.Parse(dr["Total"].ToString());
                        if(UpdateQuantityIfExist( dr))
                        {
                            continue;
                        }

                        DataRow row = dtProducts.NewRow();
                        row["ProductId"] = dr["ProductId"];
                        row["Name"] = dr["Name"];
                        row["SpecialOfferID"] = dr["SpecialOfferID"];
                        row["SpecialOfferDesc"] = dr["SpecialOfferDesc"];
                        row["Quantity"] = dr["Quantity"];
                        row["Price"] = dr["Price"];
                        int productid = Int32.Parse(dr["ProductId"].ToString());
                        int quantity = Int32.Parse(dr["Quantity"].ToString());
                        decimal discount = GetDiscountPrice(productid, quantity);
                        decimal total = decimal.Parse(dr["Total"].ToString());
                        row["Discount"] = discount;
                        row["Total"] = total - discount;
                        m_OrderTotal -= discount;
                        //for (int i = 0; i < dt.Columns.Count; i++)
                        //{
                        //    row[i+1] = dr[i];
                        //}
                        int rows_count = dtProducts.Rows.Count;
                        row["Nbr"] = rows_count+1;
                        dtProducts.Rows.Add(row);
                    }
                }
                grdOrderDetails.DataSource = dtProducts;
                SetupGridColumns();
                //txtOrderTotal.Text = m_OrderTotal.ToString();
                txtOrderTotal.Text = String.Format("{0:c}", m_OrderTotal); 
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupGridColumns()
        {
            grdOrderDetails.Columns["Nbr"].ReadOnly = true;
            //grdOrderDetails.Columns["INSTOCK"].ReadOnly = true;
            grdOrderDetails.Columns["NAME"].ReadOnly = true;
            grdOrderDetails.Columns["NAME"].Width = 250;
            grdOrderDetails.Columns["Nbr"].Width = 40;
            
            grdOrderDetails.Columns["PRODUCTID"].Visible = false;
            grdOrderDetails.Columns["SpecialOfferId"].Visible = false;
            grdOrderDetails.Columns["SpecialOfferDesc"].Width = 180;
            grdOrderDetails.Columns["SpecialOfferDesc"].HeaderText = "Special Offer";
            //grdOrderDetails.Columns["REORDERPOINT"].Visible = false;
            //grdOrderDetails.Columns["PRODUCT_CODE"].Visible = false;
            //grdOrderDetails.Columns["No Cases"].Visible = false;
            //grdOrderDetails.Columns["Unit/Case"].Visible = false;

            grdOrderDetails.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdOrderDetails.Columns["PRICE"].DefaultCellStyle.Format = "c";
            grdOrderDetails.Columns["PRICE"].Width = 70;
            grdOrderDetails.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdOrderDetails.Columns["Total"].DefaultCellStyle.Format = "c";
            grdOrderDetails.Columns["Discount"].DefaultCellStyle.Format = "c";
            grdOrderDetails.Columns["Discount"].Width = 70;
            grdOrderDetails.Columns["Quantity"].Width = 70;

            grdOrderDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdOrderDetails.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdOrderDetails.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdOrderDetails.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
        }
        private bool UpdateQuantityIfExist(DataRow row)
        {
            foreach (DataRow dr in dtProducts.Rows)
            {
                if (Int32.Parse(dr["ProductID"].ToString()) == Int32.Parse(row["ProductID"].ToString()))
                {
                    dr["Quantity"] = (int)dr["Quantity"] + (int)row["Quantity"];
                    dr["Total"] = (decimal)dr["Total"] + (decimal)row["Total"];
                    return true;

                }
            }
            return false;
        }
        private void UpdateTotalOrder(int index,bool removed)
        {
            if (index < 0)
                return;
            try
            {
                int rows_count = dtProducts.Rows.Count;
                int grid_rows = grdOrderDetails.Rows.Count;
                m_OrderTotal = 0;
                foreach (DataRow r in dtProducts.Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        m_OrderTotal += decimal.Parse(r["Total"].ToString());
                    }
                }
                      
                txtOrderTotal.Text = String.Format("{0:c}", m_OrderTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupGrid(DataTable dt)
        {
           // dtProducts.Columns.Clear();
            if (dtProducts.Columns.Count <= 1)
            {
                dtProducts.Columns.Add(new DataColumn("Nbr", typeof(int)));
                dtProducts.Columns.Add(new DataColumn("ProductID", typeof(int)));
                dtProducts.Columns.Add(new DataColumn("Name", typeof(string)));
                dtProducts.Columns.Add(new DataColumn("SpecialOfferID", typeof(int)));
                dtProducts.Columns.Add(new DataColumn("SpecialOfferDesc", typeof(string)));
                dtProducts.Columns.Add(new DataColumn("Quantity", typeof(int)));
                dtProducts.Columns.Add(new DataColumn("Price", typeof(decimal)));
                dtProducts.Columns.Add(new DataColumn("Discount", typeof(decimal)));
                dtProducts.Columns.Add(new DataColumn("Total", typeof(decimal)));
                //dtProducts.Columns.Add(dt.Columns["Name"]);
                //dtProducts.Columns.Add(dt.Columns[2]);
                //dtProducts.Columns.Add(dt.Columns[3]);
                //dtProducts.Columns.Add(dt.Columns[4]);
                //dtProducts.Columns.Add(dt.Columns[5]);
                //dtProducts.Columns.Add(dt.Columns[6]);
                //dtProducts.Columns.Add(dt.Columns[7]);
                //dtProducts.Columns.Add(dt.Columns[8]);
                //dtProducts.Columns.Add(dt.Columns[9]);

                //foreach (DataColumn dc in dt.Columns)
                //{
                //    dtProducts.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
                //}
            }
        }
        private void ClearAddressTextBoxes()
        {
            txtStreetAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostalCode.Text = "";
        }
        private Customer GetCustomerData()
        {
            try
            {
                for (int i = 0; i < m_CustomerCollection.Count; i++)
                {
                    if (m_CustomerID == m_CustomerCollection[i].CustomerID)
                    {
                        return m_CustomerCollection[i];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new Customer() ;
        }
        private DateTime GetDeliveryDate(Customer cus)
        {
            DateTime DeliveryDate = DateTime.Today.AddDays(7);
            DayOfWeek delivery_day = (DayOfWeek)cus.DeliveryDay;
            DateTime today = DateTime.Today;
            int i = 1;
            while (i < 7)
            {
                if (today.DayOfWeek == delivery_day)
                {
                    return(today);
                }
                today = today.AddDays(1);
                i++;
            }
            return (DeliveryDate);
        }
        private void CustomerToComboBoxes(Customer cus)
        {
            try
            {
                txtCreditLimit.Text = cus.CreditLimit.ToString();
                if (System.Configuration.ConfigurationManager.AppSettings["FixedDeliveryDay"] == "N")
                {
                    string strPrepDays = System.Configuration.ConfigurationManager.AppSettings["PreparationDays"];
                    if (strPrepDays != null)
                    {
                        int iPrepDays = Int32.Parse(strPrepDays);
                        dtDeliveryDate.Value = dtOrderDate.Value.AddDays(iPrepDays);
                    }
                }
                else
                {
                    dtDeliveryDate.Value = GetDeliveryDate(cus);
                }
         
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCustomerName.SelectedIndex > 0)
                {
                    int index = cmbCustomerName.SelectedIndex;
                    m_CustomerID = Int32.Parse(cmbCustomerName.SelectedValue.ToString());
                    int id = m_CustomerCollection[index].CustomerID;
                    m_AddressID = GetCustomerAddressId();
                    Address add = GetCustomerAddress();
                    AddressToTextBoxes(add);
                    Customer cus = GetCustomerData();
                    CustomerToComboBoxes(cus);
                }
                else
                {
                    ClearAddressTextBoxes();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetCustomerAddressId()
        {
            int address_id = 0;
            try
            {
                for (int i = 0; i < m_CustomerCollection.Count; i++)
                {
                    if (m_CustomerID == m_CustomerCollection[i].CustomerID)
                    {
                        return m_CustomerCollection[i].AddressID;
                    }
                }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return address_id;
        }
        private int GetCustomerAddressId(int cust_id, string add_type)
        {
            int address_id = 0;
            try
            {
                for (int i = 0; i < m_CustomerCollection.Count; i++)
                {
                    if (cust_id == m_CustomerCollection[i].CustomerID)
                    {
                        if (add_type == "billing")
                            return m_CustomerCollection[i].BillingAddressID;
                        else
                            return m_CustomerCollection[i].AddressID;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return address_id;
        }
        private void grdOrderDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }
        //private void dtPendingOrdersDetail_RowDeleting(object sender, DataRowChangeEventArgs e)
        //{
        //    /*int curr_row = grdPendingOrderHeader.CurrentRow.Index;
            
        //    try
        //    {
        //        decimal total_order = decimal.Parse(dtPendingOrders.Rows[curr_row]["Total"].ToString());
        //        decimal tot = decimal.Parse(e.Row["Grand Total"].ToString());
        //        total_order -= tot;
        //        dtPendingOrders.Rows[curr_row]["Total"] = total_order;
        //    }
        //    catch
        //    {

        //    }*/
        //    UpdateOrderAfterDelete(e,dtPendingOrders, grdPendingOrderHeader);
        //}
        private void dtViewOrdersDetails_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            //     UpdateOrderAfterDelete(e, dtViewOrders, grdViewOrderHeader);
        }
        private void dtViewOrdersDetails_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            decimal total = 0;
            int cur_row = grdViewOrderHeader.CurrentRow.Index;
            foreach (DataRow r in dtViewOrdersDetails.Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    total += decimal.Parse(r["Grand Total"].ToString());
                }
            }
            dtViewOrders.Rows[cur_row]["Total"] = total;
            dtViewOrdersDetails.AcceptChanges();
            //dgViewOrdersDetail.Refresh();
            //int orderid = dtViewOrders.Rows[cur_row]["Total"].ToString()
            //DeleteOrderDetails(dtViewOrdersDetails, dtViewOrders, grdViewOrderHeader, dgViewOrdersDetail, ViewOrders);
            //UpdateOrderHeaderTotal(detail, header, grdHeader, HeaderCol);
            //int rowindex = grdDetails.CurrentRow.Index;
            //if (rowindex >= grdDetails.Rows.Count)
            //    rowindex = 0;
            //grdDetails.Rows[rowindex].Selected = true;
            //dtViewOrdersDetails.AcceptChanges();

        }
        private void UpdateOrderAfterDelete(DataRowChangeEventArgs e,DataTable dt,DataGridView grd)
        {
            int curr_row = grd.CurrentRow.Index;

            try
            {
                decimal total_order = decimal.Parse(dt.Rows[curr_row]["Total"].ToString());
                decimal tot = decimal.Parse(e.Row["Grand Total"].ToString());
                total_order -= tot;
                dt.Rows[curr_row]["Total"] = total_order;
                dt.AcceptChanges();
                grd.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtProducts_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            int curr_row = grdOrderDetails.CurrentRow.Index;

            try
            {
                decimal tot = decimal.Parse(e.Row["Total"].ToString());
                m_OrderTotal -= tot;
                txtOrderTotal.Text = string.Format("{0:c}", m_OrderTotal);
            }
            catch 
            {
               
            }
        }
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {

                //int cur_row = grdPendingOrderHeader.CurrentRow.Index;
                SaveOrder();
                LoadFormData(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveOrder()
        {
            if (!ValidSaleOrder())
            {
                MessageBox.Show("Data missing from required fields", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (m_OrderTotal == 0)
            {
                MessageBox.Show("Can not save an order with zero total", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (grdOrderDetails.Rows.Count < 1)
            {
                MessageBox.Show("Can not save. No items selected", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SalesOrderHeader soh = new SalesOrderHeader();
            Address add = new Address();
            try
            {
                TextBoxesToAddress(add);
                int add_id = add.UpdateAddress(add);
                if (add_id == 0)
                    soh.ShipToAddressID = m_AddressID;
                else
                    soh.ShipToAddressID = add_id;
                if (soh.ShipToAddressID == 0)
                {
                    MessageBox.Show("Shipping address was not saved successfuly", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                soh.BillToAddressID = soh.ShipToAddressID;
                soh.CustomerID = Int32.Parse(cmbCustomerName.SelectedValue.ToString());
                soh.OrderDate = DateTime.Parse(dtOrderDate.Value.ToShortDateString());
                soh.DueDate = DateTime.Parse(dtDeliveryDate.Value.ToShortDateString());
                soh.Status = (byte)OrderStatus.Pending;
                soh.TotalDue = m_OrderTotal;
                soh.SubTotal = m_OrderTotal;
                soh.Comment = txtComments.Text;
                if (cmbPaymentMethod.Items.Count > 0 && cmbPaymentMethod.SelectedValue != null)
                    soh.PaymentMethodID = Int32.Parse(cmbPaymentMethod.SelectedValue.ToString());
                else
                    soh.PaymentMethodID = 0;

                soh.TaxAmt = 0;
                soh.ShipDate = soh.DueDate;
                soh.SalesPersonID = 0;
                soh.Freight = 0;
                soh.CurrencyRateID = 0;
                soh.OnlineOrderFlag = false;
                soh.SalesOrderNumber = "";
                soh.PurchaseOrderNumber = "";
                soh.ShipMethodID = 0;

                soh.SalesOrderID = soh.AddSalesOrderHeader(soh);
                SaveSaleOrderDetails(soh.SalesOrderID);
                MessageBox.Show("Order saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                soh = null;
            }

           
        }
        private void SaveSaleOrderDetails(int sale_order_id)
        {
            SalesOrderDetail sod = new SalesOrderDetail();
            try
            {
                foreach (DataRow dr in dtProducts.Rows)
                {
                    if (dr["Quantity"] != null && Int32.Parse(dr["Quantity"].ToString()) != 0)
                    {
                        sod.SalesOrderID = sale_order_id;
                        sod.ProductID = Int32.Parse(dr["PRODUCTID"].ToString());
                        sod.OrderQty = short.Parse(dr["Quantity"].ToString());
                        sod.UnitPrice = decimal.Parse(dr["PRICE"].ToString());
                        sod.UnitPriceDiscount = decimal.Parse(dr["Discount"].ToString());
                        if (dr["SpecialOfferID"] != DBNull.Value)
                        {
                            sod.SpecialOfferID = Int32.Parse(dr["SpecialOfferID"].ToString());
                        }
                        else
                        {
                            sod.SpecialOfferID = 0;
                        }
                        sod.LineTotal = (sod.OrderQty * sod.UnitPrice) - sod.UnitPriceDiscount;
                        sod.CarrierTrackingNumber = "";
                        sod.AddSalesOrderDetail(sod);
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                sod = null;
            }
            
        }
        private decimal GetDiscountPrice(int productid, int quantity)
        {
            decimal ret = 0;
            SpecialOfferProduct sop = new SpecialOfferProduct();
            DataSet ds = new DataSet();
            ds = sop.GetDiscountByProduct(productid, quantity);
            if (ds != null)
            {
                int rows = ds.Tables[0].Rows.Count;
                if (rows == 0)
                    return (0);
                decimal discount = decimal.Parse(ds.Tables[0].Rows[0]["discountpct"].ToString());
                string discount_type = ds.Tables[0].Rows[0]["type"].ToString();
                if (discount_type == "V")
                {
                    return (discount * quantity);
                }
            }
            return ret;
        }
        private void TextBoxesToAddress(Address add)
        {
            add.AddressLine1 = txtStreetAddress.Text;
            add.AddressLine2 = "";
            add.City = txtCity.Text;
            add.StateProvince = txtState.Text;
            add.PostalCode = txtPostalCode.Text;
        }
        private bool ValidSaleOrder()
        {
            bool ret = true;
            if (!ValidateComoBox(cmbCustomerName) ||
                !ValidateEmpty(txtStreetAddress))
            {
                return false;
            }
            try
            {
                foreach (DataRow dr in dtProducts.Rows)
                {
                    int quantity = short.Parse(dr["Quantity"].ToString());
                    decimal price = decimal.Parse(dr["PRICE"].ToString());
                    decimal tot = decimal.Parse(dr["Total"].ToString());
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        private void grdOrderDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int cur_row = grdOrderDetails.CurrentRow.Index;
            int quantity = 0;
            decimal price = 0;
            decimal total = 0;
            decimal discount = 0;
            try
            {
                if (dtProducts.Columns["Quantity"] != null && dtProducts.Columns["Quantity"].ToString().Trim() != String.Empty)
                    quantity = Int32.Parse(dtProducts.Rows[cur_row]["Quantity"].ToString());
                if (dtProducts.Columns["PRICE"] != null)
                    price = decimal.Parse(dtProducts.Rows[cur_row]["PRICE"].ToString());
                if (dtProducts.Columns["Total"] != null)
                    total = decimal.Parse(dtProducts.Rows[cur_row]["Total"].ToString());
                if (dtProducts.Columns["Discount"] != null)
                    discount = decimal.Parse(dtProducts.Rows[cur_row]["Discount"].ToString());
                if (e.ColumnIndex == grdOrderDetails.Columns["Quantity"].Index)
                {
                    total = price * quantity;
                }
                else if (e.ColumnIndex == grdOrderDetails.Columns["PRICE"].Index)
                {
                    total = price * quantity;
                }
                else if (e.ColumnIndex == grdOrderDetails.Columns["Total"].Index)
                {
                    price = total / quantity;
                }
                total -= discount;
                dtProducts.Rows[cur_row]["Quantity"] = quantity;
                dtProducts.Rows[cur_row]["PRICE"] = price;
                dtProducts.Rows[cur_row]["Total"] = total;
                dtProducts.Rows[cur_row]["Discount"] = discount;
                UpdateTotalOrder(cur_row,false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data entered", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Write(ex.Message, "SaveSaleOrder");
            }
                   
        }
        private void grdPendingOrderHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void grdPendingOrderHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void grdPendingOrderHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (grdPendingOrderHeader.CurrentRow != null)
            {
                DataGridViewRow row = grdPendingOrderHeader.CurrentRow;
                PendingOrderClick(row);
            }
            
        }
        private void FillShippingAddress(Address shipping_add)
        {
            txtShiptToStreet.Text = shipping_add.AddressLine1;
            txtShipToCity.Text = shipping_add.City;
            txtShipToState.Text = shipping_add.StateProvince;
            txtShipToZip.Text = shipping_add.PostalCode;
        }
        private void FillBillingAddress(Address billing_add)
        {
            txtBillToAddress.Text = billing_add.AddressLine1;
            txtBillToCity.Text = billing_add.City;
            txtBillToStateProvince.Text = billing_add.StateProvince;
            txtBillToZip.Text = billing_add.PostalCode;
        }
        private void grdPendingOrderHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPendingOrderHeader_Click(object sender, EventArgs e)
        {
            //DataGridViewRow row = grdPendingOrderHeader.CurrentRow;
            //PendingOrderClick(row);
        }
        private void PendingOrderClick(DataGridViewRow row)
        {
            if (grdPendingOrderHeader.Rows.Count <= 0)
                return;
            try
            {
                int cur_row = row.Index;
                //if (cur_row < 0)
                    //cur_row = grdPendingOrderHeader.CurrentRow.Index;
                if (cur_row >= PendingOrders.Count)
                    return;

                using (new CursorHandler())
                {
                    int OrderId = Int32.Parse(row.Cells["ID"].Value.ToString());
                    int CustomerID = Int32.Parse(row.Cells["CustomerID"].Value.ToString());
                    Customer cus = new Customer();
                    cus = cus.GetCustomer(CustomerID);
                    SalesTerritory ter = new SalesTerritory();
                    ter = ter.GetSalesTerritorys(cus.TerritoryID);
                    int Terindex = cmbPrintTerritory.FindStringExact(ter.Name);
                    if (Terindex > 0)
                        cmbPrintTerritory.SelectedIndex = Terindex;
                    
                    string custName = row.Cells["Customer"].Value.ToString();

                    Address shipping_address = new Address();
                    Address billing_address = new Address();
                    int cust_id = CustomerID;
                    billing_address.AddressID = GetCustomerAddressId(CustomerID, "billing");
                    shipping_address.AddressID = GetCustomerAddressId(CustomerID, "shipping");
                    billing_address = GetCustomerAddress(billing_address.AddressID);
                    shipping_address = GetCustomerAddress(shipping_address.AddressID);
                    if (billing_address.AddressLine1 == String.Empty || billing_address.AddressLine1 == null)
                    {
                        billing_address.AddressLine1 = shipping_address.AddressLine1;
                        billing_address.City = shipping_address.City;
                        billing_address.StateProvince = shipping_address.StateProvince;
                        billing_address.PostalCode = shipping_address.PostalCode;
                    }
                    FillShippingAddress(shipping_address);
                    FillBillingAddress(billing_address);
                    //string custName = dtPendingOrders.Rows[row]["Customer"].ToString();
                    int index = cmbPendingOrderCustomer.FindStringExact(custName);
                    if (index >= 0)
                        cmbPendingOrderCustomer.SelectedIndex = index;
                    //PopulatePendingOrdersDetailGrid(PendingOrders[row].SalesOrderID);
                    FillSalesOrdersDetailsGrid(OrderId, dtPendingOrdersDetail, grdPendingOrderDetails);
                    DateTime shipdate = DateTime.Parse(row.Cells["Ship Date"].Value.ToString());
                    decimal balance = GetCustomerBalance(CustomerID, shipdate);
                    txtPendingOrderBalance.Text = String.Format("{0:c}", balance); 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PendingOrderClick(int cur_row)
        {
            DataGridViewRow row = new DataGridViewRow();

            if (grdPendingOrderHeader.Rows.Count <= 0)
                return;
            try
            {
                if (cur_row < 0)
                {
                    row = grdPendingOrderHeader.CurrentRow;
                }
                else
                    row = grdPendingOrderHeader.Rows[cur_row];
                if (row == null) return;
             //   if(cur_row < 0)
               //     cur_row = grdPendingOrderHeader.CurrentRow.Index;
              //  if (cur_row >= PendingOrders.Count)
               //     return;

                using (new CursorHandler())
                {
                    int OrderId =  Int32.Parse(dtPendingOrders.Rows[cur_row]["ID"].ToString());
                    int CustomerID = Int32.Parse(dtPendingOrders.Rows[cur_row]["CustomerID"].ToString());
                    Customer cus = new Customer();
                    cus = cus.GetCustomer(CustomerID);
                    SalesTerritory ter = new SalesTerritory();
                    ter = ter.GetSalesTerritorys(cus.TerritoryID);
                    int Terindex = cmbPrintTerritory.FindStringExact(ter.Name);
                    if (Terindex > 0)
                        cmbPrintTerritory.SelectedIndex = Terindex;
                    
                    string custName = dtPendingOrders.Rows[cur_row]["Customer"].ToString();

                    Address shipping_address = new Address(); 
                    Address billing_address = new Address();
                    int cust_id = CustomerID;
                    billing_address.AddressID = GetCustomerAddressId(CustomerID, "billing");
                    shipping_address.AddressID = GetCustomerAddressId(CustomerID, "shipping");
                    billing_address = GetCustomerAddress(billing_address.AddressID);
                    shipping_address = GetCustomerAddress(shipping_address.AddressID);
                    if (billing_address.AddressLine1 == String.Empty || billing_address.AddressLine1 == null)
                    {
                        billing_address.AddressLine1 = shipping_address.AddressLine1;
                        billing_address.City = shipping_address.City;
                        billing_address.StateProvince = shipping_address.StateProvince;
                        billing_address.PostalCode = shipping_address.PostalCode;
                    }
                    FillShippingAddress(shipping_address);
                    FillBillingAddress(billing_address);
                    //string custName = dtPendingOrders.Rows[row]["Customer"].ToString();
                    int index = cmbPendingOrderCustomer.FindStringExact(custName);
                    if(index >= 0)
                        cmbPendingOrderCustomer.SelectedIndex = index;
                    //PopulatePendingOrdersDetailGrid(PendingOrders[row].SalesOrderID);
                    FillSalesOrdersDetailsGrid(OrderId, dtPendingOrdersDetail, grdPendingOrderDetails);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CellValueChanged(DataGridViewCellEventArgs e, DataTable dt, DataGridView grd)
        {
            int cur_row = grd.CurrentRow.Index;
            if (cur_row > dt.Rows.Count)
                return;
            int quantity = 0;
            decimal price = 0;
            decimal total = 0;
            decimal discount = 0;
            decimal grand_total;
            try
            {
                if (dt.Columns["Quantity"] != null && dt.Columns["Quantity"].ToString().Trim() != String.Empty)
                    quantity = Int32.Parse(dt.Rows[cur_row]["Quantity"].ToString());
                if (dt.Columns["Price"] != null)
                    price = decimal.Parse(dt.Rows[cur_row]["PRICE"].ToString());
                if (dt.Columns["Total"] != null)
                    total = decimal.Parse(dt.Rows[cur_row]["Total"].ToString());
                if (dt.Columns["Discount"] != null)
                    discount = decimal.Parse(dt.Rows[cur_row]["Discount"].ToString());

                if (e.ColumnIndex == grd.Columns["Quantity"].Index)
                {
                    total = price * quantity;
                }
                else if (e.ColumnIndex == grd.Columns["Price"].Index)
                {
                    total = price * quantity;
                }
                else if (e.ColumnIndex == grd.Columns["Total"].Index)
                {
                    price = total / quantity;
                }
                grand_total = total - discount;
                dt.Rows[cur_row]["Quantity"] = quantity;
                dt.Rows[cur_row]["Price"] = price;
                dt.Rows[cur_row]["Total"] = total;
                dt.Rows[cur_row]["Discount"] = discount;
                dt.Rows[cur_row]["Grand Total"] = grand_total;
                //UpdateOrderHeaderTotal();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void grdPendingOrderDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          //  dtPendingOrdersDetail.AcceptChanges();
            CellValueChanged(e,dtPendingOrdersDetail,grdPendingOrderDetails);
            UpdateOrderHeaderTotal(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader,PendingOrders);
            
        }
        private void UpdateOrderHeaderTotal(DataTable detail,DataTable header,DataGridView grd,SalesOrderHeaderCollection HeaderCol)
        {
            try
            {
                int cur_row = grd.CurrentRow.Index;
                decimal header_total = 0;
                int orderid = 0;
                foreach (DataRow dr in detail.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        orderid = Int32.Parse(dr["SalesOrderID"].ToString());
                        header_total += decimal.Parse(dr["Grand Total"].ToString());
                    }
                }
                foreach (DataRow drow in header.Rows)
                {
                    if(orderid == Int32.Parse(drow["ID"].ToString()))
                    {
                        drow["Total"] = header_total;
                        int customerid = Int32.Parse(drow["CustomerID"].ToString());
                        DateTime shipdate = DateTime.Parse(drow["Ship Date"].ToString());
                        drow["Balance"] = GetCustomerBalance(customerid, shipdate);
                        break;
                    }
                }
            //    header.Rows[cur_row]["Total"] = header_total;
                DataGridViewRow row = grd.CurrentRow;
                SavePendingOrderHeader(detail,header,row,HeaderCol);
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnPendingOrderAdd_Click(object sender, EventArgs e)
        {
            AddItemsToSaleOrder(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader,PendingOrders);
            int cur_row = grdPendingOrderHeader.CurrentRow.Index;
            int customerid = Int32.Parse(dtPendingOrders.Rows[cur_row]["CustomerID"].ToString());
            DateTime shipdate = DateTime.Parse(dtPendingOrders.Rows[cur_row]["Ship Date"].ToString());
            txtPendingOrderBalance.Text = String.Format("{0:c}", GetCustomerBalance(customerid, shipdate));
            
            /*frmProductPicker pick = new frmProductPicker(OrderType.SaleOrder);
            DataTable dt = new DataTable();
            try
            {
                dt = pick.GetSelectedProducts();
                pick.Close();
                //SetupGrid(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!(dr["Quantity"] is DBNull) && (int)dr["Quantity"] > 0)
                    {
                        //if (!(dr["Total"] is DBNull))
                            //m_OrderTotal += decimal.Parse(dr["Total"].ToString());
                        //if (UpdateQuantityIfExist(dr))
                        //{
                          //  continue;
                        //}

                        DataRow row = dtPendingOrdersDetail.NewRow();
                        row["ID"] = dr["PRODUCTID"];
                        row["Product"] = dr["Name"];
                        row["Quantity"] = dr["Quantity"];
                        row["Price"] = dr["PRICE"];
                        row["Total"] = dr["Total"];
                        row["Discount"] = 0;
                        //row["Special Offer"] = "";
                        row["Grand Total"] = dr["Total"];

                        int rows_count = dtPendingOrdersDetail.Rows.Count;
                        row["Nbr"] = rows_count + 1;
                        dtPendingOrdersDetail.Rows.Add(row);
                    }
                }
                UpdateOrderHeaderTotal(dtPendingOrdersDetail,dtPendingOrders,grdPendingOrderHeader);
                //grdOrderDetails.DataSource = dtProducts;
                //SetupGridColumns();
                //txtOrderTotal.Text = m_OrderTotal.ToString();
                //txtOrderTotal.Text = String.Format("{0:c}", m_OrderTotal);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            
        }
        private void AddItemsToSaleOrder(DataTable detail,DataTable header, DataGridView grd,SalesOrderHeaderCollection HeaderCol)
        {
            frmProductPicker pick = new frmProductPicker(OrderType.SaleOrder,0);
            DataTable dt = new DataTable();
            try
            {
                dt = pick.GetSelectedProducts();
                pick.Close();
                if (dt == null) return;
                if (dt.Rows.Count < 1) return;
                int salesorderid = 0;
                if (detail.Rows.Count > 0)
                {
                    salesorderid = Int32.Parse(detail.Rows[0]["SalesOrderID"].ToString());
                }
                else
                {
                    int headerrow = grd.CurrentRow.Index;
                    salesorderid = Int32.Parse(header.Rows[headerrow]["ID"].ToString());
                }
                //SetupGrid(dt);
                DataTable newtable = dt.Clone();
                int count = dt.Rows.Count;
                DataRow[] selectedRows = dt.Select("quantity <> 0");
                for (int i = 0; i < selectedRows.Length; i++ )
                {
                    newtable.ImportRow(selectedRows[i]);
                }
                foreach (DataRow dr in newtable.Rows)
                {
                    int qty;
                    decimal discount = 0;
                    try { qty = Int32.Parse(dr["Quantity"].ToString()); }
                    catch {qty = 0;}
                    if (qty != 0)
                    {
                        DataRow row = detail.NewRow();
                       // row["SalesOrderDetailID"] = dr["SalesOrderDetailID"];
                        row["SalesOrderID"] = salesorderid;
                        row["ID"] = dr["PRODUCTID"];
                        row["Product"] = dr["Name"];
                        row["Quantity"] = qty;
                        row["Price"] = dr["PRICE"];
                        row["Total"] = dr["Total"];
                        discount = GetDiscountPrice(Int32.Parse(row["ID"].ToString()), qty);
                        row["Discount"] = discount;
                        row["SpecialOfferID"] = dr["SpecialOfferID"];
                        row["Specail Offer"] = dr["SpecialOfferDesc"];
                        row["Grand Total"] = decimal.Parse(dr["Total"].ToString()) - discount;

                        int rows_count = detail.Rows.Count;
                        row["Nbr"] = rows_count + 1;
                        detail.Rows.Add(row);
                        AddPendingOrderDetails(row);
                       
                    }
                }
                UpdateOrderHeaderTotal(detail, header, grd,HeaderCol);
                detail.AcceptChanges();
                header.AcceptChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSavePendingOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SavePendingSaleOrder();
               // int cur_row = grdPendingOrderHeader.CurrentRow.Index;
              //  LoadFormData(cur_row);
               // LoadPendingOrders(cur_row);
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SavePendingSaleOrder()
        {
            if (grdPendingOrderHeader.SelectedRows.Count > 1)
            {
                MessageBox.Show("You must select only one order to save", "MICS");
                return;
            }
            int cust_id = Int32.Parse(cmbPendingOrderCustomer.SelectedValue.ToString());
            if (cust_id == 0)
            {
                MessageBox.Show("Invalid customer selected. Please select a customer before saving", "MICS");
                return;
            }
            grdPendingOrderHeader.CurrentRow.Cells["CustomerID"].Value = cust_id;
            grdPendingOrderHeader.CurrentRow.Cells["Customer"].Value = cmbPendingOrderCustomer.Text;
            if (m_PendingOrderBillingAddressID != 0 && m_PendingOrderShippingAddressID != 0)
            {
                grdPendingOrderHeader.CurrentRow.Cells["AddressID"].Value = m_PendingOrderShippingAddressID;
                grdPendingOrderHeader.CurrentRow.Cells["BillToAddressID"].Value = m_PendingOrderBillingAddressID;
                PendingOrders[grdPendingOrderHeader.CurrentRow.Index].ShipToAddressID = m_PendingOrderShippingAddressID;
                PendingOrders[grdPendingOrderHeader.CurrentRow.Index].BillToAddressID = m_PendingOrderBillingAddressID;
            }
            
            //if (SavePendingOrderHeader(cust_id, dtPendingOrders, PendingOrders, grdPendingOrderHeader, false))
            if(SavePendingOrderHeader(dtPendingOrdersDetail, dtPendingOrders, grdPendingOrderHeader.CurrentRow, PendingOrders))
            {
                //SavePendingOrderDetails();
               // int Orderid = Int32.Parse(dtPendingOrders.Rows[cur_row]["ID"].ToString());
               // SavePendingOrderDetails(Orderid,dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                //Update customer name in the grid
                SaveShippingAndBillingAddress(cust_id);
                MessageBox.Show("Order saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private bool SavePendingOrderHeader(int cust_id, DataTable dtHeader, SalesOrderHeaderCollection HeaderCol, DataGridView grd,DataTable detail,bool SaveInvoice)
        {
                int cur_row = grd.CurrentRow.Index;
                SalesOrderHeader soh = new SalesOrderHeader();
                try
                {
                    soh.SalesOrderID = Int32.Parse(dtHeader.Rows[cur_row]["ID"].ToString());
                    soh.CustomerID = cust_id;
                    soh.OrderDate = DateTime.Parse(dtHeader.Rows[cur_row]["Order Date"].ToString());
                    soh.DueDate = DateTime.Parse(dtHeader.Rows[cur_row]["Due Date"].ToString());
                    soh.ShipDate = DateTime.Parse(dtHeader.Rows[cur_row]["Ship Date"].ToString());
                    soh.SubTotal = 0; //Decimal.Parse(dtHeader.Rows[cur_row]["Total"].ToString());
                    soh.Comment = dtHeader.Rows[cur_row]["Comment"].ToString();
                    soh.TotalDue = 0; //soh.SubTotal;
                    foreach (DataRow  drow in detail.Rows)
                    {
                        if (drow.RowState != DataRowState.Deleted)
                        {
                            soh.SubTotal += decimal.Parse(drow["Grand Total"].ToString());
                        }
                    }
                    soh.TotalDue = soh.SubTotal;

                    soh.BillToAddressID = HeaderCol[cur_row].BillToAddressID;
                    soh.Freight = HeaderCol[cur_row].Freight;
                    soh.SalesPersonID = HeaderCol[cur_row].SalesPersonID;
                    soh.ShipToAddressID = HeaderCol[cur_row].ShipToAddressID;
                    soh.Status = HeaderCol[cur_row].Status;
                    soh.TaxAmt = HeaderCol[cur_row].TaxAmt;
                    //soh.Comment = HeaderCol[cur_row].Comment;
                    soh.CurrencyRateID = HeaderCol[cur_row].CurrencyRateID;
                    soh.PaymentMethodID = HeaderCol[cur_row].PaymentMethodID;
                    soh.PurchaseOrderNumber = HeaderCol[cur_row].PurchaseOrderNumber;
                    soh.TotalDue = soh.SubTotal + soh.TaxAmt + soh.Freight;
                    soh.SalesOrderNumber = HeaderCol[cur_row].SalesOrderNumber;
                    //soh.UpdateSalesOrderHeader(soh);
                    if (SaveInvoice)
                    {
                        SalesInvoiceHeader sih = new SalesInvoiceHeader();
                        string where = "SaleOrderId=" + soh.SalesOrderID.ToString(); // +" and AccountNumber='" + soh.CustomerID + "'";
                        string orderby = "invoiceid";
                        
                        SalesInvoiceHeaderCollection sihCol = sih.GetSalesInvoiceHeadersCollection(where,orderby);
                        sih = sihCol[0];
                        sih.TotalDue = soh.TotalDue;
                        sih.SubTotal = soh.SubTotal;
                        sih.DueDate = soh.DueDate;
                        sih.BillToAddressID = soh.BillToAddressID;
                        sih.ShipToAddressID = soh.ShipToAddressID;
                        sih.SaleOrderID = soh.SalesOrderID;
                        sih.Freight = soh.Freight;
                        sih.AccountNumber = soh.CustomerID.ToString();
                        sih.UpdateSalesInvoiceHeader(sih);
                    }
                    return (soh.UpdateSalesOrderHeader(soh));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    soh = null;
                }
                return true;
                 
        }
        private void SavePendingOrderDetails(int order_id,DataTable dt,SalesOrderHeaderCollection HeaderCol,DataGridView grd)
        {
            //int cur_row = grd.CurrentRow.Index;
            //if (cur_row < 0)
           //     return;
            try
            {
                //int order_id = HeaderCol[cur_row].SalesOrderID;
                SalesOrderDetail sod = new SalesOrderDetail();
                if (sod.RemoveSalesOrderDetail(order_id))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            continue;
                            //delete the row from the database
                           // string where = "SalesOrderDetailID=" + dr["SalesOrderDetailID"].ToString();
                           // sod.DeleteSalesOrderDetailsDynamic(where);
                           // continue;
                        }
                       // sod.SalesOrderDetailID = Int32.Parse(dr["SalesOrderDetailID"].ToString());
                        sod.SalesOrderID = order_id;
                        sod.ProductID = Int32.Parse(dr["ID"].ToString());
                        sod.OrderQty = short.Parse(dr["Quantity"].ToString());
                        sod.UnitPrice = decimal.Parse(dr["Price"].ToString());
                        sod.UnitPriceDiscount = decimal.Parse(dr["Discount"].ToString());
                        sod.LineTotal = decimal.Parse(dr["Grand Total"].ToString());
                        sod.SpecialOfferID = Int32.Parse(dr["SpecialOfferID"].ToString());
                        sod.CarrierTrackingNumber = "";
                        sod.AddSalesOrderDetail(sod);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SaveShippingAndBillingAddress(int cust_id)
        {
            try
            {
                int cur_row = grdPendingOrderHeader.CurrentRow.Index;
               // int cust_id = Int32.Parse(grdPendingOrderHeader.CurrentRow.Cells["CustomerID"].Value.ToString());//PendingOrders[cur_row].CustomerID;
                Customer cus = GetCustomer(cust_id);
                int shippingAddressID = cus.AddressID; //GetCustomerAddressId(cust_id, "shipping");
                int billingAddressID = cus.BillingAddressID; //GetCustomerAddressId(cust_id, "billing");
                Address ShipToAdd = new Address();
                ShipToAdd.AddressID = shippingAddressID;
                ShipToAdd.AddressLine1 = txtShiptToStreet.Text;
                ShipToAdd.AddressLine2 = "";
                ShipToAdd.City = txtShipToCity.Text;
                ShipToAdd.StateProvince = txtShipToState.Text;
                ShipToAdd.PostalCode = txtShipToZip.Text;
                if (shippingAddressID == 0)
                {
                    //This is a new address, add it to the address table.
                    ShipToAdd.AddAddress(ShipToAdd);
                    //update the customer with the new shipping address
                    cus.AddressID = ShipToAdd.AddressID;
                    cus.UpdateCustomer(cus);

                }
                else
                {
                    ShipToAdd.UpdateAddress(ShipToAdd);
                }

                Address billing_add = new Address();
                billing_add.AddressID = billingAddressID;
                billing_add.AddressLine1 = txtBillToAddress.Text;
                billing_add.AddressLine2 = "";
                billing_add.City = txtBillToCity.Text;
                billing_add.StateProvince = txtBillToStateProvince.Text;
                billing_add.PostalCode = txtBillToZip.Text;
                if (billingAddressID == 0)
                {
                    billing_add.AddAddress(billing_add);
                }
                else
                {
                    billing_add.AddressID = billing_add.UpdateAddress(billing_add);
                }
               
                if (billing_add.AddressID > 0)
                {
                    //update the customer with new billing address.
                   
                    cus.BillingAddressID = billing_add.AddressID;
                    cus.UpdateCustomer(cus);
                }
                

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelInvoice inv = new ExcelInvoice(ExcelInvoice.InvoiceType.Sale);
                inv.CompanyName = cmbPendingOrderCustomer.SelectedText;
                inv.ShippingStreet = txtShiptToStreet.Text;
                inv.ShippingCity = txtShipToCity.Text;
                inv.ShippingState = txtShipToState.Text;
                inv.ShippingZip = txtShipToZip.Text;
                inv.Print(dtPendingOrdersDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "mics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        private void PrintSelected(ExcelInvoice.InvoiceType InvType, DataGridViewRow row)
        {
            //foreach(DataGridViewSelectedRowCollection sel in grdPendingOrderHeader.SelectedRows)
            //{
                //int cur_row = grdPendingOrderHeader.CurrentRow.Index;
                try
                {
                    //FillSalesOrdersDetailsGrid(PendingOrders[cur_row].SalesOrderID, dtPendingOrdersDetail, grdPendingOrderDetails);
                   // PendingOrderClick(cur_row);
                    ExcelInvoice inv = new ExcelInvoice(InvType);

                    inv.CompanyName = row.Cells["Customer"].Value.ToString();
                    int addressid = Int32.Parse(row.Cells["AddressID"].Value.ToString());
                    int billingaddressid = Int32.Parse(row.Cells["BillToAddressID"].Value.ToString());
                    Address shipping = new Address();
                    shipping = shipping.GetAddresss(addressid);
                    Address billing = new Address();
                    billing = billing.GetAddresss(billingaddressid);

                    inv.ShippingStreet = shipping.AddressLine1;
                    inv.ShippingCity = shipping.City;
                    inv.ShippingState = shipping.StateProvince;
                    inv.ShippingZip = shipping.PostalCode;

                    inv.BillingStreet = billing.AddressLine1;
                    inv.BillingCity = billing.City;
                    inv.BillingState = billing.StateProvince;
                    inv.BillingZip = billing.PostalCode;

                    //inv.InvoiceDate = DateTime.Today;
                    SalesInvoiceHeader sih = new SalesInvoiceHeader();

                    inv.CusotmerID = Int32.Parse(row.Cells["CustomerID"].Value.ToString());
                    inv.DeliveryDate = DateTime.Parse(row.Cells["Ship Date"].Value.ToString());
                    inv.InvoiceDate = inv.DeliveryDate;
                    inv.TotalDue = decimal.Parse(row.Cells["Total"].Value.ToString());
                    int order_id = Int32.Parse(row.Cells["ID"].Value.ToString());
                    inv.InvoiceNumber = sih.CreateInvoiceNumber(order_id, inv.DeliveryDate);
                    inv.DueDate = DateTime.Parse(row.Cells["Due Date"].Value.ToString());
                    inv.Comments = row.Cells["Comment"].Value.ToString();
                    if (InvType == ExcelInvoice.InvoiceType.Sale)
                    {
                        Customer cus = new Customer();
                        cus = cus.GetCustomer(inv.CusotmerID);
                        decimal credit_limit = cus.CreditLimit;
                        int territory_id = cus.TerritoryID;
                        string terms = "Cash/Check";
                        if (credit_limit > 0)
                            terms = "One Week";
                        inv.PaymentTerms = terms;

                        //Payment p = new Payment();
                        //decimal tot_payments = p.GetTotalPaymentsByCustomerId(inv.CusotmerID);
                        //decimal tot_invoices = sih.GetTotalInvoicesByCustomerId(inv.CusotmerID);
                        //inv.PreviousBalance = tot_invoices - tot_payments;

                        //sale person data
                        SalesTerritoryHistory territory = new SalesTerritoryHistory();
                        DataSet dsTerritory = territory.GetSalesTerritoryHistory(cus.TerritoryID);
                        string salepersonphone = "";
                        string salepersonname = "";
                        if (dsTerritory.Tables[0].Rows.Count > 0)
                        {
                            int saleperson_id = Int32.Parse(dsTerritory.Tables[0].Rows[0]["SalesPersonID"].ToString());
                            Employee emp = new Employee();
                            emp = emp.GetEmployee(saleperson_id);
                            salepersonname = emp.FirstName.Trim() + " " + emp.LastName.Trim();
                            if (emp.CellPhone != String.Empty)
                                salepersonphone = emp.CellPhone.Trim();
                            else if (emp.WorkPhone != String.Empty)
                                salepersonphone = emp.WorkPhone;
                            else if (emp.HomePhone != String.Empty)
                                salepersonphone = emp.HomePhone;
                        }
                        inv.SalePerson = salepersonname + " " + salepersonphone;
                        //p.GetTotalPaymentsByInvoiceId(id);
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    SalesOrderDetail sod = new SalesOrderDetail();
                    int copies = Int32.Parse(NudPrintCopies.Value.ToString());
                    inv.PrintCopies = copies;
                    inv.TotalDue = 0;
                    if (InvType == ExcelInvoice.InvoiceType.ShippingList)
                    {
                        string where = "SalesOrderid=" + order_id;
                        string orderby = "salesorderid,description";
                        ds = sod.GetSalesOrderDetailDataSet(where, orderby);
                        DataTable dt = new DataTable();
                        dt = dtPendingOrdersDetail.Copy();
                        dt.Rows.Clear();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (Int32.Parse(dr["OrderQty"].ToString()) > 0)
                            {
                                DataRow drow = dt.NewRow();
                                Product p = new Product();
                                int productid = Int32.Parse(dr["ProductId"].ToString());
                                drow["ID"] = productid;
                                drow["Product"] = p.GetProduct(productid).Description;
                                drow["Quantity"] = dr["OrderQty"];
                                drow["Price"] = dr["UnitPrice"];
                                drow["Discount"] = dr["UnitPriceDiscount"];
                                drow["Specail Offer"] = dr["SpecialOfferID"];
                                drow["Grand Total"] = dr["LineTotal"];
                                inv.TotalDue += decimal.Parse(drow["Grand Total"].ToString());
                                dt.Rows.Add(drow);
                                p = null;
                            }
                        }
                        //inv.Print(ds.Tables[0]);
                       // PendingOrderClick(row);
                        inv.Print(dt);
                    }
                    else //Sale Invoices
                    {
                        ds = sod.GetOrderDetailsGroupedByName(order_id);
                        DataTable CreditItems = new DataTable();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (Int32.Parse(ds.Tables[0].Rows[i]["Quantity"].ToString()) < 0)
                            {
                                CreditItems = ds.Tables[0].Copy();
                                ds.Tables[0].Rows[i].Delete();
                                ds.Tables[0].AcceptChanges();
                            }
                        }
                        foreach (DataRow dr in CreditItems.Rows)
                        {
                            if (Int32.Parse(dr["Quantity"].ToString()) < 0)
                            {
                                DataRow drow = ds.Tables[0].NewRow();
                                drow["Quantity"] = dr["Quantity"];
                                drow["Name"] = dr["Name"] + "   *** CREDIT ***" ;
                                drow["Price"] = dr["Price"];
                                drow["Discount"] = dr["Discount"];
                                drow["Grand Total"] = dr["Grand Total"];
                                ds.Tables[0].Rows.Add(drow);
                                ds.Tables[0].AcceptChanges();
                            }
                        }
                        if (inv.Comments.Trim().Length > 0 && inv.Comments != "Mobile Order")
                        {
                            inv.Comments = BreakIntoLines(inv.Comments, 50);
                            char[] newLine = {'\n'};
                            string[]lines = inv.Comments.Split(newLine);

                            for (int i = 0; i < lines.Length; i++)
                            {
                                //add the comments in the last row
                                DataRow CommentsRow = ds.Tables[0].NewRow();
                                //DataTable dt = new DataTable();
                                //dt = ds.Tables[0].Clone;
                                CommentsRow["Quantity"] = 0;
                                CommentsRow["Name"] = "<< " + lines[i] + " >>";
                                CommentsRow["Price"] = 0;
                                CommentsRow["Discount"] = 0;
                                CommentsRow["Grand Total"] = 0;
                                ds.Tables[0].Rows.Add(CommentsRow);
                            }
                            
                            
                            
                        }
                        
                        inv.TotalDue = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            inv.TotalDue += decimal.Parse(dr["Grand Total"].ToString());
                        }
                        Payment p = new Payment();
                        decimal tot_payments = p.GetTotalPaymentsByCustomerId(inv.CusotmerID, inv.DeliveryDate);
                        decimal tot_invoices = sih.GetTotalInvoicesByCustomerId(inv.CusotmerID, inv.DeliveryDate);
                    //    if (tot_invoices > 0 && (tot_invoices > tot_payments))
                        inv.PreviousBalance = tot_invoices - tot_payments;
                        //else
                      //      inv.PreviousBalance = tot_invoices - tot_payments + inv.TotalDue;

                        inv.Print(ds.Tables[0]);
                    }
                    Cursor.Current = Cursors.Default;
                    ds = null;
                    sod = null;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "mics", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
        }
        private decimal GetCustomerBalance(int customerid, DateTime shipdate)
        {
            decimal balance = 0;
            Payment p = new Payment();
            SalesInvoiceHeader sih = new SalesInvoiceHeader();
            try
            {
                decimal tot_payments = p.GetTotalPaymentsByCustomerId(customerid, shipdate);
                decimal tot_invoices = sih.GetTotalInvoicesByCustomerId(customerid, shipdate);
                balance = tot_invoices - tot_payments;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return balance;
        }
        private string BreakIntoLines(string buffer, int LineLen)
        {
            int bufLen = buffer.Length;
            if (bufLen <= LineLen)
            {
                return buffer;
            }
            int NumOfLines = bufLen / LineLen;
            int rem = bufLen % LineLen;
            if (rem > 0)
                NumOfLines++;

            int start = LineLen;
            int end = 0;
            for (int i = 1; i < NumOfLines; i++)
            {
                for (int jj = start; jj > end; jj--)
                {
                    if (buffer[jj] == ' ')
                    {
                        buffer = buffer.Insert(jj, "\n");
                        start = jj + 1 + LineLen;
                        if(start > bufLen - 1)
                            start = bufLen -1;
                        end = jj;
                        break;
                    }
                }
            }
            return buffer;


            //string tmp = "";
            //for (int i = 0; i < bufLen; i++)
            //{
            //    while (tmp.Length < LineLen && tmp.Length < bufLen)
            //    {
            //        tmp[i] = buffer[i++];
                    
            //    }
            //}
            //int TheLen = LineLen;
            //for (int line = 1; line < NumOfLines; line++)
            //{
            //    TheLen = (line * LineLen) - 1;
            //    for (int i = TheLen; i < bufLen; i++)
            //    {
                    
            //        tmp[i] = buffer[i];
            //    }
            //}

        }
        private void cmbPendingOrderPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPendingOrderPrint.SelectedIndex > 0)
                btnPedingOrderPrint.Enabled = true;
            else
                btnPedingOrderPrint.Enabled = false;

            if (cmbPendingOrderPrint.SelectedValue.ToString() == "3" ||
               cmbPendingOrderPrint.SelectedValue.ToString() == "4")
            {
                //default the no of copies to 2 for invoices
                NudPrintCopies.Value = 2;
            }
            else
            {
                NudPrintCopies.Value = 1;
            }
            
        }
        private bool SavePendingOrderHeader(DataTable detail,DataTable header,DataGridViewRow row,SalesOrderHeaderCollection HeaderCol)
        {
            SalesOrderHeader soh = new SalesOrderHeader();
            try
            {
                
                int cur_row = row.Index;
                soh.SalesOrderID = Int32.Parse(row.Cells["ID"].Value.ToString()); // Int32.Parse(dtPendingOrders.Rows[cur_row]["ID"].ToString());
                soh.CustomerID = Int32.Parse(row.Cells["CustomerID"].Value.ToString());// Int32.Parse(dtPendingOrders.Rows[cur_row]["CustomerID"].ToString()); ;
                soh.OrderDate = DateTime.Parse(row.Cells["Order Date"].Value.ToString());// DateTime.Parse(dtPendingOrders.Rows[cur_row]["Order Date"].ToString());
                soh.DueDate = DateTime.Parse(row.Cells["Due Date"].Value.ToString());
                soh.ShipDate = DateTime.Parse(row.Cells["Ship Date"].Value.ToString());
                soh.ShipToAddressID = Int32.Parse(row.Cells["AddressID"].Value.ToString());
                soh.BillToAddressID = Int32.Parse(row.Cells["BillToAddressID"].Value.ToString());
                soh.Comment = row.Cells["Comment"].Value.ToString();
                soh.SubTotal = 0; //Decimal.Parse(row.Cells["Total"].Value.ToString());
                soh.TotalDue = 0; //soh.SubTotal;
                int i = 0;
                foreach (DataRow drow in detail.Rows)
                {
                    if (detail.Rows[i++].RowState != DataRowState.Deleted)
                    {
                        soh.SubTotal += decimal.Parse(drow["Grand Total"].ToString());
                    }
                }
                soh.TotalDue = soh.SubTotal;
                //int oid = Int32.Parse(detail.Rows[cur_row]["ID"].ToString());
                foreach (SalesOrderHeader order in HeaderCol)
                {
                    if (soh.SalesOrderID == order.SalesOrderID)
                    {
                        soh.Freight = order.Freight;
                        soh.SalesPersonID = order.SalesPersonID;
                        soh.Status = order.Status;
                        soh.TaxAmt = order.TaxAmt;
                        soh.CurrencyRateID = order.CurrencyRateID;
                        soh.PaymentMethodID = order.PaymentMethodID;
                        soh.PurchaseOrderNumber = order.PurchaseOrderNumber;
                        soh.SalesOrderNumber = order.SalesOrderNumber;
                        soh.TotalDue = soh.SubTotal + soh.TaxAmt + soh.Freight;
                        
                        return (soh.UpdateSalesOrderHeader(soh));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                soh = null;
            }
            return true;
        }
        private void btnPedingOrderPrint_Click(object sender, EventArgs e)
        {
            //int cust_id = Int32.Parse(cmbPendingOrderCustomer.SelectedValue.ToString());
            
           // int rows = 0;
            switch (cmbPendingOrderPrint.SelectedValue.ToString())
            {
                case "1"://Selected Shipping Orders
                    foreach (DataGridViewRow  row in grdPendingOrderHeader.SelectedRows)
                    {
                        //int OrderId = Int32.Parse(row.Cells["ID"].Value.ToString());
                        //if (SavePendingOrderHeader(row))
                        //{
                        //    PendingOrderClick(row);
                        //    SavePendingOrderDetails(OrderId, dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                        //}
                        PrintSelected(ExcelInvoice.InvoiceType.ShippingList, row);
                    }



                    //for (int row = 0; row < grdPendingOrderHeader.Rows.Count; row++)
                    //{
                    //    if (rows >= grdPendingOrderHeader.SelectedRows.Count)
                    //        break;
                    //    if (grdPendingOrderHeader.Rows[row].Selected)
                    //    {
                    //        string OrdId = grdPendingOrderHeader.Rows[row].Cells["ID"].Value.ToString();
                    //        if (SavePendingOrderHeader(row))
                    //        {
                    //            SavePendingOrderDetails(dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                    //        }
                    //        PrintSelected(ExcelInvoice.InvoiceType.ShippingList,row);
                    //        rows++;
                    //    }
                    //}
                    break;
                case "2":       //All Shipping Orders":
                    foreach (DataGridViewRow row in grdPendingOrderHeader.Rows)
                    {
                        //if (SavePendingOrderHeader(row))
                        //{
                        //    PendingOrderClick();
                        //    SavePendingOrderDetails(dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                        //}

                       PrintSelected(ExcelInvoice.InvoiceType.ShippingList, row);
                    }
                    break;
                case "3":       //Selected Invoices":
                    foreach (DataGridViewRow row in grdPendingOrderHeader.SelectedRows)
                    {
                            //if (SavePendingOrderHeader(row))
                            //{
                            //    SavePendingOrderDetails(dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                            //}
                            PrintSelected(ExcelInvoice.InvoiceType.Sale, row);
                          
                        
                    }
                    break;
                case "4":      //All Invoices":
                    foreach (DataGridViewRow row in grdPendingOrderHeader.Rows)
                    {
                        //if (SavePendingOrderHeader(row))
                        //{
                        //    SavePendingOrderDetails(dtPendingOrdersDetail, PendingOrders, grdPendingOrderHeader);
                        //}
                        PrintSelected(ExcelInvoice.InvoiceType.Sale, row);
                    }
                    break;
            }
        }
        private bool UpdateOrderStatus(DataGridViewRow row,byte status)
        {
            SalesOrderHeader soh = new SalesOrderHeader();
            try
            {
                int cur_row = row.Index;
                soh.SalesOrderID = Int32.Parse(row.Cells["ID"].Value.ToString()); // Int32.Parse(dtPendingOrders.Rows[cur_row]["ID"].ToString());
                soh.CustomerID = Int32.Parse(row.Cells["CustomerID"].Value.ToString());// Int32.Parse(dtPendingOrders.Rows[cur_row]["CustomerID"].ToString()); ;
                soh.OrderDate = DateTime.Parse(row.Cells["Order Date"].Value.ToString());// DateTime.Parse(dtPendingOrders.Rows[cur_row]["Order Date"].ToString());
                soh.DueDate = DateTime.Parse(row.Cells["Due Date"].Value.ToString());
                soh.ShipDate = DateTime.Parse(row.Cells["Ship Date"].Value.ToString());
                soh.SubTotal = Decimal.Parse(row.Cells["Total"].Value.ToString());
                soh.TotalDue = soh.SubTotal;
                int oid = Int32.Parse(dtPendingOrders.Rows[cur_row]["ID"].ToString());
                for (cur_row = 0; cur_row < PendingOrders.Count; cur_row++)
                {
                    if (soh.SalesOrderID == PendingOrders[cur_row].SalesOrderID)
                    {
                        soh.BillToAddressID = PendingOrders[cur_row].BillToAddressID;
                        string id = dtPendingOrders.Rows[cur_row]["ID"].ToString();
                        soh.Freight = PendingOrders[cur_row].Freight;
                        soh.SalesPersonID = PendingOrders[cur_row].SalesPersonID;
                        soh.ShipToAddressID = PendingOrders[cur_row].ShipToAddressID;
                        soh.Status = status;
                        soh.TaxAmt = PendingOrders[cur_row].TaxAmt;
                        soh.Comment = PendingOrders[cur_row].Comment;
                        soh.CurrencyRateID = PendingOrders[cur_row].CurrencyRateID;
                        soh.PaymentMethodID = PendingOrders[cur_row].PaymentMethodID;
                        soh.PurchaseOrderNumber = PendingOrders[cur_row].PurchaseOrderNumber;
                        soh.SalesOrderNumber = soh.SalesOrderNumber;
                        soh.TotalDue = soh.SubTotal + soh.TaxAmt + soh.Freight;
                        soh.SalesOrderNumber = PendingOrders[cur_row].SalesOrderNumber;
                        return (soh.UpdateSalesOrderHeader(soh));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                soh = null;
            }
            return true;
            
        }
        private void btnInvoiceAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPendingOrderHeader.Rows == null)
                    return;
                int count = grdPendingOrderHeader.Rows.Count;
                int selected = 0;

                foreach(DataGridViewRow row in grdPendingOrderHeader.SelectedRows)
                {
                    UpdateOrderStatus(row, (byte)OrderStatus.Shipped);
                    CreateSaleInvoice(row);
                    int OrderID = Int32.Parse(row.Cells["ID"].Value.ToString());
                    UpdateInventoryCount(OrderID);
                    selected++;
                }
                if (selected > 0)
                {
                    MessageBox.Show("Orders shipped successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFormData(0);
                }
                else
                {
                    MessageBox.Show("No orders selected. Please select an order and try again", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Write(ex.Message, "");
            }
        }
        private void UpdateOrderStatus(int cur_row, byte status,SalesOrderHeaderCollection HeaderCol,DataTable dt)
        {
            try
            {
                SalesOrderHeader soh = new SalesOrderHeader();
                soh.SalesOrderID = HeaderCol[cur_row].SalesOrderID;
                soh.Status = status;
                soh.CustomerID = HeaderCol[cur_row].CustomerID;
                soh.OrderDate = DateTime.Parse(dt.Rows[cur_row]["Order Date"].ToString());
                soh.DueDate = DateTime.Parse(dt.Rows[cur_row]["Due Date"].ToString());
                soh.ShipDate = DateTime.Parse(dt.Rows[cur_row]["Ship Date"].ToString());
                soh.SubTotal = Decimal.Parse(dt.Rows[cur_row]["Total"].ToString());
                soh.TotalDue = soh.SubTotal;

                soh.BillToAddressID = HeaderCol[cur_row].BillToAddressID;
                soh.Freight = HeaderCol[cur_row].Freight;
                soh.SalesPersonID = HeaderCol[cur_row].SalesPersonID;
                soh.ShipToAddressID = HeaderCol[cur_row].ShipToAddressID;

                soh.TaxAmt = HeaderCol[cur_row].TaxAmt;
                soh.Comment = HeaderCol[cur_row].Comment;
                soh.CurrencyRateID = HeaderCol[cur_row].CurrencyRateID;
                soh.PaymentMethodID = HeaderCol[cur_row].PaymentMethodID;
                soh.PurchaseOrderNumber = HeaderCol[cur_row].PurchaseOrderNumber;
                soh.SalesOrderNumber = soh.SalesOrderNumber;
                soh.TotalDue = soh.SubTotal + soh.TaxAmt + soh.Freight;
                soh.SalesOrderNumber = HeaderCol[cur_row].SalesOrderNumber;
                soh.UpdateSalesOrderHeader(soh);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void UpdateInventoryCount(int order_id)
        {
            try
            {
                SalesOrderDetail sod = new SalesOrderDetail();
                string where = "SalesOrderID=" + order_id;
                string order_by = "SalesOrderID,description";
                DataSet ds = new DataSet();
                ds = sod.GetSalesOrderDetailDataSet(where, order_by);
                DataTable dt = ds.Tables[0];

                for(int i=0; i<dt.Rows.Count; i++)
                {
                    if (order_id == Int32.Parse(dt.Rows[i]["SalesOrderID"].ToString()))
                    {
                        ProductInventory inv = new ProductInventory();
                        inv.ProductID = Int32.Parse(dt.Rows[i]["ProductID"].ToString());
                        inv = inv.GetProductInventorys(inv.ProductID);
                        inv.Quantity -= Int32.Parse(dt.Rows[i]["OrderQty"].ToString());
                        //inv.Shelf = "";
                        //inv.LocationID = 0;
                        //inv.Bin = 0;
                        inv.UpdateProductInventory(inv);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw(ex);
            }
        }
        private void CreateSaleInvoice(DataGridViewRow row)
        {
            try
            {
                SalesInvoiceHeader sih = new SalesInvoiceHeader();
                sih.SaleOrderID = Int32.Parse(row.Cells["ID"].Value.ToString());
                sih.Status = (byte)OrderStatus.Pending;
                
                sih.InvoiceDate = DateTime.Parse(row.Cells["Ship Date"].Value.ToString());
                sih.DueDate = DateTime.Parse(row.Cells["Due Date"].Value.ToString());
                
                sih.SubTotal = Decimal.Parse(row.Cells["Total"].Value.ToString());
                sih.Comment = row.Cells["Comment"].Value.ToString();
                sih.BillToAddressID = Int32.Parse(row.Cells["BillToAddressID"].Value.ToString());
                sih.ShipToAddressID = sih.BillToAddressID;
                sih.InvoiceNumber = sih.CreateInvoiceNumber(sih.SaleOrderID, sih.InvoiceDate);
                sih.AccountNumber = row.Cells["CustomerID"].Value.ToString();
                      
                bool found=false;
                int index = row.Index;
                for(int cur_row=0; cur_row<PendingOrders.Count; cur_row++)
                {
                    if (sih.SaleOrderID == PendingOrders[cur_row].SalesOrderID)
                    {
                        sih.Freight = PendingOrders[cur_row].Freight;
                        sih.SalesPersonID = PendingOrders[cur_row].SalesPersonID;
                        sih.TaxAmt = PendingOrders[cur_row].TaxAmt;
                        sih.PaymentMethodID = PendingOrders[cur_row].PaymentMethodID;
                        found=true;
                        break;
                    }
                }
                if(!found)
                {
                    sih.Freight = 0;
                    sih.SalesPersonID = 0;
                    sih.TaxAmt = 0;
                    sih.PaymentMethodID = 0;
                    log.Write("WARNING:order id not found in pending orders list (" + sih.SaleOrderID + ")", "");
                 }
                 sih.TotalDue = sih.SubTotal + sih.TaxAmt + sih.Freight;
                 sih.InvoiceID = sih.AddSalesInvoiceHeader(sih);
                 if (sih.InvoiceID > 0)
                    CreateInvoiceDeatails(sih.InvoiceID, sih.SaleOrderID);


                //}

                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw (ex);
            }
        
        }
        private void CreateInvoiceDeatails(int InvoiceID, int OrderID)
        {
            try
            {
                SalesOrderDetail sod = new SalesOrderDetail();
                string where = "SalesOrderID=" + OrderID;
                string order_by = "SalesOrderID,description";
                DataSet ds = new DataSet();
                ds = sod.GetSalesOrderDetailDataSet(where, order_by);
                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SalesInvoiceDetail sid = new SalesInvoiceDetail();
                    sid.InvoiceID = InvoiceID;
                    sid.ProductID = Int32.Parse(dt.Rows[i]["productid"].ToString());
                    sid.Quantity = short.Parse(dt.Rows[i]["OrderQty"].ToString());
                    sid.UnitPrice = decimal.Parse(dt.Rows[i]["UnitPrice"].ToString());
                    sid.UnitPriceDiscount = decimal.Parse(dt.Rows[i]["UnitPriceDiscount"].ToString());
                    if (dt.Rows[i]["SpecialOfferID"] != DBNull.Value)
                        sid.SpecialOfferID = Int32.Parse(dt.Rows[i]["SpecialOfferID"].ToString());
                    else
                        sid.SpecialOfferID = 0;
                    sid.LineTotal = decimal.Parse(dt.Rows[i]["LineTotal"].ToString());
                    sid.AddSalesInvoiceDetail(sid);
                    
                }
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        private void btnCancelPendingOrder_Click(object sender, EventArgs e)
        {
            string ConfMsg = "Are you sure you want to cancel this order";
            if (MessageBox.Show(ConfMsg, "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            try
            {
                int count = grdPendingOrderHeader.Rows.Count;
                int selected = 0;
                for (int i = 0; i < count; i++)
                {
                    if (grdPendingOrderHeader.Rows[i].Selected)
                    {
                        //UpdateOrderStatus(i, (byte)OrderStatus.Cancelled);
                        UpdateOrderStatus(i, (byte)OrderStatus.Cancelled, PendingOrders, dtPendingOrders);
                        selected++;
                    }
                }
                if (selected > 0)
                {
                    MessageBox.Show("Orders Cancelled successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFormData(0);
                }
                else
                {
                    MessageBox.Show("No orders selected. Please select an order and try again", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtToDate.Text = dtViewOrdersToDate.Value.ToShortDateString();
        }
        private void btnSearchSalesOrders_Click(object sender, EventArgs e)
        {
            LoadViewOrders();
        }
        private void dtViewOrdersFromDate_ValueChanged(object sender, EventArgs e)
        {
            txtFromDate.Text = dtViewOrdersFromDate.Value.ToShortDateString();
        }
        private void grdViewOrderHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdViewOrderHeader_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (grdViewOrderHeader.Rows.Count == 0)
            //        return;
            //    int row = grdViewOrderHeader.CurrentRow.Index;
            //    if (row >= ViewOrders.Count || row < 0)
            //        return;
            //    int order_id = ViewOrders[row].SalesOrderID;
            //    FillSalesOrdersDetailsGrid(order_id, dtViewOrdersDetails, dgViewOrdersDetail);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgViewOrdersDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellValueChanged(e, dtViewOrdersDetails, dgViewOrdersDetail);
            decimal total = 0;
            int cur_row = grdViewOrderHeader.CurrentRow.Index;
            foreach (DataRow r in dtViewOrdersDetails.Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    total += decimal.Parse(r["Grand Total"].ToString());
                }
            }
            dtViewOrders.Rows[cur_row]["Total"] = total;
         //   dtViewOrdersDetails.AcceptChanges();
           // UpdateOrderHeaderTotal(dtViewOrdersDetails, dtViewOrders, grdViewOrderHeader,ViewOrders);
        }

        private void btnAddItemsToOrder_Click(object sender, EventArgs e)
        {
            AddItemsToSaleOrder(dtViewOrdersDetails, dtViewOrders, grdViewOrderHeader,ViewOrders);
        }

        private void btnSaveSaleOrder_Click(object sender, EventArgs e)
        {
            try
            {
                dtViewOrdersDetails.AcceptChanges();
                SaveViewSaleOrder();
                LoadViewOrders();
                MessageBox.Show("Order saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveViewSaleOrder()
        {

            int row = grdViewOrderHeader.CurrentRow.Index;
            int cust_id = ViewOrders[row].CustomerID;
            int Orderid = ViewOrders[row].SalesOrderID;
            if (cmbViewOrderCustomers.SelectedIndex > 0)
            {
                int new_cust_id = Int32.Parse(cmbViewOrderCustomers.SelectedValue.ToString());
                if (new_cust_id != cust_id)
                {
                    if (MessageBox.Show("Are you sure you want to change the customer on this order to " + cmbViewOrderCustomers.Text + " .?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        Exception ex = new Exception("Order not saved");
                        throw (ex);
                    }
                    else
                    {
                        cust_id = new_cust_id;
                        ViewOrders[row].CustomerID = new_cust_id;
                        //Get the address of the new customer.
                        Customer NewCust = new Customer();
                        NewCust = NewCust.GetCustomer(new_cust_id);
                        ViewOrders[row].BillToAddressID = NewCust.BillingAddressID;
                        ViewOrders[row].ShipToAddressID = NewCust.AddressID;

                    }
                }
            }
            if (SavePendingOrderHeader(cust_id, dtViewOrders, ViewOrders, grdViewOrderHeader,dtViewOrdersDetails,true))
            {
                SavePendingOrderDetails(Orderid,dtViewOrdersDetails, ViewOrders, grdViewOrderHeader);
            }
        }

        private void btnCancelSaleOrder_Click(object sender, EventArgs e)
        {
            int cur_row = grdViewOrderHeader.CurrentRow.Index;
            if (cur_row < 0)
            {
                MessageBox.Show("No orders selected. Please select an order and try again", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string ConfMsg = "Are you sure you want to cancel this order";
            if (MessageBox.Show(ConfMsg, "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            try
            {
                int id = Int32.Parse(dtViewOrders.Rows[cur_row]["ID"].ToString());
                //IF the total payments on this order is > 0, don't cancel it.
                SalesInvoiceHeader sih = new SalesInvoiceHeader();
                string where = "saleorderid=" + id.ToString();
                string orderby = "invoiceid";
                SalesInvoiceHeaderCollection sihCol = sih.GetSalesInvoiceHeadersCollection(where, orderby);
                Payment p = new Payment();
                decimal tot_pay = 0;
                int invoiceid = 0;
                if (sihCol.Count > 0)
                {
                    invoiceid = sihCol[0].InvoiceID;
                    tot_pay = p.GetTotalPaymentsByInvoiceId(invoiceid);
                }
                if (tot_pay > 0)
                {
                    string msg = "The total payments made on this order is $" + decimal.Round(tot_pay,2).ToString() + ". You must adjust the payments to zero before cancelling this order.";
                    MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                UpdateOrderStatus(cur_row, (byte)OrderStatus.Cancelled, ViewOrders, dtViewOrders);
                DeleteInvoice(id);
                MessageBox.Show("Orders Cancelled successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadViewOrders();
                // dtViewOrders.Rows[cur_row]["Status"] = GetOrderStatus((int)OrderStatus.Cancelled);
              //  grdViewOrderHeader.DataSource = dtViewOrders;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteInvoice(int OrderId)
        {
            try
            {
                SalesInvoiceHeader sih = new SalesInvoiceHeader();
                string where = "SaleOrderId=" + OrderId.ToString() + " and status=1";
                string orderby = "invoiceid";
                SalesInvoiceHeaderCollection sihCol = sih.GetSalesInvoiceHeadersCollection(where, orderby);
                foreach (SalesInvoiceHeader h in sihCol)
                {
                    h.RemoveSalesInvoiceHeader(h.InvoiceID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void grdInvoices_Click(object sender, EventArgs e)
        {
            GrdInvoiceClick();
            //int cur_row = grdInvoices.CurrentRow.Index;
            //if (cur_row >= grdInvoices.Rows.Count - 1)
            //    return;
            //string invoice_nbr = dtInvoiceHeader.Rows[cur_row]["Invoice Nbr"].ToString();
            //decimal amount = decimal.Parse(dtInvoiceHeader.Rows[cur_row]["Balance"].ToString(), System.Globalization.NumberStyles.Currency);
            //string strID = dtInvoiceHeader.Rows[cur_row]["InvoiceID"].ToString();
            //m_InvoiceID = Int32.Parse(dtInvoiceHeader.Rows[cur_row]["InvoiceID"].ToString());
            //txtViewInvoiceNbr.Text = invoice_nbr;
            //txtPaymentAmount.Text = String.Format("{0:c}", amount);
            //SetupPaymentsGrid();
           
            
        }
        private void GrdInvoiceClick()
        {
            if (grdInvoices.Rows.Count == 0 || grdInvoices.CurrentRow == null)
                return;
            int cur_row = grdInvoices.CurrentRow.Index;
            if (cur_row >= grdInvoices.Rows.Count - 1)
                return;
            string invoice_nbr = grdInvoices.CurrentRow.Cells["Invoice Nbr"].Value.ToString(); //dtInvoiceHeader.Rows[cur_row]["Invoice Nbr"].ToString();
            decimal amount = decimal.Parse(grdInvoices.CurrentRow.Cells["Balance"].Value.ToString()); //decimal.Parse(dtInvoiceHeader.Rows[cur_row]["Balance"].ToString(), System.Globalization.NumberStyles.Currency);
            string strID = grdInvoices.CurrentRow.Cells["InvoiceID"].Value.ToString();// Rows[cur_row]["InvoiceID"].ToString();

            m_InvoiceID = Int32.Parse(strID); //Int32.Parse(dtInvoiceHeader.Rows[cur_row]["InvoiceID"].ToString());
            txtViewInvoiceNbr.Text = invoice_nbr;
            txtPaymentAmount.Text = String.Format("{0:c}", amount);
            txtCheckNumber.Text = "";
            cmbPaymentType.SelectedIndex = 0;
            SetupPaymentsGrid();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            AddSalePayment();
        }
        private void AddSalePayment()
        {
            try
            {
                string msg = "";
                if (rdCheck.Checked && !ValidateEmpty(txtCheckNumber))
                {
                    msg = "Please enter a check number";
                    MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (m_InvoiceID == 0)
                {
                    msg = "Please select an invoice from the above grid";
                    MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!ValidateComoBox(cmbPaymentType))
                {
                    msg = "Please select payment purpose";
                    MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                if (!ValidateDecimal(txtPaymentAmount))
                {
                    msg = "Invalid invoice amount";
                    MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Payment pay = new Payment();
                pay.InvoiceID = m_InvoiceID;
                pay.PaymentDate = DateTime.Today;
                pay.Amount = decimal.Parse(txtPaymentAmount.Text,System.Globalization.NumberStyles.Currency);
                pay.CheckNumber = txtCheckNumber.Text;
                pay.Comments = "";
                pay.PaymentType = cmbPaymentType.SelectedValue.ToString();
                if (pay.PaymentType == "R") //returned check
                {
                    if (pay.Amount > 0)
                    {
                        pay.Amount *= -1;
                    }
                }
                int index = cmbPaymentType.SelectedIndex;
                string ssss = cmbPaymentType.Items[index].ToString();
                string txt = cmbPaymentType.Text;
                pay.AddPayment(pay);
                msg = "Payment saved successfully";
                MessageBox.Show(msg, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow CurRow = grdInvoices.CurrentRow;
                int cur_row = grdInvoices.CurrentRow.Index;
                UpdateInvoiceBalance(CurRow, pay.Amount);
                UpdateInvoicePaymentGrid(pay);
               // LoadPastDueInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateInvoiceBalance(DataGridViewRow row, decimal amount)
        {
            decimal tot_payments = decimal.Parse(row.Cells["Payments"].Value.ToString()); //decimal.Parse(dtInvoiceHeader.Rows[index]["Payments"].ToString());
            tot_payments += amount;
            int invoiceid = Int32.Parse(row.Cells["InvoiceID"].Value.ToString());
            int customerID = Int32.Parse(row.Cells["CustomerID"].Value.ToString());
            DateTime shipDate = DateTime.Parse(row.Cells["Due Date"].Value.ToString());
            decimal CustomerBalance = GetCustomerBalance(customerID, shipDate);
            
            for (int index = 0; index < dtInvoiceHeader.Rows.Count; index++)
            {
                if (invoiceid == Int32.Parse(dtInvoiceHeader.Rows[index]["InvoiceID"].ToString()))
                {

                    dtInvoiceHeader.Rows[index]["Payments"] = tot_payments;
                    decimal balance = decimal.Parse(dtInvoiceHeader.Rows[index]["Balance"].ToString());
                    balance -= amount;
                    dtInvoiceHeader.Rows[index]["Balance"] = balance;
                    dtInvoiceHeader.Rows[index]["Cus. Balance"] = CustomerBalance;
                    int id = Int32.Parse(dtInvoiceHeader.Rows[index]["InvoiceID"].ToString());
                    SalesInvoiceHeader inv = new SalesInvoiceHeader();
                    inv = InvoiceHeader[index];
                    id = inv.InvoiceID;
                    if (balance <= 0)
                    {
                        //mark the invoice as paid

                        inv.Status = (byte)OrderStatus.Paid;
                        inv.UpdateSalesInvoiceHeader(inv);
                        //LoadPastDueInvoices();

                    }
                    else
                    {
                        inv.Status = (byte)OrderStatus.Pending;
                        inv.UpdateSalesInvoiceHeader(inv);
                    }
                    break;
                }
            }
        }
        private void UpdateInvoicePaymentGrid(Payment pay)
        {
            try
            {
                //add new row to dtinvoicepayment.
                if (dtInvoicePayments.Columns.Count == 0)
                    return;
                DataRow dRow = dtInvoicePayments.NewRow();
                dRow["Nbr"] = dtInvoicePayments.Rows.Count + 1;
                dRow["Date"] = pay.PaymentDate;
                dRow["Pay. Type"] = pay.GetPaymentCodeDescription(pay.PaymentType);
                dRow["Amount"] = pay.Amount;
                dRow["Check Nbr"] = pay.CheckNumber;
                dtInvoicePayments.Rows.Add(dRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ShowCustomerStatement(int customerID, DateTime fromDate, DateTime ToDate)
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmCustomerStatement frm = new Reports.frmCustomerStatement();
            frm.FromDate = DateTime.Parse(fromDate.ToShortDateString());
            frm.ToDate = DateTime.Parse(ToDate.ToShortDateString());
            frm.CustomerId = customerID;
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void btnPrintSelectedInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = Int32.Parse(grdInvoices.CurrentRow.Cells["CustomerID"].Value.ToString());
                DateTime ToDate = DateTime.Parse(grdInvoices.CurrentRow.Cells["Due Date"].Value.ToString());
                DateTime FromDate = ToDate.AddMonths(-1);
                ShowCustomerStatement(customerId, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Customer Statement");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            //int count = grdInvoices.Rows.Count;
            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            //    {
            //        PrintSelected(ExcelInvoice.InvoiceType.Sale, row);
            //    }

            //    //for (int i = 0; i < count; i++)
            //    //{
            //    //    if (grdInvoices.Rows[i].Selected)
            //    //    {
            //    //        int invoice_id = Int32.Parse(dtInvoiceHeader.Rows[i]["InvoiceID"].ToString());
            //    //        int OrderId = Int32.Parse(dtInvoiceHeader.Rows[i]["Order ID"].ToString());
            //    //        // DataSet ds = sod.GetOrderDetailsGroupedByName(OrderId);
            //    //        ExcelInvoice inv = new ExcelInvoice(ExcelInvoice.InvoiceType.Sale);
            //    //        //inv.Print(ds.Tables[0]);
            //    //        inv.Print(invoice_id, OrderId);
            //    //        //int order_id = Int32.Parse(dtInvoiceHeader.Rows[i]["Order ID"].ToString());
            //    //        //string custName = dtInvoiceHeader.Rows[i]["Customer"].ToString();
            //    //        //PrintInvoice(invoice_id, order_id,custName);
            //    //        selected++;
            //    //    }
            //    //}
            //}
            
        }
        //private void PrintInvoice(int invoice_id, int order_id,string customerName)
        //{
        //    try
        //    {
        //        SalesOrderHeader soh = new SalesOrderHeader();
        //        soh = soh.GetSalesOrderHeader(order_id);
        //        SalesInvoiceHeader sih = new SalesInvoiceHeader();
        //        sih = sih.GetSalesInvoiceHeaders(invoice_id);
        //        Address address = new Address();
        //        address = address.GetAddresss(soh.ShipToAddressID);
        //        Address BillingAdd = new Address();
        //        BillingAdd = BillingAdd.GetAddresss(soh.BillToAddressID);

        //        ExcelInvoice inv = new ExcelInvoice(ExcelInvoice.InvoiceType.Sale);
        //        inv.CompanyName = customerName;
        //        inv.ShippingStreet = address.AddressLine1;
        //        inv.ShippingCity = address.City;
        //        inv.ShippingState = address.StateProvince;
        //        inv.ShippingZip = address.PostalCode;

        //        inv.BillingStreet = BillingAdd.AddressLine1;
        //        inv.BillingCity = BillingAdd.City;
        //        inv.BillingState = BillingAdd.StateProvince;
        //        inv.BillingZip = BillingAdd.PostalCode;
        //        //inv.InvoiceDate = DateTime.Today;

        //        inv.CusotmerID = soh.CustomerID;
        //        inv.DeliveryDate = sih.DueDate;
        //        inv.InvoiceDate = sih.InvoiceDate;
        //        inv.TotalDue = sih.TotalDue;
        //        inv.InvoiceNumber = sih.InvoiceNumber;
        //        inv.DueDate = sih.DueDate;


        //        Customer cus = new Customer();
        //        cus = cus.GetCustomer(inv.CusotmerID);
        //        decimal credit_limit = cus.CreditLimit;
        //        int territory_id = cus.TerritoryID;
        //        string terms = "Cash/Check";
        //        if (credit_limit > 0)
        //            terms = "One Week";
        //        inv.PaymentTerms = terms;

        //        Payment p = new Payment();
        //        decimal tot_payments = p.GetTotalPaymentsByCustomerId(inv.CusotmerID);
        //        decimal tot_invoices = sih.GetTotalInvoicesByCustomerId(inv.CusotmerID);
        //        inv.PreviousBalance = tot_invoices - tot_payments;

        //        //sale person data
        //        SalesTerritoryHistory territory = new SalesTerritoryHistory();
        //        DataSet dsTerritory = territory.GetSalesTerritoryHistory(cus.TerritoryID);
        //        string salepersonphone = "";
        //        string salepersonname = "";
        //        if (dsTerritory.Tables[0].Rows.Count > 0)
        //        {
        //            int saleperson_id = Int32.Parse(dsTerritory.Tables[0].Rows[0]["SalesPersonID"].ToString());
        //            Employee emp = new Employee();
        //            emp = emp.GetEmployee(saleperson_id);
        //            salepersonname = emp.FirstName.Trim() + " " + emp.LastName.Trim();
        //            if (emp.CellPhone != String.Empty)
        //                salepersonphone = emp.CellPhone.Trim();
        //            else if (emp.WorkPhone != String.Empty)
        //                salepersonphone = emp.WorkPhone;
        //            else if (emp.HomePhone != String.Empty)
        //                salepersonphone = emp.HomePhone;
        //        }
        //        inv.SalePerson = salepersonname + " " + salepersonphone;
        //        SalesOrderDetail sod = new SalesOrderDetail();
        //        DataSet dsInv = sod.GetSalesOrderDetailDataSet("SalesOrderID=" + order_id.ToString(), "SalesOrderID");
        //        DataTable dtInv = dsInv.Tables[0];
        //        //p.GetTotalPaymentsByInvoiceId(id);

        //        inv.Print(dtInv);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write(ex.Message, "PrintInvoice");
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void btnSearchInvoices_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClearPaymentsInfo();
                string where = "";
                string OrderBy = "invoiceid";
                if (txtViewInvoiceNbr.Text.Trim().Length > 0)
                {
                    if (ValidateNumbers(txtInvoiceNumber))
                    {
                        where = "invoicenumber= '" + txtInvoiceNumber.Text + "'";
                    }
                }
                else if (txtInvoiceOrderID.Text.Trim().Length > 0)
                {
                    if (ValidateNumbers(txtInvoiceOrderID))
                    {
                        where = "saleorderid= " + txtInvoiceOrderID.Text;
                    }
                }
                else
                {
                    where = "status !=6";
                    if (txtInvoiceFromDate.Text != String.Empty)
                    {
                        string fromdate = txtInvoiceFromDate.Text; //dtInvoiceFromDate.Value.ToShortDateString();
                        where += " and invoicedate >= '" + fromdate + "'";
                    }
                    if (txtInvoiceToDate.Text != String.Empty)
                    {
                        string todate = txtInvoiceToDate.Text; //dtInvoiceToDate.Value.ToShortDateString();
                        where += " and invoicedate <='" + todate + "'";
                    }
                    if (cmbInvoiceCustomers.SelectedIndex != 0)
                    {
                        where += " and accountnumber='" + cmbInvoiceCustomers.SelectedValue.ToString() + "'";
                    }
                    else if (cmbInvoiceTerritory.SelectedIndex > 0)
                    {
                        where += " and accountnumber in (select customerid from customer where territoryid=" + cmbInvoiceTerritory.SelectedValue.ToString() + ")";
                    }
                    if (cmbInvoiceStatus.Text == "Paid")
                    {
                        where += " and status=5";
                    }
                    else if (cmbInvoiceStatus.Text == "Past Due")
                    {
                        where += " and (status !=5)";
                    }
                }

                if (where.Length > 0)
                {
                    InvoiceHeader = new SalesInvoiceHeaderCollection();
                    SalesInvoiceHeader sih = new SalesInvoiceHeader();
                    dtInvoiceHeader.Clear();
                    InvoiceHeader = sih.GetSalesInvoiceHeadersCollection(where, OrderBy);
                    SetupInvoiceHeaderGrid();
                    SetupPaymentsGrid();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void tabPendingOrders_Click(object sender, EventArgs e)
        {

        }

        private void btnFilterPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtPendingOrders.Rows.Clear();
                cmbPendingOrderCustomer.SelectedIndex = 0;
                LoadPendingOrders(0);
                dtPendingOrdersDetail.Rows.Clear();
                if (dtPendingOrders.Rows.Count > 0)
                {
                    LoadPendingOrdersDetails();
                    PendingOrderClick(grdPendingOrderHeader.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbPendingOrderCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_loading)
                return;
            Address billing_address = null;
            Address shipping_address = null;

            try
            {
                int cust_id = Int32.Parse(cmbPendingOrderCustomer.SelectedValue.ToString());
                billing_address = new Address();
                shipping_address = new Address();
                billing_address.AddressID = GetCustomerAddressId(cust_id, "billing");
                shipping_address.AddressID = GetCustomerAddressId(cust_id, "shipping");
                m_PendingOrderBillingAddressID = billing_address.AddressID;
                m_PendingOrderShippingAddressID = shipping_address.AddressID;
                billing_address = GetCustomerAddress(billing_address.AddressID);
                shipping_address = GetCustomerAddress(shipping_address.AddressID);
                if (billing_address.AddressLine1 == String.Empty || billing_address.AddressLine1 == null)
                {
                    billing_address.AddressLine1 = shipping_address.AddressLine1;
                    billing_address.City = shipping_address.City;
                    billing_address.StateProvince = shipping_address.StateProvince;
                    billing_address.PostalCode = shipping_address.PostalCode;
                }
                FillShippingAddress(shipping_address);
                FillBillingAddress(billing_address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS");
            }
        }

        private void grdViewOrderHeader_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdViewOrderHeader.Rows.Count == 0)
                    return;
                if (grdViewOrderHeader.CurrentRow != null)
                {
                    int row = grdViewOrderHeader.CurrentRow.Index;
                    if (row >= ViewOrders.Count || row < 0)
                        return;
                    //int order_id = ViewOrders[row].SalesOrderID;
                    int order_id = Int32.Parse(grdViewOrderHeader.CurrentRow.Cells["ID"].Value.ToString());
                    string customerName = grdViewOrderHeader.CurrentRow.Cells["Customer"].Value.ToString();
                    int index = cmbViewOrderCustomers.FindStringExact(customerName);
                    if (index > 0)
                        cmbViewOrderCustomers.SelectedIndex = index;
                    else
                        cmbViewOrderCustomers.SelectedIndex = 0;
                    txtViewOrdersOrderID.Text = order_id.ToString();
                    FillSalesOrdersDetailsGrid(order_id, dtViewOrdersDetails, dgViewOrdersDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtInvoiceFromDate_ValueChanged(object sender, EventArgs e)
        {
            txtInvoiceFromDate.Text = dtInvoiceFromDate.Value.ToShortDateString();
        }

        private void grdPendingOrderDetails_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void cmbNewOrderTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_loading)
                return;
            ComboBox cmb = (ComboBox)sender;
            if(cmb.SelectedValue != null)
            {
                int terid = Int32.Parse(cmb.SelectedValue.ToString());
                LoadCustomers(terid, cmbCustomerName);
            }
        }
        private void LoadCustomers(int territoryid, ComboBox cmb)
        {
            Customer cust = new Customer();
            try
            {
                cust.CustomerID = 0;
                cust.Name = "<All Customers>";

                string where = "customer.activeflag=1";
                string orderby = "customer.name";
                CustomerCollection col = new CustomerCollection();
                if (territoryid > 0)
                {
                    //col = cust.GetAllCustomerCollection();
                    where += " and customer.TerritoryID=" + territoryid.ToString();
                }
                col = cust.GetCustomersCollection(where, orderby);
                col.Insert(0, cust);
                cmb.DataSource = col;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbEditViewTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_loading)
                return;
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue != null)
            {
                int terid = Int32.Parse(cmb.SelectedValue.ToString());
                LoadCustomers(terid, cmbViewOrderCustomers);
            }
        }

        private void cmbInvoiceTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_loading)
                return;
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue != null)
            {
                int terid = Int32.Parse(cmb.SelectedValue.ToString());
                LoadCustomers(terid, cmbInvoiceCustomers);
            }
        }

        private void grdInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdInvoices_SelectionChanged(object sender, EventArgs e)
        {
            GrdInvoiceClick();
        }

        private void txtFromDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtInvoiceToDate_ValueChanged(object sender, EventArgs e)
        {
            txtInvoiceToDate.Text = dtInvoiceToDate.Value.ToShortDateString();
        }

        private void btnClearInvoice_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupSearchInvoice.Controls)
            {
                if (c.Name.StartsWith("txt"))
                {
                    c.Text = "";
                }
                
            }
            cmbInvoiceCustomers.SelectedIndex = 0;
            cmbInvoiceStatus.SelectedIndex = 0;
            cmbInvoiceTerritory.SelectedIndex = 0;
        }

        private void btnClearPaymentsInfo_Click(object sender, EventArgs e)
        {
            ClearPaymentsInfo();
        }
        private void ClearPaymentsInfo()
        {
            txtViewInvoiceNbr.Text = "";
            txtPaymentAmount.Text = "";
            txtCheckNumber.Text = "";
            cmbPaymentType.SelectedIndex = 0;
        }

        private void btnPrintEditOrder_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdViewOrderHeader.SelectedRows)
                {
                    PrintSelected(ExcelInvoice.InvoiceType.Sale, row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

           
    }
}