using System;
using System.IO;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Reflection;

namespace SandBox
{
    //Обязательно наследование от MarshalByRefObject для перехода по "ссылке"
    class Sandboxer : MarshalByRefObject
    {
        const string pathToUntrusted = @"..\..\..\UntrustedCode\bin\Debug";
        const string untrustedAssembly = "UntrustedCode";
        const string untrustedClass = "UntrustedCode.UntrustedClass";
        const string entryPoint = "IsFibonacci";

        private static readonly Object[] parameters = { 45 };

        static void Main()
        {
            //Необходимо установить путь отличный от того, где находится SandBox
            var adSetup = new AppDomainSetup { ApplicationBase = Path.GetFullPath(pathToUntrusted) };

            // Настраиваем права для  AppDomain. Даем разрешение на выполнение кода.
            // Список прав : http://msdn.microsoft.com/ru-ru/library/24ed02w7.aspx
            var permSet = new PermissionSet(PermissionState.None);
            permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            permSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess,"c:\\Temp\\"));

            var fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();

            //Создаем домен приложения и загружаем в него сборку.
            var newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);

            //Use CreateInstanceFrom to load an instance of the Sandboxer class into the
            //new AppDomain. 
            var handle = Activator.CreateInstanceFrom(
                newDomain,
                typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
                typeof(Sandboxer).FullName
                );
            var newDomainInstance = (Sandboxer)handle.Unwrap();

            newDomainInstance.ExecuteUntrustedCode(entryPoint, parameters);
        }

        public void ExecuteUntrustedCode(string method, Object[] parameters)
        {
            this.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, method, parameters);
        }

        public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, Object[] parameters)
        {
           var target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);
            try
            {
                var retVal = (bool)target.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                (new PermissionSet(PermissionState.Unrestricted)).Assert();
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("SecurityException caught:\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(ex);
                    Console.WriteLine(new string('-',20));
                    Console.WriteLine(ex.InnerException);
                CodeAccessPermission.RevertAssert();

                Console.ReadLine();
            }
      
        }
    }
}