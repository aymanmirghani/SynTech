using System;
using System.Collections;

namespace MICS.BLL
{
    /// <summary>
    /// Encapsulates a collection of Employee types
    /// </summary>
    public class EmployeeCollection : CollectionBase
    {
        public Employee this[int index]
        {
            get { return ((Employee)this.List[index]); }
            set { this.List[index] = value; }
        }

        public EmployeeCollection() { }

        public int Add(Employee employee)
        {
            return (this.List.Add(employee));
        }

        public int IndexOf(Employee employee)
        {
            return (this.List.IndexOf(employee));
        }

        public void Insert(int index, Employee employee)
        {
            this.List.Insert(index, employee);
        }

        public void Remove(Employee employee)
        {
            this.List.Remove(employee);
        }

        public new void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public bool Contains(Employee employee)
        {
            return this.List.Contains(employee);
        }
    }
}
