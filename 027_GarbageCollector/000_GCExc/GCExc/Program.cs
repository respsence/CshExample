using System;

namespace GCExc
{
    class Test
    {
        // Массив для утяжеления объекта.

        int[] array = new int[100000000]; // 100 000 000 Б * 4 = 400 000 000 Б = 390 625 КБ = 381 МБ

        public void Method(int i)
        {
            Console.WriteLine(i);
        }

        // Деструктор. - Вызывается Сборщиком Мусора!
        ~Test()
        {
            Console.WriteLine("Объект " + this.GetHashCode() + " удален");
        }
    }

    class Program
    {
        static void Main()
        {

            // Массив объектов - Test.
            var tests = new Test[1000]; // 381 * 1000 = 381 000 МБ = 372 ГБ - размер всего массива.

            try
            {
                for (int i = 0; i < tests.Length; i++)
                {
                    tests[i] = new Test();
                    tests[i].Method(i);

                    // Закомментировать блок выше и снять комментарий с блока ниже.
                    //Test test = new Test();

                    //test.Method(i);
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Управляемая куча ПЕРЕПОЛНЕНА!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ReadKey();
            // Задержка.

        }
    }
}
