using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesInvoiceHeaderData
    {
        LogWriter log = new LogWriter();
        public SalesInvoiceHeaderData()
        {
            
        }
        public bool UpdateSalesInvoiceHeader(SalesInvoiceHeader SIH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(18);
                dbm.AddParameters(0, "@InvoiceID", SIH.InvoiceID);
                dbm.AddParameters(1, "@InvoiceNumber", SIH.InvoiceNumber);
                dbm.AddParameters(2, "@InvoiceDate", SIH.InvoiceDate);
                dbm.AddParameters(3, "@DueDate", SIH.DueDate);
                dbm.AddParameters(4, "@Status", SIH.Status);
                dbm.AddParameters(5, "@AccountNumber", SIH.AccountNumber);
                dbm.AddParameters(6, "@SaleOrderID", SIH.SaleOrderID);
                dbm.AddParameters(7, "@SalesPersonID", SIH.SalesPersonID);
                dbm.AddParameters(8, "@TerritoryID", SIH.TerritoryID);
                dbm.AddParameters(9, "@BillToAddressID", SIH.BillToAddressID);
                dbm.AddParameters(10, "@ShipToAddressID", SIH.ShipToAddressID);
                dbm.AddParameters(11, "@PaymentMethodID", SIH.PaymentMethodID);
                dbm.AddParameters(12, "@SubTotal", SIH.SubTotal);
                dbm.AddParameters(13, "@TaxAmt", SIH.TaxAmt);
                dbm.AddParameters(14, "@Freight", SIH.Freight);
                dbm.AddParameters(15, "@TotalDue", SIH.TotalDue);
                dbm.AddParameters(16, "@Comment", SIH.Comment);
                dbm.AddParameters(17, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesInvoiceHeader");
                 
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesInvoiceHeader(int InvoiceID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", InvoiceID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesInvoiceHeader");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesInvoiceHeader(SalesInvoiceHeader SIH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", SIH.InvoiceID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesInvoiceHeader");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesInvoiceHeader(SalesInvoiceHeader SIH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(18);
                
                dbm.AddParameters(0, "@InvoiceNumber", SIH.InvoiceNumber);
                dbm.AddParameters(1, "@InvoiceDate", SIH.InvoiceDate);
                dbm.AddParameters(2, "@DueDate", SIH.DueDate);
                dbm.AddParameters(3, "@Status", SIH.Status);
                dbm.AddParameters(4, "@AccountNumber", SIH.AccountNumber);
                dbm.AddParameters(5, "@SaleOrderID", SIH.SaleOrderID);
                dbm.AddParameters(6, "@SalesPersonID", SIH.SalesPersonID);
                dbm.AddParameters(7, "@TerritoryID", SIH.TerritoryID);
                dbm.AddParameters(8, "@BillToAddressID", SIH.BillToAddressID);
                dbm.AddParameters(9, "@ShipToAddressID", SIH.ShipToAddressID);
                dbm.AddParameters(10, "@PaymentMethodID", SIH.PaymentMethodID);
                dbm.AddParameters(11, "@SubTotal", SIH.SubTotal);
                dbm.AddParameters(12, "@TaxAmt", SIH.TaxAmt);
                dbm.AddParameters(13, "@Freight", SIH.Freight);
                dbm.AddParameters(14, "@TotalDue", SIH.TotalDue);
                dbm.AddParameters(15, "@Comment", SIH.Comment);
                dbm.AddParameters(16, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(17, "@InvoiceID", SIH.InvoiceID);

                dbm.Parameters[17].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesInvoiceHeader");
                SIH.InvoiceID = Int32.Parse(dbm.Parameters[17].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SIH.InvoiceID;
        }
        public DataSet GetAllSalesInvoiceHeadersDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesInvoiceHeadersAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceHeadersDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesInvoiceHeaderCollection GetAllSalesInvoiceHeadersCollection()
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceHeaderCollection cols = new SalesInvoiceHeaderCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceHeaderAll");
                while (reader.Read())
                {
                    SalesInvoiceHeader SIH = new SalesInvoiceHeader();
                    SIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    SIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    SIH.DueDate = DateTime.Parse(reader["DudDate"].ToString());
                    SIH.Status = Byte.Parse(reader["Status"].ToString());
                    SIH.AccountNumber = reader["AccountNumber"].ToString();
                    SIH.SaleOrderID = Int32.Parse(reader["SaleOrderID"].ToString());
                    SIH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SIH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SIH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    SIH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    SIH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SIH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SIH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SIH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SIH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SIH.Comment = reader["Comment"].ToString();
                    SIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SIH);
               }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceHeadersCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesInvoiceHeader GetSalesInvoiceHeader(int InvoiceID)
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceHeader SIH = new SalesInvoiceHeader();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", InvoiceID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceHeader");
                while (reader.Read())
                {
                    
                    SIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    SIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    SIH.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    SIH.Status = Byte.Parse(reader["Status"].ToString());
                    SIH.AccountNumber = reader["AccountNumber"].ToString();
                    SIH.SaleOrderID = Int32.Parse(reader["SaleOrderID"].ToString());
                    SIH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SIH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SIH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    SIH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    SIH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SIH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SIH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SIH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SIH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SIH.Comment = reader["Comment"].ToString();
                    SIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SIH;
        }
        public bool InvoiceExist(int SalesOrderId)
        {
            bool ret = false;
            string where = "SaleOrderID=" + SalesOrderId.ToString();
            string orderBy = "invoiceid";
            try
            {
                DataSet ds = GetAllSalesInvoiceHeadersDynamicDataSet(where, orderBy);
                if (ds.Tables[0].Rows.Count > 0)
                    ret = true;

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw (ex);
            }
            return ret;
        }
        public DataSet GetAllSalesInvoiceHeadersDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesInvoiceHeadersDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceHeadersDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesInvoiceHeaderCollection GetAllSalesInvoiceHeadersDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceHeaderCollection cols = new SalesInvoiceHeaderCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceHeadersDynamic");
                while (reader.Read())
                {
                    SalesInvoiceHeader SIH = new SalesInvoiceHeader();
                    SIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    SIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    SIH.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    SIH.Status = Byte.Parse(reader["Status"].ToString());
                    SIH.AccountNumber = reader["AccountNumber"].ToString();
                    SIH.SaleOrderID = Int32.Parse(reader["SaleOrderID"].ToString());
                    SIH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SIH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SIH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    SIH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    SIH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SIH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SIH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SIH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SIH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SIH.Comment = reader["Comment"].ToString();
                    SIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SIH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceHeadersDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public DataSet GetInovoicesBalanceDataSet()
        {
            DataSet ds = new DataSet();
            GenericQuery q = new GenericQuery();
            string sql = "select * from InvoicesBalance_View where balance<>0";
            try
            {
                ds = q.GetDataSet(false, sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetInvoicesBalanceDataSet");
                throw (ex);
            }
            finally
            {
                q = null;
            }
            return (ds);

        }
    }
}
