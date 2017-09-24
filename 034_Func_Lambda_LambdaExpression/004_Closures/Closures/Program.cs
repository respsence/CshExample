using System;

namespace Closures
{
    class Closure
    {
        private Func<int, int> func;

        public void Method()
        {
            
        }
    }
    class Program
    {
        static void Main()
        {
            // Переменная delta и делегат func формируют Замыкание.
            int delta = 1;

            Func<int, int> func = (x) => x + delta++;

            int currentVal = 0; // Аргумент Анонимного метода.

            for (int i = 0; i < 10; ++i)
            {
                currentVal = func(currentVal);
                Console.WriteLine(currentVal);
                Console.WriteLine("---------------" + delta.ToString());
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
