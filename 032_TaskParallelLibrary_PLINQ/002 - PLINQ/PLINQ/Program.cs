using System;
using System.Linq;

// Простой запрос PLINQ.

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            var data = new int[10000000];

            // Инициализация массива данных положительными значениями.
            for (int i = 0; i < data.Length; i++) 
                data[i] = i;

            // Заполнение массива отрицательными значениями.
            data[1000] = -100;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;

            // Запрос PLINQ для поиска отрицательных значений.
            var negatives = from val in data.AsParallel() // ParallelEnumerable.AsParallel<int>(data)
                            where val < 0
                            select val;

            foreach (var v in negatives)
                Console.Write(v + " ");

            // Delay.
            Console.ReadKey();
        }
    }
}
