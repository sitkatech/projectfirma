using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateThirdReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateThirdReminderScheduledBackgroundJob Instance;

        static ProjectUpdateThirdReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateThirdReminderScheduledBackgroundJob();
        }

        public ProjectUpdateThirdReminderScheduledBackgroundJob()
            : base(ReminderMessageType.ThirdReminder)
        {
        }
    }
}