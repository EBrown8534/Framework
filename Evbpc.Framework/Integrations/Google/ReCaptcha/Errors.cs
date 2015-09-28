using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.Google.ReCaptcha
{
    /// <summary>
    /// Indicates errors that could be returned by the reCAPTCHA API.
    /// </summary>
    /// <remarks>
    /// See: https://developers.google.com/recaptcha/docs/verify
    /// </remarks>
    [Flags]
    public enum Errors
    {
        /// <summary>
        /// No errors occurred.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// The secret parameter is missing.
        /// </summary>
        MissingInputSecret = 1 << 0,
        /// <summary>
        /// The secret parameter is invalid or malformed.
        /// </summary>
        InvalidInputSecret = 1 << 1,
        /// <summary>
        /// The response parameter is missing.
        /// </summary>
        MissingInputResponse = 1 << 2,
        /// <summary>
        /// The response parameter is invalid or malformed.
        /// </summary>
        InvalidInputResponse = 1 << 3,
    }
}
