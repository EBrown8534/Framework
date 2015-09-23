using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class MemberEventArgs : EventArgs
    {
        public MemberEvent Event { get; }

        public MemberEventArgs(MemberEvent e)
        {
            Event = e;
        }
    }
}
