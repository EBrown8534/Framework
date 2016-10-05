using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    [XmlRoot(ElementName = "rss")]
    public class RssFeed
    {
        public const string DateFormat = "R";

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; } = "2.0";

        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }
}
