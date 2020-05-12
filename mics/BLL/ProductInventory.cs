using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductInventory{
      
        private LogWriter log = new LogWriter();
        private System.Int32 _ProductID;
        private System.Int32 _LocationID;
        private System.String _Shelf;
        private System.Byte _Bin;
        private System.Int64 _Quantity;
        private System.DateTime _ModifiedDate;
		public ProductInventory(){}
        public ProductInventory(
                    System.Int32 productid,
                    System.Int32 locationid,
                    System.String shelf,
                    System.Byte bin,
                    System.Int16 quantity,
                    System.DateTime modifieddate)
        {
            this._ProductID = productid;
            this._LocationID = locationid;
            this._Shelf = shelf;
            this._Bin = bin;
            this._Quantity = quantity;
            this._ModifiedDate = modifieddate;
        }
		
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Int32 LocationID{
			get{return _LocationID;}
			set{ _LocationID=value;}
		}
		public System.String Shelf{
			get{return _Shelf;}
			set{ _Shelf=value;}
		}
		public System.Byte Bin{
			get{return _Bin;}
			set{ _Bin=value;}
		}
		public System.Int64 Quantity{
			get{return _Quantity;}
			set{ _Quantity=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
       
		public bool AddProductInventory(ProductInventory productinventory)
        {
            ProductInventoryData data = new ProductInventoryData();
            bool ret = false;
            try
            {
                ret = data.AddProductInventory(productinventory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductInventory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveProductInventory(ProductInventory productinventory)
        {
            ProductInventoryData data = new ProductInventoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductInventory(productinventory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductInventory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateProductInventory(ProductInventory productinventory)
        {
            ProductInventoryData data = new ProductInventoryData();
            bool ret=false;
            try
            {
                ret = data.UpdateProductInventory(productinventory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductInventory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool UpdateInventory(ProductInventory productinventory)
        {
            ProductInventoryData data = new ProductInventoryData();
            bool ret = false;
            try
            {
                ret = data.UpdateInventory(productinventory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateInventory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public ProductInventory GetProductInventorys(int productid)
        {
            ProductInventoryData data = new ProductInventoryData();
            ProductInventory productInventory = new ProductInventory();
            try
            {
                productInventory = data.GetProductInventory(productid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductInventorys");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productInventory;
        }
        public DataSet GetAllProductInventoryDataSet()
        {
            ProductInventoryData data = new ProductInventoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductInventoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductInventoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductInventoryCollection GetAllProductInventoryCollection()
        {
            ProductInventoryData data = new ProductInventoryData();
            ProductInventoryCollection col = new ProductInventoryCollection();
            try
            {
                col = data.GetAllProductInventorysCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductInventoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductInventoryDataSet(string whereExpression, string orderByExpression)
        {
            ProductInventoryData data = new ProductInventoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductInventoryDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductInventoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductInventoryCollection GetProductInventoryCollection(string whereExpression, string orderByExpression)
        {
            ProductInventoryData data = new ProductInventoryData();
            ProductInventoryCollection col = new ProductInventoryCollection();
            try
            {
                col = data.GetAllProductInventorysDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductInventoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

	}
}
