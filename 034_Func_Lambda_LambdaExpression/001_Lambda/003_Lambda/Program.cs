using System;

namespace Lambda
{
    class Program
    {
        static void Main()
        {
            int number = 0;

            // Анонимный метод - как аргумент метода.
            WriteStream(() => number++) ;

            Console.WriteLine("Результат: {0}", number);

            // Задержка.
            Console.ReadKey();
        }

        // Делегат в качестве формального аргумента.
        static void WriteStream(Func<int> counter)
        {
            for (int i = 0; i < 10; ++i)
                Console.Write("{0}, ", counter.Invoke());
        }
    }
}
