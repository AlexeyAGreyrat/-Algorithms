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
            int n;
            Console.WriteLine($"Введите число");
            n = int.Parse(Console.ReadLine());
            int d = 0;
            int i = 2;
            if(F(n, d, i) == true)
                Console.WriteLine($"Число {n} : простое");
            else
                Console.WriteLine($"Число {n} : не простое");
        }
        static bool F(int n,int d,int i)
        {
            int number = n;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            if(d==0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
