using System;

namespace Monitoring.Test
{
    public class TestMonitoringRepository : IRepository
    {
        public Tuple<string, int> PublishInformation { get; set; }

        public Tuple<string, int> GetPublishInformation()
        {
            return PublishInformation;
        }

        public void SetPublishInformation(Tuple<string, int> publishInformation)
        {
            PublishInformation = publishInformation;
        }
    }
}
