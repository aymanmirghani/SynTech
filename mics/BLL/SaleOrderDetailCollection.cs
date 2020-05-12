using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Customer types
    /// </summary>
    public class SalesOrderDetailCollection : CollectionBase
    {
        
        public SalesOrderDetail this[int index]
        {
            get { return ((SalesOrderDetail)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesOrderDetailCollection() { }

        public int Add(SalesOrderDetail saleOrderDetail)
        {
            return (this.List.Add(saleOrderDetail));
        }

        public int IndexOf(SalesOrderDetail saleOrderDetail)
        {
            
            return (this.List.IndexOf(saleOrderDetail));
        }

        public void Insert(int index, SalesOrderDetail saleOrderDetail)
        {
            this.List.Insert(index, saleOrderDetail);
        }

        public void Remove(SalesOrderDetail saleOrderDetail)
        {
            this.List.Remove(saleOrderDetail);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesOrderDetail saleOrderDetail)
        {
            return this.List.Contains(saleOrderDetail);
        }
    }
}
