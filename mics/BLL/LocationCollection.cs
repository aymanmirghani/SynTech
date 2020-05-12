using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Location types
    /// </summary>
    public class LocationCollection : CollectionBase
    {
        public Location this[int index]
        {
            get { return ((Location)this.List[index]); }
            set { this.List[index] = value; }
        }

        public LocationCollection() { }

        public int Add(Location location)
        {
            return (this.List.Add(location));
        }

        public int IndexOf(Location location)
        {
            return (this.List.IndexOf(location));
        }

        public void Insert(int index, Location location)
        {
            this.List.Insert(index, location);
        }

        public void Remove(Location location)
        {
            this.List.Remove(location);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Location location)
        {
            return this.List.Contains(location);
        }
    }
}
