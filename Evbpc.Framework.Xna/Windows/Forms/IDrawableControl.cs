using Evbpc.Framework.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    internal interface IDrawableControl
    {
        void Draw(SpriteBatch s, Evbpc.Framework.Drawing.Point initialLocation);
    }
}
