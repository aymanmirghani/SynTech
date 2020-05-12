using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesPerson types
    /// </summary>
    public class SalesPersonCollection : CollectionBase
    {
        public SalesPerson this[int index]
        {
            get { return ((SalesPerson)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesPersonCollection() { }

        public int Add(SalesPerson salesPerson)
        {
            return (this.List.Add(salesPerson));
        }

        public int IndexOf(SalesPerson salesPerson)
        {
            return (this.List.IndexOf(salesPerson));
        }

        public void Insert(int index, SalesPerson salesPerson)
        {
            this.List.Insert(index, salesPerson);
        }

        public void Remove(SalesPerson salesPerson)
        {
            this.List.Remove(salesPerson);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesPerson salesPerson)
        {
            return this.List.Contains(salesPerson);
        }
    }
}
