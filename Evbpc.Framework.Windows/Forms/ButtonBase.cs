using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Implements the basic functionality common to button controls.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase(v=vs.110).aspx
    /// </remarks>
    public abstract class ButtonBase : Control
    {
        private bool _AutoEllipsis;
        private Color _BackColor;
        private FlatButtonAppearance _FlatAppearance;
        private FlatStyle _FlatStyle;
        private bool _IsDefault;
        private string _Text;
        private ContentAlignment _TextAlign;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ButtonBase class.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.buttonbase(v=vs.110).aspx
        /// </remarks>
        protected ButtonBase() { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the control, denoting that the control text extends beyond the specified length of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.autoellipsis(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public bool AutoEllipsis { get { return _AutoEllipsis; } set { _AutoEllipsis = value; } }

        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/ms158232(v=vs.110).aspx
        /// </remarks>
        public override Color BackColor { get { return _BackColor; } set { _BackColor = value; } }

        /// <summary>
        /// This member overrides <see cref="Control.DefaultSize"/>, and more complete documentation might be available in that topic.
        /// Gets the default size of the control.
        /// </summary>
        protected override Size DefaultSize { get { return new Size(0, 0); } }

        /// <summary>
        /// Gets the appearance of the border and the colors used to indicate check state and mouse state.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.flatappearance(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public FlatButtonAppearance FlatAppearance { get { return _FlatAppearance; } }

        /// <summary>
        /// Gets or sets the flat style appearance of the button control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.flatstyle(v=vs.110).aspx
        /// </remarks>
        public FlatStyle FlatStyle { get { return _FlatStyle; } set { _FlatStyle = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether the button control is the default button.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.isdefault(v=vs.110).aspx
        /// </remarks>
        protected internal bool IsDefault { get { return _IsDefault; } set { _IsDefault = value; } }

        /// <summary>
        /// This member overrides <see cref="Control.Text"/>, and more complete documentation might be available in that topic.
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/ms158234(v=vs.110).aspx
        /// </remarks>
        [SettingsBindableAttribute(true)]
        public override string Text { get { return _Text; } set { _Text = value; } }

        /// <summary>
        /// Gets or sets the alignment of the text on the button control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.textalign(v=vs.110).aspx
        /// </remarks>
        public virtual ContentAlignment TextAlign { get { return _TextAlign; } set { _TextAlign = value; } }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="Size"/> representing the width and height of a rectangle.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.getpreferredsize(v=vs.110).aspx
        /// </remarks>
        public override Size GetPreferredSize(Size proposedSize) { return new Size(Math.Min(Size.Width, proposedSize.Width), Math.Min(Size.Height, proposedSize.Height)); }

        /// <summary>
        /// This member overrides <see cref="Control.OnEnabledChanged(EventArgs)"/>, and more complete documentation might be available in that topic.
        /// Raises the <see cref="EnabledChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/ksa2868w(v=vs.110).aspx
        /// </remarks>
        protected override void OnEnabledChanged(EventArgs e) { base.OnEnabledChanged(e); }

        /// <summary>
        /// Raises the <see cref="GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/xk0bsxz2(v=vs.110).aspx
        /// </remarks>
        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnKeyDown"/> event.
        /// </summary>
        /// <param name="kevent">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/f6df3w7z(v=vs.110).aspx
        /// </remarks>
        protected override void OnKeyDown(KeyEventArgs kevent) { base.OnKeyDown(kevent); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnKeyUp"/> event.
        /// </summary>
        /// <param name="kevent">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/f6df3w7z(v=vs.110).aspx
        /// </remarks>
        protected override void OnKeyUp(KeyEventArgs kevent) { base.OnKeyUp(kevent); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnLostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/x5dk67cz(v=vs.110).aspx
        /// </remarks>
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnMouseDown"/> event.
        /// </summary>
        /// <param name="mevent">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/h2ksdf2z(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseDown(MouseEventArgs mevent) { base.OnMouseDown(mevent); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnMouseEnter"/> event.
        /// </summary>
        /// <param name="eventargs">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.onmouseenter(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseEnter(EventArgs eventargs) { base.OnMouseEnter(eventargs); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnMouseLeave"/> event.
        /// </summary>
        /// <param name="eventargs">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.onmouseleave(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseLeave(EventArgs eventargs) { base.OnMouseLeave(eventargs); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnMouseMove"/> event.
        /// </summary>
        /// <param name="mevent">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/3h17s498(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseMove(MouseEventArgs mevent) { base.OnMouseMove(mevent); }

        /// <summary>
        /// This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// Raises the <see cref="OnMouseUp"/> event.
        /// </summary>
        /// <param name="mevent">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/ea65040s(v=vs.110).aspx
        /// </remarks>
        protected override void OnMouseUp(MouseEventArgs mevent) { base.OnMouseUp(mevent); }

        /// <summary>
        /// This member overrides <see cref="Control.OnTextChanged(EventArgs)"/>, and more complete documentation might be available in that topic.
        /// Raises the <see cref="TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/cxxt96xw(v=vs.110).aspx
        /// </remarks>
        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); }

        /// <summary>
        /// This member overrides <see cref="Control.OnVisibleChanged(EventArgs)"/>, and more complete documentation might be available in that topic.
        /// Raises the <see cref="VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.buttonbase.onvisiblechanged(v=vs.110).aspx
        /// </remarks>
        protected override void OnVisibleChanged(EventArgs e) { base.OnVisibleChanged(e); }
        #endregion
    }
}
