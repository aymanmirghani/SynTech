using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductCategory{
        LogWriter log = new LogWriter();
        //ProductCategoryData data = new ProductCategoryData();

		public ProductCategory(){}
		public ProductCategory(
					System.Int32 productcategoryid,
					System.String name,
					System.DateTime modifieddate
		){
		this._ProductCategoryID = productcategoryid;
		this._Name = name;
		this._ModifiedDate = modifieddate;
		}
			private System.Int32 _ProductCategoryID;
			private System.String _Name;
			private System.DateTime _ModifiedDate;
		public System.Int32 ProductCategoryID{
			get{return _ProductCategoryID;}
			set{ _ProductCategoryID=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddProductCategory(ProductCategory productcategory)
        {
            ProductCategoryData data = new ProductCategoryData();
            int productCateogryID = 0;
            try
            {
                productCateogryID = data.AddProductCategory(productcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductCategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productCateogryID;
        }
		public bool RemoveProductCategory(ProductCategory productcategory)
        {
            ProductCategoryData data = new ProductCategoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductCategory(productcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductCategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveProductCategory(int productcategoryID)
        {
            ProductCategoryData data = new ProductCategoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductCategory(productcategoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductCategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateProductCategory(ProductCategory productcategory)
        {
            ProductCategoryData data = new ProductCategoryData();
            bool ret = false;
            try
            {
                ret = data.UpdateProductCategory(productcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductCategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public ProductCategory GetProductCategory(int productCategoryID)
        {
            ProductCategoryData data = new ProductCategoryData();
            ProductCategory productCategory = new ProductCategory();
            try
            {
                productCategory = data.GetProductCategory(productCategoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productCategory;
        }
        public int Exists(string name)
        {
            ProductCategoryData data = new ProductCategoryData();
            try
            {
                return (data.Exists(name));
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exists");
                throw (ex);
            }
            finally
            {
                data = null;
            }
        }
        public DataSet GetAllProductCategoryDataSet()
        {
            ProductCategoryData data = new ProductCategoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductCategoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCategoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCategoryCollection GetAllProductCategoryCollection()
        {
            ProductCategoryData data = new ProductCategoryData();
            ProductCategoryCollection col = new ProductCategoryCollection();
            try
            {
                col = data.GetAllProductCategorysCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCategoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductCategoryDataSet(string whereExpression, string orderByExpression)
        {
            ProductCategoryData data = new ProductCategoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductCategorysDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCategoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCategoryCollection GetProductCategoryCollection(string whereExpression, string orderByExpression)
        {
            ProductCategoryData data = new ProductCategoryData();
            ProductCategoryCollection col = new ProductCategoryCollection();
            try
            {
                col = data.GetProductCategorysDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCategoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public bool Exsists(string categoryName)
        {
           // ProductCategoryData data = new ProductCategoryData();
            string where = "[Name]='" + categoryName + "'";
            string orderBy = String.Empty;
            ProductCategoryCollection col = new ProductCategoryCollection();
            try
            {
                col = GetProductCategoryCollection(where, orderBy);
                if (col.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exsists");
                throw (ex);
            }
            finally
            {
                col = null;
                
            }
            

        }

        public string GetCategoryNameBySubCategory(int SubCategoryID)
        {
            string CatName = "";
            ProductCategoryData data = new ProductCategoryData();

            string where = "productcategoryid in (select productcategoryid from productsubcategory where productsubcategoryid=" + SubCategoryID + ")";
            string orderby = "Name";
            try
            {
                DataSet ds = data.GetProductCategorysDynamicDataSet(where, orderby);
                if(ds.Tables[0].Rows[0]["Name"] != DBNull.Value)
                    CatName = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetCategoryNameBySubCategory");
                throw (ex);
            }
            return CatName;
        }
	}
}
