using System;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main()
        {

            using (var wrapper = new ResourceWrapper())
            {
                Console.WriteLine(wrapper);
            }
            Console.WriteLine(new string('-',20));


            var wrapper2 = new ResourceWrapper();
            Console.WriteLine(wrapper2);

            wrapper2.Dispose();
            wrapper2.Dispose();
            wrapper2.Dispose();
            wrapper2.Dispose();

            var wrapper3 = new ResourceWrapper();

            Console.ReadKey();
            Console.WriteLine("Press any key to dispose");

        }
    }
}
