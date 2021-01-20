using System;

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
            var linkedList = new LinkedList();
            bool chekMenu = true;
            while (chekMenu == true)
            {
                Console.WriteLine($"1 - Добавляет новый элемент списка");
                Console.WriteLine($"2 - Добавляет новый элемент списка после определённого элемента");
                Console.WriteLine($"3 - Удаляет элемент по порядковому номеру");
                Console.WriteLine($"4 - Удаляет указанный элемент в списке(если он есть)");
                Console.WriteLine($"5 - Показать список");
                Console.WriteLine($"6 - Выход");
                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Введите значение элемента");
                                linkedList.AddNode(int.Parse(Console.ReadLine()));
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
                                if (linkedList.GetCount() == 0)
                                {
                                    Console.WriteLine("Список пуст");
                                    break;
                                }
                                linkedList.Show();
                                Console.WriteLine("Введите после кагого элемента добавить новый элемент");
                                var pow = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите значение элемента");
                                linkedList.AddNodeAfter(linkedList.FindNode(pow),int.Parse(Console.ReadLine()));
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;                                
                                Console.WriteLine($"Ошибка добавления элемента ");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            try
                            {
                                linkedList.Show();
                                Console.WriteLine("Введите номер удаляемого элемента");
                                linkedList.RemoveNode(int.Parse(Console.ReadLine()));
                                linkedList.Show();                               
                            }
                            catch(Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка");
                                Console.ResetColor();
                            }
                            break;
                        case 4:
                            try
                            {
                                linkedList.Show();
                                 Console.WriteLine("Введите значение удаляемого элемента");
                                linkedList.RemoveNode(linkedList.FindNode(int.Parse(Console.ReadLine())));
                                linkedList.Show();
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка");
                                Console.ResetColor();
                            }
                            break;
                        case 5:
                            linkedList.Show();
                            break;
                        case 6:
                            chekMenu = false;
                            break;
                        default:
                            Console.WriteLine("Введите число 1 - 6");
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
