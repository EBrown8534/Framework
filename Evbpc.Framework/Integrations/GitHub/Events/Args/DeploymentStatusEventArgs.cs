using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="DeploymentStatusEvent"/>.
    /// </summary>
    public class DeploymentStatusEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public DeploymentStatusEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DeploymentStatusEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public DeploymentStatusEventArgs(DeploymentStatusEvent e)
        {
            Event = e;
        }
    }
}
