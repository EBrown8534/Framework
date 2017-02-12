using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Represents a form (collection of <see cref="Control"/> objects) to be used for display in a project.
    /// </summary>
    /// <remarks>
    /// This class should not be directly inherited, as it is infrastructure for other, more graphics related, projects. You should, instead, inherit a form that is shipped with the related Graphics Library extension for your project.
    /// 
    /// I spent a lot of time typing out this class. I just started typing and typing, and I didn't stop typing.
    /// </remarks>
    public class Form : ContainerControl
    {
        /// <summary>
        /// A list of <see cref="Form"/> objects this <see cref="Form"/> owns.
        /// </summary>
        protected static List<Form> Forms = new List<Form>();

        #region Constructors
        /// <summary>
        /// Constructs a new instance of <see cref="Form"/> with default values.
        /// </summary>
        public Form()
        {
            OwnedForms = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the currently active form for this application.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.activeform(v=vs.110).aspx
        /// </remarks>
        public static Form ActiveForm { get; set; }

        /// <summary>
        /// Infrastructure. Gets or sets a value indicating whether the opacity of the form can be adjusted.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.allowtransparency(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool AllowTransparency { get; set; }

        /// <summary>
        /// Gets the default size of the control. (Overrides <see cref="Control.DefaultSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.defaultsize(v=vs.110).aspx
        /// </remarks>
        protected override Size DefaultSize { get; }

        /// <summary>
        /// Gets or sets the size and location of the form on the Windows desktop.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.desktopbounds(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Rectangle DesktopBounds { get { return Bounds; } set { Bounds = value; } }

        /// <summary>
        /// Gets or sets the location of the form on the Windows desktop.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.desktoplocation(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Point DesktopLocation { get { return Location; } set { Location = value; } }

        /// <summary>
        /// Gets or sets the border style of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.formborderstyle(v=vs.110).aspx
        /// </remarks>
        public FormBorderStyle FormBorderStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Maximize</b> button is displayed in the caption bar of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximizebox(v=vs.110).aspx
        /// </remarks>
        public bool MaximizeBox { get; set; }
        /// <summary>
        /// Gets and sets the size of the form when it is maximized.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximizedbounds(v=vs.110).aspx
        /// </remarks>
        protected Rectangle MaximizedBounds { get; set; }
        /// <summary>
        /// Gets the maximum size the form can be resized to. (Overrides <see cref="Control.MaximumSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximumsize(v=vs.110).aspx
        /// </remarks>
        public override Size MaximumSize { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the <b>Minimize</b> button is displayed in the caption bar of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.minimizebox(v=vs.110).aspx
        /// </remarks>
        public bool MinimizeBox { get; set; }
        /// <summary>
        /// Gets or sets the minimum size the form can be resized to. (Overrides <see cref="Control.MinimumSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.minimumsize(v=vs.110).aspx
        /// </remarks>
        public override Size MinimumSize { get; set; }

        /// <summary>
        /// Gets or sets the opacity level of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.opacity(v=vs.110).aspx
        /// </remarks>
        public double Opacity { get; set; }

        /// <summary>
        /// Gets an array of Form objects that represent all forms that are owned by this form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.ownedforms(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Form[] OwnedForms { get; private set; }

        /// <summary>
        /// Gets or sets the form that owns this form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.owner(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Form Owner { get; set; }

        /// <summary>
        /// Gets the location and size of the form in its normal window state.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.restorebounds(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public Rectangle RestoreBounds { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets or sets a value indicating whether the form is displayed in the Windows taskbar.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.showintaskbar(v=vs.110).aspx
        /// </remarks>
        public bool ShowInTaskbar { get; set; }
        /// <summary>
        /// Gets or sets the style of the size grip to display in the lower-right corner of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.sizegripstyle(v=vs.110).aspx
        /// </remarks>
        public SizeGripStyle SizeGripStyle { get; set; }
        /// <summary>
        /// Gets or sets the starting position of the form at run time.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.startposition(v=vs.110).aspx
        /// </remarks>
        public FormStartPosition StartPosition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display the form as a top-level window.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.toplevel(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public bool TopLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the form should be displayed as a topmost form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.topmost(v=vs.110).aspx
        /// </remarks>
        public bool TopMost { get; set; }
        /// <summary>
        /// Gets or sets the color that will represent transparent areas of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.transparencykey(v=vs.110).aspx
        /// </remarks>
        public Color TransparencyKey { get; set; }
        /// <summary>
        /// Gets or sets a value that indicates whether form is minimized, maximized, or normal.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.windowstate(v=vs.110).aspx
        /// </remarks>
        public FormWindowState WindowState { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Activates the form and gives it focus.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.activate(v=vs.110).aspx
        /// </remarks>
        public void Activate()
        {
            ActiveForm = this;

            if (Forms.Contains(this))
            {
                Forms.Remove(this);
            }

            Forms.Insert(0, this);
        }

        /// <summary>
        /// Adds an owned form to this form.
        /// </summary>
        /// <param name="ownedForm">The <see cref="Form"/> that this form will own.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.addownedform(v=vs.110).aspx
        /// </remarks>
        public void AddOwnedForm(Form ownedForm)
        {
            Form[] tForms = new Form[OwnedForms.Length + 1];

            for (int i = 0; i < OwnedForms.Length; i++)
            {
                tForms[i] = OwnedForms[i];
            }

            tForms[tForms.Length - 1] = ownedForm;
            OwnedForms = tForms;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.close(v=vs.110).aspx
        /// </remarks>
        public void Close()
        {
            OnClosing(new CancelEventArgs());
            OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false));
            Forms.Remove(this);
            OnClosed(new EventArgs());
            OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
        }

        public override bool Focus()
        {
            if (CanFocus)
            {
                ActiveForm = this;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves the <see cref="Form"/> with the specified <see cref="Control.Name"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The <see cref="Form"/> that has the specified <see cref="Control.Name"/>.</returns>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.control.findform(v=vs.110).aspx
        /// </remarks>
        public static Form FindForm(string key)
        {
            foreach (Form form in Forms)
            {
                if (form.Name == key)
                {
                    return form;
                }
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Determines if a character is an input character that the control recognizes.
        /// </summary>
        /// <param name="charCode">The character to test.</param>
        /// <returns>True if the character should be sent directly to the control and not preprocessed; otherwise, false.</returns>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.control.isinputchar(v=vs.110).aspx
        /// </remarks>
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputChar(char charCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="Keys"/> values.</param>
        /// <returns>True if the specified key is a regular input key; otherwise, false.</returns>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.control.isinputkey(v=vs.110).aspx
        /// </remarks>
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputKey(Keys keyData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises the <see cref="Activated"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onactivated(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnActivated(EventArgs e)
        {
            var evenHandler = Activated;
            evenHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Closed"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onclosed(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClosed(EventArgs e)
        {
            var evenHandler = Closed;
            evenHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Closing"/> event.
        /// </summary>
        /// <param name="e">A <code>CancelEventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onclosing(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnClosing(CancelEventArgs e)
        {
            var evenHandler = Closing;
            evenHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Deactivate"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.ondeactivate(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnDeactivate(EventArgs e)
        {
            var evenHandler = Deactivate;
            evenHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="Control.EnabledChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/46w4szff(v=vs.110).aspx
        /// </remarks>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="Control.Enter"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/46w4szff(v=vs.110).aspx
        /// </remarks>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="FormClosed"/> event.
        /// </summary>
        /// <param name="e">A <see cref="FormClosedEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onformclosed(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnFormClosed(FormClosedEventArgs e)
        {
            var evenHandler = FormClosed;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="FormClosing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="FormClosingEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onformclosing(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnFormClosing(FormClosingEventArgs e)
        {
            var evenHandler = FormClosing;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="Load"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onload(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnLoad(EventArgs e)
        {
            var evenHandler = Load;
            evenHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MaximizedBoundsChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onmaximizedboundschanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMaximizedBoundsChanged(EventArgs e)
        {
            var evenHandler = MaximizedBoundsChanged;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="MaximumSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onmaximumsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMaximumSizeChanged(EventArgs e)
        {
            var evenHandler = MaximumSizeChanged;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="MinimumSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onminimumsizechanged(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnMinimumSizeChanged(EventArgs e)
        {
            var evenHandler = MinimumSizeChanged;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="Control.Resize"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/akxb9sb3(v=vs.110).aspx
        /// </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="ResizeBegin"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onresizebegin(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnResizeBegin(EventArgs e)
        {
            var evenHandler = ResizeBegin;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="ResizeEnd"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onresizeend(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnResizeEnd(EventArgs e)
        {
            var evenHandler = ResizeEnd;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="Shown"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onshown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnShown(EventArgs e)
        {
            var evenHandler = Shown;
            evenHandler?.Invoke(this, e); 
        }

        /// <summary>
        /// Raises the <see cref="Control.TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/ck6f88bf(v=vs.110).aspx
        /// </remarks>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="Control.VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <code>EventArgs</code> that contains the event data.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.onvisiblechanged(v=vs.110).aspx
        /// </remarks>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }

        /// <summary>
        /// Removes an owned form from this form.
        /// </summary>
        /// <param name="ownedForm">A <see cref="Form"/> representing the form to remove from the list of owned forms for this form.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.removeownedform(v=vs.110).aspx
        /// </remarks>
        public void RemoveOwnedForm(Form ownedForm)
        {
            Form[] tForms = new Form[OwnedForms.Length - 1];

            int tIndex = 0;

            foreach (Form f in OwnedForms)
            {
                if (!f.Equals(ownedForm))
                {
                    tForms[tIndex] = f;
                    tIndex++;
                }
            }

            OwnedForms = tForms;
        }

        /// <summary>
        /// Selects this form, and optionally selects the next or previous control.
        /// </summary>
        /// <param name="directed">If set to true that the active control is changed</param>
        /// <param name="forward">If directed is true, then this controls the direction in which focus is moved. If this is true, then the next control is selected; otherwise, the previous control is selected.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/sh071987(v=vs.110).aspx
        /// </remarks>
        protected override void Select(bool directed, bool forward)
        {
            Activate();
            SetTopLevel(true);
        }

        /// <summary>
        /// Sets the bounds of the form in desktop coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the form's <see cref="Control.Location"/>.</param>
        /// <param name="y">The y-coordinate of the form's <see cref="Control.Location"/>.</param>
        /// <param name="width">The width of the form.</param>
        /// <param name="height">The height of the form.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.setdesktopbounds(v=vs.110).aspx
        /// </remarks>
        public void SetDesktopBounds(int x, int y, int width, int height)
        {
            OnResizeBegin(new EventArgs());
            Location = new Point(x, y);
            Size = new Size(width, height);
            OnResize(new EventArgs());
            OnResizeEnd(new EventArgs());
        }

        /// <summary>
        /// Sets the location of the form in desktop coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the form's <see cref="Control.Location"/>.</param>
        /// <param name="y">The y-coordinate of the form's <see cref="Control.Location"/>.</param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.setdesktoplocation(v=vs.110).aspx
        /// </remarks>
        public void SetDesktopLocation(int x, int y)
        {
            Location = new Point(x, y);
        }

        /// <summary>
        /// Calling this method will add the form for processing. Once a form has been shown, you should call <see cref="Close"/> to dispose of resources properly.
        /// </summary>
        /// <remarks>
        /// Due to the non-blocking nature of this method, once a form is shown the variable for it can go out of scope. This means that it will not be possible to close the form manually. It will also not be possible to make any changes to the form as well. The form will also not be disposed of, until it is closed by the user clicking the Close button, if one is made available.
        /// 
        /// If you do not need to add controls, programmatically change anything on the form, or programmatically operate on it, then it is not necessary to hold on to the variable. You may still subscribe to events and will be informed when an event is triggered.
        /// </remarks>
        public new void Show()
        {
            if (Forms.Contains(this))
            {
                throw new InvalidOperationException("The Form.Show() method has already been called on this Form.");
            }

            Forms.Add(this);
            Enabled = true;
            Visible = true;
            base.Show();
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the form is activated in code or by the user.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.activated(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Activated;

        /// <summary>
        /// Occurs when the form is closed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.closed(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public event EventHandler Closed;

        /// <summary>
        /// Occurs when the form is closing.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.closing(v=vs.110).aspx
        /// </remarks>
        [Browsable(false)]
        public event CancelEventHandler Closing;

        /// <summary>
        /// Occurs when the form loses focus and is no longer the active form.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.deactivate(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Deactivate;

        /// <summary>
        /// Occurs after the form is closed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.formclosed(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<FormClosedEventArgs> FormClosed;

        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.formclosing(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<FormClosingEventArgs> FormClosing;

        /// <summary>
        /// Occurs before a form is displayed for the first time.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.load(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Load;

        /// <summary>
        /// Occurs when the value of the <see cref="MaximizedBounds"/> property has changed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximizedboundschanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MaximizedBoundsChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="MaximumSize"/> property has changed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximumsizechanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MaximumSizeChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="MinimumSize"/> property has changed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.minimumsizechanged(v=vs.110).aspx
        /// </remarks>
        public event EventHandler MinimumSizeChanged;

        /// <summary>
        /// Occurs when a form enters resizing mode.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.resizebegin(v=vs.110).aspx
        /// </remarks>
        public event EventHandler ResizeBegin;

        /// <summary>
        /// Occurs when a form exits resizing mode.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.resizeend(v=vs.110).aspx
        /// </remarks>
        public event EventHandler ResizeEnd;

        /// <summary>
        /// Occurs whenever the form is first displayed.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.form.shown(v=vs.110).aspx
        /// </remarks>
        public event EventHandler Shown;
        #endregion
    }
}
