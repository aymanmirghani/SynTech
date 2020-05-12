using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of PurchaseInvoiceDetail types
    /// </summary>
    public class PurchaseInvoiceDetailCollection : CollectionBase
    {
        public PurchaseInvoiceDetail this[int index]
        {
            get { return ((PurchaseInvoiceDetail)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PurchaseInvoiceDetailCollection() { }

        public int Add(PurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            return (this.List.Add(purchaseInvoiceDetail));
        }

        public int IndexOf(PurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            return (this.List.IndexOf(purchaseInvoiceDetail));
        }

        public void Insert(int index, PurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            this.List.Insert(index, purchaseInvoiceDetail);
        }

        public void Remove(PurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            this.List.Remove(purchaseInvoiceDetail);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(PurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            return this.List.Contains(purchaseInvoiceDetail);
        }
    }
}
