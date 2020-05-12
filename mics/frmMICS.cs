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
using MICS.Reports;
namespace MICS
{
    public partial class frmMICS : Form
    {
        public frmMICS()
        {
            InitializeComponent();
           
            
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmAbout = new AboutBox();
            frmAbout.ShowDialog();
        }

        private void mnuVendor_Click(object sender, EventArgs e)
        {
            ShowVendor();
        }

        private void ShowVendor()
        {
            pnlPleaseWait.Visible = true;
            pnlPleaseWait.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            frmVendor frm = new frmVendor();
            frm.MdiParent = this;
            frm.Show();
            pnlPleaseWait.Visible = false;
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            ShowCustomer();
        }

        private void ShowCustomer()
        {
            pnlPleaseWait.Visible = true;
            pnlPleaseWait.Refresh();
            frmCustomer frm = new frmCustomer();
            frm.MdiParent = this;
            frm.Show();
            pnlPleaseWait.Visible = false;
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPleaseWait.Visible = true;
            pnlPleaseWait.Refresh();
            frmProducts frm = new frmProducts();
            frm.MdiParent = this;
            frm.Show();
            pnlPleaseWait.Visible = false;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuProductCategories_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.Show();
        }
        private void salesTerritoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesTerritory st = new frmSalesTerritory();
            //st.MdiParent = this;
            //st.Show();
        }

        private void frmMICS_Load(object sender, EventArgs e)
        {
            
            this.mainMenu.MdiWindowListItem = windowToolStripMenuItem;
            //frmSaleOrder s = new frmSaleOrder();
            //s.MdiParent = this;
            //s.Show();
            /*Me.MenuStrip1.MdiWindowListItem = WindowMenuToolStripItem
             * 
*/
            frmHome frm = new frmHome(this);
            frm.MdiParent = this;
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Top = this.Top;
            frm.Left = this.Left;
            frm.Show();
        }

