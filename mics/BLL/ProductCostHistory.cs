using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductCostHistory{
        private LogWriter log = new LogWriter();
        ProductCostHistoryData data = new ProductCostHistoryData();
        private System.Int32 _ID;
        private System.Int32 _ProductID;
        private System.DateTime _StartDate;
        private System.DateTime _EndDate;
        private System.Decimal _StandardCost;
        private System.DateTime _ModifiedDate;
		public ProductCostHistory(){}
        public ProductCostHistory(
                    System.Int32 id,
                    System.Int32 productid,
                    System.DateTime startdate,
                    System.DateTime enddate,
                    System.Decimal standardcost,
                    System.DateTime modifieddate)
        {
            this._ID = id;
            this._ProductID = productid;
            this._StartDate = startdate;
            this._EndDate = enddate;
            this._StandardCost = standardcost;
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
		public System.Decimal StandardCost{
			get{return _StandardCost;}
			set{ _StandardCost=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddProductCostHistory(ProductCostHistory productcosthistory)
        {
            int id = 0;
            try
            {
                id = data.AddProductCostHistory(productcosthistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductCostHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveProductCostHistory(ProductCostHistory productcosthistory)
        {
            bool ret = false;
            try
            {
                ret = data.DeleteProductCostHistory(productcosthistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductCostHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public void UpdateProductCostHistory(ProductCostHistory productcosthistory){}
		public ProductCostHistory GetProductCostHistory(int productCodeHistoryID)
        {
            ProductCostHistory productCostHistory = new ProductCostHistory();
            try
            {
                productCostHistory = data.GetProductCostHistory(productCodeHistoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCostHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productCostHistory;
        }
        public DataSet GetAllProductCostHistoryDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductCostHistoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCostHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCostHistoryCollection GetAllProductCostHistoryCollection()
        {
            ProductCostHistoryCollection col = new ProductCostHistoryCollection();
            try
            {
                col = data.GetAllProductCostHistorysCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductCostHistoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;

        }
        public DataSet GetProductCostHistoryDataSet(string whereExpression, string orderByExpression)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductCostHistoryDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCostHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCostHistoryCollection GetProductCostHistoryCollection(string whereExpression, string orderByExpression)
        {
            ProductCostHistoryCollection col = new ProductCostHistoryCollection();
            try
            {
                col = data.GetAllProductCostHistorysDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductCostHistoryCollection");
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
