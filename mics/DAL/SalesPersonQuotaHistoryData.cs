using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesPersonQuotaHistoryData
    {
        LogWriter log = new LogWriter();
        public SalesPersonQuotaHistoryData()
        {
        }
        public bool UpdateSalesPersonQuotaHistory(SalesPersonQuotaHistory SPQH)
        {
            
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@SalesPersonID", SPQH.SalesPersonID);
                dbm.AddParameters(1, "@QuotaDate", SPQH.QuotaDate);
                dbm.AddParameters(2, "@SalesQuota", SPQH.SalesQuota);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesPersonQuotaHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesPersonQuotaHistory(int SalesPersonID)
        {
            
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SalesPersonID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesPersonQuotaHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesPersonQuotaHistory(SalesPersonQuotaHistory SPQH)
        {
            
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SPQH.SalesPersonID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesPersonQuotaHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool AddSalesPersonQuotaHistory(SalesPersonQuotaHistory SPQH)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@SalesPersonID", SPQH.SalesPersonID);
                dbm.AddParameters(1, "@QuotaDate", SPQH.QuotaDate);
                dbm.AddParameters(2, "@SalesQuota", SPQH.SalesQuota);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesPersonQuotaHistory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public DataSet GetAllSalesPersonQuotaHistorysDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesPersonQuotaHistorysAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistorysDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesPersonQuotaHistoryCollection GetAllSalesPersonQuotaHistorysCollection()
        {
            IDBManager dbm = new DBManager();
            SalesPersonQuotaHistoryCollection cols = new SalesPersonQuotaHistoryCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPersonQuotaHistoryAll");
                while (reader.Read())
                {
                    SalesPersonQuotaHistory SPQH = new SalesPersonQuotaHistory();
                    SPQH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SPQH.QuotaDate = DateTime.Parse(reader["QuotaDate"].ToString());
                    SPQH.SalesQuota = decimal.Parse(reader["SalesQuota"].ToString());
                    SPQH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SPQH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistorysCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesPersonQuotaHistory GetSalesPersonQuotaHistory(int SalesPersonID)
        {
            IDBManager dbm = new DBManager();
            SalesPersonQuotaHistory SPQH = new SalesPersonQuotaHistory();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SalesPersonID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPersonQuotaHistory");
                while (reader.Read())
                {
                    SPQH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SPQH.QuotaDate = DateTime.Parse(reader["QuotaDate"].ToString());
                    SPQH.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SPQH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString()); ;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SPQH;
        }
        public DataSet GetAllSalesPersonQuotaHistorysDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesPersonQuotaHistorysDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistorysDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesPersonQuotaHistoryCollection GetAllSalesPersonQuotaHistorysDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesPersonQuotaHistoryCollection cols = new SalesPersonQuotaHistoryCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPersonQuotaHistorysDynamic");
                while (reader.Read())
                {
                    SalesPersonQuotaHistory SPQH = new SalesPersonQuotaHistory();
                    SPQH.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SPQH.QuotaDate = DateTime.Parse(reader["QuotaDate"].ToString());
                    SPQH.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SPQH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString()); ;
                    cols.Add(SPQH);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistorysDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
    }
}
