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
    /// riggered when an <see cref="IssueComment"/> is created on an issue or pull request.
    /// </summary>
    [DataContract]
    public class IssueCommentEvent
    {
        /// <summary>
        /// The name of the Webhook event for this event.
        /// </summary>
        public const string WebhookEventName = "issue_comment";

        /// <summary>
        /// The action that was performed on the comment. Currently, can only be “created”.
        /// </summary>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The <see cref="Models.Issue"/> the <see cref="Comment"/> belongs to.
        /// </summary>
        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        /// <summary>
        /// The <see cref="IssueComment"/> itself
        /// </summary>
        [DataMember(Name = "comment")]
        public IssueComment Comment { get; set; }

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
