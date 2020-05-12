using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of PurchaseOrderHeader types
    /// </summary>
    public class PurchaseOrderHeaderCollection : CollectionBase
    {
        public PurchaseOrderHeader this[int index]
        {
            get { return ((PurchaseOrderHeader)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PurchaseOrderHeaderCollection() { }

        public int Add(PurchaseOrderHeader purchaseOrderHeader)
        {
            return (this.List.Add(purchaseOrderHeader));
        }

        public int IndexOf(PurchaseOrderHeader purchaseOrderHeader)
        {
            return (this.List.IndexOf(purchaseOrderHeader));
        }

        public void Insert(int index, PurchaseOrderHeader purchaseOrderHeader)
        {
            this.List.Insert(index, purchaseOrderHeader);
        }

        public void Remove(PurchaseOrderHeader purchaseOrderHeader)
        {
            this.List.Remove(purchaseOrderHeader);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(PurchaseOrderHeader purchaseOrderHeader)
        {
            return this.List.Contains(purchaseOrderHeader);
        }
    }
}
