namespace DataStructure
{
    public class WeightedQuickUnionFind
    {
        private int[] id;
        private int[] size;

        public WeightedQuickUnionFind(int N)
        {
            id = new int[N];
            size =new int[N];
            for (var i = 0; i < N; i++)
            {
                id[i] = i;
                size[i] = 1;
            }
        }

        private int Root(int i)
        {
            while (i!=id[i])
            {
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            var i = Root(p);
            var j = Root(q);
            if (size[i] > size[j])
            {
                id[j] = i;
                size[i] = size[i] + size[j];
            }
            else
            {
                id[i] = j;
                size[j] = size[j] + size[i];
            }
        }
    }
}