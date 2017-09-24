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
            Console.WriteLine("Метод Main ожидает завершения асинхронной задачи.");

            Console.WriteLine(asyncResult.AsyncWaitHandle.GetType());

            // AsyncWaitHandle типа WaitHandle, переходит в сигнальное состояние при завершении асинхронной операции.
            asyncResult.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Асинхронный метод завершен.");

            // Получение результата асинхронной операции.
            int result = myDelegate.EndInvoke(asyncResult);

            // Закрываем WaitHandle.
            asyncResult.AsyncWaitHandle.Close();

            Console.WriteLine("Результат = " + result);

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
