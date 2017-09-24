using System;
using System.Collections.Generic;

namespace LambdaIterator
{
	class Program
	{
		static IEnumerable<T> MakeGenerator<T>(T initialValue, Func<T, T> advance)
		{
			T currentValue = initialValue;

			while (true)
			{
				yield return currentValue;
				currentValue = advance(currentValue);
			}
		}

		static void Main()
		{
			IEnumerable<double> iter = MakeGenerator<double>(1.0, x => x * 1.2);

			var enumerator = iter.GetEnumerator();

			for (int i = 0; i < 100; ++i)
			{
				enumerator.MoveNext();
				Console.WriteLine(enumerator.Current);
			}
            
			// Задержка.
			Console.ReadKey();
		}
	}
}
