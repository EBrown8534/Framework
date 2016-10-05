using System;
using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "category")]
        public string Cateogry { get; set; }

        [XmlElement(ElementName = "comments")]
        public string Comments { get; set; }

        [XmlElement(ElementName = "enclosure")]
        public XmlEnclosure Enclosure { get; set; }

        [XmlElement(ElementName = "guid")]
        public XmlGuid Guid { get; set; }

        [XmlIgnore]
        public DateTimeOffset PubDateTime { get; set; }

        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get { return PubDateTime.ToString(RssFeed.DateFormat); } set { PubDateTime = DateTimeOffset.ParseExact(value, RssFeed.DateFormat, null); } }

        [XmlElement(ElementName = "source")]
        public XmlSource Source { get; set; }
    }
}