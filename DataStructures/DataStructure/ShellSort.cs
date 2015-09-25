using System;

namespace DataStructure
{
    public class ShellSort
    {
        public static void Sort(IComparable[] a)
        {
            var n = a.Length;
            var h = 1;
            while (h<n/3)
            {
                h = h*3 + 1;
            }

            while (h>=1)
            {
                for (var i = h; i < n; i++)
                {
                    for (var j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exchange(a,j,j-h);
                    }
                }

                h = h/3;
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