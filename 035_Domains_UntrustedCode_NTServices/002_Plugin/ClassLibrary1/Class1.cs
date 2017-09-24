using System;
using SDKInterface;

namespace ClassLibrary1
{
    public class AddInC_2 : MarshalByRefObject, IAddIn
    {
        public String DoSomething(Int32 x)
        {
            return "AddIn_C_2: " + (x);
        }
    }
}
