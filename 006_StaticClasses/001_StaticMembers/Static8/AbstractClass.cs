using System;

namespace Static
{
    abstract class AbstractClass
    {
        // Статический фабричный метод.
        public static AbstractClass CreateObject()
        {
            return new ConcreteClass();
        }

        public abstract void Method();
    }
}
