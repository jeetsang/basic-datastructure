using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class KnuthSuffle
    {
        public static void Shuffle(object[] a)
        {
            var length = a.Length;
            for (var i = 0; i < length; i++)
            {
                var random = new Random();
                var r = random.Next(i + 1);
                Exchange(a,i,r);
            }
        }

        private static void Exchange(IList<object> a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}