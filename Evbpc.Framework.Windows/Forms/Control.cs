using Evbpc.Framework.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Defines the base class for controls, which are components with visual representation.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/System.Windows.Forms.Control(v=vs.110).aspx
    /// </remarks>
    public abstract class Control : Component, IComponent, IDisposable
    {
        private AnchorStyles _Anchor;
        private Color _BackColor;
        private bool _Capture;
        private ControlCollection _Controls;
        private bool _Enabled;
        private Color _ForeColor;
        private Point _Location;
        private Size _MaximumSize;
        private Size _MinimumSize;
        private string _Name;
        private Control _Parent;
        protected Size _Size;
        private int _TabIndex;
        private bool _TabStop;
        private string _Text;
        private bool _Visible;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Control class with default settings.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/6b19wbt2(v=vs.110).aspx
        /// </remarks>
        public Control()
        {
            _Text = "";
            _BackColor = DefaultBackColor;
            _ForeColor = DefaultForeColor;
            _Anchor = AnchorStyles.None;
            _Capture = true;
            _Controls = new ControlCollection(this);
            _Enabled = true;
            _Location = new Point();
            _MaximumSize = DefaultMaximumSize;
            _MinimumSize = DefaultMinimumSize;
            _Name = "";
            _Parent = null;
            _Size = DefaultSize;
            _TabIndex = int.MaxValue;
            _TabStop = true;
            _Visible = true;
        }
        /// <summary>
        /// Initializes a new instance of the Control class with specific text.
        /// </summary>
        /// <param name="text">The text displayed by the control.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/sdxb8fy8(v=vs.110).aspx
        /// </remarks>
        public Control(string text)
        {
            _Text = text;
            _BackColor = DefaultBackColor;
            _ForeColor = DefaultForeColor;
            _Anchor = AnchorStyles.None;
            _Capture = true;
            _Controls = new ControlCollection(this);
            _Enabled = true;
            _Location = new Point();
            _MaximumSize = DefaultMaximumSize;
            _MinimumSize = DefaultMinimumSize;
            _Name = "";
            _Parent = null;
            _Size = DefaultSize;
            _TabIndex = int.MaxValue;
            _TabStop = true;
            _Visible = true;
        }
        /// <summary>
        /// Initializes a new instance of the Control class as a child control, with specific text.
        /// </summary>
        /// <param name="parent">The <see cref="Control"/> to be the parent of the control.</param>
        /// <param name="text">The text displayed by the control.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/wawy06xc(v=vs.110).aspx
        /// </remarks>
        public Control(Control parent, string text)
        {
            _Text = text;
            _BackColor = DefaultBackColor;
            _ForeColor = DefaultForeColor;
            _Anchor = AnchorStyles.None;
            _Capture = true;
            _Controls = new ControlCollection(this);
            _Enabled = true;
            _Location = new Point();
            _MaximumSize = DefaultMaximumSize;
            _MinimumSize = DefaultMinimumSize;
            _Name = "";
            _Parent = parent;
            _Size = DefaultSize;
            _TabIndex = int.MaxValue;
            _TabStop = true;
            _Visible = true;
        }
        /// <summary>
        /// Initializes a new instance of the Control class with specific text, size, and location.
        /// </summary>
        /// <param name="text">The text displayed by the control.</param>
        /// <param name="left">The X position of the control, in pixels, from the left edge of the control's container. The value is assigned to the <see cref="Left"/> property.</param>
        /// <param name="top">The Y position of the control, in pixels, from the top edge of the control's container. The value is assigned to the <see cref="Top"/> property.</param>
        /// <param name="width">The width of the control, in pixels. The value is assigned to the <see cref="Width"/> property.</param>
        /// <param name="height">The height of the control, in pixels. The value is assigned to the <see cref="Height"/> property.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/9b3we91k(v=vs.110).aspx
        /// </remarks>
        public Control(string text, int left, int top, int width, int height)
        {
            _Text = text;
            _BackColor = DefaultBackColor;
            _ForeColor = DefaultForeColor;
            _Anchor = AnchorStyles.None;
            _Capture = true;
            _Controls = new ControlCollection(this);
            _Enabled = true;
            _Location = new Point(left, top);
            _MaximumSize = DefaultMaximumSize;
            _MinimumSize = DefaultMinimumSize;
            _Name = "";
            _Parent = null;
            _Size = new Drawing.Size(width, height);
            _TabIndex = int.MaxValue;
            _TabStop = true;
            _Visible = true;
        }
        /// <summary>
        /// Initializes a new instance of the Control class as a child control, with specific text, size, and location.
        /// </summary>
        /// <param name="parent">The <see cref="Control"/> to be the parent of the control.</param>
        /// <param name="text">The text displayed by the control.</param>
        /// <param name="left">The X position of the control, in pixels, from the left edge of the control's container. The value is assigned to the <see cref="Left"/> property.</param>
        /// <param name="top">The Y position of the control, in pixels, from the top edge of the control's container. The value is assigned to the <see cref="Top"/> property.</param>
        /// <param name="width">The width of the control, in pixels. The value is assigned to the <see cref="Width"/> property.</param>
        /// <param name="height">The height of the control, in pixels. The value is assigned to the <see cref="Height"/> property.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/x59hwbb3(v=vs.110).aspx
        /// </remarks>
        public Control(Control parent, string text, int left, int top, int width, int height)
        {
            _Text = text;
            _BackColor = DefaultBackColor;
            _ForeColor = DefaultForeColor;
            _Anchor = AnchorStyles.None;
            _Capture = true;
            _Controls = new ControlCollection(this);
            _Enabled = true;
            _Location = new Point(left, top);
            _MaximumSize = DefaultMaximumSize;
            _MinimumSize = DefaultMinimumSize;
            _Name = "";
            _Parent = parent;
            _Size = new Size(width, height);
            _TabIndex = int.MaxValue;
            _TabStop = true;
            _Visible = true;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.anchor(v=vs.110).aspx
        /// </remarks>
        public virtual AnchorStyles Anchor { get { return _Anchor; } set { _Anchor = value; } }
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.backcolor(v=vs.110).aspx
        /// </remarks>
        public virtual Color BackColor { get { return _BackColor; } set { _BackColor = value; } }

        /// <summary>
        /// Gets the distance, in pixels, between the bottom edge of the control and the top edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.bottom(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Bottom { get { return _Location.Y + _Size.Height; } }

        /// <summary>
        /// Gets or sets the size and location of the control including its nonclient elements, in pixels, relative to the parent control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.bounds(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Rectangle Bounds { get { return new Rectangle(_Location, _Size); } set { _Location = value.Location; _Size = value.Size; } }

        /// <summary>
        /// Gets a value indicating whether the control can receive focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.canfocus(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool CanFocus { get { return ((_Parent != null && _Parent.CanFocus) || (_Parent == null && this is Form)) && Enabled && Visible; } }

        /// <summary>
        /// Gets a value indicating whether the control can be selected.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.canselect(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool CanSelect { get { return _Parent != null && _Parent.CanFocus && Visible && Enabled; } }

        /// <summary>
        /// Gets or sets a value indicating whether the control has captured the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.capture(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool Capture { get { return _Capture; } set { _Capture = value; } }

        /// <summary>
        /// Gets the rectangle that represents the client area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.clientrectangle(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Rectangle ClientRectangle { get { return Bounds; } }

        /// <summary>
        /// Gets or sets the height and width of the client area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.clientsize(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Size ClientSize { get { return _Size; } set { _Size = value; } }

        /// <summary>
        /// Gets a value indicating whether the control, or one of its child controls, currently has the input focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.containsfocus(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool ContainsFocus { get { if ((_Parent != null)) { foreach (Control c in _Controls) { if (c.ContainsFocus) { return true; } } if (FindForm().ActiveControl == this) { return true; } } return false; } }

        /// <summary>
        /// Gets the collection of controls contained within the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controls(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Control.ControlCollection Controls { get { return _Controls; } }

        /// <summary>
        /// Gets the default background color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultbackcolor(v=vs.110).aspx
        /// </remarks>
        public static Color DefaultBackColor { get { return new Color(255, 255, 255); } }
        /// <summary>
        /// Gets the default foreground color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultforecolor(v=vs.110).aspx
        /// </remarks>
        public static Color DefaultForeColor { get { return new Color(0, 0, 0); } }
        /// <summary>
        /// Gets the length and height, in pixels, that is specified as the default maximum size of a control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultmaximumsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultMaximumSize { get { return new Size(int.MaxValue, int.MaxValue); } }
        /// <summary>
        /// Gets the length and height, in pixels, that is specified as the default minimum size of a control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultminimumsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultMinimumSize { get { return new Size(0, 0); } }
        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultSize { get { return new Size(640, 480); } }

        /// <summary>
        /// Gets the rectangle that represents the display area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.displayrectangle(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public virtual Rectangle DisplayRectangle { get { return Bounds; } }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.enabled(v=vs.110).aspx
        /// </remarks>
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }

        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.focused(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public virtual bool Focused { get { return (_Parent != null) && ContainsFocus; } }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.forecolor(v=vs.110).aspx
        /// </remarks>
        public virtual Color ForeColor { get { return _ForeColor; } set { _ForeColor = value; } }

        /// <summary>
        /// Gets a value indicating whether the control contains one or more child controls.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.haschildren(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool HasChildren { get { return _Controls.Count > 0; } }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.height(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Height { get { return _Size.Height; } set { _Size = new Size(_Size.Width, value); } }

        /// <summary>
        /// Gets or sets the distance, in pixels, between the left edge of the control and the left edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.left(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Left { get { return _Location.X; } set { _Location = new Point(Left, _Location.Y); } }

        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the control relative to the upper-left corner of its container.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.location(v=vs.110).aspx
        /// </remarks>
        public Point Location { get { return _Location; } set { _Location = value; } }
        /// <summary>
        /// Gets or sets the size that is the upper limit that GetPreferredSize can specify.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.maximumsize(v=vs.110).aspx
        /// </remarks>
        public virtual Size MaximumSize { get { return _MaximumSize; } set { _MaximumSize = value; } }
        /// <summary>
        /// Gets or sets the size that is the lower limit that GetPreferredSize can specify.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.minimumsize(v=vs.110).aspx
        /// </remarks>
        public virtual Size MinimumSize { get { return _MinimumSize; } set { _MinimumSize = value; } }

        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.name(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public string Name { get { return _Name; } set { _Name = value; } }

        /// <summary>
        /// Gets or sets the parent container of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.parent(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Control Parent { get { return _Parent; } set { _Parent = value; } }

        /// <summary>
        /// Gets the size of a rectangular area into which the control can fit.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.preferredsize(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Size PreferredSize { get { return _Size; } }

        /// <summary>
        /// Gets the distance, in pixels, between the right edge of the control and the left edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.right(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Right { get { return _Location.X + _Size.Width; } }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.size(v=vs.110).aspx
        /// </remarks>
        public Size Size { get { return _Size; } set { _Size = value; } }
        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabindex(v=vs.110).aspx
        /// </remarks>
        public int TabIndex { get { return _TabIndex; } set { _TabIndex = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabstop(v=vs.110).aspx
        /// </remarks>
        public bool TabStop { get { return _TabStop; } set { _TabStop = value; } }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.text(v=vs.110).aspx
        /// </remarks>
        [BindableAttribute(true)]
        public virtual string Text { get { return _Text; } set { _Text = value; } }

        /// <summary>
        /// Gets or sets the distance, in pixels, between the top edge of the control and the top edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.top(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Top { get { return _Location.X; } set { _Location = new Point(_Location.X, value); } }

        /// <summary>
        /// Gets the parent control that is not parented by another Windows Forms control. Typically, this is the outermost Form that the control is contained in.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.toplevelcontrol(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Control TopLevelControl { get { if (_Parent == null) { if (this is Form) { return this; } } else { return _Parent.TopLevelControl; } return null; } }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.visible(v=vs.110).aspx
        /// </remarks>
        public bool Visible { get { return _Visible; } set { _Visible = value; } }

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.width(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public int Width { get { return _Size.Width; } set { _Size = new Size(value, _Size.Height); } }
        #endregion

        #region Methods
        /// <summary>
        /// Brings the control to the front of the z-order.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.bringtofront(v=vs.110).aspx
        /// </remarks>
        public void BringToFront() { throw new NotImplementedException(); }

        /// <summary>
        /// Retrieves the form that the control is on.
        /// </summary>
        /// <returns>The <see cref="Form"/> that the control is on.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.findform(v=vs.110).aspx
        /// </remarks>
        [UIPermissionAttribute(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        public Form FindForm() { if (this is Form) { return (Form)this; } else { if (_Parent != null) { return _Parent.FindForm(); } } return null; }

        /// <summary>
        /// Sets input focus to the control.
        /// </summary>
        /// <returns>true if the input focus request was successful; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.focus(v=vs.110).aspx
        /// </remarks>
        public bool Focus() { if (_Parent != null) { if (CanFocus) { FindForm().ActiveControl = this; } } return ContainsFocus; }
        /// <summary>
        /// Retrieves the next control forward or back in the tab order of child controls.
        /// </summary>
        /// <param name="ctl">The <see cref="Control"/> to start the search with.</param>
        /// <param name="forward">true to search forward in the tab order; true to search backward.</param>
        /// <returns>The next <see cref="Control"/> in the tab order.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.getnextcontrol(v=vs.110).aspx
        /// </remarks>
        public Control GetNextControl(Control ctl, bool forward) { throw new NotImplementedException(); }
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="Drawing.Size"/> representing the width and height of a rectangle.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.getpreferredsize(v=vs.110).aspx
        /// </remarks>
        public virtual Size GetPreferredSize(Size proposedSize) { return new Size(Math.Min(Size.Width, proposedSize.Width), Math.Min(Size.Height, proposedSize.Height)); }
        /// <summary>
        /// Determines if the control is a top-level control.
        /// </summary>
        /// <returns>true if the control is a top-level control; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.gettoplevel(v=vs.110).aspx
        /// </remarks>
        protected bool GetTopLevel() { throw new NotImplementedException(); }
        /// <summary>
        /// Raises the <see cref="BackColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onbackcolorchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnBackColorChanged(EventArgs e) { if (BackColorChanged != null) { BackColorChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="Click"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClick(EventArgs e) { if (Click != null) { Click(this, e); } }
        /// <summary>
        /// Raises the <see cref="ClientSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onclientsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClientSizeChanged(EventArgs e) { if (ClientSizeChanged != null) { ClientSizeChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="ControlAdded"/> event.
        /// </summary>
        /// <param name="e">A <see cref="ControlEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.oncontroladded(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnControlAdded(ControlEventArgs e) { if (ControlAdded != null) { ControlAdded(this, e); } }
        /// <summary>
        /// Raises the <see cref="ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">A <see cref="ControlEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.oncontrolremoved(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnControlRemoved(ControlEventArgs e) { if (ControlRemoved != null) { ControlRemoved(this, e); } }
        /// <summary>
        /// Raises the <see cref="DoubleClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ondoubleclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnDoubleClick(EventArgs e) { if (DoubleClick != null) { DoubleClick(this, e); } }
        /// <summary>
        /// Raises the <see cref="EnabledChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onenabledchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnEnabledChanged(EventArgs e) { if (EnabledChanged != null) { EnabledChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="Enter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onenter(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnEnter(EventArgs e) { if (Enter != null) { Enter(this, e); } }
        /// <summary>
        /// Raises the <see cref="ForeColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onforecolorchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnForeColorChanged(EventArgs e) { if (ForeColorChanged != null) { ForeColorChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ongotfocus(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnGotFocus(EventArgs e) { if (GotFocus != null) { GotFocus(this, e); } }
        /// <summary>
        /// Raises the <see cref="KeyDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeydown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyDown(KeyEventArgs e) { if (KeyDown != null) { KeyDown(this, e); } }
        /// <summary>
        /// Raises the <see cref="KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyPressEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeypress(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyPress(KeyPressEventArgs e) { if (KeyPress != null) { KeyPress(this, e); } }
        /// <summary>
        /// Raises the <see cref="KeyUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeyup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyUp(KeyEventArgs e) { if (KeyUp != null) { KeyUp(this, e); } }
        /// <summary>
        /// Raises the <see cref="Leave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onleave(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLeave(EventArgs e) { if (Leave != null) { Leave(this, e); } }
        /// <summary>
        /// Raises the <see cref="LocationChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onlocationchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLocationChanged(EventArgs e) { if (LocationChanged != null) { LocationChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="LostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onlostfocus(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLostFocus(EventArgs e) { if (LostFocus != null) { LostFocus(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseClick(MouseEventArgs e) { if (MouseClick != null) { MouseClick(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousedoubleclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseDoubleClick(MouseEventArgs e) { if (MouseDoubleClick != null) { MouseDoubleClick(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousedown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseDown(MouseEventArgs e) { if (MouseDown != null) { MouseDown(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseEnter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseenter(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseEnter(EventArgs e) { if (MouseEnter != null) { MouseEnter(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseHover"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousehover(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseHover(EventArgs e) { if (MouseHover != null) { MouseHover(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseLeave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseleave(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseLeave(EventArgs e) { if (MouseLeave != null) { MouseLeave(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseMove"/> event.
        /// </summary>
        /// <param name="e">An <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousemove(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseMove(MouseEventArgs e) { if (MouseMove != null) { MouseMove(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseUp(MouseEventArgs e) { if (MouseUp != null) { MouseUp(this, e); } }
        /// <summary>
        /// Raises the <see cref="MouseWheel"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousewheel(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseWheel(MouseEventArgs e) { if (MouseWheel != null) { MouseWheel(this, e); } }
        /// <summary>
        /// Raises the <see cref="Move"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmove(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMove(EventArgs e) { if (Move != null) { Move(this, e); } }
        /// <summary>
        /// Raises the <see cref="Resize"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onresize(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnResize(EventArgs e) { if (Resize != null) { Resize(this, e); } }
        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnSizeChanged(EventArgs e) { if (SizeChanged != null) { SizeChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="TabIndexChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontabindexchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTabIndexChanged(EventArgs e) { if (TabIndexChanged != null) { TabIndexChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="TabStopChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontabstopchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTabStopChanged(EventArgs e) { if (TabStopChanged != null) { TabStopChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontextchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTextChanged(EventArgs e) { if (TextChanged != null) { TextChanged(this, e); } }
        /// <summary>
        /// Raises the <see cref="VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onvisiblechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnVisibleChanged(EventArgs e) { if (VisibleChanged != null) { VisibleChanged(this, e); } }
        /// <summary>
        /// Resets the <see cref="BackColor"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resetbackcolor(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetBackColor() { _BackColor = DefaultBackColor; }
        /// <summary>
        /// Resets the <see cref="ForeColor"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resetforecolor(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetForeColor() { _ForeColor = DefaultForeColor; }
        /// <summary>
        /// Resets the <see cref="Text"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resettext(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetText() { _Text = ""; }
        /// <summary>
        /// Activates the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/7wt11hea(v=vs.110).aspx
        /// </remarks>
        public void Select() { Focus(); }
        /// <summary>
        /// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
        /// </summary>
        /// <param name="directed">true to specify the direction of the control to select; otherwise, false.</param>
        /// <param name="forward">true to move forward in the tab order; false to move backward in the tab order.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/hb97bya5(v=vs.110).aspx
        /// </remarks>
        protected virtual void Select(bool directed, bool forward) { throw new NotImplementedException(); }
        /// <summary>
        /// Activates the next control.
        /// </summary>
        /// <param name="ctl">The <see cref="Control"/> at which to start the search.</param>
        /// <param name="forward">true to move forward in the tab order; false to move backward in the tab order.</param>
        /// <param name="tabStopOnly">true to ignore the controls with the TabStop property set to false; otherwise, false.</param>
        /// <param name="nested">true to include nested (children of child controls) child controls; otherwise, false.</param>
        /// <param name="wrap">true to continue searching from the first control in the tab order after the last control has been reached; otherwise, false.</param>
        /// <returns>true if a control was activated; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.selectnextcontrol(v=vs.110).aspx
        /// </remarks>
        public bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap) { throw new NotImplementedException(); }
        /// <summary>
        /// Sends the control to the back of the z-order.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.sendtoback(v=vs.110).aspx
        /// </remarks>
        public void SendToBack() { throw new NotImplementedException(); }
        /// <summary>
        /// Sets the bounds of the control to the specified location and size.
        /// </summary>
        /// <param name="x">The new <see cref="Left"/> property value of the control.</param>
        /// <param name="y">The new <see cref="Top"/> property value of the control.</param>
        /// <param name="width">The new <see cref="Width"/> property value of the control.</param>
        /// <param name="height">The new <see cref="Height"/> property value of the control.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/z0tayb1b(v=vs.110).aspx
        /// </remarks>
        public void SetBounds(int x, int y, int width, int height) { _Location = new Point(x, y); _Size = new Size(width, height); }
        /// <summary>
        /// Sets the control as the top-level control.
        /// </summary>
        /// <param name="value">true to set the control as the top-level control; otherwise, false.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.settoplevel(v=vs.110).aspx
        /// </remarks>
        protected void SetTopLevel(bool value) { /*throw new NotImplementedException();*/ }
        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.show(v=vs.110).aspx
        /// </remarks>
        public void Show() { _Visible = true; Select(); }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the value of the <see cref="BackColor"/> property changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.backcolorchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler BackColorChanged;
        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.click(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Click;
        /// <summary>
        /// Occurs when the value of the <see cref="ClientSize"/> property changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.clientsizechanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler ClientSizeChanged;

        /// <summary>
        /// Occurs when a new control is added to the <see cref="Control.ControlCollection"/>.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controladded(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public event ControlEventHandler ControlAdded;

        /// <summary>
        /// Occurs when a control is removed from the <see cref="Control.ControlRemoved"/>.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlremoved(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(true)]
        public event ControlEventHandler ControlRemoved;

        /// <summary>
        /// Occurs when the control is double-clicked.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.doubleclick(v=vs.110).aspx
        /// </remarks>
        public event EventHandler DoubleClick;
        /// <summary>
        /// Occurs when the <see cref="Enabled"/> property value has changed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.enabledchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler EnabledChanged;
        /// <summary>
        /// Occurs when the control is entered.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.enter(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Enter;
        /// <summary>
        /// Occurs when the <see cref="ForeColor"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.forecolorchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler ForeColorChanged;

        /// <summary>
        /// Occurs when the control receives focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.gotfocus(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public event EventHandler GotFocus;

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown(v=vs.110).aspx
        /// </remarks>
        public event KeyEventHandler KeyDown;
        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keypress(v=vs.110).aspx
        /// </remarks>
        public event KeyPressEventHandler KeyPress;
        /// <summary>
        /// Occurs when a key is released while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keyup(v=vs.110).aspx
        /// </remarks>
        public event KeyEventHandler KeyUp;
        /// <summary>
        /// Occurs when the input focus leaves the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.leave(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Leave;
        /// <summary>
        /// Occurs when the <see cref="Location"/> property value has changed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.locationchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler LocationChanged;

        /// <summary>
        /// Occurs when the control loses focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.lostfocus(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public event EventHandler LostFocus;

        /// <summary>
        /// Occurs when the control is clicked by the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseclick(v=vs.110).aspx
        /// </remarks>
        public event MouseEventHandler MouseClick;
        /// <summary>
        /// Occurs when the control is double clicked by the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousedoubleclick(v=vs.110).aspx
        /// </remarks>
        public event MouseEventHandler MouseDoubleClick;
        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousedown(v=vs.110).aspx
        /// </remarks>
        public event MouseEventHandler MouseDown;
        /// <summary>
        /// Occurs when the mouse pointer enters the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseenter(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MouseEnter;
        /// <summary>
        /// Occurs when the mouse pointer rests on the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousehover(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MouseHover;
        /// <summary>
        /// Occurs when the mouse pointer leaves the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseleave(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MouseLeave;
        /// <summary>
        /// Occurs when the mouse pointer is moved over the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousemove(v=vs.110).aspx
        /// </remarks>
        public event MouseEventHandler MouseMove;
        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseup(v=vs.110).aspx
        /// </remarks>
        public event MouseEventHandler MouseUp;

        /// <summary>
        /// Occurs when the mouse wheel moves while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousewheel(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public event MouseEventHandler MouseWheel;

        /// <summary>
        /// Occurs when the control is moved.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.move(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Move;
        /// <summary>
        /// Occurs when the control is resized.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resize(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Resize;
        /// <summary>
        /// Occurs when the <see cref="Size"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.sizechanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler SizeChanged;
        /// <summary>
        /// Occurs when the <see cref="TabIndex"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabindexchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler TabIndexChanged;
        /// <summary>
        /// Occurs when the <see cref="TabStop"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabstopchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler TabStopChanged;
        /// <summary>
        /// Occurs when the <see cref="Text"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.textchanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler TextChanged;
        /// <summary>
        /// Occurs when the <see cref="Visible"/> property value changes.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.visiblechanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler VisibleChanged;
        #endregion

        /// <summary>
        /// Represents a collection of <see cref="Control"/> objects.
        /// Is not actually inherited from ArrangedElementCollection. ArrangedElementCollection was removed from this implementation. (Cuz was Dolan.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection(v=vs.110).aspx
        /// </remarks>
        [ListBindableAttribute(false)]
        public class ControlCollection : IEnumerable
        {
            private List<Control> _Controls;
            private Control _Owner;

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="Control.ControlCollection"/> class.
            /// </summary>
            /// <param name="owner">A <see cref="Control"/> representing the control that owns the control collection.</param>
            public ControlCollection(Control owner) { _Owner = owner; _Controls = new List<Control>(); }
            #endregion

            #region Properties
            /// <summary>
            /// Gets the number of elements in the collection.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.count(v=vs.110).aspx
            /// </remarks>
            public virtual int Count { get { return _Controls.Count; } }
            /// <summary>
            /// Gets a value indicating whether the collection is read-only.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.isreadonly(v=vs.110).aspx
            /// </remarks>
            public virtual bool IsReadOnly { get { return false; } }
            /// <summary>
            /// Indicates the <see cref="Control"/> at the specified indexed location in the collection.
            /// </summary>
            /// <param name="index">The index of the control to retrieve from the control collection.</param>
            /// <returns>The <see cref="Control"/> located at the specified index location within the control collection.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/333f9hk4(v=vs.110).aspx
            /// </remarks>
            public virtual Control this[int index] { get { return _Controls[index]; } }
            /// <summary>
            /// Indicates a <see cref="Control"/> with the specified key in the collection.
            /// </summary>
            /// <param name="key">The name of the control to retrieve from the control collection.</param>
            /// <returns>The <see cref="Control"/> with the specified key within the <see cref="Control.ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/s1865435(v=vs.110).aspx
            /// </remarks>
            public virtual Control this[string key] { get { foreach (Control c in _Controls) { if (c._Name == key) { return c; } } throw new KeyNotFoundException(); } }
            /// <summary>
            /// Gets the control that owns this <see cref="Control.ControlCollection"/>.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.owner(v=vs.110).aspx
            /// </remarks>
            public Control Owner { get { return _Owner; } }
            #endregion

            #region Methods
            /// <summary>
            /// Adds the specified control to the control collection.
            /// </summary>
            /// <param name="value">The <see cref="Control"/> to add to the control collection.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.add(v=vs.110).aspx
            /// </remarks>
            public virtual void Add(Control value) { if (_Owner == value) { throw new Exception(); } value.TabIndex = _Controls.Count; _Controls.Add(value); value.Parent = _Owner; }
            /// <summary>
            /// Adds an array of control objects to the collection.
            /// </summary>
            /// <param name="controls">An array of <see cref="Control"/> objects to add to the collection.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.addrange(v=vs.110).aspx
            /// </remarks>
            public virtual void AddRange(Control[] controls) { foreach (Control control in controls) { this.Add(control); } }
            /// <summary>
            /// Removes all controls from the collection.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.clear(v=vs.110).aspx
            /// </remarks>
            public virtual void Clear() { _Controls.Clear(); }
            /// <summary>
            /// Determines whether the specified control is a member of the collection.
            /// </summary>
            /// <param name="control">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>true if the <see cref="Control"/> is a member of the collection; otherwise, false.</returns>
            public bool Contains(Control control) { return _Controls.Contains(control); }
            /// <summary>
            /// Determines whether the <see cref="Control.ControlCollection"/> contains an item with the specified key.
            /// </summary>
            /// <param name="key">The key to locate in the <see cref="Control.ControlCollection"/>.</param>
            /// <returns>true if the <see cref="Control.ControlCollection"/> contains an item with the specified key; otherwise, false.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.containskey(v=vs.110).aspx
            /// </remarks>
            public virtual bool ContainsKey(string key) { foreach (Control c in _Controls) { if (c._Name == key) { return true; } } return false; }
            /// <summary>
            /// Copies the entire contents of this collection to a compatible one-dimensional <see cref="Array"/>, starting at the specified index of the target array.
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from the current collection. The array must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in array at which copying begins.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.copyto(v=vs.110).aspx
            /// </remarks>
            public void CopyTo(Array array, int index) { throw new NotImplementedException(); }
            /// <summary>
            /// Searches for controls by their <see cref="Name"/> property and builds an array of all the controls that match.
            /// </summary>
            /// <param name="key">The key to locate in the <see cref="Control.ControlCollection"/>.</param>
            /// <param name="searchAllChildren">true to search all child controls; otherwise, false.</param>
            /// <returns>An array of type <see cref="Control"/> containing the matching controls.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.find(v=vs.110).aspx
            /// </remarks>
            public Control[] Find(string key, bool searchAllChildren) { throw new NotImplementedException(); }
            /// <summary>
            /// Retrieves the index of the specified child control within the control collection.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to search for in the control collection.</param>
            /// <returns>A zero-based index value that represents the location of the specified child control within the control collection.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/1fz293fh(v=vs.110).aspx
            /// </remarks>
            public int GetChildIndex(Control child) { if (_Controls.Contains(child)) { return _Controls.IndexOf(child); } throw new KeyNotFoundException(); }
            /// <summary>
            /// Retrieves the index of the specified child control within the control collection, and optionally raises an exception if the specified control is not within the control collection.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to search for in the control collection.</param>
            /// <param name="throwException">true to throw an exception if the <see cref="Control"/> specified in the child parameter is not a control in the <see cref="Control.ControlCollection"/>; otherwise, false.</param>
            /// <returns></returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/ta8fcz9s(v=vs.110).aspx
            /// </remarks>
            public virtual int GetChildIndex(Control child, bool throwException) { if (_Controls.Contains(child)) { return _Controls.IndexOf(child); } if (throwException) { throw new ArgumentException(); } return -1; }
            /// <summary>
            /// Retrieves a reference to an enumerator object that is used to iterate over a <see cref="Control.ControlCollection"/>.
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/ms158431(v=vs.110).aspx
            /// </remarks>
            public virtual IEnumerator GetEnumerator() { return _Controls.GetEnumerator(); }
            /// <summary>
            /// Retrieves the index of the specified control in the control collection.
            /// </summary>
            /// <param name="control">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>A zero-based index value that represents the position of the specified <see cref="Control"/> in the <see cref="Control.ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.indexof(v=vs.110).aspx
            /// </remarks>
            public int IndexOf(Control control) { return _Controls.IndexOf(control); }
            /// <summary>
            /// Retrieves the index of the specified control in the control collection.
            /// </summary>
            /// <param name="key">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>A zero-based index value that represents the position of the specified <see cref="Control"/> in the <see cref="Control.ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.indexof(v=vs.110).aspx
            /// </remarks>
            public virtual int IndexOfKey(string key) { throw new NotImplementedException(); }
            /// <summary>
            /// Removes the specified control from the control collection.
            /// </summary>
            /// <param name="value">The <see cref="Control"/> to remove from the <see cref="Control.ControlCollection"/>.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.remove(v=vs.110).aspx
            /// </remarks>
            public virtual void Remove(Control value) { _Controls.Remove(value); }
            /// <summary>
            /// Removes a control from the control collection at the specified indexed location.
            /// </summary>
            /// <param name="index">The index value of the <see cref="Control"/> to remove.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.removeat(v=vs.110).aspx
            /// </remarks>
            public void RemoveAt(int index) { _Controls.RemoveAt(index); }
            /// <summary>
            /// Removes the child control with the specified key.
            /// </summary>
            /// <param name="key">The name of the child control to remove.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.removebykey(v=vs.110).aspx
            /// </remarks>
            public virtual void RemoveByKey(string key) { throw new NotImplementedException(); }
            /// <summary>
            /// Sets the index of the specified child control in the collection to the specified index value.
            /// </summary>
            /// <param name="child">The child <see cref="Control"/> to search for.</param>
            /// <param name="newIndex">The new index value of the control.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.setchildindex(v=vs.110).aspx
            /// </remarks>
            public virtual void SetChildIndex(Control child, int newIndex) { if (_Controls.Contains(child)) { if (newIndex >= Count) { _Controls.Remove(child); _Controls.Add(child); } else { _Controls.Remove(child); _Controls.Insert(newIndex, child); } } else { throw new ArgumentException(); } }
            #endregion

            #region Explicit Interface Implementations
            //Object ICloneable.Clone() { return new object(); }
            //bool ICollection.IsSynchronized { get { return true; } }
            //Object ICollection.SyncRoot { get { return new object(); } }
            //int IList.Add(Object control) { if (control is Control) { this.Add((Control)control); return _Controls.Count; } return -1; }
            //void IList.Clear() { _Controls.Clear(); }
            //bool IList.Contains(Object value) { if (value is Control) { return _Controls.Contains((Control)value); } return false; }
            //int IList.IndexOf(Object value) { if (value is Control) { return _Controls.IndexOf((Control)value); } return -1; }
            //void IList.Insert(int index, Object value) { if (value is Control) { _Controls.Insert(index, (Control)value); } }
            //bool IList.IsFixedSize { get { return false; } }
            //Object IList.this[int index] { get { return _Controls[index]; } set { if (value is Control) { _Controls[index] = (Control)value; } } }
            //void IList.Remove(Object control) { if (control is Control) { _Controls.Remove((Control)control); } }
            //void IList.RemoveAt(int index) { _Controls.RemoveAt(index); }
            #endregion
        }
    }
}
