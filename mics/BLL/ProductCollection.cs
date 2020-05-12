using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Product types
    /// </summary>
    public class ProductCollection : CollectionBase
    {
        public Product this[int index]
        {
            get { return ((Product)this.List[index]); 
            }
            set { this.List[index] = value; }
        }

        public ProductCollection() { }

        public int Add(Product product)
        {
            return (this.List.Add(product));
        }

        public int IndexOf(Product product)
        {
            return (this.List.IndexOf(product));
        }

        public void Insert(int index, Product product)
        {
            this.List.Insert(index, product);
        }

        public void Remove(Product product)
        {
            this.List.Remove(product);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Product product)
        {
            return this.List.Contains(product);
        }
    }
}
