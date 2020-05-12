using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SalesTaxRateData
    {
        LogWriter log = new LogWriter();
        public SalesTaxRateData()
        {
        }
        public bool UpdateSalesTaxRate(SalesTaxRate STR)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@SalesTaxRateID", STR.SalesTaxRateID);
                dbm.AddParameters(1, "@StateProvinceID", STR.StateProvinceID);
                dbm.AddParameters(2, "@TaxType", STR.TaxType);
                dbm.AddParameters(3, "@TaxRate", STR.TaxRate);
                dbm.AddParameters(4, "@Name", STR.Name);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSalesTaxRate");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTaxRate");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTaxRate(int SalesTaxRateID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesTaxRateID", SalesTaxRateID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTaxRate");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTaxRate");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSalesTaxRate(SalesTaxRate STR)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesTaxRateID", STR.SalesTaxRateID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSalesTaxRate");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesTaxRate");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSalesTaxRate(SalesTaxRate STR)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(6);
                
                dbm.AddParameters(0, "@StateProvinceID", STR.StateProvinceID);
                dbm.AddParameters(1, "@TaxType", STR.TaxType);
                dbm.AddParameters(2, "@TaxRate", STR.TaxRate);
                dbm.AddParameters(3, "@Name", STR.Name);
                dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(5, "@SalesTaxRateID", STR.SalesTaxRateID);
                dbm.Parameters[5].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSalesTaxRate");
                STR.SalesTaxRateID = Int32.Parse(dbm.Parameters[5].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSalesTaxRate");
               throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return STR.SalesTaxRateID;
        }
        public DataSet GetAllSalesTaxRatesDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTaxRatesAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTaxRateCollection GetAllSalesTaxRatesCollection()
        {
            IDBManager dbm = new DBManager();
            SalesTaxRateCollection cols = new SalesTaxRateCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTaxRateAll");
                while (reader.Read())
                {
                    SalesTaxRate STR = new SalesTaxRate();
                    STR.SalesTaxRateID = Int32.Parse(reader["SalesTaxRateID"].ToString());
                    STR.StateProvinceID = reader["StateProvinceID"].ToString();
                    STR.TaxType = Byte.Parse(reader["TaxType"].ToString());
                    STR.TaxRate = Decimal.Parse(reader["TaxRate"].ToString());
                    STR.Name = reader["Name"].ToString();
                    STR.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(STR);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SalesTaxRate GetSalesTaxRate(int SalesTaxRateID)
        {
            IDBManager dbm = new DBManager();
            SalesTaxRate STR = new SalesTaxRate();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SalesTaxRateID", SalesTaxRateID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTaxRate");
                while (reader.Read())
                {
                    STR.SalesTaxRateID = Int32.Parse(reader["SalesTaxRateID"].ToString());
                    STR.StateProvinceID = reader["StateProvinceID"].ToString();
                    STR.TaxType = Byte.Parse(reader["TaxType"].ToString());
                    STR.TaxRate = Decimal.Parse(reader["TaxRate"].ToString());
                    STR.Name = reader["Name"].ToString();
                    STR.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTaxRate");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return STR;
        }
        public DataSet GetAllSalesTaxRatesDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSalesTaxRatesDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SalesTaxRateCollection GetAllSalesTaxRatesDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SalesTaxRateCollection cols = new SalesTaxRateCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSalesTaxRatesDynamic");
                while (reader.Read())
                {
                    SalesTaxRate STR = new SalesTaxRate();
                    STR.SalesTaxRateID = Int32.Parse(reader["SalesTaxRateID"].ToString());
                    STR.StateProvinceID = reader["StateProvinceID"].ToString();
                    STR.TaxType = Byte.Parse(reader["TaxType"].ToString());
                    STR.TaxRate = Decimal.Parse(reader["TaxRate"].ToString());
                    STR.Name = reader["Name"].ToString();
                    STR.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(STR);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesDynamicCollection");
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
