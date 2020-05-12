using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ProductVendor types
    /// </summary>
    public class ProductVendorCollection : CollectionBase
    {
        public ProductVendor this[int index]
        {
            get { return ((ProductVendor)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ProductVendorCollection() { }

        public int Add(ProductVendor productVendor)
        {
            return (this.List.Add(productVendor));
        }

        public int IndexOf(ProductVendor productVendor)
        {
            return (this.List.IndexOf(productVendor));
        }

        public void Insert(int index, ProductVendor productVendor)
        {
            this.List.Insert(index, productVendor);
        }

        public void Remove(ProductVendor productVendor)
        {
            this.List.Remove(productVendor);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ProductVendor productVendor)
        {
            return this.List.Contains(productVendor);
        }
    }
}
