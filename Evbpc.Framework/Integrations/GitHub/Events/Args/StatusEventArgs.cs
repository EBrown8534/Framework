using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="StatusEvent"/>.
    /// </summary>
    public class StatusEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public StatusEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="StatusEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public StatusEventArgs(StatusEvent e)
        {
            Event = e;
        }
    }
}
