using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class CommitCommentEventArgs : EventArgs
    {
        public CommitCommentEvent Event { get; }

        public CommitCommentEventArgs(CommitCommentEvent e)
        {
            Event = e;
        }
    }
}
