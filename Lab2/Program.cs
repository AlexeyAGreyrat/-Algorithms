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

        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;// 1
            for (int i = 0; i < inputArray.Length; i++) // N*N*N O(N^3)
            {
                for (int j = 0; j < inputArray.Length; j++)//N*N
                {
                    for (int k = 0; k < inputArray.Length; k++)//N
                    {
                        int y = 0;//1

                        if (j != 0)
                        {
                            y = k / j;//1
                        }
                        sum += inputArray[i] + i + k + j + y;//1
                    }
                }
            }
            return sum;
        }
    }
}
