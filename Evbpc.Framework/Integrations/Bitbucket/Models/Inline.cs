using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Inline
    {
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "to")]
        public string To { get; set; }
    }
}