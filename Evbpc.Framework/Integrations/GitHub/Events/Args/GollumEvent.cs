using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class GollumEventArgs : EventArgs
    {
        public GollumEvent Event { get; }

        public GollumEventArgs(GollumEvent e)
        {
            Event = e;
        }
    }
}
