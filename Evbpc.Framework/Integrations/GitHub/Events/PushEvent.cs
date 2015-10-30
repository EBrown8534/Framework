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
    /// Triggered when a repository branch is pushed to. In addition to branch pushes, webhook push events are also triggered when repository tags are pushed.
    /// </summary>
    [DataContract(Name = "root")]
    public class PushEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "push";

        /// <summary>
        /// The full Git ref that was pushed. Example: "refs/heads/master".
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        /// <summary>
        /// The SHA of the most recent commit on ref after the push.
        /// </summary>
        [DataMember(Name = "head")]
        public string Head { get; set; }

        /// <summary>
        /// The SHA of the most recent commit on ref before the push.
        /// </summary>
        [DataMember(Name = "before")]
        public string Before { get; set; }

        /// <summary>
        /// The number of commits in the push.
        /// </summary>
        [DataMember(Name = "size")]
        public int Size { get; set; }

        /// <summary>
        /// The number of distinct commits in the push.
        /// </summary>
        [DataMember(Name = "distinct_size")]
        public int DistinctSize { get; set; }

        [DataMember(Name = "after")]
        public string After { get; set; }

        [DataMember(Name = "created")]
        public bool Created { get; set; }

        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        [DataMember(Name = "forced")]
        public bool Forced { get; set; }

        [DataMember(Name = "base_ref")]
        public string BaseRef { get; set; }

        [DataMember(Name = "compare")]
        public string Compare { get; set; }

        /// <summary>
        /// An array of commit objects describing the pushed commits. (The array includes a maximum of 20 commits. If necessary, you can use the Commits API to fetch additional commits. This limit is applied to timeline events only and isn’t applied to webhook deliveries.)
        /// </summary>
        [DataMember(Name = "commits")]
        public List<Commit> Commits { get; set; }

        [DataMember(Name = "head_commit")]
        public Commit HeadCommit { get; set; }

        [DataMember(Name = "pusher")]
        public Author Pusher { get; set; }

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
