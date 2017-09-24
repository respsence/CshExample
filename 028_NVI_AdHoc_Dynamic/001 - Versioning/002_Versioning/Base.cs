using System;

namespace GoodLibrary
{
    public class Base
    {
        public void DoWork()
        {
            PreDoWork();
            CoreDoWork();
        }

        void PreDoWork()
        {
            Console.WriteLine("Base.PreDoWork();");
        }

        protected virtual void CoreDoWork()
        {
            Console.WriteLine("Base.DoWork()");
        }
    }
}