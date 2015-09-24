using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="IssueCommentEvent"/>.
    /// </summary>
    public class IssueCommentEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public IssueCommentEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="IssueCommentEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public IssueCommentEventArgs(IssueCommentEvent e)
        {
            Event = e;
        }
    }
}
