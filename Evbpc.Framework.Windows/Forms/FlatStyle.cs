using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the appearance of a control.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.flatstyle(v=vs.110).aspx
    /// </remarks>
    public enum FlatStyle
    {
        /// <summary>
        /// The control appears flat.
        /// </summary>
        Flat,

        /// <summary>
        /// A control appears flat until the mouse pointer moves over it, at which point it appears three-dimensional.
        /// </summary>
        Popup,

        /// <summary>
        /// The control appears three-dimensional.
        /// </summary>
        Standard,

        /// <summary>
        /// The appearance of the control is determined by the user's operating system.
        /// </summary>
        System
    }
}
