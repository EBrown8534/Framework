using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class FormClosingEventArgs : CancelEventArgs
    {
        #region Constructors
        public FormClosingEventArgs(CloseReason closeReason, bool cancel)
        {
            CloseReason = closeReason;
            Cancel = cancel;
        }
        #endregion

        #region Properties
        public CloseReason CloseReason { get; }
        #endregion
    }
}
