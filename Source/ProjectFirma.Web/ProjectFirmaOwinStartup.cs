using ProjectFirma.Web;
using ProjectFirma.Web.ScheduledJobs;
using Microsoft.Owin;
using Owin;

// This is how Owin figures out the class to call on startup
[assembly: OwinStartup(typeof(ProjectFirmaOwinStartup))]

namespace ProjectFirma.Web
{
    /// <summary>
    /// Owin Startup for ProjectFirma
    /// </summary>
    public class ProjectFirmaOwinStartup
    {
        /// <summary>
        /// Function required by <see cref="OwinStartupAttribute"/>
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            ScheduledBackgroundJobBootstrapper.ConfigureHangfireAndScheduledBackgroundJobs(app);
        }
    }
}