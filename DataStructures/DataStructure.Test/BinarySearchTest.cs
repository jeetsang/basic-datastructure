using System;
using DataStructure;
using NUnit.Framework;

namespace DataStructureTest
{
    [TestFixture]
    public class BinarySearchTest
    {
        private BinarySearchTree<string, string> bst;
        private const int BstSize = 9;
        private const string Maxkey = "X";
        private const string Minkey = "A";

        [SetUp]
        public void Setup()
        {
            bst = new BinarySearchTree<string, string>();
            bst.Put("S","S");
            bst.Put("E","E");
            bst.Put("X","X");
            bst.Put("A","A");
            bst.Put("R","R");
            bst.Put("C","C");
            bst.Put("H","H");
            bst.Put("G","G");
            bst.Put("M","M");
        }

        [Test]
        public void BstShouldReturnTheValueWhenKeyExist()
        {
            const string key = "C";
            Assert.AreEqual("C",bst.Get(key));
        }

        [Test]
        public void BstShouldReturnNullIfIsNotPresent()
        {
            Assert.Null(bst.Get("Z"));
        }

        [Test]
        public void BstShouldReturnTrueOnlyIfKeyPresent()
        {
            Assert.True(bst.Contains("A"));
            Assert.False(bst.Contains("Z"));
        }

        [Test]
        public void BstShouldReturnTheMaxKey()
        {
            Assert.AreEqual(Maxkey,bst.Max());
        }

        [Test]
        public void BstShouldReturnTheMinKey()
        {
            Assert.AreEqual(Minkey,bst.Min());
        }

        [Test]
        public void BstShouldReturnTheSizeOfTheTree()
        {
            Assert.AreEqual(BstSize,bst.Size());
        }

        [Test]
        public void BstShouldReturnTheFloorKey()
        {
            const string expteced = "X";
            Assert.AreEqual(expteced,bst.Floor("Z"));
        }

        [Test]
        public void BstShouldReturnCeilingForTheKey()
        {
            const string expected = "C";
            Assert.AreEqual(expected,bst.Ceiling("B"));
        }

        [Test]
        public void BstShouldReturnTheNumberOfKeysLessThanGivenKey()
        {
            Assert.AreEqual(3,bst.Rank("G"));
        }

        [Test]
        public void BstShouldHaveInorderIterator()
        {
            foreach (var key in bst.Keys())
            {
                Console.WriteLine(key);
            }
        }

        [Test]
        public void BstShouldDeleteTheMinKey()
        {
            bst.DeleteMin();
            Assert.Null(bst.Get("A"));
        }

        [Test]
        public void BstShouldReturnNullForDeletedKey()
        {
            bst.Delete("E");
            Assert.Null(bst.Get("E"));
        }

        [Test]
        public void BstShouldDeleteMaxKey()
        {
            bst.DeleteMax();
            Assert.Null(bst.Get("X"));
        }
    }
}