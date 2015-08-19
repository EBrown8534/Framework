using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    public class TrackableObjectChangedEventArgs : EventArgs
    {
        private PointF _newPosition;
        private PointF _oldPosition;
        private SizeF _newSize;
        private SizeF _oldSize;

        public PointF NewPosition { get { return _newPosition; } }
        public PointF OldPosition { get { return _oldPosition; } }
        public SizeF NewSize { get { return _newSize; } }
        public SizeF OldSize { get { return _oldSize; } }

        public TrackableObjectChangedEventArgs(PointF newPosition, PointF oldPosition, SizeF newSize, SizeF oldSize) { _newPosition = newPosition; _oldPosition = oldPosition; _newSize = newSize; _oldSize = oldSize; }
    }
}
