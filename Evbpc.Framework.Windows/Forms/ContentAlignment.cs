using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies alignment of content on the drawing surface.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.drawing.contentalignment(v=vs.110).aspx
    /// </remarks>
    public enum ContentAlignment
    {
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned at the center.
        /// </summary>
        BottomCenter,
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the left.
        /// </summary>
        BottomLeft,
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the right.
        /// </summary>
        BottomRight,
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned at the center.
        /// </summary>
        MiddleCenter,
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the left.
        /// </summary>
        MiddleLeft,
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the right.
        /// </summary>
        MiddleRight,
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned at the center.
        /// </summary>
        TopCenter,
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the left.
        /// </summary>
        TopLeft,
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the right.
        /// </summary>
        TopRight
    }
}
