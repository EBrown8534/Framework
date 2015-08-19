using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    public class TrackableObjectChangedEventArgs : EventArgs
    {
        private PointF _NewPosition;
        private PointF _OldPosition;
        private SizeF _NewSize;
        private SizeF _OldSize;

        public PointF NewPosition { get { return _NewPosition; } }
        public PointF OldPosition { get { return _OldPosition; } }
        public SizeF NewSize { get { return _NewSize; } }
        public SizeF OldSize { get { return _OldSize; } }

        public TrackableObjectChangedEventArgs(PointF newPosition, PointF oldPosition, SizeF newSize, SizeF oldSize) { _NewPosition = newPosition; _OldPosition = oldPosition; _NewSize = newSize; _OldSize = oldSize; }
    }
}
