using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class XmlEnclosure
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "length")]
        public int Length { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}