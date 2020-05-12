using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SpecialOffer types
    /// </summary>
    public class SpecialOfferCollection : CollectionBase
    {
        public SpecialOffer this[int index]
        {
            get { return ((SpecialOffer)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SpecialOfferCollection() { }

        public int Add(SpecialOffer specialOffer)
        {
            return (this.List.Add(specialOffer));
        }

        public int IndexOf(SpecialOffer specialOffer)
        {
            return (this.List.IndexOf(specialOffer));
        }

        public void Insert(int index, SpecialOffer specialOffer)
        {
            this.List.Insert(index, specialOffer);
        }

        public void Remove(SpecialOffer specialOffer)
        {
            this.List.Remove(specialOffer);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SpecialOffer specialOffer)
        {
            return this.List.Contains(specialOffer);
        }
    }
}
