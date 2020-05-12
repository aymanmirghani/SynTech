using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class SpecialOfferData
    {
        LogWriter log = new LogWriter();
        public SpecialOfferData()
        {
        }
        public bool UpdateSpecialOffer(SpecialOffer SO)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(10);
                dbm.AddParameters(0, "@SpecialOfferID", SO.SpecialOfferID);
                dbm.AddParameters(1, "@Description", SO.Description);
                dbm.AddParameters(2, "@DiscountPct", SO.DiscountPct);
                dbm.AddParameters(3, "@Type", SO.Type);
                dbm.AddParameters(4, "@Category", SO.Category);
                dbm.AddParameters(5, "@StartDate", SO.StartDate);
                dbm.AddParameters(6, "@EndDate", SO.EndDate);
                dbm.AddParameters(7, "@MaxQty", SO.MaxQty);
                dbm.AddParameters(8, "@MinQty", SO.MinQty);
	            dbm.AddParameters(9,"@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSpecialOffer");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSpecialOffer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSpecialOffer(int SpacialOfferID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SpacialOfferID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSpecialOffer");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSpecialOffer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteSpecialOffer(SpecialOffer SO)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SO.SpecialOfferID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteSpecialOffer");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSpecialOffer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddSpecialOffer(SpecialOffer SO)
        {
            IDBManager dbm = new DBManager();
            
            try
            {
                dbm.CreateParameters(10);
                dbm.AddParameters(0, "@Description", SO.Description);
                dbm.AddParameters(1, "@DiscountPct", SO.DiscountPct);
                dbm.AddParameters(2, "@Type", SO.Type);
                dbm.AddParameters(3, "@Category", SO.Category);
                dbm.AddParameters(4, "@StartDate", SO.StartDate);
                dbm.AddParameters(5, "@EndDate", SO.EndDate);
                dbm.AddParameters(6, "@MinQty", SO.MinQty);
                dbm.AddParameters(7, "@MaxQty", SO.MaxQty);
	            dbm.AddParameters(8,"@ModifiedDate", DateTime.Now);
                dbm.AddParameters(9, "@SpecialOfferID", SO.SpecialOfferID);
                dbm.Parameters[9].Direction = ParameterDirection.Output;

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSpecialOffer");
                SO.SpecialOfferID = Int32.Parse(dbm.Parameters[9].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSpecialOffer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SO.SpecialOfferID;
        }
        public int AddUpdateSpecialOffer(SpecialOffer SO)
        {
            IDBManager dbm = new DBManager();

            try
            {
                dbm.CreateParameters(10);
                dbm.AddParameters(0, "@Description", SO.Description);
                dbm.AddParameters(1, "@DiscountPct", SO.DiscountPct);
                dbm.AddParameters(2, "@Type", SO.Type);
                dbm.AddParameters(3, "@Category", SO.Category);
                dbm.AddParameters(4, "@StartDate", SO.StartDate);
                dbm.AddParameters(5, "@EndDate", SO.EndDate);
                dbm.AddParameters(6, "@MinQty", SO.MinQty);
                dbm.AddParameters(7, "@MaxQty", SO.MaxQty);
                dbm.AddParameters(8, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(9, "@SpecialOfferID", SO.SpecialOfferID);
                dbm.Parameters[9].Direction = ParameterDirection.Output;

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSpecialOffer");
                SO.SpecialOfferID = Int32.Parse(dbm.Parameters[9].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "InsertSpecialOffer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return SO.SpecialOfferID; 
        }

        public DataSet GetAllSpecialOffersDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSpecialOffersAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersDataSet()");
                throw (ex);;
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SpecialOfferCollection GetAllSpecialOffersCollection()
        {
            IDBManager dbm = new DBManager();
            SpecialOfferCollection cols = new SpecialOfferCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOfferAll");
                while (reader.Read())
                {
                    SpecialOffer SO = new SpecialOffer();
                    SO.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SO.Description = reader["Description"].ToString();
                    SO.Category = reader["Category"].ToString();
                    SO.DiscountPct = decimal.Parse(reader["DiscountPct"].ToString());
                    SO.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    SO.MaxQty = Int32.Parse(reader["MaxQty"].ToString());
                    SO.MinQty = Int32.Parse(reader["MinQty"].ToString());
                    SO.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    SO.Type = reader["Type"].ToString();
                    SO.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SO);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersCollection");
                throw (ex);;
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public SpecialOffer GetSpecialOffer(int SpecialOfferID)
        {
            IDBManager dbm = new DBManager();
            SpecialOffer SO = new SpecialOffer();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@SpecialOfferID", SpecialOfferID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOffer");
                while (reader.Read())
                {
                    SO.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SO.Description = reader["Description"].ToString();
                    SO.Category = reader["Category"].ToString();
                    SO.DiscountPct = decimal.Parse(reader["DiscountPct"].ToString());
                    SO.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    SO.MaxQty = Int32.Parse(reader["MaxQty"].ToString());
                    SO.MinQty = Int32.Parse(reader["MinQty"].ToString());
                    SO.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    SO.Type = reader["Type"].ToString();
                    SO.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOffer");
                throw (ex);;
            }
            finally
            {
                dbm.Dispose();
            }
            return SO;
        }
        public DataSet GetAllSpecialOffersDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectSpecialOffersDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersDynamicDataSet()");
                throw (ex);;
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public SpecialOfferCollection GetAllSpecialOffersDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            SpecialOfferCollection cols = new SpecialOfferCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectSpecialOffersDynamic");
                while (reader.Read())
                {
                    SpecialOffer SO = new SpecialOffer();
                    SO.SpecialOfferID = Int32.Parse(reader["SpecialOfferID"].ToString());
                    SO.Description = reader["Description"].ToString();
                    SO.Category = reader["Category"].ToString();
                    SO.DiscountPct = decimal.Parse(reader["DiscountPct"].ToString());
                    SO.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    SO.MaxQty = Int32.Parse(reader["MaxQty"].ToString());
                    SO.MinQty = Int32.Parse(reader["MinQty"].ToString());
                    SO.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    SO.Type = reader["Type"].ToString();
                    SO.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(SO);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersDynamicCollection");
                throw (ex);;
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
    }
}
