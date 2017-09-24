using System;
using System.Collections.Generic;

// Мемоизация - замена делегата другим делегатом.

namespace Memoizers
{
    public static class Memoizers
    {
        // Расширяющий метод.(Для произведения нового делегата.)
        public static Func<T, R> Memoize<T, R>(this Func<T, R> func)
        {
            var cache = new Dictionary<T, R>(); // для блока истинности тернарного оператора чтоб не вычислять заново фибоначи для 0 и 1

            return x =>
            {
                R result = default(R);
                if (cache.TryGetValue(x, out result))
                    return result;

                result = func(x);
                cache[x] = result;
                return result;
            };
        }
    }

    class Program
    {
        static void Main()
        {
            Func<UInt32, UInt64> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;

            fib = fib.Memoize(); // Закомментировать и выполнить! (Ощутимая задержка в расчетах)

            for (UInt32 i = 0; i < 95; ++i)
                Console.WriteLine("{0:D2}-е число: {1}", i + 1, fib(i));

            // Задержка
            Console.ReadKey();
        }
    }
}
