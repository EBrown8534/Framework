using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the <see cref="Form.FormClosing"/> event.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosingeventargs(v=vs.110).aspx
    /// </remarks>
    public class FormClosingEventArgs : CancelEventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FormClosingEventArgs"/> class.
        /// </summary>
        /// <param name="closeReason">A <see cref="Forms.CloseReason"/> value that represents the reason why the form is being closed.</param>
        /// <param name="cancel">True to cancel the event, otherwise false.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosingeventargs.formclosingeventargs(v=vs.110).aspx
        /// </remarks>
        public FormClosingEventArgs(CloseReason closeReason, bool cancel)
        {
            CloseReason = closeReason;
            Cancel = cancel;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value that indicates why the form is being closed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosingeventargs.closereason(v=vs.110).aspx
        /// </remarks>
        public CloseReason CloseReason { get; }
        #endregion
    }
}
