using Hangfire.Dashboard;
using Keystone.Common.OpenID;
using Microsoft.Owin;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class HangfireFirmaWebAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var owinContext = new OwinContext(context.GetOwinEnvironment());
            var person = KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(owinContext.Authentication.User,
                null,
                HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid);
            return person.IsAdministrator();
        }
    }
}
