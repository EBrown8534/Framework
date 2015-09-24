using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="TeamAddEvent"/>.
    /// </summary>
    public class TeamAddEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public TeamAddEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="TeamAddEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public TeamAddEventArgs(TeamAddEvent e)
        {
            Event = e;
        }
    }
}
