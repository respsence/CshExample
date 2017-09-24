using System;
using System.Linq.Expressions;

namespace LambdaExpression
{
    static class Program
    {
        static void Main()
        {
            // Лямбда-Выражение преобразуется в структуру данных, представляющую операцию.
            Expression<Func<int, double>> expression = x => x + 1;

            // Компилируем выражение в делегат.
            Func<int, double> func = expression.Compile();

            for (int i = 0; i < 10; i++ )
                Console.WriteLine("Результат: {0}", func.Invoke(i));

            // Задержка.
            Console.ReadKey();
        }
    }
}