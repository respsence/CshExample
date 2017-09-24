using System;
using System.Windows;
using System.Net;
using System.Diagnostics;


namespace AsyncFetch
{

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

         void GetButtonClick(object sender, RoutedEventArgs e)
        {
            dataTextBox.Text +="Calling DoDownload";
             DoDownloadAsync();
            dataTextBox.Text +="DoDownload done";
        }

         async void DoDownloadAsync()
        {
            
            using (var w = new WebClient())
            {
                try
                {
                    string txt =  await w.DownloadStringTaskAsync("http://www.micr1osoft.com/");
                    dataTextBox.Text += txt;
                }
                catch (Exception e)
                {
                    dataTextBox.Text += e.Message;
                }
              
            }
        }
       
        void DoDownload()
        {
            using (var w = new WebClient())
            {
                string txt = w.DownloadString("http://www.micros1oft.com/");
                dataTextBox.Text += txt;
            }
        }
    }
}
