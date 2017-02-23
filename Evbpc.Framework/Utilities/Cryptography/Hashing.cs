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

        /// <summary>
        /// Hashes a password with <see cref="Rfc2898DeriveBytes"/> / PBKDF2.
        /// </summary>
        /// <param name="password">The string password to hash.</param>
        /// <param name="salt">The byte array of the salt.</param>
        /// <param name="byteCount">Optionally specify the number of bytes of the hash to return, default is 32.</param>
        /// <param name="iterations">Optionally specify the number of iterations to perform, default is 10000.</param>
        /// <returns>The byte array for the hashed password.</returns>
        public static byte[] HashPassword(string password, byte[] salt, int byteCount = 32, int iterations = 10000)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return rfc2898DeriveBytes.GetBytes(byteCount);
            }
        }
    }
}
