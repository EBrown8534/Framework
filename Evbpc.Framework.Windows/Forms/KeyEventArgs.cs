using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class KeyEventArgs : EventArgs
    {
        private Keys _keyData;
        private bool _handled;
        private bool _suppressKeyPress;
        private bool _shift;

        #region Constructors
        public KeyEventArgs(Keys keyData) { _shift = false; _keyData = keyData; if ((_keyData & Keys.Shift) == Keys.Shift) { _keyData = _keyData ^ Keys.Shift; _shift = true; } }
        #endregion

        #region Properties
        public virtual bool Alt { get { return (_keyData & Keys.Alt) == Keys.Alt; } }
        public bool Control { get { return (_keyData & Keys.Control) == Keys.Control; } }
        public bool Handled { get { return _handled; } set { _handled = value; } }
        public Keys KeyCode { get { return _keyData; } }
        public Keys KeyData { get { return _keyData; } }
        public int KeyValue { get { return (int)_keyData; } }
        public Keys Modifiers { get { return _keyData & Keys.Modifiers; } }
        public virtual bool Shift { get { return _shift; } }
        public bool SuppressKeyPress { get { return _suppressKeyPress; } set { _suppressKeyPress = value; } }
        #endregion
    }
}
