using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Customer types
    /// </summary>
    public class CustomerCollection : CollectionBase
    {
        public Customer this[int index]
        {
            get { return ((Customer)this.List[index]); }
            set { this.List[index] = value; }
        }

        public CustomerCollection() { }

        public int Add(Customer customer)
        {
            return (this.List.Add(customer));
        }

        public int IndexOf(Customer customer)
        {
            return (this.List.IndexOf(customer));
        }

        public void Insert(int index, Customer customer)
        {
            this.List.Insert(index, customer);
        }

        public void Remove(Customer customer)
        {
            this.List.Remove(customer);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Customer customer)
        {
            return this.List.Contains(customer);
        }
    }
}
