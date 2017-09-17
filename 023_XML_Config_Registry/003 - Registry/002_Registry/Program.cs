using System;
using Microsoft.Win32;

// Навигация по реестру.

namespace RegistryBasics
{
    class Program
    {
        static void Main()
        {
            // Процесс получения ссылки на объект RegistryKey называется открытием ключа.
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey software = myKey.OpenSubKey("Software");
            RegistryKey microsoft = software.OpenSubKey("Microsoft");
           // software.Close();

            Console.WriteLine("{0} - всего элементов: {1}.", microsoft.Name, microsoft.SubKeyCount);
            microsoft.Close();

            // Попытка открыть несуществующий ключ. Переменной будет присвоено значение NULL.
            software = myKey.OpenSubKey("StrangeName");

            // В блоке try совершается попытка обратится к переменной, значение которой не присвоено.
            try
            {
                Console.WriteLine("Открыли узел: {0}.", software.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());
            }

            // Задержка на экране.
            Console.ReadKey();
        }
    }
}
