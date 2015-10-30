using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the <see cref="Form.FormClosed"/> event.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosedeventargs(v=vs.110).aspx
    /// </remarks>
    public class FormClosedEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FormClosedEventArgs"/> class.
        /// </summary>
        /// <param name="closeReason">A <see cref="Forms.CloseReason"/> value that represents the reason why the form was closed.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosedeventargs.formclosedeventargs(v=vs.110).aspx
        /// </remarks>
        public FormClosedEventArgs(CloseReason closeReason)
        {
            CloseReason = closeReason;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value that indicates why the form was closed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.formclosedeventargs.closereason(v=vs.110).aspx
        /// </remarks>
        public CloseReason CloseReason { get; }
        #endregion
    }
}
