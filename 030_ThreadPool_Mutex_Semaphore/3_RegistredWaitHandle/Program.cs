﻿using System;
using System.Threading;

// Блокировка потоков, бесконечно ожидающих доступ к объекту ядра - не рациональная трата памяти.
// Пул потока предлагает механизм вызова метода.

namespace RegistredWaitHandleNs
{
    class Program
    {
        static void Main()
        {
            AutoResetEvent auto = new AutoResetEvent(false);
            WaitOrTimerCallback callback = new WaitOrTimerCallback(CallbackMethod);

            // auto - от кого ждать сингнал
            // callback - что выполнять
            // null - 1-й аргумент Callback метода
            // 1000 - интервал между вызовами Callback метода
            // если true - вызвать Callback метод один раз. Если false - вызывать Callback метод с интервалом.
      //      ThreadPool.RegisterWaitForSingleObject(auto, callback, null, Timeout.Infinite, true);

           var waitHandle =  ThreadPool.RegisterWaitForSingleObject(auto, callback, null, 1000, false); 
        
            Console.WriteLine("S - сигнал, Q - выход");

            while (true)
            {
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();

                if (operation == "S")
                {
                   auto.Set();
                }
                if (operation == "Q")
                {
                    waitHandle.Unregister(auto);
                    break;
                }
            }
            Console.ReadKey();
        }

        static void CallbackMethod(object state, bool timedOut)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Signal");
        }
    }
}
