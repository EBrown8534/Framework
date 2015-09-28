using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Changes
    {
        [DataMember(Name = "forced")]
        public bool Forced { get; set; }

        [DataMember(Name = "truncated")]
        public bool Truncated { get; set; }

        [DataMember(Name = "new")]
        public Change New { get; set; }

        [DataMember(Name = "links")]
        public Links Links { get; set; }

        [DataMember(Name = "old")]
        public Change Old { get; set; }

        [DataMember(Name = "commits")]
        public List<Commit> Commits { get; set; }

        [DataMember(Name = "created")]
        public bool Created { get; set; }

        [DataMember(Name = "closed")]
        public bool Closed { get; set; }
    }
}
