using Evbpc.Framework.Integrations.Bitbucket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events
{
    [DataContract]
    public class IssueCreatedEvent
    {
        public const string WebhookEventName = "issue:created";

        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }
    }
}
