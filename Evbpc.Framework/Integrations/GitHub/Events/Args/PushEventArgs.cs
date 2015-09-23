using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class PushEventArgs : EventArgs
    {
        public PushEvent Event { get; }

        public PushEventArgs(PushEvent e)
        {
            Event = e;
        }
    }
}
