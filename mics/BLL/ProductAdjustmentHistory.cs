using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductAdjustmentHistory{
        private LogWriter log = new LogWriter();
        private ProductAdjustmentHistoryData data = new ProductAdjustmentHistoryData();
		public ProductAdjustmentHistory(){}
        public ProductAdjustmentHistory(
                    System.Int32 id,
                    System.Int32 productid,
                    System.Int32 adjustedquantity,
                    System.String reason,
                    System.DateTime modifieddate)
        {
            this._ID = id;
            this._ProductID = productid;
            this._AdjustedQuantity = adjustedquantity;
            this._Reason = reason;
            this._ModifiedDate = modifieddate;
        }
			private System.Int32 _ID;
			private System.Int32 _ProductID;
			private System.Int32 _AdjustedQuantity;
			private System.String _Reason;
			private System.DateTime _ModifiedDate;
		public System.Int32 ID{
			get{return _ID;}
			set{ _ID=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Int32 AdjustedQuantity{
			get{return _AdjustedQuantity;}
			set{ _AdjustedQuantity=value;}
		}
		public System.String Reason{
			get{return _Reason;}
			set{ _Reason=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddProductAdjustmentHistory(ProductAdjustmentHistory productadjustmenthistory)
        {
           // bool ret = false;
            int id = 0;
            try
            {
                id = data.AddProductAdjustmentHistory(productadjustmenthistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductAdjustmentHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		
		
		public ProductAdjustmentHistory GetProductAdjustmentHistory(int pahId)
        {
            ProductAdjustmentHistory pah = new ProductAdjustmentHistory();
            try
            {
                pah = data.GetProductAdjustmentHistory(pahId);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductAdjustmentHistorys");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return pah;
        }
        public DataSet GetAllProductAdjustmentHistoryDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductAdjustmentHistoryDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductAdjustmentHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductAdjustmentHistoryCollection GetAllProductAdjustmentHistoryCollection()
        {
            ProductAdjustmentHistoryCollection col = new ProductAdjustmentHistoryCollection();
            try
            {
                col = data.GetAllProductAdjustmentHistoryCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductAdjustmentHistoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductAdjustmentHistoryDataSet(string where, string orderBy)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductAdjustmentHistoryDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductAdjustmentHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductAdjustmentHistoryCollection GetProductAdjustmentHistoryCollection(string where, string orderBy)
        {
            ProductAdjustmentHistoryCollection col = new ProductAdjustmentHistoryCollection();
            try
            {
                col = data.GetAllProductAdjustmentHistoryDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductAdjustmentHistoryCollection");
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
