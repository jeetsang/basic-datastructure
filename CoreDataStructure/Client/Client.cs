using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
           //For Testing Purpose

            IComparable[] a = {1, 4, 3, 2, 9, 8, 3};
            InsertationSort.Sort(a);
            foreach (var comparable in a)
            {
                Console.WriteLine(comparable);
            }

            Console.ReadKey();


        }
    }
}
