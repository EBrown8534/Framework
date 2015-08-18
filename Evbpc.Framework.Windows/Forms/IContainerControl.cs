using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public interface IContainerControl
    {
        Control ActiveControl { get; set; }

        bool ActivateControl(Control active);
    }
}
