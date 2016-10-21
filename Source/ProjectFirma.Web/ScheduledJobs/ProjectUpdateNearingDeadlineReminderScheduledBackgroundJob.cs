using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob Instance;

        static ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob();
        }

        public ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob()
            : base(ReminderMessageType.NearingDeadlineReminder)
        {
        }
    }
}