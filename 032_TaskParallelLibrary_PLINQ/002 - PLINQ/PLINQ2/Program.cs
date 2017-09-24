using System;
using System.Linq;

// Запрос PLINQ. Использование метода AsOrdered().

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            int[] data = new int[10000000];

            // Инициализация массива данных положительными значениями.
            for (int i = 0; i < data.Length; i++) data[i] = i;

            // Заполнение массива отрицательными значениями.
            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;

            // Запрос PLINQ для поиска отрицательных значений с использованием метода AsOrdered() 
            // для сохранения порядка в результирующей последовательности.
            var negatives = data.AsParallel().AsOrdered().
                                Where(val => val < 0);

            foreach (var v in negatives)
                Console.Write(v + " ");

            // Delay.
            Console.ReadKey();
        }
    }
}
