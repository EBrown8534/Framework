using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="ReleaseEvent"/>.
    /// </summary>
    public class ReleaseEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public ReleaseEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ReleaseEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public ReleaseEventArgs(ReleaseEvent e)
        {
            Event = e;
        }
    }
}
