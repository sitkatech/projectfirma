using log4net;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using System;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace ProjectFirma.Web.Session
{
    public class FirmaWebSession
    {
        public const string FirmaSessionBaseCookieName = "__Host-FirmaSessionCookie";
        private static readonly ILog Logger = LogManager.GetLogger(typeof(FirmaWebSession));

        /// <summary>
        /// This string just needs to be the same for <see cref="MachineKey.Protect"/> and <see cref="MachineKey.Unprotect"/>
        /// </summary>
        private const string EncryptionPurposeString = "mykey";

        public static string GetTenantizedFirmaSessionCookieName(Tenant tenant)
        {
            return $"{FirmaSessionBaseCookieName}_tenant_{tenant.TenantID}";
        }

        public static FirmaSession GetSessionFromCookie(AuthenticationContext filterContext, Tenant currentTenant)
        {
            var httpCookieCollection = filterContext.RequestContext.HttpContext.Request.Cookies;
            if (IsSessionCookiePresentAndValid(currentTenant, httpCookieCollection))
            {
                var FirmaSessionGuid = ParseSessionCookie(httpCookieCollection[GetTenantizedFirmaSessionCookieName(currentTenant)]);

            }

            // HACK just to get airborne!
            // Otherwise, anonymous user. We make a new session each time, which seems flawed - but not sure how else to handle yet. -- SLG
            var firmaSessionForAnonymousPerson = FirmaSession.MakeEmptyFirmaSession(HttpRequestStorage.DatabaseEntities, HttpRequestStorage.Tenant);
            return firmaSessionForAnonymousPerson;
        }

        public static Guid ParseSessionCookie(HttpCookie httpCookie)
        {
            var sessionGuidEncryptedAsByteArray = GeneralUtility.HexStringToBytes(httpCookie.Value);
            var sessionGuidUnencrypted = MachineKey.Unprotect(sessionGuidEncryptedAsByteArray, EncryptionPurposeString);
            return new Guid(sessionGuidUnencrypted);
        }

        public static bool IsSessionCookiePresentAndValid(Tenant currentTenant, HttpCookieCollection httpCookieCollection)
        {
            var tenantizedFirmaWebSessionCookieName = FirmaWebSession.GetTenantizedFirmaSessionCookieName(currentTenant);
            var httpCookie = httpCookieCollection[tenantizedFirmaWebSessionCookieName];
            var sessionCookieExists = (httpCookie != null);
            if (!sessionCookieExists)
            {
                return false;
            }
            try
            {
                ParseSessionCookie(httpCookie);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}