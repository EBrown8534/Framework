using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    [DataContract]
    public class StatusEvent
    {
        public const string WebhookEventName = "status";

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "sha")]
        public int Sha { get; set; }

        [DataMember(Name = "name")]
        public int Name { get; set; }

        [DataMember(Name = "target_url")]
        public string TargetUrl { get; set; }

        [DataMember(Name = "context")]
        public string Context { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "commit")]
        public StatusCommit Commit { get; set; }

        [DataMember(Name = "branches")]
        public List<Branch> Branches { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
