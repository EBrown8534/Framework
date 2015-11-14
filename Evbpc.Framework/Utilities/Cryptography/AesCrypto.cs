using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Evbpc.Framework.Utilities.Extensions;

namespace Evbpc.Framework.Utilities.Cryptography
{
    /// <summary>
    /// Provides Cryptography methods based on AES cryptography implementation.
    /// </summary>
    public class AesCrypto
    {
        /// <summary>
        /// Gets or sets the salt to use with AES encryption.
        /// </summary>
        public byte[] Salt { get; set; }

        /// <summary>
        /// Gets or sets the passphrase for use with AES encryption.
        /// </summary>
        public string Passphrase { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="AesCrypto"/> from the specified values.
        /// </summary>
        /// <param name="salt">The <see cref="Salt"/> used in encryption.</param>
        /// <param name="passphrase">The <see cref="Passphrase"/> used in encryption.</param>
        public AesCrypto(byte[] salt, string passphrase)
        {
            if (Passphrase.Length == 0)
            {
                throw new ArgumentException($"The parameter {nameof(passphrase)} is required.");
            }

            if (Salt.Length == 0)
            {
                throw new ArgumentException($"The parameter {nameof(salt)} is required.");
            }

            Salt = salt;
            Passphrase = passphrase;
        }

        /// <summary>
        /// Uses AES encryption to encrypt a string of data.
        /// </summary>
        /// <param name="clearText">The data to encrypt. Data is expected to be Unicode.</param>
        /// <returns>An encrypted Base64 string.</returns>
        public string AesEncrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Passphrase, Salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = StringExtensions.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        /// <summary>
        /// Uses AES encryption to decrypt a string of data.
        /// </summary>
        /// <param name="cipherText">The encrypted Base64 string to decrypt.</param>
        /// <param name="Passphrase">The secret pre-shared passphrase.</param>
        /// <param name="throwExceptions">If true, will throw exceptions on decryption failure. Else, returns null string on decryption failure.</param>
        /// <returns>The plaintext data. Data is unicode.</returns>
        public string AesDecrypt(string cipherText, bool throwExceptions)
        {
            if (throwExceptions)
            {
                cipherText = AesDecryptInternal(cipherText);
            }
            else
            {
                try
                {
                    cipherText = AesDecryptInternal(cipherText);
                }
                catch
                {
                    cipherText = null;
                }
            }

            return cipherText;
        }

        private string AesDecryptInternal(string cipherText)
        {
            byte[] cipherBytes = StringExtensions.FromBase64String(cipherText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes saltDerived = new Rfc2898DeriveBytes(Passphrase, Salt);
                encryptor.Key = saltDerived.GetBytes(32);
                encryptor.IV = saltDerived.GetBytes(16);

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
