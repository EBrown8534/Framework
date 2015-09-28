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
    public class PushEvent
    {
        public const string WebhookEventName = "repo:push";

        [DataMember(Name = "actor")]
        public Actor Actor { get; set; }

        [DataMember(Name = "push")]
        public PushData Push { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }
    }
}
