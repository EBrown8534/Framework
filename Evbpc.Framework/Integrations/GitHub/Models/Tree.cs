using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Tree
    {
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}