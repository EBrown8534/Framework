using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="PushEvent"/>.
    /// </summary>
    public class PushEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public PushEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PushEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public PushEventArgs(PushEvent e)
        {
            Event = e;
        }
    }
}
