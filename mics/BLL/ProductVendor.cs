using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class ProductVendor{
        private LogWriter log = new LogWriter();
        

        private System.Int32 _ID;
        private System.Int32 _ProductID;
        private System.Int32 _VendorID;
        private System.Int32 _AverageLeadTime;
        private System.Decimal _StandardPrice;
        private System.Decimal _LastReceiptCost;
        private System.DateTime _LastReceiptDate;
        private System.Int32 _MinOrderQty;
        private System.Int32 _MaxOrderQty;
        private System.Int32 _OnOrderQty;
        private System.String _UnitMeasureCode;
        private System.DateTime _ModifiedDate;

		public ProductVendor(){}
        public ProductVendor(
                    System.Int32 _ID,
                    System.Int32 productid,
                    System.Int32 vendorid,
                    System.Int32 averageleadtime,
                    System.Decimal standardprice,
                    System.Decimal lastreceiptcost,
                    System.DateTime lastreceiptdate,
                    System.Int32 minorderqty,
                    System.Int32 maxorderqty,
                    System.Int32 onorderqty,
                    System.String unitmeasurecode,
                    System.DateTime modifieddate)
        {
            this._ID = ID;
            this._ProductID = productid;
            this._VendorID = vendorid;
            this._AverageLeadTime = averageleadtime;
            this._StandardPrice = standardprice;
            this._LastReceiptCost = lastreceiptcost;
            this._LastReceiptDate = lastreceiptdate;
            this._MinOrderQty = minorderqty;
            this._MaxOrderQty = maxorderqty;
            this._OnOrderQty = onorderqty;
            this._UnitMeasureCode = unitmeasurecode;
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
		public System.Int32 VendorID{
			get{return _VendorID;}
			set{ _VendorID=value;}
		}
		public System.Int32 AverageLeadTime{
			get{return _AverageLeadTime;}
			set{ _AverageLeadTime=value;}
		}
		public System.Decimal StandardPrice{
			get{return _StandardPrice;}
			set{ _StandardPrice=value;}
		}
		public System.Decimal LastReceiptCost{
			get{return _LastReceiptCost;}
			set{ _LastReceiptCost=value;}
		}
		public System.DateTime LastReceiptDate{
			get{return _LastReceiptDate;}
			set{ _LastReceiptDate=value;}
		}
		public System.Int32 MinOrderQty{
			get{return _MinOrderQty;}
			set{ _MinOrderQty=value;}
		}
		public System.Int32 MaxOrderQty{
			get{return _MaxOrderQty;}
			set{ _MaxOrderQty=value;}
		}
		public System.Int32 OnOrderQty{
			get{return _OnOrderQty;}
			set{ _OnOrderQty=value;}
		}
		public System.String UnitMeasureCode{
			get{return _UnitMeasureCode;}
			set{ _UnitMeasureCode=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public bool AddProductVendor(ProductVendor productvendor)
        {
            ProductVendorData data = new ProductVendorData();
            bool ret =false;
            try
            {
                ret = data.AddProductVendor(productvendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProductVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveProductVendor(ProductVendor productvendor)
        {
            ProductVendorData data = new ProductVendorData();
            bool ret = false;
            try
            {
                ret = data.DeleteProductVendor(productvendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProductVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateProductVendor(ProductVendor productvendor)
        {
            ProductVendorData data = new ProductVendorData();
            bool ret = false;
            try
            {
                ret = data.UpdateProductVendor(productvendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProductVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public ProductVendor GetProductVendors(int productid)
        {
            ProductVendorData data = new ProductVendorData();
            ProductVendor pv = new ProductVendor();
            try
            {
                pv = data.GetProductVendor(productid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductVendors");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return pv;
        }
        public DataSet GetAllProductVendorsDataSet()
        {
            ProductVendorData data = new ProductVendorData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllProductVendorDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductVendorsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductVendorCollection GetAllProductVendorsCollection()
        {
            ProductVendorData data = new ProductVendorData();
            ProductVendorCollection col = new ProductVendorCollection();
            try
            {
                col = data.GetAllProductVendorCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductVendorsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductVendorsDataSet(string whereExpression, string orderByExpression)
        {
            ProductVendorData data = new ProductVendorData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductVendorDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductVendorsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductVendorCollection GetProductVendorsCollection(string whereExpression, string orderByExpression)
        {
            ProductVendorData data = new ProductVendorData();
            ProductVendorCollection col = new ProductVendorCollection();
            try
            {
                col = data.GetAllProductVendorDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductVendorsCollection");
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
