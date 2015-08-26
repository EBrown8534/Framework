using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Physics
{
    /// <summary>
    /// Represents a generic combination of direction and magnitude to represent a system.
    /// </summary>
    public interface IVector2
    {
        /// <summary>
        /// The distance or magnitude from the origin (0, 0).
        /// </summary>
        double R { get; }
        /// <summary>
        /// The angle that represents the <see cref="IVector2"/>.
        /// </summary>
        double Theta { get; }
        /// <summary>
        /// Gets a boolean value indicating whether or not the current <see cref="IVector2"/> is empty.
        /// </summary>
        bool IsEmpty { get; }
    }
}
