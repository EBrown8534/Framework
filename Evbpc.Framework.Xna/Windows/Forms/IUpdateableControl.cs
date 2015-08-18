using Evbpc.Framework.Xna.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Windows.Forms
{
    internal interface IUpdateableControl
    {
        void Update(MouseState m, bool hasFocus, GameTime gt);
    }
}
