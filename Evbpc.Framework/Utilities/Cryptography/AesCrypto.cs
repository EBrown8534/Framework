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
    public class AesCrypto : IDisposable
    {
        private string _passphrase;
        private byte[] _salt;

        private Rijndael _encryptor;
        private Rfc2898DeriveBytes _pdb;
        private ICryptoTransform _encryptorTransform;
        private ICryptoTransform _decryptorTransform;

        /// <summary>
        /// Gets or sets the passphrase for use with AES encryption.
        /// </summary>
        public string Passphrase
        {
            get { return _passphrase; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"The parameter {nameof(Passphrase)} is required.");
                }

                _passphrase = value;
            }
        }

        /// <summary>
        /// Gets or sets the salt to use with AES encryption. This should be different for each message.
        /// </summary>
        public byte[] Salt
        {
            get { return _salt; }
            set
            {
                if (value == null || value.Length < 8)
                {
                    throw new ArgumentException($"The parameter {nameof(Salt)} is required, and must be at least 8 bytes.");
                }

                _salt = value;
            }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="AesCrypto"/> from the specified values.
        /// </summary>
        /// <param name="salt">The <see cref="Salt"/> used in encryption.</param>
        /// <param name="passphrase">The <see cref="Passphrase"/> used in encryption.</param>
        public AesCrypto(string passphrase, byte[] salt)
        {
            Passphrase = passphrase;
            Salt = salt;

            _encryptor = Rijndael.Create();
            _encryptor.Padding = PaddingMode.PKCS7;
            _pdb = new Rfc2898DeriveBytes(Passphrase, Salt);
            _encryptor.Key = _pdb.GetBytes(_encryptor.KeySize / 8);
            _encryptor.IV = _pdb.GetBytes(_encryptor.BlockSize / 8);

            _encryptorTransform = _encryptor.CreateEncryptor();
            _decryptorTransform = _encryptor.CreateDecryptor();
        }

        /// <summary>
        /// Uses AES encryption to encrypt a string of data.
        /// </summary>
        /// <param name="clearText">The data to encrypt. Data is expected to be Unicode.</param>
        /// <returns>An encrypted Base64 string.</returns>
        public string AesEncrypt(string clearText)
        {
            var clearBytes = Encoding.UTF8.GetBytes(clearText);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, _encryptorTransform, CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.FlushFinalBlock();
                }

                return StringExtensions.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// Uses AES encryption to decrypt a string of data.
        /// </summary>
        /// <param name="cipherText">The encrypted Base64 string to decrypt.</param>
        /// <param name="throwExceptions">If true, will throw exceptions on decryption failure. Else, returns null string on decryption failure.</param>
        /// <returns>The plaintext data. Data is unicode.</returns>
        public string AesDecrypt(string cipherText, bool throwExceptions)
        {
            try
            {
                var cipherBytes = StringExtensions.FromBase64String(cipherText);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, _decryptorTransform, CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch when (!throwExceptions)
            {
                return null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _encryptor.Dispose();
                    _encryptorTransform.Dispose();
                    _decryptorTransform.Dispose();
                    _pdb.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AesCrypto() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
