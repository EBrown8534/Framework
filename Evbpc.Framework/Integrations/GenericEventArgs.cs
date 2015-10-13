using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations
{
    /// <summary>
    /// Represents a generic event that has only one field.
    /// </summary>
    /// <typeparam name="T">The type of the event.</typeparam>
    public class GenericEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Represents the data associated with the event.
        /// </summary>
        public T Event { get; }

        /// <summary>
        /// Constructs a new instance of <see cref="GenericEventArgs{T}"/> with the specified <see cref="Event"/>.
        /// </summary>
        /// <param name="thisEvent">The object to be put in the <see cref="Event"/>.</param>
        public GenericEventArgs(T thisEvent)
        {
            Event = thisEvent;
        }
    }
}
