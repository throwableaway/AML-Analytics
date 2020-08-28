using System;
using System.Xml;

namespace Monitoring
{
    // TODO I am not sure about the naming
    public class MonitoringRepository : IRepository
    { 
        private const string Url = "https://www.treasury.gov/ofac/downloads/sdn.xml";

        public Tuple<string, int> GetPublishInformation()
        {
            using var reader = XmlReader.Create(Url);
            var newPublishDate = string.Empty;
            var newRecordCount = 0;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Publish_Date")
                    newPublishDate = reader.ReadInnerXml();

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Record_Count" && int.TryParse(reader.ReadInnerXml(), out newRecordCount))
                    break;
            }

            return new Tuple<string, int>(newPublishDate, newRecordCount);
        }
    }
}