using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Vendor types
    /// </summary>
    public class VendorCollection : CollectionBase
    {
        public Vendor this[int index]
        {
            get { return ((Vendor)this.List[index]); }
            set { this.List[index] = value; }
        }

        public VendorCollection() { }

        public int Add(Vendor vendor)
        {
            return (this.List.Add(vendor));
        }

        public int IndexOf(Vendor vendor)
        {
            return (this.List.IndexOf(vendor));
        }

        public void Insert(int index, Vendor vendor)
        {
            this.List.Insert(index, vendor);
        }

        public void Remove(Vendor vendor)
        {
            this.List.Remove(vendor);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Vendor vendor)
        {
            return this.List.Contains(vendor);
        }
    }
}
