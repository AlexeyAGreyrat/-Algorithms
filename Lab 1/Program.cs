using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Tree = new Tree<int>();
            Tree.RTree(10);
            Console.WriteLine($"Поиск в ширину:");
            Console.WriteLine($"Введите какой элемент неободимо найти");
            var n = int.Parse(Console.ReadLine());
            if (Tree<int>.Queue(n) == true)
                Console.WriteLine($"Элемент {n} присутствует в дереве");
            else
                Console.WriteLine($"Элемент {n} отсутствует в дереве");
            Console.WriteLine($"Поиск в глубину:");
            Console.WriteLine($"Введите какой элемент неободимо найти");
            n = int.Parse(Console.ReadLine());
            if (Tree<int>.Stack(n) == true)
                Console.WriteLine($"Элемент {n} присутствует в дереве");
            else
                Console.WriteLine($"Элемент {n} отсутствует в дереве");
            Console.ReadKey();
        }
    }
}
