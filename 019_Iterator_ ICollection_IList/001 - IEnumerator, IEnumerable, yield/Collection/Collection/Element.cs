// Создание простой пользовательской коллекции.

namespace Collection.Collection
{
	// Класс, представляющий собой содержимое коллекции.
	public class Element
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
