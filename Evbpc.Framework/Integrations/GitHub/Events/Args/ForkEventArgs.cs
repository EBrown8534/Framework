using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class ForkEventArgs : EventArgs
    {
        public ForkEvent Event { get; }

        public ForkEventArgs(ForkEvent e)
        {
            Event = e;
        }
    }
}
