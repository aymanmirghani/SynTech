using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
	/// <summary>
	/// Summary description for ProductInventoryData.
	/// </summary>
	public class ProductInventoryData
	{
		LogWriter log = new LogWriter();
		public ProductInventoryData()
		{
			
		}
		public bool UpdateProductInventory(ProductInventory productInventory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(6);
				dbm.AddParameters(0, "@ProductID", productInventory.ProductID);
				dbm.AddParameters(1, "@LocationID", productInventory.LocationID);
				dbm.AddParameters(2, "@Shelf", productInventory.Shelf);
				dbm.AddParameters(3, "@Bin", productInventory.Bin);
				dbm.AddParameters(4, "@Quantity", productInventory.Quantity);
				dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductInventory");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdateProductInventory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
        public bool UpdateInventory(ProductInventory productInventory)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@ProductID", productInventory.ProductID);
                dbm.AddParameters(1, "@Quantity", productInventory.Quantity);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateInventory");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateInventory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
		public bool DeleteProductInventory(int productID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ProductID", productID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductCostHistory");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeleteProductInventory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
		public bool DeleteProductInventory(ProductInventory productInventory)
		{
			return(DeleteProductInventory(productInventory.ProductID));
		}
		public bool AddProductInventory(ProductInventory productInventory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(6);
                dbm.AddParameters(0, "@ProductID", productInventory.ProductID);
                dbm.AddParameters(1, "@LocationID", productInventory.LocationID);
                dbm.AddParameters(2, "@Shelf", productInventory.Shelf);
                dbm.AddParameters(3, "@Bin", productInventory.Bin);
                dbm.AddParameters(4, "@Quantity", productInventory.Quantity);
				dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductInventory");

			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddProductInventory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public DataSet GetAllProductInventoryDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductInventoriesAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductInventoryDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductInventoryCollection GetAllProductInventorysCollection()
		{
			IDBManager dbm = new DBManager();
			ProductInventoryCollection cols = new ProductInventoryCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductInventoriesAll");
				while (reader.Read())
				{
					ProductInventory productInventory = new ProductInventory();
					productInventory.ProductID= Int32.Parse(reader["ProductID"].ToString());
					productInventory.LocationID = Int32.Parse(reader["LocationID"].ToString());
					productInventory.Shelf = reader["Shelf"].ToString();
					productInventory.Quantity = Int16.Parse(reader["Quantity"].ToString());
					productInventory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
					cols.Add(productInventory);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "ProductInventoryCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public ProductInventory GetProductInventory(int productID)
		{
			IDBManager dbm = new DBManager();
			ProductInventory productInventory = new ProductInventory();

			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ProductID", productID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductInventory");
				while (reader.Read())
				{
					productInventory.ProductID= Int32.Parse(reader["ProductID"].ToString());
                    if(reader["LocationID"] != DBNull.Value)
					    productInventory.LocationID = Int32.Parse(reader["LocationID"].ToString());
                    if(reader["Shelf"] != DBNull.Value)
					    productInventory.Shelf = reader["Shelf"].ToString();
                    if(reader["Quantity"] != DBNull.Value)
					    productInventory.Quantity = Int16.Parse(reader["Quantity"].ToString());
					productInventory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetProductInventory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return productInventory;
		}
		public DataSet GetProductInventoryDynamicDataSet(string whereExpression, string orderBy)
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
				log.Write(ex.Message, "GetProductInventoryDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductInventoryCollection GetAllProductInventorysDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			ProductInventoryCollection cols = new ProductInventoryCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductInventoriesDynamic");
				while (reader.Read())
				{
					ProductInventory productInventory = new ProductInventory();
					productInventory.ProductID= Int32.Parse(reader["ProductID"].ToString());
					productInventory.LocationID = Int32.Parse(reader["LocationID"].ToString());
					productInventory.Shelf = reader["Shelf"].ToString();
                    productInventory.Bin = Byte.Parse(reader["Bin"].ToString());
					productInventory.Quantity = Int16.Parse(reader["Quantity"].ToString());
					productInventory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
					cols.Add(productInventory);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductInventorysDynamicCollection");
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
