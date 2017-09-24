using System;
using GoodLibrary;

// NVI - (Non-Virtual Interface) Невиртуальный Интерфейс

namespace NVI
{
    public class Derived : Base
	{
		protected override void CoreDoWork()
		{
			Console.WriteLine("Derived.DoWork()");
		}
	}

	class Program
	{
		static void Main()
		{
			Base instance = new Derived();
			instance.DoWork();             // = "Derived.DoWork()"

			// Задержка.
			Console.ReadKey();
		}
	}
}
