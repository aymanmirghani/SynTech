using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;
namespace MICS.DAL
{
    class ProductSubcategoryData
    {
        LogWriter log = new LogWriter();
        public ProductSubcategoryData(){}
        public bool UpdateProductSubcategory(ProductSubcategory productSubcategory)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(4);
                dbm.AddParameters(0, "@ProductSubcategoryID", productSubcategory.ProductSubcategoryID);
                dbm.AddParameters(1, "@ProductCategoryID", productSubcategory.ProductCategoryID);
                dbm.AddParameters(2, "@Name", productSubcategory.Name);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductSubcategory");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "UpdateProductSubcategory");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeleteProductSubcategory(int productSubCategoryID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductSubcategoryID", productSubCategoryID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductSubcategory");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "DeleteProductSubcategory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
        public bool DeleteProductSubcategory(ProductSubcategory productSubcategory)
		{
            return (DeleteProductSubcategory(productSubcategory.ProductSubcategoryID));
		}
        public int AddProductSubcategory(ProductSubcategory productSubcategory)
		{
			IDBManager dbm = new DBManager();
            int id = 0;
			try
			{
				dbm.CreateParameters(4);
                dbm.AddParameters(0, "@ProductCategoryID", productSubcategory.ProductCategoryID);
                dbm.AddParameters(1, "@Name", productSubcategory.Name);
				dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(3, "@ProductSubcategoryID", productSubcategory.ProductSubcategoryID);
                dbm.Parameters[3].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductSubcategory");
                id= Int32.Parse(dbm.Parameters[3].Value.ToString());
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddProductSubcategory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return id;
		}
		public DataSet GetAllProductSubcategoryDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductSubcategoriesAll");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductSubcategoryDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductSubcategoryCollection GetAllProductSubcategoryCollection()
		{
			IDBManager dbm = new DBManager();
			ProductSubcategoryCollection cols = new ProductSubcategoryCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductSubcategoriesAll");
				while (reader.Read())
				{
                    ProductSubcategory productSubcategory = new ProductSubcategory();
                    productSubcategory.ProductSubcategoryID = Int32.Parse(reader["ProductSubcategoryID"].ToString());
                    productSubcategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
                    productSubcategory.Name = reader["Name"].ToString();
                    productSubcategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productSubcategory);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductSubcategoryCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
        public ProductSubcategory GetProductSubcategory(int productSubcategoryID)
		{
			IDBManager dbm = new DBManager();
            ProductSubcategory productSubcategory = new ProductSubcategory();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductSubcategoryID", productSubcategoryID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductSubcategory");
				while (reader.Read())
				{
                    productSubcategory.ProductSubcategoryID = Int32.Parse(reader["ProductSubcategoryID"].ToString());
                    productSubcategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
                    productSubcategory.Name = reader["Name"].ToString();
                    productSubcategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductSubcategory");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return productSubcategory;
		}
        public int Exists(string name, int categroyID)
        {
            IDBManager dbm = new DBManager();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@Name", name);
                dbm.AddParameters(1, "@ProductCategoryID", categroyID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductSubcategoryExists");
                if (reader.Read())
                {
                    return (Int32.Parse(reader["ProductCategoryID"].ToString()));
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductSubcategory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            
        }
		public DataSet GetProductSubcategoryDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductSubcategoriesDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetProductSubcategoryDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public ProductSubcategoryCollection GetAllProductSubcategoryDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			ProductSubcategoryCollection cols = new ProductSubcategoryCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductSubcategoriesDynamic");
				while (reader.Read())
				{
					ProductSubcategory productSubcategory = new ProductSubcategory();
					productSubcategory.ProductSubcategoryID= Int32.Parse(reader["ProductSubcategoryID"].ToString());
					productSubcategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
					productSubcategory.Name = reader["Name"].ToString();
                    productSubcategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productSubcategory);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllProductSubcategoryDynamicCollection");
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
