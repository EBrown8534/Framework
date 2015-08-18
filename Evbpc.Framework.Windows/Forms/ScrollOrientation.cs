using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the scroll bar orientation for the <see cref="ScrollBar.Scroll"/> event.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.ScrollOrientation(v=vs.110).aspx
    /// </remarks>
    public enum ScrollOrientation
    {
        /// <summary>
        /// The horizontal scroll bar.
        /// </summary>
        HorizontalScroll = 0x00,
        /// <summary>
        /// The vertical scroll bar.
        /// </summary>
        VerticalScroll = 0x01
    }
}
