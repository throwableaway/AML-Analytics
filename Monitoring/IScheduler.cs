using System;

namespace Monitoring
{
    public interface IScheduler
    {
        event EventHandler Alarm;
        void Start();
    }
}
