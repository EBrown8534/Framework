using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    /// <summary>
    /// Provides the functionality for a control to act as a parent for other controls.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/system.windows.forms.icontainercontrol(v=vs.110).aspx
    /// </remarks>
    public interface IContainerControl
    {
        /// <summary>
        /// Gets or sets the control that is active on the container control.
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.icontainercontrol.activecontrol(v=vs.110).aspx
        /// </remarks>
        Control ActiveControl { get; set; }

        /// <summary>
        /// Activates a specified control.
        /// </summary>
        /// <param name="active">The <see cref="Control"/> being activated.</param>
        /// <returns>True if the <see cref="Control"/> is successfully activated, otherwise false.</returns>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/library/system.windows.forms.icontainercontrol.activatecontrol(v=vs.110).aspx
        /// </remarks>
        bool ActivateControl(Control active);
    }
}
