using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the <see cref="Control.ControlAdded"/> and <see cref="Control.ControlRemoved"/> events.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.ControlEventArgs(v=vs.110).aspx
    /// </remarks>
    public class ControlEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlEventArgs"/> class for the specified control.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to store in this event.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.controleventargs.controleventargs(v=vs.110).aspx
        /// </remarks>
        public ControlEventArgs(Control control)
        {
            Control = control;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the control object used by this event.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.controleventargs.control(v=vs.110).aspx
        /// </remarks>
        public Control Control { get; }
        #endregion
    }
}
