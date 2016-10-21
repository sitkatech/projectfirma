using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateAtDeadlineReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateAtDeadlineReminderScheduledBackgroundJob Instance;

        static ProjectUpdateAtDeadlineReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateAtDeadlineReminderScheduledBackgroundJob();
        }

        public ProjectUpdateAtDeadlineReminderScheduledBackgroundJob()
            : base(ReminderMessageType.AtDeadlineReminder)
        {
        }
    }
}