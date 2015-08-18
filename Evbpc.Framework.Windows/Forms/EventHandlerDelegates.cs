using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public delegate void ControlEventHandler(Object sender, ControlEventArgs e);
    public delegate void KeyEventHandler(Object sender, KeyEventArgs e);
    public delegate void KeyPressEventHandler(Object sender, KeyPressEventArgs e);
    public delegate void MouseEventHandler(Object sender, MouseEventArgs e);
    public delegate void FormClosedEventHandler(Object sender, FormClosedEventArgs e);
    public delegate void FormClosingEventHandler(Object sender, FormClosingEventArgs e);
    public delegate void ScrollEventHandler(Object sender, ScrollEventArgs e);
}
