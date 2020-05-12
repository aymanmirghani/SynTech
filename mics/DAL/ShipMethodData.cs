using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class ShipMethodData
    {
        LogWriter log = new LogWriter();
        public ShipMethodData()
        {
        }
        public bool UpdateShipMethod(ShipMethod SM)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(5);
                dbm.AddParameters(0, "@ShipMethodID", SM.ShipMethodID);
                dbm.AddParameters(1, "@Name", SM.Name);
                dbm.AddParameters(2, "@ShipBase", SM.ShipBase);
                dbm.AddParameters(3, "@ShipRate", SM.ShipRate);
                dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateShipMethod");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateShipMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteShipMethod(int SpacialOfferID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ShipMethodID", SpacialOfferID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteShipMethod");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteShipMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteShipMethod(ShipMethod SM)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ShipMethodID", SM.ShipMethodID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteShipMethod");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteShipMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddShipMethod(ShipMethod SM)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(5);
                
                dbm.AddParameters(0, "@Name", SM.Name);
                dbm.AddParameters(1, "@ShipBase", SM.ShipBase);
                dbm.AddParameters(2, "@ShipRate", SM.ShipRate);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(4, "@ShipMethodID", SM.ShipMethodID);
                dbm.Parameters[4].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertShipMethod");
                SM.ShipMethodID = Int32.Parse(dbm.Parameters[4].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertShipMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SM.ShipMethodID;
        }
        public DataSet GetAllShipMethodsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectShipMethodsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public ShipMethodCollection GetAllShipMethodsCollection()
        {
            IDBManager dbm = new DBManager();
            ShipMethodCollection cols = new ShipMethodCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectShipMethodAll");
                while (reader.Read())
                {
                    ShipMethod SM = new ShipMethod();
                    SM.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SM.Name = reader["Name"].ToString();
                    SM.ShipBase = decimal.Parse(reader["ShipBase"].ToString());
                    SM.ShipRate = decimal.Parse(reader["ShipRate"].ToString());
                    SM.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SM);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public ShipMethod GetShipMethod(int ShipMethodID)
        {
            IDBManager dbm = new DBManager();
            ShipMethod SM = new ShipMethod();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ShipMethodID", ShipMethodID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectShipMethod");
                while (reader.Read())
                {
                    SM.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SM.Name = reader["Name"].ToString();
                    SM.ShipBase = decimal.Parse(reader["ShipBase"].ToString());
                    SM.ShipRate = decimal.Parse(reader["ShipRate"].ToString());
                    SM.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetShipMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SM;
        }
        public DataSet GetAllShipMethodsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectShipMethodsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public ShipMethodCollection GetAllShipMethodsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            ShipMethodCollection cols = new ShipMethodCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectShipMethodsDynamic");
                while (reader.Read())
                {
                    ShipMethod SM = new ShipMethod();
                    SM.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    SM.Name = reader["Name"].ToString();
                    SM.ShipBase = decimal.Parse(reader["ShipBase"].ToString());
                    SM.ShipRate = decimal.Parse(reader["ShipRate"].ToString());
                    SM.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SM);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsDynamicCollection");
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
