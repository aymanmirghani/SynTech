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
    public partial class frmProductsList : Form
    {
        private bool m_Loading = false;
        public frmProductsList()
        {
            InitializeComponent();
        }

        private void frmProductsList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PurchasedProducts.ProductList' table. You can move, or remove it, as needed.
            m_Loading = true;
            PopulateProductCategories();
            LoadSubCategories(0);
            m_Loading = false;
           // this.ProductListTableAdapter.Fill(this.PurchasedProducts.ProductList);
            this.ProductListTableAdapter.FillByWhere(this.PurchasedProducts.ProductList, "");
            SetReportParameter();
            this.reportViewer1.RefreshReport();
        }
        private void PopulateProductCategories()
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

                ddlCategory.DataSource = catCol;
                ddlCategory.DisplayMember = "Name";
                ddlCategory.ValueMember = "ProductCategoryID";
                // m_Loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void SetReportParameters(CheckedListBox list)
        {
            string[] strValues;
            int count = list.Items.Count;
            strValues = new string[count];
            for (int i = 0; i < count; i++)
            {
                bool selected = false;
                for (int j = 0; j < list.CheckedItems.Count; j++)
                {
                    if (list.Items[i] == list.CheckedItems[j])
                    {
                        strValues[i] = list.CheckedItems[j].ToString();
                        selected = true;
                        break;
                    }
                }
                if (!selected)
                    strValues[i] = "";

            }
            ReportParameter rp = new ReportParameter("ReportColumns", strValues);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.RefreshReport();

        }
        public ReportParameterInfoCollection GetReportParamters()
        {
            ReportParameterInfoCollection p = this.reportViewer1.LocalReport.GetParameters();
            return (p);
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Loading)
                return;
            try
            {
                int CatId = Int32.Parse(ddlCategory.SelectedValue.ToString());
                LoadSubCategories(CatId);
                
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
                ddlSubCategory.DataSource = subCol;
                ddlSubCategory.DisplayMember = "Name";
                ddlSubCategory.ValueMember = "ProductSubcategoryId";
                m_Loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string where = "";
            
            try
            {
                if (ddlCategory.SelectedIndex > 0)
                {
                    if (ddlSubCategory.SelectedIndex > 0)
                    {
                        where += "p.productsubcategoryid=" + ddlSubCategory.SelectedValue.ToString();
                    }
                    else
                    {
                        where += "cat.productcategoryid=" + ddlCategory.SelectedValue.ToString();
                    }
                }
                this.ProductListTableAdapter.FillByWhere(this.PurchasedProducts.ProductList, where);
                SetReportParameter();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SetReportParameter()
        {
            ReportParameter[] p = new ReportParameter[4];
            string company = System.Configuration.ConfigurationManager.AppSettings["CompanyName"].ToString();
            string companyAddress = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress1"].ToString();
            string companyCityState = System.Configuration.ConfigurationManager.AppSettings["CompanyAddress2"].ToString();
            string companyPhone = System.Configuration.ConfigurationManager.AppSettings["CompanyPhone"].ToString();

            p[0] = new ReportParameter("CompanyName", company);
            p[1] = new ReportParameter("CompanyAddress", companyAddress);
            p[2] = new ReportParameter("CompanyCityState", companyCityState);
            p[3] = new ReportParameter("CompanyPhone", companyPhone);
            this.reportViewer1.LocalReport.SetParameters(p);
        }
    }
}