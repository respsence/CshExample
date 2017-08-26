using System;

// Техника Делегирования.

namespace Delegation
{
    class A
    {
        public void DoSomething()
        {
            Console.WriteLine("Action");
        }
    }

    class B
    {
        public void DoSomething()
        {
            A a = new A();
            a.DoSomething();
        }
    }

    class Program
    {
        static void Main()
        {
            B b = new B();
            b.DoSomething();

            // Delay.
            Console.ReadKey();
        }
    }
}
