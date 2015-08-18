using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides properties that specify the appearance of <see cref="Button"/> controls whose <see cref="FlatStyle"/> is <see cref="FlatStyle.Flat"/>.
    /// </summary>
    public class FlatButtonAppearance
    {
        /// <summary>
        /// Gets or sets the color of the border around the button.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatbuttonappearance.bordercolor(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the size, in pixels, of the border around the button.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatbuttonappearance.bordersize(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public int BorderSize { get; set; }

        /// <summary>
        /// Gets or sets the color of the client area of the button when the button is checked and the mouse pointer is outside the bounds of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatbuttonappearance.checkedbackcolor(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public Color CheckedBackColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the client area of the button when the mouse is pressed within the bounds of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatbuttonappearance.mousedownbackcolor(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public Color MouseDownBackColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the client area of the button when the mouse pointer is within the bounds of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatbuttonappearance.mouseoverbackcolor(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public Color MouseOverBackColor { get; set; }
    }
}
