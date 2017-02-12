using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Point = Evbpc.Framework.Drawing.Point;
using Microsoft.Xna.Framework;
using Evbpc.Framework.Xna.Drawing.Extensions;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    public class PasswordBox : TextBox, IDrawableControl
    {
        public char PasswordChar { get; set; } = '*';

        public PasswordBox(SpriteFont font, string name, Texture2D texture)
            : base(font, name, texture)
        {
        }

        void IDrawableControl.Draw(SpriteBatch s, Point initialLocation)
        {
            var drawText = new string(PasswordChar, Text.Length);
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
    }
}
