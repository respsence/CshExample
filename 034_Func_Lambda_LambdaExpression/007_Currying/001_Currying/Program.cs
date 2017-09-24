using System;
using System.Collections.Generic;
using System.Linq;

// Частичное применение преобразует функцию с N параметрами в функцию с N-1 параметрами, применяя один аргумент.

namespace Currying
{
    public static class CurryExtensions
    {
        public static Func<TArg1, TResult> ApplyPartial<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> func, 
                                                                                    TArg2 constant)
        {
            return (x) => func(x, constant);
        }
    }

    class Program
    {

        static void Main()
        {

            var mylist = new List<double> { 1.0, 3.4, 5.4, 6.54 };

            // Здесь - исходное выражение.
            Func<double, double, double> func = (x, y) => x + y;

            Func<double, double> funcBound = func.ApplyPartial(3.2);

            var newlist = from el in mylist
                          select funcBound(el);

            foreach (double item in newlist)
                Console.Write("{0}, ", item);

            // Задержка.
            Console.ReadKey();
        }
    }
}
