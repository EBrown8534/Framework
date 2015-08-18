using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class FormClosingEventArgs : CancelEventArgs
    {
        private CloseReason _CloseReason;

        #region Constructors
        public FormClosingEventArgs(CloseReason closeReason, bool cancel) { _CloseReason = closeReason; Cancel = cancel; }
        #endregion

        #region Properties
        public CloseReason CloseReason { get { return _CloseReason; } }
        #endregion
    }
}
