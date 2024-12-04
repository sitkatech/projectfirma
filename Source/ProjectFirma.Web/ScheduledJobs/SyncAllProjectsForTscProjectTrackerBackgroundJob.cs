using System.Threading.Tasks;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class SyncAllProjectsForTscProjectTrackerBackgroundJob  : SyncProjectsForTscProjectTrackerBackgroundJob
    {
        public new const string ScheduledBackgroundJobName = "Sync All Projects For TCS Project Tracker";

        public SyncAllProjectsForTscProjectTrackerBackgroundJob() : base(ScheduledBackgroundJobName)
        {
        }

        protected override async Task RunJobImplementationAsync()
        {
            await RunSyncJobImplementationAsync("all-projects", false);
        }
    }
}
