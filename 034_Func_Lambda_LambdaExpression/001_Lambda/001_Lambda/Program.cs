using System;

namespace Lambda
{
	class Program
	{
		static void Main()
		{
			// Func< (аргумент - int), (возвращаемое значение - double) >.
			//Func<int, double> expression = x => x / 2; // Лямбда-Выражение сообщенное с делегатом.

            Func<int, double> func = x => x / 2;

			int number = 9;

			Console.WriteLine("Результат: {0}", func(number));

			// Задержка.
			Console.ReadKey();
		}
	}
}
