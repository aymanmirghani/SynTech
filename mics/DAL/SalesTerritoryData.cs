using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesTerritoryData
    {
        LogWriter log = new LogWriter();
        public SalesTerritoryData()
        {
        }
        public bool UpdateSalesTerritory(SalesTerritory ST)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@TerritoryID", ST.TerritoryID);
                dbm.AddParameters(1, "@Name", ST.Name);
                dbm.AddParameters(2, "@CountryRegionCode", ST.CountryRegionCode);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesTerritory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTerritory(int TerritoryID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@TerritoryID", TerritoryID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTerritory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTerritory(SalesTerritory ST)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@TerritoryID", ST.TerritoryID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTerritory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesTerritory(SalesTerritory ST)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                
                dbm.AddParameters(0, "@Name", ST.Name);
                dbm.AddParameters(1, "@CountryRegionCode", ST.CountryRegionCode);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(3, "@TerritoryID", ST.TerritoryID);
                dbm.Parameters[3].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesTerritory");
                ST.TerritoryID = Int32.Parse(dbm.Parameters[3].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ST.TerritoryID;
        }
        public int AddUpdateSalesTerritory(SalesTerritory ST)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);

                dbm.AddParameters(0, "@Name", ST.Name);
                dbm.AddParameters(1, "@CountryRegionCode", ST.CountryRegionCode);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(3, "@TerritoryID", ST.TerritoryID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertUpdateSalesTerritory");
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertUpdateSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ST.TerritoryID;
        }
        public DataSet GetAllSalesTerritorysDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTerritoriesAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritorysDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTerritoryCollection GetAllSalesTerritorysCollection()
        {
            IDBManager dbm = new DBManager();
            SalesTerritoryCollection cols = new SalesTerritoryCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritoryAll");
                while (reader.Read())
                {
                    SalesTerritory ST = new SalesTerritory();
                    ST.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    ST.Name = reader["Name"].ToString();
                    ST.CountryRegionCode = reader["CountryRegionCode"].ToString();
                    ST.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(ST);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritorysCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesTerritory GetSalesTerritory(int TerritoryID)
        {
            IDBManager dbm = new DBManager();
            SalesTerritory ST = new SalesTerritory();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@TerritoryID", TerritoryID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritory");
                while (reader.Read())
                {
                    ST.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    ST.Name = reader["Name"].ToString();
                    ST.CountryRegionCode = reader["CountryRegionCode"].ToString();
                    ST.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ST;
        }
        public DataSet GetAllSalesTerritorysDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTerritorysDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritorysDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTerritoryCollection GetAllSalesTerritorysDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesTerritoryCollection cols = new SalesTerritoryCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTerritorysDynamic");
                while (reader.Read())
                {
                    SalesTerritory ST = new SalesTerritory();
                    ST.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    ST.Name = reader["Name"].ToString();
                    ST.CountryRegionCode = reader["CountryRegionCode"].ToString();
                    ST.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(ST);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritorysDynamicCollection");
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
