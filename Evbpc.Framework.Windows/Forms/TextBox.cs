using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    [ComVisibleAttribute(true)]
    public class TextBox : TextBoxBase
    {
        public TextBox()
        {
            KeyPress += TextBox_KeyPress;
        }

        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.ContainsFocus)
            if (this.Parent.Focused)
                if (e.KeyChar < 32 || e.KeyChar >= 127)
                    if (e.KeyChar == (char)Keys.Back)
                        if (this.Text.Length > 0)
                            this.Text = this.Text.Substring(0, this.Text.Length - 1);
                        else
                            this.Text = "";
                    else
                        this.Text = this.Text;
                else
                    this.Text += e.KeyChar;
        }
    }
}
