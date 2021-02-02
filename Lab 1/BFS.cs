using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class BFS
    {
        public static bool FindBFS(Node<int> root , int n)
        {
            Console.WriteLine($"Поиск в ширину:");
            if (root == null)
                return false ;
            Console.WriteLine($"Добавляем корень {root.Data} в очередь ");
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);
            var i = 1;            
            while (queue.Count > 0)
            {
                Console.WriteLine($"Шаг {i}");
                var node = queue.Dequeue();
                Console.WriteLine($"Берем элемент {node.Data} из очереди ");
                if (node.Data == n)
                    return true;
                else
                {
                    if (node.Left != null)
                    {
                        Console.WriteLine($"Добавляем левый элемент {node.Left.Data} в очередь ");
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        Console.WriteLine($"Добавляем правый элемент {node.Right.Data} в очередь ");
                        queue.Enqueue(node.Right);
                    }
                }
                Console.WriteLine();
                i++;
            }
            return false;
        }
    }
}
