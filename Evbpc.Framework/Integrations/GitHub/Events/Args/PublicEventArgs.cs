using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class PublicEventArgs : EventArgs
    {
        public PublicEvent Event { get; }

        public PublicEventArgs(PublicEvent e)
        {
            Event = e;
        }
    }
}
