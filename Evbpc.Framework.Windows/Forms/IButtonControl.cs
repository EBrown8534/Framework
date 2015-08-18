using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Allows a control to act like a button on a form.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.ibuttoncontrol(v=vs.110).aspx
    /// </remarks>
    public interface IButtonControl
    {
        #region Methods
        /// <summary>
        /// Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.
        /// </summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.ibuttoncontrol.notifydefault(v=vs.110).aspx
        /// </remarks>
        void NotifyDefault(bool value);

        /// <summary>
        /// Generates a Click event for the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.ibuttoncontrol.performclick(v=vs.110).aspx
        /// </remarks>
        void PerformClick();
        #endregion
    }
}
