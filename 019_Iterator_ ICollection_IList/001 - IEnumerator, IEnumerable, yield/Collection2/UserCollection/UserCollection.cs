using System;
using System.Collections;
using System.Collections.Generic;

// Создание простой пользовательской коллекции с использованием обобщенных интерфейсов.

namespace Collection
{
	// Класс, представляющий собой пользовательскую коллекцию.
	public class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
	{
	    readonly T[] elements = new T[4];

		public T this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

		int position = -1;

		// Реализация интерфейса IEnumerator<T>:
		// 1. Метод MoveNext().
        bool IEnumerator.MoveNext()
		{
		    if (position < elements.Length - 1)
			{
				position++;
				return true;
			}
		    return false;
		}

	    // 2. Метод Reset().
        void IEnumerator.Reset()
		{
			position = -1;
		}

		// 3. Свойство Current.
		object IEnumerator.Current
		{
			get { return elements[position]; }
		}

		// 4. Обобщенное свойство Current.
		T IEnumerator<T>.Current
		{
			get { return elements[position]; }
		}

		// Реализация интерфейса IEnumerable<T>:
		// 1. Метод GetEnumerator().
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}
		// 2. Обобщенный метод GetEnumerator().
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
		    return this;
		}

		// Реализация интерфейса IDisposable:
		// 1. Метод Dispose().
		void IDisposable.Dispose()
		{
			((IEnumerator)this).Reset();
		}
	}
}
