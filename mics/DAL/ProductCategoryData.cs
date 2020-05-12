using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class ProductCategoryData
    {
        LogWriter log = new LogWriter();
        public ProductCategoryData()
        {
        }
        public bool UpdateProductCategory(ProductCategory productCategory)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@ProductCategoryID", productCategory.ProductCategoryID);
                dbm.AddParameters(1, "@Name", productCategory.Name);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProductCategory");


            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductCategory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteProductCategory(int productCategoryID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductCategoryID", productCategoryID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProductCategory");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteProductCategory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteProductCategory(ProductCategory productCategory)
        {
           return (DeleteProductCategory(productCategory.ProductCategoryID));
        }
        public int AddProductCategory(ProductCategory productCategory)
        {
            IDBManager dbm = new DBManager();
            int productCategoryID = 0;
            try
            {
                dbm.CreateParameters(3);
                dbm.AddParameters(0, "@Name", productCategory.Name);
                dbm.AddParameters(1, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(2, "@ProductCategoryID", productCategoryID);
                dbm.Parameters[2].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProductCategory");
                productCategoryID = Int32.Parse(dbm.Parameters[2].Value.ToString());

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductCategory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return productCategoryID;
        }
        public DataSet GetAllProductCategoryDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductCategoriesAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCategoryDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public ProductCategoryCollection GetAllProductCategorysCollection()
        {
            IDBManager dbm = new DBManager();
            ProductCategoryCollection cols = new ProductCategoryCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCategoriesAll");
                while (reader.Read())
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
                    productCategory.Name = reader["Name"].ToString();
                    productCategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productCategory);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCategorysCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public int Exists(string name)
        {
            IDBManager dbm = new DBManager();
            
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@Name", name);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCategoryExists");
                if (reader.Read())
                {
                  return Int32.Parse(reader["ProductCategoryID"].ToString());
                }
                else
                {
                    return 0;
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "Exists");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
         
        }
        public ProductCategory GetProductCategory(int productCategoryID)
        {
            IDBManager dbm = new DBManager();
            ProductCategory productCategory = new ProductCategory();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0,"@ProductCategoryID",productCategoryID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCategory");
                while (reader.Read())
                {
                    productCategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
                    productCategory.Name = reader["Name"].ToString();
                    productCategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCategory");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return productCategory;
        }
        
        public ProductCategoryCollection GetProductCategorysDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            ProductCategoryCollection cols = new ProductCategoryCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductCategoriesDynamic");
                while (reader.Read())
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.ProductCategoryID = Int32.Parse(reader["ProductCategoryID"].ToString());
                    productCategory.Name = reader["Name"].ToString();
                    productCategory.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(productCategory);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCategorysDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public DataSet GetProductCategorysDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductCategoriesDynamic");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCategorysDynamicDataSet");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
    }
}
