using System.Runtime.Serialization;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    /// <summary>
    /// Represents a GitHub deployment object for a <see cref="Events.DeploymentEvent"/>.
    /// </summary>
    [DataContract]
    public class Deployment
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The short or long sha that was recorded at creation time. Default: none
        /// </summary>
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        /// <summary>
        /// The name of the ref. This can be a branch, tag, or sha. Default: none
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        /// <summary>
        /// The name of the task for the deployment. e.g. deploy or deploy:migrations. Default: none
        /// </summary>
        [DataMember(Name = "task")]
        public string Task { get; set; }

        [DataMember(Name = "payload")]
        public object Payload { get; set; }

        /// <summary>
        /// The name of the environment that was deployed to. e.g. staging or production. Default: none
        /// </summary>
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