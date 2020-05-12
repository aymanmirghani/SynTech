using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of ShipMethod types
    /// </summary>
    public class ShipMethodCollection : CollectionBase
    {
        public ShipMethod this[int index]
        {
            get { return ((ShipMethod)this.List[index]); }
            set { this.List[index] = value; }
        }

        public ShipMethodCollection() { }

        public int Add(ShipMethod shipMethod)
        {
            return (this.List.Add(shipMethod));
        }

        public int IndexOf(ShipMethod shipMethod)
        {
            return (this.List.IndexOf(shipMethod));
        }

        public void Insert(int index, ShipMethod shipMethod)
        {
            this.List.Insert(index, shipMethod);
        }

        public void Remove(ShipMethod shipMethod)
        {
            this.List.Remove(shipMethod);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(ShipMethod shipMethod)
        {
            return this.List.Contains(shipMethod);
        }
    }
}
