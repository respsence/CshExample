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

            // ������� ��������� ����� ����������
            AppDomain ad2 = AppDomain.CreateDomain("PluginAD");

            // ������������ ���������� �������� ����������� ����� � �������� ���������
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += ad2_ReflectionOnlyAssemblyResolve;

            // ��������� � �������� ��������� ������ � ��������� (���, ����������� � ���� ��������, ����� ���� ���������������,
            // �� �� ����� ���� ��������)
            // ���������: http://msdn.microsoft.com/ru-ru/library/system.reflection.assembly.reflectiononlyloadfrom.aspx
            foreach (Assembly assembly in pluginLibraries.Select(Assembly.ReflectionOnlyLoadFrom))
                foreach (TypeInfo type in assembly.DefinedTypes)
                {
                    //������� ����, � ������, ������� ��������� ��������� IAddIn � ����������� �� MarshalByRefObject
                    if (type.IsClass
                     && type.IsAbstract == false
                     && type.ImplementedInterfaces.Any(it => it.GUID == typeof(IAddIn).GUID)
                     && type.BaseType == typeof(MarshalByRefObject))

                    // ��������� ��� - ��� ������������ ������
                    // ������ �������� CreateInstanceFromAndUnwrap �������� ��������� ���� �� ��������� ������, 
                    // � ��������� ������ �� ������-������
                    // � ��������� addInTypes.
                    {
                        IAddIn proxy = ad2.CreateInstanceFromAndUnwrap(type.Assembly.CodeBase, type.FullName) as IAddIn;
                        addInTypes.Add(proxy);
                    }
                }

            Console.WriteLine(new string('-', 40));

            Console.WriteLine("������� {0} ������������ ������!", addInTypes.Count);

            foreach (IAddIn t in addInTypes)
            {
                Console.WriteLine("������ {0} �������� �� {1}", t,
                                  RemotingServices.IsTransparentProxy(t) ?
                                    "������" : "��������");

                Console.WriteLine(t.DoSomething(5));
                Console.WriteLine(new string('-', 15));
            }

            AppDomain.Unload(ad2);
            Console.WriteLine("Plugins executed succesfully");
            Console.ReadKey();
        }

        // ���� ���������� ���������� ����� CLR �������� �������� ��������� �������� ������ � ��������� ���������.
        static Assembly ad2_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            //�������� ������ ��������� ������
            string strTempAssmbPath = "";

            Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            if (arrReferencedAssmbNames.Any(
                strAssmbName => strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(","))))
            {
                strTempAssmbPath = Path.GetDirectoryName(objExecutingAssemblies.Location) + "\\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
            }
            //��������� ������ � �������� ���������					
            Assembly myAssembly = Assembly.ReflectionOnlyLoadFrom(strTempAssmbPath);

            //���������� ������ �� ����������� ������
            return myAssembly;
        }
    }
}