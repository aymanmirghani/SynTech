using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of PurchaseOrderDetail types
    /// </summary>
    public class PurchaseOrderDetailCollection : CollectionBase
    {
        public PurchaseOrderDetail this[int index]
        {
            get { return ((PurchaseOrderDetail)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PurchaseOrderDetailCollection() { }

        public int Add(PurchaseOrderDetail purchaseOrderDetail)
        {
            return (this.List.Add(purchaseOrderDetail));
        }

        public int IndexOf(PurchaseOrderDetail purchaseOrderDetail)
        {
            return (this.List.IndexOf(purchaseOrderDetail));
        }

        public void Insert(int index, PurchaseOrderDetail purchaseOrderDetail)
        {
            this.List.Insert(index, purchaseOrderDetail);
        }

        public void Remove(PurchaseOrderDetail purchaseOrderDetail)
        {
            this.List.Remove(purchaseOrderDetail);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(PurchaseOrderDetail purchaseOrderDetail)
        {
            return this.List.Contains(purchaseOrderDetail);
        }
    }
}
