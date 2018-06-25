using System.Collections.Generic;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateReminderScheduledBackgroundJob Instance;

        public override List<FirmaEnvironmentType> RunEnvironments => new List<FirmaEnvironmentType> { FirmaEnvironmentType.Local, FirmaEnvironmentType.Qa, FirmaEnvironmentType.Prod };

        static ProjectUpdateReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateReminderScheduledBackgroundJob();
        }

        public ProjectUpdateReminderScheduledBackgroundJob()
            : base()
        {
        }
    }
}