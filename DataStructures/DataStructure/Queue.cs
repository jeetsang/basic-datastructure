using System;
using System.ComponentModel.Design;

namespace DataStructure
{
    public class Queue<Item>
    {
        private Node first = null;
        private Node last = null;

        private class Node
        {
            internal Item item;
            internal Node next;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Enqueue(Item item)
        {
            var node = new Node {item = item, next = null};

            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                last.next = node;
                last = node;
            }
        }

        public Item Dequeue()
        {
            if(IsEmpty()) throw  new Exception("Queue is Empty");
            var dequeuedItem = first.item;
            first = first.next;
            return dequeuedItem;
        }
    }
}