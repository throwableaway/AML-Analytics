using System;

namespace Monitoring
{
    internal class Program
    {
        private static void Main()
        {
            IRepository repository = new MonitoringRepository();
            IScheduler scheduler = new Scheduler();
            new ListChecker(repository, scheduler).StartChecking();

            Console.ReadKey();
        }
    }
}
