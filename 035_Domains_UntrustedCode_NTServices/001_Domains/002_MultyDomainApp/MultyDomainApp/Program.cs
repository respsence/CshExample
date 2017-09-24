using System;

// Загрузка исполняемых файлов в домен.

// Для выполнения этого проекта требуется скопировать исполняемые файлы App1.exe и App2.exe 
// в папку с исполняемым файлом MultyDomainApp.exe

namespace MultyDomainApp
{
    static class Program
    {
        static void Main()
        {
            // Создание доменов.
            AppDomain domain1 = AppDomain.CreateDomain("Domain 1");
            AppDomain domain2 = AppDomain.CreateDomain("Domain 2");
            
            // Запуск приложений в контексте вторичных доменов.
            domain1.ExecuteAssembly("App1.exe");
            domain2.ExecuteAssembly("App2.exe");
                       
            // Delay.
            Console.ReadKey();
        }
    }
}
