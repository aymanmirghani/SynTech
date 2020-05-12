using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesTerritoryHistoryData
    {
        LogWriter log = new LogWriter();
        public SalesTerritoryHistoryData()
        {
        }
        public bool UpdateSalesTerritoryHistory(SalesTerritoryHistory STH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@ID", STH.ID);
                dbm.AddParameters(1, "@EndDate", STH.EndDate);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesTerritoryHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTerritoryHistory(int SalesPersonID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@SalesPersonID", SalesPersonID);
                dbm.AddParameters(1, "@EndDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTerritoryHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTerritoryHistory(SalesTerritoryHistory STH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", STH.SalesPersonID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTerritoryHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool AddSalesTerritoryHistory(SalesTerritoryHistory STH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(5);
                dbm.AddParameters(0, "@SalesPersonID", STH.SalesPersonID);
                dbm.AddParameters(1, "@TerritoryID", STH.TerritoryID);
                dbm.AddParameters(2, "@StartDate", STH.StartDate);
                dbm.AddParameters(3, "@EndDate", "");
                dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesTerritoryHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public DataSet GetAllSalesTerritoryHistorysDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTerritoryHistorysAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryHistorysDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTerritoryHistoryCollection GetAllSalesTerritoryHistorysCollection()
        {
            IDBManager dbm = new DBManager();
            SalesTerritoryHistoryCollection cols = new SalesTerritoryHistoryCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritoryHistoryAll");
                while (reader.Read())
                {
                    SalesTerritoryHistory STH = new SalesTerritoryHistory();
                    STH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    STH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    STH.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    STH.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    STH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(STH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryHistorysCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesTerritoryHistory GetSalesTerritoryHistory(int ID)
        {
            IDBManager dbm = new DBManager();
            SalesTerritoryHistory STH = new SalesTerritoryHistory();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", ID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritoryHistory");
                while (reader.Read())
                {
                    STH.ID = Int32.Parse(reader["ID"].ToString());
                    STH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    STH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    STH.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    if (reader["EndDate"] != null && reader["EndDate"].ToString() != "")
                    {
                        STH.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    }
                    STH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return STH;
        }
        public DataSet GetAllSalesTerritoryHistorysDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTerritoryHistorysDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryHistorysDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTerritoryHistoryCollection GetAllSalesTerritoryHistorysDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesTerritoryHistoryCollection cols = new SalesTerritoryHistoryCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritoryHistorysDynamic");
                while (reader.Read())
                {
                    SalesTerritoryHistory STH = new SalesTerritoryHistory();
                    STH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    STH.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    STH.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    STH.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    STH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(STH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryHistorysDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public DataSet GetAllSalesTerritoryHistorysViewDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "ViewSalesTerritoryList");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryHistorysViewDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
    }
}
