using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="PullRequestEvent"/>.
    /// </summary>
    public class PullRequestEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public PullRequestEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PullRequestEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public PullRequestEventArgs(PullRequestEvent e)
        {
            Event = e;
        }
    }
}
