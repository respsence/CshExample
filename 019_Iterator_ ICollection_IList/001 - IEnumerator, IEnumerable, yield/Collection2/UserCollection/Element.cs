using System;

// Создание простой пользовательской коллекции с использованием обобщенных интерфейсов.

namespace Collection
{
	// Класс, представляющий собой содержимое коллекции.
	class Element
	{
		public int FieldA { get; set; }
		public int FieldB { get; set; }

		public Element(int fieldA, int fieldB)
		{
			FieldA = fieldA;
			FieldB = fieldB;
		}
	}
}
