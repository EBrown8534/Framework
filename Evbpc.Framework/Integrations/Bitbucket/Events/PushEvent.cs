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
    /// Represents a Bitbucket <see cref="Repository"/> push event.
    /// </summary>
    [DataContract]
    public class PushEvent
    {
        /// <summary>
        /// The name of the webhook that indicates the event is a <see cref="PushEvent"/>.
        /// </summary>
        public const string WebhookEventName = "repo:push";

        /// <summary>
        /// The <see cref="Models.Actor"/> who committed the <see cref="PushEvent"/>.
        /// </summary>
        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        /// <summary>
        /// Represents the commits included in this <see cref="PushEvent"/>.
        /// </summary>
        [DataMember(Name = "push")]
        public Push Push { get; set; }

        /// <summary>
        /// Represents the <see cref="Models.Repository"/> that this <see cref="PushEvent"/> was committed to.
        /// </summary>
        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }
    }
}
