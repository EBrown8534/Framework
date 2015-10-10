using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events.Args
{
    public class IssueUpdatedEventArgs : EventArgs
    {
        public IssueUpdatedEvent Event { get; set; }

        public IssueUpdatedEventArgs(IssueUpdatedEvent e)
        {
            Event = e;
        }
    }
}
