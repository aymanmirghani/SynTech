using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{

    
	public class PurchaseInvoiceHeader{
        
        private LogWriter log = new LogWriter();
        private OrderNumber orderNumber = new OrderNumber();
		public PurchaseInvoiceHeader(){}
        public PurchaseInvoiceHeader(
                    System.Int32 invoiceid,
                    System.String invoicenumber,
                    System.Byte status,
                    System.Int32 employeeid,
                    System.Int32 purchaseOrderID,
                    System.Int32 vendorid,
                    System.DateTime invoicedate,
                    System.Decimal subtotal,
                    System.Decimal taxamt,
                    System.Decimal freight,
                    System.Decimal totaldue,
                    System.DateTime modifieddate)
        {
            this._InvoiceID = invoiceid;
            this._InvoiceNumber = invoicenumber;
            this._Status = status;
            this._EmployeeID = employeeid;
            this._PurchaseOrderID = purchaseOrderID;
            this._VendorID = vendorid;
            this._InvoiceDate = invoicedate;
            this._SubTotal = subtotal;
            this._TaxAmt = taxamt;
            this._Freight = freight;
            this._TotalDue = totaldue;
            this._ModifiedDate = modifieddate;
        }
        public PurchaseInvoiceHeader(PurchaseOrderHeader poh)
        {
            this._EmployeeID = poh.EmployeeID;
            this._Freight = poh.Freight;
            this._InvoiceDate = poh.OrderDate;
            this._InvoiceNumber = orderNumber.GetNextNumber(OrderType.PurchaseInvoice);
            this._ModifiedDate = DateTime.Now;
            this._PurchaseOrderID = poh.PurchaseOrderID;
            this._Status = poh.Status;
            this._SubTotal = poh.SubTotal;
            this._TaxAmt = poh.TaxAmt;
            this._TotalDue = poh.TotalDue;
            this._VendorID = poh.VendorID;
        }
			private System.Int32 _InvoiceID;
			private System.String _InvoiceNumber;
			private System.Byte _Status;
			private System.Int32 _EmployeeID;
            private System.Int32 _PurchaseOrderID;
			private System.Int32 _VendorID;
			private System.DateTime _InvoiceDate;
			private System.Decimal _SubTotal;
			private System.Decimal _TaxAmt;
			private System.Decimal _Freight;
			private System.Decimal _TotalDue;
			private System.DateTime _ModifiedDate;
		public System.Int32 InvoiceID{
			get{return _InvoiceID;}
			set{ _InvoiceID=value;}
		}
		public System.String InvoiceNumber{
			get{return _InvoiceNumber;}
			set{ _InvoiceNumber=value;}
		}
		public System.Byte Status{
			get{return _Status;}
			set{ _Status=value;}
		}
		public System.Int32 EmployeeID{
			get{return _EmployeeID;}
			set{ _EmployeeID=value;}
		}
        public System.Int32 PurchaseOrderID
        {
            get { return _PurchaseOrderID; }
            set { _PurchaseOrderID = value; }
        }
		public System.Int32 VendorID{
			get{return _VendorID;}
			set{ _VendorID=value;}
		}
		public System.DateTime InvoiceDate{
			get{return _InvoiceDate;}
			set{ _InvoiceDate=value;}
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
        
		public int AddPurchaseInvoiceHeader(PurchaseInvoiceHeader purchaseinvoiceheader)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            int purchaseInoviceHeaderID = 0;
            try
            {
                purchaseInoviceHeaderID = data.AddPurchaseInvoiceHeader(purchaseinvoiceheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPurchaseInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return purchaseInoviceHeaderID;

        }
		public bool RemovePurchaseInvoiceHeader(PurchaseInvoiceHeader purchaseinvoiceheader)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseInvoiceHeader(purchaseinvoiceheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemovePurchaseInvoiceHeader(int purchaseinvoiceheaderID)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseInvoiceHeader(purchaseinvoiceheaderID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdatePurchaseInvoiceHeader(PurchaseInvoiceHeader purchaseinvoiceheader)
        {
           
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.UpdatePurchaseInvoiceHeader(purchaseinvoiceheader);
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePurchaseInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        
        public PurchaseInvoiceHeader GetPurchaseInvoiceHeader(int purchaseInvoiceHeaderID)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            try
            {
                pih = data.GetPurchaseInvoiceHeader(purchaseInvoiceHeaderID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return pih;
        }
        public int PurchaseInvoiceHeaderExists(int purchaseOrderID)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            PurchaseInvoiceHeaderCollection col = new PurchaseInvoiceHeaderCollection();
            string where = "[PurchaseOrderID]=" + purchaseOrderID;
            string orderBy = String.Empty;
            
            try
            {
                col = data.GetAllPurchaseInvoiceHeaderDynamicCollection(where, orderBy);
                if (col.Count > 0)
                {
                    return col[0].InvoiceID;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public DataSet GetPurchaseInvoiceHeaderDataSet(string where, string orderBy)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPurchaseInvoiceHeaderDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceHeaderDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseInvoiceHeaderCollection GetPurchaseInvoiceHeaders(string where,string orderBy)
        {
            PurchaseInvoiceHeaderData data = new PurchaseInvoiceHeaderData();
            PurchaseInvoiceHeaderCollection col = new PurchaseInvoiceHeaderCollection();
            try
            {
                col = data.GetAllPurchaseInvoiceHeaderDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
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
