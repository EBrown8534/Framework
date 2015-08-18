using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the style of the sizing grip on a <see cref="Form"/>.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.SizeGripStyle(v=vs.110).aspx
    /// </remarks>
    public enum SizeGripStyle
    {
        /// <summary>
        /// The sizing grip is automatically displayed when needed.
        /// </summary>
        Auto = 0x00,
        /// <summary>
        /// The sizing grip is hidden.
        /// </summary>
        Hide = 0x02,
        /// <summary>
        /// The sizing grip is always shown on the form.
        /// </summary>
        Show = 0x01
    }
}
