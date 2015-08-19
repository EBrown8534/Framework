using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class MouseEventArgs : EventArgs
    {
        private MouseButtons _button;
        private int _clicks;
        private Point _location;
        private int _delta;

        #region Constructors
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta) { _button = button; _clicks = clicks; _location = new Point(x, y); _delta = delta; }
        #endregion

        #region Properties
        public MouseButtons Button { get { return _button; } }
        public int Clicks { get { return _clicks; } }
        public int Delta { get { return _delta; } }
        public Point Location { get { return _location; } }
        public int X { get { return _location.X; } }
        public int Y { get { return _location.Y; } }
        #endregion
    }
}
