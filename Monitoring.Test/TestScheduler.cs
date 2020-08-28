using System;

namespace Monitoring.Test
{
    public class TestScheduler : IScheduler
    {
        public event EventHandler Alarm;
        public void Start()
        {
            var handler = Alarm;
            handler?.Invoke(this, new EventArgs());
        }
    }
}
