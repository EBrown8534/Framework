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
    /// Represents a <see cref="Framework.Windows.Forms.Form"/> that can be drawn with an XNA <code>SpriteBatch</code>.
    /// </summary>
    public class Form : Framework.Windows.Forms.Form
    {
        private static MouseState _mouseStatePrevious;
        private TimeSpan _clickTrigger = new TimeSpan(0, 0, 0, 0, 500);
        private DateTime _clickStart;
        private EFD.Point _dragMouseStart;
        private EFD.Point _dragPosStart;
        private bool _inDrag;
        //private EFD.Size _WindowSize;

        /// <summary>
        /// Gets or sets the <see cref="Utilities.KeyboardStateManager"/> used by all instances of the <see cref="Form"/> class.
        /// </summary>
        public static KeyboardStateManager KeyboardStateManager { get; set; }

        /// <summary>
        /// The Texture2D to use as the background of the form. If the <see cref="Control.Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D BackgroundTexture { get; set; }
        /// <summary>
        /// The Texture2D to use as the background for the title of the form. If the <see cref="Control.Size"/> does not match the Texture2D size, clipping or resizing may occur.
        /// </summary>
        public Texture2D TitleTexture { get; set; }
        /// <summary>
        /// Determines whether or not the title will be rendered. If this is false, the entire title will not be rendered, and the content will be moved up if the <see cref="TitleBarHeight"/> is not 0.
        /// </summary>
        public bool ShowTitleBar { get; set; }
        /// <summary>
        /// Determines the height of the title when <see cref="ShowTitleBar"/> is not false.
        /// </summary>
        public int TitleBarHeight { get; set; }
        /// <summary>
        /// Determines the <see cref="Color"/> the <see cref="TitleTexture"/> will be rendered as.
        /// </summary>
        public EFD.Color TitleBarColor { get; set; }
        /// <summary>
        /// Determines of the <see cref="Form"/> can be moved.
        /// </summary>
        public bool AllowDrag { get; set; }
        ///// <summary>
        ///// Determines the <see cref="Evbpc.Framework.Drawing.Size"/> of the <see cref="Form"/>.
        ///// </summary>
        //public EFD.Size WindowSize { get { return _WindowSize; } set { _WindowSize = value; } }

        /// <summary>
        /// Gets a value indicating whether or not this <see cref="Form"/> has focus.
        /// </summary>
        public override bool Focused => ActiveForm == this;

        /// <summary>
        /// Creates a new instance of the <see cref="Form"/> class.
        /// </summary>
        public Form(string name)
        {
            Name = name;
            KeyboardStateManager.KeyDown += KeyStateMan_KeyDown;
            KeyboardStateManager.KeyPress += KeyStateMan_KeyPress;
            KeyboardStateManager.KeyUp += KeyStateMan_KeyUp;
        }

        void KeyStateMan_KeyUp(object sender, KeyEventArgs e) { OnKeyUp(e); }

        void KeyStateMan_KeyPress(object sender, KeyPressEventArgs e) { OnKeyPress(e); }

        void KeyStateMan_KeyDown(object sender, KeyEventArgs e) { OnKeyDown(e); }

        private void Draw(SpriteBatch s)
        {
            if (Visible && Enabled)
            {
                if (ShowTitleBar)
                {
                    s.Draw(TitleTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, TitleBarHeight), TitleBarColor.ToXnaColor());
                    s.Draw(BackgroundTexture, new XnaF.Rectangle(Location.X, Location.Y + TitleBarHeight, Size.Width, Size.Height - TitleBarHeight), BackColor.ToXnaColor());
                }
                else
                {
                    s.Draw(BackgroundTexture, new XnaF.Rectangle(Location.X, Location.Y, Size.Width, Size.Height), BackColor.ToXnaColor());
                }

                foreach (Control c in Controls)
                {
                    if (c is IDrawableControl)
                    {
                        if (ShowTitleBar)
                            ((IDrawableControl)c).Draw(s, new EFD.Point(Location.X, Location.Y + TitleBarHeight));
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
        /// <param name="gt">A value representing the elapsed <code>GameTime</code> since the last update.</param>
        /// <param name="hasFocus">A value indicating whether or not the application has focus.</param>
        public static void UpdateAll(MouseState m, GameTime gt, bool hasFocus)
        {
            if ((m.LeftButton == ButtonState.Pressed && _mouseStatePrevious.LeftButton == ButtonState.Released)
                || (m.RightButton == ButtonState.Pressed && _mouseStatePrevious.RightButton == ButtonState.Released)
                || (m.MiddleButton == ButtonState.Pressed && _mouseStatePrevious.MiddleButton == ButtonState.Released))
            {
                int f = GetActiveForm(new Point(m.X, m.Y));

                if (f > 0 || (f > -1 && ActiveForm == null))
                {
                    Forms[f].Activate();
                }
                else if (f < 0)
                {
                    ActiveForm = null;
                }
            }

            if (ActiveForm != null)
            {
                ((Form)ActiveForm).Update(m, hasFocus, gt);
            }

            for (int i = 0; i < Forms.Count; i++)
            {
                ((Form)Forms[i]).Update(m, false, gt);
            }

            _mouseStatePrevious = m;
        }

        /// <summary>
        /// This call must be made in order for any forms to be displayed.
        /// </summary>
        /// <param name="s">The SpriteBatch to do the drawing.</param>
        public static void DrawAll(SpriteBatch s)
        {
            foreach (Form form in Forms)
            {
                form.Draw(s);
            }

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
                if (m.X >= this.Bounds.Left
                    && m.X < this.Bounds.Right
                    && m.Y >= this.Bounds.Top
                    && m.Y < this.Bounds.Bottom)
                {
                    if (m.LeftButton == ButtonState.Pressed
                        && m.RightButton == ButtonState.Pressed)
                    {
                        Select();
                    }

                    if (m.LeftButton == ButtonState.Released
                        && _mouseStatePrevious.LeftButton == ButtonState.Pressed)
                    {
                        if (DateTime.UtcNow - _clickStart <= _clickTrigger)
                            OnClick(new EventArgs());

                        _inDrag = false;

                        OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, m.X, m.Y, m.ScrollWheelValue - _mouseStatePrevious.ScrollWheelValue));
                    }
                    else if (m.LeftButton == ButtonState.Pressed
                        && _mouseStatePrevious.LeftButton == ButtonState.Released)
                    {
                        _clickStart = DateTime.UtcNow;

                        if (ShowTitleBar)
                        {
                            if (m.X >= this.Bounds.Left
                                && m.X < this.Bounds.Right
                                && m.Y >= this.Location.Y
                                && m.Y < this.Location.Y + this.TitleBarHeight)
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
                    if (AllowDrag && _inDrag && ShowTitleBar)
                    {
                        this.Location = _dragPosStart + new Evbpc.Framework.Drawing.Size(m.X - _dragMouseStart.X, m.Y - _dragMouseStart.Y);
                    }
                }

                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is IUpdateableControl)
                        ((IUpdateableControl)Controls[i]).Update(m, Controls[i] == ActiveControl, gt);
                }
            }
            else if (Enabled && Visible)
            {
                // Down here we can do any updating that doesn't require input. The form must be both Enabled and Visible for us to do anything.
            }
        }

        private static int GetActiveForm(Point p)
        {
            for (int i = 0; i < Forms.Count; i++)
            {
                if (p.X >= Forms[i].Bounds.Left
                    && p.X < Forms[i].Bounds.Right
                    && p.Y >= Forms[i].Bounds.Top
                    && p.Y < Forms[i].Bounds.Bottom
                    && Forms[i].Visible
                    && Forms[i].Enabled)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
