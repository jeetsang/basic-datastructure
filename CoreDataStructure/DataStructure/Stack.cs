using System;
using System.Runtime.Remoting.Messaging;

namespace DataStructure
{
    public class Stack<T>
    {
        private Node first = null;
       
        private class  Node
        {
            internal T Item;
            internal Node Next;
        }

        public void Push(T item)
        {
            var temp = first;
            first = new Node
            {
                Item = item,
                Next = temp
            };
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public T Pop()
        {
            if(IsEmpty()) throw new Exception("Stack UnderFlow");
            var poppedValue = first.Item; 
            first = first.Next;
            return poppedValue;
        }
    }
}