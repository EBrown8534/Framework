using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Repository
    {
        [DataMember(Name = "scm")]
        public string SCM { get; set; }

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        [DataMember(Name = "links")]
        public Links Links { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "owner")]
        public Author Owner { get; set; }

        [DataMember(Name = "is_private")]
        public bool IsPrivate { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
