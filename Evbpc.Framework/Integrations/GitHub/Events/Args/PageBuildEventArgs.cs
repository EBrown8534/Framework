using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="PageBuildEvent"/>.
    /// </summary>
    public class PageBuildEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public PageBuildEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PageBuildEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public PageBuildEventArgs(PageBuildEvent e)
        {
            Event = e;
        }
    }
}
