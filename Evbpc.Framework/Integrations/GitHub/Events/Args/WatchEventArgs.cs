using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class WatchEventArgs : EventArgs
    {
        public WatchEvent Event { get; }

        public WatchEventArgs(WatchEvent e)
        {
            Event = e;
        }
    }
}
