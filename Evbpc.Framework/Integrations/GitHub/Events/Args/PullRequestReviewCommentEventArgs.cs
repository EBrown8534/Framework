using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="PullRequestReviewCommentEvent"/>.
    /// </summary>
    public class PullRequestReviewCommentEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public PullRequestReviewCommentEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PullRequestReviewCommentEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public PullRequestReviewCommentEventArgs(PullRequestReviewCommentEvent e)
        {
            Event = e;
        }
    }
}
