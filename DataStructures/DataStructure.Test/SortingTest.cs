using DataStructure;
using NUnit.Framework;

namespace DataStructureTest
{
    [TestFixture]
    public class SortingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, MaxTime(4000)]
        public void HeapSortShouldCompleteInSpecifiedTimeForHugeN()
        {
            var heapSort = new Heap();
            const int oneMillion = 1000000;
            var integerArray = RandomNumberGenerator.GetIntegerArrayOf(oneMillion);
            heapSort.Sort(integerArray);
        }

        [Test]
        public void HeapSortShouldSortData()
        {
            var heapSort = new Heap();
            const int oneMillion = 1000000;
            var expected = true;
            var integerArray = RandomNumberGenerator.GetIntegerArrayOf(oneMillion);
            heapSort.Sort(integerArray);
            for (var i = 0; i < oneMillion - 1; i++)
            {
                if (integerArray[i + 1].CompareTo(integerArray[i]) >= 0) continue;
                expected = false;
                break;
            }
            Assert.IsTrue(expected);
        }
    }
}