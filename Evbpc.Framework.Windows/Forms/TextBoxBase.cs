using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [ComVisibleAttribute(true)]
    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    [DefaultBindingPropertyAttribute("Text")]
    public abstract class TextBoxBase : Control
    {

    }
}
