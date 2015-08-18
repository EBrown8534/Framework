using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the border styles for a form.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.FormBorderStyle(v=vs.110).aspx
    /// </remarks>
    public enum FormBorderStyle
    {
        /// <summary>
        /// A fixed, three-dimensional border.
        /// </summary>
        Fixed3D = 0x02,
        /// <summary>
        /// A thick, fixed dialog-style border.
        /// </summary>
        FixedDialog = 0x03,
        /// <summary>
        /// A fixed, single-line border.
        /// </summary>
        FixedSingle = 0x01,
        /// <summary>
        /// A tool window border that is not resizable. A tool window does not appear in the taskbar or in the window that appears when the user presses ALT+TAB. Although forms that specify FixedToolWindow typically are not shown in the taskbar, you must also ensure that the <see cref="Form.ShowInTaskbar"/> property is set to false, since its default value is true.
        /// </summary>
        FixedToolWindow = 0x05,
        /// <summary>
        /// No border.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// A resizable border.
        /// </summary>
        Sizable = 0x04,
        /// <summary>
        /// A resizable tool window border. A tool window does not appear in the taskbar or in the window that appears when the user presses ALT+TAB.
        /// </summary>
        SizableToolWindow = 0x06
    }
}
