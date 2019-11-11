using System;
using System.Linq;
using System.Web;
using Keystone.Common.OpenID;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
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

        public static FirmaSession FirmaSessionFromClaimsIdentity(IAuthenticationManager authenticationManager, Tenant currentTenant)
        {
            try
            {
                // Get the Person from Claims Identity
                //var personFromClaimsIdentity = KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(
                //    authenticationManager.User, PersonModelExtensions.GetAnonymousSitkaUser(),
                //    HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid);

                // Other RPs use an actual "anonymous" user, but we are trying to have CurrentPerson be null, so, we are trying this. -- SLG & SG
                const Person anonymousSitkaUser = null;
                var personFromClaimsIdentity = KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(
                    authenticationManager.User, anonymousSitkaUser,
                    HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid);

                // Actual real person
                if (personFromClaimsIdentity != null)
                {
                    // Sanity check
                    Check.Ensure(currentTenant.TenantID == personFromClaimsIdentity.TenantID);

                    // Try to find existing Session for this Person.
                    // ** This seems potentially flawed, and may not work for multiple logins -- SLG & SG **
                    var firmaSessionForRealPerson = HttpRequestStorage.DatabaseEntities.FirmaSessions.GetFirmaSessionsByPersonID(personFromClaimsIdentity.PersonID, false);
                    if (firmaSessionForRealPerson.Any())
                    {
                        // For now, we just give them the last session. This is NOT a long term solution. -- SLG
                        return firmaSessionForRealPerson.Last();
                    }
                    // Otherwise, we could not find a FirmaSession for this person. Create one.
                    var firmaSessionFromClaimsIdentity = new FirmaSession(personFromClaimsIdentity);

                    // Only save if the Session if it being newly created
                    HttpRequestStorage.DatabaseEntities.AllFirmaSessions.Add(firmaSessionFromClaimsIdentity);
                    HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(currentTenant.TenantID);

                    return firmaSessionFromClaimsIdentity;
                }
                // Otherwise, anonymous user. We make a new session each time, which seems flawed - but not sure how else to handle yet. -- SLG
                var firmaSessionForAnonymousPerson = FirmaSession.MakeEmptyFirmaSession(HttpRequestStorage.Tenant);
                return firmaSessionForAnonymousPerson;
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
            HttpRequestStorage.FirmaSession.Person = null;
            HttpRequestStorage.FirmaSession.OriginalPerson = null;
        }


    }
}