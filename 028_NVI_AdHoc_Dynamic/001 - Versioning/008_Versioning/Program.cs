using System;

namespace ConsoleApplication1
{
	class BaseClass
	{
		public virtual void SomeMetod1()
		{
			Console.WriteLine("1");
		}

		public virtual void SomeMetod2()
		{
			Console.WriteLine("2");
		}
	}

	class DerivedClass : BaseClass
	{
		// Без NEW срабатывает как с NEW - НО, предупреждение компилятора.
		public void SomeMetod1()
		{
			Console.WriteLine("3");
		}

		public override void SomeMetod2()
		{
			Console.WriteLine("4");
		}
	}

	class DerivedFromDerivedClass : DerivedClass
	{
	}


	class Program
	{
		static void Main()
		{
			Console.WriteLine("BaseClass");

			BaseClass c1 = new DerivedClass();
			c1.SomeMetod1(); // вернет "1"
			c1.SomeMetod2(); // вернет "4"


			Console.WriteLine("DerivedClass");

			DerivedClass c2 = new DerivedClass();
			c2.SomeMetod1();
			c2.SomeMetod2();


			Console.WriteLine("DerivedFromDerivedClass");

			DerivedFromDerivedClass c3 = new DerivedFromDerivedClass();
			c3.SomeMetod1();
			c3.SomeMetod2();

			Console.ReadKey();
		}
	}
}
