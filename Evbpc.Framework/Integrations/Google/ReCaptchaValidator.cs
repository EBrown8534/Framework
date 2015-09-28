using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Evbpc.Framework.Integrations.Google
{
    /// <summary>
    /// This class provides the ability to easily implement Google's reCAPTCHA.
    /// </summary>
    /// <remarks>
    /// See: https://www.google.com/recaptcha/intro/index.html
    /// </remarks>
    public class ReCaptchaValidator
    {
        private const string _headScriptInclude = "<script src='https://www.google.com/recaptcha/api.js'></script>";
        private const string _bodyDivInclude = "<div class=\"g-recaptcha %EXTRACLASSES%\" data-sitekey=\"%SITEKEY%\"></div>";
        private const string _reCaptchaFormCode = "g-recaptcha-response";
        private const string _googleApiEndpoint = "https://www.google.com/recaptcha/api/siteverify";

        private readonly string _reCaptchaSecret;
        private readonly string _reCaptchaSiteKey;
        private readonly List<string> _extraClasses = new List<string>();

        /// <summary>
        /// Returns the script to be included in the <code>&lt;head&gt;</code> of the page.
        /// </summary>
        public string HeadScriptInclude => ReCaptchaValidator._headScriptInclude;

        /// <summary>
        /// Use this to get or set any extra classes that should be added to the <code>&lt;div&gt;</code> that is created by the <see cref="BodyDivInclude"/>.
        /// </summary>
        public List<string> ExtraClasses => _extraClasses;

        /// <summary>
        /// Returns the <code>&lt;div&gt;</code> that should be inserted in the HTML where the reCAPTCHA should be rendered.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetBodyDivContent(List{string})"/> with <see cref="ExtraClasses"/> as the parameter.
        /// </remarks>
        public string BodyDivInclude => GetBodyDivContent(this.ExtraClasses);

        /// <summary>
        /// Creates a new instance of the <see cref="ReCaptchaValidator"/>.
        /// </summary>
        /// <param name="reCaptchaSecret">The reCAPTCHA secret.</param>
        /// <param name="reCaptchaSiteKey">The reCAPTCHA site key.</param>
        public ReCaptchaValidator(string reCaptchaSecret, string reCaptchaSiteKey)
        {
            _reCaptchaSecret = reCaptchaSecret;
            _reCaptchaSiteKey = reCaptchaSiteKey;
        }

        /// <summary>
        /// Determines if the reCAPTCHA response in a <code>NameValueCollection</code> passed validation.
        /// </summary>
        /// <param name="form">The <code>Request.Form</code> to validate.</param>
        /// <param name="remoteIp">An optional <code>IPAddress</code></param>
        /// <returns>A <see cref="ReCaptchaResponse"/> value indicating the response of the verification.</returns>
        /// <remarks>
        /// If the returned <see cref="ReCaptchaResponse"/> is null, then a severe error occurred during the exchange.
        /// </remarks>
        public ReCaptchaResponse Validate(NameValueCollection form, string remoteIp = null)
        {
            string reCaptchaSecret = _reCaptchaSecret;
            string reCaptchaResponse = form[ReCaptchaValidator._reCaptchaFormCode];

            using (WebClient client = new WebClient())
            {
                NameValueCollection postParameters = new NameValueCollection() { { "secret", reCaptchaSecret }, { "response", reCaptchaResponse } };

                if (remoteIp != null)
                {
                    postParameters.Add("remoteip", remoteIp);
                }

                byte[] response = client.UploadValues(ReCaptchaValidator._googleApiEndpoint, postParameters);

                string reCaptchaResult = System.Text.Encoding.UTF8.GetString(response);

                ReCaptchaResponse result = new ReCaptchaResponse();

                if (result.ParseJson(reCaptchaResult))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Returns the <code>&lt;div&gt;</code> that should be inserted in the HTML where the reCAPTCHA should be rendered.
        /// </summary>
        /// <param name="extraClasses">Any extra classes that should be appended to the <code>&lt;div&gt;</code>.</param>
        /// <returns>The HTML that should be inserted into the document to render the reCAPTCHA.</returns>
        /// <remarks>
        /// This method allows you to pass an arbitrary list of extra classes, regardless of what the current instance may contain.
        /// </remarks>
        public string GetBodyDivContent(List<string> extraClasses)
        {
            string result = ReCaptchaValidator._bodyDivInclude;

            result = result.Replace("%SITEKEY%", _reCaptchaSiteKey);

            if (extraClasses != null)
            {
                result = result.Replace("%EXTRACLASSES%", string.Join(" ", extraClasses));
            }

            return result;
        }
    }

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
        /// <returns>True if no errors were encountered during parsing, or false if the JSON appeared to be malformed.</returns>
        public bool ParseJson(string jsonResponse)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic deserializedJson = jss.DeserializeObject(jsonResponse);

            if (deserializedJson.ContainsKey("success"))
            {
                _success = deserializedJson["success"];
                _errors = ReCaptchaErrors.None;

                if (deserializedJson.ContainsKey("error-codes"))
                {
                    foreach (string error in deserializedJson["error-codes"])
                    {
                        // Our `ReCaptchaErrors` enum contains the exact same strings as the returned `error` text would be, with the following transformations:
                        // 1. The words are transformed to PascalCase;
                        // 2. The dashes are stripped;
                        string[] errorWords = error.Split('-');

                        string errorEnumName = "";
                        foreach (string errorWord in errorWords)
                        {
                            errorEnumName += errorWord[0].ToString().ToUpper() + errorWord.Substring(1);
                        }

                        if (Enum.IsDefined(typeof(ReCaptchaErrors), errorEnumName))
                        {
                            _errors = _errors | (ReCaptchaErrors)Enum.Parse(typeof(ReCaptchaErrors), errorEnumName);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Indicates errors that could be returned by the reCAPTCHA API.
    /// </summary>
    /// <remarks>
    /// See: https://developers.google.com/recaptcha/docs/verify
    /// </remarks>
    [Flags]
    public enum ReCaptchaErrors
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