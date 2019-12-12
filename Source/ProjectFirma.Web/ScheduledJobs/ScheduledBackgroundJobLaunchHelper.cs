namespace ProjectFirma.Web.ScheduledJobs
{
    /// <summary>
    /// When running jobs via Hangfire, the job execution is serialized.  Much better to have a static void function for that to avoid problems. This class provides the functions that can be wired to Hangire.
    /// </summary>
    public static class ScheduledBackgroundJobLaunchHelper
    {
        public static void RunProjectUpdateKickoffReminderScheduledBackgroundJob()
        {
            var projectUpdateReminderScheduledBackgroundJob = new ProjectUpdateReminderScheduledBackgroundJob();
            projectUpdateReminderScheduledBackgroundJob.RunJob();
        }

        public static void RunCleanUpStaleFirmaSessionsScheduledBackgroundJob()
        {
            var cleanUpStaleFirmaSessionsJob = new CleanUpStaleFirmaSessionsJob();
            cleanUpStaleFirmaSessionsJob.RunJob();
        }

    }
}
