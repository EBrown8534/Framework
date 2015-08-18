using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XnaF = Microsoft.Xna.Framework;
using EFD = Evbpc.Framework.Drawing;
using Evbpc.Framework.Windows.Forms;
using Evbpc.Framework.Xna.Drawing.Extensions;
using Evbpc.Framework.Xna.Utilities;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    /// <summary>
    /// Represents a form that can be drawn with an XNA SpriteBatch.
    /// </summary>
    public class Form : Evbpc.Framework.Windows.Forms.Form
    {
        private Texture2D _BackgroundTexture;
        private Texture2D _TitleTexture;
        private static MouseState _mPrev;
        public static KeyboardStateManager KeyStateMan { get; set; }
        private bool _ShowTitleBar;
        private int _TitleBarHeight;
        private EFD.Color _TitleBarColor;
        private TimeSpan _ClickTrigger = new TimeSpan(0, 0, 0, 0, 500);
        private DateTime _ClickStart;
        private bool _AllowDrag;
        private EFD.Point _DragMouseStart;
        private EFD.Point _DragPosStart;
        private bool _InDrag;
        //private EFD.Size _WindowSize;

        /// <summary>
        /// The Texture2D to use as the background of the form. If the <see cref="Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D BackgroundTexture { get { return _BackgroundTexture; } set { _BackgroundTexture = value; } }
        /// <summary>
        /// The Texture2D to use as the background for the <see cref="Title"/> of the form. If the <see cref="Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D TitleTexture { get { return _TitleTexture; } set { _TitleTexture = value; } }
        /// <summary>
        /// Determines whether or not the <see cref="Title"/> will be rendered. If this is false, the entire title will not be rendered, and the content will be moved up if the <see cref="TitleBarHeight"/> is not 0.
        /// </summary>
        public bool ShowTitleBar { get { return _ShowTitleBar; } set { _ShowTitleBar = value; } }
        /// <summary>
        /// Determines the height of the <see cref="Title"/> when <see cref="ShowTitleBar"/> is not false.
        /// </summary>
        public int TitleBarHeight { get { return _TitleBarHeight; } set { _TitleBarHeight = value; } }
        /// <summary>
        /// Determines the <see cref="Evbpc.Framework.Drawing.Color"/> the <see cref="TitleTexture"/> will be rendered as.
        /// </summary>
        public EFD.Color TitleBarColor { get { return _TitleBarColor; } set { _TitleBarColor = value; } }
        /// <summary>
        /// Determines of the <see cref="Form"/> can be moved.
        /// </summary>
        public bool AllowDrag { get { return _AllowDrag; } set { _AllowDrag = value; } }
        ///// <summary>
        ///// Determines the <see cref="Evbpc.Framework.Drawing.Size"/> of the <see cref="Form"/>.
        ///// </summary>
        //public EFD.Size WindowSize { get { return _WindowSize; } set { _WindowSize = value; } }

        public override bool Focused { get { return _ActiveForm == this; } }

        /// <summary>
        /// Creates a new instance of the <see cref="Form"/> class.
        /// </summary>
        public Form(string name)
        {
            Name = name;
            KeyStateMan.KeyDown += KeyStateMan_KeyDown;
            KeyStateMan.KeyPress += KeyStateMan_KeyPress;
            KeyStateMan.KeyUp += KeyStateMan_KeyUp;
        }

        void KeyStateMan_KeyUp(object sender, KeyEventArgs e) { OnKeyUp(e); }

        void KeyStateMan_KeyPress(object sender, KeyPressEventArgs e) { OnKeyPress(e); }

        void KeyStateMan_KeyDown(object sender, KeyEventArgs e) { OnKeyDown(e); }

        private void Draw(SpriteBatch s)
        {
            if (Visible && Enabled)
            {
                if (_ShowTitleBar)
                {
                    s.Draw(_TitleTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, _TitleBarHeight), TitleBarColor.ToXnaColor());
                    s.Draw(_BackgroundTexture, new XnaF.Rectangle(Location.X, Location.Y + _TitleBarHeight, Size.Width, Size.Height - _TitleBarHeight), BackColor.ToXnaColor());
                }
                else
                {
                    s.Draw(_BackgroundTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, Size.Height), BackColor.ToXnaColor());
                }

                foreach (Control c in Controls)
                {
                    if (c is IDrawableControl)
                        if (_ShowTitleBar)
                            ((IDrawableControl)c).Draw(s, new EFD.Point(Location.X, Location.Y + _TitleBarHeight));
                        else
                            ((IDrawableControl)c).Draw(s, Location);
                }
            }
        }

        /// <summary>
        /// This should update anything that requires mouse, keyboard, gamepad, joystick, or other input controls. (Dragging, etc.)
        /// </summary>
        /// <param name="m">The current MouseState object.</param>
        /// <param name="k">The current KeyboardState object.</param>
        /// <param name="hasFocus">A value indicating whether or not the application has focus.</param>
        public static void UpdateAll(MouseState m, bool hasFocus, GameTime gt)
        {
            if ((m.LeftButton == ButtonState.Pressed && _mPrev.LeftButton == ButtonState.Released) || (m.RightButton == ButtonState.Pressed && _mPrev.RightButton == ButtonState.Released) || (m.MiddleButton == ButtonState.Pressed && _mPrev.MiddleButton == ButtonState.Released))
            {
                int f = GetActiveForm(new Point(m.X, m.Y));

                if (f > 0 || (f > -1 && _ActiveForm == null))
                {
                    _Forms[f].Activate();
                }
                else if (f < 0)
                    _ActiveForm = null;
            }

            if (_ActiveForm != null)
            {
                ((Form)_ActiveForm).Update(m, hasFocus, gt);
            }

            for (int i = 0; i < _Forms.Count; i++)
            {
                ((Form)_Forms[i]).Update(m, false, gt);
            }

            _mPrev = m;
        }

        /// <summary>
        /// This call must be made in order for any forms to be displayed.
        /// </summary>
        /// <param name="s">The SpriteBatch to do the drawing.</param>
        public static void DrawAll(SpriteBatch s)
        {
            for (int i = _Forms.Count - 1; i >= 0; i--)
            {
                ((Form)_Forms[i]).Draw(s);
            }
        }

        internal void Update(MouseState m, bool hasFocus, GameTime gt)
        {
            // We should only process things that require input if the game is focused, the form is visible, and the form is enabled.
            if (Enabled && Visible && hasFocus)
            {
                if (m.X >= this.Bounds.Left && m.X < this.Bounds.Right && m.Y >= this.Bounds.Top && m.Y < this.Bounds.Bottom)
                {
                    if (m.LeftButton == ButtonState.Pressed && m.RightButton == ButtonState.Pressed)
                    {
                        Select();
                    }

                    if (m.LeftButton == ButtonState.Released && _mPrev.LeftButton == ButtonState.Pressed)
                    {
                        if (DateTime.Now - _ClickStart <= _ClickTrigger)
                            OnClick(new EventArgs());

                        _InDrag = false;

                        OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, m.X, m.Y, m.ScrollWheelValue - _mPrev.ScrollWheelValue));
                    }
                    else if (m.LeftButton == ButtonState.Pressed && _mPrev.LeftButton == ButtonState.Released)
                    {
                        _ClickStart = DateTime.Now;

                        if (_ShowTitleBar)
                            if (m.X >= this.Bounds.Left && m.X < this.Bounds.Right && m.Y >= this.Location.Y && m.Y < this.Location.Y + this.TitleBarHeight)
                            {
                                _DragMouseStart = new EFD.Point(m.X, m.Y);
                                _DragPosStart = this.Location;
                                _InDrag = true;
                            }

                        OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, m.X, m.Y, m.ScrollWheelValue - _mPrev.ScrollWheelValue));
                    }
                }

                if (m.LeftButton == ButtonState.Pressed)
                {
                    if (_AllowDrag && _InDrag && _ShowTitleBar)
                    {
                        this.Location = _DragPosStart + new Evbpc.Framework.Drawing.Size(m.X - _DragMouseStart.X, m.Y - _DragMouseStart.Y);
                    }
                }

                for (int i = 0; i < Controls.Count; i++)
                    if (Controls[i] is IUpdateableControl)
                        ((IUpdateableControl)Controls[i]).Update(m, Controls[i] == ActiveControl, gt);
            }
            else if (Enabled && Visible)
            {
                // Down here we can do any updating that doesn't require input. The form must be both Enabled and Visible for us to do anything.
            }
        }

        private static int GetActiveForm(Point p)
        {
            for (int i = 0; i < _Forms.Count; i++)
            {
                if (p.X >= _Forms[i].Bounds.Left && p.X < _Forms[i].Bounds.Right && p.Y >= _Forms[i].Bounds.Top && p.Y < _Forms[i].Bounds.Bottom && _Forms[i].Visible && _Forms[i].Enabled)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
