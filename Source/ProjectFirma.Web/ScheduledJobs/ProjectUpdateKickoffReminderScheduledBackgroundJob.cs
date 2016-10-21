using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateKickoffReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        public static ProjectUpdateKickoffReminderScheduledBackgroundJob Instance;

        static ProjectUpdateKickoffReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateKickoffReminderScheduledBackgroundJob();
        }

        public ProjectUpdateKickoffReminderScheduledBackgroundJob()
            : base(ReminderMessageType.KickoffReminder)
        {
        }
    }
}