using Hangfire.Dashboard;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class HangfireFirmaWebAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var person = HttpRequestStorage.Person;
            return person.IsAdministrator();
        }
    }
}
