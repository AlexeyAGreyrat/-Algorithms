using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Tree<T>
    {
        private static Node<int> root;
        private static Random rnd = new Random();
        public Node<int> RTree(int n)
        {
            Node<int> newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node<int>();
                newNode.Data = rnd.Next(1, 1000);
                newNode.Left = RTree(nl);
                newNode.Right = RTree(nr);
            }
            root = newNode;
            return newNode;
        }
        public static bool Queue(int n)
        {
            return BFS.FindBFS(root, n);
        }
        public static bool Stack(int n)
        {
            return DFS.FindDFS(root, n);
        }
    }
}
