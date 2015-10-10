using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Content
    {
        [DataMember(Name = "raw")]
        public string Raw { get; set; }

        [DataMember(Name = "html")]
        public string Html { get; set; }

        [DataMember(Name = "markup")]
        public string Markup { get; set; }
    }
}
