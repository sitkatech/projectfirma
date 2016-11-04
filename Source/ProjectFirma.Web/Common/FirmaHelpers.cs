using System;
using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Common
{
    public static class FirmaHelpers
    {
        public static readonly List<string> DefaultColorRange = new List<string> {
            "#1f77b4",
            "#ff7f0e",
            "#aec7e8",
            "#ffbb78",
            "#2ca02c",
            "#98df8a",
            "#d62728",
            "#ff9896",
            "#9467bd",
            "#c5b0d5",
            "#022c99",
            "#507e3c",
            "#0d5875",
            "#37aba8",
            "#44cc44",
            "#afa5f2",
            "#d3ffce",
            "#070a41"
        };

        public static string GenerateLogInUrlWithReturnUrl()
        {
            var logInUrl = SitkaRoute<AccountController>.BuildUrlFromExpression(c => c.LogOn());

            var returnUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            return OnErrorOrNotFoundPage(returnUrl) ? logInUrl : string.Format("{0}?returnUrl={1}", logInUrl, HttpUtility.UrlEncode(returnUrl));
        }

        public static string GenerateLogOutUrlWithReturnUrl()
        {
            var logOutUrl = SitkaRoute<AccountController>.BuildAbsoluteUrlHttpsFromExpression(c => c.LogOff(), LtInfo.Common.FirmaWebConfiguration.CanonicalHostName);
            
            var returnUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            return OnErrorOrNotFoundPage(returnUrl) ? logOutUrl : String.Format("{0}?returnUrl={1}", logOutUrl, HttpUtility.UrlEncode(returnUrl));
        }

        private static bool OnErrorOrNotFoundPage(string url)
        {
            var returnUrlPathAndQuery = new Uri(url).PathAndQuery;
            var notFoundUrlPathAndQuery = new Uri(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.NotFound())).PathAndQuery;
            var errorUrlPathAndQuery = new Uri(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Error())).PathAndQuery;

            var onErrorOrNotFoundPage = returnUrlPathAndQuery.StartsWith(notFoundUrlPathAndQuery, StringComparison.InvariantCultureIgnoreCase) ||
                                        returnUrlPathAndQuery.StartsWith(errorUrlPathAndQuery, StringComparison.InvariantCultureIgnoreCase);
            return onErrorOrNotFoundPage;
        }
    }
}