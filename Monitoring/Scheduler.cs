using System;
using System.Timers;

namespace Monitoring
{
    public class Scheduler : IScheduler
    {
        public event EventHandler Alarm;
        private readonly Timer _timer;

        public Scheduler()
        {
            _timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            var handler = Alarm;
            handler?.Invoke(this, e);
        }

        public void Start()
        {
            _timer.Start();
        }
    }
}
