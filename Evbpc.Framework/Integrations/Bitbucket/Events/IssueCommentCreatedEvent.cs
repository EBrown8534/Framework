using Evbpc.Framework.Integrations.Bitbucket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events
{
    /// <summary>
    /// Represents a Bitbucket issue comment.
    /// </summary>
    [DataContract]
    public class IssueCommentCreatedEvent
    {
        /// <summary>
        /// The name of the webhook that indicates the event is a <see cref="IssueCommentCreatedEvent"/>.
        /// </summary>
        public const string WebhookEventName = "issue:comment_created";

        /// <summary>
        /// The <see cref="Models.Actor"/> who commented on the <see cref="Issue"/>.
        /// </summary>
        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        /// <summary>
        /// The <see cref="Models.Issue"/> that was commented on.
        /// </summary>
        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> that the <see cref="Issue"/> belongs to.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        /// <summary>
        /// The <see cref="Models.Comment"/> that was left on the <see cref="Issue"/>.
        /// </summary>
        [DataMember(Name = "comment")]
        public Comment Comment { get; set; }
    }
}
