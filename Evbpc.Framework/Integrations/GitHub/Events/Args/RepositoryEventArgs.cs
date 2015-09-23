using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class RepositoryEventArgs : EventArgs
    {
        public RepositoryEvent Event { get; }

        public RepositoryEventArgs(RepositoryEvent e)
        {
            Event = e;
        }
    }
}
