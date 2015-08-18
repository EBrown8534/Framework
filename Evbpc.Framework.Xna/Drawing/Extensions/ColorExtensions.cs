using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Drawing.Extensions
{
    public static class ColorExtensions
    {
        public static Microsoft.Xna.Framework.Color ToXnaColor(this Evbpc.Framework.Drawing.Color color)
        {
            return new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }
    }
}
