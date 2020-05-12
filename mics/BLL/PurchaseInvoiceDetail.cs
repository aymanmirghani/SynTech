using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class PurchaseInvoiceDetail{
        //public event OrderEventsHandler PurchaseOrderStatusChanged;
        private LogWriter log = new LogWriter();
        
		public PurchaseInvoiceDetail(){}
        public PurchaseInvoiceDetail(
                    System.Int32 invoiceid,
                    System.Int32 invoicedetailid,
                    System.Int32 productid,
                    System.Decimal unitprice,
                    System.Int64 quantity,
                    System.DateTime modifieddate
        )
        {
            this._InvoiceID = invoiceid;
            this._InvoiceDetailID = invoicedetailid;
            this._ProductID = productid;
            this._UnitPrice = unitprice;
            this._Quantity = quantity;
            this._ModifiedDate = modifieddate;
        }
        public PurchaseInvoiceDetail(PurchaseOrderDetail pod,int invoiceID)
        {
            this._ProductID = pod.ProductID;
            this._Quantity = pod.OrderQty;
            this._UnitPrice = pod.UnitPrice;
            this._ModifiedDate = DateTime.Now;
            this._InvoiceID = invoiceID;
        }
			private System.Int32 _InvoiceID;
			private System.Int32 _InvoiceDetailID;
			private System.Int32 _ProductID;
			private System.Decimal _UnitPrice;
			private System.Int64 _Quantity;
			private System.DateTime _ModifiedDate;
		public System.Int32 InvoiceID{
			get{return _InvoiceID;}
			set{ _InvoiceID=value;}
		}
		public System.Int32 InvoiceDetailID{
			get{return _InvoiceDetailID;}
			set{ _InvoiceDetailID=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Decimal UnitPrice{
			get{return _UnitPrice;}
			set{ _UnitPrice=value;}
		}
		public System.Int64 Quantity{
			get{return _Quantity;}
			set{ _Quantity=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        
		public int AddPurchaseInvoiceDetail(PurchaseInvoiceDetail purchaseinvoicedetail)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            int id = 0;
            try
            {
                id = data.AddPurchaseInvoiceDetail(purchaseinvoicedetail);
                UpdateInvoiceTotal(purchaseinvoicedetail.InvoiceID);
                
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
        public void AddUpdatePurchaseInvoiceDetail(PurchaseInvoiceDetail purchaseinvoicedetail)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            
            try
            {
                data.AddUpdatePurchaseInvoiceDetail(purchaseinvoicedetail);
               // this.PurchaseOrderStatusChanged += new OrderEventsHandler(PurchaseInvoiceDetail_OrderStatusChanged);
                
                PurchaseInvoiceHeader head = new PurchaseInvoiceHeader();
                PurchaseInvoiceHeaderCollection col = new PurchaseInvoiceHeaderCollection();

                head = head.GetPurchaseInvoiceHeader(purchaseinvoicedetail.InvoiceID);

                /*this.OrderStatusChanged += new OrderEventsHandler(PurchaseInvoiceHeader_OrderStatusChanged);*/
               // if (head.Status == (byte)OrderStatus.Received)
               // {
                //    OnPurchaseOrderStatusChanged(purchaseinvoicedetail.ProductID, purchaseinvoicedetail.Quantity);

               // }
                UpdateInvoiceTotal(purchaseinvoicedetail.InvoiceID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddUpdatePurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            
        }
        private void UpdateInvoiceTotal(int invoiceID)
        {
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
            PurchaseInvoiceDetailCollection pidColl = new PurchaseInvoiceDetailCollection();
            string where = "invoiceID = " + invoiceID;
            string orderby = String.Empty;
            try
            {
                pidColl = pid.GetPurchaseInvoiceDetailsCollection(where, orderby);
                decimal total = 0.00m;
                foreach (PurchaseInvoiceDetail p in pidColl)
                {
                    total += (decimal)(p.UnitPrice * p.Quantity);
                }
                pih = pih.GetPurchaseInvoiceHeader(invoiceID);
                pih.TotalDue = total;
                pih.UpdatePurchaseInvoiceHeader(pih);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateInvoiceTotal");
                throw (ex);
            }
            finally
            {
                pih = null;
                pid = null;
                pidColl = null;
            }
        }
        private void UpdateInvoiceTotal(PurchaseInvoiceDetailCollection coll)
        {
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
            PurchaseInvoiceDetailCollection pidColl = new PurchaseInvoiceDetailCollection();
            int invoiceID = coll[0].InvoiceID;
            string where = "invoiceID = " + invoiceID;
            string orderby = String.Empty;
            try
            {
                pidColl = pid.GetPurchaseInvoiceDetailsCollection(where, orderby);
                decimal total = 0.00m;
                foreach (PurchaseInvoiceDetail p in pidColl)
                {
                    total += (decimal)(p.UnitPrice * p.Quantity);
                }
                pih = pih.GetPurchaseInvoiceHeader(invoiceID);
                pih.TotalDue = total;
                pih.UpdatePurchaseInvoiceHeader(pih);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateInvoiceTotal");
                throw (ex);
            }
            finally
            {
                pih = null;
                pid = null;
                pidColl = null;
            }
        }

        private void UpdateInvoiceTotal(int invoiceDetailID, bool flag)
        {
            PurchaseInvoiceHeader pih = new PurchaseInvoiceHeader();
            PurchaseInvoiceDetail pid = new PurchaseInvoiceDetail();
            PurchaseInvoiceDetailCollection pidColl = new PurchaseInvoiceDetailCollection();
            
            try
            {
                pid = pid.GetPurchaseInvoiceDetails(invoiceDetailID);
                int invoiceID = pid.InvoiceID;
                string where = "invoiceID = " + invoiceID;
                string orderby = String.Empty;
                pidColl = pid.GetPurchaseInvoiceDetailsCollection(where, orderby);

                decimal total = 0.00m;
                foreach (PurchaseInvoiceDetail p in pidColl)
                {
                    total += (decimal)(p.UnitPrice * p.Quantity);
                }
                pih = pih.GetPurchaseInvoiceHeader(invoiceID);
                pih.TotalDue = total;
                pih.UpdatePurchaseInvoiceHeader(pih);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateInvoiceTotal");
                throw (ex);
            }
            finally
            {
                pih = null;
                pid = null;
                pidColl = null;
            }
        }
        
		public bool RemovePurchaseInvoiceDetail(PurchaseInvoiceDetail purchaseinvoicedetail)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseInvoiceDetail(purchaseinvoicedetail);
                UpdateInvoiceTotal(purchaseinvoicedetail.InvoiceID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemovePurchaseInvoiceDetail(int pid)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseInvoiceDetail(pid);
                UpdateInvoiceTotal(pid,true);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemovePurchaseInvoiceDetail(PurchaseInvoiceDetailCollection col)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseInvoiceDetail(col);
                UpdateInvoiceTotal(col);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdatePurchaseInvoiceDetail(PurchaseInvoiceDetail purchaseinvoicedetail)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            bool ret = false;
            try
            {
                ret = data.UpdatePurchaseInvoiceDetail(purchaseinvoicedetail);
                UpdateInvoiceTotal(purchaseinvoicedetail.InvoiceID);
                

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
       /* protected virtual void OnPurchaseOrderStatusChanged(int productId, long quantity)
        {
            if (PurchaseOrderStatusChanged != null)
            {
                OrderEventsArgs args = new OrderEventsArgs(productId, quantity);
                PurchaseOrderStatusChanged(this, args);
            }
        }*/
        /*
        void PurchaseInvoiceDetail_OrderStatusChanged(object sender, OrderEventsArgs e)
        {
            ProductInventory inv = new ProductInventory();
            inv.ProductID = e.ProductID;
            inv.Quantity = e.Quantity;
            inv.ModifiedDate = DateTime.Now;
            
            inv.UpdateInventory(inv);
            
        }*/
		public PurchaseInvoiceDetail GetPurchaseInvoiceDetails(int pid)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();
            try
            {
                purchaseInvoiceDetail = data.GetPurchaseInvoiceDetail(pid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceDetails");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return purchaseInvoiceDetail;
        }
        public DataSet GetAllPurchaseInvoiceDetailsDataSet()
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPurchaseInvoiceDetailDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public DataSet GetAllPurchaseInvoiceDetailsDataSet(int purchaseInvoiceDetailID)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPurchaseInvoiceDetailDataSet(purchaseInvoiceDetailID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseInvoiceDetailCollection GetAllPurchaseInvoiceDetailsCollection()
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            PurchaseInvoiceDetailCollection col = new PurchaseInvoiceDetailCollection();
            try
            {
                col = data.GetAllPurchaseInvoiceDetailCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public PurchaseInvoiceDetailCollection GetAllPurchaseInvoiceDetailsCollection(int purchaseInvoiceDetailsID)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            PurchaseInvoiceDetailCollection col = new PurchaseInvoiceDetailCollection();
            try
            {
                col = data.GetAllPurchaseInvoiceDetailCollection(purchaseInvoiceDetailsID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        //
        public DataSet GetPurchaseInvoiceDetailsGridDataSet(string where, string orderBy)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPurchaseInvoiceDetailGridDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceDetailsGridDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public DataSet GetPurchaseInvoiceDetailsDataSet(string where, string orderBy)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPurchaseInvoiceDetailDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceDetailsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseInvoiceDetailCollection GetPurchaseInvoiceDetailsCollection(string where, string orderBy)
        {
            PurchaseInvoiceDetailData data = new PurchaseInvoiceDetailData();
            PurchaseInvoiceDetailCollection col = new PurchaseInvoiceDetailCollection();
            try
            {
                col = data.GetAllPurchaseInvoiceDetailDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceDetailsCollection");
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
