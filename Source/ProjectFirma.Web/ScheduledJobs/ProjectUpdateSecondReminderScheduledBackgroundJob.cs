using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateSecondReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateSecondReminderScheduledBackgroundJob Instance;

        static ProjectUpdateSecondReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateSecondReminderScheduledBackgroundJob();
        }

        public ProjectUpdateSecondReminderScheduledBackgroundJob()
            : base(ReminderMessageType.SecondReminder)
        {
        }
    }
}