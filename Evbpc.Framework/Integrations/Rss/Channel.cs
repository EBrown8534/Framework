using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class Channel
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }

        [XmlElement(ElementName = "managingEditor")]
        public string ManagingEditor { get; set; }

        [XmlElement(ElementName = "webMaster")]
        public string WebMaster { get; set; }

        [XmlIgnore]
        public DateTimeOffset PubDateTime { get; set; }

        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get { return PubDateTime.ToString(RssFeed.DateFormat); } set { PubDateTime = DateTimeOffset.ParseExact(value, RssFeed.DateFormat, null); } }

        [XmlIgnore]
        public DateTimeOffset LastBuildDateTime { get; set; }

        [XmlElement(ElementName = "lastBuildDate")]
        public string LastBuildDate { get { return LastBuildDateTime.ToString(RssFeed.DateFormat); } set { LastBuildDateTime = DateTimeOffset.ParseExact(value, RssFeed.DateFormat, null); } }

        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; }

        [XmlElement(ElementName = "docs")]
        public string Docs { get; set; }

        [XmlElement(ElementName = "cloud")]
        public string Cloud { get; set; }

        [XmlElement(ElementName = "ttl")]
        public int? TimeToLive { get; set; }

        [XmlElement(ElementName = "image")]
        public XmlImage Image { get; set; }

        [XmlElement(ElementName = "textInput")]
        public string TextInput { get; set; }

        [XmlElement(ElementName = "skipHours")]
        public List<int> SkipHours { get; set; }

        [XmlElement(ElementName = "skipDays")]
        public List<string> SkipDays { get; set; }

        [XmlElement(ElementName = "item")]
        public List<Item> Items { get; set; }
    }
}
