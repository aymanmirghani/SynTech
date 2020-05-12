using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesInvoiceHeader types
    /// </summary>
    public class SalesInvoiceHeaderCollection : CollectionBase
    {
        public SalesInvoiceHeader this[int index]
        {
            get { return ((SalesInvoiceHeader)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesInvoiceHeaderCollection() { }

        public int Add(SalesInvoiceHeader salesInvoiceHeader)
        {
            return (this.List.Add(salesInvoiceHeader));
        }

        public int IndexOf(SalesInvoiceHeader salesInvoiceHeader)
        {
            return (this.List.IndexOf(salesInvoiceHeader));
        }

        public void Insert(int index, SalesInvoiceHeader salesInvoiceHeader)
        {
            this.List.Insert(index, salesInvoiceHeader);
        }

        public void Remove(SalesInvoiceHeader salesInvoiceHeader)
        {
            this.List.Remove(salesInvoiceHeader);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesInvoiceHeader salesInvoiceHeader)
        {
            return this.List.Contains(salesInvoiceHeader);
        }
    }
}
