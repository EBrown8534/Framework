using Evbpc.Framework.Drawing;
using Evbpc.Framework.Windows.Forms;
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
    /// <summary>
    /// Represents a <see cref="Framework.Windows.Forms.Label"/> to be used with a <see cref="Form"/>.
    /// </summary>
    public class Label : Framework.Windows.Forms.Label, IDrawableControl
    {
        /// <summary>
        /// The <code>SpriteFont</code> the <see cref="Label"/> should be drawn with.
        /// </summary>
        public SpriteFont Font { get; }

        /// <summary>
        /// Constructs a new <see cref="Label"/> with the specified <see cref="Control.Name"/>.
        /// </summary>
        /// <param name="font">The <see cref="Font"/>.</param>
        /// <param name="name">The <see cref="Control.Name"/>.</param>
        public Label(SpriteFont font, string name)
        {
            Font = font;
            Name = name;
        }

        /// <summary>
        /// Constructs a new <see cref="Label"/> with the specified <see cref="Control.Name"/>.
        /// </summary>
        /// <param name="font">The <see cref="Font"/>.</param>
        /// <param name="name">The <see cref="Control.Name"/>.</param>
        /// <param name="text">The <see cref="Control.Text"/></param>
        public Label(SpriteFont font, string name, string text)
            : this(font, name)
        {
            Text = text;
        }

        void IDrawableControl.Draw(SpriteBatch s, Framework.Drawing.Point initialLocation)
        {
            s.DrawString(Font, Text, new Vector2(initialLocation.X + Location.X, initialLocation.Y + Location.Y), ForeColor.ToXnaColor());
        }
    }
}
