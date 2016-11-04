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