using System;
using System.Reflection;
using System.Linq;

// Атрибуты сборки - добавляются в файл AssemblyInfo.cs

namespace Attributes
{
    class Program
    {
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object[] attributes = assembly.GetCustomAttributes(false);

            foreach (Attribute attr in attributes)
            {
                Console.WriteLine("Attribute: {0}", attr.GetType().Name);
            }
            
            var appVersion = attributes.OfType<AssemblyFileVersionAttribute>().Single();

            Console.WriteLine("Приложение  версия {0}", appVersion.Version);
            
            // Delay.
            Console.ReadKey();
        }
    }
}
