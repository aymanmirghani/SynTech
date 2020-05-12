using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MICS.BLL;

namespace MICS.Reports
{
    public partial class frmSalesReports : Form
    {
        private bool m_Loading = false;
        public frmSalesReports()
        {
            InitializeComponent();
        }
        private void SetReportData()
        {
            rptView.Visible = true;
            rptView.Reset();
            rptView.ShowProgress = true;
            rptView.Refresh();
            rptView.LocalReport.DataSources.Clear();
            ReportDataSource rds = null;
            ReportParameter[] p = null;
            rptView.LocalReport.ReportEmbeddedResource = "MICS.Reports.SalesByTerritory.rdlc";
            this.YTDSalesByTerritoryTableAdapter.SetTimeOut = 120;
            this.Refresh();
            string where = "";
            string GroupBy = "";
            switch (cmbGroupBy.SelectedValue.ToString())
            {
                case "Territories":
                    GroupBy = "ter.name";
                    break;
                case "Product Categories":
                    GroupBy = "cat.name";
                    break;
                default:
                    break;
            }
            if (rdCurYear.Checked)
            {
                where = "soh.orderdate >= dateadd(Month,-13,getdate())";
                GroupBy = "";

            }
            else if (rdCurMonth.Checked)
            {
                string firstDay = cmbMonth.SelectedItem.ToString() + "/01/" + cmbYear.SelectedItem.ToString();
                string lastDay = cmbMonth.SelectedItem.ToString() + "/" + DateTime.DaysInMonth(Int32.Parse(cmbYear.SelectedItem.ToString()), Int32.Parse(cmbMonth.SelectedItem.ToString())) + "/" + cmbYear.SelectedItem.ToString();
                where = "soh.orderdate >='" + firstDay + "' and soh.orderdate <='" + lastDay + "'";
            }
            if (cmbTerritory.SelectedValue.ToString() != "0")
            {
                where += " and ter.territoryid=" + cmbTerritory.SelectedValue;
                if (cmbCustomer.SelectedValue.ToString() != "0")
                {
                    where += " and cus.customerid=" + cmbCustomer.SelectedValue;
                }
            }
            if (cmbCategory.SelectedIndex > 0)
            {
                where += " and cat.productcategoryid=" + cmbCategory.SelectedValue;
                if (cmbProductName.SelectedIndex > 0)
                {
                    where += " and prd.productid=" + cmbProductName.SelectedValue;
                }
                else if (cmbSubCategory.SelectedIndex > 0)
                {
                    where += " and sub.productsubcategoryid=" + cmbSubCategory.SelectedValue;
                    
                }
                
            }
            this.YTDSalesByTerritoryTableAdapter.FillByWhere(this.PurchasedProducts.YTDSalesByTerritory, where, GroupBy);
            rds = new ReportDataSource("PurchasedProducts_YTDSalesByTerritory", YTDSalesByTerritoryTableAdapter.GetData());
            rds.Value = this.YTDSalesByTerritoryBindingSource;
            
            SetReportParameters();
            rptView.LocalReport.DataSources.Add(rds);
            rptView.RefreshReport();

            
        }
        private void frmSalesReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.SalesReport' table. You can move, or remove it, as needed.
            try
            {
                PopulateComboBoxes();
                SetReportData();
                //  SetReportParameters();

                //this.YTDSalesByTerritoryTableAdapter.Fill(this.PurchasedProducts.YTDSalesByTerritory);
                //this.rptView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
           
        }
        private void PopulateComboBoxes()
        {
            m_Loading = true;
            LoadMesures();
            LoadCategories();
            LoadSubCategories(0);
            LoadProducts(0, 0);
            LoadTerritories();
            LoadGroupBy("Sales");
            LoadMonthYear();
            m_Loading = false;
        }
        private void LoadMesures()
        {
            cmbMeasures.Items.Add("Sales");
            cmbMeasures.Items.Add("Purchases");
            cmbMeasures.SelectedIndex = 0;
        }
        private void LoadCategories()
        {
            ProductCategory cat = new ProductCategory();
            ProductCategoryCollection catCol = new ProductCategoryCollection();
            m_Loading = true;
            try
            {
                catCol = cat.GetAllProductCategoryCollection();

                ProductCategory AllCat = new ProductCategory();
                cat.ProductCategoryID = 0;
                cat.Name = "All";
                cat.ModifiedDate = DateTime.Now;
                catCol.Insert(0, cat);

                cmbCategory.DataSource = catCol;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "ProductCategoryID";
               // m_Loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadSubCategories(int CategoryId)
        {
            if (m_Loading)
                return;
            string where = "ProductCategoryId=" + CategoryId.ToString();
            string order_by = "Name";
            ProductSubcategory sub = new ProductSubcategory();
            ProductSubcategoryCollection subCol = new ProductSubcategoryCollection();
            try
            {
                m_Loading = true;
                subCol = sub.GetProductSubcategoryCollection(where, order_by);
                sub.ProductCategoryID = 0;
                sub.ProductSubcategoryID = 0;
                sub.Name = "All";
                sub.ModifiedDate = DateTime.Now;
                subCol.Insert(0, sub);
                cmbSubCategory.DataSource = subCol;
                cmbSubCategory.DisplayMember = "Name";
                cmbSubCategory.ValueMember = "ProductSubcategoryId";
                m_Loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadProducts(int CategoryId, int SubCategoryId)
        {
            if (m_Loading)
                return;
            string where = "";
            string orderby = "Description";
            if (SubCategoryId > 0)
            {
                where = "ProductSubCategoryId=" + SubCategoryId.ToString();
            }
            else
            {
                where = "ProductSubCategoryId in (select ProductSubCategoryId from ProductSubCategory where ProductCategoryId=" + CategoryId.ToString() + ")";
            }
            Product p = new Product();
            ProductCollection pCol = new ProductCollection();
            try
            {
                pCol = p.GetProductsCollection(where, orderby);
                p.ProductID = 0;
                p.Name = "All";
                p.Description = "All";
                p.ProductSubcategoryID = 0;
                p.ModifiedDate = DateTime.Now;
                p.ListPrice = 0;
                pCol.Insert(0, p);
                cmbProductName.DataSource = pCol;
                cmbProductName.DisplayMember = "Description";
                cmbProductName.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LoadTerritories()
        {
            SalesTerritory terr = new SalesTerritory();
            SalesTerritoryCollection terrCol = new SalesTerritoryCollection();
            try
            {
                terrCol = terr.GetAllSalesTerritoryCollection();
                terr.TerritoryID = 0;
                terr.Name = "All";
                terr.ModifiedDate = DateTime.Now;
                terrCol.Insert(0, terr);
                cmbTerritory.DataSource = terrCol;
                cmbTerritory.DisplayMember = "Name";
                cmbTerritory.ValueMember = "TerritoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                terr = null;
            }
        }
        private void LoadCustomers(int TerritoryId)
        {
            if (m_Loading)
                return;
            string where = "t.TerritoryId=" + TerritoryId;
            string orderby = "Name";
            Customer cus = new Customer();
            CustomerCollection cusCol = new CustomerCollection();
            try
            {
                cusCol = cus.GetCustomersCollection(where, orderby);
                cus.CustomerID = 0;
                cus.TerritoryID = 0;
                cus.Name = "All";
                cus.AddressID = 0;
                cus.ModifiedDate = DateTime.Today;
                cusCol.Insert(0, cus);
                cmbCustomer.DataSource = cusCol;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cusCol = null;
                cus = null;
            }
        }
        private void LoadGroupBy(string measure)
        {
            string[] SalesGroupBy = { "Territories", "Product Categories"}; //, "Product Sub Categories", "Product Names", "Customers" };
            string[] PurchasesGroupBy = { "Product Catetories", "Product Sub Categories", "Product Names", "Vendors" };
            switch (measure)
            {
                case "Sales":
                    cmbGroupBy.DataSource = SalesGroupBy;
                    break;
                case "Purchases":
                    cmbGroupBy.DataSource = PurchasesGroupBy;
                    break;
            }
            cmbGroupBy.SelectedIndex = 0;
        }
        private void LoadMonthYear()
        {

            string[,] CalMonth = { {"1", "JAN"},
                                   {"2", "FEB"},
                                   {"3", "MAR"},
                                   {"4", "APR"},
                                   {"5", "MAY"},
                                   {"6", "JUN"},
                                   {"7", "JUL"},
                                   {"8", "AUG"},
                                   {"9", "SEP"},
                                   {"10", "OCT"},
                                   {"11", "NOV"},
                                   {"12", "DEC"}
            };
            for (int i = 1; i<13; i++)
            {
                cmbMonth.Items.Add(i.ToString());
                if (i == DateTime.Today.Month)
                    cmbMonth.SelectedIndex = i - 1;
            }
           // cmbMonth.SelectedIndex = 0;
            int curYear = DateTime.Today.Year;
            for (int i = curYear; i > curYear - 5; i--)
            {
                cmbYear.Items.Add(i.ToString());
            }
            cmbYear.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Loading)
                return;
            try
            {
                int CatId = Int32.Parse(cmbCategory.SelectedValue.ToString());
                LoadSubCategories(CatId);
                LoadProducts(CatId, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Loading)
                return;
            try
            {
                int subCatId = Int32.Parse(cmbSubCategory.SelectedValue.ToString());
                int CatId = Int32.Parse(cmbCategory.SelectedValue.ToString());
                LoadProducts(CatId, subCatId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                rptView.Visible = true;
                SetReportData();
                //SetReportParameters();
                //this.YTDSalesByTerritoryTableAdapter.Fill(this.PurchasedProducts.YTDSalesByTerritory);
                //this.rptView.Visible = true;
                //this.rptView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetReportParameters()
        {
            ReportParameter[] p = new ReportParameter[7];
            try
            {
                string paramValue = null;
                if (rdCurYear.Checked)
                {
                    paramValue = "YTD";
                }
                else if (rdCurMonth.Checked)
                {
                    paramValue = "MTD";
                }
                p[0] = new ReportParameter("Period", paramValue);
                p[1] = cmbTerritory.SelectedIndex > 0 ? new ReportParameter("territoryid", cmbTerritory.SelectedValue.ToString()) : new ReportParameter("territoryid", "");
                p[2] = cmbCustomer.SelectedIndex > 0 ? new ReportParameter("customerid", cmbCustomer.SelectedValue.ToString()) : new ReportParameter("customerid", "");
                p[3] = cmbCategory.SelectedIndex > 0 ? new ReportParameter("categoryid", cmbCategory.SelectedValue.ToString()) : new ReportParameter("categoryid", "");
                p[4] = cmbSubCategory.SelectedIndex > 0 ? new ReportParameter("subcategoryid", cmbSubCategory.SelectedValue.ToString()) : new ReportParameter("subcategoryid", "");
                p[5] = cmbProductName.SelectedIndex > 0 ? new ReportParameter("productid", cmbProductName.SelectedValue.ToString()) : new ReportParameter("productid", "");
                p[6] = new ReportParameter("GroupBy", cmbGroupBy.Text);
                rptView.LocalReport.SetParameters(p);
                //if (rdCurMonth.Checked)
                //{
                //    int Month = DateTime.Today.Month;
                //    int Year = DateTime.Today.Year;
                //    string MMYYYY = Month.ToString() + "/" + Year.ToString();
                //}
                //else if (rdCurMonth.Text == "Month/Year")
                //{
                //    if (rdCurMonth.Checked)
                //    {
                //        p[6] = new ReportParameter("Period", MonthYear);
                //    }
                //}
                //else
                //{
                //}

                //rptView.LocalReport.SetParameters(new ReportParameter[] { p });
                //rptView.LocalReport.SetParameters(p);
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

        private void cmbTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Loading)
                return;
            int territoryid = Int32.Parse(cmbTerritory.SelectedValue.ToString());
            LoadCustomers(territoryid);
        }

        private void rptView_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            try
            {
               
                LocalReport DetailReport = (LocalReport)e.Report;
                MICS.Reports.PurchasedProducts.SalesDetailDataTable r = new PurchasedProducts.SalesDetailDataTable();
                MICS.Reports.PurchasedProductsTableAdapters.SalesDetailsTableAdapter ad = new MICS.Reports.PurchasedProductsTableAdapters.SalesDetailsTableAdapter();
                ad.SetTimeOut = 120;
                ReportParameterInfoCollection p = DetailReport.GetParameters();
                string name = p[0].Name;
                string ParamValue = p[0].Values[0];
                ad.FillByWhere(this.PurchasedProducts.SalesDetail, ParamValue);
                DetailReport.DataSources.Add(new ReportDataSource("PurchasedProducts_SalesDetail", ad.GetData()));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}