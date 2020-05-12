using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class PurchaseOrderDetail{
        private LogWriter log = new LogWriter();
        

        public PurchaseOrderDetail(){}
		public PurchaseOrderDetail(
					System.Int32 purchaseorderid,
					System.Int32 purchaseorderdetailid,
					System.DateTime duedate,
					System.Int16 orderqty,
					System.Int32 productid,
					System.Decimal unitprice,
					System.Double numberofcases,
					System.Int32 unitpercase,
					System.Int64 receivedqty,
					System.Int64 rejectedqty,
					System.Int64 stockedqty,
					System.DateTime modifieddate
		){
		this._PurchaseOrderID = purchaseorderid;
		this._PurchaseOrderDetailID = purchaseorderdetailid;
		this._DueDate = duedate;
		this._OrderQty = orderqty;
		this._ProductID = productid;
		this._UnitPrice = unitprice;
		this._NumberOfCases = numberofcases;
		this._UnitPerCase = unitpercase;
		this._ReceivedQty = receivedqty;
		this._RejectedQty = rejectedqty;
		this._StockedQty = stockedqty;
		this._ModifiedDate = modifieddate;
		}
			private System.Int32 _PurchaseOrderID;
			private System.Int32 _PurchaseOrderDetailID;
			private System.DateTime _DueDate;
			private System.Int16 _OrderQty;
			private System.Int32 _ProductID;
			private System.Decimal _UnitPrice;
			private System.Double _NumberOfCases;
			private System.Int32 _UnitPerCase;
			private System.Int64 _ReceivedQty;
			private System.Int64 _RejectedQty;
			private System.Int64 _StockedQty;
			private System.DateTime _ModifiedDate;
		public System.Int32 PurchaseOrderID{
			get{return _PurchaseOrderID;}
			set{ _PurchaseOrderID=value;}
		}
		public System.Int32 PurchaseOrderDetailID{
			get{return _PurchaseOrderDetailID;}
			set{ _PurchaseOrderDetailID=value;}
		}
		public System.DateTime DueDate{
			get{return _DueDate;}
			set{ _DueDate=value;}
		}
		public System.Int16 OrderQty{
			get{return _OrderQty;}
			set{ _OrderQty=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.Decimal UnitPrice{
			get{return _UnitPrice;}
			set{ _UnitPrice=value;}
		}
		public System.Double NumberOfCases{
			get{return _NumberOfCases;}
			set{ _NumberOfCases=value;}
		}
		public System.Int32 UnitPerCase{
			get{return _UnitPerCase;}
			set{ _UnitPerCase=value;}
		}
		public System.Int64 ReceivedQty{
			get{return _ReceivedQty;}
			set{ _ReceivedQty=value;}
		}
		public System.Int64 RejectedQty{
			get{return _RejectedQty;}
			set{ _RejectedQty=value;}
		}
		public System.Int64 StockedQty{
			get{return _StockedQty;}
			set{ _StockedQty=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddPurchaseOrderDetail(PurchaseOrderDetail purchaseorderdetail)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
           int id=0;
            try
            {
                id = data.AddPurchaseOrderDetail(purchaseorderdetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPurchaseOrderDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemovePurchaseOrderDetail(PurchaseOrderDetail purchaseorderdetail)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            bool ret = false;
            try
            {
                ret = data.DeletePurchaseOrderDetail(purchaseorderdetail);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePurchaseOrderDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        private void UpdateInventory(PurchaseOrderDetail pod)
        {
            ProductInventory inv = new ProductInventory();
            inv.ProductID = pod.ProductID;
            inv.Quantity = pod.OrderQty;
            inv.ModifiedDate = DateTime.Now;

            inv.UpdateInventory(inv);
        }
		public bool UpdatePurchaseOrderDetail(PurchaseOrderDetail purchaseorderdetail)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            bool ret = false;
            try
            {
                ret = data.UpdatePurchaseOrderDetail(purchaseorderdetail);
                PurchaseOrderHeader poh = new PurchaseOrderHeader();
                poh = poh.GetPurchaseOrderHeader(this.PurchaseOrderID);
                if (poh.Status == (byte)OrderStatus.Received)
                {
                    UpdateInventory(this);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePurchaseOrderDetail");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public PurchaseOrderDetail GetPurchaseOrderDetails(int purchaseOrderDetailID)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            try
            {
                pod = data.GetPurchaseOrderDetail(purchaseOrderDetailID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOrderDetails");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return pod;
        }
        public DataSet GetAllPurchaseOrderDetailDataSet()
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPurchaseOrderDetailDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseOrderDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseOrderDetailCollection GetAllPurchaseOrderDetailCollection()
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            PurchaseOrderDetailCollection col = new PurchaseOrderDetailCollection();
            try
            {
                col = data.GetAllPurchaseOrderDetailCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseOrderDetailCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

        public DataSet GetPurchaseOrderDetailDataSet(string where, string orderby)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPurchaseOrderDetailDynamicDataSet(where, orderby);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOrderDetailDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PurchaseOrderDetailCollection GetPurchaseOrderDetailCollection(string where, string orderby)
        {
            PurchaseOrderDetailData data = new PurchaseOrderDetailData();
            PurchaseOrderDetailCollection col = new PurchaseOrderDetailCollection();
            try
            {
                col = data.GetAllPurchaseOrderDetailDynamicCollection(where, orderby);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseOrderDetailCollection");
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
