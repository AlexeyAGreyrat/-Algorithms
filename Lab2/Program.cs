using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {                        
            Menu();
        }
        static void Menu()
        {
            var rnd = new Random();
            Tree<int> btr = new Tree<int>();
            var RandomTree = new Tree<int>();
            bool chekMenu = true;
            while (chekMenu == true)
            {                
                Console.WriteLine($"1 - Добавляет новый элемент в дерево");
                Console.WriteLine($"2 - Удаляет элемена из дерева");
                Console.WriteLine($"3 - Показать дерево");
                Console.WriteLine($"4 - Выход");
                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {                        
                        case 1:
                            try
                            {
                                Console.WriteLine("Введите узел");
                                var n = int.Parse(Console.ReadLine());
                                if (btr.AddNode(n) == true)
                                {
                                    Console.WriteLine($"Узел {n} добавлен"); 
                                }
                                else
                                {
                                    Console.WriteLine($"Узел {n} существуетв добавление невозможно");
                                }
                                Tree<int>.Print();
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Ошибка добавления элемента ");
                                Console.ResetColor();
                            }
                            break;
                        case 2:
                            try
                            {
                                var n = int.Parse(Console.ReadLine());
                                if (btr.remove(n) == true)
                                {
                                    Console.WriteLine($"Узел {n} удален");
                                }
                                else
                                {
                                    Console.WriteLine($"Узел {n} не существует удаление невозможно");
                                }
                                Tree<int>.Print();
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            try
                            {
                                Tree<int>.Print();
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка");
                                Console.ResetColor();
                            }
                            break;
                        case 4:
                            chekMenu = false;
                            break;                        
                        default:
                            Console.WriteLine("Введите число 1 - 5");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка");
                    Console.ResetColor();
                }
            }
        }
    }

}
