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
    public class DeleteEvent
    {
        public const string WebhookEventName = "delete";

        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "ref_type")]
        public string RefType { get; set; }

        [DataMember(Name = "pusher_type")]
        public string PusherType { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
