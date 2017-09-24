using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Первичный поток: Id {0}", Thread.CurrentThread.ManagedThreadId);

            var myDelegate = new Action(Method);

            // Делегат, метод которого будет запущен по завершению асинхронной операции.
            var callback = new AsyncCallback(HandleCompletion);

            // Первый параметр: 
            // Принимает метод обратного вызова, который должен сработать по завершению асинхронной операции.
            // Второй параметр: 
            // Дополнительный объект хранящий состояние, который будет доступен в методе обратного вызова.
            myDelegate.BeginInvoke(callback, null);

            Console.WriteLine("Первичный поток продолжает работать.");

            // Delay.
            Console.ReadKey();
        }

        // Метод для выполнения в отдельном потоке.
        static void Method()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nАсинхронный метод запущен.");
            Console.WriteLine("\nВторичный поток: Id {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }

            Console.WriteLine("Асинхронная операция завершена.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Callback метод для обработки завершения асинхронной операции.
        static void HandleCompletion(IAsyncResult asyncResult)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Callback метод. Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
