using System;

namespace Lambda
{
    class Program
    {
        static void Main()
        {
            int number = 0;

            // Аргумент метода - Лямбда-Выражение не принимающее параметров.
       
            WriteStream(() => number++);
            Console.WriteLine("Результат: {0}", number);

            // Задержка.
            Console.ReadKey();
        }

        // Делегат в качестве формального параметра метода.
        static void WriteStream(Func<int> counter)
        {
            for (int i = 0; i < 2; ++i)
                Console.WriteLine("{0}, ", counter.Invoke());
        }
    }
}
