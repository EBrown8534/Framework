using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class ReleaseEventArgs : EventArgs
    {
        public ReleaseEvent Event { get; }

        public ReleaseEventArgs(ReleaseEvent e)
        {
            Event = e;
        }
    }
}
