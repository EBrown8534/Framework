using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="MembershipEvent"/>.
    /// </summary>
    public class MembershipEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public MembershipEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MembershipEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public MembershipEventArgs(MembershipEvent e)
        {
            Event = e;
        }
    }
}
