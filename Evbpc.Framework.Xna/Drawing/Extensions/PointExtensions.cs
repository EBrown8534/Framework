using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Drawing.Extensions
{
    /// <summary>
    /// Contains extensions methods to use with <see cref="Framework.Drawing.Point"/>, <see cref="Framework.Drawing.PointF"/>, and <see cref="Framework.Drawing.PointShort"/>.
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Converts a <see cref="Framework.Drawing.Point"/> to a <code>Microsoft.Xna.Framwork.Point</code>.
        /// </summary>
        /// <param name="p">The <see cref="Framework.Drawing.Point"/> to convert.</param>
        /// <returns>The <code>Microsoft.Xna.Framwork.Point</code> representing the specified <see cref="Framework.Drawing.Point"/>.</returns>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this Framework.Drawing.Point p) => new Microsoft.Xna.Framework.Point(p.X, p.Y);

        /// <summary>
        /// Converts a <see cref="Framework.Drawing.PointF"/> to a <code>Microsoft.Xna.Framwork.Point</code> by truncating values.
        /// </summary>
        /// <param name="p">The <see cref="Framework.Drawing.PointF"/> to convert.</param>
        /// <returns>The <code>Microsoft.Xna.Framwork.Point</code> representing the specified <see cref="Framework.Drawing.PointF"/>.</returns>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this Framework.Drawing.PointF p) => new Microsoft.Xna.Framework.Point((int)p.X, (int)p.Y);

        /// <summary>
        /// Converts a <see cref="Framework.Drawing.PointShort"/> to a <code>Microsoft.Xna.Framwork.Point</code> by truncating values.
        /// </summary>
        /// <param name="p">The <see cref="Framework.Drawing.PointShort"/> to convert.</param>
        /// <returns>The <code>Microsoft.Xna.Framwork.Point</code> representing the specified <see cref="Framework.Drawing.PointShort"/>.</returns>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this Framework.Drawing.PointShort p) => new Microsoft.Xna.Framework.Point((int)p.X, (int)p.Y);
    }
}
