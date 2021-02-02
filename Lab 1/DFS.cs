using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DFS
    {
        public static bool FindDFS(Node<int> root,int n)
        {
            Console.WriteLine($"Поиск в глубину:");
            if (root == null)
                return false;
            Console.WriteLine($"Добавляем корень {root.Data} в стэк ");
            var stack = new Stack<Node<int>>();
            stack.Push(root);
            var i = 1;
            while (stack.Count > 0)
            {               
                var node = stack.Pop();
                Console.WriteLine($"Шаг {i}:");
                Console.WriteLine($"Берем элемент {node.Data} из стэка");
                if (node.Data == n)
                    return true;
                else
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                        Console.WriteLine($"Добавляем правый элемент {node.Right.Data} в стэк");
                    }
                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                        Console.WriteLine($"Добавляем левый элемент {node.Left.Data} в стэк");                        
                    }
                }
                Console.WriteLine();
                i++;
            }
            return false;
        }
    }
}
