using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides basic properties for the <see cref="VScrollBar"/> class.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.VScrollProperties(v=vs.110).aspx
    /// </remarks>
    public class VScrollProperties : ScrollProperties
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="VScrollProperties"/> class.
        /// </summary>
        /// <param name="container">A <see cref="ScrollableControl"/> that contains the scroll bar.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.vscrollproperties.vscrollproperties(v=vs.110).aspx
        /// </remarks>
        public VScrollProperties(ScrollableControl container)
            : base(container)
        {
        }
        #endregion
    }
}
