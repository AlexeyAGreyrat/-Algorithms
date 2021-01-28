using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Test
    {
        private string[] str;
        private HashSet<string> hashSet = new HashSet<string>();
        private Random rnd = new Random();
        public Test()
        {
            int n = 100000;
            this.str = new string[n];
            for (int i = 0; i < n; i++)
            {
                str[i] = Word();
                hashSet.Add(str[i]);
            }
        }
        public string Word()
        {
            string word = null;
            char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            int ln = 100;
            for (int j = 0; j < ln; j++)
            {
                int letter_num = rnd.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            return word;
        }

        [Benchmark]
        public void searchHStr()
        {
            var search = Word();
            Console.WriteLine($"{hashSet.Contains(search)}");
        }
        [Benchmark]
        public void searchStr()
        {
            var search = Word();
            var n = str.Length;
            for (int i = 0; i < n; i++)
            {
                if (str[i] == search)
                {
                    Console.WriteLine($"True");
                    return;
                }
            }
            Console.WriteLine($"False");
        }



    }
}
