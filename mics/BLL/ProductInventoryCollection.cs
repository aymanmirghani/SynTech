using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductInventory types
    /// </summary>
    public class ProductInventoryCollection : CollectionBase
    {
        public ProductInventory this[int index]
        {
            get { return ((ProductInventory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductInventoryCollection() { }

        public int Add(ProductInventory productInventory)
        {
            return (this.List.Add(productInventory));
        }

        public int IndexOf(ProductInventory productInventory)
        {
            return (this.List.IndexOf(productInventory));
        }

        public void Insert(int index, ProductInventory productInventory)
        {
            this.List.Insert(index, productInventory);
        }

        public void Remove(ProductInventory productInventory)
        {
            this.List.Remove(productInventory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductInventory productInventory)
        {
            return this.List.Contains(productInventory);
        }
    }
}
