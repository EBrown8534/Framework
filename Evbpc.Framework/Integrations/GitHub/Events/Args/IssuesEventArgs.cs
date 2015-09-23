using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class IssuesEventArgs : EventArgs
    {
        public IssuesEvent Event { get; }

        public IssuesEventArgs(IssuesEvent e)
        {
            Event = e;
        }
    }
}
