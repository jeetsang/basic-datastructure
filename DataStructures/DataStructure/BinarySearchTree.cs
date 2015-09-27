using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root = null;

        private class Node
        {
            internal TKey key;
            internal TValue value;
            internal Node left;
            internal Node right;
            internal int count;

            public Node(TKey key, TValue value, int count)
            {
                this.key = key;
                this.value = value;
                this.count = count;
                left = null;
                right = null;
            }
        }

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, TKey key, TValue value)
        {
            if (node == null) return new Node(key, value, 1);
            var compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                node.left = Put(node.left, key, value);
            }
            else if (compare > 0)
            {
                node.right = Put(node.right, key, value);
            }
            else
            {
                node.value = value;
            }
            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        private int Size(Node node)
        {
            return node == null ? 0 : node.count;
        }

        public TValue Get(TKey key)
        {
            var node = root;
            while (node != null)
            {
                var compare = key.CompareTo(node.key);
                if (compare < 0) node = node.left;
                else if (compare > 0)
                {
                    node = node.right;
                }
                else
                {
                    return node.value;
                }
            }

            return default(TValue);
        }

        public void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node node, TKey key)
        {
            if (node == null) return null;
            var cmp = key.CompareTo(node.key);
            if (cmp < 0) node.left = Delete(node.left, key);
            else if(cmp > 0 )
            {
                node.right = Delete(node.right, key);
            }
            else
            {
                if (node.right == null) return node.left;
                if (node.left == null) return node.right;

                var t = node;
                node = Min(t.right);
                node.right = DeleteMin(t.right);
                node.left = t.left;
            }
            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public bool Contains(TKey key)
        {
            return Get(key) != null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public TKey Max()
        {
            var node = root;
            while (node.right != null)
            {
                node = node.right;
            }

            return node.key;
        }

        public TKey Min()
        {
            var node = Min(root);
            return node.key;
        }

        private Node Min(Node node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public int Size()
        {
            return Size(root);
        }

        public TKey Floor(TKey key)
        {
            var node = Floor(root, key);
            return node == null ? default(TKey) : node.key;
        }

        private Node Floor(Node node, TKey key)
        {
            if (node == null) return null;
            var cmp = key.CompareTo(node.key);
            if (cmp == 0) return node;
            if (cmp < 0) return Floor(node.left, key);

            var t = Floor(node.right, key);
            return t ?? node;
        }

        public TKey Ceiling(TKey key)
        {
            var node = Ceiling(root, key);
            return node == null ? default(TKey) : node.key;
        }

        private Node Ceiling(Node node, TKey key)
        {
            if (node == null) return null;
            var cmp = key.CompareTo(node.key);
            if (cmp == 0) return node;
            if (cmp > 0) return Ceiling(node.right, key);

            var t = Ceiling(node.left, key);
            return t ?? node;
        }

        public int Rank(TKey key)
        {
            return Rank(root, key);
        }

        private int Rank(Node node, TKey key)
        {
            if (node == null) return 0;
            var cmp = key.CompareTo(node.key);
            if (cmp < 0)
            {
                return Rank(node.left, key);
            }
            if (cmp > 0)
            {
                return 1 + Size(node.left) + Rank(node.right, key);
            }
            return Size(node.left);
        }

        public IEnumerable<TKey> Keys()
        {
            //TODO Use DS queue implemnetation once that supports iteration;
            var  queue = new System.Collections.Generic.Queue<TKey>();
            Inorder(root, queue);
            return queue;
        }

        private void Inorder(Node node, System.Collections.Generic.Queue<TKey> queue)
        {
            if (node == null) return;
            Inorder(node.left, queue);
            queue.Enqueue(node.key);
            Inorder(node.right,queue);
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            if(node.left==null) return node.right;
            node.left = DeleteMin(node.left);
            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public void DeleteMax()
        {
            root = DeleteMax(root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.right == null) return node.left;
            node.right = DeleteMax(node.right);
            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }
    }
}