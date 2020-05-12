using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using MICS.DAL;
using MICS.MobileDataSetTableAdapters;
using MICS.Utilities;
namespace MICS
{
    public partial class frmSynchImport : Form
    {
        LogWriter log = new LogWriter();
        
        public frmSynchImport()
        {
            InitializeComponent();
           
        }
        public void SetProgressBar(string type, int value)
        {
            switch (type)
            {
                case "max":
                    progressBar1.Maximum = value;
                    break;
                case "min":
                    progressBar1.Maximum = value;
                    break;
                default:
                    progressBar1.Value = value;
                    break;
            }
        }
        public void StatusLable(string text)
        {
            lblStatus.Text = text;
        }
        public void ImportData()
        {
            this.Show();
            ImportOrders();
            ImportPyments();
        }
        public void ImportPyments()
        {
            Payment p = null;
            try
            {
                SqlCompactConnection conn = new SqlCompactConnection();
                conn.connect();
                lblStatus.Text = "Connected to mobile database";
                RefreshForm();
                string sql = "select * from payment";
                DataTable dtPayments = conn.GetDataTable(sql);
                int rows = dtPayments.Rows.Count;
                if (rows == 0)
                {
                    lblStatus.Text += "\nNo payments found";
                    //MessageBox.Show("There are no records to import", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                lblStatus.Text = "Importing Payments..";
                progressBar1.Minimum = 0;
                progressBar1.Maximum = rows;
                RefreshForm();
                int count = 0;
                foreach (DataRow dr in dtPayments.Rows)
                {
                    p = new Payment();
                    p.InvoiceID = Int32.Parse(dr["InvoiceId"].ToString());
                    p.PaymentType = "S";
                    p.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString());
                    p.Amount = decimal.Parse(dr["Amount"].ToString());
                    p.CheckNumber = dr["CheckNumber"].ToString();
                    p.Comments = "Mobile Payment";
                    if (dr["Comments"].ToString() != String.Empty)
                    {
                        p.Comments += " : " + dr["Comments"].ToString();
                    }
                    //p.PaymentCode = dr["PaymentCode"].ToString();;
                    p.ModifiedDate = DateTime.Today;
                    p.AddPayment(p);
                    lblStatus.Text = "removing mobile payment..";
                    sql = "delete payment where InvoiceId=" + p.InvoiceID;
                    conn.Execute(sql);
                    UpdatePaymentStatus(p.InvoiceID);
                    progressBar1.Value = count++;
                    RefreshForm();
                }
                lblStatus.Text = rows.ToString() + " payments imported successfully";
                progressBar1.Value = rows;
                RefreshForm();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdatePaymentStatus(int invoiceid)
        {
            decimal payments = 0;
            SalesInvoiceHeader inv = new SalesInvoiceHeader();
            GenericQuery q = new GenericQuery();
            try
            {
                inv = inv.GetSalesInvoiceHeaders(invoiceid);
                string sql = "select sum(amount) as TotalPayments from payment where invoiceid=" + inv.InvoiceID;
                DataSet ds = new DataSet();
                ds = q.GetDataSet(false, sql);
                if (ds.Tables[0].Rows.Count > 0)
                    payments = decimal.Parse(ds.Tables[0].Rows[0]["TotalPayments"].ToString());

                if (payments >= inv.TotalDue)
                {
                    inv.Status = 5;
                    inv.UpdateSalesInvoiceHeader(inv);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                inv = null;
                q = null;
            }
        }
        public void ImportOrders()
        {
            CustomerCollection NewCustomers = new CustomerCollection();
            SalesOrderHeaderCollection NewCustomerOrders = new SalesOrderHeaderCollection();
            SqlCompactConnection conn = new SqlCompactConnection();
            SalesOrderDetailCollection sodCol = new SalesOrderDetailCollection();
            try
            {
                
               // conn.connect();
                lblStatus.Text = "Connected to mobile database";
                RefreshForm();
                DataTable dtSoh = new DataTable();
                string sql = "select * from salesorderheader where status=1";
                dtSoh = conn.GetDataTable(sql);
                lblStatus.Text = "Received sales order header data (" + dtSoh.Rows.Count.ToString() + " records)";
                RefreshForm();
                
                //conn.Close();
                
                //SalesOrderHeaderTableAdapter soh = new SalesOrderHeaderTableAdapter();
                //SalesOrderDetailTableAdapter sod = new SalesOrderDetailTableAdapter();

                SalesOrderHeader OrderHeader = new SalesOrderHeader();

                int rows = dtSoh.Rows.Count;
                if (rows == 0)
                {
                    MessageBox.Show("There are no records to import", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.DeleteOldOrders();
                    return;
                }
               // conn = new SqlCompactConnection();
                
                DataTable dtSod = new DataTable();
                sql = "select * from salesorderdetail where salesorderid in (select salesorderid from salesorderheader where status=1)";
                dtSod = conn.GetDataTable(sql);
                lblStatus.Text = "Received sales order details data(" + dtSod.Rows.Count.ToString() + " records)";
                RefreshForm();

                int iCount = 0;
                lblStatus.Text = "Copying sales order information";
                RefreshForm();
                progressBar1.Minimum = 1;
                progressBar1.Maximum = dtSoh.Rows.Count;
                foreach (DataRow dr in dtSoh.Rows)
                {
                    OrderHeader = new SalesOrderHeader();
                    int OrderID = Int32.Parse(dr["SalesOrderID"].ToString());
                    OrderHeader.OrderDate = DateTime.Parse(dr["OrderDate"].ToString());
                    OrderHeader.ShipDate = DateTime.Parse(dr["ShipDate"].ToString());
                    OrderHeader.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                    OrderHeader.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
                    OrderHeader.PurchaseOrderNumber = dr["PurchaseOrderNumber"].ToString();
                    OrderHeader.CustomerID = Int32.Parse(dr["CustomerID"].ToString());
                    if (OrderHeader.CustomerID == 0)
                    {
                        //This is a new customer.
                        Customer NewCus = new Customer();
                        string comments = dr["Comment"].ToString();
                        //The comments has the territoryid and customer name in the format TerritoryID~CustomerName
                        int pos = comments.IndexOf("~");
                        string territory = comments.Substring(0, pos);
                        string CustName = comments.Substring(pos + 1);
                        NewCus.TerritoryID = Int32.Parse(territory);
                        NewCus.Name = CustName;
                        NewCus.AddressID = 0;
                        NewCus.BillingAddressID = 0;
                        NewCus.ModifiedDate = DateTime.Now;
                        OrderHeader.CustomerID = NewCus.AddCustomer(NewCus);
                        NewCus.CustomerID = OrderHeader.CustomerID;
                        NewCustomers.Add(NewCus);
                        
                    }
                    OrderHeader.SalesPersonID = Int32.Parse(dr["SalesPersonID"].ToString());
                    OrderHeader.BillToAddressID = Int32.Parse(dr["BillToAddressID"].ToString());
                    OrderHeader.ShipToAddressID = Int32.Parse(dr["ShipToAddressID"].ToString());
                    OrderHeader.ShipMethodID = Int32.Parse(dr["ShipMethodID"].ToString());
                    OrderHeader.Status = byte.Parse(dr["Status"].ToString());
                    OrderHeader.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
                    OrderHeader.TaxAmt = decimal.Parse(dr["TaxAmt"].ToString());
                    OrderHeader.TotalDue = decimal.Parse(dr["TotalDue"].ToString());
                    OrderHeader.Comment = "Mobile Order";
                    //save the mobile order id in currencyrateid
                    OrderHeader.CurrencyRateID = OrderID;
                    //save the mobile order id in currencyrateid
                    OrderHeader.CurrencyRateID = OrderID;

                    int ServerOrderID = OrderHeader.AddSalesOrderHeader(OrderHeader);
                    OrderHeader.SalesOrderID = ServerOrderID;
                    if (dr["CustomerID"].ToString() == "0")
                    {
                        //save orders of new customers in the collection
                        NewCustomerOrders.Add(OrderHeader);
                    }
                    //reset the status to 9 in the mobile
                    
                    //Get order details in the mobile db
                    // DataTable dtSod = new DataTable();
                    //  sql = "select * from salesorderdetail where salesorderid=" + OrderID.ToString();
                    //  dtSod = conn.GetDataTable(sql);
                    //insert the details in the server
                    foreach (DataRow drow in dtSod.Rows)
                    {
                        SalesOrderDetail OrderDetails = new SalesOrderDetail();
                        if (OrderID == Int32.Parse(drow["SalesOrderID"].ToString()))
                        {
                            OrderDetails.SalesOrderID = ServerOrderID;
                            OrderDetails.ProductID = Int32.Parse(drow["ProductID"].ToString());
                            OrderDetails.OrderQty = short.Parse(drow["OrderQty"].ToString());
                            OrderDetails.UnitPrice = decimal.Parse(drow["UnitPrice"].ToString());
                            OrderDetails.SpecialOfferID = Int32.Parse(drow["SpecialOfferID"].ToString());
                            OrderDetails.UnitPriceDiscount = decimal.Parse(drow["UnitPriceDiscount"].ToString());
                            if (OrderDetails.UnitPriceDiscount > 0 && OrderDetails.SpecialOfferID == 0)
                            {
                                //check if the discount is coming from special offer deal.
                                SpecialOfferProduct sop = new SpecialOfferProduct();
                                DataSet ds = new DataSet();
                                ds = sop.GetDiscountByProduct(OrderDetails.ProductID, OrderDetails.OrderQty);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["SpecialOfferID"] != DBNull.Value)
                                        OrderDetails.SpecialOfferID = Int32.Parse(ds.Tables[0].Rows[0]["SpecialOfferID"].ToString());
                                }

                            }
                            OrderDetails.LineTotal = decimal.Parse(drow["LineTotal"].ToString());
                            OrderDetails.CarrierTrackingNumber = "";
                            OrderDetails.AddSalesOrderDetail(OrderDetails);

                        }

                    }
                    iCount++;
                    //update the status of header record in the mobile to Uploaded
                    
                    //soh.UpdateStatusByID(OrderID);
                    progressBar1.Value = iCount;
                    RefreshForm();
                    OrderHeader = null;
                }
                lblStatus.Text = "updating sales mobile status";
                //conn.UpdateMobileStatus(dtSoh);
                conn.UpdateMobileOrderHeader("status=9", "status=1");
                MessageBox.Show(iCount.ToString() + " of " + rows.ToString() + " records imported successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //update new order customerid
                for (int j = 0; j < NewCustomerOrders.Count; j++)
                {
                    string update = "CustomerId=" + NewCustomerOrders[j].CustomerID.ToString();
                    string where = "SalesOrderID=" + NewCustomerOrders[j].CurrencyRateID.ToString();
                    conn.UpdateMobileOrderHeader(update, where);
                }
                //Add the new customer to the mobile database
                if (NewCustomers.Count > 0)
                {
                    conn.SynchForm = this;
                    conn.AddCustomer(NewCustomers);
                }
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                lblStatus.Text = "Removing old orders";
                progressBar1.Value = 25;
                RefreshForm();
                conn.DeleteOldOrders();
                lblStatus.Text = "Finished Removing old orders";
                progressBar1.Value = 100;
                RefreshForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            

        }

        public void ExportData()
        {
            try
            {
                int nTickStart = Environment.TickCount;
                this.Show();
                lblStatus.Text = "Updating mobile sales orders ..";
                StripStatus.Text = "sales orders ..";
                RefreshForm();
                //ExportSalesOrder();

                StripStatus.Text = "Sales Territory ..";
                ExportTerritories();
                lblStatus.Text = "Exporting customers";
                StripStatus.Text = "customers ..";
                ExportCustomers();
                ExportAddresses();

                lblStatus.Text = "Exporting Invoices and Payments ..";
                StripStatus.Text = "Payments..";
                progressBar1.Value = 0;
                RefreshForm();
                ExportInvoicesBalance();

                progressBar1.Value = 0;
                lblStatus.Text = "Exporting Products";
                StripStatus.Text = "Products ..";
                RefreshForm();
                ExportProducts();
                ExportCategories();
                ExportSpecialOffers();
                int nTickEnd = Environment.TickCount;
                int nTickTotal = (nTickEnd - nTickStart) / 1000;
                //progressBar1.Value = 100;
                lblStatus.Text = "Finished. Total seconds:" + nTickTotal.ToString();
                StripStatus.Text = "Done.";
                RefreshForm();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                MessageBox.Show(ex.Message);
            }
        }
        public void ExportSalesOrder()
        {
            UpdateMobileSalesOrder();
            AddNewSalesOrdersToMobile();
        }
        private void UpdateMobileSalesOrder()
        {
            
            SqlCompactConnection conn = new SqlCompactConnection();
            try
            {
                conn.connect();
                DataTable dt = new DataTable();
                string sql = "select salesorderid,salespersonid from salesorderheader where status <> 1";
                dt = conn.GetDataTable(sql);
                int rows = dt.Rows.Count;
                int i = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = rows;
                foreach (DataRow dr in dt.Rows)
                {
                    //Get sales order data from server.
                    SalesOrderHeader soh = new SalesOrderHeader();
                    SalesOrderHeaderCollection SohCol = new SalesOrderHeaderCollection();
                    string where = "CurrencyRateID=" + dr["SalesOrderID"].ToString();
                    where += " and SalesPersonID=" + dr["SalesPersonID"].ToString();
                    string orderby = "SalesOrderID";
                    SohCol = soh.GetSalesOrderHeaderCollection(where, orderby);
                    int count = SohCol.Count;
                    if (count == 0)
                    {
                        continue;
                    }
                                       
                    //update salesorder in mobile.
                    SohCol[0].Status = 9;
                    soh.UpdateSalesOrderHeaderMobile(SohCol[0]);

                    //get server order details
                    SalesOrderDetail sod = new SalesOrderDetail();
                    SalesOrderDetailCollection SodCol = new SalesOrderDetailCollection();
                    where = "SalesOrderID=" + SohCol[0].SalesOrderID;
                    orderby = "SalesOrderID";
                    SodCol = sod.GetSalesOrderDetailCollection(where, orderby);

                    //Delete sales order details from mobile
                    sod.DeleteSalesOrderDetailMobile(SohCol[0].CurrencyRateID);
                    //copy sales order details from the server to the mobile.
                    for (int j = 0; j < SodCol.Count; j++)
                    {
                        SodCol[j].SalesOrderID = SohCol[0].CurrencyRateID;
                        sod.AddSalesOrderDetailsMobile(SodCol[j]);
                    }
                    i++;
                    progressBar1.Value = i;
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }

        }
        public void RefreshForm()
        {
            lblStatus.Refresh();
            this.Refresh();
            progressBar1.Refresh();
        }
        private void AddNewSalesOrdersToMobile()
        {
        }
        private void ExportInvoicesBalance()
        {
            ExportDueInvoices();
        }
        public void ExportCategories()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            try
            {
                StripStatus.Text = "Products Sub Categories..";
                ProductSubcategory sub = new ProductSubcategory();
                ProductCategory cat = new ProductCategory();
                conn.DropProdctSubCategoryTable();
                conn.CreateProdctSubCategoryTable();
                ProductSubcategoryCollection subCol = sub.GetAllProductSubcategoryCollection();
                conn.SynchForm = this;
                conn.AddProductSubCategory(subCol);

                StripStatus.Text = "Products Categories..";
                conn.DropProdctCategoryTable();
                conn.CreateProdctCategoryTable();
                ProductCategoryCollection catCol = cat.GetAllProductCategoryCollection();
                conn.AddProductCategory(catCol);
                sub = null;
                cat = null;
                subCol = null;
                catCol = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
        }
        public void ExportTerritories()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            SalesTerritory ter = new SalesTerritory();
            try
            {
                SalesTerritoryCollection colTerr = ter.GetAllSalesTerritoryCollection();
                conn.SynchForm = this;
                conn.DropSalesTerritoryTable();
                conn.CreateTerritoryTable();
                conn.AddSalesTerritory(colTerr);
                ter = null;
                colTerr = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
        }
        public void ExportCustomers()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            try
            {
                
                Customer cus = new Customer();
                CustomerCollection CusCol = new CustomerCollection();
                string where = "customerid > 0 AND ActiveFlag=1";
                string orderby = "customerid";
                CusCol = cus.GetCustomersCollection(where, orderby);
                conn.DropCustomerTable();
                conn.CreateCustomerTable();
                conn.SynchForm = this;
              
                conn.AddCustomer(CusCol);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
            
        }
        public void ExportAddresses()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            try
            {

                Address add = new Address();
                AddressCollection AddCol = new AddressCollection();
                string where = "addressid in (select Addressid from customer where activeflag=1)";
                string orderby = "addressid";
                AddCol = add.GetAddressCollection(where, orderby);
                conn.DropAddressTable();
                conn.CreateAddressTable();
                conn.SynchForm = this;
                conn.AddAddress(AddCol);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
        }
        public void ExportProducts()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            Product p = new Product();
            ProductCollection ProdCol = new ProductCollection();
            int i=0;
            try
            {
                string where = "activeflag=1";
                string orderby = "productid";
                ProdCol = p.GetProductsCollection(where, orderby);
                conn.DropProdctTable();
                conn.CreateProductTable();
                conn.SynchForm = this;
                conn.AddProduct(ProdCol);
                                
            }
            catch (Exception ex)
            {
                log.Write("Product Record faild to export (id=" + ProdCol[i].ProductID + "). Error:" + ex.Message,"frmSynch.ExportProduct");
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
        }
        public void ExportDueInvoices()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            SalesInvoiceHeader sih = new SalesInvoiceHeader();
            DataSet ds = new DataSet();
            int count = 0;
            try
            {
                ds = sih.GetInvoicesBalance();
                count = ds.Tables[0].Rows.Count;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = count;
                lblStatus.Text = "Exporting Invoices (" + count.ToString() + " records)";
                RefreshForm();
                conn.DropInvoicesBalanceTable();
                //progressBar1.Value = count/5 ;
                RefreshForm();
                conn.SynchForm = this;
                conn.CreateInvoicesBalanceTable();
                //progressBar1.Value = count * 2/5;
                RefreshForm();
                if(ds != null)
                  conn.InsertInvoicesBalance(ds.Tables[0]);
                //progressBar1.Value = count ;
                //RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
            }
            
        }
        public void ExportSpecialOffers()
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            SpecialOffer so = new SpecialOffer();
            SpecialOfferCollection soCol = new SpecialOfferCollection();
            SpecialOfferProduct sop = new SpecialOfferProduct();
            SpecialOfferProductCollection sopCol = new SpecialOfferProductCollection();
            string where = "startdate <= getdate() and enddate >= getdate()";
            string orderby = "specialofferid";
            try
            {
                //ds = q.GetDataSet(false, sql);
                soCol = so.GetSpecialOffersCollection(where, orderby);
                conn.SynchForm = this;
                conn.DropSepcialOfferTable();
                conn.CreateSpecialOfferTable();
                conn.AddSpecialOffer(soCol);
                where = "specialofferid in (select specialofferid from specialoffer where startdate <= getdate() and enddate >= getdate())";
                orderby = "specialofferid";
                sopCol = sop.GetSpecialOfferProductsCollection(where, orderby);
                conn.DropSepcialOfferProductTable();
                conn.CreateSpecialOfferProductTable();
                conn.AddSpecialOfferProduct(sopCol);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseDatabase();
                conn = null;
                so = null;
                soCol = null;
                sop = null;
                sopCol = null;
                //ds.Dispose();
               // q = null;
            }
        }

        private void frmSynchImport_Load(object sender, EventArgs e)
        {
           

        }
                
                
    }
}