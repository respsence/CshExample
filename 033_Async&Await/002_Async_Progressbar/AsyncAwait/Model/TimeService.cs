using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Model
{
    public class TimeService
    {
        private readonly IProgress<ProgressEventArgs> _progress;

        public TimeService()
        {
            
        }
        public TimeService(IProgress<ProgressEventArgs> progress)
        {
            _progress = progress;
        }

        public string GetTime()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
           
                if (_progress != null) _progress.Report(new ProgressEventArgs { Value = i });
            }

            return DateTime.Now.ToString("HH:mm:ss.fff");
        }

        public async Task<string> GetTimeAsync()
        {
            return await Task.Run(() => GetTime());
        }

    }
}