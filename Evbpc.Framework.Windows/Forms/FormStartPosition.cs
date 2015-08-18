using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the initial position of a form.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.FormStartPosition(v=vs.110).aspx
    /// </remarks>
    public enum FormStartPosition
    {
        /// <summary>
        /// The form is centered within the bounds of its parent form.
        /// </summary>
        CenterParent = 0x04,
        /// <summary>
        /// The form is centered on the current display, and has the dimensions specified in the form's size.
        /// </summary>
        CenterScreen = 0x01,
        /// <summary>
        /// The position of the form is determined by the <see cref="Control.Location"/> property.
        /// </summary>
        Manual = 0x00,
        /// <summary>
        /// The form is positioned at the Windows default location and has the bounds determined by Windows default.
        /// </summary>
        WindowsDefaultBounds = 0x03,
        /// <summary>
        /// The form is positioned at the Windows default location and has the dimensions specified in the form's size.
        /// </summary>
        WindowsDefaultLocation = 0x02
    }
}
