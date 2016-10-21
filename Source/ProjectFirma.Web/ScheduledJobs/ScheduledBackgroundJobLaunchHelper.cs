namespace ProjectFirma.Web.ScheduledJobs
{
    /// <summary>
    /// When running jobs via Hangfire, the job execution is serialized.  Much better to have a static void function for that to avoid problems. This class provides the functions that can be wired to Hangire.
    /// </summary>
    public static class ScheduledBackgroundJobLaunchHelper
    {
        public static void RunProjectUpdateKickoffReminderScheduledBackgroundJob()
        {
            ProjectUpdateKickoffReminderScheduledBackgroundJob.Instance.RunJob();
        }
        public static void RunProjectUpdateSecondReminderScheduledBackgroundJob()
        {
            ProjectUpdateSecondReminderScheduledBackgroundJob.Instance.RunJob();
        }
        public static void RunProjectUpdateThirdReminderScheduledBackgroundJob()
        {
            ProjectUpdateThirdReminderScheduledBackgroundJob.Instance.RunJob();
        }
        public static void RunProjectUpdateNearingDeadlineReminderScheduledBackgroundJob()
        {
            ProjectUpdateNearingDeadlineReminderScheduledBackgroundJob.Instance.RunJob();
        }
        public static void RunProjectUpdateAtDeadlineReminderScheduledBackgroundJob()
        {
            ProjectUpdateAtDeadlineReminderScheduledBackgroundJob.Instance.RunJob();
        }
        public static void RunProjectUpdatePastDeadlineReminderScheduledBackgroundJob()
        {
            ProjectUpdatePastDeadlineReminderScheduledBackgroundJob.Instance.RunJob();
        }
    }
}