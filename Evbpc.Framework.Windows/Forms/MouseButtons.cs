using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [FlagsAttribute]
    public enum MouseButtons
    {
        Left = 0x100000,
        Middle = 0x400000,
        None = 0x00,
        Right = 0x200000,
        XButton1 = 0x800000,
        XButton2 = 0x1000000
    }
}
