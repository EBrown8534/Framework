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
    /// Represents a <see cref="Evbpc.Framework.Windows.Forms.Form"/> that can be drawn with an XNA <code>SpriteBatch</code>.
    /// </summary>
    public class Form : Evbpc.Framework.Windows.Forms.Form
    {
        private Texture2D _backgroundTexture;
        private Texture2D _titleTexture;
        private static MouseState _mouseStatePrevious;
        private bool _showTitleBar;
        private int _titleBarHeight;
        private EFD.Color _titleBarColor;
        private TimeSpan _clickTrigger = new TimeSpan(0, 0, 0, 0, 500);
        private DateTime _clickStart;
        private bool _allowDrag;
        private EFD.Point _dragMouseStart;
        private EFD.Point _dragPosStart;
        private bool _inDrag;
        //private EFD.Size _WindowSize;

        public static KeyboardStateManager KeyStateMan { get; set; }

        /// <summary>
        /// The Texture2D to use as the background of the form. If the <see cref="Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D BackgroundTexture { get { return _backgroundTexture; } set { _backgroundTexture = value; } }
        /// <summary>
        /// The Texture2D to use as the background for the <see cref="Title"/> of the form. If the <see cref="Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D TitleTexture { get { return _titleTexture; } set { _titleTexture = value; } }
        /// <summary>
        /// Determines whether or not the <see cref="Title"/> will be rendered. If this is false, the entire title will not be rendered, and the content will be moved up if the <see cref="TitleBarHeight"/> is not 0.
        /// </summary>
        public bool ShowTitleBar { get { return _showTitleBar; } set { _showTitleBar = value; } }
        /// <summary>
        /// Determines the height of the <see cref="Title"/> when <see cref="ShowTitleBar"/> is not false.
        /// </summary>
        public int TitleBarHeight { get { return _titleBarHeight; } set { _titleBarHeight = value; } }
        /// <summary>
        /// Determines the <see cref="Evbpc.Framework.Drawing.Color"/> the <see cref="TitleTexture"/> will be rendered as.
        /// </summary>
        public EFD.Color TitleBarColor { get { return _titleBarColor; } set { _titleBarColor = value; } }
        /// <summary>
        /// Determines of the <see cref="Form"/> can be moved.
        /// </summary>
        public bool AllowDrag { get { return _allowDrag; } set { _allowDrag = value; } }
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
                if (_showTitleBar)
                {
                    s.Draw(_titleTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, _titleBarHeight), TitleBarColor.ToXnaColor());
                    s.Draw(_backgroundTexture, new XnaF.Rectangle(Location.X, Location.Y + _titleBarHeight, Size.Width, Size.Height - _titleBarHeight), BackColor.ToXnaColor());
                }
                else
                {
                    s.Draw(_backgroundTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, Size.Height), BackColor.ToXnaColor());
                }

                foreach (Control c in Controls)
                {
                    if (c is IDrawableControl)
                    {
                        if (_showTitleBar)
                            ((IDrawableControl)c).Draw(s, new EFD.Point(Location.X, Location.Y + _titleBarHeight));
                        else
                            ((IDrawableControl)c).Draw(s, Location);
                    }
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
            if ((m.LeftButton == ButtonState.Pressed && _mouseStatePrevious.LeftButton == ButtonState.Released) || (m.RightButton == ButtonState.Pressed && _mouseStatePrevious.RightButton == ButtonState.Released) || (m.MiddleButton == ButtonState.Pressed && _mouseStatePrevious.MiddleButton == ButtonState.Released))
            {
                int f = GetActiveForm(new Point(m.X, m.Y));

                if (f > 0 || (f > -1 && _ActiveForm == null))
                {
                    _Forms[f].Activate();
                }
                else if (f < 0)
                {
                    _ActiveForm = null;
                }
            }

            if (_ActiveForm != null)
            {
                ((Form)_ActiveForm).Update(m, hasFocus, gt);
            }

            for (int i = 0; i < _Forms.Count; i++)
            {
                ((Form)_Forms[i]).Update(m, false, gt);
            }

            _mouseStatePrevious = m;
        }

        /// <summary>
        /// This call must be made in order for any forms to be displayed.
        /// </summary>
        /// <param name="s">The SpriteBatch to do the drawing.</param>
        public static void DrawAll(SpriteBatch s)
        {
            foreach (Form form in _Forms)
                form.Draw(s);

            //for (int i = _Forms.Count - 1; i >= 0; i--)
            //{
            //    ((Form)_Forms[i]).Draw(s);
            //}
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

                    if (m.LeftButton == ButtonState.Released && _mouseStatePrevious.LeftButton == ButtonState.Pressed)
                    {
                        if (DateTime.UtcNow - _clickStart <= _clickTrigger)
                            OnClick(new EventArgs());

                        _inDrag = false;

                        OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, m.X, m.Y, m.ScrollWheelValue - _mouseStatePrevious.ScrollWheelValue));
                    }
                    else if (m.LeftButton == ButtonState.Pressed && _mouseStatePrevious.LeftButton == ButtonState.Released)
                    {
                        _clickStart = DateTime.UtcNow;

                        if (_showTitleBar)
                        {
                            if (m.X >= this.Bounds.Left && m.X < this.Bounds.Right && m.Y >= this.Location.Y && m.Y < this.Location.Y + this.TitleBarHeight)
                            {
                                _dragMouseStart = new EFD.Point(m.X, m.Y);
                                _dragPosStart = this.Location;
                                _inDrag = true;
                            }
                        }

                        OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, m.X, m.Y, m.ScrollWheelValue - _mouseStatePrevious.ScrollWheelValue));
                    }
                }

                if (m.LeftButton == ButtonState.Pressed)
                {
                    if (_allowDrag && _inDrag && _showTitleBar)
                    {
                        this.Location = _dragPosStart + new Evbpc.Framework.Drawing.Size(m.X - _dragMouseStart.X, m.Y - _dragMouseStart.Y);
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
                if (p.X >= _Forms[i].Bounds.Left
                    && p.X < _Forms[i].Bounds.Right
                    && p.Y >= _Forms[i].Bounds.Top
                    && p.Y < _Forms[i].Bounds.Bottom
                    && _Forms[i].Visible
                    && _Forms[i].Enabled)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
