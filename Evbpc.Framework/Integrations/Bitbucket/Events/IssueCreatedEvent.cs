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
    /// Represents a Bitbucket issue creation.
    /// </summary>
    [DataContract]
    public class IssueCreatedEvent
    {
        /// <summary>
        /// The name of the webhook that indicates the event is a <see cref="IssueCreatedEvent"/>.
        /// </summary>
        public const string WebhookEventName = "issue:created";

        /// <summary>
        /// The <see cref="Models.Actor"/> who created the <see cref="Issue"/>.
        /// </summary>
        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        /// <summary>
        /// The <see cref="Models.Issue"/> that was created.
        /// </summary>
        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        /// <summary>
        /// The <see cref="Models.Repository"/> that the <see cref="Issue"/> belongs to.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }
    }
}
