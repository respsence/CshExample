using System;
using System.Linq.Expressions;

namespace LambdaExpression
{
    static class Program
    {
        static void Main()
        {
            Expression<Func<int, int>> expression = n => n + 1;

            // Теперь присвоим expression значение исходного выражения умноженное на 2.            
            expression = Expression<Func<int, int>>.Lambda<Func<int, int>>
                                  (Expression.Multiply(expression.Body, Expression.Constant(2)),
                                  expression.Parameters);
                          
            // Компилируем выражение в делегат.
            Func<int, int> func = expression.Compile();
            Console.WriteLine(expression);
            for (int i = 0; i < 10; i++ )
                Console.WriteLine("Результат: {0}", func.Invoke(i));

            // Задержка.
            Console.ReadKey();
        }
    }
}
