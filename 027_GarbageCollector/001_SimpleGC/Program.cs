using System;
using System.Runtime;
using System.Threading;

// ПОКОЛЕНИЯ (Генерации)
// Поколение 0 - Объекты не проверялись сборщиком мусора.
// Поколение 1 - Объекты пережившие одну проверку сборщиком мусора(а также объекты помеченные на удаление, но не удаленные,
//               так как в управляемой куче было достаточно свободного места).
// Поколение 2 - Объекты которые пережили более чем одну проверку сборщиком мусора.

namespace SimpleGC
{
    class Program
    {
        static void Main()
        {
            Thread.Sleep(4000);
            // Смотрим Размер памяти в байтах которую занимают объекты в управляемой куче.
            // Метод GetTotalMemory() возвращает размер памяти в байтах которую занимают объекты в управляемой куче.
            // Этот метод принимает параметр указывающий, запускать или нет процесс сборки мусора.
            Console.WriteLine("Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));

            // Свойство MaxGeneration - возвращает максимальное количество поколений, 
            // поддерживаемое данной системой. (Отсчет с нуля поэтому + 1)
            Console.WriteLine("Система поддерживает {0} поколения.\n", (GC.MaxGeneration + 1));

            // Создается новый объект в динамической памяти (куче).
            // Возвращается ссылка на этот объект и присваивается переменной car. 
            
            Car car = new Car("RENAULT", 120);

            // Перегруженный ToString().
            Console.WriteLine(car.ToString());

            // Метод GetGeneration() возвращает поколение, к которому относится данный объект.
            Console.WriteLine("\nОбъект car относится к {0} поколению.\n", GC.GetGeneration(car));

            Console.WriteLine("Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));

            // Массив объектов для тестирования.
            object[] array = new object[10000000];

            ShowGCStat();
          
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new object();
            }
           
            Console.WriteLine("Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));
            array = null;
            
            Console.WriteLine("\nМассив построен, запускаем GC ");
            
            ShowGCStat();
            var start = DateTime.Now;
            // Метод Collect - дает указание сборщику муссора проверить объекты определенного поколения (В данном случае - 2).            
            GC.Collect();

            // Метод WaitForPendingFinalizers() - приостанавливает выполнение текущего потока, пока
            // не будут отработаны все объекты, предусматривающие финализацию. 
            // Вызывается обычно непосредственно после вызова  GC.Collect().
            GC.WaitForPendingFinalizers();

            Console.WriteLine("GC отрабтал                   " + (DateTime.Now - start).TotalMilliseconds + "\n");
            
            Console.WriteLine("Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));

            Console.WriteLine("\nОбъект car относится к {0} поколению.\n", GC.GetGeneration(car));

            // Метод CollectionCount() - возвращает числовое значение, сколько раз данная 
            // генерация (поколение) выживала при сборке мусора.
           
            ShowGCStat();

            // Задержка.
          //  Console.ReadKey();
        }

        private static void ShowGCStat()
        {
            Console.WriteLine("\nПоколение 0 проверялось {0} раз", GC.CollectionCount(0));
            Console.WriteLine("Поколение 1 проверялось {0} раз", GC.CollectionCount(1));
            Console.WriteLine("Поколение 2 проверялось {0} раз", GC.CollectionCount(2));
        }
    }
}
