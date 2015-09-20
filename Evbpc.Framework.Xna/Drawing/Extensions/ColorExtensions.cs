using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Drawing.Extensions
{
    /// <summary>
    /// Contains extension methods used with <see cref="Framework.Drawing.Color"/> and <code>Microsoft.Xna.Framwork.Color</code>.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts an <see cref="Framework.Drawing.Color"/> to a <code>Microsoft.Xna.Framework.Color</code>.
        /// </summary>
        /// <param name="color">The color to convert from.</param>
        /// <returns>A <code>Microsoft.Xna.Framework.Color</code> build with the values from the <see cref="Framework.Drawing.Color"/>.</returns>
        public static Microsoft.Xna.Framework.Color ToXnaColor(this Framework.Drawing.Color color) => new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
    }
}
