using System;
using System.Windows.Forms;

// В свойствах проекта, установите тип приложения - Windows Application.

namespace App1
{
    public static class Program
    {
        public static void Main() 
        {
            MessageBox.Show("App1", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
