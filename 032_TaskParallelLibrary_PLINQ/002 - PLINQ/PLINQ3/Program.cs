using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Отмена параллельного запроса. (Выполняться через Ctrl + F5)

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            var token = new CancellationTokenSource();
            var data = new int[10000000];

            // Инициализация массива данных положительными значениями.
            for (int i = 0; i < data.Length; i++) data[i] = i;

            // Заполнение массива отрицательными значениями.
            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;

            // Запрос PLINQ для поиска отрицательных значений.
            ParallelQuery<int> negatives = from val in data
                                               .AsParallel()
                                               .WithCancellation(token.Token)
                                               .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                           where val < 0
                                           select val;

            // Создание задачи для отмены запроса по истечении 100 миллисекунд.
            token.CancelAfter(50);

            try
            {
                foreach (var v in negatives)
                    Console.Write(v + " ");
                Console.WriteLine("Enumeration completed succesfully!");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                token.Dispose();
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
