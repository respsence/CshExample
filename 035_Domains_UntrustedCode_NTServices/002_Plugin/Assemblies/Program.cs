using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Remoting;
using SDKInterface;

namespace Assemblies
{
    public static class Program
    {
        public static void Main()
        {
            String pluginsPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) 
                                    + ConfigurationManager.AppSettings["pluginsDirectory"];
            String[] pluginLibraries = Directory.GetFiles(pluginsPath, "*.dll");

            var addInTypes = new List<IAddIn>();

            // Создаем вторичный домен приложения
            AppDomain ad2 = AppDomain.CreateDomain("PluginAD");

            // Регистрируем обработчик загрузки необходимых типов в контекст рефлексии
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += ad2_ReflectionOnlyAssemblyResolve;

            // Загружаем в контекст рефлексии сборки с плагинами (Код, загруженный в этот контекст, может быть проанализирован,
            // но не может быть выполнен)
            // Детальнее: http://msdn.microsoft.com/ru-ru/library/system.reflection.assembly.reflectiononlyloadfrom.aspx
            foreach (Assembly assembly in pluginLibraries.Select(Assembly.ReflectionOnlyLoadFrom))
                foreach (TypeInfo type in assembly.DefinedTypes)
                {
                    //Находим типы, в сборке, которые реализуют интерфейс IAddIn и наследуются от MarshalByRefObject
                    if (type.IsClass
                     && type.IsAbstract == false
                     && type.ImplementedInterfaces.Any(it => it.GUID == typeof(IAddIn).GUID)
                     && type.BaseType == typeof(MarshalByRefObject))

                    // Найденный тип - это подключаемый модуль
                    // Значит вызываем CreateInstanceFromAndUnwrap создавая экземпляр типа во вторичном домене, 
                    // и добавляем ссылку на прокси-сервер
                    // в коллекцию addInTypes.
                    {
                        IAddIn proxy = ad2.CreateInstanceFromAndUnwrap(type.Assembly.CodeBase, type.FullName) as IAddIn;
                        addInTypes.Add(proxy);
                    }
                }

            Console.WriteLine(new string('-', 40));

            Console.WriteLine("Найдено {0} подключаемых модуля!", addInTypes.Count);

            foreach (IAddIn t in addInTypes)
            {
                Console.WriteLine("Модуль {0} доступен по {1}", t,
                                  RemotingServices.IsTransparentProxy(t) ?
                                    "ссылке" : "значению");

                Console.WriteLine(t.DoSomething(5));
                Console.WriteLine(new string('-', 15));
            }

            AppDomain.Unload(ad2);
            Console.WriteLine("Plugins executed succesfully");
            Console.ReadKey();
        }

        // Этот обработчик вызывается когда CLR пытается неудачно выполнить привязку сборки в контексте отражения.
        static Assembly ad2_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            //Получаем список связанных сборок
            string strTempAssmbPath = "";

            Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            if (arrReferencedAssmbNames.Any(
                strAssmbName => strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(","))))
            {
                strTempAssmbPath = Path.GetDirectoryName(objExecutingAssemblies.Location) + "\\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
            }
            //Загружаем сборку в контекст отражения					
            Assembly myAssembly = Assembly.ReflectionOnlyLoadFrom(strTempAssmbPath);

            //Возвращаем ссылку на загруженную сборку
            return myAssembly;
        }
    }
}