using System;
using System.Linq;
using System.Threading;

// Извлечение сведений о настройке из домена приложения.

namespace Domains
{
    class Program
    {
        static void ListAllAssembliesInAppDomain(AppDomain defaultAD)
        {
            // Доступ к домену приложения по умолчанию для текущего потока. 


            // Извлечение списка всех сборок, загруженных в этот домен приложения. 
            var loadedAssemblies = from a in defaultAD.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("--------------- Список сборок в {0} ---------------\n", defaultAD.FriendlyName);

            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

        static void Main()
        {
            Console.SetWindowSize(80, 58);
            // Создание нового домена приложения.
            AppDomain domain = AppDomain.CreateDomain("MyDomain");

            // Вывод информации о доменах.
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("\nNew domain: " + domain.FriendlyName);

            // Возвращает базовый каталог, в котором распознаватель сборок производит поиск.
            Console.WriteLine("\nApplication base is: " + domain.BaseDirectory);

            // Является ли домен используемым по умолчанию?
            Console.WriteLine("\nIs {0} the default domain? - {1}", domain.FriendlyName, domain.IsDefaultAppDomain());

            // Является ли домен используемым по умолчанию?
            Console.WriteLine("\nIs {0} the default domain? - {1}", AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain.IsDefaultAppDomain());

            // Настроен ли домен приложения для теневого копирования файлов.
            Console.WriteLine("\nShadow copy files is set to: " + domain.ShadowCopyFiles);

            Console.WriteLine();

            // Перечислить все сборки в данном домене.
            ListAllAssembliesInAppDomain(domain);
            ListAllAssembliesInAppDomain(AppDomain.CurrentDomain);
            AppDomain.Unload(domain);

            // Delay.
            Console.ReadKey();
        }
    }
}