using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    public class TextBox : TextBoxBase
    {
        public TextBox()
        {
            KeyPress += TextBox_KeyPress;
        }

        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.ContainsFocus)
            if (Parent.Focused)
            {
                if (e.KeyChar < 32 || e.KeyChar >= 127)
                {
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        if (Text.Length > 0)
                        {
                            Text = Text.Substring(0, Text.Length - 1);
                        }
                        else
                        {
                            Text = "";
                        }
                    }
                    else
                    {
                        Text = Text;
                    }
                }
                else
                {
                    Text += e.KeyChar;
                }
            }
        }
    }
}
