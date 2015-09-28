using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events.Args
{
    public class PushEventArgs
    {
        public PushEvent Event { get; }

        public PushEventArgs(PushEvent e)
        {
            Event = e;
        }
    }
}
