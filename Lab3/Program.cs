using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Номер числа Фибоначчи");
            int n = int.Parse(Console.ReadLine());
            bool chekMenu = true;
            while (chekMenu == true)
            {
                try
                {
                    Console.WriteLine("1 - Вывести число Фибоначчи через рекурсию");
                    Console.WriteLine("2 - Вывести число Фибоначчи без рекурсии");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:                            
                            Console.WriteLine($"Число Фибоначчи под номером {n} : {Fib(n)}");
                            chekMenu = false;
                            break;
                        case 2:
                            Console.WriteLine($"Число Фибоначчи под номером {n} : {NoRec(n)}");
                            chekMenu = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка Введите число 1 или 2 ");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка Введите число 1 или 2 ");
                }
            }
        }
        static int FibRec(int fn1, int fn2, int n)
        {
            return n == 0 ? fn1 : FibRec(fn2, fn1 + fn2, n - 1);
        }
        static int Fib(int n)
        {
            int f0 = 0;
            int f1 = 1;
            if (n > 0)
                return FibRec(f0, f1, n);
            else
            {
                n = Math.Abs(n);
                if (n % 2 != 0)
                    return FibRec(f0, f1, n);
                else
                    return -FibRec(f0, f1, n);
            }
        }
        static int NoRec(int n)
        {
            int i=0;
            int f1 = 0;
            int f2 = 1;
            while(i < Math.Abs(n))
            {
                    int tmp = f2;
                    f2 = f1 + f2;
                    f1 = tmp;
                    i++;                
            }
            if(n<0)
                return f1 = n % 2 == 0 ? f1*-1 : f1*1;            
            else
                return f1;
        }
    }
}
