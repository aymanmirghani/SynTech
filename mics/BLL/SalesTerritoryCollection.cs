using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of SalesTerritory types
    /// </summary>
    public class SalesTerritoryCollection : CollectionBase
    {
        public SalesTerritory this[int index]
        {
            get { return ((SalesTerritory)this.List[index]); }
            set { this.List[index] = value; }
        }

        public SalesTerritoryCollection() { }

        public int Add(SalesTerritory saleTerritory)
        {
            return (this.List.Add(saleTerritory));
        }

        public int IndexOf(SalesTerritory saleTerritory)
        {
            return (this.List.IndexOf(saleTerritory));
        }

        public void Insert(int index, SalesTerritory saleTerritory)
        {
            this.List.Insert(index, saleTerritory);
        }

        public void Remove(SalesTerritory saleTerritory)
        {
            this.List.Remove(saleTerritory);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(SalesTerritory saleTerritory)
        {
            return this.List.Contains(saleTerritory);
        }
    }
}
