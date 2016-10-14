using Evbpc.Framework.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Utilities
{
    public class MouseStateManager
    {
        public MouseState MouseStateNow { get; private set; }
        public MouseState MouseStatePrevious { get; private set; }
        public int DoubleClickThresholdMs { get; set; } = 300;

        private DateTime _lastClickAt;
        private MouseButtons _lastClickBy;

        public void Update(MouseState state)
        {
            MouseStatePrevious = MouseStateNow;
            MouseStateNow = state;

            var buttonsWentDown = ButtonsWentDown();

            if (buttonsWentDown != MouseButtons.None)
            {
                OnMouseDown(new MouseEventArgs(buttonsWentDown, 0, MouseStateNow.X, MouseStateNow.Y, 0));
            }

            var buttonsWentUp = ButtonsWentUp();

            if (buttonsWentUp != MouseButtons.None)
            {
                OnMouseUp(new MouseEventArgs(buttonsWentUp, 0, MouseStateNow.X, MouseStateNow.Y, 0));
                OnMouseClick(new MouseEventArgs(buttonsWentUp, 1, MouseStateNow.X, MouseStateNow.Y, 0));

                if (buttonsWentUp == _lastClickBy
                    && (DateTime.Now - _lastClickAt).TotalMilliseconds <= DoubleClickThresholdMs)
                {
                    OnMouseDoubleClick(new MouseEventArgs(buttonsWentUp, 2, MouseStateNow.X, MouseStateNow.Y, 0));
                }

                _lastClickBy = buttonsWentUp;
                _lastClickAt = DateTime.Now;
            }

            var scrollDelta = MouseStateNow.ScrollWheelValue - MouseStatePrevious.ScrollWheelValue;

            if (scrollDelta > 0 || scrollDelta < 0)
            {
                OnMouseWheel(new MouseEventArgs(MouseButtons.None, 0, MouseStateNow.X, MouseStateNow.Y, scrollDelta));
            }

            var xDelta = MouseStateNow.X - MouseStatePrevious.X;
            var yDelta = MouseStateNow.Y - MouseStatePrevious.Y;

            if (xDelta > 0 || xDelta < 0 || yDelta > 0 || yDelta < 0)
            {
                OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, MouseStateNow.X, MouseStateNow.Y, 0));
            }
        }

        private MouseButtons ButtonsWentUp()
        {
            var buttons = MouseButtons.None;

            if (WentUp(MouseButtons.Left))
            {
                buttons |= MouseButtons.Left;
            }

            if (WentUp(MouseButtons.Middle))
            {
                buttons |= MouseButtons.Middle;
            }

            if (WentUp(MouseButtons.Right))
            {
                buttons |= MouseButtons.Right;
            }

            if (WentUp(MouseButtons.XButton1))
            {
                buttons |= MouseButtons.XButton1;
            }

            if (WentUp(MouseButtons.XButton2))
            {
                buttons |= MouseButtons.XButton2;
            }

            return buttons;
        }

        private MouseButtons ButtonsWentDown()
        {
            var buttons = MouseButtons.None;

            if (WentDown(MouseButtons.Left))
            {
                buttons |= MouseButtons.Left;
            }

            if (WentDown(MouseButtons.Middle))
            {
                buttons |= MouseButtons.Middle;
            }

            if (WentDown(MouseButtons.Right))
            {
                buttons |= MouseButtons.Right;
            }

            if (WentDown(MouseButtons.XButton1))
            {
                buttons |= MouseButtons.XButton1;
            }

            if (WentDown(MouseButtons.XButton2))
            {
                buttons |= MouseButtons.XButton2;
            }

            return buttons;
        }

        public MouseButtons ButtonsUp()
        {
            var buttons = MouseButtons.None;

            if (MouseStateNow.LeftButton == ButtonState.Released)
            {
                buttons |= MouseButtons.Left;
            }

            if (MouseStateNow.MiddleButton == ButtonState.Released)
            {
                buttons |= MouseButtons.Middle;
            }

            if (MouseStateNow.RightButton == ButtonState.Released)
            {
                buttons |= MouseButtons.Right;
            }

            if (MouseStateNow.XButton1 == ButtonState.Released)
            {
                buttons |= MouseButtons.XButton1;
            }

            if (MouseStateNow.XButton2 == ButtonState.Released)
            {
                buttons |= MouseButtons.XButton2;
            }

            return buttons;
        }

        public MouseButtons ButtonsDown()
        {
            var buttons = MouseButtons.None;

            if (MouseStateNow.LeftButton == ButtonState.Pressed)
            {
                buttons |= MouseButtons.Left;
            }

            if (MouseStateNow.MiddleButton == ButtonState.Pressed)
            {
                buttons |= MouseButtons.Middle;
            }

            if (MouseStateNow.RightButton == ButtonState.Pressed)
            {
                buttons |= MouseButtons.Right;
            }

            if (MouseStateNow.XButton1 == ButtonState.Pressed)
            {
                buttons |= MouseButtons.XButton1;
            }

            if (MouseStateNow.XButton2 == ButtonState.Pressed)
            {
                buttons |= MouseButtons.XButton2;
            }

            return buttons;
        }

        public bool WentDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return MouseStatePrevious.LeftButton == ButtonState.Released && MouseStateNow.LeftButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return MouseStatePrevious.MiddleButton == ButtonState.Released && MouseStateNow.MiddleButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return MouseStatePrevious.RightButton == ButtonState.Released && MouseStateNow.RightButton == ButtonState.Pressed;
                case MouseButtons.XButton1:
                    return MouseStatePrevious.XButton1 == ButtonState.Released && MouseStateNow.XButton1 == ButtonState.Pressed;
                case MouseButtons.XButton2:
                    return MouseStatePrevious.XButton2 == ButtonState.Released && MouseStateNow.XButton2 == ButtonState.Pressed;
            }

            return false;
        }

        public bool BeenDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return MouseStatePrevious.LeftButton == ButtonState.Pressed && MouseStateNow.LeftButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return MouseStatePrevious.MiddleButton == ButtonState.Pressed && MouseStateNow.MiddleButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return MouseStatePrevious.RightButton == ButtonState.Pressed && MouseStateNow.RightButton == ButtonState.Pressed;
                case MouseButtons.XButton1:
                    return MouseStatePrevious.XButton1 == ButtonState.Pressed && MouseStateNow.XButton1 == ButtonState.Pressed;
                case MouseButtons.XButton2:
                    return MouseStatePrevious.XButton2 == ButtonState.Pressed && MouseStateNow.XButton2 == ButtonState.Pressed;
            }

            return false;
        }

        public bool WentUp(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return MouseStatePrevious.LeftButton == ButtonState.Pressed && MouseStateNow.LeftButton == ButtonState.Released;
                case MouseButtons.Middle:
                    return MouseStatePrevious.MiddleButton == ButtonState.Pressed && MouseStateNow.MiddleButton == ButtonState.Released;
                case MouseButtons.Right:
                    return MouseStatePrevious.RightButton == ButtonState.Pressed && MouseStateNow.RightButton == ButtonState.Released;
                case MouseButtons.XButton1:
                    return MouseStatePrevious.XButton1 == ButtonState.Pressed && MouseStateNow.XButton1 == ButtonState.Released;
                case MouseButtons.XButton2:
                    return MouseStatePrevious.XButton2 == ButtonState.Pressed && MouseStateNow.XButton2 == ButtonState.Released;
            }

            return false;
        }

        protected virtual void OnMouseClick(MouseEventArgs e)
        {
            var handler = MouseClick;
            handler?.Invoke(this, e);
        }

        protected virtual void OnMouseDoubleClick(MouseEventArgs e)
        {
            var handler = MouseDoubleClick;
            handler?.Invoke(this, e);
        }

        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            var handler = MouseDown;
            handler?.Invoke(this, e);
        }

        protected virtual void OnMouseMove(MouseEventArgs e)
        {
            var handler = MouseMove;
            handler?.Invoke(this, e);
        }

        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            var handler = MouseUp;
            handler?.Invoke(this, e);
        }

        protected virtual void OnMouseWheel(MouseEventArgs e)
        {
            var handler = MouseWheel;
            handler?.Invoke(this, e);
        }

        public event EventHandler<MouseEventArgs> MouseClick;
        public event EventHandler<MouseEventArgs> MouseDoubleClick;
        public event EventHandler<MouseEventArgs> MouseDown;
        public event EventHandler<MouseEventArgs> MouseMove;
        public event EventHandler<MouseEventArgs> MouseUp;
        public event EventHandler<MouseEventArgs> MouseWheel;
    }
}
