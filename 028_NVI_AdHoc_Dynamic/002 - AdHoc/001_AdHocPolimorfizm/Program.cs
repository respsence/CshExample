using System;

// AdHoc полиморфизм.

namespace AdHocPolimorfizm
{
    interface IInterface
    {
        void Method();
    }

    //Just for fun!
    class MyClass1 : Class1, IInterface { }
    class MyClass2 : Class2, IInterface { }
    class MyClass3 : Class3, IInterface { }

    class Program
    {
        static void Main()
        {
            IInterface[] array = { new MyClass1(), new MyClass2(), new MyClass3() };

            for (var i = 0; i < 3; i++)
                array[i].Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
