using System;

namespace DataStructureTest
{
    public class RandomNumberGenerator
    {
        public static IComparable[] GetIntegerArrayOf(Int64 length)
        {
            var random = new Random();
            var integers = new IComparable[length];
            for (var i = 0; i < length; i++)
            {
                integers[i] = new Integer(random.Next());
            }

            return integers;
        }
    }
}