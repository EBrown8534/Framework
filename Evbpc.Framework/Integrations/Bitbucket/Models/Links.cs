using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Links
    {
        [DataMember(Name = "self")]
        public Link Self { get; set; }

        [DataMember(Name = "avatar")]
        public Link Avatar { get; set; }

        [DataMember(Name = "html")]
        public Link Html { get; set; }

        [DataMember(Name = "commits")]
        public Link Commits { get; set; }

        [DataMember(Name = "diff")]
        public Link Diff { get; set; }
    }
}
