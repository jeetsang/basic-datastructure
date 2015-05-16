using System;

namespace DataStructure
{
    public class InsertationSort
    {
        public static void Sort(IComparable[] a)
        {
            var N = a.Length;
            for (var i = 0; i < N; i++)
            {
                for (var j = i; j > 0; j--)
                {
                    if (Less(a[j], a[j - 1]))
                    {
                        Exchange(a, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
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