using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static Evbpc.Framework.Utilities.StringHelpers;

namespace Evbpc.Framework.Integrations.Google
{
    /// <summary>
    /// This class is used by the <see cref="ReCaptchaValidator"/> to return a proper response to a reCAPTCHA validation request.
    /// </summary>
    public class ReCaptchaResponse
    {
        private bool _success = false;
        private ReCaptchaErrors _errors = ReCaptchaErrors.None;

        /// <summary>
        /// Returns a value indicating if the <see cref="ReCaptchaValidator"/> succeeded in validating the reCAPTCHA response or not.
        /// </summary>
        public bool Success => _success;

        /// <summary>
        /// Returns any <see cref="ReCaptchaErrors"/> that occurred during the reCAPTCHA response validation.
        /// </summary>
        public ReCaptchaErrors Errors => _errors;

        /// <summary>
        /// Parses a JSON string into the current <see cref="ReCaptchaResponse"/>.
        /// </summary>
        /// <param name="jsonResponse">The JSON string to transform.</param>
        /// <param name="result">The parsed result.</param>
        /// <returns>True if no errors were encountered during parsing, or false if the JSON appeared to be malformed.</returns>
        public static bool TryParseJson(string jsonResponse, out ReCaptchaResponse result)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic deserializedJson = jss.DeserializeObject(jsonResponse);
            ReCaptchaResponse resultResponse = new ReCaptchaResponse();

            if (!deserializedJson.ContainsKey("success"))
            {
                result = null;
                return false;
            }

            resultResponse._success = deserializedJson["success"];
            resultResponse._errors = ReCaptchaErrors.None;

            if (deserializedJson.ContainsKey("error-codes"))
            {
                ReCaptchaErrors? errors = ErrorsToEnum(deserializedJson["error-codes"]);

                if (errors.HasValue)
                {
                    resultResponse._errors = errors.Value;
                }
            }

            result = resultResponse;
            return true;
        }

        /// <summary>
        /// Converts a string-array of reCAPTCHA errors to an enum of <see cref="ReCaptchaErrors"/>.
        /// </summary>
        /// <param name="errorCodes">The errors to convert.</param>
        /// <returns>A nullable enum of type <see cref="ReCaptchaErrors"/>. If null, then there was an error returned that is not defined in the enum.</returns>
        protected static ReCaptchaErrors? ErrorsToEnum(string[] errorCodes)
        {
            ReCaptchaErrors errors = ReCaptchaErrors.None;

            foreach (string error in errorCodes)
            {
                string errorEnumName = error.ToPascalCase();
                if (!Enum.IsDefined(typeof(ReCaptchaErrors), errorEnumName))
                {
                    return null;
                }

                errors = errors | (ReCaptchaErrors)Enum.Parse(typeof(ReCaptchaErrors), errorEnumName);
            }

            return errors;
        }
    }
}
