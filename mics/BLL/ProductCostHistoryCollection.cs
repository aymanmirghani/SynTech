using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductCostHistory types
    /// </summary>
    public class ProductCostHistoryCollection : CollectionBase
    {
        public ProductCostHistory this[int index]
        {
            get { return ((ProductCostHistory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductCostHistoryCollection() { }

        public int Add(ProductCostHistory productCostHistory)
        {
            return (this.List.Add(productCostHistory));
        }

        public int IndexOf(ProductCostHistory productCostHistory)
        {
            return (this.List.IndexOf(productCostHistory));
        }

        public void Insert(int index, ProductCostHistory productCostHistory)
        {
            this.List.Insert(index, productCostHistory);
        }

        public void Remove(ProductCostHistory productCostHistory)
        {
            this.List.Remove(productCostHistory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductCostHistory productCostHistory)
        {
            return this.List.Contains(productCostHistory);
        }
    }
}
