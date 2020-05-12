using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of PaymentMethod types
    /// </summary>
    public class PaymentMethodCollection : CollectionBase
    {
        public PaymentMethod this[int index]
        {
            get { return ((PaymentMethod)this.List[index]); }
            set { this.List[index] = value; }
        }

        public PaymentMethodCollection() { }

        public int Add(PaymentMethod paymentMethod)
        {
            return (this.List.Add(paymentMethod));
        }

        public int IndexOf(PaymentMethod paymentMethod)
        {
            return (this.List.IndexOf(paymentMethod));
        }

        public void Insert(int index, PaymentMethod paymentMethod)
        {
            this.List.Insert(index, paymentMethod);
        }

        public void Remove(PaymentMethod paymentMethod)
        {
            this.List.Remove(paymentMethod);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(PaymentMethod paymentMethod)
        {
            return this.List.Contains(paymentMethod);
        }
    }
}
