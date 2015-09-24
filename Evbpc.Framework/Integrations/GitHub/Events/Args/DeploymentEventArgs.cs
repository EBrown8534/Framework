using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="DeploymentEvent"/>.
    /// </summary>
    public class DeploymentEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public DeploymentEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DeploymentEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public DeploymentEventArgs(DeploymentEvent e)
        {
            Event = e;
        }
    }
}
