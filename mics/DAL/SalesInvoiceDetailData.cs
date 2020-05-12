using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesInvoiceDetailData
    {
        LogWriter log = new LogWriter();
        public SalesInvoiceDetailData()
        {
           
        }
        public bool UpdateSalesInvoiceDetail(SalesInvoiceDetail SID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(9);
                dbm.AddParameters(0, "@InvoiceDetailID", SID.InvoiceDetailID);
                dbm.AddParameters(1, "InvoiceID", SID.InvoiceID);
                dbm.AddParameters(2, "Quantity", SID.Quantity);
                dbm.AddParameters(3, "ProductID", SID.ProductID);
                dbm.AddParameters(4, "@SpecialOfferID",SID.SpecialOfferID);
	            dbm.AddParameters(5, "@UnitPrice", SID.UnitPrice);
	            dbm.AddParameters(6, "@UnitPriceDiscount", SID.UnitPriceDiscount);
                dbm.AddParameters(7, "@LineTotal", SID.LineTotal);
                dbm.AddParameters(8, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesInvoiceDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesInvoiceDetail(int @InvoiceDetailID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceDetailID", @InvoiceDetailID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesInvoiceDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesInvoiceDetail(SalesInvoiceDetail SID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceDetailID", SID.@InvoiceDetailID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesInvoiceDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesInvoiceDetail(SalesInvoiceDetail SID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(9);
                
                dbm.AddParameters(0, "InvoiceID", SID.InvoiceID);
                dbm.AddParameters(1, "Quantity", SID.Quantity);
                dbm.AddParameters(2, "ProductID", SID.ProductID);
                dbm.AddParameters(3, "@SpecialOfferID", SID.SpecialOfferID);
                dbm.AddParameters(4, "@UnitPrice", SID.UnitPrice);
                dbm.AddParameters(5, "@UnitPriceDiscount", SID.UnitPriceDiscount);
                dbm.AddParameters(6, "@LineTotal", SID.LineTotal);
                dbm.AddParameters(7, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(8, "@InvoiceDetailID", SID.InvoiceDetailID);

                dbm.Parameters[8].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesInvoiceDetail");
                SID.InvoiceDetailID = Int32.Parse(dbm.Parameters[8].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesInvoiceDetail");
                throw (ex);

            }
            finally
            {
                dbm.Dispose();
            }
            return SID.InvoiceDetailID;
        }
        public DataSet GetAllSalesInvoiceDetailsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesInvoiceDetailsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesInvoiceDetailCollection GetAllSalesInvoiceDetailsCollection()
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceDetailCollection cols = new SalesInvoiceDetailCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceDetailAll");
                while (reader.Read())
                {
                    SalesInvoiceDetail SID = new SalesInvoiceDetail();
                    SID.@InvoiceDetailID = Int32.Parse(reader["@InvoiceDetailID"].ToString());
                    SID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SID.Quantity = short.Parse(reader["Quantity"].ToString());
                    SID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SID.SpecialOfferID = Int32.Parse(reader[""].ToString());
	                SID.UnitPrice = decimal.Parse(reader[""].ToString());
	                SID.UnitPriceDiscount = decimal.Parse(reader[""].ToString());
                    SID.LineTotal = decimal.Parse(reader[""].ToString());
                    SID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SID);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesInvoiceDetail GetSalesInvoiceDetail(int @InvoiceDetailID)
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceDetail SID = new SalesInvoiceDetail();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceDetailID", @InvoiceDetailID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceDetail");
                while (reader.Read())
                {
                    SID.@InvoiceDetailID = Int32.Parse(reader["@InvoiceDetailID"].ToString());
                    SID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SID.Quantity = short.Parse(reader["Quantity"].ToString());
                    SID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SID.SpecialOfferID = Int32.Parse(reader[""].ToString());
                    SID.UnitPrice = decimal.Parse(reader[""].ToString());
                    SID.UnitPriceDiscount = decimal.Parse(reader[""].ToString());
                    SID.LineTotal = decimal.Parse(reader[""].ToString());
                    SID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SID;
        }
        public DataSet GetAllSalesInvoiceDetailsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesInvoiceDetailsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesInvoiceDetailCollection GetAllSalesInvoiceDetailsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesInvoiceDetailCollection cols = new SalesInvoiceDetailCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesInvoiceDetailsDynamic");
                while (reader.Read())
                {
                    SalesInvoiceDetail SID = new SalesInvoiceDetail();
                    SID.@InvoiceDetailID = Int32.Parse(reader["@InvoiceDetailID"].ToString());
                    SID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    SID.Quantity = short.Parse(reader["Quantity"].ToString());
                    SID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SID.SpecialOfferID = Int32.Parse(reader[""].ToString());
                    SID.UnitPrice = decimal.Parse(reader[""].ToString());
                    SID.UnitPriceDiscount = decimal.Parse(reader[""].ToString());
                    SID.LineTotal = decimal.Parse(reader[""].ToString());
                    SID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SID);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailsDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public DataSet GetInvoiceDetailsGroupedByName(int invoiceid)
        {
            DataSet ds = new DataSet();
            string sql = "select p.name, sum(o.quantity) as Quantity, o.unitprice as Price,";
            sql += " sum(UnitPriceDiscount) as Discount,";
            sql += " ( sum(quantity * unitprice) - sum(UnitPriceDiscount) ) as [Grand Total]";
            sql += " from salesinvoicedetail o,product p";
            sql += " where o.productid=p.productid and";
            sql += " o.invoiceid=" + invoiceid.ToString();
            sql += " group by p.name,o.unitprice order by p.name";
            try
            {
                GenericQuery q = new GenericQuery();
                ds = q.GetDataSet(false, sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, sql);
                throw (ex);
            }
            return ds;
        }
    }
}
