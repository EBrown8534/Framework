using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static Evbpc.Framework.Utilities.Extensions.StringExtensions;

namespace Evbpc.Framework.Utilities.Cryptography
{
    /// <summary>
    /// A collection of methods which can hash strings to various formats.
    /// </summary>
    public static class Hashing
    {
        /// <summary>
        /// Hashes a string to a Sha512 hash.
        /// </summary>
        /// <param name="data">The string to hash.</param>
        /// <returns>The hexadecimal string representing the hash.</returns>
        public static string Sha512HashString(string data) => Sha512HashBytes(data).ToHexString();

        /// <summary>
        /// Hashes a string to a Sha512 hash.
        /// </summary>
        /// <param name="data">The string to hash.</param>
        /// <returns>The byte array representing the hash.</returns>
        public static byte[] Sha512HashBytes(string data)
        {
            using (var sha512 = SHA512.Create())
            {
                sha512.ComputeHash(Encoding.Unicode.GetBytes(data));

                return sha512.Hash;
            }
        }
    }
}
