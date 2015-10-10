using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events.Args
{
    public class IssueCreatedEventArgs : EventArgs
    {
        public IssueCreatedEvent Event { get; }

        public IssueCreatedEventArgs(IssueCreatedEvent e)
        {
            Event = e;
        }
    }
}
