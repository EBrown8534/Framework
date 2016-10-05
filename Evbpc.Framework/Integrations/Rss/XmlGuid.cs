using System;
using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class XmlGuid
    {
        [XmlText]
        public Guid Guid { get; set; }

        [XmlAttribute(AttributeName = "isPermalink")]
        public bool IsPermalink { get; set; }
    }
}