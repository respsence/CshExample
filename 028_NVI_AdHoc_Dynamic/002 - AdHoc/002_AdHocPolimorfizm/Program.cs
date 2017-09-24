using System;

namespace AdHocPolimorfizm
{
    class Program
    {
        static void Main()
        {
            dynamic[] array = { new Class1(), new Class2(), new Class3() };
                                   
            foreach (var item in array)
                item.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
