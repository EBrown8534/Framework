using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Serialization
{
    /// <summary>
    /// Provides an interface for common members for objects that are serializable to byte-arrays.
    /// </summary>
    public interface ISerializableByteArray
    {
        /// <summary>
        /// Serializes this <see cref="ISerializableByteArray"/> to a byte-array. Implementation varies by object.
        /// </summary>
        /// <returns>A byte-array representing the current <see cref="ISerializableByteArray"/>.</returns>
        byte[] GetBytes();

        /// <summary>
        /// Fills this <see cref="ISerializableByteArray"/> from a byte-array. Implementation varies by object.
        /// </summary>
        /// <param name="data">A byte-array representing the current <see cref="ISerializableByteArray"/>.</param>
        void FromBytes(byte[] data);

        /// <summary>
        /// Gets the size (in bytes) that the <see cref="ISerializableByteArray"/> will fill.
        /// </summary>
        int SizeInBytes { get; }
    }
}
