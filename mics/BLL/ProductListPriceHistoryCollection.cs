using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductListPriceHistory types
    /// </summary>
    public class ProductListPriceHistoryCollection : CollectionBase
    {
        public ProductListPriceHistory this[int index]
        {
            get { return ((ProductListPriceHistory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductListPriceHistoryCollection() { }

        public int Add(ProductListPriceHistory productListPriceHistory)
        {
            return (this.List.Add(productListPriceHistory));
        }

        public int IndexOf(ProductListPriceHistory productListPriceHistory)
        {
            return (this.List.IndexOf(productListPriceHistory));
        }

        public void Insert(int index, ProductListPriceHistory productListPriceHistory)
        {
            this.List.Insert(index, productListPriceHistory);
        }

        public void Remove(ProductListPriceHistory productListPriceHistory)
        {
            this.List.Remove(productListPriceHistory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductListPriceHistory productListPriceHistory)
        {
            return this.List.Contains(productListPriceHistory);
        }
    }
}
