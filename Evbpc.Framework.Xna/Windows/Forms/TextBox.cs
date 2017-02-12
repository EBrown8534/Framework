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
using Point = Evbpc.Framework.Drawing.Point;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    /// <summary>
    /// Represents a <see cref="Framework.Windows.Forms.TextBox"/> to be used with a <see cref="Form"/>.
    /// </summary>
    public class TextBox : Framework.Windows.Forms.TextBox, IDrawableControl, IUpdateableControl
    {
        /// <summary>
        /// The <code>SpriteFont</code> the <see cref="TextBox"/> should be drawn with.
        /// </summary>
        public SpriteFont Font { get; }

        public Texture2D Texture { get; }

        /// <summary>
        /// Constructs a new <see cref="TextBox"/> with the specified <see cref="Control.Name"/>.
        /// </summary>
        /// <param name="font">The <see cref="Font"/>.</param>
        /// <param name="name">The <see cref="Control.Name"/>.</param>
        /// <param name="texture">The <see cref="Texture2D"/> for background and borders.</param>
        public TextBox(SpriteFont font, string name, Texture2D texture)
        {
            Font = font;
            Name = name;
            Texture = texture;
            Form.KeyboardStateManager.KeyDown += KeyStateMan_KeyDown;
            Form.KeyboardStateManager.KeyPress += KeyStateMan_KeyPress;
            Form.KeyboardStateManager.KeyUp += KeyStateMan_KeyUp;
        }

        void KeyStateMan_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        void KeyStateMan_KeyPress(object sender, KeyPressEventArgs e)
        { 
            OnKeyPress(e);
        }

        void KeyStateMan_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        void IDrawableControl.Draw(SpriteBatch s, Point initialLocation)
        {
            var drawText = Text;
            if (ContainsFocus)
            {
                if (DateTime.UtcNow.Millisecond / 500 == 0)
                {
                    drawText += "|";
                }
            }

            s.Draw(Texture, new Rectangle(Location.X + initialLocation.X, Location.Y + initialLocation.Y, Size.Width, Size.Height), BackColor.ToXnaColor());
            s.DrawString(Font, drawText, new Vector2(initialLocation.X + Location.X, initialLocation.Y + Location.Y), ForeColor.ToXnaColor());
        }

        void IUpdateableControl.Update(bool hasFocus, GameTime gt)
        {

        }
    }
}
