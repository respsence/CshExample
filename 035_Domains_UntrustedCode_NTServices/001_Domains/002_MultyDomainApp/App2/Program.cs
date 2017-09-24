using System;
using System.Windows.Forms;

// В свойствах проекта, установите тип приложения - Windows Application.

namespace App2
{
    public static class Program 
    {
        public static void Main()
        {
            MessageBox.Show("App2", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
