using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_WPF_Context
{
    static class Program
    {
        static void Main()
        {
            MultipleContinueWith(Sum,100000);

            Thread.Sleep(2000);
        }

        static Task<T> MultipleContinueWith<T>(Func<object,T> func, T arg)
        {

            var t = new Task<T>(func,arg);


            t.ContinueWith(task => Console.WriteLine("The sum is: " + task.Result),
                           TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith(task => Console.WriteLine("Sum threw: " + task.Exception.InnerException.Message),
                           TaskContinuationOptions.OnlyOnFaulted);

            t.Start();

            return t;
        }

        static Int32 Sum(object arg)
        {
           
            Int32 sum = 0, x = (Int32)arg;
            for (; x > 0; x--)
             //   checked
                {
                    sum += x;
                }
            return sum;
        }
    }
}
