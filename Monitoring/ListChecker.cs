using System;

namespace Monitoring
{
    // TODO Naming
    public class ListChecker
    {
        private readonly IRepository _repository;
        private readonly IScheduler _scheduler;

        public string PublishDate { get; private set; }
        public int RecordCount { get; private set; }

        public ListChecker(IRepository repository, IScheduler scheduler)
        {
            _repository = repository ?? throw new ArgumentNullException();
            _scheduler = scheduler ?? throw new ArgumentNullException();

            scheduler.Alarm += TryToUpdate;

            // This should be last known from storage ( I was thinking about file storage for know)
            // but since it's a POC application it will use last known as a current data from website
            (PublishDate, RecordCount) = repository.GetPublishInformation();
        }

        private void TryToUpdate(object sender, EventArgs e)
        {
            var (newPublishDate, newRecordCount) = _repository.GetPublishInformation();

            if (PublishDate == newPublishDate && RecordCount == newRecordCount) 
                return;

            // TODO That would be stored in the database as well
            PublishDate = newPublishDate;
            RecordCount = newRecordCount;

            // I would like to push an event/notify some other 3rd party
        }

        public void StartChecking()
        {
            _scheduler.Start();
        }
    }
}