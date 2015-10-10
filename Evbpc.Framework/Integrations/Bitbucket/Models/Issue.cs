using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Issue
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "component")]
        public string Component { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public Content Content { get; set; }

        [DataMember(Name = "priority")]
        public string Priority { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "milestone")]
        public Milestone Milestone { get; set; }

        [DataMember(Name = "version")]
        public Version Version { get; set; }

        [DataMember(Name = "created_on")]
        public string CreatedOn { get; set; }

        [DataMember(Name = "updated_on")]
        public string UpdatedOn { get; set; }

        [DataMember(Name = "links")]
        public Links Links { get; set; }
    }
}
