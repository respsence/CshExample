using System;

// Замещение

namespace ConsoleApplication1
{
	class BaseClass
	{
		public void SomeMetod1()
		{
			Console.WriteLine("1");
		}

		public void SomeMetod2()
		{
			Console.WriteLine("2");
		}
	}

	class DerivedClass : BaseClass 
	{
		public new void SomeMetod1()
		{
			Console.WriteLine("3");
		}

		public void SomeMetod2()
		{
			Console.WriteLine("4");
		}
	}

	class Program
	{
		static void Main()
		{
			BaseClass instance = new DerivedClass();

			instance.SomeMetod1();
			instance.SomeMetod2();

		    DerivedClass ins2 = instance as DerivedClass;

			ins2.SomeMetod1();
            ins2.SomeMetod2();

			Console.ReadKey();
		}
	}
}
