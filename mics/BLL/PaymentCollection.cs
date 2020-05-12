using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Payment types
    /// </summary>
    public class PaymentCollection : CollectionBase
    {
        public Payment this[int index]
        {
            get { return ((Payment)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PaymentCollection() { }

        public int Add(Payment payment)
        {
            return (this.List.Add(payment));
        }

        public int IndexOf(Payment payment)
        {
            return (this.List.IndexOf(payment));
        }

        public void Insert(int index, Payment payment)
        {
            this.List.Insert(index, payment);
        }

        public void Remove(Payment payment)
        {
            this.List.Remove(payment);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Payment payment)
        {
            return this.List.Contains(payment);
        }
    }
}
