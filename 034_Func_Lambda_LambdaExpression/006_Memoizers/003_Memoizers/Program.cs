using System;
using System.Collections.Generic;

namespace Memoizers2
{
    public static class Memoizers
    {
        public static Func<T, R> Memoize<T, R>(this Func<T, R> func)
        {
            var cache = new Dictionary<T, R>();
            R result = default(R);
            return x => cache.TryGetValue(x, out result) 
                                ? result 
                                : cache[x] = func(x);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(100, 58);

            Func<ulong, ulong> fib = null;
            fib = x => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            fib = fib.Memoize();

            Func<ulong, decimal> fibConstant = null;
            fibConstant = x => (x == 1) ? 1 / ((decimal)fib(x)) : 1 / ((decimal)fib(x)) + fibConstant(x - 1);
            
            fibConstant = fibConstant.Memoize();

            Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\n", "Count", "Fibonacci".PadRight(24), "1/Fibonacci".PadRight(24), "Fibonacci Constant".PadRight(24));

            for (ulong i = 1; i <= 93; ++i)
                Console.WriteLine("{0:D5}\t{1:D24}\t{2:F24}\t{3:F24}", i, fib(i), (1 / (decimal)fib(i)), fibConstant(i));

            // Задержка.
            Console.ReadKey();
        }
    }
}
