using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="CreateEvent"/>.
    /// </summary>
    public class CreateEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public CreateEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="CreateEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public CreateEventArgs(CreateEvent e)
        {
            Event = e;
        }
    }
}
