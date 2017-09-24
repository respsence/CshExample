using System;
using System.Threading.Tasks;

// Использование типов ParallelLoopResult и ParallelLoopState, 
// методов Break() и ForEach() для параллельного выполнения цикла.

namespace TPL
{
    class Program
    {
        static int[] data;

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            data = new int[100000000];

            // Инициализация массива в цикле.
            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            // Поместить отрицательное значение в массив data.
            data[100] = -10;

            // Использование цикла, параллельно выполняемого методом ForeEach, для отображения данных на экране.
            ParallelLoopResult loopResult = Parallel.ForEach(data, (v, state) =>
                {
                    // Прервать цикл при обнаружении отрицательного значения.
                    if (v < 0)
                        state.Break();
                    Console.WriteLine("Значение: " + v);
                });

            // Проверить, завершился ли цикл. 
            if (!loopResult.IsCompleted)
                Console.WriteLine("\nЦикл завершился преждевременно." +
                    " На шаге {0} обнаружено отрицательное значение.\n", loopResult.LowestBreakIteration);

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
