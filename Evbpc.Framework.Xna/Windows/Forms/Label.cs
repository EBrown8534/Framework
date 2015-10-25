using Evbpc.Framework.Drawing;
using Evbpc.Framework.Xna.Drawing.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    public class Label : Evbpc.Framework.Windows.Forms.Label, IDrawableControl
    {
        public SpriteFont Font { get; }

        public Label(SpriteFont font, string name)
        {
            Font = font;
            Name = name;
        }

        public Label(SpriteFont font, string name, string text)
            : this(font, name)
        {
            Text = text;
        }

        void IDrawableControl.Draw(SpriteBatch s, Evbpc.Framework.Drawing.Point initialLocation)
        {
            s.DrawString(Font, Text, new Vector2(initialLocation.X + this.Location.X, initialLocation.Y + this.Location.Y), ForeColor.ToXnaColor());
        }
    }
}
