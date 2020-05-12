using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesOrderHeader{
        private LogWriter log = new LogWriter();
        private SalesOrderHeaderData data = new SalesOrderHeaderData();
        private System.Int32 _SalesOrderID;
        private System.DateTime _OrderDate;
        private System.DateTime _DueDate;
        private System.DateTime _ShipDate;
        private System.Byte _Status;
        private System.Boolean _OnlineOrderFlag;
        private System.String _SalesOrderNumber;
        private System.String _PurchaseOrderNumber;
        private System.Int32 _CustomerID;
        private System.Int32 _SalesPersonID;
        private System.Int32 _BillToAddressID;
        private System.Int32 _ShipToAddressID;
        private System.Int32 _ShipMethodID;
        private System.Int32 _PaymentMethodID;
        private System.Int32 _CurrencyRateID;
        private System.Decimal _SubTotal;
        private System.Decimal _TaxAmt;
        private System.Decimal _Freight;
        private System.Decimal _TotalDue;
        private System.String _Comment;
        private System.DateTime _ModifiedDate;
        public SalesOrderHeader(){}
        public SalesOrderHeader(
                    System.Int32 salesorderid,
                    System.DateTime orderdate,
                    System.DateTime duedate,
                    System.DateTime shipdate,
                    System.Byte status,
                    System.Boolean onlineorderflag,
                    System.String salesordernumber,
                    System.String purchaseordernumber,
                    System.Int32 customerid,
                    System.Int32 salespersonid,
                    System.Int32 billtoaddressid,
                    System.Int32 shiptoaddressid,
                    System.Int32 shipmethodid,
                    System.Int32 paymentmethodid,
                    System.Int32 currencyrateid,
                    System.Decimal subtotal,
                    System.Decimal taxamt,
                    System.Decimal freight,
                    System.Decimal totaldue,
                    System.String comment,
                    System.DateTime modifieddate)
        {
            this._SalesOrderID = salesorderid;
            this._OrderDate = orderdate;
            this._DueDate = duedate;
            this._ShipDate = shipdate;
            this._Status = status;
            this._OnlineOrderFlag = onlineorderflag;
            this._SalesOrderNumber = salesordernumber;
            this._PurchaseOrderNumber = purchaseordernumber;
            this._CustomerID = customerid;
            this._SalesPersonID = salespersonid;
            this._BillToAddressID = billtoaddressid;
            this._ShipToAddressID = shiptoaddressid;
            this._ShipMethodID = shipmethodid;
            this._PaymentMethodID = paymentmethodid;
            this._CurrencyRateID = currencyrateid;
            this._SubTotal = subtotal;
            this._TaxAmt = taxamt;
            this._Freight = freight;
            this._TotalDue = totaldue;
            this._Comment = comment;
            this._ModifiedDate = modifieddate;
        }
		
		public System.Int32 SalesOrderID{
			get{return _SalesOrderID;}
			set{ _SalesOrderID=value;}
		}
		public System.DateTime OrderDate{
			get{return _OrderDate;}
			set{ _OrderDate=value;}
		}
		public System.DateTime DueDate{
			get{return _DueDate;}
			set{ _DueDate=value;}
		}
		public System.DateTime ShipDate{
			get{return _ShipDate;}
			set{ _ShipDate=value;}
		}
		public System.Byte Status{
			get{return _Status;}
			set{ _Status=value;}
		}
		public System.Boolean OnlineOrderFlag{
			get{return _OnlineOrderFlag;}
			set{ _OnlineOrderFlag=value;}
		}
		public System.String SalesOrderNumber{
			get{return _SalesOrderNumber;}
			set{ _SalesOrderNumber=value;}
		}
		public System.String PurchaseOrderNumber{
			get{return _PurchaseOrderNumber;}
			set{ _PurchaseOrderNumber=value;}
		}
		public System.Int32 CustomerID{
			get{return _CustomerID;}
			set{ _CustomerID=value;}
		}
		public System.Int32 SalesPersonID{
			get{return _SalesPersonID;}
			set{ _SalesPersonID=value;}
		}
		public System.Int32 BillToAddressID{
			get{return _BillToAddressID;}
			set{ _BillToAddressID=value;}
		}
		public System.Int32 ShipToAddressID{
			get{return _ShipToAddressID;}
			set{ _ShipToAddressID=value;}
		}
		public System.Int32 ShipMethodID{
			get{return _ShipMethodID;}
			set{ _ShipMethodID=value;}
		}
		public System.Int32 PaymentMethodID{
			get{return _PaymentMethodID;}
			set{ _PaymentMethodID=value;}
		}
		public System.Int32 CurrencyRateID{
			get{return _CurrencyRateID;}
			set{ _CurrencyRateID=value;}
		}
		public System.Decimal SubTotal{
			get{return _SubTotal;}
			set{ _SubTotal=value;}
		}
		public System.Decimal TaxAmt{
			get{return _TaxAmt;}
			set{ _TaxAmt=value;}
		}
		public System.Decimal Freight{
			get{return _Freight;}
			set{ _Freight=value;}
		}
		public System.Decimal TotalDue{
			get{return _TotalDue;}
			set{ _TotalDue=value;}
		}
		public System.String Comment{
			get{return _Comment;}
			set{ _Comment=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddSalesOrderHeader(SalesOrderHeader salesorderheader)
        {
            int ret = 0;
            if(data == null)
                data = new SalesOrderHeaderData();
            try
            {
                ret = data.AddSalesOrderHeader(salesorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveSalesOrderHeader(SalesOrderHeader salesorderheader)
        {
            bool ret = false;
            try
            {
                ret = data.DeleteSalesOrderHeader(salesorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesOrderHeader(SalesOrderHeader salesorderheader)
        {
            bool ret = false;
            try
            {
                ret = data.UpdateSalesOrderHeader(salesorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SalesOrderHeader GetSalesOrderHeader(int saleOrderHeaderID)
        {
            SalesOrderHeader soh = new SalesOrderHeader();
            try
            {
                soh = data.GetSalesOrderHeader(saleOrderHeaderID);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return soh;
        }
        public DataSet GetAllSalesOrderHeaderDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesOrderHeadersDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeaderDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesOrderHeaderCollection GetAllSalesOrderHeaderCollection()
        {
            SalesOrderHeaderCollection col = new SalesOrderHeaderCollection();
            try
            {
                col = data.GetAllSalesOrderHeadersCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesOrderHeaderCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesOrderHeaderDataSet(string where, string orderBy)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesOrderHeadersDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderHeaderDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesOrderHeaderCollection GetSalesOrderHeaderCollection(string where, string orderBy)
        {
            SalesOrderHeaderCollection col = new SalesOrderHeaderCollection();
            if (data == null)
                data = new SalesOrderHeaderData();
            try
            {
                col = data.GetAllSalesOrderHeadersDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesOrderHeaderCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

        public bool UpdateSalesOrderHeaderMobile(SalesOrderHeader salesorderheader)
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            bool ret = false;
            try
            {
                ret = conn.UpdateSalesOrderHeader(salesorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesOrderHeaderMobile");
                throw (ex);
            }
            finally
            {
                conn = null;
            }
            return ret;

        }
        public int AddSalesOrderHeaderMobile(SalesOrderHeader salesorderheader)
        {
            SqlCompactConnection conn = new SqlCompactConnection();
            int ret = 0;
            try
            {
                ret = conn.AddSalesOrderHeader(salesorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesOrderHeaderMobile");
                throw (ex);
            }
            finally
            {
                conn = null;
            }
            return ret;
        }


        
	}
}
