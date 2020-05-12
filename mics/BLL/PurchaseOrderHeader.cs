using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class PurchaseOrderHeader{
        
        private LogWriter log = new LogWriter();
        
        private System.Int32 _PurchaseOrderID;
        private System.String _RevisionNumber;
        private System.Byte _Status;
        private System.Int32 _EmployeeID;
        private System.Int32 _VendorID;
        private System.Int32 _ShipMethodID;
        private System.DateTime _OrderDate;
        private System.DateTime _ShipDate;
        private System.Decimal _SubTotal;
        private System.Decimal _TaxAmt;
        private System.Decimal _Freight;
        private System.Decimal _TotalDue;
        private System.DateTime _ModifiedDate;
        public PurchaseOrderHeader(){}
        public PurchaseOrderHeader(
                    System.Int32 purchaseorderid,
                    System.String revisionnumber,
                    System.Byte status,
                    System.Int32 employeeid,
                    System.Int32 vendorid,
                    System.Int32 shipmethodid,
                    System.DateTime orderdate,
                    System.DateTime shipdate,
                    System.Decimal subtotal,
                    System.Decimal taxamt,
                    System.Decimal freight,
                    System.Decimal totaldue,
                    System.DateTime modifieddate)
        {
            this._PurchaseOrderID = purchaseorderid;
            this._RevisionNumber = revisionnumber;
            this._Status = status;
            this._EmployeeID = employeeid;
            this._VendorID = vendorid;
            this._ShipMethodID = shipmethodid;
            this._OrderDate = orderdate;
            this._ShipDate = shipdate;
            this._SubTotal = subtotal;
            this._TaxAmt = taxamt;
            this._Freight = freight;
            this._TotalDue = totaldue;
            this._ModifiedDate = modifieddate;
        }
		
		public System.Int32 PurchaseOrderID{
			get{return _PurchaseOrderID;}
			set{ _PurchaseOrderID=value;}
		}
		public System.String RevisionNumber{
			get{return _RevisionNumber;}
			set{ _RevisionNumber=value;}
		}
		public System.Byte Status{
			get{return _Status;}
			set{ _Status=value;}
		}
		public System.Int32 EmployeeID{
			get{return _EmployeeID;}
			set{ _EmployeeID=value;}
		}
		public System.Int32 VendorID{
			get{return _VendorID;}
			set{ _VendorID=value;}
		}
		public System.Int32 ShipMethodID{
			get{return _ShipMethodID;}
			set{ _ShipMethodID=value;}
		}
		public System.DateTime OrderDate{
			get{return _OrderDate;}
			set{ _OrderDate=value;}
		}
		public System.DateTime ShipDate{
			get{return _ShipDate;}
			set{ _ShipDate=value;}
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
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddPurchaseOrderHeader(PurchaseOrderHeader purchaseorderheader)
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            int ret = 0;
            try
            {
                ret = data.AddPurchaseOrderHeader(purchaseorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPurchaseOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemovePurchaseOrderHeader(PurchaseOrderHeader purchaseorderheader)
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseOrderHeader(purchaseorderheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
       

		public bool UpdatePurchaseOrderHeader(PurchaseOrderHeader purchaseorderheader)
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            bool ret = false;
            try
            {
                ret = data.UpdatePurchaseOrderHeader(purchaseorderheader);
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePurchaseOrderHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public PurchaseOrderHeader GetPurchaseOrderHeader(int purchaseOrderID )
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            try
            {
                poh = data.GetPurchaseOrderHeader(purchaseOrderID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOrderHeaders");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return poh;
        }
        public DataSet GetAllPurchasOrderHeadersDataSet()
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPurchaseOrderHeaderDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchasOrderHeadersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseOrderHeaderCollection GetAllPurchaseOrderHeaderCollection()
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            PurchaseOrderHeaderCollection col = new PurchaseOrderHeaderCollection();
            try
            {
                col = data.GetAllPurchaseOrderHeaderCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseOrderHeaderCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetPurchaseOderHeaderDataSet(string where, string orderby)
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPurchaseOrderHeaderDynamicDataSet(where, orderby);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOderHeaderDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseOrderHeaderCollection GetPurchaseOrderHeaderCollection(string where, string orderBy)
        {
            PurchaseOrderHeaderData data = new PurchaseOrderHeaderData();
            PurchaseOrderHeaderCollection col = new PurchaseOrderHeaderCollection();
            try
            {
                col = data.GetAllPurchaseOrderHeaderDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOrderHeaderCollection");
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
