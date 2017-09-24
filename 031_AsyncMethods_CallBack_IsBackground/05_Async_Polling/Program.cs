using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            var myDelegate = new Func<int,int,int>(Add);

            // Запуск асинхронной задачи.
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);

            Console.WriteLine("Асинхронный метод запущен. Метод Main продолжает работать.");

            // Выполнение цикла до тех пор, пока работает асинхронная операция.
            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }

            // Получение результата асинхронной операции.
            int result = myDelegate.EndInvoke(asyncResult);

            Console.WriteLine("\nРезультат = " + result);

            // Delay.
            Console.ReadKey();
        }

        // Метод для выполнения в отдельном потоке.
        static int Add(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
