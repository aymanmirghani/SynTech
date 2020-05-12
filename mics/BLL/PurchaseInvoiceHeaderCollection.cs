using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of PurchaseInvoiceHeader types
    /// </summary>
    public class PurchaseInvoiceHeaderCollection : CollectionBase
    {
        public PurchaseInvoiceHeader this[int index]
        {
            get { return ((PurchaseInvoiceHeader)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PurchaseInvoiceHeaderCollection() { }

        public int Add(PurchaseInvoiceHeader purchaseInvoiceHeader)
        {
            return (this.List.Add(purchaseInvoiceHeader));
        }

        public int IndexOf(PurchaseInvoiceHeader purchaseInvoiceHeader)
        {
            return (this.List.IndexOf(purchaseInvoiceHeader));
        }

        public void Insert(int index, PurchaseInvoiceHeader purchaseInvoiceHeader)
        {
            this.List.Insert(index, purchaseInvoiceHeader);
        }

        public void Remove(PurchaseInvoiceHeader purchaseInvoiceHeader)
        {
            this.List.Remove(purchaseInvoiceHeader);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(PurchaseInvoiceHeader purchaseInvoiceHeader)
        {
            return this.List.Contains(purchaseInvoiceHeader);
        }
    }
}
