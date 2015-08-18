using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    public class PositionChangedEventArgs : EventArgs
    {
        private PointF _NewPosition;
        private PointF _OldPosition;

        public PointF NewPosition { get { return _NewPosition; } }
        public PointF OldPosition { get { return _OldPosition; } }

        public PositionChangedEventArgs(PointF mNewPosition, PointF mOldPosition) { _NewPosition = mNewPosition; _OldPosition = mOldPosition; }
    }
}
