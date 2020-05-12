using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SpecialOfferProduct types
    /// </summary>
    public class SpecialOfferProductCollection : CollectionBase
    {
        public SpecialOfferProduct this[int index]
        {
            get { return ((SpecialOfferProduct)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SpecialOfferProductCollection() { }

        public int Add(SpecialOfferProduct specialOfferProduct)
        {
            return (this.List.Add(specialOfferProduct));
        }

        public int IndexOf(SpecialOfferProduct specialOfferProduct)
        {
            return (this.List.IndexOf(specialOfferProduct));
        }

        public void Insert(int index, SpecialOfferProduct specialOfferProduct)
        {
            this.List.Insert(index, specialOfferProduct);
        }

        public void Remove(SpecialOfferProduct specialOfferProduct)
        {
            this.List.Remove(specialOfferProduct);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SpecialOfferProduct specialOfferProduct)
        {
            return this.List.Contains(specialOfferProduct);
        }
    }
}
