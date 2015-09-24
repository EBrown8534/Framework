using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="CommitCommentEvent"/>.
    /// </summary>
    public class CommitCommentEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public CommitCommentEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="CommitCommentEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public CommitCommentEventArgs(CommitCommentEvent e)
        {
            Event = e;
        }
    }
}
