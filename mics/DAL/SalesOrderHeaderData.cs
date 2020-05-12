using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesOrderHeaderData
    {
        LogWriter log = new LogWriter();
        public SalesOrderHeaderData()
        {
        }
        public bool UpdateSalesOrderHeader(SalesOrderHeader SOH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(21);
                dbm.AddParameters(0, "@SalesOrderID", SOH.SalesOrderID);
                dbm.AddParameters(1, "@OrderDate", SOH.OrderDate);
                dbm.AddParameters(2, "@DueDate", SOH.DueDate);
                dbm.AddParameters(3, "@ShipDate", SOH.ShipDate);
                dbm.AddParameters(4, "@Status", SOH.Status);
                dbm.AddParameters(5, "@OnlineOrderFlag", SOH.OnlineOrderFlag);
                dbm.AddParameters(6, "@SalesOrderNumber", SOH.SalesOrderNumber);
                dbm.AddParameters(7, "@PurchaseOrderNumber", SOH.PurchaseOrderNumber);
                dbm.AddParameters(8, "@CustomerID", SOH.CustomerID);
                dbm.AddParameters(9, "@SalesPersonID", SOH.SalesPersonID);
                dbm.AddParameters(10, "@BillToAddressID", SOH.BillToAddressID);
                dbm.AddParameters(11, "@ShipToAddressID", SOH.ShipToAddressID);
                dbm.AddParameters(12, "@ShipMethodID", SOH.ShipMethodID);
                dbm.AddParameters(13, "@PaymentMethodID", SOH.PaymentMethodID);
                dbm.AddParameters(14, "@CurrencyRateID", SOH.CurrencyRateID);
                dbm.AddParameters(15, "@SubTotal", SOH.SubTotal);
                dbm.AddParameters(16, "@TaxAmt", SOH.TaxAmt);
                dbm.AddParameters(17, "@Freight", SOH.Freight);
                dbm.AddParameters(18, "@TotalDue", SOH.TotalDue);
                dbm.AddParameters(19, "@Comment", SOH.Comment);
                dbm.AddParameters(20, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesOrderHeader");
                 
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesOrderHeader(int SalesOrderID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderID", SalesOrderID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesOrderHeader");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesOrderHeader(SalesOrderHeader SOH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderID", SOH.SalesOrderID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesOrderHeader");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesOrderHeader(SalesOrderHeader SOH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(21);

                dbm.AddParameters(0, "@OrderDate", SOH.OrderDate);
                dbm.AddParameters(1, "@DueDate", SOH.DueDate);
                dbm.AddParameters(2, "@ShipDate", SOH.ShipDate);
                dbm.AddParameters(3, "@Status", SOH.Status);
                dbm.AddParameters(4, "@OnlineOrderFlag", SOH.OnlineOrderFlag);
                dbm.AddParameters(5, "@SalesOrderNumber", SOH.SalesOrderNumber);
                dbm.AddParameters(6, "@PurchaseOrderNumber", SOH.PurchaseOrderNumber);
                dbm.AddParameters(7, "@CustomerID", SOH.CustomerID);
                dbm.AddParameters(8, "@SalesPersonID", SOH.SalesPersonID);
                dbm.AddParameters(9, "@BillToAddressID", SOH.BillToAddressID);
                dbm.AddParameters(10, "@ShipToAddressID", SOH.ShipToAddressID);
                dbm.AddParameters(11, "@ShipMethodID", SOH.ShipMethodID);
                dbm.AddParameters(12, "@PaymentMethodID", SOH.PaymentMethodID);
                dbm.AddParameters(13, "@CurrencyRateID", SOH.CurrencyRateID);
                dbm.AddParameters(14, "@SubTotal", SOH.SubTotal);
                dbm.AddParameters(15, "@TaxAmt", SOH.TaxAmt);
                dbm.AddParameters(16, "@Freight", SOH.Freight);
                dbm.AddParameters(17, "@TotalDue", SOH.TotalDue);
                dbm.AddParameters(18, "@Comment", SOH.Comment);
                dbm.AddParameters(19, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(20, "@SalesOrderID", SOH.SalesOrderID);
                dbm.Parameters[20].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesOrderHeader");
                SOH.SalesOrderID = Int32.Parse(dbm.Parameters[20].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SOH.SalesOrderID;
        }
        public DataSet GetAllSalesOrderHeadersDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesOrderHeadersAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeadersDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesOrderHeaderCollection GetAllSalesOrderHeadersCollection()
        {
            IDBManager dbm = new DBManager();
            SalesOrderHeaderCollection cols = new SalesOrderHeaderCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderHeadersAll");
                while (reader.Read())
                {
                    SalesOrderHeader SOH = new SalesOrderHeader();
                    SOH.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    SOH.DueDate = DateTime.Parse(reader["OrderDate"].ToString());
                    SOH.OrderDate = DateTime.Parse(reader["DueDate"].ToString());
                    SOH.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    SOH.Status = Byte.Parse(reader["Status"].ToString());
                    SOH.OnlineOrderFlag = bool.Parse(reader["OnlineOrderFlag"].ToString());
                    SOH.SalesOrderNumber = reader["SalesOrderNumber"].ToString();
                    SOH.PurchaseOrderNumber = reader["PurchaseOrderNumber"].ToString();
                    SOH.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    SOH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SOH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    SOH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    SOH.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SOH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SOH.CurrencyRateID = Int32.Parse(reader["CurrencyRateID"].ToString());
                    SOH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SOH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SOH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SOH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SOH.Comment = reader["Comment"].ToString();
                    SOH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SOH);
                                       
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeadersCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesOrderHeader GetSalesOrderHeader(int SalesOrderID)
        {
            IDBManager dbm = new DBManager();
            SalesOrderHeader SOH = new SalesOrderHeader();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderID", SalesOrderID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderHeader");
                while (reader.Read())
                {
                    SOH.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    SOH.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    SOH.DueDate = DateTime.Parse(reader["OrderDate"].ToString());
                    SOH.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    SOH.Status = Byte.Parse(reader["Status"].ToString());
                    SOH.OnlineOrderFlag = bool.Parse(reader["OnlineOrderFlag"].ToString());
                    SOH.SalesOrderNumber = reader["SalesOrderNumber"].ToString();
                    SOH.PurchaseOrderNumber = reader["PurchaseOrderNumber"].ToString();
                    SOH.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    SOH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SOH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    SOH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    SOH.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SOH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SOH.CurrencyRateID = Int32.Parse(reader["CurrencyRateID"].ToString());
                    SOH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SOH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SOH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SOH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SOH.Comment = reader["Comment"].ToString();
                    SOH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SOH;
        }
        public DataSet GetAllSalesOrderHeadersDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesOrderHeadersDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeadersDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesOrderHeaderCollection GetAllSalesOrderHeadersDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesOrderHeaderCollection cols = new SalesOrderHeaderCollection();
            int id = 0;
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderHeadersDynamic");
                
                while (reader.Read())
                {
                    SalesOrderHeader SOH = new SalesOrderHeader();
                    SOH.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    id = SOH.SalesOrderID;
                    SOH.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    SOH.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    SOH.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    SOH.Status = Byte.Parse(reader["Status"].ToString());
                    SOH.OnlineOrderFlag = bool.Parse(reader["OnlineOrderFlag"].ToString());
                    SOH.SalesOrderNumber = reader["SalesOrderNumber"].ToString();
                    SOH.PurchaseOrderNumber = reader["PurchaseOrderNumber"].ToString();
                    SOH.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    SOH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    if (reader["BillToAddressID"] != DBNull.Value)
                        SOH.BillToAddressID = Int32.Parse(reader["BillToAddressID"].ToString());
                    else
                        SOH.BillToAddressID = 0;
                    if (reader["ShipToAddressID"] != DBNull.Value)
                        SOH.ShipToAddressID = Int32.Parse(reader["ShipToAddressID"].ToString());
                    else
                        SOH.ShipToAddressID = 0;
                    SOH.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SOH.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    SOH.CurrencyRateID = Int32.Parse(reader["CurrencyRateID"].ToString());
                    SOH.SubTotal = decimal.Parse(reader["SubTotal"].ToString());
                    SOH.TaxAmt = decimal.Parse(reader["TaxAmt"].ToString());
                    SOH.Freight = decimal.Parse(reader["Freight"].ToString());
                    SOH.TotalDue = decimal.Parse(reader["TotalDue"].ToString());
                    SOH.Comment = reader["Comment"].ToString();
                    SOH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SOH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeadersDynamicCollection, SalesOrderID:" + id.ToString());
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public decimal GetTotalOrdersByCustomer(int CustomerID)
        {
            decimal tot = 0;
            GenericQuery gen = new GenericQuery();
            try
            {
                string sql = "select sum(TotalDue) as tot from salesorderheader where status=6 and customerid=)" + CustomerID.ToString();

                DataSet ds = new DataSet();
                ds = gen.GetDataSet(false, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["tot"] != DBNull.Value)
                        tot += decimal.Parse(dr["tot"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalOrdersByCustomer");
                throw (ex);
            }
            finally
            {
                gen = null;
            }
            return tot;



        }
    }
}
