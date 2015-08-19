using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides focus-management functionality for controls that can function as a container for other controls.
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.containercontrol(v=vs.110).aspx
    /// </remarks>
    public class ContainerControl : ScrollableControl, IContainerControl
    { 
        private Control _activeControl;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerControl"/> class.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.containercontrol.containercontrol(v=vs.110).aspx
        /// </remarks>
        public ContainerControl() : base() { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the active control on the container control.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.containercontrol.activecontrol(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Control ActiveControl { get { return _activeControl; } set { if (this.Controls.Contains(value)) { _activeControl = value; } } }

        /// <summary>
        /// Gets the form that the container control is assigned to.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.containercontrol.parentform(v=vs.110).aspx
        /// </remarks>
        [BrowsableAttribute(false)]
        public Form ParentForm { get { return FindForm(); } }
        #endregion

        #region Methods
        /// <summary>
        /// Activates the specified control.
        /// </summary>
        /// <param name="active">The <see cref="Control"/> to activate.</param>
        /// <returns>true if the control is successfully activated; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/bb339151(v=vs.110).aspx
        /// </remarks>
        public bool ActivateControl(Control active) { if (this.Controls.Contains(active)) { active.Select(); this._activeControl = active; return true; } return false; }

        /// <summary>
        /// Selects the next available control and makes it the active control.
        /// </summary>
        /// <param name="forward">true to cycle forward through the controls in the ContainerControl; otherwise, false.</param>
        /// <returns>true if a control is selected; otherwise, false.</returns>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.containercontrol.processtabkey(v=vs.110).aspx
        /// </remarks>
        [UIPermissionAttribute(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool ProcessTabKey(bool forward)
        {
            if (_activeControl != null)
            {
                int tIndex = _activeControl.TabIndex;
            }

            return false;
        }

        /// <summary>
        /// This member overrides <see cref="Control.Select(Boolean, Boolean)"/>, and more complete documentation might be available in that topic.
        /// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
        /// </summary>
        /// <param name="directed">true to specify the direction of the control to select; otherwise, false.</param>
        /// <param name="forward">true to move forward in the tab order; false to move backward in the tab order.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/z62bk4s9(v=vs.110).aspx
        /// </remarks>
        protected override void Select(bool directed, bool forward) { throw new NotImplementedException(); }
        #endregion
    }
}
