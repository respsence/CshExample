using System;
using System.Runtime;

// Работа Деструктора.

namespace SimpleFinalize
{

    public class ResourceWrapper
    {
        ~ResourceWrapper()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(".");
        }
    }

    class Program
    {
        static void Main()
        {
            ResourceWrapper resource =  // Так как имеется сильная ссылка, сразу финализация не происходит.
                new ResourceWrapper();
            GC.Collect();
          //  resource = null;

            Console.WriteLine("\n\nНажмите любую клавишу для завершения работы");
            Console.WriteLine("и вызова (Деструктора) Finalize() сборщиком мусора");
            Console.WriteLine("для объектов предусматривающих финализацию в AppDomain.");

            // Задержка.
            Console.ReadKey();
        }
    }
}
