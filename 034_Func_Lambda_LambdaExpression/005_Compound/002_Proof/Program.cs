using System;

namespace Proof
{
    class Program
    {
        static void Main()
        {
            Func<int, int> fib = null;

            fib = (x) => x > 1 ? fib.Invoke(x - 1) + fib.Invoke(x - 2) : x;

            for (int i = 0; i < 45; ++i)
                Console.WriteLine("{0:D2}-е число: {1}", i + 1, fib(i));

            // Задержка.
            Console.ReadKey();
        }
    }
}
