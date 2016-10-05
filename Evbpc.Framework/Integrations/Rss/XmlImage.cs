using System.Xml.Serialization;

namespace Evbpc.Framework.Integrations.Rss
{
    public class XmlImage
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "width")]
        public int? Width { get; set; }

        [XmlElement(ElementName = "height")]
        public int? Height { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }
}