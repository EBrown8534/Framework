using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Represents event data used in the <see cref="ITrackableObject.TrackableObjectChanged"/> event.
    /// </summary>
    public class TrackableObjectChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the value of the <see cref="ITrackableObject.Position"/> after the <see cref="ITrackableObject.TrackableObjectChanged"/> event.
        /// </summary>
        public PointF NewPosition { get; }
        /// <summary>
        /// Gets the value of the <see cref="ITrackableObject.Position"/> before the <see cref="ITrackableObject.TrackableObjectChanged"/> event.
        /// </summary>
        public PointF OldPosition { get; }
        /// <summary>
        /// Gets the value of the <see cref="ITrackableObject.Size"/> after the <see cref="ITrackableObject.TrackableObjectChanged"/> event.
        /// </summary>
        public SizeF NewSize { get; }
        /// <summary>
        /// Gets the value of the <see cref="ITrackableObject.Size"/> before the <see cref="ITrackableObject.TrackableObjectChanged"/> event.
        /// </summary>
        public SizeF OldSize { get; }

        /// <summary>
        /// Constructs a new instance of <see cref="TrackableObjectChangedEventArgs"/> from the specified values.
        /// </summary>
        /// <param name="newPosition">The <see cref="NewPosition"/>.</param>
        /// <param name="oldPosition">The <see cref="OldPosition"/>.</param>
        /// <param name="newSize">The <see cref="NewSize"/>.</param>
        /// <param name="oldSize">The <see cref="OldSize"/>.</param>
        public TrackableObjectChangedEventArgs(PointF newPosition, PointF oldPosition, SizeF newSize, SizeF oldSize)
        {
            NewPosition = newPosition;
            OldPosition = oldPosition;
            NewSize = newSize;
            OldSize = oldSize;
        }
    }
}
