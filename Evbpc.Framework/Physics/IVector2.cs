using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Physics
{
    public interface IVector2
    {
        double R { get; }
        double Theta { get; }
        bool IsEmpty { get; }
    }
}
