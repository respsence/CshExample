using System;

// Выгрузка домена приложения.

namespace Domains
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Создание нового AppDomain.");
            AppDomain domain = AppDomain.CreateDomain("MyDomain");

            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Child domain: " + domain.FriendlyName);

            AppDomain.Unload(domain); // Выгрузка домена приложения.

            try
            {
                Console.WriteLine("\nHost domain: " + AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine("Child domain: " + domain.FriendlyName); // AppDomainUnloadedException, т.к. домен не существует.
            }
            catch (AppDomainUnloadedException e)
            {
                Console.WriteLine(e.GetType().FullName);
                Console.WriteLine("The appdomain MyDomain does not exist.");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
