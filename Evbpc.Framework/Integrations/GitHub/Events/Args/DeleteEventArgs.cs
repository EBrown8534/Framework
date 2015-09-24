using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="DeleteEvent"/>.
    /// </summary>
    public class DeleteEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public DeleteEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DeleteEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public DeleteEventArgs(DeleteEvent e)
        {
            Event = e;
        }
    }
}
