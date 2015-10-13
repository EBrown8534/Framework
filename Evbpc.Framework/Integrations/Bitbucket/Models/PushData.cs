using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Models
{
    [DataContract]
    public class Push
    {
        [DataMember(Name = "changes")]
        public List<Changes> Changes { get; set; }
    }
}
