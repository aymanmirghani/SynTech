using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesTaxRate types
    /// </summary>
    public class SalesTaxRateCollection : CollectionBase
    {
        public SalesTaxRate this[int index]
        {
            get { return ((SalesTaxRate)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesTaxRateCollection() { }

        public int Add(SalesTaxRate salesTaxRate)
        {
            return (this.List.Add(salesTaxRate));
        }

        public int IndexOf(SalesTaxRate salesTaxRate)
        {
            return (this.List.IndexOf(salesTaxRate));
        }

        public void Insert(int index, SalesTaxRate salesTaxRate)
        {
            this.List.Insert(index, salesTaxRate);
        }

        public void Remove(SalesTaxRate salesTaxRate)
        {
            this.List.Remove(salesTaxRate);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesTaxRate salesTaxRate)
        {
            return this.List.Contains(salesTaxRate);
        }
    }
}
