using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Windows.Forms
{
    public class MouseEventArgs : EventArgs
    {
        #region Constructors
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
        {
            Button = button;
            Clicks = clicks;
            Location = new Point(x, y);
            Delta = delta;
        }
        #endregion

        #region Properties
        public MouseButtons Button { get; }
        public int Clicks { get; }
        public int Delta { get; }
        public Point Location { get; }
        public int X => Location.X;
        public int Y => Location.Y;
        #endregion
    }
}
