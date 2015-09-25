using System;

namespace DataStructure
{
    /// <summary>
    /// Max priority queue with Heap implementation.
    /// </summary>
    //TODO Replace fixed size array with dynamic array 
    public class MaxPq<TKey> where TKey : IComparable<TKey>
    {
        private int n;
        private readonly TKey[] pq;

        public MaxPq(int capacity)
        {
            n = 0;
            pq = new TKey[capacity + 1];
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public void Insert(TKey key)
        {
            pq[++n] = key;
            Swim(n);
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Exchange(k, k/2);
                k = k/2;
            }
        }

        private void Exchange(int i, int j)
        {
            var temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        public TKey DelMax()
        {
            var maxKey = pq[1];
            Exchange(1, n--);
            Sink(1);
            pq[n + 1] = default(TKey);
            return maxKey;
        }

        private void Sink(int k)
        {
            while (2*k <= n)
            {
                var j = 2*k;
                if (j < n && Less(j, j + 1))
                {
                    j++;
                }
                if (Less(j, k)) break;

                Exchange(k, j);
                k = j;
            }
        }
    }
}