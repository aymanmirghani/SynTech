using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of User types
    /// </summary>
    public class UserCollection : CollectionBase
    {
        public User this[int index]
        {
            get { return ((User)this.List[index]); }
            set { this.List[index] = value; }
        }

        public UserCollection() { }

        public int Add(User user)
        {
            return (this.List.Add(user));
        }

        public int IndexOf(User user)
        {
            return (this.List.IndexOf(user));
        }

        public void Insert(int index, User user)
        {
            this.List.Insert(index, user);
        }

        public void Remove(User user)
        {
            this.List.Remove(user);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(User user)
        {
            return this.List.Contains(user);
        }
    }
}
