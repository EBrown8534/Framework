using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Head
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "user")]
        public Sender User { get; set; }

        [DataMember(Name = "repo")]
        public Repository Repo { get; set; }
    }
}