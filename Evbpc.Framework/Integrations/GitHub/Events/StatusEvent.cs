using Evbpc.Framework.Integrations.GitHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events
{
    /// <summary>
    /// Triggered when the status of a Git commit changes.
    ///
    /// Events of this type are not visible in timelines, they are only used to trigger hooks.
        /// </summary>
    [DataContract]
    public class StatusEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "status";

        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The Commit SHA.
        /// </summary>
        [DataMember(Name = "sha")]
        public int Sha { get; set; }

        [DataMember(Name = "name")]
        public int Name { get; set; }

        /// <summary>
        /// The optional link added to the status.
        /// </summary>
        [DataMember(Name = "target_url")]
        public string TargetUrl { get; set; }

        [DataMember(Name = "context")]
        public string Context { get; set; }

        /// <summary>
        /// The optional human-readable description added to the status.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The new state. Can be pending, success, failure, or error.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "commit")]
        public StatusCommit Commit { get; set; }

        /// <summary>
        /// An array of <see cref="Models.Branch"/> objects containing the status’ SHA. Each branch contains the given SHA, but the SHA may or may not be the head of the branch. The array includes a maximum of 10 branches.
        /// </summary>
        [DataMember(Name = "branches")]
        public List<Branch> Branches { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> for this event.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        /// <summary>
        /// The <see cref="Models.Sender"/> that triggered the event.
        /// </summary>
        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
