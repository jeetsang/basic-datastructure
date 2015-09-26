using System.Collections.Generic;
using DataStructure;
using NUnit.Framework;

namespace DataStructureTest
{
    [TestFixture]
    public class PriorityQueueTest
    {
        private List<Person> persons;

        [SetUp]
        public void Setup()
        {
            persons = new List<Person>
            {
                new Person
                {
                    Name = "A"
                },
                new Person
                {
                    Name = "B"
                },
                new Person
                {
                    Name = "C"
                },
                new Person
                {
                    Name = "D"
                },
                new Person
                {
                    Name = "E"
                }
            };
        }

        [Test]
        public void ShouldDelTheMaxKeyFromPriorityQueue()
        {
            var maxPq = new MaxPq<Person>(10);
            foreach (var person in persons)
            {
                maxPq.Insert(person);
            }

            Assert.AreEqual("E", maxPq.DelMax().Name);
            Assert.AreEqual("D", maxPq.DelMax().Name);
            Assert.AreEqual("C", maxPq.DelMax().Name);
            Assert.AreEqual("B", maxPq.DelMax().Name);
            Assert.AreEqual("A", maxPq.DelMax().Name);
            Assert.True(maxPq.IsEmpty());
        }
    }
}