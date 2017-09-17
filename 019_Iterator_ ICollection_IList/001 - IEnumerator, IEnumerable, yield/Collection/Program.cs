using System;
using System.Collections.Generic;
using Collection.UserCollection;

// Создание простой пользовательской коллекции.

namespace Collection
{
	class Program
	{
		static void Main()
		{
		  
			// Создаем коллекцию.
			var сollection = new UserCollection<Element>();

			// Помещаем в коллекцию 4 элемента.
			сollection[0] = new Element(1, 2);
			сollection[1] = new Element(3, 4);
			сollection[2] = new Element(5, 6);
			сollection[3] = new Element(7, 8);

            Console.WriteLine("Foreach 1");
			// В циклической конструкции foreach выводим содержимое коллекции на экран.
			foreach (Element element in сollection)
			{
                Console.WriteLine("{0}, {1}",
                    element.FieldA,
                    element.FieldB);
			}

			Console.WriteLine(new string('-', 5));

		    Console.WriteLine("Foreach 2");

            // В циклической конструкции foreach выводим содержимое коллекции на экран.
			foreach (Element element in сollection)
			{
				Console.WriteLine("{0}, {1}",
					element.FieldA,
					element.FieldB);
			}

            Console.WriteLine(new string('-', 5));
            Console.WriteLine("Manual 1");
            
            var enumerator = (сollection as IEnumerable<Element>).GetEnumerator();

            while (enumerator.MoveNext())
            {
                var element = enumerator.Current;

                Console.WriteLine("{0}, {1}",
                  element.FieldA,
                  element.FieldB);
            }

            if (сollection is IDisposable)
                ((IDisposable) сollection).Dispose();

			// Delay.
			Console.ReadKey();
		}
	}
}
