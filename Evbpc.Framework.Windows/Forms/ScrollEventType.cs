using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the type of action used to raise the <see cref="ScrollBar.Scroll"/> event.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.ScrollEventType(v=vs.110).aspx
    /// </remarks>
    public enum ScrollEventType
    {
        /// <summary>
        /// The scroll box has stopped moving.
        /// </summary>
        EndScroll,
        /// <summary>
        /// The scroll box was moved to the <see cref="ScrollBar.Minimum"/> position.
        /// </summary>
        First,
        /// <summary>
        /// The scroll box moved a large distance. The user clicked the scroll bar to the left(horizontal) or above(vertical) the scroll box, or pressed the PAGE UP key.
        /// </summary>
        LargeDecrement,
        /// <summary>
        /// The scroll box moved a large distance. The user clicked the scroll bar to the right(horizontal) or below(vertical) the scroll box, or pressed the PAGE DOWN key.
        /// </summary>
        LargeIncrement,
        /// <summary>
        /// The scroll box was moved to the <see cref="ScrollBar.Maximum"/> position.
        /// </summary>
        Last,
        /// <summary>
        /// The scroll box was moved a small distance. The user clicked the left(horizontal) or top(vertical) scroll arrow, or pressed the UP ARROW key.
        /// </summary>
        SmallDecrement,
        /// <summary>
        /// The scroll box was moved a small distance. The user clicked the right(horizontal) or bottom(vertical) scroll arrow, or pressed the DOWN ARROW key.
        /// </summary>
        SmallIncrement,
        /// <summary>
        /// The scroll box was moved.
        /// </summary>
        ThumbPosition,
        /// <summary>
        /// The scroll box is currently being moved.
        /// </summary>
        ThumbTrack
    }
}
