using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesTerritoryHistory types
    /// </summary>
    public class SalesTerritoryHistoryCollection : CollectionBase
    {
        public SalesTerritoryHistory this[int index]
        {
            get { return ((SalesTerritoryHistory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesTerritoryHistoryCollection() { }

        public int Add(SalesTerritoryHistory saleTerritoryHistory)
        {
            return (this.List.Add(saleTerritoryHistory));
        }

        public int IndexOf(SalesTerritoryHistory saleTerritoryHistory)
        {
            return (this.List.IndexOf(saleTerritoryHistory));
        }

        public void Insert(int index, SalesTerritoryHistory saleTerritoryHistory)
        {
            this.List.Insert(index, saleTerritoryHistory);
        }

        public void Remove(SalesTerritoryHistory saleTerritoryHistory)
        {
            this.List.Remove(saleTerritoryHistory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesTerritoryHistory saleTerritoryHistory)
        {
            return this.List.Contains(saleTerritoryHistory);
        }
    }
}
