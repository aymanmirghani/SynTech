using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesOrderHeader types
    /// </summary>
    public class SalesOrderHeaderCollection : CollectionBase
    {
        public SalesOrderHeader this[int index]
        {
            get { return ((SalesOrderHeader)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesOrderHeaderCollection() { }

        public int Add(SalesOrderHeader salesorderheader)
        {
            return (this.List.Add(salesorderheader));
        }

        public int IndexOf(SalesOrderHeader salesorderheader)
        {
            return (this.List.IndexOf(salesorderheader));
        }

        public void Insert(int index, SalesOrderHeader salesorderheader)
        {
            this.List.Insert(index, salesorderheader);
        }

        public void Remove(SalesOrderHeader salesorderheader)
        {
            this.List.Remove(salesorderheader);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesOrderHeader salesorderheader)
        {
            return this.List.Contains(salesorderheader);
        }
    }
}
