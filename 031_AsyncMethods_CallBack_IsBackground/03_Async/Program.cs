using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            var myDelegate = new Func<int,int,int>(Add);

            // Так как класс делегата сообщается с методами, которые принимают два целочисленных параметра, метод BeginInvoke также
            // начинает принимать два дополнительных параметра, кроме двух последних постоянных аргументов.
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);

            // Ожидание завершения асинхронной операции и получение результата работы метода.
            int result = myDelegate.EndInvoke(asyncResult);

            Console.WriteLine("Результат = " + result);

            // Delay.
            Console.ReadKey();
        }

        // Метод для выполнения в отдельном потоке.
        static int Add(int a, int b)
        {
            Thread.Sleep(2000);
            return a + b;
        }
    }
}
