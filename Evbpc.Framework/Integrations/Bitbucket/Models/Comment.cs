using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "parent")]
        public int Parent { get; set; }

        [DataMember(Name = "content")]
        public Content Content { get; set; }

        [DataMember(Name = "inline")]
        public Inline Inline { get; set; }

        [DataMember(Name = "created_on")]
        public string CreatedOn { get; set; }

        [DataMember(Name = "updated_on")]
        public string UpdatedOn { get; set; }

        [DataMember(Name = "links")]
        public Links Links { get; set; }
    }
}
