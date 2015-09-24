using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="PublicEvent"/>.
    /// </summary>
    public class PublicEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public PublicEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PublicEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public PublicEventArgs(PublicEvent e)
        {
            Event = e;
        }
    }
}
