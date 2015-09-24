using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="IssuesEvent"/>.
    /// </summary>
    public class IssuesEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public IssuesEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="IssuesEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public IssuesEventArgs(IssuesEvent e)
        {
            Event = e;
        }
    }
}
