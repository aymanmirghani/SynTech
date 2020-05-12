using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class ProductAdjustmentHistoryData
    {
        LogWriter log = new LogWriter();
        public ProductAdjustmentHistoryData()
		{
            
		}
        public int AddProductAdjustmentHistory(ProductAdjustmentHistory PAH)
		{
			IDBManager dbm = new DBManager();
			try
			{
                dbm.CreateParameters(5);
                dbm.AddParameters(0, "@ProductID", PAH.ProductID);
                dbm.AddParameters(1, "@AdjustedQuantity", PAH.AdjustedQuantity);
                dbm.AddParameters(2, "@Reason", PAH.Reason);
                dbm.AddParameters(3, "@ModifiedDate", PAH.ModifiedDate);
                dbm.AddParameters(4, "@ID", PAH.ID);
                dbm.Parameters[4].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductAdjustmentHistory");
                PAH.ID = Int32.Parse(dbm.Parameters[4].Value.ToString());

			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddProductAdjustmentHistory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PAH.ID;
		}
		public DataSet GetAllProductAdjustmentHistoryDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductAdjustmentHistorysAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductAdjustmentHistoryDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public DataSet GetAllProductAdjustmentHistoryDataSet(int purchaseAdjustedQuantity)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductID", purchaseAdjustedQuantity);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductAdjustmentHistoryByAdjustedQuantity");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductAdjustmentHistoryDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public ProductAdjustmentHistoryCollection GetAllProductAdjustmentHistoryCollection(int purchaseAdjustedQuantity)
        {
            IDBManager dbm = new DBManager();
            ProductAdjustmentHistoryCollection cols = new ProductAdjustmentHistoryCollection();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductID", purchaseAdjustedQuantity);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductAdjustmentHistoryByAdjustedQuantity");
                while (reader.Read())
                {
                    ProductAdjustmentHistory PAH = new ProductAdjustmentHistory();
                    PAH.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PAH.AdjustedQuantity = Int32.Parse(reader["AdjustedQuantity"].ToString());
                    PAH.Reason = reader["Reason"].ToString();
                    PAH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    
                    cols.Add(PAH);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "ProductAdjustmentHistoryCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
		public ProductAdjustmentHistoryCollection GetAllProductAdjustmentHistoryCollection()
		{
			IDBManager dbm = new DBManager();
			ProductAdjustmentHistoryCollection cols = new ProductAdjustmentHistoryCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductAdjustmentHistorysAll");
				while (reader.Read())
				{
                    ProductAdjustmentHistory PAH = new ProductAdjustmentHistory();
                    PAH.ID = Int32.Parse(reader["ID"].ToString());
                    PAH.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PAH.AdjustedQuantity = Int32.Parse(reader["AdjustedQuantity"].ToString());
                    PAH.Reason = reader["Reason"].ToString();
                    PAH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PAH);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "ProductAdjustmentHistoryCollection");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public ProductAdjustmentHistory GetProductAdjustmentHistory(int ID)
		{
			IDBManager dbm = new DBManager();
            ProductAdjustmentHistory PAH = new ProductAdjustmentHistory();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", ID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductAdjustmentHistory");
				while (reader.Read())
				{
                    PAH.ID = Int32.Parse(reader["ID"].ToString());
                    PAH.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PAH.AdjustedQuantity = Int32.Parse(reader["AdjustedQuantity"].ToString());
                    PAH.Reason = reader["Reason"].ToString();
                    PAH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetProductAdjustmentHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PAH;
		}
		public DataSet GetProductAdjustmentHistoryDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductAdjustmentHistorysDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductAdjustmentHistoryDynamicDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public ProductAdjustmentHistoryCollection GetAllProductAdjustmentHistoryDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            ProductAdjustmentHistoryCollection cols = new ProductAdjustmentHistoryCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectUsersDynamic");
                while (reader.Read())
                {
                    ProductAdjustmentHistory PAH = new ProductAdjustmentHistory();

                    PAH.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PAH.AdjustedQuantity = Int32.Parse(reader["ProductID"].ToString());
                    PAH.Reason = reader["Reason"].ToString();
                    PAH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PAH);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductAdjustmentHistoryDynamicCollection");
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
