using System;
using System.Collections.Generic;

namespace Lambda
{
    class Program
    {
        static void Main()
        {
            var members = new List<string>
                                       {
                                           "Один - One", 
                                           "Два - Two", 
                                           "Три - Three",
                                           "Одиннадцать - Eleven", 
                                       };

            WriteStream(members, "а", (x, y) => x.ToLower().Contains(y));
         
            
            
            // Задержка.
            Console.ReadKey();
        }

        // Метод.
        static void WriteStream(IEnumerable<string> members, string name, Func<string, string, bool> predicate)
        {
            foreach (string member in members)
                if (predicate(member, name)) // Делегат-Предикат.
                    Console.WriteLine(member);
        }
    }
}
