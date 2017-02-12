using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Point = Evbpc.Framework.Drawing.Point;

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
            base.Draw(s, initialLocation, new string('*', Text.Length));
        }
    }
}
