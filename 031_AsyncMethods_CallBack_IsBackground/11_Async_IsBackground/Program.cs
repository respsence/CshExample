using System;
using System.Threading;

// По умолчанию в Асинхронном шаблоне, IsBackground = true (С завершением первичного потока завершается вторичный).
// IsBackground = false (Первичный поток ожидает окончания работы вторичного потока).

namespace AsynchronousProgramming
{
    class Program
    {
        private static void Function()
        {
            Thread.CurrentThread.IsBackground = false; // Закомментировать.

            Console.WriteLine("Вторичный поток начал работу.");

            for (int i = 0; i < 240; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.WriteLine("\nВторичный поток завершил работу.");
        }

        private static void CallBack(IAsyncResult asyncResult)
        {
            var work = asyncResult.AsyncState as Action;
            if (work != null) work.EndInvoke(asyncResult);
        }

        static void Main()
        {
            Console.WriteLine("Первичный поток начал работу.");

            var work = new Action(Function);
            work.BeginInvoke(new AsyncCallback(CallBack), (object)work);

            Thread.Sleep(1000);
            Console.WriteLine("\nПервичный поток завершил работу.\n");
        }
    }
}
