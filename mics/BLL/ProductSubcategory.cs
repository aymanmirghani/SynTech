using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductSubcategory{
        private LogWriter log = new LogWriter();
        //private ProductSubcategoryData data = new ProductSubcategoryData();
		public ProductSubcategory(){}
		public ProductSubcategory(
					System.Int32 productsubcategoryid,
					System.Int32 productcategoryid,
					System.String name,
					System.DateTime modifieddate
		){
		this._ProductSubcategoryID = productsubcategoryid;
		this._ProductCategoryID = productcategoryid;
		this._Name = name;
		this._ModifiedDate = modifieddate;
		}
			private System.Int32 _ProductSubcategoryID;
			private System.Int32 _ProductCategoryID;
			private System.String _Name;
			private System.DateTime _ModifiedDate;
		public System.Int32 ProductSubcategoryID{
			get{return _ProductSubcategoryID;}
			set{ _ProductSubcategoryID=value;}
		}
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
		public int AddProductSubcategory(ProductSubcategory productsubcategory)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            int productSubCatID = 0;
            try
            {
                productSubCatID = data.AddProductSubcategory(productsubcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductSubcategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productSubCatID;
        }
		public bool RemoveProductSubcategory(ProductSubcategory productsubcategory)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductSubcategory(productsubcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductSubcategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public int Exists(string name, int categoryID)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            try
            {
                return(data.Exists(name,categoryID));
            }
            catch (Exception ex)
            {
                log.Write(ex.Message,"Exists");
                throw(ex);
            }
            finally
            {
                data = null;
            }
        }
        public bool RemoveProductSubcategory(int productsubcategoryID)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductSubcategory(productsubcategoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductSubcategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateProductSubcategory(ProductSubcategory productsubcategory)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            bool ret = false;
            try
            {
                ret = data.UpdateProductSubcategory(productsubcategory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductSubcategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public ProductSubcategory GetProductSubcategory(int productSubCategoryID)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            ProductSubcategory psc = new ProductSubcategory();
            try
            {
                psc = data.GetProductSubcategory(productSubCategoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductSubcategory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return psc;
        }
        public DataSet GetAllProductSubcategoryDataSet()
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductSubcategoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductSubcategoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductSubcategoryCollection GetAllProductSubcategoryCollection()
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            ProductSubcategoryCollection col = new ProductSubcategoryCollection();
            try
            {
                col = data.GetAllProductSubcategoryCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductSubcategoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductSubcategoryDataSet(string whereExpression, string orderByExpression)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductSubcategoryDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductSubcategoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductSubcategoryCollection GetProductSubcategoryCollection(string whereExpression, string orderByExpression)
        {
            ProductSubcategoryData data = new ProductSubcategoryData();
            ProductSubcategoryCollection col = new ProductSubcategoryCollection();
            try
            {
                col = data.GetAllProductSubcategoryDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductSubcategoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public bool Exsists(string subCategoryName)
        {
           // ProductSubcategoryData data = new ProductSubcategoryData();
            ProductSubcategoryCollection col = new ProductSubcategoryCollection();
            string where = "[Name]='" + subCategoryName + "'";
            string orderBy = String.Empty;
            try
            {
                col = GetProductSubcategoryCollection(where, orderBy);
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
           // return false;
        }
        
	}
}
