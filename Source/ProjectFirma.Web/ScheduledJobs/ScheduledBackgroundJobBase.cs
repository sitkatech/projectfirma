using System;
using log4net;

namespace ProjectFirma.Web.ScheduledJobs
{
    /// <summary>
    /// Base class for all jobs, handles the basic setup so jobs can focus on work to be done
    /// </summary>
    public abstract class ScheduledBackgroundJobBase
    {
        /// <summary>
        /// A safety guard to ensure only one job is running at a time, some jobs seem like they would collide if allowed to run concurrently or possibly drag the server down.
        /// </summary>
        public static readonly object ScheduledBackgroundJobLock = new object();

        public readonly string JobName;
        protected readonly ILog Logger;

        protected ScheduledBackgroundJobBase(string jobName)
        {
            JobName = jobName;
            Logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// This wraps the call to <see cref="RunJobImplementation"/> with all of the housekeeping for being a scheduled job.
        /// </summary>
        public void RunJob()
        {
            lock (ScheduledBackgroundJobLock)
            {
                try
                {
                    Logger.Info(String.Format("Begin ProjectFirma Job {0}", JobName));
                    RunJobImplementation();
                    Logger.Info(String.Format("End ProjectFirma Job {0}", JobName));
                }
                catch (Exception ex)
                {
                    // Wrap and rethrow with the information about which job encountered the problem
                    throw new ScheduledBackgroundJobException(JobName, ex);
                }
            }
        }

        /// <summary>
        /// Jobs can fill this in with whatever they need to run. This is called by <see cref="RunJob"/> which handles other miscellaneous stuff
        /// </summary>
        protected abstract void RunJobImplementation();
    }
}