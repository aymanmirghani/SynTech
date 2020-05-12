using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesOrderDetailData
    {
        LogWriter log = new LogWriter();
        public SalesOrderDetailData()
        {
        }
        public bool UpdateSalesOrderDetail(SalesOrderDetail SOD)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(10);
                dbm.AddParameters(0, "@SalesOrderID", SOD.SalesOrderID);
                dbm.AddParameters(1, "@SalesOrderDetailID", SOD.SalesOrderDetailID);
                dbm.AddParameters(2, "@CarrierTrackingNumber", SOD.CarrierTrackingNumber);
                dbm.AddParameters(3, "@OrderQty", SOD.OrderQty);
                dbm.AddParameters(4, "@ProductID", SOD.ProductID);
                dbm.AddParameters(5, "@SpecialOfferID",SOD.SpecialOfferID);
	            dbm.AddParameters(6, "@UnitPrice", SOD.UnitPrice);
	            dbm.AddParameters(7, "@UnitPriceDiscount", SOD.UnitPriceDiscount);
                dbm.AddParameters(8, "@LineTotal", SOD.LineTotal);
                dbm.AddParameters(9, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesOrderDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesOrderDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesOrderDetail(int salesOrderID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderID", salesOrderID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesOrderDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesOrderDetail(SalesOrderDetail SOD)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderDetailID", SOD.SalesOrderDetailID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesOrderDetail");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesOrderDetailsDynamic(string where)
        {
            IDBManager dbm = new DBManager();
            bool ret = true;
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@WhereCondition", where);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesOrderDetailsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderDetailsDynamic");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ret;
        }
        public int AddSalesOrderDetail(SalesOrderDetail SOD)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(10);
                dbm.AddParameters(0, "@SalesOrderID", SOD.SalesOrderID);
                dbm.AddParameters(1, "@SalesOrderDetailID", SOD.SalesOrderDetailID);
                dbm.AddParameters(2, "@CarrierTrackingNumber", SOD.CarrierTrackingNumber);
                dbm.AddParameters(3, "@OrderQty", SOD.OrderQty);
                dbm.AddParameters(4, "@ProductID", SOD.ProductID);
                dbm.AddParameters(5, "@SpecialOfferID", SOD.SpecialOfferID);
                dbm.AddParameters(6, "@UnitPrice", SOD.UnitPrice);
                dbm.AddParameters(7, "@UnitPriceDiscount", SOD.UnitPriceDiscount);
                dbm.AddParameters(8, "@LineTotal", SOD.LineTotal);
                dbm.AddParameters(9, "@ModifiedDate", DateTime.Now);

                dbm.Parameters[1].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesOrderDetail");
                SOD.SalesOrderDetailID = Int32.Parse(dbm.Parameters[1].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesOrderDetail");
                throw (ex);

            }
            finally
            {
                dbm.Dispose();
            }
            return SOD.SalesOrderDetailID ;
        }
        public DataSet GetAllSalesOrderDetailsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesOrderDetailsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesOrderDetailCollection GetAllSalesOrderDetailsCollection()
        {
            IDBManager dbm = new DBManager();
            SalesOrderDetailCollection cols = new SalesOrderDetailCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderDetailAll");
                while (reader.Read())
                {
                    SalesOrderDetail SOD = new SalesOrderDetail();
                    SOD.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    SOD.SalesOrderDetailID = Int32.Parse(reader["SalesOrderDetailID"].ToString());
                    SOD.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                    SOD.OrderQty = short.Parse(reader["OrderQty"].ToString());
                    SOD.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOD.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SOD.UnitPrice = decimal.Parse(reader["UnitPrice"].ToString());
                    SOD.UnitPriceDiscount = decimal.Parse(reader["UnitPriceDiscount"].ToString());
                    SOD.LineTotal = decimal.Parse(reader["LineTotal"].ToString());
                    SOD.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SOD);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesOrderDetail GetSalesOrderDetail(int salesOrderDetailID)
        {
            IDBManager dbm = new DBManager();
            SalesOrderDetail SOD = new SalesOrderDetail();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesOrderDetailID", salesOrderDetailID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderDetail");
                while (reader.Read())
                {
                    SOD.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    SOD.SalesOrderDetailID = Int32.Parse(reader["SalesOrderDetailID"].ToString());
                    SOD.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                    SOD.OrderQty = short.Parse(reader["OrderQty"].ToString());
                    SOD.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOD.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SOD.UnitPrice = decimal.Parse(reader["UnitPrice"].ToString());
                    SOD.UnitPriceDiscount = decimal.Parse(reader["UnitPriceDiscount"].ToString());
                    SOD.LineTotal = decimal.Parse(reader["LineTotal"].ToString());
                    SOD.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SOD;
        }
        public DataSet GetAllSalesOrderDetailsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesOrderDetailsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesOrderDetailCollection GetAllSalesOrderDetailsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesOrderDetailCollection cols = new SalesOrderDetailCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesOrderDetailsDynamic");
                while (reader.Read())
                {
                    SalesOrderDetail SOD = new SalesOrderDetail();
                    SOD.SalesOrderID = Int32.Parse(reader["SalesOrderID"].ToString());
                    SOD.SalesOrderDetailID = Int32.Parse(reader["SalesOrderDetailID"].ToString());
                    SOD.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                    SOD.OrderQty = short.Parse(reader["OrderQty"].ToString());
                    SOD.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOD.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    if (reader["SpecialOfferDesc"] != DBNull.Value)
                        SOD.SpecialOfferDesc = reader["SpecialOfferDesc"].ToString();
                    else
                        SOD.SpecialOfferDesc = "";
                    SOD.UnitPrice = decimal.Parse(reader["UnitPrice"].ToString());
                    SOD.UnitPriceDiscount = decimal.Parse(reader["UnitPriceDiscount"].ToString());
                    SOD.LineTotal = decimal.Parse(reader["LineTotal"].ToString());
                    SOD.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    SOD.ProductName = reader["Name"].ToString();
                    SOD.Description = reader["Description"].ToString();
                    cols.Add(SOD);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailsDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public DataSet GetOrderDetailsGroupedByName(int orderid)
        {
            DataSet ds = new DataSet();
            string sql = "select p.name, sum(o.orderqty) as Quantity, o.unitprice as Price,";
            sql += " sum(UnitPriceDiscount) as Discount,";
            sql += " ( sum(orderqty * unitprice) - sum(UnitPriceDiscount) ) as [Grand Total]";
            sql += " from salesorderdetail o,product p";
            sql += " where o.productid=p.productid and";
            sql += " o.salesorderid=" + orderid.ToString();
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
