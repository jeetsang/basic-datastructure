using System;

namespace DataStructureTest
{
    public class Integer : IComparable
    {
        private readonly long value;

        public long Value
        {
            get { return value; }
        }

        public Integer(long value)
        {
            this.value = value;
        }

        public int CompareTo(Integer other)
        {
            return value.CompareTo(other.value);
        }

        public int CompareTo(object obj)
        {
            var integer = obj as Integer;
            if (integer != null) return value.CompareTo(integer.value);
            return -1;
        }
    }
}