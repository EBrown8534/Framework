using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides basic properties for the HScrollBar.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/system.windows.forms.hscrollproperties(v=vs.110).aspx
    /// </remarks>
    public class HScrollProperties : ScrollProperties
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HScrollProperties"/> class.
        /// </summary>
        /// <param name="container">A <see cref="ScrollableControl"/> that contains the scroll bar.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.hscrollproperties.hscrollproperties(v=vs.110).aspx
        /// </remarks>
        public HScrollProperties(ScrollableControl container) 
            : base(container)
        {
        }
        #endregion
    }
}
