using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class IssueChanges
    {
        [DataMember(Name = "status")]
        public StringChange Status { get; set; }
    }
}
