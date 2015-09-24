using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="ForkEvent"/>.
    /// </summary>
    public class ForkEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public ForkEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ForkEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public ForkEventArgs(ForkEvent e)
        {
            Event = e;
        }
    }
}
