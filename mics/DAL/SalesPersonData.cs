using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesPersonData
    {
        LogWriter log = new LogWriter();
        public SalesPersonData()
        {
        }
        public bool UpdateSalesPerson(SalesPerson SP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@SalesPersonID", SP.SalesPersonID);
                dbm.AddParameters(1, "@TerritoryID", SP.TerritoryID);
                dbm.AddParameters(2, "@SalesQuota", SP.SalesQuota);
                dbm.AddParameters(3, "@Bounus", SP.Bonus);
                dbm.AddParameters(4, "@CommissionPct", SP.CommissionPct);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesPerson");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesPerson");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesPerson(int SalesPersonID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SalesPersonID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesPerson");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesPerson");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesPerson(SalesPerson SP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SP.SalesPersonID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesPerson");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesPerson");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesPerson(SalesPerson SP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@SalesPersonID", SP.SalesPersonID);
                dbm.AddParameters(1, "@TerritoryID", SP.TerritoryID);
                dbm.AddParameters(2, "@SalesQuota", SP.SalesQuota);
                dbm.AddParameters(3, "@Bounus", SP.Bonus);
                dbm.AddParameters(4, "@CommissionPct", SP.CommissionPct);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.Parameters[0].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesPerson");
                SP.SalesPersonID = Int32.Parse(dbm.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertUpdateSalesPerson");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SP.SalesPersonID;
        }
        public int AddUpdateSalesPerson(SalesPerson SP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@SalesPersonID", SP.SalesPersonID);
                dbm.AddParameters(1, "@TerritoryID", SP.TerritoryID);
                dbm.AddParameters(2, "@SalesQuota", SP.SalesQuota);
                dbm.AddParameters(3, "@Bonus", SP.Bonus);
                dbm.AddParameters(4, "@CommissionPct", SP.CommissionPct);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertUpdateSalesPerson");
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertUpdateSalesPerson");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SP.SalesPersonID;
        }
        public DataSet GetAllSalesPersonsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesPersonsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesPersonCollection GetAllSalesPersonsCollection()
        {
            IDBManager dbm = new DBManager();
            SalesPersonCollection cols = new SalesPersonCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPersonAll");
                while (reader.Read())
                {
                    SalesPerson SP = new SalesPerson();
                    SP.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SP.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SP.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SP.Bonus = Decimal.Parse(reader["Bonus"].ToString());
                    SP.CommissionPct = Decimal.Parse(reader["CommissionPct"].ToString());
                    SP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SP);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesPerson GetSalesPerson(int SalesPersonID)
        {
            IDBManager dbm = new DBManager();
            SalesPerson SP = new SalesPerson();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesPersonID", SalesPersonID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPerson");
                while (reader.Read())
                {
                    SP.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SP.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SP.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SP.Bonus = Decimal.Parse(reader["Bonus"].ToString());
                    SP.CommissionPct = Decimal.Parse(reader["CommissionPct"].ToString());
                    SP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPerson");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SP;
        }
        public DataSet GetAllSalesPersonsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesPersonsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesPersonCollection GetAllSalesPersonsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesPersonCollection cols = new SalesPersonCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesPersonsDynamic");
                while (reader.Read())
                {
                    SalesPerson SP = new SalesPerson();
                    SP.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SP.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    SP.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SP.Bonus = Decimal.Parse(reader["Bonus"].ToString());
                    SP.CommissionPct = Decimal.Parse(reader["CommissionPct"].ToString());
                    SP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SP);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }

        public DataSet GetAllSalesPersonsViewDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "ViewSalesPersonsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsViewDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesPersonCollection GetAllSalesPersonsViewCollection()
        {
            IDBManager dbm = new DBManager();
            SalesPersonCollection col = new SalesPersonCollection();
            
            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "ViewSalesPersonsAll");
                while (reader.Read())
                {
                    SalesPerson SP = new SalesPerson();
                    SP.SalesPersonID = Int32.Parse(reader["SalesPersonID"].ToString());
                    SP.FullName = reader["FullName"].ToString().Trim();
                    SP.SalesQuota = Decimal.Parse(reader["SalesQuota"].ToString());
                    SP.Bonus = Decimal.Parse(reader["Bonus"].ToString());
                    SP.CommissionPct = Decimal.Parse(reader["CommissionPct"].ToString());
                    SP.FirstName = reader["FirstName"].ToString().Trim();
                    SP.MiddleName = reader["MiddleName"].ToString().Trim();
                    SP.LastName = reader["LastName"].ToString().Trim();
                    col.Add(SP);

                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsViewDataCollection()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return col;
        }
    }
}
