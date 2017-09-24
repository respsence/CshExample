using System.ServiceProcess;
using System.Diagnostics;
using System.Timers;
using System.Net;
using System.IO;
using System;

namespace WindowsServices
{
    public partial class MyService : ServiceBase
    {
        readonly Timer timer;

        public MyService()
        {
            InitializeComponent();
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Отправка HTTP запроса.
                const string url = "http://www.microsoft.com";
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                // Сохранение ответа в текстовый файл.
                string path = @"c:\temp\log.txt";

                var file = new FileInfo(path);
                var writer = file.AppendText();

                //TextWriter writer = new StreamWriter(path, true);
                writer.WriteLine(DateTime.Now.ToString() + " for " + url + ": " + response.StatusCode.ToString());
                writer.Close();

                // Закрытие HTTP запроса.
                response.Close();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "Exception: " + ex.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        protected override void OnContinue()
        {
            this.OnStart(null);
        }

        protected override void OnPause()
        {
            this.OnStop();
        }

        protected override void OnShutdown()
        {
            this.OnStop();
        }
    }
}
