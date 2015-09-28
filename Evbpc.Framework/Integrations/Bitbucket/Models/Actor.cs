using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Actor
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "display_name")]
        public string DisplayName { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        [DataMember(Name = "links")]
        public Links Links { get; set; }
    }
}
