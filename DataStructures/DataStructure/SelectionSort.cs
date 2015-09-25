using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class SelectionSort
    {
        public static void Sort(IComparable[] a)
        {
            var N = a.Length;

            for (var i = 0; i < N; i++)
            {
                var min = i;
                for (var j = i; j < N; j++)
                {
                    if (Less(a[j], a[min]))
                    {
                        min = j;
                    }
                }
                Exchange(a, i, min);
            }
        }

        private static void Exchange(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private static bool Less(IComparable a, IComparable b)
        {
            return a.CompareTo(b) < 0;
        }

        private static bool IsSorted(IComparable[] a)
        {
            for (int i = 1, n = a.Length; i < n; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }
    }
}