using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Branch
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "commit")]
        public Tree Commit { get; set; }
    }
}
