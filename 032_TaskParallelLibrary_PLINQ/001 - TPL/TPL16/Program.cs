using System;
using System.Threading.Tasks;

// Использование типов ParallelLoopResult и ParallelLoopState, 
// методов Break() и For() для параллельного выполнения цикла.

namespace TPL
{
    class Program
    {
        static int[] data;

        // Метод служащий в качестве тела параллельно выполняемого цикла.
        // Операторы этого цикла просто расходуют время ЦП для целей демонстрации.

        // ParallelLoopState - Позволяет итерациям циклов Parallel взаимодействовать с другими итерациями.
        // Экземпляр этого класса предоставляется каждому циклу параллельным классом;
        // невозможно создавать экземпляры в пользовательском коде.
        static void MyTransform(int i, ParallelLoopState state)
        {
            // Прервать цикл при обнаружении отрицательного значения.
            if (data[i] < 0)
                state.Break();
            
            data[i] = data[i] / 10;

            if (data[i] < 10000) data[i] = 0;
            if (data[i] > 10000 && data[i] < 20000) data[i] = 100;
            if (data[i] > 20000 && data[i] < 30000) data[i] = 200;
            if (data[i] > 30000) data[i] = 300;
            Console.WriteLine(i);
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            data = new int[100000000];

            // Инициализация массива в цикле.
            for (int i = 0; i < data.Length; i++) 
                data[i] = i;

            // Поместить отрицательное значение в массив data.
            data[1000] = -10;

            // Параллельный вариант инициализации массива в цикле.
            // ParallelLoopResult -  Предоставляет состояние выполнения цикла Parallel.
            ParallelLoopResult loopResult = Parallel.For(0, data.Length, MyTransform);

            // Проверить, завершился ли цикл. 
            if (!loopResult.IsCompleted)
                Console.WriteLine("\nЦикл завершился преждевременно." +
                    " На шаге {0} обнаружено отрицательное значение.\n", loopResult.LowestBreakIteration);

            Console.WriteLine("Основной поток завершен.");

            // Delay.
       //     Console.ReadKey();
        }
    }
}
