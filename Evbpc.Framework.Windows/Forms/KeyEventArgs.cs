using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides data for the <see cref="Control.KeyDown"/> or <see cref="Control.KeyUp"/> event.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs(v=vs.110).aspx
    /// </remarks>
    public class KeyEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="keyData">A <see cref="Keys"/> representing the key that was pressed, combined with any modifier flags that indicate which CTRL, SHIFT, and ALT keys were pressed at the same time. Possible values are obtained be applying the bitwise OR (|) operator to constants from the Keys enumeration.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.keyeventargs(v=vs.110).aspx
        /// </remarks>
        public KeyEventArgs(Keys keyData)
        {
            Shift = false;
            KeyData = keyData;

            if ((KeyData & Keys.Shift) == Keys.Shift)
            {
                KeyData = KeyData ^ Keys.Shift;
                Shift = true;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether the ALT key was pressed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.alt(v=vs.110).aspx
        /// </remarks>
        public virtual bool Alt => (KeyData & Keys.Alt) == Keys.Alt;

        /// <summary>
        /// Gets a value indicating whether the CTRL key was pressed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.control(v=vs.110).aspx
        /// </remarks>
        public bool Control => (KeyData & Keys.Control) == Keys.Control;

        /// <summary>
        /// Gets or sets a value indicating whether the event was handled.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.handled(v=vs.110).aspx
        /// </remarks>
        public bool Handled { get; set; }

        /// <summary>
        /// Gets the keyboard code for a <see cref="Control.KeyDown"/> or <see cref="Control.KeyUp"/> event.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.keycode(v=vs.110).aspx
        /// </remarks>
        public Keys KeyCode => KeyData;

        /// <summary>
        /// Gets the key data for a <see cref="Control.KeyDown"/> or <see cref="Control.KeyUp"/> event.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.keydata(v=vs.110).aspx
        /// </remarks>
        public Keys KeyData { get; }

        /// <summary>
        /// Gets the keyboard value for a <see cref="Control.KeyDown"/> or <see cref="Control.KeyUp"/> event.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.keyvalue(v=vs.110).aspx
        /// </remarks>
        public int KeyValue => (int)KeyData;

        /// <summary>
        /// Gets the modifier flags for a <see cref="Control.KeyDown"/> or <see cref="Control.KeyUp"/> event. The flags indicate which combination of CTRL, SHIFT, and ALT keys was pressed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.modifiers(v=vs.110).aspx
        /// </remarks>
        public Keys Modifiers => KeyData & Keys.Modifiers;

        /// <summary>
        /// Gets a value indicating whether the SHIFT key was pressed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.shift(v=vs.110).aspx
        /// </remarks>
        public virtual bool Shift { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the key event should be passed on to the underlying control.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.keyeventargs.suppresskeypress(v=vs.110).aspx
        /// </remarks>
        public bool SuppressKeyPress { get; set; }
        #endregion
    }
}
