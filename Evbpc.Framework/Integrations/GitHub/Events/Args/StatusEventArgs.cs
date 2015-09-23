using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class StatusEventArgs : EventArgs
    {
        public StatusEvent Event { get; }

        public StatusEventArgs(StatusEvent e)
        {
            Event = e;
        }
    }
}
