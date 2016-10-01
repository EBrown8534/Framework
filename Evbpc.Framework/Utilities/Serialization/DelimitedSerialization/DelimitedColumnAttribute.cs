using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Serialization.DelimitedSerialization
{
    /// <summary>
    /// Represents a column which can be used in a <see cref="DelimitedSerializer"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DelimitedColumnAttribute : Attribute
    {
        /// <summary>
        /// The name of the column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order the column should appear in.
        /// </summary>
        public int Order { get; set; }

        public string Format { get; set; }

        public bool Traverse { get; set; }
    }
}
