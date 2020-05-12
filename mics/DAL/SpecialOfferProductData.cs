using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SpecialOfferProductData
    {
        LogWriter log = new LogWriter();
        public SpecialOfferProductData()
        {
        }
        public bool UpdateSpecialOfferProduct(SpecialOfferProduct SOP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@SpecialOfferID", SOP.SpecialOfferID);
                dbm.AddParameters(1, "@ProductID", SOP.ProductID);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSpecialOfferProduct");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSpecialOfferProduct(int SpacialOfferID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SpacialOfferID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSpecialOfferProduct");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSpecialOfferProduct(SpecialOfferProduct SOP)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SOP.SpecialOfferID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSpecialOfferProduct");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool AddSpecialOfferProduct(SpecialOfferProduct SOP)
        {
            IDBManager dbm = new DBManager();
           
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@SpecialOfferID", SOP.SpecialOfferID);
                dbm.AddParameters(1, "@ProductID", SOP.ProductID);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSpecialOfferProduct");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public DataSet GetAllSpecialOfferProductsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSpecialOfferProductsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SpecialOfferProductCollection GetAllSpecialOfferProductsCollection()
        {
            IDBManager dbm = new DBManager();
            SpecialOfferProductCollection cols = new SpecialOfferProductCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOfferProductAll");
                while (reader.Read())
                {
                    SpecialOfferProduct SOP = new SpecialOfferProduct();
                    SOP.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SOP.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SOP);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SpecialOfferProduct GetSpecialOfferProduct(int SpecialOfferID)
        {
            IDBManager dbm = new DBManager();
            SpecialOfferProduct SOP = new SpecialOfferProduct();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SpecialOfferID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOfferProduct");
                while (reader.Read())
                {
                    SOP.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SOP.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SOP;
        }
        public DataSet GetAllSpecialOfferProductsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSpecialOfferProductsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SpecialOfferProductCollection GetAllSpecialOfferProductsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SpecialOfferProductCollection cols = new SpecialOfferProductCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOfferProductsDynamic");
                while (reader.Read())
                {
                    SpecialOfferProduct SOP = new SpecialOfferProduct();
                    SOP.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SOP.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    SOP.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SOP);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductsDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public DataSet GetDiscountByProduct(int productid, int quantity)
        {
            GenericQuery q = new GenericQuery();
            DataSet ds = new DataSet();
            string sql = "select s.description as SpecialOfferDesc,s.specialofferid,discountpct,type,minqty,maxqty";
            sql += " from specialoffer s";
            sql += " join specialofferproduct sp on s.specialofferid=sp.specialofferid";
            sql += " where productid=" + productid.ToString();
            sql += " and startDate <=getdate() and EndDate >= getdate()";
            sql += " and (minqty=0 or minqty >= " + quantity.ToString() + ")";
            try
            {
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
