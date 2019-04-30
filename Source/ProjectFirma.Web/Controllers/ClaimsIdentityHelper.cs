using System;
using System.Web;
using Keystone.Common.OpenID;
using LtInfo.Common;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public static class ClaimsIdentityHelper
    {
        public const string AuthenticationApplicationCookieName = "PsInfoCookieIdentity";

        public static Person PersonFromClaimsIdentity(IAuthenticationManager authenticationManager)
        {
            try
            {
                return KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(
                    authenticationManager.User, PersonModelExtensions.GetAnonymousSitkaUser(),
                    HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid);
            }
            catch (Exception ex)
            {
                IdentitySignOut(authenticationManager);
                throw new SitkaDisplayErrorException("Something went wrong with your session or credentials. Please try logging in again. If this does not resolve the issue, please contact support.", ex);
            }
        }

        public static void IdentitySignOut(IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            var authenticationApplicationCookieName = $"{HttpRequestStorage.Tenant.TenantName}_{FirmaWebConfiguration.FirmaEnvironment.FirmaEnvironmentType}";
            HttpContext.Current.Request.Cookies.Remove(authenticationApplicationCookieName);
            HttpRequestStorage.Person = PersonModelExtensions.GetAnonymousSitkaUser();
        }
    }
}