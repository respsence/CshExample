using System;
using System.Collections.Generic;

namespace LambdaIterator
{
    public static class IteratorExtensions
    {
        // Расширяющий метод.
        public static IEnumerable<TItem> MakeCustomIterator<TCollection, TCursor, TItem>(this TCollection collection,                       
                                                                                         TCursor cursor,                               
                                                                                         Func<TCollection, TCursor, TItem> getCurrent, 
                                                                                         Func<TCollection, TCursor, bool> isFinished,               
                                                                                         Func<TCursor, TCursor> advanceCursor)
        {
            while (!isFinished(collection, cursor))
            {
                yield return getCurrent(collection, cursor);
                cursor = advanceCursor(cursor);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Матрица.
            //var matrix = new List<List<double>> {new List<double> { 1.0, 1.1, 1.2 },
            //                                     new List<double> { 2.0, 2.1, 2.2 },
            //                                     new List<double> { 3.0, 3.1, 3.2 }
            //                                    };

            ////IEnumerable<double> iter = matrix.MakeCustomIterator<List<List<double>>, Int32[], double>(...);
            //IEnumerable<double> iter = matrix.MakeCustomIterator(new[] { 0, 0 },
            //                                     (coll, cur) => coll [cur[0]] [cur[1]],
            //                                     (coll, cur)=> cur[0] > coll.Count-1 || cur[1] > coll.,
            //                                     cur => new[] { cur[0]+1 , cur[1] + 1 });
         
       
            //// Вывод на экран.
            //foreach (double item in iter)
            //    Console.WriteLine(item);


            var iter2 = "Hello"
                            .MakeCustomIterator(0,
                            (col, cur) => col[cur] + " ",
                            (col, cur) => cur > col.Length-1,
                            cur => cur + 2);

            foreach (var symbol in iter2)
            {
                Console.Write(symbol);
            }

           // Задержка.
            Console.ReadKey();
        }
    }
}
