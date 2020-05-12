using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesOrderDetail{
        private LogWriter log = new LogWriter();
        
		public SalesOrderDetail(){}
        public SalesOrderDetail(
                    System.Int32 salesorderid,
                    System.Int32 salesorderdetailid,
                    System.String carriertrackingnumber,
                    System.Int16 orderqty,
                    System.Int32 productid,
                    System.Int32 specialofferid,
                    System.String specialofferdesc,
                    System.Decimal unitprice,
                    System.Decimal unitpricediscount,
                    System.Decimal linetotal,
                    System.DateTime modifieddate)
        {
            this._SalesOrderID = salesorderid;
            this._SalesOrderDetailID = salesorderdetailid;
            this._CarrierTrackingNumber = carriertrackingnumber;
            this._OrderQty = orderqty;
            this._ProductID = productid;
            this._SpecialOfferID = specialofferid;
            this._SpecialOfferDesc = specialofferdesc;
            this._UnitPrice = unitprice;
            this._UnitPriceDiscount = unitpricediscount;
            this._LineTotal = linetotal;
            this._ModifiedDate = modifieddate;
        }
			private System.Int32 _SalesOrderID;
			private System.Int32 _SalesOrderDetailID;
			private System.String _CarrierTrackingNumber;
			private System.Int16 _OrderQty;
			private System.Int32 _ProductID;
			private System.Int32 _SpecialOfferID;
            private System.String _SpecialOfferDesc;
			private System.Decimal _UnitPrice;
			private System.Decimal _UnitPriceDiscount;
			private System.Decimal _LineTotal;
			private System.DateTime _ModifiedDate;
            private System.String _Name;
            private System.String _Description;
		public System.Int32 SalesOrderID{
			get{return _SalesOrderID;}
			set{ _SalesOrderID=value;}
		}
		public System.Int32 SalesOrderDetailID{
			get{return _SalesOrderDetailID;}
			set{ _SalesOrderDetailID=value;}
		}
        public System.String CarrierTrackingNumber{
			get{return _CarrierTrackingNumber;}
			set{ _CarrierTrackingNumber=value;}
		}
		public System.Int16 OrderQty{
			get{return _OrderQty;}
			set{ _OrderQty=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Int32 SpecialOfferID{
			get{return _SpecialOfferID;}
			set{ _SpecialOfferID=value;}
		}
        public System.String SpecialOfferDesc
        {
            get { return _SpecialOfferDesc; }
            set { _SpecialOfferDesc = value; }
        }
		public System.Decimal UnitPrice{
			get{return _UnitPrice;}
			set{ _UnitPrice=value;}
		}
		public System.Decimal UnitPriceDiscount{
			get{return _UnitPriceDiscount;}
			set{ _UnitPriceDiscount=value;}
		}
		public System.Decimal LineTotal{
			get{return _LineTotal;}
			set{ _LineTotal=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        public System.String ProductName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public System.String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
		public int AddSalesOrderDetail(SalesOrderDetail salesorderdetail)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            int ret = 0;
            if (data == null)
                data = new SalesOrderDetailData();
            try
            {
                ret = data.AddSalesOrderDetail(salesorderdetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesOrderDetails");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesOrderDetail(int salesorderid)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            bool ret = true;
            try
            {
                ret = data.DeleteSalesOrderDetail(salesorderid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesOrderDetails");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool DeleteSalesOrderDetailsDynamic(string where)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            bool ret = true;
            try
            {
                ret = data.DeleteSalesOrderDetailsDynamic(where);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderDetailsDynamic");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesOrderDetail(SalesOrderDetail salesorderdetail)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            bool ret = true;
            try
            {
                data.UpdateSalesOrderDetail(salesorderdetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesOrderDetails");
                ret = false;
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public SalesOrderDetail GetSalesOrderDetail(int saleOrderID)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            SalesOrderDetail sod = new SalesOrderDetail();
            try
            {
                sod = data.GetSalesOrderDetail(saleOrderID);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sod;
        }
        public DataSet GetAllSalesOrderDetailDataSet()
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesOrderDetailsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesOrderDetailCollection GetAllSalesOrderHeaderCollection()
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            SalesOrderDetailCollection col = new SalesOrderDetailCollection();
            try
            {
                col = data.GetAllSalesOrderDetailsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderDetailCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesOrderDetailDataSet(string where, string orderBy)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesOrderDetailsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesOrderDetailCollection GetSalesOrderDetailCollection(string where, string orderBy)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            SalesOrderDetailCollection col = new SalesOrderDetailCollection();
            try
            {
                col = data.GetAllSalesOrderDetailsDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderDetailCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

        public bool DeleteSalesOrderDetailMobile(int SalesOrderID)
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            bool ret = false;
            try
            {
                ret = conn.DeleteSalesOrderDetail(SalesOrderID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteSalesOrderDetailMobile");
                throw (ex);
            }
            finally
            {
                conn = null;
            }
            return ret;
        }
        public bool AddSalesOrderDetailsMobile(SalesOrderDetail salesorderdetails)
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            bool ret = false;
            try
            {
                ret = conn.AddSalesOrderDetails(salesorderdetails);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesOrderDetailsMobile");
            }
            finally
            {
                conn = null;
            }
            return ret;
        }

        public DataSet GetOrderDetailsGroupedByName(int orderid)
        {
            SalesOrderDetailData data = new SalesOrderDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetOrderDetailsGroupedByName(orderid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetOrderDetailsGroupedByName");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
	}
}
