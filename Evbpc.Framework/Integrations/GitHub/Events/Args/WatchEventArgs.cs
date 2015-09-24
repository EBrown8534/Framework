using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="WatchEvent"/>.
    /// </summary>
    public class WatchEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public WatchEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="WatchEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public WatchEventArgs(WatchEvent e)
        {
            Event = e;
        }
    }
}
