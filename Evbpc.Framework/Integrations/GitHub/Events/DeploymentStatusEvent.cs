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
    public class DeploymentStatusEvent
    {
        public const string WebhookEventName = "deployment_status";

        [DataMember(Name = "deployment")]
        public Deployment Deployment { get; set; }

        [DataMember(Name = "deployment_status")]
        public DeploymentStatus DeploymentStatus { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sender")]
        public Sender Sender { get; set; }
    }
}
