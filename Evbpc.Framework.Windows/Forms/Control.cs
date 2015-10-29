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
    public abstract partial class Control : Component, IComponent, IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Control class with default settings.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/6b19wbt2(v=vs.110).aspx
        /// </remarks>
        public Control()
        {
            Text = "";
            BackColor = DefaultBackColor;
            ForeColor = DefaultForeColor;
            Anchor = AnchorStyles.None;
            Capture = true;
            Controls = new ControlCollection(this);
            Enabled = true;
            Location = new Point();
            MaximumSize = DefaultMaximumSize;
            MinimumSize = DefaultMinimumSize;
            Name = "";
            Parent = null;
            Size = DefaultSize;
            TabIndex = int.MaxValue;
            TabStop = true;
            Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the Control class with specific text.
        /// </summary>
        /// <param name="text">The text displayed by the control.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/sdxb8fy8(v=vs.110).aspx
        /// </remarks>
        public Control(string text)
            : this()
        {
            Text = text;
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
            : this(text)
        {
            Parent = parent;
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
            : this(text)
        {
            Location = new Point(left, top);
            Size = new Drawing.Size(width, height);
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
            : this(text, left, top, width, height)
        {
            Parent = parent;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.anchor(v=vs.110).aspx
        /// </remarks>
        public virtual AnchorStyles Anchor { get; set; }
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.backcolor(v=vs.110).aspx
        /// </remarks>
        public virtual Color BackColor { get; set; }

        /// <summary>
        /// Gets the distance, in pixels, between the bottom edge of the control and the top edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.bottom(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Bottom => Location.Y + Size.Height;

        /// <summary>
        /// Gets or sets the size and location of the control including its nonclient elements, in pixels, relative to the parent control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.bounds(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Rectangle Bounds { get { return new Rectangle(Location, Size); } set { Location = value.Location; Size = value.Size; } }

        /// <summary>
        /// Gets a value indicating whether the control can receive focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.canfocus(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool CanFocus => ((Parent != null && Parent.CanFocus) || (Parent == null && this is Form)) && Enabled && Visible;

        /// <summary>
        /// Gets a value indicating whether the control can be selected.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.canselect(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool CanSelect => Parent != null && Parent.CanFocus && Visible && Enabled;

        /// <summary>
        /// Gets or sets a value indicating whether the control has captured the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.capture(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool Capture { get; set; }

        /// <summary>
        /// Gets the rectangle that represents the client area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.clientrectangle(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Rectangle ClientRectangle => Bounds;

        /// <summary>
        /// Gets or sets the height and width of the client area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.clientsize(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Size ClientSize { get { return Size; } set { Size = value; } }

        /// <summary>
        /// Gets a value indicating whether the control, or one of its child controls, currently has the input focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.containsfocus(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool ContainsFocus
        {
            get
            {
                if (Parent != null)
                {
                    foreach (Control c in Controls)
                    {
                        if (c.ContainsFocus)
                        {
                            return true;
                        }
                    }

                    if (FindForm().ActiveControl == this)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the collection of controls contained within the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controls(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public ControlCollection Controls { get; }

        /// <summary>
        /// Gets the default background color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultbackcolor(v=vs.110).aspx
        /// </remarks>
        public static Color DefaultBackColor => new Color(255, 255, 255);

        /// <summary>
        /// Gets the default foreground color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultforecolor(v=vs.110).aspx
        /// </remarks>
        public static Color DefaultForeColor => new Color(0, 0, 0);

        /// <summary>
        /// Gets the length and height, in pixels, that is specified as the default maximum size of a control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultmaximumsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultMaximumSize => new Size(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Gets the length and height, in pixels, that is specified as the default minimum size of a control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultminimumsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultMinimumSize => new Size(0, 0);

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.defaultsize(v=vs.110).aspx
        /// </remarks>
        protected virtual Size DefaultSize => new Size(640, 480);

        /// <summary>
        /// Gets the rectangle that represents the display area of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.displayrectangle(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public virtual Rectangle DisplayRectangle => Bounds;

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.enabled(v=vs.110).aspx
        /// </remarks>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.focused(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public virtual bool Focused => Parent != null && ContainsFocus;

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.forecolor(v=vs.110).aspx
        /// </remarks>
        public virtual Color ForeColor { get; set; }

        /// <summary>
        /// Gets a value indicating whether the control contains one or more child controls.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.haschildren(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool HasChildren => Controls.Count > 0;

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.height(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Height { get { return Size.Height; } set { Size = new Size(Size.Width, value); } }

        /// <summary>
        /// Gets or sets the distance, in pixels, between the left edge of the control and the left edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.left(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Left { get { return Location.X; } set { Location = new Point(value, Location.Y); } }

        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the control relative to the upper-left corner of its container.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.location(v=vs.110).aspx
        /// </remarks>
        public Point Location { get; set; }
        /// <summary>
        /// Gets or sets the size that is the upper limit that GetPreferredSize can specify.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.maximumsize(v=vs.110).aspx
        /// </remarks>
        public virtual Size MaximumSize { get; set; }
        /// <summary>
        /// Gets or sets the size that is the lower limit that GetPreferredSize can specify.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.minimumsize(v=vs.110).aspx
        /// </remarks>
        public virtual Size MinimumSize { get; set; }

        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.name(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent container of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.parent(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Control Parent { get; set; }

        /// <summary>
        /// Gets the size of a rectangular area into which the control can fit.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.preferredsize(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Size PreferredSize => Size;

        /// <summary>
        /// Gets the distance, in pixels, between the right edge of the control and the left edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.right(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Right => Location.X + Size.Width;

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.size(v=vs.110).aspx
        /// </remarks>
        public Size Size { get; set; }
        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabindex(v=vs.110).aspx
        /// </remarks>
        public int TabIndex { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.tabstop(v=vs.110).aspx
        /// </remarks>
        public bool TabStop { get; set; }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.text(v=vs.110).aspx
        /// </remarks>
        [BindableAttribute(true)]
        public virtual string Text { get; set; }

        /// <summary>
        /// Gets or sets the distance, in pixels, between the top edge of the control and the top edge of its container's client area.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.top(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Top { get { return Location.X; } set { Location = new Point(Location.X, value); } }

        /// <summary>
        /// Gets the parent control that is not parented by another Windows Forms control. Typically, this is the outermost Form that the control is contained in.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.toplevelcontrol(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Control TopLevelControl
        {
            get
            {
                if (Parent == null)
                {
                    if (this is Form)
                    {
                        return this;
                    }
                }
                else
                {
                    return Parent.TopLevelControl;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.visible(v=vs.110).aspx
        /// </remarks>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.width(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public int Width { get { return Size.Width; } set { Size = new Size(value, Size.Height); } }
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
        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        public Form FindForm()
        {
            if (this is Form)
            {
                return (Form)this;
            }
            else
            {
                return Parent?.FindForm();
            }
        }

        /// <summary>
        /// Sets input focus to the control.
        /// </summary>
        /// <returns>true if the input focus request was successful; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.focus(v=vs.110).aspx
        /// </remarks>
        public bool Focus()
        {
            if (Parent != null)
            {
                if (CanFocus)
                {
                    FindForm().ActiveControl = this;
                }
            }

            return ContainsFocus;
        }

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
        public virtual Size GetPreferredSize(Size proposedSize) => new Size(Math.Min(Size.Width, proposedSize.Width), Math.Min(Size.Height, proposedSize.Height));

        /// <summary>
        /// Determines if the control is a top-level control.
        /// </summary>
        /// <returns>true if the control is a top-level control; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.gettoplevel(v=vs.110).aspx
        /// </remarks>
        protected bool GetTopLevel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises the <see cref="BackColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onbackcolorchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnBackColorChanged(EventArgs e)
        {
            var handler = BackColorChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Click"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClick(EventArgs e)
        {
            var handler = Click;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ClientSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onclientsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClientSizeChanged(EventArgs e)
        {
            var handler = ClientSizeChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ControlAdded"/> event.
        /// </summary>
        /// <param name="e">A <see cref="ControlEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.oncontroladded(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnControlAdded(ControlEventArgs e)
        {
            var handler = ControlAdded;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">A <see cref="ControlEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.oncontrolremoved(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnControlRemoved(ControlEventArgs e)
        {
            var handler = ControlRemoved;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="DoubleClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ondoubleclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnDoubleClick(EventArgs e)
        {
            var handler = DoubleClick;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="EnabledChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onenabledchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            var handler = EnabledChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Enter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onenter(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnEnter(EventArgs e)
        {
            var handler = Enter;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ForeColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onforecolorchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnForeColorChanged(EventArgs e)
        {
            var handler = ForeColorChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ongotfocus(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnGotFocus(EventArgs e)
        {
            var handler = GotFocus;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="KeyDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeydown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            var handler = KeyDown;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyPressEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeypress(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyPress(KeyPressEventArgs e)
        {
            var handler = KeyPress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="KeyUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeyup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyUp(KeyEventArgs e)
        {
            var handler = KeyUp;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Leave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onleave(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLeave(EventArgs e)
        {
            var handler = Leave;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="LocationChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onlocationchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLocationChanged(EventArgs e)
        {
            var handler = LocationChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="LostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onlostfocus(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLostFocus(EventArgs e)
        {
            var handler = LostFocus;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseClick(MouseEventArgs e)
        {
            var handler = MouseClick;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousedoubleclick(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseDoubleClick(MouseEventArgs e)
        {
            var handler = MouseDoubleClick;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousedown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            var handler = MouseDown;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseEnter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseenter(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseEnter(EventArgs e)
        {
            var handler = MouseEnter;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseHover"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousehover(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseHover(EventArgs e)
        {
            var handler = MouseHover;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseLeave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseleave(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseLeave(EventArgs e)
        {
            var handler = MouseLeave;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseMove"/> event.
        /// </summary>
        /// <param name="e">An <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousemove(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseMove(MouseEventArgs e)
        {
            var handler = MouseMove;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmouseup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            var handler = MouseUp;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MouseWheel"/> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmousewheel(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMouseWheel(MouseEventArgs e)
        {
            var handler = MouseWheel;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Move"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onmove(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMove(EventArgs e)
        {
            var handler = Move;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Resize"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onresize(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnResize(EventArgs e)
        {
            var handler = Resize;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnSizeChanged(EventArgs e)
        {
            var handler = SizeChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TabIndexChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontabindexchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTabIndexChanged(EventArgs e)
        {
            var handler = TabIndexChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TabStopChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontabstopchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTabStopChanged(EventArgs e)
        {
            var handler = TabStopChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.ontextchanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnTextChanged(EventArgs e)
        {
            var handler = TextChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onvisiblechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnVisibleChanged(EventArgs e)
        {
            var handler = VisibleChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Resets the <see cref="BackColor"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resetbackcolor(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetBackColor()
        {
            BackColor = DefaultBackColor;
        }

        /// <summary>
        /// Resets the <see cref="ForeColor"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resetforecolor(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetForeColor()
        {
            ForeColor = DefaultForeColor;
        }

        /// <summary>
        /// Resets the <see cref="Text"/> property to its default value.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.resettext(v=vs.110).aspx
        /// </remarks>
        public virtual void ResetText()
        {
            Text = "";
        }

        /// <summary>
        /// Activates the control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/7wt11hea(v=vs.110).aspx
        /// </remarks>
        public void Select()
        {
            Focus();
        }

        /// <summary>
        /// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
        /// </summary>
        /// <param name="directed">true to specify the direction of the control to select; otherwise, false.</param>
        /// <param name="forward">true to move forward in the tab order; false to move backward in the tab order.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/hb97bya5(v=vs.110).aspx
        /// </remarks>
        protected virtual void Select(bool directed, bool forward)
        {
            throw new NotImplementedException();
        }

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
        public bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends the control to the back of the z-order.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.sendtoback(v=vs.110).aspx
        /// </remarks>
        public void SendToBack()
        {
            throw new NotImplementedException();
        }

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
        public void SetBounds(int x, int y, int width, int height)
        {
            Location = new Point(x, y);
            Size = new Size(width, height);
        }

        /// <summary>
        /// Sets the control as the top-level control.
        /// </summary>
        /// <param name="value">true to set the control as the top-level control; otherwise, false.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.settoplevel(v=vs.110).aspx
        /// </remarks>
        protected void SetTopLevel(bool value)
        {
            /*throw new NotImplementedException();*/
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.show(v=vs.110).aspx
        /// </remarks>
        public void Show()
        {
            Visible = true;
            Select();
        }
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
        [Browsable(true)]
        public event EventHandler<ControlEventArgs> ControlAdded;

        /// <summary>
        /// Occurs when a control is removed from the <see cref="Control.ControlRemoved"/>.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlremoved(v=vs.110).aspx
        /// </remarks>
        [Browsable(true)]
        public event EventHandler<ControlEventArgs> ControlRemoved;

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
        [Browsable(false)]
        public event EventHandler GotFocus;

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyEventArgs> KeyDown;
        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keypress(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyPressEventArgs> KeyPress;
        /// <summary>
        /// Occurs when a key is released while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keyup(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyEventArgs> KeyUp;
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
        [Browsable(false)]
        public event EventHandler LostFocus;

        /// <summary>
        /// Occurs when the control is clicked by the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseclick(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<MouseEventArgs> MouseClick;
        /// <summary>
        /// Occurs when the control is double clicked by the mouse.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousedoubleclick(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<MouseEventArgs> MouseDoubleClick;
        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousedown(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<MouseEventArgs> MouseDown;
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
        public event EventHandler<MouseEventArgs> MouseMove;
        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mouseup(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<MouseEventArgs> MouseUp;

        /// <summary>
        /// Occurs when the mouse wheel moves while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.mousewheel(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public event EventHandler<MouseEventArgs> MouseWheel;

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
    }
}
