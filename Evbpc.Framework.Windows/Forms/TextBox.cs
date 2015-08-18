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
            KeyUp += TextBox_KeyUp;
            KeyDown += TextBox_KeyDown;
            KeyPress += TextBox_KeyPress;
        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Back && this.Text.Length > 0)
            //    this.Text = this.Text.Substring(0, this.Text.Length - 1);
            //else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            //    if (e.Shift)
            //        this.Text += e.KeyCode.ToString();
            //    else
            //        this.Text += e.KeyCode.ToString().ToLower();
            //else if (e.KeyCode == Keys.Space)
            //    this.Text += " ";
        }

        void TextBox_KeyUp(object sender, KeyEventArgs e)
        {

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
