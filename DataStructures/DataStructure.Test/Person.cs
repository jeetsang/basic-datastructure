using System;

namespace DataStructureTest
{
    public class Person:IComparable<Person>
    {
        public string Name { get; set; }
       
        public int CompareTo(Person other)
        {
           return String.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}