using System;
using SDKInterface;

namespace SDK_Plugin
{
    [Serializable]
    public class AddInA : IAddIn
    {
        public String DoSomething(Int32 x)
        {
            return "AddIn_A: " + x;
        }
    }

    public class AddInB : MarshalByRefObject, IAddIn
    {
        public String DoSomething(Int32 x)
        {
            return "AddIn_B: " + (x * 2);
        }
    }
}
