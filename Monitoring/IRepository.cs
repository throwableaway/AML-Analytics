using System;

namespace Monitoring
{
    public interface IRepository
    {
        public Tuple<string, int> GetPublishInformation();
    }
}