using System;

namespace DataStructure
{
    public class Heap
    {
        public void Sort(IComparable[] a)
        {
            var n = a.Length;
            BuildHeap(a, n);
            while (n > 1)
            {
                Exchange(a, 1, n);
                Sink(a, 1, --n);
            }
        }

        private void BuildHeap(IComparable[] a, Int64 n)
        {
            for (var k = n/2; k >= 1; k--)
            {
                Sink(a, k, n);
            }
        }

        private void Sink(IComparable[] a, Int64 k, Int64 n)
        {
            while (2*k <= n)
            {
                var j = 2*k;
                if (j < n && Less(a, j, j + 1))
                {
                    j++;
                }
                if (Less(a, j, k)) break;

                Exchange(a, k, j);
                k = j;
            }
        }

        private bool Less(IComparable[] a, Int64 i, Int64 j)
        {
            return a[i - 1].CompareTo(a[j - 1]) < 0;
        }

        private void Exchange(IComparable[] a, long i, long j)
        {
            var temp = a[i - 1];
            a[i - 1] = a[j - 1];
            a[j - 1] = temp;
        }
    }
}