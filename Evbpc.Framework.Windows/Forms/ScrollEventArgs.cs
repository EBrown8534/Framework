using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the Scroll event.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.ScrollEventArgs(v=vs.110).aspx
    /// </remarks>
    public class ScrollEventArgs : EventArgs
    {
        private int _newValue;
        private int _oldValue;
        private ScrollOrientation _scrollOrientation;
        private ScrollEventType _type;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollEventArgs"/> class using the given values for the <see cref="Type"/> and <see cref="NewValue"/> properties.
        /// </summary>
        /// <param name="type">One of the <see cref="ScrollEventType"/> values.</param>
        /// <param name="newValue">The new value for the scroll bar.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/3t1y9bcb(v=vs.110).aspx
        /// </remarks>
        public ScrollEventArgs(ScrollEventType type, int newValue) { _type = type; _newValue = newValue; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollEventArgs"/> class using the given values for the <see cref="Type"/>, <see cref="OldValue"/>, and <see cref="NewValue"/> properties.
        /// </summary>
        /// <param name="type">One of the <see cref="ScrollEventType"/> values.</param>
        /// <param name="oldValue">The old value for the scroll bar.</param>
        /// <param name="newValue">The new value for the scroll bar.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/4kfeedwb(v=vs.110).aspx
        /// </remarks>
        public ScrollEventArgs(ScrollEventType type, int oldValue, int newValue) { _type = type; _newValue = newValue; _oldValue = oldValue; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollEventArgs"/> class using the given values for the <see cref="Type"/>, <see cref="NewValue"/>, and <see cref="ScrollOrientation"/> properties.
        /// </summary>
        /// <param name="type">One of the <see cref="ScrollEventType"/> values.</param>
        /// <param name="newValue">The new value for the scroll bar.</param>
        /// <param name="scroll">One of the <see cref="ScrollOrientation"/> values.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/yc9axxs4(v=vs.110).aspx
        /// </remarks>
        public ScrollEventArgs(ScrollEventType type, int newValue, ScrollOrientation scroll) { _type = type; _newValue = newValue; _scrollOrientation = scroll; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollEventArgs"/> class using the given values for the <see cref="Type"/>, <see cref="OldValue"/>, <see cref="NewValue"/>, and <see cref="ScrollOrientation"/> properties.
        /// </summary>
        /// <param name="type">One of the <see cref="ScrollEventType"/> values.</param>
        /// <param name="oldValue">The old value for the scroll bar.</param>
        /// <param name="newValue">The new value for the scroll bar.</param>
        /// <param name="scroll">One of the <see cref="ScrollOrientation"/> values.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/wy4h3cfs(v=vs.110).aspx
        /// </remarks>
        public ScrollEventArgs(ScrollEventType type, int oldValue, int newValue, ScrollOrientation scroll) { _type = type; _newValue = newValue; _oldValue = oldValue; _scrollOrientation = scroll; }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the new <see cref="ScrollBar.Value"/> of the scroll bar.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.scrolleventargs.newvalue(v=vs.110).aspx
        /// </remarks>
        public int NewValue { get { return _newValue; } set { _newValue = value; } }
        /// <summary>
        /// Gets the old <see cref="ScrollBar.Value"/> of the scroll bar.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.scrolleventargs.oldvalue(v=vs.110).aspx
        /// </remarks>
        public int OldValue { get { return _oldValue; } }
        /// <summary>
        /// Gets the scroll bar orientation that raised the Scroll event.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.scrolleventargs.scrollorientation(v=vs.110).aspx
        /// </remarks>
        public ScrollOrientation ScrollOrientation { get { return _scrollOrientation; } }
        /// <summary>
        /// Gets the type of scroll event that occurred.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.scrolleventargs.type(v=vs.110).aspx
        /// </remarks>
        public ScrollEventType Type { get { return _type; } }
        #endregion
    }
}
