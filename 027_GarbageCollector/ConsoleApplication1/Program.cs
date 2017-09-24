using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var timer = new Timer(Method, "Hello", 0, 200);
          
            Console.ReadLine();
            timer.Dispose();
        }

        static void Method(object state)
        {
            Console.WriteLine(state);
            GC.Collect();
        }
    }
}
