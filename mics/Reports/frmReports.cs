using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using Microsoft.Reporting.WinForms;

namespace MICS.Reports
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnMPPOk_Click(object sender, EventArgs e)
        {
            int reportType = Int32.Parse(cmbReports.SelectedValue.ToString());
            switch (reportType)
            {
                case 1:
                    //Purchased Products Report
                    ShowPurchasedProudctsReport();
                    break;
                case 2:
                    ShowSpecialOffer();
                    break;
                case 3:
                    //ShowProductTracking();
                    Show30DaysPastDue();
                    break;
                case 4:
                    ShowCustomerStatement();
                    break;
                case 5:
                    ShowCurrentSpeicalOffers();
                    break;
                case 6:
                    ShowProductSalesByCustomer();
                    break;
                case 7:
                    ShowCustomerList();
                    break;
                case 8:
                    ShowVendorList();
                    break;
                case 9:
                    ShowProductList();
                    break;
                default:
                    break;
            }
         
        }
        private void ShowProductSalesByCustomer()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmProductSalesByCustomer frm = new frmProductSalesByCustomer(); 
            frm.FromDate = DateTime.Parse(dtMPPFrom.Value.ToShortDateString());
            frm.ToDate = DateTime.Parse(dtMPPToDate.Value.ToShortDateString());
            frm.ProductID = Int32.Parse(cmbProducts.SelectedValue.ToString());
            frm.PName = cmbProducts.Text;
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowCustomerStatement()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmCustomerStatement frm = new frmCustomerStatement();
            frm.FromDate = DateTime.Parse(dtMPPFrom.Value.ToShortDateString());
            frm.ToDate = DateTime.Parse(dtMPPToDate.Value.ToShortDateString());
            frm.CustomerId =Int32.Parse(cmbCustomers.SelectedValue.ToString());
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowSpecialOffer()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmSpecialOfferReport frm = new frmSpecialOfferReport();
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowCurrentSpeicalOffers()
        {
            Cursor.Current = Cursors.WaitCursor;
            CurrentSpecialOffer frm = new CurrentSpecialOffer();
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowProductTracking()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmProductTracking frm = new frmProductTracking();
            frm.FromDate = DateTime.Parse(dtMPPFrom.Value.ToShortDateString());
            frm.ToDate = DateTime.Parse(dtMPPToDate.Value.ToShortDateString());
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void Show30DaysPastDue()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmPastDueInvoices frm = new frmPastDueInvoices();
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowPurchasedProudctsReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            frmSalesReports frm = new frmSalesReports();
            frm.Show();
            //Reports.frmPurchsedProducts frm = new frmPurchsedProducts();
            //frm.FromDate = DateTime.Parse(dtMPPFrom.Value.ToShortDateString());
            //frm.ToDate = DateTime.Parse(dtMPPToDate.Value.ToShortDateString());
            //frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowCustomerList()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmCustomerList frm = new frmCustomerList();
            frm.SetReportParameters(chkListReportColumns);
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowVendorList()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmVendorsList frm = new frmVendorsList();
            frm.SetReportParameters(chkListReportColumns);
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ShowProductList()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmProductsList frm = new frmProductsList();
            frm.SetReportParameters(chkListReportColumns);
            frm.Show();
            Cursor.Current = Cursors.Default;
        }
        private void btnSPRunReport_Click(object sender, EventArgs e)
        {
            ShowSoldProductReport();
            Cursor.Current = Cursors.Default;

        }

        private void ShowSoldProductReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            Reports.frmSoldProducts frm = new frmSoldProducts();
            frm.FromDate = dtMPPFrom.Value.ToShortDateString();
            frm.ToDate =dtMPPToDate.Value.ToShortDateString();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmReports_Load(object sender, EventArgs e)
        {
            Product p = new Product();
            ProductCollection pcol = new ProductCollection();
            Product selProd = new Product();
            Customer c = new Customer();
            Customer select = new Customer();

            CustomerCollection col = new CustomerCollection();
            List<SimplePair> pair = new List<SimplePair>();
            pair.Add(new SimplePair(0,"<Select Report Type>"));
            pair.Add(new SimplePair(1, "Sales Report"));
            pair.Add(new SimplePair(2, "Special Offer"));
            pair.Add(new SimplePair(3, "30+ Past Due Invoices"));
            pair.Add(new SimplePair(4, "Customer Statement Report"));
            pair.Add(new SimplePair(5, "Current Special Offers"));
            //pair.Add(new SimplePair(5, "Customer Payments Report"));
            //pair.Add(new SimplePair(6, "Product Sales By Customer Report"));
            pair.Add(new SimplePair(7, "Customers List"));
            pair.Add(new SimplePair(8, "Vendors List"));
            pair.Add(new SimplePair(9, "Products List"));


            cmbReports.DataSource = pair;
            cmbReports.DisplayMember = "DisplayMember";
            cmbReports.ValueMember = "ValueMember";
            
            select.CustomerID = 0;
            select.Name = "<Select One>";
            col = c.GetAllCustomerCollection();
            col.Insert(0, select);

            cmbCustomers.DataSource = col;
            cmbCustomers.DisplayMember = "Name";
            cmbCustomers.ValueMember = "CustomerID";

            selProd.ProductID = 0;
            selProd.Name = "<Select One>";
            pcol = p.GetAllProductsCollection();
            pcol.Insert(0, selProd);
            cmbProducts.DataSource = pcol;
            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "ProductID";


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReports.Text == "Customer Statement Report" ||
               cmbReports.Text == "Product Sales By Customer Report")
            {
                panelProductParam.Visible = true;
            }
            else
            {
                panelProductParam.Visible = false;
            }
            if (cmbReports.Text == "Customer Statement Report")
            {
                cmbCustomers.Visible=true;
               // panelProductParam.Visible = true;
                panelListParam.Visible = false;
            }
            else
            {
                cmbCustomers.Visible = false;
               // panelProductParam.Visible = false;
            }
            if (cmbReports.Text == "Product Sales By Customer Report")
            {
                cmbProducts.Visible = true;
                panelProductParam.Visible = true;
            }
            else
            {
                cmbProducts.Visible = false;
                //panelProductParam.Visible = false;
            }
            if (cmbReports.Text == "Customers List" || cmbReports.Text == "Vendors List" || cmbReports.Text == "Products List")
            {
                panelListParam.Visible = true;
                LoadParametersList();
            }
            else
            {
                panelListParam.Visible = false;
            }
        }
        private void LoadParametersList()
        {
            IList<string> ParamArray = null;
            chkListReportColumns.Items.Clear();
            switch (cmbReports.Text)
            {
                case "Customers List":
                    Reports.frmCustomerList frm = new frmCustomerList();
                    ReportParameterInfoCollection p = frm.GetReportParamters();
                    for (int i = 0; i < p.Count; i++)
                    {
                        chkListReportColumns.Items.Add(p[i].Name, true);
                    }
                    //chkListReportColumns.Items.Add("ID", false);
                    //chkListReportColumns.Items.Add("name", true);
                    //chkListReportColumns.Items.Add("address", true);
                    //chkListReportColumns.Items.Add("phone", true);
                    
                    break;
                case "Vendors List":
                    Reports.frmVendorsList frmV = new frmVendorsList();
                    ReportParameterInfoCollection VendParam = frmV.GetReportParamters();
                    ParamArray = VendParam[0].Values;
                    for (int i = 0; i < ParamArray.Count; i++)
                    {
                        chkListReportColumns.Items.Add(ParamArray[i], true);
                    }
                    break;
                case "Products List":
                    Reports.frmProductsList frmP = new frmProductsList();
                    ReportParameterInfoCollection ProdParam = frmP.GetReportParamters();
                    ParamArray = ProdParam[0].Values;
                    for (int i = 0; i < ParamArray.Count; i++)
                    {
                        chkListReportColumns.Items.Add(ParamArray[i], true);
                    }
                    break;
                default:
                    break;
            }
        }
        private void LoadTerritory()
        {
            //SalesTerritory st = new SalesTerritory();
            //DataSet ds = st.GetAllSalesTerritoryDataSet();
            //DataTable dt = ds.Tables[0];
            //DataRow dr = dt.NewRow();
            //dr[0] = "0";
            //dr[1] = "<All Territories>";
            //dt.Rows.InsertAt(dr, 0);
            //cmbTerritory.DataSource = dt;
            //cmbTerritory.DisplayMember = "Name";
            //cmbTerritory.ValueMember = "TerritoryID";
        }
    }
}