using System;
using System.Collections.Generic;
using System.Text;
using MICS.Utilities;
using MICS.BLL;
using System.Data;
namespace MICS.DAL
{
    class productData
    {
         LogWriter log = new LogWriter();
        public productData()
        {
        }
        public bool UpdateProduct(Product product)
        {
            if (product.Description == String.Empty || product.Description == null)
            {
                product.Description = product.Name;
            }
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(29);
                dbm.AddParameters(0, "@ProductID", product.ProductID);
                dbm.AddParameters(1, "@Name", product.Name);
                dbm.AddParameters(2, "@Description", product.Description);
                dbm.AddParameters(3, "@ProductNumber", product.ProductNumber);
                dbm.AddParameters(4, "@MakeFlag", product.MakeFlag);
                dbm.AddParameters(5, "@FinishedGoodsFlag", product.FinishedGoodsFlag);
                dbm.AddParameters(6, "@Color", product.Color);
                dbm.AddParameters(7, "@SafetyStockLevel", product.SafetyStockLevel);
                dbm.AddParameters(8, "@ReorderPoint", product.ReorderPoint);
                dbm.AddParameters(9, "@StandardCost", product.StandardCost);
                dbm.AddParameters(10, "@ListPrice", product.ListPrice);
                dbm.AddParameters(11, "@Size", product.Size);
                dbm.AddParameters(12, "@SizeUnitMeasureCode", product.SizeUnitMeasureCode);
                dbm.AddParameters(13, "@WeightUnitMeasureCode", product.WeightUnitMeasureCode);
                dbm.AddParameters(14, "@Weight", product.Weight);
                dbm.AddParameters(15, "@DaysToManufacture", product.DaysToManufacture);
                dbm.AddParameters(16, "@ProductLine", product.ProductLine);
                dbm.AddParameters(17, "@Class", product.Class);
                dbm.AddParameters(18, "@Style", product.Style);
                dbm.AddParameters(19, "@ProductSubcategoryID", product.ProductSubcategoryID);
                dbm.AddParameters(20, "@ProductModelID", product.ProductModelID);
                dbm.AddParameters(21, "@SellStartDate", product.SellStartDate);
                dbm.AddParameters(22, "@SellEndDate", product.SellEndDate);
                dbm.AddParameters(23, "@DiscontinuedDate", product.DiscontinuedDate);
                dbm.AddParameters(24, "@ModifiedDate", product.ModifiedDate);
                dbm.AddParameters(25, "@PrimaryVendorId", product.PrimaryVendorId);
                dbm.AddParameters(26, "@SecondaryVendorId", product.SecondaryVendorId);
                dbm.AddParameters(27, "@ActiveFlag", product.ActiveFlag);
                dbm.AddParameters(28, "@Comments", product.Comments);
                

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProduct");


            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteProduct(int productID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ProductID", productID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProduct");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteProduct");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteProduct(Product product)
        {
            return (DeleteProduct(product.ProductID));
        }
        public int AddProduct(Product product)
        {
            if (product.Description == String.Empty || product.Description == null)
            {
                product.Description = product.Name;
            }
            IDBManager dbm = new DBManager();
            int id=0;
            try
            {
                 dbm.CreateParameters(29);
                
                dbm.AddParameters(0, "@Name", product.Name);
                dbm.AddParameters(1, "@Description", product.Description);
                dbm.AddParameters(2, "@ProductNumber", product.ProductNumber);
                dbm.AddParameters(3, "@MakeFlag", product.MakeFlag);
                dbm.AddParameters(4, "@FinishedGoodsFlag", product.FinishedGoodsFlag);
                dbm.AddParameters(5, "@Color", product.Color);
                dbm.AddParameters(6, "@SafetyStockLevel", product.SafetyStockLevel);
                dbm.AddParameters(7, "@ReorderPoint", product.ReorderPoint);
                dbm.AddParameters(8, "@StandardCost", product.StandardCost);
                dbm.AddParameters(9, "@ListPrice", product.ListPrice);
                dbm.AddParameters(10, "@Size", product.Size);
                dbm.AddParameters(11, "@SizeUnitMeasureCode", product.SizeUnitMeasureCode);
                dbm.AddParameters(12, "@WeightUnitMeasureCode", product.WeightUnitMeasureCode);
                dbm.AddParameters(13, "@Weight", product.Weight);
                dbm.AddParameters(14, "@DaysToManufacture", product.DaysToManufacture);
                dbm.AddParameters(15, "@ProductLine", product.ProductLine);
                dbm.AddParameters(16, "@Class", product.Class);
                dbm.AddParameters(17, "@Style", product.Style);
                dbm.AddParameters(18, "@ProductSubcategoryID", product.ProductSubcategoryID);
                dbm.AddParameters(19, "@ProductModelID", product.ProductModelID);
                dbm.AddParameters(20, "@SellStartDate", product.SellStartDate);
                dbm.AddParameters(21, "@SellEndDate", product.SellEndDate);
                dbm.AddParameters(22, "@DiscontinuedDate", product.DiscontinuedDate);
                dbm.AddParameters(23, "@ModifiedDate", product.ModifiedDate);
                dbm.AddParameters(24, "@ProductID", product.ProductID);
                dbm.AddParameters(25, "@PrimaryVendorId", product.PrimaryVendorId);
                dbm.AddParameters(26, "@SecondaryVendorId", product.SecondaryVendorId);
                dbm.AddParameters(27, "@ActiveFlag", product.ActiveFlag);
                dbm.AddParameters(28, "@Comments", product.Comments);
                dbm.Parameters[24].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertProduct");
                id= Int32.Parse(dbm.Parameters[24].Value.ToString());
                ProductInventory pi = new ProductInventory();
                pi = product.ProductInventory;
                pi.ProductID = id;
                pi.AddProductInventory(pi);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProduct");
                return -1;
            }
            finally
            {
                dbm.Dispose();
            }
            return id;
        }
        public int Exists(string name,string description)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@Name", name);
                dbm.AddParameters(1, "@Description", description);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductExists");
                if (reader.Read())
                {
                    return Int32.Parse(reader["ProductID"].ToString());
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
        public DataSet GetAllProductsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public DataSet GetProductsWithVendorsDataSet()
        {
            DataSet ds = new DataSet();
            string sql = "select p.*,";
                   sql +="(select c.name from productcategory c";
                   sql += " join productsubcategory s on s.productcategoryid=c.productcategoryid";
                   sql += " where s.productsubcategoryid=p.productsubcategoryid) Category,";
                   sql += " (select s.name from productsubcategory s where s.productsubcategoryid=p.productsubcategoryid) SubCategory,";
                   sql += " (select v.name from vendor v where v.vendorid=p.primaryvendorid) PrimaryVendor,";
                   sql += " (select v.name from vendor v where v.vendorid=p.secondaryvendorid) SecondaryVendor";
                   sql += " from product p Order by p.name";
            GenericQuery q = new GenericQuery();
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
        public Product ReaderToProduct(IDataReader reader, Product product)
        {
            product.ProductID = Int32.Parse(reader["ProductID"].ToString());
            product.Name = reader["Name"].ToString();
            product.Description = reader["Description"].ToString();
            product.ProductNumber = reader["ProductNumber"].ToString();
            product.MakeFlag = Boolean.Parse(reader["MakeFlag"].ToString());
            product.FinishedGoodsFlag = Boolean.Parse(reader["FinishedGoodsFlag"].ToString());
            product.Color = reader["Color"].ToString();
            product.SafetyStockLevel = Int16.Parse(reader["SafetyStockLevel"].ToString());
            product.ReorderPoint = Int16.Parse(reader["ReorderPoint"].ToString());
            product.StandardCost = Decimal.Parse(reader["StandardCost"].ToString());
            product.ListPrice = Decimal.Parse(reader["ListPrice"].ToString());
            product.Size = reader["Size"].ToString();
            product.SizeUnitMeasureCode = reader["SizeUnitMeasureCode"].ToString();
            product.WeightUnitMeasureCode = reader["WeightUnitMeasureCode"].ToString();
            product.Weight = Decimal.Parse(reader["Weight"].ToString());
            product.DaysToManufacture = Int32.Parse(reader["DaysToManufacture"].ToString());
            product.ProductLine = reader["ProductLine"].ToString();
            product.Class = reader["Class"].ToString();
            product.Style = reader["Style"].ToString();
            product.ProductSubcategoryID = Int32.Parse(reader["ProductSubcategoryID"].ToString());
            product.ProductModelID = Int32.Parse(reader["ProductModelID"].ToString());
            product.SellStartDate = DateTime.Parse(reader["SellStartDate"].ToString());
            product.SellEndDate = DateTime.Parse(reader["SellEndDate"].ToString());
            product.DiscontinuedDate = DateTime.Parse(reader["DiscontinuedDate"].ToString());
            product.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
            if (reader["PrimaryVendorId"] != DBNull.Value)
                product.PrimaryVendorId = Int32.Parse(reader["PrimaryVendorId"].ToString());
            if (reader["SecondaryVendorId"] != DBNull.Value)
                product.SecondaryVendorId = Int32.Parse(reader["SecondaryVendorId"].ToString());
            if (reader["ActiveFlag"] != DBNull.Value)
                product.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
            else
                product.ActiveFlag = false;
            product.Comments = reader["Comments"].ToString();
                    
            return product;
        }
        public ProductCollection GetAllProductsCollection()
        {
            IDBManager dbm = new DBManager();
            IDataReader reader = null;
            ProductCollection cols = new ProductCollection();

            try
            {
                reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductsAll");
                while (reader.Read())
                {
                    Product product = new Product();
                    product = ReaderToProduct(reader, product);
                    cols.Add(product);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductsCollection");
                throw (ex);
            }
            finally
            {
                if(reader != null)
                    reader.Close();

                dbm.Dispose();
            }
            return cols;
        }

        public Product GetProduct(int productID)
        {
            IDBManager dbm = new DBManager();
            IDataReader reader = null;
            Product product = new Product();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0,"@ProductID",productID);
                reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProduct");
                while (reader.Read())
                {
                    product = ReaderToProduct(reader, product);
                    /*product.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    product.Name = reader["Name"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.ProductNumber = reader["ProductNumber"].ToString();
                    product.MakeFlag =Boolean.Parse(reader["MakeFlag"].ToString());
                    product.FinishedGoodsFlag = Boolean.Parse(reader["FinishedGoodsFlag"].ToString());
                    product.Color = reader["Color"].ToString();
                    product.SafetyStockLevel = 0;// Int16.Parse(reader["SafetyStockLevel"].ToString());
                    product.ReorderPoint = Int16.Parse(reader["ReorderPoint"].ToString());
                    product.StandardCost = Decimal.Parse(reader["StandardCost"].ToString());
                    product.ListPrice =Decimal.Parse(reader["ListPrice"].ToString());
                    product.Size = reader["Size"].ToString();
                    product.SizeUnitMeasureCode = reader["SizeUnitMeasureCode"].ToString();
                    product.WeightUnitMeasureCode = reader["WeightUnitMeasureCode"].ToString();
                    product.Weight = 0; // Decimal.Parse(reader[""].ToString());
                    product.DaysToManufacture = 0; // Int32.Parse(reader["DaysToManufacture"].ToString());
                    product.ProductLine = reader["ProductLine"].ToString();
                    product.Class = reader["Class"].ToString();
                    product.Style = reader["Style"].ToString();
                    product.ProductSubcategoryID = Int32.Parse(reader["ProductSubcategoryID"].ToString());
                    product.ProductModelID = 0;// Int32.Parse(reader["ProductModelID"].ToString());
                    product.SellStartDate = DateTime.Parse(reader["SellStartDate"].ToString());
                    product.SellEndDate= DateTime.Parse(reader["SellEndDate"].ToString());
                    product.DiscontinuedDate= DateTime.Parse(reader["DiscontinuedDate"].ToString());
                    product.ModifiedDate= DateTime.Parse(reader["ModifiedDate"].ToString());
                    if (reader["PrimaryVendorId"] != DBNull.Value)
                        product.PrimaryVendorId = Int32.Parse(reader["PrimaryVendorId"].ToString());
                    else
                        product.PrimaryVendorId = 0;
                    if (reader["SecondaryVendorId"] != DBNull.Value)
                        product.SecondaryVendorId = Int32.Parse(reader["SecondaryVendorId"].ToString());
                    else
                        product.SecondaryVendorId = 0;
                    if (reader["ActiveFlag"] != DBNull.Value)
                        product.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                    else
                        product.ActiveFlag = false;
                    product.Comments = reader["Comments"].ToString(); */
                    
                    
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProduct");
                throw (ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                dbm.Dispose();
            }
            return product;
        }
        public DataSet GetProductDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectProductsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductDynamicDataSet");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public ProductCollection GetProductDynamicCollection(string whereExpression,string orderBy)
        {
            IDBManager dbm = new DBManager();
            IDataReader reader = null;
            ProductCollection cols = new ProductCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                
                reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectProductsDynamic");
                while (reader.Read())
                {
                    Product product = new Product();
                    product = ReaderToProduct(reader, product);
                    cols.Add(product);
                    
                    /*product.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    product.Name = reader["Name"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.ProductNumber = reader["ProductNumber"].ToString();
                    product.MakeFlag = Boolean.Parse(reader["MakeFlag"].ToString());
                    product.FinishedGoodsFlag = Boolean.Parse(reader["FinishedGoodsFlag"].ToString());
                    product.Color = reader["Color"].ToString();
                    product.SafetyStockLevel = Int16.Parse(reader["SafetyStockLevel"].ToString());
                    product.ReorderPoint = Int16.Parse(reader["ReorderPoint"].ToString());
                    product.StandardCost = Decimal.Parse(reader["StandardCost"].ToString());
                    product.ListPrice =Decimal.Parse(reader["ListPrice"].ToString());
                    product.Size = reader["Size"].ToString();
                    product.SizeUnitMeasureCode = reader["SizeUnitMeasureCode"].ToString();
                    product.WeightUnitMeasureCode = reader["WeightUnitMeasureCode"].ToString();
                    product.Weight = Decimal.Parse(reader["Weight"].ToString());
                    product.DaysToManufacture = Int32.Parse(reader["DaysToManufacture"].ToString());
                    product.ProductLine = reader["ProductLine"].ToString();
                    product.Class = reader["Class"].ToString();
                    product.Style = reader["Style"].ToString();
                    product.ProductSubcategoryID = Int32.Parse(reader["ProductSubcategoryID"].ToString());
                    product.ProductModelID = Int32.Parse(reader["ProductModelID"].ToString());
                    product.SellStartDate = DateTime.Parse(reader["SellStartDate"].ToString());
                    product.SellEndDate= DateTime.Parse(reader["SellEndDate"].ToString());
                    product.DiscontinuedDate= DateTime.Parse(reader["DiscontinuedDate"].ToString());
                    product.ModifiedDate= DateTime.Parse(reader["ModifiedDate"].ToString());
                    product.PrimaryVendorId = Int32.Parse(reader["PrimaryVendorId"].ToString());
                    product.SecondaryVendorId = Int32.Parse(reader["SecondaryVendorId"].ToString());
                    product.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                    product.Comments = reader["Comments"].ToString();
                    
                    cols.Add(product);*/
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductDynamicCollection");
                throw (ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                dbm.Dispose();
            }
            return cols;

        }
    }
    
}
