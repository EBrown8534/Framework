using Evbpc.Framework.Drawing;
using Evbpc.Framework.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Provides an interface to be used for tracking the position of an object, in classes similar to the <see cref="Camera"/> class.
    /// </summary>
    public interface ITrackableObject
    {
        /// <summary>
        /// Gets the position of the <see cref="ITrackableObject"/>.
        /// </summary>
        PointF Position { get; }

        /// <summary>
        /// Gets the size of the <see cref="ITrackableObject"/>.
        /// </summary>
        SizeF Size { get; }

        /// <summary>
        /// An event that objects tracking the current <see cref="ITrackableObject"/> can subscribe to in order to receive notifications of changes to the <see cref="Position"/>.
        /// </summary>
        event EventHandler<PositionChangedEventArgs> PositionChanged;
    }
}
