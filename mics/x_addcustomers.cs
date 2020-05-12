using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using System.IO;
using System.Xml;
using MICS.Utilities;
namespace MICS
{
    public partial class x_addcustomers : Form
    {
        LogWriter log = new LogWriter();
        public x_addcustomers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\migration\customers.xml";
            FileStream fs = new FileStream(fileName, FileMode.Open);


            XmlReader reader = new XmlTextReader(fs);
            reader.MoveToContent();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            DataSet ds = new DataSet("customers");
            ds.ReadXml(reader);
            reader.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "customers";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Address add = new Address();
            Customer cust = new Customer();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    add.AddressLine1 = dataGridView1.Rows[i].Cells["Addressline1"].Value.ToString();
                    add.AddressLine2 = "";
                    add.City = dataGridView1.Rows[i].Cells["city"].Value.ToString();
                    add.StateProvince = dataGridView1.Rows[i].Cells["state"].Value.ToString();
                    add.PostalCode = dataGridView1.Rows[i].Cells["zip"].Value.ToString();
                    int addid = add.AddAddress(add);
                    cust.AddressID = addid;
                    cust.AccountNumber = "";
                    cust.TerritoryID = 0;
                    cust.DeliveryDay = 1;
                    cust.CustomerType = "A";
                    cust.CreditLimit = 100.00m;
                    cust.Email = "";
                    cust.ContactName = dataGridView1.Rows[i].Cells["contactname"].Value.ToString();
                    cust.Fax = dataGridView1.Rows[i].Cells["fax"].Value.ToString();
                    cust.Phone = dataGridView1.Rows[i].Cells["phone"].Value.ToString();
                    cust.SecondPhone = dataGridView1.Rows[i].Cells["secondphone"].Value.ToString();
                    cust.Name = dataGridView1.Rows[i].Cells["name"].Value.ToString();
                    cust.ModifiedDate = DateTime.Now;
                    cust.AddCustomer(cust);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                add = null;
                cust = null;
                Cursor.Current = Cursors.Default;
                MessageBox.Show("done", "Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\migration\Products.xml";
            FileStream fs = new FileStream(fileName, FileMode.Open);


            XmlReader reader = new XmlTextReader(fs);
            reader.MoveToContent();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            DataSet ds = new DataSet("ProductsNew");
            ds.ReadXml(reader);
            reader.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ProductsNew";

        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\migration\vendors.xml";
            FileStream fs = new FileStream(fileName, FileMode.Open);


            XmlReader reader = new XmlTextReader(fs);
            reader.MoveToContent();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            DataSet ds = new DataSet("Vendors");
            ds.ReadXml(reader);
            reader.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Vendors_mod";
        }

        private void btnVendorXML_Click(object sender, EventArgs e)
        {
            LoadVendors();
            //dataGridView1.DataMember = "vendors";
        }

        private void LoadVendors()
        {
            string fileName = @"C:\migration\vendors.xml";
            FileStream fs = new FileStream(fileName, FileMode.Open);


            XmlReader reader = new XmlTextReader(fs);
            reader.MoveToContent();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            DataSet ds = new DataSet("Vendors");
            ds.ReadXml(reader);
            reader.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Vendors_mod";
        }
       
