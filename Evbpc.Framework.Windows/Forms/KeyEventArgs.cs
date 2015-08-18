using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class KeyEventArgs : EventArgs
    {
        private Keys _KeyData;
        private bool _Handled;
        private bool _SuppressKeyPress;
        private bool _Shift;

        #region Constructors
        public KeyEventArgs(Keys keyData) { _Shift = false; _KeyData = keyData; if ((_KeyData & Keys.Shift) == Keys.Shift) { _KeyData = _KeyData ^ Keys.Shift; _Shift = true; } }
        #endregion

        #region Properties
        public virtual bool Alt { get { return (_KeyData & Keys.Alt) == Keys.Alt; } }
        public bool Control { get { return (_KeyData & Keys.Control) == Keys.Control; } }
        public bool Handled { get { return _Handled; } set { _Handled = value; } }
        public Keys KeyCode { get { return _KeyData; } }
        public Keys KeyData { get { return _KeyData; } }
        public int KeyValue { get { return (int)_KeyData; } }
        public Keys Modifiers { get { return _KeyData & Keys.Modifiers; } }
        public virtual bool Shift { get { return _Shift; } }
        public bool SuppressKeyPress { get { return _SuppressKeyPress; } set { _SuppressKeyPress = value; } }
        #endregion
    }
}
