using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

using AsyncAwait.Helpers;
using AsyncAwait.Model;

namespace AsyncAwait
{
    public partial class AsyncDemoForm : Form
    {
        readonly TimeService _timeService;
        readonly Progress<ProgressEventArgs> _progress;
        readonly Func<String> _getTimeDelegate;

        public AsyncDemoForm()
        {
            InitializeComponent();

            label1.Visible = false;
            _progress = new Progress<ProgressEventArgs>();
            _progress.ProgressChanged += progress_ProgressChanged;
            _timeService = new TimeService(_progress);
            _getTimeDelegate = _timeService.GetTime;
            //_timeService.UpdateUI += _timeService_UpdateUI;
        }

        void _timeService_UpdateUI()
        {
            Application.DoEvents();
        }

        void SynchronousButton_Click(object sender, EventArgs e)
        {
            SynchronousLabel.Text = _timeService.GetTime();
        }

        void CallbackButton_Click(object sender, EventArgs e)
        {
            panel1.DisableControls<Button>();

            _getTimeDelegate.BeginInvoke(GetTimeComplete, null);
        }

        void GetTimeComplete(IAsyncResult ar)
        {
            var del = ((AsyncResult)ar).AsyncDelegate as Func<string>;
            var dateTimeResult = del.EndInvoke(ar);

            Invoke(new Action(() =>
                                   {
                                       panel1.EnableControls<Button>();
                                       CallbackLabel.Text = dateTimeResult;
                                   }));
        }

        async void AsyncButton_Click(object sender, EventArgs e)
        {
            panel1.DisableControls<Button>();

            AsyncLabel.Text = await _timeService.GetTimeAsync();

            panel1.EnableControls<Button>();
        }

        void progress_ProgressChanged(object sender, ProgressEventArgs e)
        {
            //TODO: Check this bug in sync!
            //Application.DoEvents();
            workProgressBar.Value = e.Value;
       
            if (e.Value >= 100)
            {
                label1.Visible = false;
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public int Value;
    }
}
