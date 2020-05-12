using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductSubcategory types
    /// </summary>
    public class ProductSubcategoryCollection : CollectionBase
    {
        public ProductSubcategory this[int index]
        {
            get { return ((ProductSubcategory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductSubcategoryCollection() { }

        public int Add(ProductSubcategory productSubcategory)
        {
            return (this.List.Add(productSubcategory));
        }

        public int IndexOf(ProductSubcategory productSubcategory)
        {
            return (this.List.IndexOf(productSubcategory));
        }

        public void Insert(int index, ProductSubcategory productSubcategory)
        {
            this.List.Insert(index, productSubcategory);
        }

        public void Remove(ProductSubcategory productSubcategory)
        {
            this.List.Remove(productSubcategory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductSubcategory productSubcategory)
        {
            return this.List.Contains(productSubcategory);
        }
    }
}
