using System;

namespace LtInfo.Common.Tasks
{
    /// <summary>
    /// All LtInfo Tasks should inherit from this not <see cref="SitkaTaskBase"/>
    /// </summary>
    public abstract class LtInfoTaskBase : SitkaTaskBase
    {
        public override TimeSpan TimeBetweenRuns
        {
            get { return TimeSpan.FromHours(1); }
        }

        public override DateTime GetTimeOfNextRun(DateTime dateTimeOfLastRun)
        {
            return TruncateToTheHour(dateTimeOfLastRun + TimeBetweenRuns);
        }

        /// <summary>
        /// For manually performed operations from UI threads
        /// </summary>
        public void PerformWork(DateTime timeOfThisRun)
        {
            Action<string> messageLoggingFunction = message =>
            {
                Logger.Info(message);
                //taurusContext.AddMessage(message);
            };

            // We lock here because we manually invoke PerformScheduledWork via a button, and therefore we could have a collison between
            // that and a background thread. This is separate from and in addition to the lock on the background thread launcher.
            lock (PerformWorkImplLock)
            {
                PerformWorkImpl(timeOfThisRun, messageLoggingFunction);
            }
        }

    }
}