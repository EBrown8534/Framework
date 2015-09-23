using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Build
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "error")]
        public Error Error { get; set; }

        [DataMember(Name = "pusher")]
        public Sender Pusher { get; set; }

        [DataMember(Name = "commit")]
        public string Commit { get; set; }

        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }
    }
}
