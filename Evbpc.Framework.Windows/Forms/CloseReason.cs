using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Specifies the reason that a form was closed.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.CloseReason(v=vs.110).aspx
    /// </remarks>
    public enum CloseReason
    {
        /// <summary>
        /// The Exit method of the Application class was invoked.
        /// </summary>
        ApplicationExitCall = 0x06,
        /// <summary>
        /// The owner form is closing.
        /// </summary>
        FormOwnerClosing = 0x05,
        /// <summary>
        /// The parent form of this multiple document interface (MDI) form is closing.
        /// </summary>
        MdiFormClosing = 0x02,
        /// <summary>
        /// The cause of the closure was not defined or could not be determined.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// The Microsoft Windows Task Manager is closing the application.
        /// </summary>
        TaskManagerClosing = 0x04,
        /// <summary>
        /// The user is closing the form through the user interface (UI), for example by clicking the Close button on the form window, selecting Close from the window's control menu, or pressing ALT+F4.
        /// </summary>
        UserClosing = 0x03,
        /// <summary>
        /// The operating system is closing all applications before shutting down.
        /// </summary>
        WindowsShutDown = 0x01
    }
}
