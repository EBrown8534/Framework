using Evbpc.Framework.Windows.Forms;
using Evbpc.Framework.Xna.Drawing.Extensions;
using Evbpc.Framework.Xna.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    public class TextBox : Framework.Windows.Forms.TextBox, IDrawableControl, IUpdateableControl
    {
        private SpriteFont _Font;
        public SpriteFont Font { get { return _Font; } }
        
        public TextBox(SpriteFont font, string name)
        {
            _Font = font;
            Name = name;
            Form.KeyStateMan.KeyDown += KeyStateMan_KeyDown;
            Form.KeyStateMan.KeyPress += KeyStateMan_KeyPress;
            Form.KeyStateMan.KeyUp += KeyStateMan_KeyUp;
        }

        void KeyStateMan_KeyUp(object sender, KeyEventArgs e) { OnKeyUp(e); }

        void KeyStateMan_KeyPress(object sender, KeyPressEventArgs e) { OnKeyPress(e); }

        void KeyStateMan_KeyDown(object sender, KeyEventArgs e) { OnKeyDown(e); }

        public TextBox(SpriteFont font, string name, string text)
            : this(font, name)
        {
            Text = text;
        }

        void IDrawableControl.Draw(SpriteBatch s, Evbpc.Framework.Drawing.Point initialLocation)
        {
            s.DrawString(_Font, Text, new Vector2(initialLocation.X + this.Location.X, initialLocation.Y + this.Location.Y), ForeColor.ToXnaColor());
        }

        void IUpdateableControl.Update(MouseState m, bool hasFocus, GameTime gt)
        {

        }
    }
}
