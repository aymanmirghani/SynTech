using System;
using System.Collections.Generic;
using System.Text;

namespace MICS.BLL
{
    #region Enumerations
   
    public class OrderStatusObject
    {
        public OrderStatusObject()
        {
        }
        public OrderStatusObject(byte id, string name)
        {
            this.id = id;
            this.name = name;
        }
        byte id;
        string name;
        public byte ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    #endregion
    
    public class OrderEventsArgs : EventArgs
    {
        private int _ProductID;
        private long _Quantity;
       
        public int ProductID
        {
            get { return _ProductID; }
        }
        public long Quantity
        {
            get { return _Quantity; }
        }
       
        public OrderEventsArgs(int productId, long quantity)
        {
            _ProductID = productId;
            _Quantity = quantity;
            
        }
       
    }
    //public delegate void OrderEventsHandler(object sender, OrderEventsArgs e);
}
