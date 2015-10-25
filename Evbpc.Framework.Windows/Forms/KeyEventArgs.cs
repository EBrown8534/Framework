using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class KeyEventArgs : EventArgs
    {
        #region Constructors
        public KeyEventArgs(Keys keyData)
        {
            Shift = false;
            KeyData = keyData;

            if ((KeyData & Keys.Shift) == Keys.Shift)
            {
                KeyData = KeyData ^ Keys.Shift;
                Shift = true;
            }
        }
        #endregion

        #region Properties
        public virtual bool Alt => (KeyData & Keys.Alt) == Keys.Alt;
        public bool Control => (KeyData & Keys.Control) == Keys.Control;
        public bool Handled { get; set; }
        public Keys KeyCode => KeyData;
        public Keys KeyData { get; }
        public int KeyValue => (int)KeyData;
        public Keys Modifiers => KeyData & Keys.Modifiers;
        public virtual bool Shift { get; }
        public bool SuppressKeyPress { get; set; }
        #endregion
    }
}
