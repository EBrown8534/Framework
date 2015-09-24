using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="MemberEvent"/>.
    /// </summary>
    public class MemberEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public MemberEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MemberEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public MemberEventArgs(MemberEvent e)
        {
            Event = e;
        }
    }
}
