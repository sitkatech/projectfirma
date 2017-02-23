/*-----------------------------------------------------------------------
<copyright file="HttpHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public static class HttpHelper
    {
        public static bool IsURL(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri);
        }

        public static CookieCollection ToCookieCollection(this HttpCookieCollection cookies, string host)
        {
            var realCookies = new CookieCollection();
            foreach (string cookieIndex in cookies)
            {
                var cookie = cookies[cookieIndex];
                if (cookie != null)
                {
                    var realCookie = new Cookie
                                     {
                                         Domain = host, 
                                         Expires = cookie.Expires, 
                                         Name = cookie.Name, 
                                         Path = cookie.Path, 
                                         Secure = cookie.Secure, 
                                         Value = cookie.Value
                                     };

                    realCookies.Add(realCookie);
                }
            }
            return realCookies;
        }

        public static string FullyQualifyUrl(string url)
        {
            if (url != null && url.Trim().ToLower().StartsWith("www"))
            {
                return "http://" + url;
            }

            return url;
        }        

        public static string GetUrl(string url, out HttpStatusCode statusCode, out HttpWebResponse response)
        {
            return GetUrlImplCookieList(url, null, out statusCode, out response, false);
        }

        public static string GetUrl(string url, out HttpStatusCode statusCode)
        {
            HttpWebResponse response;
            return GetUrlImplCookieList(url, null, out statusCode, out response, false);
        }

        public static string GetUrl(string url, CookieContainer cookieContainer, out HttpStatusCode statusCode)
        {
            HttpWebResponse response;
            return GetUrlImplCookieContainer(url, cookieContainer, out statusCode, out response, false);
        }

        public static string GetUrl(string url, CookieContainer cookieContainer, out HttpStatusCode statusCode, out HttpWebResponse response)
        {
            return GetUrlImplCookieContainer(url, cookieContainer, out statusCode, out response, false);
        }

        public static string GetUrl(Uri url)
        {
            return GetUrl(url.AbsoluteUri, null);
        }

        public static string GetUrl(string url)
        {
            return GetUrl(url, null);
        }

        public static string GetUrl(string url, IEnumerable<Cookie> cookies)
        {
            HttpStatusCode status;
            HttpWebResponse response;
            return GetUrlImplCookieList(url, cookies, out status, out response, true);
        }

        public static Uri BuildUri(string scheme, string domain)
        {
            return BuildUri(scheme, string.Empty, domain);
        }

        public static Uri BuildUri(string scheme, string hostName, string subDomain)
        {
            Check.RequireNotNullNotEmpty(subDomain, "subDomain must be supplied");
            Check.Require(scheme == Uri.UriSchemeHttps || scheme == Uri.UriSchemeHttp);

            var uriString = new StringBuilder();

            uriString.Append(scheme);
            uriString.Append("://");

            if (!string.IsNullOrEmpty(hostName))
            {
                uriString.Append(hostName);
                uriString.Append(".");
            }

            uriString.Append(subDomain);

            if (!subDomain.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                uriString.Append("/");
            }

            return new Uri(uriString.ToString());
        }

        public static string PostToUrl(string url, CookieContainer optionalCookieContainer, IDictionary<string, string> postData, out HttpStatusCode statusCode)
        {
            var query = ParameterizeQuery(postData);

            return PostToUrl(url, optionalCookieContainer, query, out statusCode);
        }

        public static string ParameterizeQuery(IDictionary<string, string> postData)
        {
            var queryString = postData
                .Aggregate( "",
                           (current, d) =>
                           current +
                           ("&" + d.Key.ToString() + "=" +
                            (d.Value != null ? HttpUtility.UrlEncode(d.Value.ToString()) : "")));

            return queryString.Substring(1);
        }

        public static string PostToUrl(string url, CookieContainer optionalCookieContainer, string postData, out HttpStatusCode statusCode)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = optionalCookieContainer;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response;
            return GetUrlResponse(request, false, out statusCode, out response);
        }

        public static NameValueCollection ParseQueryString(string queryString)
        {
            var parsedQueryString = new NameValueCollection();
            var decodedQueryString = HttpUtility.UrlDecode(queryString);

            var queryStringArray = decodedQueryString.Split(Convert.ToChar("?"));
            foreach (var item in queryStringArray)
            {
                parsedQueryString.Add(HttpUtility.ParseQueryString(item));
            }

            return parsedQueryString;
        }

        #region Private helpers

        private static string GetUrlImplCookieContainer(string url, CookieContainer cookieContainer, out HttpStatusCode statusCode, out HttpWebResponse response, bool throwOnError)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookieContainer;

            return GetUrlResponse(request, throwOnError, out statusCode, out response);
        }

        private static string GetUrlImplCookieList(string url, IEnumerable<Cookie> cookies, out HttpStatusCode statusCode, out HttpWebResponse response, bool throwOnError)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                foreach (var cookie in cookies)
                {
                    cookie.Domain = request.RequestUri.Host;
                    request.CookieContainer.Add(cookie);
                }
            }

            return GetUrlResponse(request, throwOnError, out statusCode, out response);
        }

        private static string GetUrlResponse(WebRequest request, bool throwOnError, out HttpStatusCode statusCode, out HttpWebResponse response)
        {
            Exception innerException = null;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException we)
            {
                innerException = we;
                response = (HttpWebResponse) we.Response;
            }

            statusCode = HttpStatusCode.InternalServerError;
            string output = null;
            if (response != null)
            {
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    using (var readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        output = readStream.ReadToEnd();
                        statusCode = response.StatusCode;
                    }
                }
            }

            if ((throwOnError && innerException != null) || output == null)
            {
                if (innerException == null)
                {
                    var message = string.Format("Request to \"{0}\" could not be constructed!", request.RequestUri);
                    throw new ApplicationException(message);
                }
                var exceptionMessage = string.Format("{0}\r\n" + "Url: {1}\r\n{2}", innerException.Message, request.RequestUri.AbsoluteUri, output);
                throw new ApplicationException(exceptionMessage, innerException);
            }
            return output;
        }

        #endregion Private helpers
    }
}
