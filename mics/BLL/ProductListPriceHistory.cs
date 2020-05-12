using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductListPriceHistory{
        private LogWriter log = new LogWriter();
        
        private System.Int32 _ID;
        private System.Int32 _ProductID;
        private System.DateTime _StartDate;
        private System.DateTime _EndDate;
        private System.Decimal _ListPrice;
        private System.DateTime _ModifiedDate;

        public ProductListPriceHistory(){}
        public ProductListPriceHistory(
                    System.Int32 id,
                    System.Int32 productid,
                    System.DateTime startdate,
                    System.DateTime enddate,
                    System.Decimal listprice,
                    System.DateTime modifieddate)
        {
            this._ID = id;
            this._ProductID = productid;
            this._StartDate = startdate;
            this._EndDate = enddate;
            this._ListPrice = listprice;
            this._ModifiedDate = modifieddate;
        }
        public System.Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.DateTime StartDate{
			get{return _StartDate;}
			set{ _StartDate=value;}
		}
		public System.DateTime EndDate{
			get{return _EndDate;}
			set{ _EndDate=value;}
		}
		public System.Decimal ListPrice{
			get{return _ListPrice;}
			set{ _ListPrice=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddProductListPriceHistory(ProductListPriceHistory productlistpricehistory)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            int id = 0;
            try
            {
                id = data.AddProductListPriceHistory(productlistpricehistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductListPriceHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveProductListPriceHistory(ProductListPriceHistory productlistpricehistory)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductListPriceHistory(productlistpricehistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductListPriceHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateProductListPriceHistory(ProductListPriceHistory productlistpricehistory)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            bool ret = false;
            try
            {
                ret = data.UpdateProductListPriceHistory(productlistpricehistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductListPriceHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public ProductListPriceHistory GetProductListPriceHistory(int id)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            ProductListPriceHistory plph = new ProductListPriceHistory();
            try
            {
                plph = data.GetProductListPriceHistory(id);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductListPriceHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return plph;
        }
        public DataSet GetAllProductListPriceHistoryDataSet()
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductListPriceHistoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductListPriceHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductListPriceHistoryCollection GetAllProductListPriceHistoryCollection()
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            ProductListPriceHistoryCollection col = new ProductListPriceHistoryCollection();
            try
            {
                col = data.GetAllProductListPriceHistoryCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductListPriceHistoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductListPriceHistoryDataSet(string whereExpression, string orderByExpression)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductListPriceHistoryDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductListPriceHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductListPriceHistoryCollection GetProductListPriceHistoryCollection(string whereExpression, string orderByExpression)
        {
            ProductListPriceHistoryData data = new ProductListPriceHistoryData();
            ProductListPriceHistoryCollection col = new ProductListPriceHistoryCollection();
            try
            {
                col = data.GetAllProductListPriceHistorysDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductListPriceHistoryCollection");
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
