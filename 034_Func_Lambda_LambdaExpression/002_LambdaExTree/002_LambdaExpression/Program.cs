using System;
using System.Linq.Expressions;

namespace LambdaExpression
{
    static class Program
	{
		static void Main()
		{
			// Expression<Func<int, int>> expression = n => n + 1;
			// Строки ниже заменяют единственную строку Лямбда-Выражения из предыдущего примера.

			// Представляем параметр в списке параметров лямбда-выражения.
			// Эта строка говорит, что нам нужна переменная n типа int.
			ParameterExpression n = Expression.Parameter(typeof(int), "n");
            ParameterExpression t = Expression.Parameter(typeof(int), "t");

		    var cons1 = Expression.Constant(1);
            var c2 = Expression.Constant(2);

			// Прибавляем число 1 к параметру n.
			var addBody = Expression.Add(n, cons1);
		    var multBody = Expression.Multiply(addBody, t);
		    var divBody = Expression.Divide(multBody, c2);

		    var expression = Expression.Lambda<Func<int, int, int>>(divBody,t,n);

            Console.WriteLine(expression);
            
			// Компилируем выражение в делегат.
			Func<int, int,int> func = expression.Compile();

			for (int i = 0; i < 10; i++ )
				Console.WriteLine("Результат: {0}", func(i,i));

			// Задержка.
			Console.ReadKey();
		}
	}
}
