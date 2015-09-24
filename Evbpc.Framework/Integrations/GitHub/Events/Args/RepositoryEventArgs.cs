using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="RepositoryEvent"/>.
    /// </summary>
    public class RepositoryEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public RepositoryEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="RepositoryEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public RepositoryEventArgs(RepositoryEvent e)
        {
            Event = e;
        }
    }
}
