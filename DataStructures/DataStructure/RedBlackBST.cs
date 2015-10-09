using System;
using System.Collections.Generic;

namespace DataStructure
{
    /// <summary>
    ///     Left leaning red black binary search tree.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class RedBlackBst<TKey, TValue> where TKey : IComparable<TKey>
    {
        private const bool RED = true;
        private const bool BLACK = false;
        private Node root;

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, TKey key, TValue value)
        {
            if (node == null) return new Node(key, value, 1, RED);
            int compare = key.CompareTo(node.key);
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

            //All the cases
            //Right child red,left child black: rotate left.
            //Left child red and left-left grand child red: rotate right.
            //both children red: flip color.
            if (IsRed(node.right) && !IsRed(node.left))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.left) && IsRed((node.left.left)))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColor(node);
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
            Node node = root;
            while (node != null)
            {
                int compare = key.CompareTo(node.key);
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
            Node node = root;
            while (node.right != null)
            {
                node = node.right;
            }

            return node.key;
        }

        public TKey Min()
        {
            Node node = Min(root);
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
            Node node = Floor(root, key);
            return node == null ? default(TKey) : node.key;
        }

        private Node Floor(Node node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.key);
            if (cmp == 0) return node;
            if (cmp < 0) return Floor(node.left, key);

            Node t = Floor(node.right, key);
            return t ?? node;
        }

        public TKey Ceiling(TKey key)
        {
            Node node = Ceiling(root, key);
            return node == null ? default(TKey) : node.key;
        }

        private Node Ceiling(Node node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.key);
            if (cmp == 0) return node;
            if (cmp > 0) return Ceiling(node.right, key);

            Node t = Ceiling(node.left, key);
            return t ?? node;
        }

        public int Rank(TKey key)
        {
            return Rank(root, key);
        }

        private int Rank(Node node, TKey key)
        {
            if (node == null) return 0;
            int cmp = key.CompareTo(node.key);
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
            var queue = new System.Collections.Generic.Queue<TKey>();
            Inorder(root, queue);
            return queue;
        }

        private void Inorder(Node node, System.Collections.Generic.Queue<TKey> queue)
        {
            if (node == null) return;
            Inorder(node.left, queue);
            queue.Enqueue(node.key);
            Inorder(node.right, queue);
        }

        private bool IsRed(Node node)
        {
            if (node == null) return false;
            return node.color == RED;
        }

        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            h.color = RED;
            return x;
        }

        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            h.color = RED;
            return x;
        }

        private void FlipColor(Node h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        private class Node
        {
            internal readonly TKey key;
            internal bool color;
            internal int count;
            internal Node left;
            internal Node right;
            internal TValue value;

            public Node(TKey key, TValue value, int count, bool color)
            {
                this.key = key;
                this.value = value;
                this.count = count;
                left = null;
                right = null;
                this.color = color; //color of the parent link.
            }
        }
    }
}