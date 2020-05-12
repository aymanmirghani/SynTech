using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class ProductVendorData
    {
        		LogWriter log = new LogWriter();
        public ProductVendorData()
		{
			
		}
        public bool UpdateProductVendor(ProductVendor productVendor)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(12);
                dbm.AddParameters(0, "@ID", productVendor.ProductID);
                dbm.AddParameters(1, "@ProductID", productVendor.ProductID);
                dbm.AddParameters(2, "@VendorID", productVendor.VendorID);
                dbm.AddParameters(3, "@AverageLeadTime", productVendor.AverageLeadTime);
                dbm.AddParameters(4, "@StandardPrice", productVendor.StandardPrice);
                dbm.AddParameters(5, "@LastReceiptCost", productVendor.LastReceiptCost);
                dbm.AddParameters(6, "@LastReceiptDate", productVendor.LastReceiptDate);
                dbm.AddParameters(7, "@MinOrderQty", productVendor.MinOrderQty);
                dbm.AddParameters(8, "@MaxOrderQty", productVendor.MaxOrderQty);
                dbm.AddParameters(9, "@OnOrderQty", productVendor.OnOrderQty);
                dbm.AddParameters(10, "@UnitMeasureCode", productVendor.UnitMeasureCode);
                dbm.AddParameters(11, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductVendor");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdateProductVendor");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeleteProductVendor(int ID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ID", ID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductVendor");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeleteProductVendor");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
        public bool DeleteProductVendor(ProductVendor productVendor)
		{
            return (DeleteProductVendor(productVendor.ID));
		}
        public bool AddProductVendor(ProductVendor productVendor)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(11);
                dbm.AddParameters(0, "@ProductID", productVendor.ProductID);
                dbm.AddParameters(1, "@VendorID", productVendor.VendorID);
                dbm.AddParameters(2, "@AverageLeadTime", productVendor.AverageLeadTime);
                dbm.AddParameters(3, "@StandardPrice", productVendor.StandardPrice);
                dbm.AddParameters(4, "@LastReceiptCost", productVendor.LastReceiptCost);
                dbm.AddParameters(5, "@LastReceiptDate", productVendor.LastReceiptDate);
                dbm.AddParameters(6, "@MinOrderQty", productVendor.MinOrderQty);
                dbm.AddParameters(7, "@MaxOrderQty", productVendor.MaxOrderQty);
                dbm.AddParameters(8, "@OnOrderQty", productVendor.OnOrderQty);
                dbm.AddParameters(9, "@UnitMeasureCode", productVendor.UnitMeasureCode);
                dbm.AddParameters(10, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductVendor");


			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddProductVendor");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public DataSet GetAllProductVendorDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductInventoriesAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllProductVendorDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductVendorCollection GetAllProductVendorCollection()
		{
			IDBManager dbm = new DBManager();
			ProductVendorCollection cols = new ProductVendorCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductInventoriesAll");
				while (reader.Read())
				{
                    ProductVendor productVendor = new ProductVendor();
                    productVendor.ID = Int32.Parse(reader["ID"].ToString());
                    productVendor.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productVendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    productVendor.AverageLeadTime = Int32.Parse(reader["AverageLeadTime"].ToString());
                    productVendor.StandardPrice= Decimal.Parse(reader["StandardCost"].ToString());
                    productVendor.LastReceiptCost = Decimal.Parse(reader["LastReceiptCost"].ToString());
                    productVendor.LastReceiptDate = DateTime.Parse(reader["LastReceiptDate"].ToString());
                    productVendor.MinOrderQty = Int32.Parse(reader["MinOrderQty"].ToString());
                    productVendor.MaxOrderQty = Int32.Parse(reader["MaxOrderQty"].ToString());
                    productVendor.OnOrderQty = Int32.Parse(reader["OnOrderQty"].ToString());
                    productVendor.UnitMeasureCode= reader["LastReceiptCost"].ToString();
                    productVendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productVendor);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductVendorCollection");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public ProductVendor GetProductVendor(int productID)
		{
			IDBManager dbm = new DBManager();
            ProductVendor productVendor = new ProductVendor();

			try
			{
				dbm.CreateParameters(1);
				dbm.AddParameters(0, "@ProductID", productID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductVendor");
				while (reader.Read())
				{
                    productVendor.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productVendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    productVendor.AverageLeadTime = Int32.Parse(reader["AverageLeadTime"].ToString());
                    productVendor.StandardPrice = Decimal.Parse(reader["StandardCost"].ToString());
                    productVendor.LastReceiptCost = Decimal.Parse(reader["LastReceiptCost"].ToString());
                    productVendor.LastReceiptDate = DateTime.Parse(reader["LastReceiptDate"].ToString());
                    productVendor.MinOrderQty = Int32.Parse(reader["MinOrderQty"].ToString());
                    productVendor.MaxOrderQty = Int32.Parse(reader["MaxOrderQty"].ToString());
                    productVendor.OnOrderQty = Int32.Parse(reader["OnOrderQty"].ToString());
                    productVendor.UnitMeasureCode = reader["LastReceiptCost"].ToString();
                    productVendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetProductVendor");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return productVendor;
		}
		public DataSet GetProductVendorDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductVendorsDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductVendorDynamicDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductVendorCollection GetAllProductVendorDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			ProductVendorCollection cols = new ProductVendorCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductVendorsDynamic");
				while (reader.Read())
				{
                    ProductVendor productVendor = new ProductVendor();
                    productVendor.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    productVendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    productVendor.AverageLeadTime = Int32.Parse(reader["AverageLeadTime"].ToString());
                    productVendor.StandardPrice = Decimal.Parse(reader["StandardCost"].ToString());
                    productVendor.LastReceiptCost = Decimal.Parse(reader["LastReceiptCost"].ToString());
                    productVendor.LastReceiptDate = DateTime.Parse(reader["LastReceiptDate"].ToString());
                    productVendor.MinOrderQty = Int32.Parse(reader["MinOrderQty"].ToString());
                    productVendor.MaxOrderQty = Int32.Parse(reader["MaxOrderQty"].ToString());
                    productVendor.OnOrderQty = Int32.Parse(reader["OnOrderQty"].ToString());
                    productVendor.UnitMeasureCode = reader["LastReceiptCost"].ToString();
                    productVendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productVendor);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductVendorDynamicCollection");
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
