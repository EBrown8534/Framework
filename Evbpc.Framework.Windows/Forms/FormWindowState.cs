using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies how a form window is displayed.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.FormWindowState(v=vs.110).aspx
    /// </remarks>
    public enum FormWindowState
    {
        /// <summary>
        /// A maximized window.
        /// </summary>
        Maximized = 0x02,
        /// <summary>
        /// A minimized window.
        /// </summary>
        Minimized = 0x01,
        /// <summary>
        /// A default sized window.
        /// </summary>
        Normal = 0x00
    }
}
