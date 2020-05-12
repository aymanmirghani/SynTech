using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesInvoiceDetail{
        private LogWriter log = new LogWriter();
        
		public SalesInvoiceDetail(){}
        public SalesInvoiceDetail(
                    System.Int32 invoicedetailid,
                    System.Int32 invoiceid,
                    System.Int16 quantity,
                    System.Int32 productid,
                    System.Int32 specialofferid,
                    System.Decimal unitprice,
                    System.Decimal unitpricediscount,
                    System.Decimal linetotal,
                    System.DateTime modifieddate)
        {
            this._InvoiceDetailID = invoicedetailid;
            this._InvoiceID = invoiceid;
            this._Quantity = quantity;
            this._ProductID = productid;
            this._SpecialOfferID = specialofferid;
            this._UnitPrice = unitprice;
            this._UnitPriceDiscount = unitpricediscount;
            this._LineTotal = linetotal;
            this._ModifiedDate = modifieddate;
        }
			private System.Int32 _InvoiceDetailID;
			private System.Int32 _InvoiceID;
			private System.Int16 _Quantity;
			private System.Int32 _ProductID;
			private System.Int32 _SpecialOfferID;
			private System.Decimal _UnitPrice;
			private System.Decimal _UnitPriceDiscount;
			private System.Decimal _LineTotal;
			private System.DateTime _ModifiedDate;
		public System.Int32 InvoiceDetailID{
			get{return _InvoiceDetailID;}
			set{ _InvoiceDetailID=value;}
		}
		public System.Int32 InvoiceID{
			get{return _InvoiceID;}
			set{ _InvoiceID=value;}
		}
		public System.Int16 Quantity{
			get{return _Quantity;}
			set{ _Quantity=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Int32 SpecialOfferID{
			get{return _SpecialOfferID;}
			set{ _SpecialOfferID=value;}
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
		public int AddSalesInvoiceDetail(SalesInvoiceDetail salesinvoicedetail)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            int id = 0;
            try
            {
                id = data.AddSalesInvoiceDetail(salesinvoicedetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveSalesInvoiceDetail(SalesInvoiceDetail salesinvoicedetail)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesInvoiceDetail(salesinvoicedetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesInvoiceDetail(int salesinvoicedetailID)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesInvoiceDetail(salesinvoicedetailID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesInvoiceDetail(SalesInvoiceDetail salesinvoicedetail)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.UpdateSalesInvoiceDetail(salesinvoicedetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SalesInvoiceDetail GetSalesInvoiceDetails(int saleInvoiceDetailID)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            SalesInvoiceDetail sih = new SalesInvoiceDetail();
            try
            {
                sih = data.GetSalesInvoiceDetail(saleInvoiceDetailID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceDetails");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sih;
        }
        public DataSet GetAllSalesInvoiceDetailDataSet()
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesInvoiceDetailsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesInvoiceDetailCollection GetAllSalesInvoiceDetailCollection()
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            SalesInvoiceDetailCollection col = new SalesInvoiceDetailCollection();
            try
            {
                col = data.GetAllSalesInvoiceDetailsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceDetailCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesInvoiceDetailDataSet(string where, string orderBy)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesInvoiceDetailsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesInvoiceDetailCollection GetSalesInvoiceDetailCollection(string where, string orderBy)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            SalesInvoiceDetailCollection col = new SalesInvoiceDetailCollection();
            try
            {
                col = data.GetAllSalesInvoiceDetailsDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceDetailCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetInvoiceDetailsGroupedByName(int invoiceid)
        {
            SalesInvoiceDetailData data = new SalesInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetInvoiceDetailsGroupedByName(invoiceid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetInvoiceDetailsGroupedByName");
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
