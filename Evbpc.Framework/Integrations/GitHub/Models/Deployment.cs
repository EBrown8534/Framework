using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Deployment
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "task")]
        public string Task { get; set; }

        [DataMember(Name = "payload")]
        public object Payload { get; set; }

        [DataMember(Name = "environment")]
        public string Environment { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "creator")]
        public Sender Creator { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "statuses_url")]
        public string StatusesUrl { get; set; }

        [DataMember(Name = "repository_url")]
        public string RepositoryUrl { get; set; }
    }
}