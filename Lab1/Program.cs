using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {        

    static void Main()
    {
        int[] bucket = new int[15];
        Random rnd = new Random();
        for (int i = 0; i < bucket.Length; i++)
            bucket[i] = rnd.Next(0, 100);

        Console.WriteLine(String.Join(" ", bucket));
        Sort.BucketSort(bucket);
        Console.WriteLine(String.Join(" ", bucket));
    }
}
}
