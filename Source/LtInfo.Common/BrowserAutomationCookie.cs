/*-----------------------------------------------------------------------
<copyright file="BrowserAutomationCookie.cs" company="Sitka Technology Group">
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
using System.Linq;
using System.Web;

namespace LtInfo.Common
{
    public static class BrowserAutomationCookie
    {
        private const string IsWebBrowserRunningUnderTestAutomationCookieName = "IsWebBrowserRunningUnderTestAutomationCookie";
        public static bool IsRunningUnderWebBrowserAutomation()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                return false;
            }
            return httpContext.Request.Cookies.AllKeys.Contains(IsWebBrowserRunningUnderTestAutomationCookieName);
        }

        /// <summary>
        /// Temporarily sets things *as if* it were running under web browser automation for this request, even if the request wasn't really
        /// </summary>
        public static void SetIsRunningUnderWebBrowserAutomation()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                return;
            }
            SetCookieIsRunningUnderWebBrowserAutomation(httpContext.Request.Cookies);
        }

        public static void SetCookieIsRunningUnderWebBrowserAutomation(HttpCookieCollection httpCookieCollection)
        {
            httpCookieCollection.Add(new HttpCookie(IsWebBrowserRunningUnderTestAutomationCookieName));
        }

    }
}
