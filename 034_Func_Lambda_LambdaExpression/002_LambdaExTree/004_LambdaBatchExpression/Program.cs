using System;
using System.Linq.Expressions;
using System.Reflection;

namespace _004_LambdaBatchExpression
{
    static class Program
    {

        static void Main()
        {

            #region MethodInfo

            MethodInfo consoleWriteLine = typeof(Console).GetMethod("WriteLine", new[] { typeof(String) });
            MethodInfo consoleReadLine = typeof(Console).GetMethod("ReadLine");
            MethodInfo stringConcat = typeof(String).GetMethod("Concat", new[] { typeof(String), typeof(String) });
            MethodInfo convertToTnt = typeof(Convert).GetMethod("ToInt32", new[] { typeof(String) });
            MethodInfo convertToString = typeof(Convert).GetMethod("ToString", new[] { typeof(Int32) });

            #endregion

            #region Constants and Parameters

            var enterA = Expression.Constant("Enter a:");
            var enterB = Expression.Constant("Enter b:");
            var theSumIs = Expression.Constant("The sum of a and b is : ");
            var exceptionMessage = Expression.Constant("Exception: ");

            var parameterA = Expression.Parameter(typeof(Int32), "a");
            var parameterB = Expression.Parameter(typeof(Int32), "b");
            var parameterResult = Expression.Parameter(typeof(Int32), "sum");
            var message = Expression.Parameter(typeof(String), "message");

            var exception = Expression.Parameter(typeof(Exception), "ex");


            #endregion


            var callReadLine = Expression.Call(consoleReadLine);

            var block = Expression.Block(new[]
                {
                    parameterA, parameterB, parameterResult, message
                },

                // Console.WriteLine(enterA);
                Expression.Call(consoleWriteLine, enterA),

                // int parameterA = Convert.ToInt32(Console.ReadLine());
                Expression.Assign(parameterA, Expression.Call(convertToTnt, callReadLine)),

                // Console.WriteLine(enterB);
                Expression.Call(consoleWriteLine, enterB),

                // int parameterB = Convert.ToInt32(Console.ReadLine());
                Expression.Assign(parameterB, Expression.Call(convertToTnt, callReadLine)),

                //int parameterResult = parameterA + parameterB;
                Expression.Assign(parameterResult, Expression.Add(parameterA, parameterB)),

                // string message = String.Concat(theSumIs, Convert.ToString(parameterResult));
                Expression.Assign(message, Expression.Call(stringConcat, theSumIs, Expression.Call(convertToString, parameterResult))),

                // Console.WriteLine(message);
                Expression.Call(consoleWriteLine, message)
                );

            //Let's make it safe :)
            // catch (Exception ex)
            //{
            //  Console.WriteLine(String.Concat(exceptionMessage, ex.Message));
            //}
            var catchBlock = Expression.Catch(exception,
                Expression.Call(consoleWriteLine,
                    Expression.Call(stringConcat, exceptionMessage, Expression.Property(exception, "Message"))));


            ////try
            //{
            //    *block
            //}
            ////catch
            //{
            //    *catchBlock
            //}
            var safeBlock = Expression.TryCatch(block, catchBlock);
 
            //-----------------------------------------------------

            #region Print out the Code!

            Console.WriteLine(safeBlock);
            foreach (var expression in block.Expressions)
            {
                Console.WriteLine("\t" + expression);
            }

            Console.WriteLine(safeBlock.Handlers[0]);
            Console.WriteLine("\t" + safeBlock.Handlers[0].Body);

            Console.WriteLine(new string('-', 40));
            #endregion
            
            Expression<Action> expressionCw = Expression.Lambda<Action>(safeBlock);

            var lambda = expressionCw.Compile();

            //Voila!
            lambda.Invoke();
        }
    }
}
