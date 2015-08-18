using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class FormClosedEventArgs : EventArgs
    {
        private CloseReason _CloseReason;

        #region Constructors
        public FormClosedEventArgs(CloseReason closeReason) { _CloseReason = closeReason; }
        #endregion

        #region Properties
        public CloseReason CloseReason { get { return _CloseReason; } }
        #endregion
    }
}
