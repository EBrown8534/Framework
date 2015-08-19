using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Evbpc.Framework.Utilities.Extensions;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Provides certain Cryptography methods to ease the implementation of them.
    /// </summary>
    public class Cryptography
    {
        private static byte[] _aesSalt = new byte[] {
            0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 
            0x76
        };

        /// <summary>
        /// Gets or sets the salt to use with AES encryption.
        /// </summary>
        public static byte[] AesSalt { get { return _aesSalt; } set { _aesSalt = value; } }

        /// <summary>
        /// Uses AES encryption to encrypt a string of data.
        /// </summary>
        /// <param name="clearText">The data to encrypt.</param>
        /// <param name="passphrase">The secret pre-shared passphrase.</param>
        /// <returns>An encrypted Base64 string.</returns>
        public static string AesEncrypt(string clearText, string passphrase)
        {
            if (passphrase.Length > 0)
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passphrase, _aesSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = ms.ToArray().ToBase64String();
                    }
                }
            }

            return clearText;
        }

        /// <summary>
        /// Uses AES encryption to decrypt a string of data.
        /// </summary>
        /// <param name="cipherText">The encrypted Base64 string to decrypt.</param>
        /// <param name="passphrase">The secret pre-shared passphrase.</param>
        /// <param name="throwExceptions">If true, will throw exceptions on decryption failure. Else, returns null string on decryption failure.</param>
        /// <returns>The plaintext data.</returns>
        public static string AesDecrypt(string cipherText, string passphrase, bool throwExceptions)
        {
            if (passphrase.Length > 0)
            {
                if (throwExceptions)
                {
                    cipherText = AesDecryptInternal(cipherText, passphrase);
                }
                else
                {
                    try
                    {
                        cipherText = AesDecryptInternal(cipherText, passphrase);
                    }
                    catch
                    {
                        cipherText = null;
                    }
                }
            }

            return cipherText;
        }

        private static string AesDecryptInternal(string cipherText, string passphrase)
        {
            byte[] cipherBytes = cipherText.FromBase64String();

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passphrase, _aesSalt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }
    }
}
