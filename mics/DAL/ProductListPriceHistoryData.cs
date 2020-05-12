using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;
namespace MICS.DAL
{
	/// <summary>
	/// Summary description for ProductListPriceHistory.
	/// </summary>
	public class ProductListPriceHistoryData
	{
		LogWriter log = new LogWriter();
		public ProductListPriceHistoryData()
		{
			
		}

        public bool UpdateProductListPriceHistory(ProductListPriceHistory productListPriceHistory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(6);
                dbm.AddParameters(0, "@ID", productListPriceHistory.ID);
				dbm.AddParameters(1, "@ProductID", productListPriceHistory.ProductID);
                dbm.AddParameters(2, "@StartDate", productListPriceHistory.StartDate);
                dbm.AddParameters(3, "@EndDate", productListPriceHistory.EndDate);
                dbm.AddParameters(4, "@ListPrice", productListPriceHistory.ListPrice);
				dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductListPriceHistory");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "UpdateProductListPriceHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeleteProductListPriceHistory(int id)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ID", id);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductListPriceHistory");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "DeleteProductListPriceHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
        public bool DeleteProductListPriceHistory(ProductListPriceHistory productListPriceHistory)
		{
            return (DeleteProductListPriceHistory(productListPriceHistory.ID));
		}
        public int AddProductListPriceHistory(ProductListPriceHistory productListPriceHistory)
		{
			IDBManager dbm = new DBManager();

			try
			{
				dbm.CreateParameters(6);
                dbm.AddParameters(0, "@ID", productListPriceHistory.ID);
                dbm.AddParameters(1, "@ProductID", productListPriceHistory.ProductID);
                dbm.AddParameters(2, "@StartDate", productListPriceHistory.StartDate);
                dbm.AddParameters(3, "@EndDate", productListPriceHistory.EndDate);
                dbm.AddParameters(4, "@ListPrice", productListPriceHistory.ListPrice);
				dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.Parameters[0].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductListPriceHistory");
                productListPriceHistory.ID = Int32.Parse(dbm.Parameters[0].Value.ToString());
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddProductListPriceHistory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return productListPriceHistory.ID;
		}
		public DataSet GetAllProductListPriceHistoryDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductListPriceHistoriesAll");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductListPriceHistoryDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductListPriceHistoryCollection GetAllProductListPriceHistoryCollection()
		{
			IDBManager dbm = new DBManager();
			ProductListPriceHistoryCollection cols = new ProductListPriceHistoryCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductListPriceHistoriesAll");
				while (reader.Read())
				{
                    ProductListPriceHistory productListPriceHistory = new ProductListPriceHistory();
                    productListPriceHistory.ID = Int32.Parse(reader["ID"].ToString());
                    productListPriceHistory.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productListPriceHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    productListPriceHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    productListPriceHistory.ListPrice = Decimal.Parse(reader["ListPrice"].ToString());
                    productListPriceHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productListPriceHistory);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductListPriceHistoryCollection");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public ProductListPriceHistory GetProductListPriceHistory(int id)
		{
			IDBManager dbm = new DBManager();
            ProductListPriceHistory productListPriceHistory = new ProductListPriceHistory();

			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ID", id);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductListPriceHistory");
				while (reader.Read())
				{
                    productListPriceHistory.ID = Int32.Parse(reader["ID"].ToString());
                    productListPriceHistory.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productListPriceHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    productListPriceHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    productListPriceHistory.ListPrice = Decimal.Parse(reader["ListPrice"].ToString());
                    productListPriceHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductListPriceHistory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return productListPriceHistory;
		}
		public DataSet GetProductListPriceHistoryDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductListPriceHistoriesDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductListPriceHistoryDynamicDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductListPriceHistoryCollection GetAllProductListPriceHistorysDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			ProductListPriceHistoryCollection cols = new ProductListPriceHistoryCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductListPriceHistoriesDynamic");
				while (reader.Read())
				{
                    ProductListPriceHistory productListPriceHistory = new ProductListPriceHistory();
                    productListPriceHistory.ID = Int32.Parse(reader["ID"].ToString());
                    productListPriceHistory.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productListPriceHistory.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    productListPriceHistory.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    productListPriceHistory.ListPrice = Decimal.Parse(reader["ListPrice"].ToString());
                    productListPriceHistory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productListPriceHistory);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductListPriceHistorysDynamicCollection");
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
