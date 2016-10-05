using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class XmlSource
    {
        [XmlText]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }
}