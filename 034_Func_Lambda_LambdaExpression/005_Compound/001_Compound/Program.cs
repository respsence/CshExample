using System;

namespace Compound
{
    class Program
    {
        // Метод принимает два делегата и производит третий делегат, комбинируя первые два.
        static Func<T, S> Chain<T, R, S>(Func<T, R> f1, Func<R, S> f2)
        {
            return x => f2(f1(x));
        }

        static void Main()
        {
            Func<int, double> f2f1 = Chain((int x) => x * 3, x => x + 3.1415);

            Console.WriteLine(f2f1(2));

            // Задержка.
            Console.ReadKey();
        }
    }
}
