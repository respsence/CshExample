using System;

namespace AttributeWork
{
    [My("XXX", "1/1/1111")]
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Ctor BaseClass!!!");
        }
    }
}