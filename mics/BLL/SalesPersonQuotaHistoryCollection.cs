using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesPersonQuotaHistory types
    /// </summary>
    public class SalesPersonQuotaHistoryCollection : CollectionBase
    {
        public SalesPersonQuotaHistory this[int index]
        {
            get { return ((SalesPersonQuotaHistory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesPersonQuotaHistoryCollection() { }

        public int Add(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            return (this.List.Add(salesPersonQuotaHistory));
        }

        public int IndexOf(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            return (this.List.IndexOf(salesPersonQuotaHistory));
        }

        public void Insert(int index, SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            this.List.Insert(index, salesPersonQuotaHistory);
        }

        public void Remove(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            this.List.Remove(salesPersonQuotaHistory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            return this.List.Contains(salesPersonQuotaHistory);
        }
    }
}
