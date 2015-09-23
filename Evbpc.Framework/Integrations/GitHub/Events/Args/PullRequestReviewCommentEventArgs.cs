using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    public class PullRequestReviewCommentEventArgs : EventArgs
    {
        public PullRequestReviewCommentEvent Event { get; }

        public PullRequestReviewCommentEventArgs(PullRequestReviewCommentEvent e)
        {
            Event = e;
        }
    }
}
