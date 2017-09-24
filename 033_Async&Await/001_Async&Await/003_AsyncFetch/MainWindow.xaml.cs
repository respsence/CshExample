using System.Windows;
using System.Net;
using System.Threading.Tasks;

namespace AsyncFetch
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetButtonClick(object sender, RoutedEventArgs e)
        {
            dataTextBox.Text +="Staring async download\n";
            DoDownload();
            dataTextBox.Text +="Async download started\n";
        }

        async Task DoDownload()
        {
            
            var req = (HttpWebRequest) WebRequest.Create("http://www.microsoft.com");
            req.Method = "GET";
            var resp = (HttpWebResponse) await req.GetResponseAsync();
      
            dataTextBox.Text += resp.Headers.ToString();
            dataTextBox.Text +="Async download completed";
        }

        async void DoDownloadFromAsync()
        {
            var req = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            req.Method = "GET";

            Task<WebResponse> getResponseTask = Task.Factory.FromAsync<WebResponse>(
                req.BeginGetResponse, req.EndGetResponse, null);

            var resp = (HttpWebResponse) await getResponseTask;

            string headersText = resp.Headers.ToString();
            dataTextBox.Text += headersText;
            dataTextBox.Text += "Async download completed";
        }
    }
}
