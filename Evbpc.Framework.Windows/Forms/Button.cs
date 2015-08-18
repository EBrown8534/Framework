using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Represents a Windows button control.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.button(v=vs.110).aspx
    /// </remarks>
    public class Button : ButtonBase, IButtonControl
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.button.button(v=vs.110).aspx
        /// </remarks>
        public Button() { }
        #endregion

        #region Properties

        #endregion

        #region Methods
        /// <summary>
        /// Notifies the <see cref="Button"/> whether it is the default button so that it can adjust its appearance accordingly.
        /// </summary>
        /// <param name="value">true if the button is to have the appearance of the default button; otherwise, false.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.button.notifydefault(v=vs.110).aspx
        /// </remarks>
        public virtual void NotifyDefault(bool value) { }

        /// <summary>
        /// This member overrides <see cref="ButtonBase.OnMouseEnter(EventArgs)"/>, and more complete documentation might be available in that topic.
        /// Raises the <see cref="OnMouseEnter"/> event.
        /// </summary>
        /// <param name="eventargs">Provides information for the event.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/6y878dt5(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseEnter(EventArgs eventargs) { base.OnMouseEnter(eventargs); }

        /// <summary>
        /// This member overrides <see cref="ButtonBase.OnMouseLeave(EventArgs)"/>, and more complete documentation might be available in that topic.
        /// Raises the <see cref="OnMouseLeave"/> event.
        /// </summary>
        /// <param name="eventargs">Provides missing information for the event.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/e6ty6yb0(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseLeave(EventArgs eventargs) { base.OnMouseLeave(eventargs); }

        /// <summary>
        /// Raises the <see cref="OnMouseUp"/> event.
        /// </summary>
        /// <param name="mevent">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/1hc3z2ya(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseUp(MouseEventArgs mevent) { base.OnMouseUp(mevent); }

        /// <summary>
        /// Raises the <see cref="TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/0k7keftx(v=vs.110).aspx
        /// </remarks>
        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); }

        /// <summary>
        /// Generates a <see cref="Click"/> event for a button.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.button.performclick(v=vs.110).aspx
        /// </remarks>
        public void PerformClick() { }
        #endregion
    }
}
