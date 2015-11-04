using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static Evbpc.Framework.Utilities.Extensions.StringExtensions;

namespace Evbpc.Framework.Integrations.Google.ReCaptcha
{
    /// <summary>
    /// This class is used by the <see cref="Validator"/> to return a proper response to a reCAPTCHA validation request.
    /// </summary>
    public class Response
    {
        private bool _success = false;
        private Errors _errors = Errors.None;

        /// <summary>
        /// Returns a value indicating if the <see cref="Validator"/> succeeded in validating the reCAPTCHA response or not.
        /// </summary>
        public bool Success => _success;

        /// <summary>
        /// Returns any <see cref="ReCaptcha.Errors"/> that occurred during the reCAPTCHA response validation.
        /// </summary>
        public Errors Errors => _errors;

        /// <summary>
        /// Parses a JSON string into the current <see cref="Response"/>.
        /// </summary>
        /// <param name="jsonResponse">The JSON string to transform.</param>
        /// <param name="result">The parsed result.</param>
        /// <returns>True if no errors were encountered during parsing, or false if the JSON appeared to be malformed.</returns>
        public static bool TryParseJson(string jsonResponse, out Response result)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic deserializedJson = jss.DeserializeObject(jsonResponse);
            Response resultResponse = new Response();

            if (!deserializedJson.ContainsKey("success"))
            {
                result = null;
                return false;
            }

            resultResponse._success = deserializedJson["success"];
            resultResponse._errors = Errors.None;

            if (deserializedJson.ContainsKey("error-codes"))
            {
                Errors? errors = ErrorsToEnum(deserializedJson["error-codes"]);
                
                if (!errors.HasValue)
                {
                    result = null;
                    return false;
                }

                resultResponse._errors = errors.Value;
            }

            result = resultResponse;
            return true;
        }

        /// <summary>
        /// Converts a string-array of reCAPTCHA errors to an enum of <see cref="ReCaptcha.Errors"/>.
        /// </summary>
        /// <param name="errorCodes">The errors to convert.</param>
        /// <returns>A nullable enum of type <see cref="ReCaptcha.Errors"/>. If null, then there was an error returned that is not defined in the enum.</returns>
        protected static Errors? ErrorsToEnum(string[] errorCodes)
        {
            Errors errors = Errors.None;

            foreach (string error in errorCodes)
            {
                string errorEnumName = error.ToPascalCase();
                if (!Enum.IsDefined(typeof(Errors), errorEnumName))
                {
                    return null;
                }

                errors = errors | (Errors)Enum.Parse(typeof(Errors), errorEnumName);
            }

            return errors;
        }
    }
}
