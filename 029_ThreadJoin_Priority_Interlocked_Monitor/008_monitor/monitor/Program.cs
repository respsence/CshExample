using System;
using System.Threading;

// Lock - не принимает типов значений, а только ссылочные.

namespace monitor
{
    class Program
    {
        static private int counter = 0;

        // Нельзя использовать объекты блокировки структурного типа.
        // block - не может быть структурным.
        static private int block = 0;

        static private void Function()
        {
            for (int i = 0; i < 50; ++i)
            {
                // Устанавливается блокировка постоянно в новый object (boxing).
                Monitor.Enter((object)block);
                try
                {
                    Console.WriteLine(++counter);
                }
                finally
                {
                    // Попытка снять блокировку с незаблокированного объекта (boxing создает новый объект).
                    Monitor.Exit((object)block);
                }
            }
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread t in threads)
            {
                t.Start();
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
