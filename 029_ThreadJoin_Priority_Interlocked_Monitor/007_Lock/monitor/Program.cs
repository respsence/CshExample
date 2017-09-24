using System;
using System.Threading;

namespace monitor
{
    class Program
    {
        static private readonly object block = new object();
        static private int counter;
        static private readonly Random random = new Random();

        private static void Function()
        {
            // Управляющий поток увеличивает счетчик и ожидает
            // произвольный период времени от 1 до 12 секунд. 
  
            lock (block)
            {
                ++counter;
            }

            int time = random.Next(1000, 12000);
            Thread.Sleep(time);

            lock (block)
            {
                --counter;
            }
        }

        private static void Report()
        {
            while (true)
            {
                int count;

                lock (block)
                {
                    count = counter;
                }

                Console.WriteLine("{0} поток(ов) активно", count);
                Thread.Sleep(100);
            }
        }

        static void Main()
        {
            var reporter = new Thread(Report) {IsBackground = true};
            reporter.Start();

            var threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }
        }
    }
}
