using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies how a control anchors to the edges of its container.
    /// This enumeration has a <code>FlagsAttribute</code> attribute that allows a bitwise combination of its member values.
    /// </summary>
    [FlagsAttribute]
    public enum AnchorStyles
    {
        /// <summary>
        /// The control is anchored to the bottom edge of its container.
        /// </summary>
        Bottom = 0x02,
        /// <summary>
        /// The control is anchored to the left edge of its container.
        /// </summary>
        Left = 0x04,
        /// <summary>
        /// The control is not anchored to any edges of its container.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// The control is anchored to the right edge of its container.
        /// </summary>
        Right = 0x08,
        /// <summary>
        /// The control is anchored to the top edge of its container.
        /// </summary>
        Top = 0x01
    }
}
