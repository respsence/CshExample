using System;

namespace Lambda
{
	class Program
	{
		static void Main()
		{
			// (аргумент - double) (возвращаемое значение - double)
			Func<double, double> expression = x => x / 2;

			// Func<double, int> expression = x => x / 2;
			int number = 9;

			Console.WriteLine("Результат: {0}", expression(number));

			// Задержка.
			Console.ReadKey();
		}
	}
}