using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Point = Evbpc.Framework.Drawing.Point;
using Evbpc.Framework.Xna.Drawing.Extensions;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    public class Button : Framework.Windows.Forms.Button, IDrawableControl, IUpdateableControl
    {
        /// <summary>
        /// The <code>SpriteFont</code> the <see cref="Button"/> should be drawn with.
        /// </summary>
        public SpriteFont Font { get; }

        public Texture2D Texture { get; }

        /// <summary>
        /// Constructs a new <see cref="Button"/> with the specified <see cref="Control.Name"/>.
        /// </summary>
        /// <param name="font">The <see cref="Font"/>.</param>
        /// <param name="name">The <see cref="Control.Name"/>.</param>
        /// <param name="texture">The <see cref="Texture2D"/> for background and borders.</param>
        public Button(SpriteFont font, string name, Texture2D texture)
        {
            Font = font;
            Name = name;
            Texture = texture;
        }

        public void Draw(SpriteBatch s, Point initialLocation)
        {
            s.Draw(Texture, new Rectangle(Location.X + initialLocation.X, Location.Y + initialLocation.Y, Size.Width, Size.Height), BackColor.ToXnaColor());
            s.DrawString(Font, Text, new Vector2(initialLocation.X + Location.X, initialLocation.Y + Location.Y), ForeColor.ToXnaColor());
        }

        public void Update(bool hasFocus, GameTime gt)
        {

        }
    }
}