        private void salesTerritoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSalesTerritory st = new frmSalesTerritory();
            st.MdiParent = this;
            st.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpecialOffers offer = new frmSpecialOffers();
            offer.MdiParent = this;
            offer.Show();

        }
        private void userSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.MdiParent = this;
            frm.Show();


        }

        //private void helpToolStripButton_Click(object sender, EventArgs e)
        //{
        //    frmProductPicker frm = new frmProductPicker();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void mnuPurchaseOrder_Click(object sender, EventArgs e)
        {


            ShowPurchaseOrder();
        }

        public void ShowPurchaseOrder()
        {
            statusBar.Visible = true;
            statusBarMessage.Text = "Loading...Please Wait";
            statusBarMessage.Width = 150;

            statusBar.Maximum = 100;
            statusBar.Value = 0;
            pnlPleaseWait.Visible = true;
            pnlPleaseWait.Refresh();
            pnlPleaseWait.Update();
            statusBar.Value = 50;
            frmPurchaseOrder frm = new frmPurchaseOrder();
            frm.MdiParent = this;
            statusBar.Value = 75;
            frm.Show();
            pnlPleaseWait.Visible = false;
            statusBar.Value = 100;
            statusBar.Value = 0;
            statusBar.Visible = false;
            statusBarMessage.Text = "";
        }
		 private void mnuSaleOrder_Click(object sender, EventArgs e)
        {
            ShowSalesOrder();
        }

        public void ShowSalesOrder()
        {
            statusBar.Visible = true;
            statusBar.Maximum = 100;
            statusBar.Value = 0;
            pnlPleaseWait.Visible = true;
            pnlPleaseWait.Refresh();
            statusBar.Value = 50;
            frmSaleOrder s = new frmSaleOrder();
            s.MdiParent = this;
            statusBar.Value = 75;
            s.Show();
            pnlPleaseWait.Visible = false;
            statusBar.Value = 100;
            statusBar.Visible = false;
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_addcustomers frm = new x_addcustomers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMICS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void importMobileDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSynchImport synch = new frmSynchImport();
            synch.ImportData();
            //try
            //{
            //    SqlCompactConnection conn = new SqlCompactConnection();
            //    conn.connect();
            //    DataTable dtSoh = new DataTable();
            //    string sql = "select * from salesorderheader where status=1";
            //    dtSoh = conn.GetDataTable(sql);
                
            //    //SalesOrderHeaderTableAdapter soh = new SalesOrderHeaderTableAdapter();
            //    //SalesOrderDetailTableAdapter sod = new SalesOrderDetailTableAdapter();
                
            //    SalesOrderHeader OrderHeader = new SalesOrderHeader();

            //    int rows = dtSoh.Rows.Count;
            //    if (rows == 0)
            //    {
            //        MessageBox.Show("There are no records to import", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //    int iCount = 0;
                
            //    foreach (DataRow dr in dtSoh.Rows)
            //    {
            //        int OrderID = Int32.Parse(dr["SalesOrderID"].ToString());
            //        OrderHeader.OrderDate = DateTime.Parse(dr["OrderDate"].ToString());
            //        OrderHeader.ShipDate = DateTime.Parse(dr["ShipDate"].ToString());
            //        OrderHeader.DueDate = DateTime.Parse(dr["DueDate"].ToString());
            //        OrderHeader.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
            //        OrderHeader.PurchaseOrderNumber = dr["PurchaseOrderNumber"].ToString();
            //        OrderHeader.CustomerID = Int32.Parse(dr["CustomerID"].ToString());
            //        OrderHeader.SalesPersonID = Int32.Parse(dr["SalesPersonID"].ToString());
            //        OrderHeader.BillToAddressID = Int32.Parse(dr["BillToAddressID"].ToString());
            //        OrderHeader.ShipToAddressID = Int32.Parse(dr["ShipToAddressID"].ToString());
            //        OrderHeader.ShipMethodID = Int32.Parse(dr["ShipMethodID"].ToString());
            //        OrderHeader.Status = byte.Parse(dr["Status"].ToString());
            //        OrderHeader.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
            //        OrderHeader.TaxAmt = decimal.Parse(dr["TaxAmt"].ToString());
            //        OrderHeader.TotalDue = decimal.Parse(dr["TotalDue"].ToString());
            //        OrderHeader.Comment = "Mobile Order";
            //        //save the mobile order id in currencyrateid
            //        OrderHeader.CurrencyRateID = OrderID;

            //        int ServerOrderID = OrderHeader.AddSalesOrderHeader(OrderHeader);

            //        //Get order details in the mobile db
            //        DataTable dtSod = new DataTable();
            //        sql = "select * from salesorderdetail where salesorderid=" + OrderID.ToString();
            //        dtSod = conn.GetDataTable(sql);
            //        //insert the details in the server
            //        foreach (DataRow drow in dtSod.Rows)
            //        {
            //            SalesOrderDetail OrderDetails = new SalesOrderDetail();
            //            OrderDetails.SalesOrderID = ServerOrderID;
            //            OrderDetails.ProductID = Int32.Parse(drow["ProductID"].ToString());
            //            OrderDetails.OrderQty = short.Parse(drow["OrderQty"].ToString());
            //            OrderDetails.UnitPrice = decimal.Parse(drow["UnitPrice"].ToString());
            //            OrderDetails.SpecialOfferID = Int32.Parse(drow["SpecialOfferID"].ToString());
            //            OrderDetails.UnitPriceDiscount = decimal.Parse(drow["UnitPriceDiscount"].ToString());
            //            OrderDetails.LineTotal = decimal.Parse(drow["LineTotal"].ToString());
            //            OrderDetails.CarrierTrackingNumber = "";
            //            OrderDetails.AddSalesOrderDetail(OrderDetails);

            //        }
            //        iCount++;
            //        //update the status of header record in the mobile to Uploaded
            //        sql = "update salesorderheader set status=9 where salesorderid=" + OrderID;
            //        conn.Execute(sql);
            //       //soh.UpdateStatusByID(OrderID);
                         

            //    }
            //    conn.CloseDatabase();
            //    MessageBox.Show(iCount.ToString() + " of " + rows.ToString() + " records imported successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            /*SqlCompactConnection con = new SqlCompactConnection();
            try
            {
                con.connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con = null;
            }*/

            }
            /*SqlCompactConnection con = new SqlCompactConnection();
            try
            {
                con.connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con = null;
            }*/

        private void mnuInventoryAdjustment_Click(object sender, EventArgs e)
        {
            ShowInventory();
        }

        private void ShowInventory()
        {
            frmInventoryAdjustment frm = new frmInventoryAdjustment();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void exportToMobileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSynchImport synch = new frmSynchImport();
            synch.ExportData();
        }

        private void showReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReports();
        }
        /*private void showReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReports();

        }*/

        private void ShowReports()
        {
            frmReports frm = new frmReports();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        private void ShowBackup()
        {
            frmBackup frm = new frmBackup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            ShowPurchaseOrder();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            ShowSalesOrder();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            ShowVendor();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowCustomer();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowReports();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowInventory();
        }

        private void btnPurchaseOrder_Click_1(object sender, EventArgs e)
        {
            ShowPurchaseOrder();
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBackup();
        }

        

        
    }
}