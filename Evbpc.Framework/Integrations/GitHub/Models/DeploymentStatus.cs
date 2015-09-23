using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class DeploymentStatus
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "creator")]
        public Sender Creator { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "target_url")]
        public string TargetUrl { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "deployment_url")]
        public string DeploymentUrl { get; set; }

        [DataMember(Name = "repository_url")]
        public string RepositoryUrl { get; set; }
    }
}