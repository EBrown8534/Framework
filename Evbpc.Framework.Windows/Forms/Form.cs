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
    /// Represents a form (collection of <see cref="Control"/>s) to be used for display in a project. This class should not be directly inherited, as it is infrastructure for other, more graphics related, projects. You should, instead, inherit a form that is shipped with the related Graphics Library extension for your project.
    /// </summary>
    /// <remarks>
    /// I spent a lot of time typing out this class. I just started typing and typing, and I didn't stop typing.
    /// </remarks>
    public class Form : ContainerControl
    {
        protected static Form _ActiveForm;
        protected static List<Form> _Forms = new List<Form>();
        private bool _AllowTransparency;
        private Size _DefaultSize;
        private FormBorderStyle _FormBorderStyle;
        private bool _MaximizeBox;
        private Rectangle _MaximizedBounds;
        private Size _MaximumSize;
        private bool _MinimizeBox;
        private Size _MinimumSize;
        private double _Opacity;
        private Form[] _OwnedForms;
        private Form _Owner;
        private bool _ShowInTaskbar;
        private SizeGripStyle _SizeGripStyle;
        private FormStartPosition _StartPosition;
        private bool _TopLevel;
        private bool _TopMost;
        private Color _TransparencyKey;
        private FormWindowState _WindowState;

        #region Constructors
        public Form() { _OwnedForms = null; }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the currently active form for this application.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.activeform(v=vs.110).aspx
        /// </remarks>
        public static Form ActiveForm { get { return _ActiveForm; } }

        /// <summary>
        /// Infrastructure. Gets or sets a value indicating whether the opacity of the form can be adjusted.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.allowtransparency(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool AllowTransparency { get { return _AllowTransparency; } set { _AllowTransparency = value; } }

        /// <summary>
        /// Gets the default size of the control. (Overrides <see cref="Control.DefaultSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.defaultsize(v=vs.110).aspx
        /// </remarks>
        protected override Size DefaultSize { get { return _DefaultSize; } }

        /// <summary>
        /// Gets or sets the size and location of the form on the Windows desktop.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.desktopbounds(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Rectangle DesktopBounds { get { return base.Bounds; } set { base.Bounds = value; } }

        /// <summary>
        /// Gets or sets the location of the form on the Windows desktop.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.desktoplocation(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Point DesktopLocation { get { return base.Location; } set { base.Location = value; } }

        /// <summary>
        /// Gets or sets the border style of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.formborderstyle(v=vs.110).aspx
        /// </remarks>
        public FormBorderStyle FormBorderStyle { get { return _FormBorderStyle; } set { _FormBorderStyle = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Maximize</b> button is displayed in the caption bar of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximizebox(v=vs.110).aspx
        /// </remarks>
        public bool MaximizeBox { get { return _MaximizeBox; } set { _MaximizeBox = value; } }
        /// <summary>
        /// Gets and sets the size of the form when it is maximized.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximizedbounds(v=vs.110).aspx
        /// </remarks>
        protected Rectangle MaximizedBounds { get { return _MaximizedBounds; } set { _MaximizedBounds = value; } }
        /// <summary>
        /// Gets the maximum size the form can be resized to. (Overrides <see cref="Control.MaximumSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.maximumsize(v=vs.110).aspx
        /// </remarks>
        public override Size MaximumSize { get { return _MaximumSize; } set { _MaximumSize = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether the <b>Minimize</b> button is displayed in the caption bar of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.minimizebox(v=vs.110).aspx
        /// </remarks>
        public bool MinimizeBox { get { return _MinimizeBox; } set { _MinimizeBox = value; } }
        /// <summary>
        /// Gets or sets the minimum size the form can be resized to. (Overrides <see cref="Control.MinimumSize"/>.)
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.minimumsize(v=vs.110).aspx
        /// </remarks>
        public override Size MinimumSize { get { return _MinimumSize; } set { _MinimumSize = value; } }

        /// <summary>
        /// Gets or sets the opacity level of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.opacity(v=vs.110).aspx
        /// </remarks>
        public double Opacity { get { return _Opacity; } set { _Opacity = value; } }

        /// <summary>
        /// Gets an array of Form objects that represent all forms that are owned by this form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.ownedforms(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Form[] OwnedForms { get { return _OwnedForms; } }

        /// <summary>
        /// Gets or sets the form that owns this form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.owner(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Form Owner { get { return _Owner; } set { _Owner = value; } }

        /// <summary>
        /// Gets the location and size of the form in its normal window state.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.restorebounds(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Rectangle RestoreBounds { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets or sets a value indicating whether the form is displayed in the Windows taskbar.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.showintaskbar(v=vs.110).aspx
        /// </remarks>
        public bool ShowInTaskbar { get { return _ShowInTaskbar; } set { _ShowInTaskbar = value; } }
        /// <summary>
        /// Gets or sets the style of the size grip to display in the lower-right corner of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.sizegripstyle(v=vs.110).aspx
        /// </remarks>
        public SizeGripStyle SizeGripStyle { get { return _SizeGripStyle; } set { _SizeGripStyle = value; } }
        /// <summary>
        /// Gets or sets the starting position of the form at run time.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.startposition(v=vs.110).aspx
        /// </remarks>
        public FormStartPosition StartPosition { get { return _StartPosition; } set { _StartPosition = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether to display the form as a top-level window.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.toplevel(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public bool TopLevel { get { return _TopLevel; } set { _TopLevel = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether the form should be displayed as a topmost form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.topmost(v=vs.110).aspx
        /// </remarks>
        public bool TopMost { get { return _TopMost; } set { _TopMost = value; } }
        /// <summary>
        /// Gets or sets the color that will represent transparent areas of the form.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.transparencykey(v=vs.110).aspx
        /// </remarks>
        public Color TransparencyKey { get { return _TransparencyKey; } set { _TransparencyKey = value; } }
        /// <summary>
        /// Gets or sets a value that indicates whether form is minimized, maximized, or normal.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.form.windowstate(v=vs.110).aspx
        /// </remarks>
        public FormWindowState WindowState { get { return _WindowState; } set { _WindowState = value; } }
        #endregion

        #region Methods
        public void Activate()
        {
            _ActiveForm = this;
            List<Form> l2 = new List<Form>();

            for (int i = 0; i < _Forms.Count; i++)
            {
                l2.Add(_Forms[i]);
            }

            _Forms.Clear();
            _Forms.Add(this);

            for (int i = 0; i < l2.Count; i++)
            {
                if (l2[i] != this)
                    _Forms.Add(l2[i]);
            }
        }
        public void AddOwnedForm(Form ownedForm) { Form[] tForms = new Form[_OwnedForms.Length + 1]; for (int i = 0; i < _OwnedForms.Length; i++) { tForms[i] = _OwnedForms[i]; } tForms[tForms.Length - 1] = ownedForm; _OwnedForms = tForms; }
        public void Close() { OnClosing(new CancelEventArgs()); OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false)); OnClosed(new EventArgs()); OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing)); _Forms.Remove(this); }

        public static Form FindForm(string key) { foreach (Form f in _Forms) { if (f.Name == key) { return f; } } throw new KeyNotFoundException(); }

        [UIPermissionAttribute(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputChar(char charCode) { throw new NotImplementedException(); }

        [UIPermissionAttribute(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputKey(Keys keyData) { throw new NotImplementedException(); }

        protected virtual void OnActivated(EventArgs e) { Activated(this, e); }
        protected virtual void OnClosed(EventArgs e) { Closed(this, e); }
        protected virtual void OnClosing(CancelEventArgs e) { Closing(this, e); }
        protected virtual void OnDeactivate(EventArgs e) { Deactivate(this, e); }
        protected override void OnEnabledChanged(EventArgs e) { base.OnEnabledChanged(e); }
        protected override void OnEnter(EventArgs e) { base.OnEnter(e); }
        protected virtual void OnFormClosed(FormClosedEventArgs e) { FormClosed(this, e); }
        protected virtual void OnFormClosing(FormClosingEventArgs e) { FormClosing(this, e); }
        protected virtual void OnLoad(EventArgs e) { Load(this, e); }
        protected virtual void OnMaximizedBoundsChanged(EventArgs e) { MaximizedBoundsChanged(this, e); }
        protected virtual void OnMaximumSizeChanged(EventArgs e) { MaximumSizeChanged(this, e); }
        protected virtual void OnMinimumSizeChanged(EventArgs e) { MinimumSizeChanged(this, e); }
        protected override void OnResize(EventArgs e) { base.OnResize(e); }
        protected virtual void OnResizeBegin(EventArgs e) { ResizeBegin(this, e); }
        protected virtual void OnResizeEnd(EventArgs e) { ResizeEnd(this, e); }
        protected virtual void OnShown(EventArgs e) { Shown(this, e); }
        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); }
        protected override void OnVisibleChanged(EventArgs e) { base.OnVisibleChanged(e); }
        public void RemoveOwnedForm(Form ownedForm) { Form[] tForms = new Form[_OwnedForms.Length - 1]; int tIndex = 0; foreach (Form f in _OwnedForms) { if (!f.Equals(ownedForm)) { tForms[tIndex] = f; tIndex++; } } }
        protected override void Select(bool directed, bool forward) { Activate(); SetTopLevel(true); }
        public void SetDesktopBounds(int x, int y, int width, int height) { OnResizeBegin(new EventArgs()); base.Location = new Point(x, y); base.Size = new Size(width, height); OnResize(new EventArgs()); OnResizeEnd(new EventArgs()); }
        public void SetDesktopLocation(int x, int y) { base.Location = new Point(x, y); }
        /// <summary>
        /// Calling this method will add the form for processing. Once a form has been shown, you should call <see cref="Close"/> to dispose of resources properly.
        /// </summary>
        /// <remarks>
        /// Due to the non-blocking nature of this method, once a form is shown the variable for it can go out of scope. This means that it will not be possible to close the form manually. It will also not be possible to make any changes to the form as well. The form will also not be disposed of, until it is closed by the user clicking the Close button, if one is made available.
        /// 
        /// If you do not need to add controls, programmatically change anything on the form, or programmatically operate on it, then it is not necessary to hold on to the variable. You may still subscribe to events and will be informed when an event is triggered.
        /// </remarks>
        public void Show() { if (_Forms.Contains(this)) { throw new InvalidOperationException("The Form.Show() method has already been called on this Form."); } _Forms.Add(this); base.Show(); Enabled = true; Visible = true; }
        #endregion

        #region Events
        public event EventHandler Activated;

        [BrowsableAttribute(false)]
        public event EventHandler Closed;

        [BrowsableAttribute(false)]
        public event CancelEventHandler Closing;

        public event EventHandler Deactivate;
        public event FormClosedEventHandler FormClosed;
        public event FormClosingEventHandler FormClosing;
        public event EventHandler Load;
        public event EventHandler MaximizedBoundsChanged;
        public event EventHandler MaximumSizeChanged;
        public event EventHandler MinimumSizeChanged;
        public event EventHandler ResizeBegin;
        public event EventHandler ResizeEnd;
        public event EventHandler Shown;
        #endregion
    }
}