        private void btnSaveVendor_Click(object sender, EventArgs e)
        {
            
            
            int addressid = 0;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Address add = new Address();
                    Vendor vend = new Vendor();

                    add.AddressLine1 = dataGridView1.Rows[i].Cells["address 2"].Value.ToString();
                    add.AddressLine2 = dataGridView1.Rows[i].Cells["addresline2"].Value.ToString();
                    add.City = dataGridView1.Rows[i].Cells["city"].Value.ToString();
                    add.StateProvince = dataGridView1.Rows[i].Cells["state"].Value.ToString();
                    add.PostalCode = dataGridView1.Rows[i].Cells["zip"].Value.ToString();
                    addressid = add.AddAddress(add);

                    vend.AccountNumber = "";
                    vend.AddressID = addressid;
                    vend.ActiveFlag = true;
                    //vend.ContactName = dataGridView1.Rows[i].Cells["FirstName"].Value.ToString();
                    vend.CreditRating = 100;
                    vend.Email = dataGridView1.Rows[i].Cells["alt phone"].Value.ToString();
                    vend.Phone = dataGridView1.Rows[i].Cells["contact"].Value.ToString();
                    vend.Fax = dataGridView1.Rows[i].Cells["phone"].Value.ToString();
                    vend.ModifiedDate = DateTime.Now;
                    vend.Name = dataGridView1.Rows[i].Cells["vendor"].Value.ToString();
                    vend.ContactName = dataGridView1.Rows[i].Cells["firstname"].Value.ToString() + " " + dataGridView1.Rows[i].Cells["MI"].Value.ToString() + " " + dataGridView1.Rows[i].Cells["lastname"].Value.ToString();
                    vend.PreferredVendorStatus = true;
                    vend.AddVendor(vend);
                    add = null;
                    vend = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVendors_Click_1(object sender, EventArgs e)
        {
            LoadVendors();
        }
        private void SaveProducts()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
               
                int catid = 0;
                int subcatid = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ProductCategory cat = new ProductCategory();
                    ProductCategoryCollection catCol = new ProductCategoryCollection ();
                    ProductSubcategory sub = new ProductSubcategory();
                    ProductSubcategoryCollection subCol = new ProductSubcategoryCollection();
                    Product prod = new Product();
                    string where=String.Empty;
                    string orderBy=String.Empty;

                    cat.Name = dataGridView1.Rows[i].Cells["category"].Value.ToString();
                    cat.ModifiedDate = DateTime.Now;
                    if (cat.Name == "Candy") MessageBox.Show("here");
                    if (!cat.Exsists(cat.Name))
                    {
                        catid = cat.AddProductCategory(cat);
                    }
                    else
                    {
                        where = "[Name]='" + cat.Name + "'";
                        catCol = cat.GetProductCategoryCollection(where, orderBy);
                        if (catCol.Count > 0)
                        {
                            catid = catCol[0].ProductCategoryID;
                        }
                        else
                        {
                            MessageBox.Show("error");
                            log.Write(cat.Name, "Loading Products");
                        }
                    }

                    sub.ProductCategoryID = catid;
                    sub.Name = dataGridView1.Rows[i].Cells["subcategory"].Value.ToString();
                    sub.ModifiedDate = DateTime.Now;
                    if (sub.Name == "Pacifire") MessageBox.Show("Stealers");
                    if (sub.Exsists(sub.Name))
                    {
                        where = "[Name]='" + sub.Name + "'";
                        subCol = sub.GetProductSubcategoryCollection(where, orderBy);
                        if (subCol.Count > 0)
                        {
                            subcatid = subCol[0].ProductSubcategoryID;
                        }
                    }
                    else
                    {
                        subcatid = sub.AddProductSubcategory(sub);
                    }

                    prod.ProductSubcategoryID = subcatid;
                    prod.Name = dataGridView1.Rows[i].Cells["productname"].Value.ToString();
                    prod.Class = String.Empty;
                    prod.Color = String.Empty;
                    prod.DaysToManufacture = 0;
                    prod.Description = dataGridView1.Rows[i].Cells["productname"].Value.ToString();
                    prod.DiscontinuedDate = DateTime.Parse("01/01/1900");
                    prod.FinishedGoodsFlag = true;
                    prod.ListPrice =dataGridView1.Rows[i].Cells["price"].Value.ToString()==String.Empty?0.00m:Decimal.Parse(dataGridView1.Rows[i].Cells["price"].Value.ToString());
                    prod.MakeFlag = true;
                    prod.ModifiedDate = DateTime.Now;
                    prod.ProductLine = String.Empty;
                    prod.ProductModelID = 0;
                    prod.ProductNumber = String.Empty;
                    prod.ReorderPoint = 0;// Int16.Parse(dataGridView1.Rows[i].Cells["Reorder Point"].Value.ToString());
                    prod.SafetyStockLevel = 0;
                   
                    prod.SellEndDate = DateTime.Now;
                    prod.SellStartDate = DateTime.Now;
                    prod.Size = String.Empty;
                    prod.SizeUnitMeasureCode = String.Empty;
                    prod.StandardCost = Decimal.Parse(dataGridView1.Rows[i].Cells["cost"].Value.ToString());
                    prod.Style = String.Empty;
                    prod.Weight = 0.00m;
                    prod.WeightUnitMeasureCode = String.Empty;
                    prod.AddProduct(prod);
                    cat = null;
                    sub = null;
                    prod = null;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                MessageBox.Show("Done");
                Cursor.Current = Cursors.Default;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveProducts();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OrderNumber on = new OrderNumber();


            MessageBox.Show(on.GetNextNumber(OrderType.SaleOrder));
        }

     
      
        

       
    }
}