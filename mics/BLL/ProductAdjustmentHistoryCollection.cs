using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductAdjustmentHistory types
    /// </summary>
    public class ProductAdjustmentHistoryCollection : CollectionBase
    {
        public ProductAdjustmentHistory this[int index]
        {
            get { return ((ProductAdjustmentHistory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductAdjustmentHistoryCollection() { }

        public int Add(ProductAdjustmentHistory productAdjustmentHistory)
        {
            return (this.List.Add(productAdjustmentHistory));
        }

        public int IndexOf(ProductAdjustmentHistory productAdjustmentHistory)
        {
            return (this.List.IndexOf(productAdjustmentHistory));
        }

        public void Insert(int index, ProductAdjustmentHistory productAdjustmentHistory)
        {
            this.List.Insert(index, productAdjustmentHistory);
        }

        public void Remove(ProductAdjustmentHistory productAdjustmentHistory)
        {
            this.List.Remove(productAdjustmentHistory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductAdjustmentHistory productAdjustmentHistory)
        {
            return this.List.Contains(productAdjustmentHistory);
        }
    }
}
