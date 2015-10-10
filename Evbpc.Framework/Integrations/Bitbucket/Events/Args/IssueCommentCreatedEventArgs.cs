using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Bitbucket.Events.Args
{
    public class IssueCommentCreatedEventArgs : EventArgs
    {
        public IssueCommentCreatedEvent Event { get; }

        public IssueCommentCreatedEventArgs(IssueCommentCreatedEvent e)
        {
            Event = e;
        }
    }
}
