/*-----------------------------------------------------------------------
<copyright file="Auth0CookieHelper.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Web;

namespace LtInfo.Common
{
    public static class Auth0CookieHelper
    {

        // Public string setter
        public static void SetCookieProperty(HttpRequestBase request, HttpResponseBase response, string cookieName, string key, string value, int? daysToExpire = 7)
        {
            if (response == null) return;

            HttpCookie cookie = request?.Cookies[cookieName] ?? new HttpCookie(cookieName);
            cookie[key] = value;

            if (daysToExpire.HasValue)
            {
                cookie.Expires = DateTime.Now.AddDays(daysToExpire.Value);
            }

            response.Cookies.Set(cookie);
        }

        // Public string getter
        public static string GetCookieProperty(HttpRequestBase request, string cookieName, string key, string defaultValue = null)
        {
            return GetCookieStringValue(request, cookieName, key, defaultValue);
        }

        // Private helper to avoid method name conflict
        private static string GetCookieStringValue(HttpRequestBase request, string cookieName, string key, string defaultValue = null)
        {
            HttpCookie cookie = request?.Cookies[cookieName];
            return cookie?[key] ?? defaultValue;
        }

        // Public int setter
        public static void SetCookieProperty(HttpRequestBase request, HttpResponseBase response, string cookieName, string key, int value, int? daysToExpire = 7)
        {
            SetCookieProperty(request, response, cookieName, key, value.ToString(), daysToExpire);
        }

        // Public int getter
        public static int GetCookieProperty(HttpRequestBase request, string cookieName, string key, int defaultValue = 0)
        {
            string value = GetCookieStringValue(request, cookieName, key);
            return int.TryParse(value, out int result) ? result : defaultValue;
        }

    }
}