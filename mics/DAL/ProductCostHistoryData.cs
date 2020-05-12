using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
	/// <summary>
	/// Summary description for ProductCostHistoryData.
	/// </summary>
	public class ProductCostHistoryData
	{
		LogWriter log = new LogWriter();
		public ProductCostHistoryData()
		{
		}
		public bool UpdateProductCostHistory(ProductCostHistory productCostHistory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(5);
				dbm.AddParameters(0, "@ProductID", productCostHistory.ProductID);
				dbm.AddParameters(1, "@StartDate", productCostHistory.StartDate);
				dbm.AddParameters(2, "@EndDate", productCostHistory.EndDate);
				dbm.AddParameters(3, "@StandardCost", productCostHistory.StandardCost);
				dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductCostHistory");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdateProductCostHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeleteProductCostHistory(int ID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ID", ID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductCostHistory");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeleteProductCostHistory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
		public bool DeleteProductCostHistory(ProductCostHistory productCostHistory)
		{
			return(DeleteProductCostHistory(productCostHistory.ProductID));
		}
		public int AddProductCostHistory(ProductCostHistory productCostHistory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(6);
				dbm.AddParameters(0, "@ProductID", productCostHistory.ProductID);
				dbm.AddParameters(1, "@StartDate", productCostHistory.StartDate);
				dbm.AddParameters(2, "@EndDate", productCostHistory.EndDate);
				dbm.AddParameters(3, "@StandardCost", productCostHistory.StandardCost);
				dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(5,"@ID",productCostHistory.ID);
                dbm.Parameters[5].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductCostHistory");
                
                productCostHistory.ID = Int32.Parse(dbm.Parameters[5].Value.ToString());

			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "AddProductCostHistory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return productCostHistory.ID;
		}
		public DataSet GetAllProductCostHistoryDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductCostHistoriesAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductCostHistoryDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductCostHistoryCollection GetAllProductCostHistorysCollection()
		{
			IDBManager dbm = new DBManager();
			ProductCostHistoryCollection cols = new ProductCostHistoryCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCostHistoriesAll");
				while (reader.Read())
				{
					ProductCostHistory productCostHistory = new ProductCostHistory();
                    productCostHistory.ID = Int32.Parse(reader["ID"].ToString());
					productCostHistory.ProductID= Int32.Parse(reader["ProductID"].ToString());
					productCostHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
					productCostHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
					productCostHistory.StandardCost = Decimal.Parse(reader["StandardCost"].ToString());
					productCostHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
					cols.Add(productCostHistory);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductCostHistorysCollection");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public ProductCostHistory GetProductCostHistory(int productID)
		{
			IDBManager dbm = new DBManager();
			ProductCostHistory productCostHistory = new ProductCostHistory();

			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ProductID", productID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCostHistory");
				while (reader.Read())
				{
                    productCostHistory.ID = Int32.Parse(reader["ID"].ToString());
					productCostHistory.ProductID = Int32.Parse(reader["ProductID"].ToString());
					productCostHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
					productCostHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
					productCostHistory.StandardCost= Decimal.Parse(reader["StandardCost"].ToString());
					productCostHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetProductCostHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return productCostHistory;
		}
		public DataSet GetProductCostHistoryDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductInventoriesDynamic");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetProductCostHistoryDynamicDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductCostHistoryCollection GetAllProductCostHistorysDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			ProductCostHistoryCollection cols = new ProductCostHistoryCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductInventoriesDynamic");
				while (reader.Read())
				{
					ProductCostHistory productCostHistory = new ProductCostHistory();
					productCostHistory.ProductID = Int32.Parse(reader["ProductID"].ToString());
					productCostHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
					productCostHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
					productCostHistory.StandardCost= Decimal.Parse(reader["StandardCost"].ToString());
					productCostHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
					cols.Add(productCostHistory);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductCostHistorysDynamicCollection");
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
