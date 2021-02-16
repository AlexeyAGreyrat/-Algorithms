using System;
using System.Collections.Generic;

namespace lab1
{
    class Sort
    {
        public static void BucketSort(int[] mass)
        {
            int minValue = mass[0];
            int maxValue = mass[0];
            List<int>[] bucket = new List<int>[mass.Length];

            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();

            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] < minValue)
                    minValue = mass[i];
                else if (mass[i] > maxValue)
                    maxValue = mass[i];
            }

            double numRange = maxValue - minValue;

            for (int i = 0; i < mass.Length; i++)
            {
                int id = (int)Math.Floor((mass[i] - minValue) / numRange * (bucket.Length - 1));
                bucket[id].Add(mass[i]);
            }

            for (int i = 0; i < bucket.Length; i++)
                bucket[i].Sort();

            int index = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i].Count; i++)
                    mass[index++] = bucket[i][j];
            }
        }
    }
}
