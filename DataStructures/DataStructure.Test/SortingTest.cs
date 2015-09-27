using System;
using DataStructure;
using NUnit.Framework;

namespace DataStructureTest
{
    [TestFixture]
    public class SortingTest
    {
        private const int OneMillion = 1000000;
        private IComparable[] sortingData;

        [SetUp]
        public void Setup()
        {
            sortingData = RandomNumberGenerator.GetIntegerArrayOf(OneMillion);
        }

        [Test, MaxTime(4000)]
        public void HeapSortShouldCompleteInSpecifiedTimeForHugeN()
        {
            var heapSort = new Heap();
            heapSort.Sort(sortingData);
        }

        [Test]
        public void HeapSortShouldSortData()
        {
            var heapSort = new Heap();
            var expected = true;
            heapSort.Sort(sortingData);
            for (var i = 0; i < OneMillion - 1; i++)
            {
                if (sortingData[i + 1].CompareTo(sortingData[i]) >= 0) continue;
                expected = false;
                break;
            }
            Assert.IsTrue(expected);
        }
    }
}