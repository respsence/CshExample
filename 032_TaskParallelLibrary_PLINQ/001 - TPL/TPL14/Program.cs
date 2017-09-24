using System;
using System.Threading.Tasks;

// Применение метода Parallel.For() для организации параллельно выполняемого цикла обработки данных.

namespace TPL
{
    class Program
    {
        static int[] data;

        // Метод служащий в качестве тела параллельно выполняемого цикла.
        // Операторы этого цикла просто расходуют время ЦП для целей демонстрации.
        static void MyTransform(int i)
        {
            data[i] = data[i] / 10;
            if (data[i] < 10000) data[i] = 0;
            if (data[i] > 10000 && data[i] < 20000) data[i] = 100;
            if (data[i] > 20000 && data[i] < 30000) data[i] = 200;
            if (data[i] > 30000) data[i] = 300;
        }


        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            data = new int[100000000];

            // Инициализация данных в обычном цикле for.
            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            // Распараллелить цикл методом For().
            Parallel.For(0, data.Length, new Action<int>(MyTransform));
           
            // Внимание!
            // Выполнение метода Main() приостанавливается, 
            // пока не произойдет возврат из метода For().

            Console.WriteLine("Основной поток завершен.");

            // Delay.
       //     Console.ReadKey();
        }
    }
}
