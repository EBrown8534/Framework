using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class MembershipEventArgs : EventArgs
    {
        public MembershipEvent Event { get; }

        public MembershipEventArgs(MembershipEvent e)
        {
            Event = e;
        }
    }
}
