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
    public class TeamAddEvent
    {
        public const string WebhookEventName = "team_add";

        [DataMember(Name = "team")]
        public Team Team { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
