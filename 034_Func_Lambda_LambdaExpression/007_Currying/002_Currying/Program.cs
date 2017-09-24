using System;
using System.Collections.Generic;

namespace Currying
{
    // Каррирование декомпозирует функцию на функции от одного аргумента. 
    public static class CurryExtensions
	{
		public static Func< TArg2, Func<TArg1, TResult> > 
                        Curry<TArg1, TArg2, TResult>(
                                                this Func<TArg1, TArg2, TResult> func)
		{
			return y => x => func(x, y);
		}
	}

	class Program
	{
		static void Main()
		{
			var mylist = new List<double> { 1.0, 3.4, 5.4, 6.54 };
			var newlist = new List<double>();

			// Здесь - исходное выражение.
			Func<double, double, double> func = (x, y) => x + y;

			// Здесь - каррирование.
            // В отличие от частичного применения мы не передаем никаких дополнительных аргументов в метод Curry, 
            // кроме преобразуемой функции
            // (x, y) => x + y   -----------> y => x => func(x, y)
		    Func<double,Func<double,double>> curried = func.Curry();


			foreach (double item in mylist)
			{
				Console.Write("{0}, ", item);
				newlist.Add(curried(3)(item));
			}

			Console.WriteLine();

			foreach (double item in newlist)            
				Console.Write("{0}, ", item);

			// Задержка.
			Console.ReadKey();
		}
	}
}
