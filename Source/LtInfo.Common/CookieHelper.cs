/*-----------------------------------------------------------------------
<copyright file="CookieHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace LtInfo.Common
{
public class CookieHelper
    {
        public static string GetCookieValueOrSetDefault(HttpRequestBase request, string cookieNameAt, string defaultValue)
        {
            if (request != null && request.Cookies != null)
            {
                var cookie = request.Cookies.Get(cookieNameAt);
                if (cookie == null)
                {
                    var defaultCookie = new HttpCookie(cookieNameAt, defaultValue);
                    request.Cookies.Set(defaultCookie);
                }
                else
                {
                    defaultValue = HttpUtility.UrlDecode(cookie.Value);
                }
            }
            return defaultValue;
        }


        public static void SetCookieValue(HttpRequestBase request, string cookieNameAt, string value)
        {
            if (request == null || request.Cookies == null)
            {
                return;
            }
            var cookie = request.Cookies.Get(cookieNameAt) ?? new HttpCookie(cookieNameAt, value);
            cookie.Value = value;
            request.Cookies.Set(cookie);
        }

        /// <summary>
        /// If we are going to make an HTTP request back to our own website, don't pass the ASP.NET Session cookie (typically named "ASP.NET_SessionId") to avoid deadlock on session
        /// </summary>
        public static List<Cookie> GetAllCookiesExceptSessionCookie(CookieCollection cookieCollection)
        {
            // httpCookieCollection is weird, the enumerator returns strings. This way we get to a list of cookies first.
            var cookies = Enumerable.Range(0, cookieCollection.Count).Select(i => cookieCollection[i]).ToList();

            var sessionCookieName = CookieNameForAspNetSessionCookieForThisApplication();

            // We remove the session cookie due to potentially for locking (ASP.MVC has session state lock)
            var allCookiesExceptSessionCookie = cookies.Where(x => x.Name != sessionCookieName).ToList();

            // *AND* any cookies that don't conform to the RFC (otherwise will get exceptions)
            var cookiesToPassOn = allCookiesExceptSessionCookie.Where(x => DoesCookieValueConformToRfc6265(x.Value)).ToList();

            // Also log that there were non-RFC 6265 cookies that were passed along, so we can see this is happening
            var nonConformingCookies = allCookiesExceptSessionCookie.Except(cookiesToPassOn).ToList();
            if (nonConformingCookies.Any())
            {
                var warningMessages =
                    nonConformingCookies.Select(
                        ic =>
                        string.Format(
                            "   RFC6265 non-conforming Cookie Name: {0} Value: {1} Timestamp: {2} Domain: {3} Path: {4} Port: {5} Comment: {6} CommentUri: {7} AsItWouldAppearInHttpHeader: {8}",
                            ic.Name,
                            ic.Value,
                            ic.TimeStamp,
                            ic.Domain,
                            ic.Path,
                            ic.Port,
                            ic.Comment,
                            ic.CommentUri,
                            ic.ToString())).ToList();
                var warningMessageList = string.Join("\r\n", warningMessages);
                var message = string.Format("While passing on System.Net.Cookie to a web request, filtered out {0} cookies due to non-conformance with RFC6265. Typically this can be ignored unless that cookie is needed in the remote request. If it is a cookie under your control, considering updating it to conform.\r\n{1}", nonConformingCookies.Count, warningMessageList);
                SitkaHttpApplication.Logger.WarnFormat(message);
            }
            return cookiesToPassOn;
        }

        /// <summary>
        /// Looks similar to other function but is crucially different - these are outgoing cookies <see cref="HttpCookie"/> versus <see cref="Cookie"/>
        /// </summary>
        public static List<HttpCookie> GetAllCookiesExceptSessionCookie(HttpCookieCollection httpCookieCollection)
        {
            // httpCookieCollection is weird, the enumerator returns strings. This way we get to a list of cookies first.
            var cookies = Enumerable.Range(0, httpCookieCollection.Count).Select(i => httpCookieCollection[i]).ToList();

            var sessionCookieName = CookieNameForAspNetSessionCookieForThisApplication();

            // We remove the session cookie due to potentially for locking (ASP.MVC has session state lock)
            var allCookiesExceptSessionCookie = cookies.Where(x => x.Name != sessionCookieName).ToList();

            // *AND* any cookies that don't conform to the RFC (otherwise will get exceptions)
            var cookiesToPassOn = allCookiesExceptSessionCookie.Where(x => DoesCookieValueConformToRfc6265(x.Value)).ToList();

            // Also log that there were non-RFC 6265 cookies that were passed along, so we can see this is happening
            var nonConformingCookies = allCookiesExceptSessionCookie.Except(cookiesToPassOn).ToList();
            if (nonConformingCookies.Any())
            {
                var warningMessages =
                    nonConformingCookies.Select(
                        ic =>
                        string.Format(
                            "   RFC6265 non-conforming Cookie Name: {0} Value: {1} Domain: {2} Path: {3}",
                            ic.Name,
                            ic.Value,
                            ic.Domain,
                            ic.Path)).ToList();
                var warningMessageList = string.Join("\r\n", warningMessages);
                var message = string.Format("While passing on System.Web.HttpCookie to a web request, filtered out {0} cookies due to non-conformance with RFC6265. Typically this can be ignored unless that cookie is needed in the remote request. If it is a cookie under your control, considering updating it to conform.\r\n{1}", nonConformingCookies.Count, warningMessageList);
                SitkaHttpApplication.Logger.WarnFormat(message);
            }
            return cookiesToPassOn;
        }

        //
        // Cookie - validation of name and value
        // -------------------------------------
        //
        // From RFC6265: http://tools.ietf.org/html/rfc6265
        // cookie-pair       = cookie-name "=" cookie-value
        // cookie-name       = token
        // cookie-value      = *cookie-octet / ( DQUOTE *cookie-octet DQUOTE )
        // cookie-octet      = %x21 / %x23-2B / %x2D-3A / %x3C-5B / %x5D-7E
        //                ; US-ASCII characters excluding CTLs,
        //                ; whitespace DQUOTE, comma, semicolon,
        //                ; and backslash
        // token             = <token, defined in [RFC2616], Section 2.2>
        //
        //
        // From RFC2616: http://tools.ietf.org/html/rfc2616#section-2.2
        // CHAR           = <any US-ASCII character (octets 0 - 127)>
        // CTL            = <any US-ASCII control character (octets 0 - 31) and DEL (127)>
        // SP             = <US-ASCII SP, space (32)>
        // HT             = <US-ASCII HT, horizontal-tab (9)>
        // token          = 1*<any CHAR except CTLs or separators>
        // separators     = "(" | ")" | "<" | ">" | "@"
        //                      | "," | ";" | ":" | "\" | <">
        //                      | "/" | "[" | "]" | "?" | "="
        //                      | "{" | "}" | SP | HT

        /// <summary>
        /// The Regex for validation of cookies conforming to RFC 6265 - otherwise such cookies can't be passed along without exception
        /// </summary>
        private const string RegexStringForRfc6265 = @"^([\x21\x23-\x2B\x2D-\x3A\x3C-\x5B\x5D-\x7E]*|""[\x21\x23-\x2B\x2D-\x3A\x3C-\x5B\x5D-\x7E]*"")$";

        /// <summary>
        /// The Regex for validation of cookies conforming to RFC 6265 - otherwise such cookies can't be passed along without exception
        /// </summary>
        private static readonly Regex RegexForRfc6265 = new Regex(RegexStringForRfc6265);

        /// <summary>
        /// DHTMLx grid, in particular, sets non-Rfc 6265 cookies that contain comma characters. This is out of spec for RFC 6265 for browser to server communication
        /// for cookies, and ASP.NET rejects them when we try to add them to cookie collections. This function allows you to detect such cookies, allowing you
        /// to discard them. -- SLG 05/09/2013
        /// </summary>
        private static bool DoesCookieValueConformToRfc6265(string value)
        {            
            return (RegexForRfc6265.IsMatch(value));
        }

        private static string CookieNameForAspNetSessionCookieForThisApplication()
        {
            var sessionStateSection = (SessionStateSection) ConfigurationManager.GetSection("system.web/sessionState");
            return sessionStateSection.CookieName;
        }

        public static HttpCookieCollection GetAllAuthenticationCookies(HttpCookieCollection httpCookieCollection, string pfCookieName)
        {
            var cookies = Enumerable.Range(0, httpCookieCollection.Count).Select(i => httpCookieCollection[i]).ToList();
            var allAuthenticationCookies = new HttpCookieCollection();
            cookies.Where(x => x.Name.StartsWith(pfCookieName)).ToList().ForEach(x => allAuthenticationCookies.Add(x));
            return allAuthenticationCookies;
        }
    }
}
