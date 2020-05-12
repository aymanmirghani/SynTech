using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesInvoiceDetail types
    /// </summary>
    public class SalesInvoiceDetailCollection : CollectionBase
    {
        public SalesInvoiceDetail this[int index]
        {
            get { return ((SalesInvoiceDetail)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesInvoiceDetailCollection() { }

        public int Add(SalesInvoiceDetail salesInvoiceDetail)
        {
            return (this.List.Add(salesInvoiceDetail));
        }

        public int IndexOf(SalesInvoiceDetail salesInvoiceDetail)
        {
            return (this.List.IndexOf(salesInvoiceDetail));
        }

        public void Insert(int index, SalesInvoiceDetail salesInvoiceDetail)
        {
            this.List.Insert(index, salesInvoiceDetail);
        }

        public void Remove(SalesInvoiceDetail salesInvoiceDetail)
        {
            this.List.Remove(salesInvoiceDetail);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesInvoiceDetail salesInvoiceDetail)
        {
            return this.List.Contains(salesInvoiceDetail);
        }
    }
}
