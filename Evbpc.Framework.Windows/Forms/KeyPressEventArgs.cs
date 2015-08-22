using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the <see cref="Control.KeyPress"/> event.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.KeyPressEventArgs(v=vs.110).aspx
    /// </remarks>
    public class KeyPressEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPressEventArgs"/> class.
        /// </summary>
        /// <param name="keyChar">The ASCII character corresponding to the key the user pressed.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.keypresseventargs.keypresseventargs(v=vs.110).aspx
        /// </remarks>
        public KeyPressEventArgs(char keyChar) { KeyChar = keyChar; }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Control.KeyPress"/> event was handled.
        /// </summary>
        public bool Handled { get; set; }
        /// <summary>
        /// Gets or sets the character corresponding to the key pressed.
        /// </summary>
        public char KeyChar { get; set; }
        #endregion
    }
}
