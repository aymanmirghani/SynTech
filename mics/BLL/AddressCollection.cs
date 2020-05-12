using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Address types
    /// </summary>
    public class AddressCollection : CollectionBase
    {
        public Address this[int index]
        {
            get { return ((Address)this.List[index]); }
            set { this.List[index] = value; }
        }

        public AddressCollection() { }

        public int Add(Address address)
        {
            return (this.List.Add(address));
        }

        public int IndexOf(Address address)
        {
            return (this.List.IndexOf(address));
        }

        public void Insert(int index, Address address)
        {
            this.List.Insert(index, address);
        }

        public void Remove(Address address)
        {
            this.List.Remove(address);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Address address)
        {
            return this.List.Contains(address);
        }
    }
}
