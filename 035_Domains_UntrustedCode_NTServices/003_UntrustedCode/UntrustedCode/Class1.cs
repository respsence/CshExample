using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace UntrustedCode
{
    public class UntrustedClass
    {
        public static bool IsFibonacci(int number)
        {
           File.WriteAllText("C:\\text.txt","gbhj g hj ghj ghj ghkj k5555555555555");
            Console.WriteLine("Hello from AppDomain"); 
            return false;
        }
    }
}