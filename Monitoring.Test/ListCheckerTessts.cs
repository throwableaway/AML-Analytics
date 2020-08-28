using System;
using NUnit.Framework;

namespace Monitoring.Test
{
    public class ListCheckerTests
    {
        private ListChecker _sut;
        private TestMonitoringRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new TestMonitoringRepository();
            _repository.SetPublishInformation(new Tuple<string, int>("08/25/2020", 8292));

            var scheduler = new TestScheduler();
            _sut = new ListChecker(_repository, scheduler);
        }

        [Test]
        public void GivenPublishInformation_WhenInformationIsUpdated_ThenUpdated()
        {
            _repository.SetPublishInformation(new Tuple<string, int>("08/28/2020", 8299));
            _sut.StartChecking();

            Assert.That(_sut.PublishDate, Is.EqualTo("08/28/2020"));
            Assert.That(_sut.RecordCount, Is.EqualTo(8299));
        }
    }
}