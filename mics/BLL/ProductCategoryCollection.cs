using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductCategory types
    /// </summary>
    public class ProductCategoryCollection : CollectionBase
    {
        public ProductCategory this[int index]
        {
            get { return ((ProductCategory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductCategoryCollection() { }

        public int Add(ProductCategory productCategory)
        {
            return (this.List.Add(productCategory));
        }

        public int IndexOf(ProductCategory productCategory)
        {
            return (this.List.IndexOf(productCategory));
        }

        public void Insert(int index, ProductCategory productCategory)
        {
            this.List.Insert(index, productCategory);
        }

        public void Remove(ProductCategory productCategory)
        {
            this.List.Remove(productCategory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductCategory productCategory)
        {
            return this.List.Contains(productCategory);
        }
    }
}
