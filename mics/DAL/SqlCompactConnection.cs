using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.SqlServerCe;
using System.Configuration;
using System.Data.Common;
using MICS.BLL;
using Primeworks.DesktopSqlCe;
using MICS.Utilities;
using System.Windows.Forms;
using System.Net;

namespace MICS.DAL
{
    class SqlCompactConnection:Form
    {
        private string ConnectionString;
        private ProgressBar ProgressBar1 = null;
        private frmSynchImport _synchForm;
        //private SqlCeConnection SqlConn;
        SqlCeConnection connection = new SqlCeConnection();
        private SqlCeCommand command = new SqlCeCommand();
//        private SqlCeDataReader reader = null;
        private Pipe m_pipe;
        private SqlCeDatabase m_sqlCeDb;
        private SqlCeRowset RowSet;
        LogWriter log = new LogWriter();
        SqlCeTable CategoryTable;
        SqlCeTable SubCategoryTable;
        //private SqlCeDataAdapter SqlAdp;
        DataTable tableSchema;
        //DataTable tableRowset;
        //private DataSet ds;
        public SqlCompactConnection()
        {
            ConnectionString = System.Configuration.ConfigurationManager.AppSettings["MobileConnectionString"].ToString();
        }
        public ProgressBar Prgoress
        {
            set { ProgressBar1 = value; }
            get { return ProgressBar1; }
        }
        public frmSynchImport SynchForm
        {
            set { _synchForm = value; }
            get { return _synchForm; }
        }
        public void connect()
        {
               
            if(connection == null)
                connection = new SqlCeConnection();
            connection.ConnectionString =  ConnectionString; //str.ToString();
            License lic = new License("Ayman Mirghani", "347-TRKM-380357B3");
            try
            {
                connection.License = lic;
                connection.Pipe.Timeout = 45000; // 45 seconds time time
                connection.Open();
            }
            catch (SqlCeException ex)
            {
                log.Write(ex.Message, "SqlCompactConnection.connect");
                throw (ex);
            }
            m_pipe = connection.Pipe;
            m_sqlCeDb = new SqlCeDatabase(m_pipe);
           
            CategoryTable = new SqlCeTable(m_sqlCeDb, "ProductCategory");
            SubCategoryTable = new SqlCeTable(m_sqlCeDb, "ProductSubCategory");
                 
            
        }
        public DataTable GetDataTable(string sql)
        {
            SqlCeDataReader reader = null;
            SqlCeConnection MobileConn = new SqlCeConnection();
            License lic = new License("Ayman Mirghani", "347-TRKM-380357B3");
            try
            {
                MobileConn.ConnectionString = ConnectionString; //str.ToString();
                MobileConn.License = lic;
                MobileConn.Pipe.Timeout = 45000;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Connection = MobileConn;
                MobileConn.Open();
                
                reader = command.ExecuteReader();
                reader.Mode = SqlCeDataReaderMode.Bulk;
                string mode = "";
                mode = reader.Mode.ToString();
                tableSchema = new DataTable();
                for (int iColumn = 0; iColumn < reader.FieldCount; ++iColumn)
                {
                    string colname = reader.GetName(iColumn);
                    tableSchema.Columns.Add(reader.GetName(iColumn));
                }
                //tableSchema = reader.GetSchemaTable();
                int i = 0;
                while (reader.Read())
                {
                    DataRow dr = tableSchema.NewRow();
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        string colName = reader.GetName(col);
                        dr[colName] = reader[colName];
                    }
                    tableSchema.Rows.Add(dr);
                    i++;
                }
                
            }
            catch (SqlCeException ex)
            {
                StringBuilder strMsg = new StringBuilder();
                HResult hr;
                hr = new HResult(ex.HResult);
                strMsg.Append(hr.ToString());
                strMsg.Append(" : ");
                strMsg.Append(ex.Message);
                log.Write(strMsg.ToString(), "SqlCompactConnection.GetDataTable(string sql)");
                throw (ex);
            }
            catch (Exception ex2)
            {
                log.Write(ex2.Message, "SqlCompactConnection.GetDataTable(" + sql + ")");
                throw (ex2);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                command.Dispose();
                MobileConn.Close();
                MobileConn.Dispose();
              
            }
            return tableSchema;

           
        }
        public void Execute(string sql)
        {
            try
            {
                SqlCeCmd cmd = new SqlCeCmd(connection.SqlCeDatabase, sql);
                SqlCeRowset rowset = cmd.ExecuteQuery();
                //tableRowset = rowset.GetSchemaTable();
            }
            catch (SqlCeException ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.Execute(sql)");
               throw(ex);
            }
        }
        public void CloseDatabase()
        {
            try
            {
                if(m_pipe != null)
                    m_pipe.Close();
                connection.Close();
                         
            }
            catch (SqlCeException ex)
            {
                throw (ex);
            }
            finally
            {
                connection.Dispose();
            }
        }
        public bool UpdateSalesOrderHeader(SalesOrderHeader SOH)
        {
            string sql = "";
            try
            {
                connect();
                sql = "update salesorderheader ";
                sql += "set OrderDate='" + SOH.OrderDate + "',";
                sql += "DueDate='" + SOH.DueDate + "',";
                sql += "ShipDate='" + SOH.ShipDate + "',";
                sql += "CustomerID=" + SOH.CustomerID + ",";
                sql += "Status=" + SOH.Status + ",";

                sql += "SalesPersonID=" + SOH.SalesPersonID + ",";
                sql += "BillToAddressID=" + SOH.BillToAddressID + ",";
                sql += "ShipToAddressID=" + SOH.ShipToAddressID + ",";
                sql += "ShipMethodID=" + SOH.ShipMethodID + ",";
                sql += "PaymentMethodID=" + SOH.PaymentMethodID + ",";
                sql += "SubTotal=" + SOH.SubTotal + ",";

                sql += "TaxAmt=" + SOH.TaxAmt + ",";
                sql += "Freight=" + SOH.Freight + ",";
                sql += "TotalDue=" + SOH.TotalDue + ",";
                sql += "Comment='" + SOH.Comment + "',";
                sql += "ModifiedDate='" + SOH.ModifiedDate + "'";

                sql += " where salesorderid=" + SOH.CurrencyRateID;
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.updatesalesorderheder)");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
            return true;
            
        }
        public int AddSalesOrderHeader(SalesOrderHeader SOH)
        {
            string sql = "";
            try
            {
                connect();
                sql = "insert into salesorderheader(";
                sql += "DueDate,ShipDate,CustomerID,Status,SalesPersonID,BillToAddressID,";
                sql += "ShipToAddressID,ShipMethod,PaymentMethodID,SubTotal,TaxAmt,Freight,";
                sql += "TotalDue,Comment,ModifiedDate) values(";
                sql += "'" + SOH.DueDate + "',";
                sql += "'" + SOH.ShipDate + "',";
                sql += SOH.CustomerID + ",";
                sql += "Status=" + SOH.Status + ",";

                sql += SOH.SalesPersonID + ",";
                sql += SOH.BillToAddressID + ",";
                sql += SOH.ShipToAddressID + ",";
                sql += SOH.ShipMethodID + ",";
                sql += SOH.PaymentMethodID + ",";
                sql += SOH.SubTotal + ",";

                sql += SOH.TaxAmt + ",";
                sql += SOH.Freight + ",";
                sql += SOH.TotalDue + ",";
                sql += "'" + SOH.Comment + "',";
                sql += "'" + SOH.ModifiedDate + "'";

                sql += ")";
                Execute(sql);
                
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.AddSalesOrdeHeader(sql)");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
            return (GetMaxSalesOrderID());

        }
        public void DeleteOldOrders()
        {
            string sql = "DELETE from salesorderdetail where salesorderid in (select salesorderid  from salesorderheader where status!=1 and orderdate < dateadd(MONTH,-1, getdate()))";
            string sql2 = "DELETE SalesOrderHeader where status!=1 and orderdate < dateadd(MONTH,-1,getdate())";
            string sql3 = "DELETE from salesorderdetail where salesorderid not in (select salesorderid from salesorderheader)";
            try
            {
                connect();
                Execute(sql);
                Execute(sql2);
                Execute(sql3);
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteOldMobileOrders");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void UpdateMobileOrderHeader(string fieldsValues, string where)
        {
            //try
            //{
            //    connect();
            //    SqlCeTable table = new SqlCeTable(m_sqlCeDb, "SalesOrderHeader");
            //    RowSet = table.Open();
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        RowSet.PrepareRow();
            //        for (int i = 0; i < dt.Columns.Count; i++)
            //        {
            //            string ColName = dt.Columns[i].ColumnName;
            //            RowSet.
            //            RowSet.SetValue(ColName, dr[ColName]);
            //        }

            //        //RowSet.SetValue("InvoiceID", Int32.Parse(dr["InvoiceID"].ToString()));
            //        //RowSet.SetValue("CustomerID", Int32.Parse(dr["CustomerID"].ToString()));
            //        //RowSet.SetValue("InvoiceNumber", dr["InvoiceNumber"].ToString());
            //        //RowSet.SetValue("InvoiceDate", DateTime.Parse(dr["InvoiceDate"].ToString()));
            //        //RowSet.SetValue("InvoiceTotal", Decimal.Parse(dr["InvoiceTotal"].ToString()));
            //        //RowSet.SetValue("TotalPayments", Decimal.Parse(dr["TotalPayments"].ToString()));
            //        //RowSet.SetValue("Balance", Decimal.Parse(dr["Balance"].ToString()));
            //        RowSet.Update();


            //    }
            //    RowSet.Close();
            //}
            //catch (Exception ex)
            //{
            //    log.Write(ex.Message, "UpdateMobileStatus");
            //    throw (ex);
            //}
            //finally
            //{
            //    CloseDatabase();
            //}



            string sql = "update salesorderheader set " + fieldsValues + " where " + where;
            try
            {
                connect();
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Updating mobile sales order");
                throw (ex);
            }
            finally
            {
               // connection.Close();
            }
        }
        public int GetMaxSalesOrderID()
        {
            int max_id = 0;
            try
            {
                connect();
                string sql = "selct max(SalesOrderID) as max_id from salesorderheader";
                GetDataTable(sql);
                max_id = Int32.Parse(tableSchema.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
               throw(ex);
            }
            finally
            {
                //closedatabase();
            }
            return (max_id);

        }
        public bool DeleteSalesOrderDetail(int SalesOrderID)
        {
            try
            {
                connect();
                string sql = "Delete from SalesOrderDetail where SalesOrderID=" + SalesOrderID;
                Execute(sql);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //closedatabase();
            }
            return true;

        }
        public bool AddSalesOrderDetails(SalesOrderDetail SOD)
        {
            string sql = "";
            try
            {
                connect();
                sql = "insert into salesorderdetail(";
                sql += "SalesOrderID,CarrierTrackingNumber,OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,";
                sql += "LineTotal,ModifiedDate) values(";
                sql += SOD.SalesOrderID + ",";
                sql += "'" + SOD.CarrierTrackingNumber + "',"; ;
                sql += SOD.OrderQty + ",";
                sql += SOD.ProductID + ",";
                sql += SOD.SpecialOfferID + ",";
                sql += SOD.UnitPrice + ",";
                sql += SOD.UnitPriceDiscount + ",";
                sql += SOD.LineTotal + ",";
                sql += "'" + SOD.ModifiedDate + "'";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.addsalesorderdetails");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
            return true;
        }
        public void DropProdctTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("Product"))
                    return;
                sql = "DROP TABLE [Product]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropProductTable");
                log.Write(ex.Message,"");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropProdctCategoryTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("ProductCategory"))
                    return;
                sql = "DROP TABLE [ProductCategory]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropProductTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateProdctCategoryTable()
        {
            string sql = "";
            try
            {
                connect();
                sql = "CREATE TABLE [ProductCategory](ProductCategoryID [int] NOT NULL primary key,Name [nvarchar](50)  NOT NULL)";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropProductTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropProdctSubCategoryTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("ProductSubCategory"))
                    return;
                sql = "DROP TABLE [ProductSubCategory]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropProductTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateProdctSubCategoryTable()
        {
            string sql = "";
            try
            {
                connect();
                sql = "CREATE TABLE [ProductSubCategory](ProductSubCategoryID [int] NOT NULL primary key,ProductCategoryID [int] NOT NULL,Name [nvarchar](50)  NOT NULL)";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropProductTable");
                log.Write(ex.Message, "");
            }
        }
       
        public void CreateProductTable()
        {
            string sql = "";
            try
            {
                connect();
                sql = "CREATE TABLE [Product](";
                sql += "[ProductID] [int] NOT NULL primary key,";
                sql += "[Name] [nvarchar](50)  NOT NULL,";
                sql += "[Description] [nchar](100)  NULL,";
                sql += "[ProductNumber] [nvarchar](25)  NOT NULL,";
                sql += "[ListPrice] [money] NOT NULL DEFAULT ((0.00)),";
                sql += "[ProductSubcategoryID] [int] NULL DEFAULT ((0))";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.CreateProductTable");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateProductDiscountTable()
        {
            string sql = "";
            try
            {
                connect();
                sql = "CREATE TABLE [ProductDiscount](";
                sql += "[ProductID] [int] NOT NULL,";
                sql += "[Discount] [money] NOT NULL DEFAULT ((0.00)),";
                sql += "[MinQty] [int] NULL DEFAULT ((0)),";
                sql += "[MaxQty] [int] NULL DEFAULT ((0))";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.CreateProductDiscountTable");
                throw (ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public bool TableExist(string table_name)
        {
            bool ret = false;
            DataTable dt = new DataTable();
            try
            {
                string sql = "select table_name from information_schema.tables where table_name='" + table_name + "'";
                dt = GetDataTable(sql);
                if (dt.Rows.Count > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "TableExist");
            }
            finally
            {
                dt.Dispose();
            }
            return ret;

        }
        public void DropSalesTerritoryTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("SalesTerritory"))
                    return;
                sql = "DROP TABLE [SalesTerritory]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropSalesTerritoryTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropCustomerTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("Customer"))
                    return;
                sql = "DROP TABLE [Customer]";
                Execute(sql);
                
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropCustomerTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropInvoicesBalanceTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("InvoiceBalance"))
                    return;
                sql = "DROP TABLE [InvoiceBalance]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropInvoiceBalanceTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropSepcialOfferTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("SpecialOffer"))
                    return;
                sql = "DROP TABLE [SpecialOffer]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropSepcialOfferTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropSepcialOfferProductTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("SpecialOfferProduct"))
                    return;
                sql = "DROP TABLE [SpecialOfferProduct]";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropSepcialOfferTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void DropProductDiscountTable()
        {
            string sql = "DROP TABLE [ProductDiscount]";
            try
            {
                connect();
                if (!TableExist("ProductDiscount"))
                    return;
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateInvoicesBalanceTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [InvoiceBalance](";
                sql += "[InvoiceID] [int] NOT NULL,";
                sql += "[CustomerID] [int] NOT NULL,";
                sql += "[InvoiceNumber] [nvarchar](20),";
                sql += "[InvoiceDate] [datetime],";
                sql += "[InvoiceTotal] [money],";
                sql += "[TotalPayments] [money],";
                sql += "[Balance] [money]";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void InsertInvoicesBalance(int InvoiceID, int CustomerID, string InvoiceNumber, string InvoiceDate, decimal InvoiceTotal, decimal TotalPayments, decimal Balance)
        {
            string sql = "insert into InvoiceBalance (InvoiceID,CustomerID,InvoiceNumber,InvoiceDate,InvoiceTotal,TotalPayments,Balance) values(";
            try
            {
                connect();
                sql += InvoiceID.ToString() + ",";
                sql += CustomerID.ToString() + ",";
                sql += "'" + InvoiceNumber + "',";
                sql += "'" + InvoiceDate + "',";
                sql += InvoiceTotal.ToString() + ",";
                sql += TotalPayments.ToString() + ",";
                sql += Balance.ToString() + ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void InsertInvoicesBalance(DataTable dt)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "InvoiceBalance");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", dt.Rows.Count);
                int count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("InvoiceID", Int32.Parse(dr["InvoiceID"].ToString()));
                    RowSet.SetValue("CustomerID", Int32.Parse(dr["CustomerID"].ToString()));
                    RowSet.SetValue("InvoiceNumber", dr["InvoiceNumber"].ToString());
                    RowSet.SetValue("InvoiceDate", DateTime.Parse(dr["InvoiceDate"].ToString()));
                    RowSet.SetValue("InvoiceTotal", Decimal.Parse(dr["InvoiceTotal"].ToString()));
                    RowSet.SetValue("TotalPayments", Decimal.Parse(dr["TotalPayments"].ToString()));
                    RowSet.SetValue("Balance", Decimal.Parse(dr["Balance"].ToString()));
                    RowSet.Insert();

                    string status = "Exporting Invoices(" + count.ToString() + " of " + dt.Rows.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateTerritoryTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [SalesTerritory](";
                sql += "[TerritoryID] [int] NOT NULL primary key,";
	            sql += "[Name] [nvarchar](25) NOT NULL,";
	            sql += "[CountryRegionCode] [nvarchar](3) NOT NULL,";
                sql += "[ModifiedDate] [datetime] NOT NULL DEFAULT (getdate())";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw (ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateCustomerTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [Customer](";
                sql += "[CustomerID] [int] NOT NULL primary key,";
                sql += "[Name] [nvarchar](50) NOT NULL,";
                sql += "[TerritoryID] [int] NULL,";
                sql += "[AddressID] [int] NULL,";
                sql += "[BillingAddressId] [int] NULL,";
                sql += "[Phone] [nvarchar](30) NULL";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateAddressTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [Address](";
                sql += "[AddressID] [int] NOT NULL primary key,";
                sql += "[AddressLine1] [nvarchar](60) NOT NULL,";
                sql += "[AddressLine2] [nvarchar](60) NULL,";
                sql += "[City] [nvarchar](30) NULL,";
                sql += "[StateProvince] [nvarchar](2) NULL,";
                sql += "[PostalCode] [nvarchar](15) NULL,";
                sql += "[ModifiedDate] [datetime] NOT NULL  DEFAULT (getdate())";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw(ex);
            }
            finally
            {
                //closedatabase();
            }
        }
        public void CreateSpecialOfferTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [SpecialOffer](";
                sql += "[SpecialOfferID] [int] NOT NULL primary key,";
                sql += "[Description] [nvarchar](255) NOT NULL,";
                sql += "[DiscountPct] [money] NOT NULL DEFAULT ((0.00)),";
                sql += "[Type] [nvarchar](50) NOT NULL,";
                sql += "[Category] [nvarchar](50) NULL,";
                sql += "[StartDate] [datetime] NOT NULL,";
                sql += "[EndDate] [datetime] NOT NULL,";
                sql += "[MinQty] [int] NOT NULL DEFAULT ((0)),";
                sql += "[MaxQty] [int] NULL DEFAULT ((0)),";
                sql += "[ModifiedDate] [datetime] NOT NULL DEFAULT (getdate())";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
           
        }
        public void CreateSpecialOfferProductTable()
        {
            try
            {
                connect();
                string sql = "CREATE TABLE [SpecialOfferProduct](";
                sql += "[SpecialOfferID] [int] NOT NULL,";
                sql += "[ProductID] [int] NOT NULL,";
                sql += "[ModifiedDate] [datetime] NOT NULL DEFAULT (getdate())";
                sql += ")";
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
        }
        public void DropAddressTable()
        {
            string sql = "";
            try
            {
                connect();
                if (!TableExist("Address"))
                    return;
                sql = "DROP TABLE [Address]";
                Execute(sql);
               
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.DropAddressTable");
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void AddProduct(ProductCollection Products)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "Product");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Products.Count);
                int count = 0;
                foreach (Product product in Products)
                {
                    //string sql = "";
                    RowSet.PrepareRow();
                    RowSet.SetValue("ProductID", product.ProductID);
                    RowSet.SetValue("Name", product.Name);
                    RowSet.SetValue("Description", product.Description);
                    RowSet.SetValue("ProductNumber", product.ProductNumber);
                    RowSet.SetValue("ListPrice", product.ListPrice);
                    RowSet.SetValue("ProductSubcategoryID", product.ProductSubcategoryID);
                    RowSet.Insert();

                    string status = "Exporting Products(" + count.ToString() + " of " + Products.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();

                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void AddProduct(Product product)
        {
            
            string sql = "";
            try
            {
                sql = "insert into product(";
                connect();
                sql += "ProductID,Name,Description,ProductNumber,";
                sql += "StandardCost,ListPrice,";
                sql += "ProductSubcategoryID,SellStartDate,SellEndDate,";
                sql += "DiscontinuedDate,ModifiedDate";

                sql += ")values(";
                sql += product.ProductID + ",";
                sql += "'" + product.Name + "',";
                sql += "'" + product.Description + "',";
                sql += "'" + product.ProductNumber + "',";
                sql += product.StandardCost+ ",";
                sql += product.ListPrice + ",";
                sql += product.ProductSubcategoryID + ",";
                sql += "'" + product.SellStartDate + "',";
                sql += "'" + product.SellEndDate + "',";
                sql += "'" + product.DiscontinuedDate + "',";
                sql += "'" + product.ModifiedDate + "'";

                sql += ")";

                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.AddProduct");
                throw(ex);
            }
            
        }
        public void AddProductSubCategory(ProductSubcategoryCollection SubCategories)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "ProductSubCategory");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", SubCategories.Count);
                int count = 0;
                foreach (ProductSubcategory subcategory in SubCategories)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("ProductSubCategoryID", subcategory.ProductSubcategoryID);
                    RowSet.SetValue("ProductCategoryID", subcategory.ProductCategoryID);
                    RowSet.SetValue("Name", subcategory.Name);
                    RowSet.Insert();
                    
                    string status = "Setting Products Subcategories(" + count.ToString() + " of " + SubCategories.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message,"");
            }
            finally
            {
                //closedatabase();
            }

        }
        public void AddProductCategory(ProductCategoryCollection Categories)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "ProductCategory");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Categories.Count);
                int count = 0;
                foreach (ProductCategory category in Categories)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("ProductCategoryID", category.ProductCategoryID);
                    RowSet.SetValue("Name", category.Name);
                    RowSet.Insert();
                    string status = "Setting Products Categories(" + count.ToString() + " of " + Categories.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }

        }
        public void AddAddress(AddressCollection Addresses)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "Address");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Addresses.Count);
                int count = 0;
                foreach (Address address in Addresses)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("AddressID", address.AddressID);
                    RowSet.SetValue("AddressLine1", address.AddressLine1);
                    RowSet.SetValue("AddressLine2", address.AddressLine2);
                    RowSet.SetValue("city", address.City);
                    RowSet.SetValue("StateProvince", address.StateProvince);
                    RowSet.SetValue("PostalCode", address.PostalCode);
                    RowSet.SetValue("ModifiedDate", address.ModifiedDate);
                    RowSet.Insert();
                    string status = "Updating Customers Addresses(" + count.ToString() + " of " + Addresses.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void AddSalesTerritory(SalesTerritoryCollection Territories)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "SalesTerritory");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Territories.Count);
                int count = 0;
                foreach (SalesTerritory territory in Territories)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("TerritoryID", territory.TerritoryID);
                    RowSet.SetValue("Name", territory.Name);
                    RowSet.SetValue("CountryRegionCode", territory.CountryRegionCode);
                    RowSet.SetValue("ModifiedDate", territory.ModifiedDate);
                    RowSet.Insert();
                    string status = "Updating Customers Territories(" + count.ToString() + " of " + Territories.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void AddProductDiscount(DataTable Discounts)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "ProductDiscount");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Discounts.Rows.Count);
                int count = 0;
                foreach (DataRow discount in Discounts.Rows)
                {
                    try
                    {
                        RowSet.PrepareRow();
                        RowSet.SetValue("ProductId", Int32.Parse(discount["ProductId"].ToString()));
                        RowSet.SetValue("Discount", decimal.Parse(discount["Discount"].ToString()));
                        RowSet.SetValue("MinQty", Int32.Parse(discount["MinQty"].ToString()));
                        RowSet.SetValue("MaxQty", Int32.Parse(discount["MaxQty"].ToString()));
                        RowSet.Insert();

                        string status = "Special Offer Products(" + count.ToString() + " of " + Discounts.Rows.Count + ")";
                        _synchForm.StatusLable(status);
                        _synchForm.SetProgressBar("", count++);
                        _synchForm.RefreshForm();
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.Message, "");
                        throw (ex);
                    }
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
        }
        public void AddSpecialOffer(SpecialOfferCollection SpecialOffers)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "SpecialOffer");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", SpecialOffers.Count);
                int count = 0;
                foreach (SpecialOffer speicaloffer in SpecialOffers)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("SpecialOfferID",speicaloffer.SpecialOfferID);
                    RowSet.SetValue("Category", speicaloffer.Category);
                    RowSet.SetValue("Description", speicaloffer.Description);
                    RowSet.SetValue("DiscountPct", speicaloffer.DiscountPct);
                    RowSet.SetValue("EndDate", speicaloffer.EndDate);
                    RowSet.SetValue("MaxQty", speicaloffer.MaxQty);
                    RowSet.SetValue("MinQty", speicaloffer.MinQty);
                    RowSet.SetValue("ModifiedDate", speicaloffer.ModifiedDate);
                    RowSet.SetValue("StartDate", speicaloffer.StartDate);
                    RowSet.SetValue("Type", speicaloffer.Type);
                   

                    RowSet.Insert();
                    string status = "Setting Special Offers(" + count.ToString() + " of " + SpecialOffers.Count+ ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
        }
        public void AddSpecialOfferProduct(SpecialOfferProductCollection SpecialOfferProducts)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "SpecialOfferProduct");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", SpecialOfferProducts.Count);
                int count = 0;
                foreach (SpecialOfferProduct speicalofferproduct in SpecialOfferProducts)
                {
                    RowSet.PrepareRow();
                    RowSet.SetValue("SpecialOfferID", speicalofferproduct.SpecialOfferID);
                    RowSet.SetValue("ProductID", speicalofferproduct.ProductID);
                    RowSet.SetValue("ModifiedDate", speicalofferproduct.ModifiedDate);
                     RowSet.Insert();
                     string status = "Setting Special Offer Products(" + count.ToString() + " of " + SpecialOfferProducts.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();
                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
        }
        public void UpdateProduct(Product product)
        {
            string sql = "";
            try
            {
                connect();
                sql = "update Product set ";
                sql += "Name='" + product.Name + "',";
                sql += "Description='" + product.Description + "',";
                sql += "ProductNumber='" + product.ProductNumber + "',";
                sql += "StandardCost=" + product.StandardCost + ",";
                sql += "ListPrice=" + product.ListPrice + ",";
                sql += "ProductSubcategoryID=" + product.ProductSubcategoryID + ",";
                sql += "SellStartDate='" + product.SellStartDate + "',";
                sql += "SellEndDate='" + product.SellEndDate + "',";
                sql += "DiscontinuedDate='" + product.DiscontinuedDate + "',";
                sql += "ModifiedDate='" + product.ModifiedDate + "'";
                sql += " where ProductID=" + product.ProductID;
                Execute(sql);
            }
            catch (Exception ex)
            {
                log.Write("SQL Failed:(" + sql + ")", "SqlCompactConnection.UpdateProduct");
               throw(ex);
            }
        }
        public int GetMaxProductID()
        {
            int max_id = 0;
            try
            {
                if (connection.ConnectionString == "")
                  connect();
               string sql = "select max(ProductID) as max_id from Product";
               GetDataTable(sql);
               max_id = Int32.Parse(tableSchema.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
               throw(ex);
            }
            return (max_id);

        }
        public void AddCustomer(CustomerCollection Customers)
        {
            try
            {
                connect();
                SqlCeTable table = new SqlCeTable(m_sqlCeDb, "Customer");
                RowSet = table.Open();
                _synchForm.SetProgressBar("min", 0);
                _synchForm.SetProgressBar("max", Customers.Count);
                int count = 0;

                foreach (Customer customer in Customers)
                {

                    if (customer.Name.Contains("'"))
                    {
                        customer.Name = customer.Name.Replace("'", "");
                    }
                    RowSet.PrepareRow();
                    RowSet.SetValue("CustomerID", customer.CustomerID);
                    RowSet.SetValue("TerritoryID", customer.TerritoryID);
                    RowSet.SetValue("AddressID", customer.AddressID);
                    RowSet.SetValue("BillingAddressId", customer.BillingAddressID);
                    RowSet.SetValue("Name", customer.Name);
                    RowSet.SetValue("Phone", customer.Phone);
                    RowSet.Insert();
                    string status = "Exporting Customers(" + count.ToString() + " of " + Customers.Count + ")";
                    _synchForm.StatusLable(status);
                    _synchForm.SetProgressBar("", count++);
                    _synchForm.RefreshForm();

                }
                RowSet.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
            }
            finally
            {
                //closedatabase();
            }
                
        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                if (customer.Name.Contains("'") )
                {
                    customer.Name  = customer.Name.Replace("'", "");
                }
                connect();
                string sql = "insert into Customer(";
                sql += "CustomerID,TerritoryID,AddressID,AccountNumber,CreditLimit,DeliveryDay,";
                sql += "CustomerType,Name,ContactName,Email,Phone,";
                sql += "SecondPhone,Fax,ModifiedDate,BillingAddressId";

                sql += ")values(";

                sql += customer.CustomerID + ",";
                sql += customer.TerritoryID + ",";
                sql += customer.AddressID + ",";
                sql += "'" + customer.AccountNumber + "',";
                sql += customer.CreditLimit + ",";
                sql += customer.DeliveryDay + ",";
                sql += "'" + customer.CustomerType + "',";
                sql += "'" + customer.Name + "',";
                sql += "'" + customer.ContactName + "',";
                sql += "'" + customer.Email + "',";
                sql += "'" + customer.Phone + "',";
                sql += "'" + customer.SecondPhone + "',";
                sql += "'" + customer.Fax + "',";
                sql += "'" + customer.ModifiedDate + "',";
                sql += customer.BillingAddressID;

                sql += ")";

                Execute(sql);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
            
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                if (customer.Name.Contains("'"))
                {
                    customer.Name = customer.Name.Replace("'", "");
                }
                connect();
                string sql = "update customer set ";
                sql += "TerritoryID=" + customer.TerritoryID + ",";
                sql += "AddressID=" + customer.AddressID + ",";
                sql += "AccountNumber='" + customer.AccountNumber + "',";
                sql += "CreditLimit=" + customer.CreditLimit + ",";
                sql += "DeliveryDay=" + customer.DeliveryDay + ",";
                sql += "CustomerType='" + customer.CustomerType + "',";
                sql += "Name='" + customer.Name + "',";
                sql += "ContactName='" + customer.ContactName + "',";
                sql += "Email='" + customer.Email + "',";
                sql += "Phone='" + customer.Phone + "',";
                sql += "SecondPhone='" + customer.SecondPhone + "',";
                sql += "Fax='" + customer.Fax + "',";
                sql += "ModifiedDate='" + customer.ModifiedDate + "',";
                sql += "BillingAddressID=" + customer.BillingAddressID;

                sql += " where CustomerID=" + customer.CustomerID;
                Execute(sql);
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        public int GetMaxCustomerID()
        {
            int max_id = 0;
            try
            {
                if (connection.ConnectionString == "")
                  connect();
                string sql = "select max(CustomerID) as max_id from Customer";
                GetDataTable(sql);
                if(tableSchema.Rows.Count > 0)
                  max_id = Int32.Parse(tableSchema.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return (max_id);

        }
        public DateTime GetLastModifiedDate(string table_name,string IdName ,int IdValue)
        {
            DateTime ModifiedDate = DateTime.Today;
            try
            {
                if(connection.ConnectionString == "")
                    connect();
                string sql = "select ModifiedDate from " + table_name;
                sql += " where " + IdName + "=" + IdValue.ToString();
                GetDataTable(sql);
                if(tableSchema.Rows.Count > 0)
                  ModifiedDate = DateTime.Parse(tableSchema.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return (ModifiedDate);
        }
         
    }    
}
