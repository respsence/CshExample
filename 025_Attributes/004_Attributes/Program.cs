using System;
using System.Reflection;

// Глобальные атрибуты для всей сборки.
[assembly: AssemblyVersionAttribute("1.0.2000.0")]      // Версия сборки.
[assembly: AssemblyTitle("AssemblySmpl")]               // Имя сборки.
[assembly: AssemblyDescription("")]                     // Описание сборки.
[assembly: AssemblyConfiguration("")]                   // Конфигурация, например, Release или Debug.
[assembly: AssemblyCompany("CyberBionic Systematics")]  // Имя компании разработчика.
[assembly: AssemblyProduct("AssemblySmpl")]             // Имя продукта.
[assembly: AssemblyCopyright("Copyright 2009")]         // Копирайты.
[assembly: AssemblyTrademark("")]                       // Торговая марка.
[assembly: AssemblyCulture("")]                         // Какие культуры поддерживает сборка. 

namespace AssemblySmpl
{
    public class Program
    {
        public static void Main()
        {
            // Получение сборки (Assembly assembly) код которой выполняется в данный моемент.
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Полное имя сборки.
            Console.WriteLine("Assembly Full Name:\n{0}", assembly.FullName);
            
            // AssemblyName объект, который позволяет разбить полное имя сборки на части.
            AssemblyName assemblyName = assembly.GetName();

            Console.WriteLine("\nName: {0}", assemblyName.Name);                                           // Имя сборки
            Console.WriteLine("Version: {0}.{1}", assemblyName.Version.Major, assemblyName.Version.Minor); // Версия сборки.
            Console.WriteLine("\nAssembly CodeBase: \n{0}", assembly.CodeBase);                              // Место хранения сборки.

            // Точка входа сборки AssemblySmpl.
            Console.WriteLine("\nAssembly entry point:");

            Console.WriteLine(assembly.EntryPoint);

            // Задержка.
            Console.ReadKey();
        }
    }
}
