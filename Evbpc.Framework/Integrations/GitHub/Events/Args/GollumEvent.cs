﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Events.Args
{
    /// <summary>
    /// Represents a <see cref="GollumEvent"/>.
    /// </summary>
    public class GollumEventArgs : EventArgs
    {
        /// <summary>
        /// The event to represent.
        /// </summary>
        public GollumEvent Event { get; }

        /// <summary>
        /// Creates a new instance of <see cref="GollumEventArgs"/>.
        /// </summary>
        /// <param name="e">The event data.</param>
        public GollumEventArgs(GollumEvent e)
        {
            Event = e;
        }
    }
}
