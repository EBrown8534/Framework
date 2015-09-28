using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Evbpc.Framework.Integrations.Google.ReCaptcha
{
    /// <summary>
    /// This class provides the ability to easily implement Google's reCAPTCHA.
    /// </summary>
    /// <remarks>
    /// See: https://www.google.com/recaptcha/intro/index.html
    /// </remarks>
    public class Validator
    {
        private const string _headScriptInclude = "<script src='https://www.google.com/recaptcha/api.js'></script>";
        private const string _bodyDivInclude = "<div class=\"g-recaptcha %EXTRACLASSES%\" data-sitekey=\"%SITEKEY%\"></div>";
        private const string _reCaptchaFormCode = "g-recaptcha-response";
        private const string _googleApiEndpoint = "https://www.google.com/recaptcha/api/siteverify";

        private readonly string _reCaptchaSecret;
        private readonly string _reCaptchaSiteKey;

        /// <summary>
        /// Returns the script to be included in the <code>&lt;head&gt;</code> of the page.
        /// </summary>
        public string HeadScriptInclude => Validator._headScriptInclude;

        /// <summary>
        /// Use this to get or set any extra classes that should be added to the <code>&lt;div&gt;</code> that is created by the <see cref="BodyDivInclude"/>.
        /// </summary>
        public List<string> ExtraClasses => new List<string>();

        /// <summary>
        /// Returns the <code>&lt;div&gt;</code> that should be inserted in the HTML where the reCAPTCHA should be rendered.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetBodyDivContent()"/>.
        /// </remarks>
        public string BodyDivInclude => GetBodyDivContent();

        /// <summary>
        /// Creates a new instance of the <see cref="Validator"/>.
        /// </summary>
        /// <param name="reCaptchaSecret">The reCAPTCHA secret.</param>
        /// <param name="reCaptchaSiteKey">The reCAPTCHA site key.</param>
        public Validator(string reCaptchaSecret, string reCaptchaSiteKey)
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
            string reCaptchaFormResponse = form[Validator._reCaptchaFormCode];

            NameValueCollection postParameters = GetPostParameters(reCaptchaFormResponse, remoteIp);
            ReCaptchaResponse result;
            ReCaptchaResponse.TryParseJson(Validator.UploadRecaptchaResponse(postParameters), out result);
            return result;
        }

        /// <summary>
        /// Uploads a request to the Google API for reCAPTCHA data to be validated.
        /// </summary>
        /// <param name="postParameters">The parameters to send in the POST message.</param>
        /// <returns>A string representing the returned response.</returns>
        protected static string UploadRecaptchaResponse(NameValueCollection postParameters)
        {
            using (WebClient client = new WebClient())
            {
                byte[] response = client.UploadValues(Validator._googleApiEndpoint, postParameters);
                string reCaptchaResult = System.Text.Encoding.UTF8.GetString(response);
                return reCaptchaResult;
            }
        }

        /// <summary>
        /// Returns the parameters to be placed within the post body of a validation message.
        /// </summary>
        /// <param name="reCaptchaFormResponse">The response from the reCAPTCHA form.</param>
        /// <param name="remoteIp">An optional IP to include as the origin of the reCAPTCHA form.</param>
        /// <returns>The <code>NameValueCollection</code> that should be included in the post body.</returns>
        protected NameValueCollection GetPostParameters(string reCaptchaFormResponse, string remoteIp = null)
        {
            NameValueCollection postParameters = new NameValueCollection() { { "secret", _reCaptchaSecret }, { "response", reCaptchaFormResponse } };

            if (!string.IsNullOrWhiteSpace(remoteIp))
            {
                postParameters.Add("remoteip", remoteIp);
            }

            return postParameters;
        }

        /// <summary>
        /// Returns the <code>&lt;div&gt;</code> that should be inserted in the HTML where the reCAPTCHA should be rendered.
        /// </summary>
        /// <param name="extraClasses">Any extra classes that should be appended to the <code>&lt;div&gt;</code>.</param>
        /// <returns>The HTML that should be inserted into the document to render the reCAPTCHA.</returns>
        /// <remarks>
        /// This method allows you to pass an arbitrary list of extra classes, regardless of what the current instance may contain.
        /// </remarks>
        public string GetBodyDivContent()
        {
            string result = Validator._bodyDivInclude.Replace("%SITEKEY%", _reCaptchaSiteKey);

            if (ExtraClasses != null && ExtraClasses.Count > 0)
            {
                result = result.Replace("%EXTRACLASSES%", string.Join(" ", ExtraClasses));
            }

            return result;
        }
    }
}