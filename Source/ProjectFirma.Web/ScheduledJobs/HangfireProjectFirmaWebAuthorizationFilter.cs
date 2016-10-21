using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using Hangfire.Dashboard;

namespace ProjectFirma.Web.ScheduledJobs
{
    /// <summary>
    /// How the web ui mangement urls are protected for <see cref="Hangfire"/>
    /// </summary>
    public class HangfireProjectFirmaWebAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            var person = HttpRequestStorage.Person;
            return person.IsAdministrator();
        }
    }
}