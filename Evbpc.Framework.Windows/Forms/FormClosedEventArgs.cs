using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class FormClosedEventArgs : EventArgs
    {
        #region Constructors
        public FormClosedEventArgs(CloseReason closeReason)
        {
            CloseReason = closeReason;
        }
        #endregion

        #region Properties
        public CloseReason CloseReason { get; }
        #endregion
    }
}
