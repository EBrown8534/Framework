using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class PullRequestEventArgs : EventArgs
    {
        public PullRequestEvent Event { get; }

        public PullRequestEventArgs(PullRequestEvent e)
        {
            Event = e;
        }
    }
}
