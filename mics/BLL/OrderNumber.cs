
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
    public class OrderNumber
    {
        private LogWriter log = new LogWriter();
        private int _Id = 0;

       
        private int _orderType = 0;
        private DateTime _todaysDate = DateTime.Now;
        private int _sequenceNumber = 0;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int Ordertype
        {
            get { return _orderType; }
            set { _orderType = value; }
        }
      
        public DateTime TodaysDate
        {
            get { return _todaysDate; }
            set { _todaysDate = value; }
        }
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set { _sequenceNumber = value; }
        }
        public OrderNumber()
        {
        }
        public OrderNumber(OrderType orderType) 
        { 

        }
        public string GetNextNumber(OrderType ot)
        {
            OrderNumberData data = new OrderNumberData();
            DateTime today = DateTime.Today;
            string prefix = String.Empty;
            switch (ot)
            {
                case OrderType.SaleOrder:
                    prefix = "SO_";
                    break;
                case OrderType.SaleInvoice:
                    prefix = "SI_";
                    break;
                case OrderType.PurchaseOrder:
                    prefix = "PO_";
                    break;
                case OrderType.PurchaseInvoice:
                    prefix = "PI_";
                    break;
            }
            string returnedValue = String.Empty;
            if (FirstOrderOfTheDay(ot))
            {
                int seq = 1;
                AddNewEntry(today, ot, 1);
                returnedValue =prefix + today.ToString("yyyyMMdd") + "-" + seq.ToString("000");
            }
            else
            {
                string ret = GetMaxSequence(ot);
                if (ret != String.Empty)
                {
                    int seqno = Int32.Parse(ret); 
                    AddNewEntry(today, ot, seqno);
                    returnedValue = prefix + today.ToString("yyyyMMdd") + "-" + ret;

                }
            }
            return returnedValue;
            
        }
       
        private bool FirstOrderOfTheDay(OrderType ot)
        {
            OrderNumberData data = new OrderNumberData();
            DateTime today = DateTime.Today;
            List<OrderNumber> list = new List<OrderNumber>();
            string where = "[today]='" + today.ToShortDateString()+ "' and ordertype =" + (int)ot;
            try
            {
                list = data.GetOrderNumber(where);
                if (list.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "FirstOrderOfTheDay");
                throw (ex);
            }
            
            
        }
        private string GetMaxSequence(OrderType ot)
        {
            List<OrderNumber> list = new List<OrderNumber>();
            OrderNumberData data = new OrderNumberData();
            DateTime today = DateTime.Today;
            string where = "[today]='" + today.ToString("MM/dd/yyyy")+ "' and ordertype =" + (int)ot ;
            try
            {
                list = data.GetOrderNumber(where);
                if (list.Count > 0)
                {
                    data.DeleteOrderNumber(list[0].Id);
                    int seqno = list[0].SequenceNumber + 1;
                    return seqno.ToString("000");
                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetMaxSequence");

            }
            return String.Empty;
        }
        private int AddNewEntry(DateTime todaysDate, OrderType orderType, int sequenceNumber)
        {
            OrderNumberData data = new OrderNumberData();
            OrderNumber orderNumber = new OrderNumber();
            orderNumber.TodaysDate = todaysDate;
            orderNumber.SequenceNumber = sequenceNumber;
            orderNumber.Ordertype = (int) orderType;

            return (data.AddOrderNumber(orderNumber));
        }
    }
}
