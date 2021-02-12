using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        public static int[,] Map(int n,int m,int[,] buffer)
        {
            var rnd = new Random();
            var buf = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    buf[i, j] = 1;
                }
            }
            var set = rnd.Next(1, 3);
            while(set!=0)
            {
                var i = rnd.Next(0, buf.GetLength(0)-1);
                var j = rnd.Next(0, buf.GetLength(1)-1);
                if(i==0 && j == 0)
                {

                }
                else
                { 
                    if (i != n && j != m)
                    {
                     buf[i, j] = 0;
                        set--;
                    }                
                }
            }
            return buf;
           
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите количество столбцов");
            int N=int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите количество строк");
            int M = int.Parse(Console.ReadLine());
            int[,] board = new int[N, M];
            int[,] map = new int[N, M];         
            map = Map(N, M, board);                    
            Console.WriteLine($"Количество маршрутов без препятствий = {NoBarrier(board) }");
            Console.WriteLine($" Количество маршрутов с препятствиями= {Barrier(map, board)}");
        }
        public static int NoBarrier(int[,] buffer)
        {
            buffer = new int[buffer.GetLength(0), buffer.GetLength(1)];
            buffer[0, 0] = 1;
            for (int i = 0; i < buffer.GetLength(1); i++)
            {
                buffer[0, i] = 1;
            }
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                buffer[i, 0] = 1;
            }
            for (int i = 1; i < buffer.GetLength(0); i++)
            {
                for (int j = 1; j < buffer.GetLength(1); j++)
                {
                    buffer[i, j] = buffer[i, j - 1] + buffer[i - 1, j];
                }
            }
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                {
                    Console.Write(buffer[i, j] + "  ");
                }
                Console.WriteLine();
            }
            return buffer[buffer.GetLength(0) - 1, buffer.GetLength(1) - 1];
        }
            public static int Barrier(int[,] map ,int[,] buffer)
            {
            buffer = new int[buffer.GetLength(0), buffer.GetLength(1)];
            buffer[0, 0] = 1;
            var i1 = 1;
            var j1 = 1;
            for (int i = 0; i < map.GetLength(1); i++)
            {
                if (map[0, i] == 0)
                    i1 = 0;
                buffer[0, i] = i1;
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                if (map[i, 0] == 0)
                    j1 = 0;
                buffer[i, 0] = j1;
            }            
            for (int i = 1; i < map.GetLength(0); i++)
            {
                for (int j = 1; j < map.GetLength(1); j++)
                {
                    if(map[i,j]!=0)
                    {
                        buffer[i,j] = buffer[i, j - 1] + buffer[i - 1, j];
                    }
                    else
                    {
                        buffer[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(buffer[i, j] + "  ");
                }
                Console.WriteLine();
            }
            return buffer[map.GetLength(0)-1, map.GetLength(1)-1];
        }
    }
}
