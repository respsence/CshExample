using System;
using System.Reflection;

// Тема: ОТОБРАЖЕНИЕ ИНФОРМАЦИИ ОБ АТРИБУТЕ.

namespace AttributeWork
{
    class Program
    {
        static void Main()
        {
            // MemberInfo - абстрактный класс, используется для получения информации о членах класса. 
            //Type type = typeof(MyClass);
            MemberInfo type = typeof(MyClass);

            // Метод GetCustomAttributes() - возвращает массив объектов, которые при выполнении приложения
            // представляют собой эквиваленты атрибутов, созданных в исходном коде.
            // Извлекаем из элементов массива элементы типа - MyAttribute.
            object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), true);

            // Если в массиве есть соответствующие записи, то первый элемент представляет собой атрибут - MyAttribute.
            if (attributes.GetLength(0) != 0)
            {
                // Отображаем полученные значения.
                foreach (MyAttribute attribute in attributes)
                {
                    Console.WriteLine(attribute.Text);
                    Console.WriteLine(attribute.Data);
                    attribute.Method();
                }
            }

            //Задержка.
            Console.ReadKey();
        }
    }
}
