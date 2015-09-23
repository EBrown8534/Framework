using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class IssueCommentEventArgs : EventArgs
    {
        public IssueCommentEvent Event { get; }

        public IssueCommentEventArgs(IssueCommentEvent e)
        {
            Event = e;
        }
    }
}
