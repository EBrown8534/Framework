using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class MouseEventArgs : EventArgs
    {
        private MouseButtons _Button;
        private int _Clicks;
        private Point _Location;
        private int _Delta;

        #region Constructors
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta) { _Button = button; _Clicks = clicks; _Location = new Point(x, y); _Delta = delta; }
        #endregion

        #region Properties
        public MouseButtons Button { get { return _Button; } }
        public int Clicks { get { return _Clicks; } }
        public int Delta { get { return _Delta; } }
        public Point Location { get { return _Location; } }
        public int X { get { return _Location.X; } }
        public int Y { get { return _Location.Y; } }
        #endregion
    }
}
