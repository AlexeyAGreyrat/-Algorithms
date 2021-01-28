using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Tree<T>
    {
        private static Node<int> root;       
        private static Random rnd = new Random();
        // Построение идеально сбалансированного дерева с n узлами
        // со случайными значениями
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
                newNode.Data = rnd.Next(1,10);
                newNode.Left = RTree(nl);
                newNode.Right = RTree(nr);
            }
            root = newNode;
            return newNode;
        }
        //
        public bool AddNode(int value)
        {
            if (root == null)
            {
                root = GetFreeNode(value, null);
                return true;
            }
            else
            {
                return AddNodeAfter(root, value);
            }
        }
        public static void Print()
        {
            BTreePrinter.Print(root);
        }

        private bool AddNodeAfter(Node<int> Node, int value)
        {
            Node<int> tmp = null;
            if (root == null)
            {
                root = GetFreeNode(value, null);
                return true;
            }

            tmp = root;
            while (tmp != null)
            {
                if (value > tmp.Data)
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = GetFreeNode(value, tmp);
                        return true;
                    }
                }
                else if (value < tmp.Data)
                {
                    if (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = GetFreeNode(value, tmp);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    
    public static Node<int> GetFreeNode(int value, Node<int> parent)
        {
            var newNode = new Node<int>
            {
                Data = value,
                Parent = parent
            };
            return newNode;
        }    
        private Node<int> _Search(Node<int> node, int value)
        {            
            if (node == null) return null;
            switch (value.CompareTo(node.Data))
            {
                case 1: return _Search(node.Right, value);
                case -1: return _Search(node.Left, value);
                case 0: return node;
                default: return null;
            }
        }
        public Node<int> Search(int value)
        {
            return _Search(root, value);
        }

        public bool remove(int val)
        {
            //Проверяем, существует ли данный узел
            Node<int> node = Search(val);
            if (node == null)
            {
                //Если узла не существует, вернем false
                return false;
            }
            Node<int> curNode;

            //Если удаляем корень
            if (node == root)
            {
                if (node.Right != null)
                {
                    curNode = node.Right;
                }
                else curNode = node.Left;

                while (curNode.Left != null)
                {
                    curNode = curNode.Left;
                }
                int temp = curNode.Data;
                this.remove(temp);
                node.Data = temp;

                return true;
            }

            //Удаление листьев
            if (node.Left == null && node.Right == null && node.Parent != null)
            {
                if (node == node.Parent.Left)
                    node.Parent.Left = null;
                else
                {
                    node.Parent.Right = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (node.Left != null && node.Right == null)
            {
                //Меняем родителя
                node.Left.Parent = node.Parent;
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else if (node == node.Parent.Right)
                {
                    node.Parent.Right = node.Left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (node.Left == null && node.Right != null)
            {
                //Меняем родителя
                node.Right.Parent = node.Parent;
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else if (node == node.Parent.Right)
                {
                    node.Parent.Right = node.Right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (node.Right != null && node.Left != null)
            {
                curNode = node.Right;

                while (curNode.Left != null)
                {
                    curNode = curNode.Left;
                }

                //Если самый левый элемент является первым потомком
                if (curNode.Parent == node)
                {
                    curNode.Left = node.Left;
                    node.Left.Parent = curNode;
                    curNode.Parent = node.Parent;
                    if (node == node.Parent.Left)
                    {
                        node.Parent.Left = curNode;
                    }
                    else if (node == node.Parent.Right)
                    {
                        node.Parent.Right = curNode;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curNode.Right != null)
                    {
                        curNode.Right.Parent = curNode.Parent;
                    }
                    curNode.Parent.Left = curNode.Right;
                    curNode.Right = node.Right;
                    curNode.Left = node.Left;
                    node.Left.Parent = curNode;
                    node.Right.Parent = curNode;
                    curNode.Parent = node.Parent;
                    if (node == node.Parent.Left)
                    {
                        node.Parent.Left = curNode;
                    }
                    else if (node == node.Parent.Right)
                    {
                        node.Parent.Right = curNode;
                    }
                    return true;
                }
            }
            return false;

        }
    }    
}
