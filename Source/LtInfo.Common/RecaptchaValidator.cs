using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace LtInfo.Common
{
    public class RecaptchaValidator
    {
        /// <summary>
        /// This is using the new Recaptcha 2 API
        /// </summary>
        public static bool IsValidResponse(string response, string clientIP, string privateKey, string validationUrl, Action<string> loggingFunction)
        {
            if (clientIP == null || response == null)
            {
                loggingFunction(string.Format("Problem with Captcha. One or more of the required Captcha parts is null (response, or clientIP). Asking client to re-try. If this happens repeatedly it may indicate a change to the Captcha API. (did not cause a user visible exception)\r\nresponse: {0}\r\nclientIP: {1}.", response, clientIP));
                return false;
            }

            var request = (HttpWebRequest)WebRequest.Create(validationUrl);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = 30 * 1000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string formdata = string.Format("secret={0}&remoteip={1}&response={2}"
                                            , new object[]
                                                {
                                                    HttpUtility.UrlEncode(privateKey)
                                                ,   HttpUtility.UrlEncode(clientIP)
                                                ,   HttpUtility.UrlEncode(response)
                                                });

            byte[] formbytes = Encoding.ASCII.GetBytes(formdata);

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(formbytes, 0, formbytes.Length);
            }

            using (var httpResponse = request.GetResponse())
            {
                using (var readStream = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
                {
                    var rawJson = readStream.ReadToEnd();
                    var recaptchaResponseJson = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup

                    switch (recaptchaResponseJson["success"].ToString().ToLower())
                    {
                        case "true":
                            return true;

                        case "false":
                            loggingFunction(string.Format("Recaptcha verification failed! Error codes \"{0}\" from Recaptcha validation call.",
                                    string.Join(",", recaptchaResponseJson["error-codes"])));
                            return false;

                        default:
                            if (recaptchaResponseJson["error-codes"] != null)
                            {
                                throw new InvalidProgramException(string.Format("Recaptcha verification failed! Error codes \"{0}\" from Recaptcha validation call.",
                                    string.Join(",", recaptchaResponseJson["error-codes"])));
                            }
                            throw new InvalidProgramException(string.Format("Unknown status response \"{0}\" from Recaptcha validation call.", rawJson));
                    }
                }
            }
        }
    }
}
