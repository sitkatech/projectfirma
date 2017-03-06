/*-----------------------------------------------------------------------
<copyright file="SitkaTaskBase.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Threading;
using System.Web.Hosting;
using LtInfo.Common.DesignByContract;
using log4net;

namespace LtInfo.Common.Tasks
{
    public abstract class SitkaTaskBase : IRegisteredObject
    {
        protected readonly ILog Logger = LogManager.GetLogger(typeof(SitkaTaskBase));
        protected readonly object PerformWorkImplLock = new object();
        private string _lastRunningThreadName;
        private int _lastRunningManagedThreadId;
        private readonly ManualResetEvent _stopHasBeenCalledEvent = new ManualResetEvent(false);
        private readonly ManualResetEvent _mainThreadIsNotRunningEvent = new ManualResetEvent(true);

        protected SitkaTaskBase()
        {
            HostingEnvironment.RegisterObject(this);
        }

        public virtual string TaskName
        {
            get
            {
                // Use the type as a default name
                return GetType().Name;
            }
        }

        public virtual string TaskDescription
        {
            get
            {
                // Default to task name again.
                return TaskName;
            }
        }

        /// <summary>
        /// Should this task run right away on application start up?
        /// </summary>
        protected virtual bool ShouldRunRightAwayOnApplicationStartup
        {
            get { return true; }
        }

        /// <summary>
        /// Is this task currently running? 
        /// </summary>
        private bool _isRunning;

        
        /// <summary>
        /// Is this task currently running? Not threadsafe, so only use for display, not logic.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsRunning
        {
            get { return _isRunning; }
        }

        /// <summary>
        /// Human readable task status : Running, last run, etc.
        /// </summary>
        /// <returns></returns>
        public virtual string GetStatus()
        {
            return IsRunning ? "Running" : "Not Running";
        }

        /// <summary>
        /// Time between runs, if scheduled
        /// </summary>
        public abstract TimeSpan TimeBetweenRuns { get; }

        /// <summary>
        /// Time of next run, if scheduled
        /// </summary>
        public abstract DateTime GetTimeOfNextRun(DateTime dateTimeOfLastRun);

        private string TaskIdentifierForLogging
        {
            get { return String.Format("TaskName: {0}, ThreadName: {1}, ManagedThreadId: {2}", TaskName, Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId); }
        }

        /// <summary>
        /// Perform the work repeatedly, waiting until an interval elapses between runs
        /// </summary>
        public void PerformScheduledWorkRepeatedlyThreadStart()
        {
            _mainThreadIsNotRunningEvent.Reset();
            Logger.Info(String.Format("Beginning thread on {0}", TaskIdentifierForLogging));

            var timeOfThisRun = DateTime.Now;

            Logger.Info(String.Format("Thread is set to run on startup: {0} for {1}", ShouldRunRightAwayOnApplicationStartup, TaskIdentifierForLogging));
            var doPerformWork = ShouldRunRightAwayOnApplicationStartup;
            
            _lastRunningManagedThreadId = Thread.CurrentThread.ManagedThreadId;
            _lastRunningThreadName = Thread.CurrentThread.Name;

            while (!ShouldBeStopped())
            {
                // On first run only run tasks that are marked for running *immediately*
                if (doPerformWork)
                {
                    Logger.Info(String.Format("Beginning PerformWork on {0}", TaskIdentifierForLogging));
                    try
                    {
                        PerformWork(timeOfThisRun);
                    }
                    catch (Exception ex)
                    {
                        // log and continue
                        Logger.Error(String.Format("Exception PerformWork on {0}", TaskIdentifierForLogging), ex);
                    }
                    Logger.Info(String.Format("Ending PerformWork on {0}. StartTime: {1}, EndTime: {2}, ElapsedTime: {3}", TaskIdentifierForLogging, timeOfThisRun, DateTime.Now, DateTime.Now - timeOfThisRun));
                }
                try
                {
                    // Schedule for the next run time
                    var timeOfNextRun = GetTimeOfNextRun(timeOfThisRun);
                    var now = DateTime.Now;

                    // if the next schedule time's already passed
                    if (timeOfNextRun < now)
                    {
                        // Schedule for the run time from now
                        timeOfNextRun = GetTimeOfNextRun(now);
                    }
                    Logger.Info(String.Format("Scheduling PerformWork on {0} for {1}", TaskIdentifierForLogging, timeOfNextRun));

                    WaitUntilNextRunTimeOrStopSignal(timeOfNextRun);

                    timeOfThisRun = timeOfNextRun;
                    doPerformWork = true;
                }
                catch (Exception ex)
                {
                    // Something weird happened. Log error, suppress exception, and break out to exit this worker thread.
                    Logger.Error(String.Format("Unexpected exception in task controller logic on {0}, failed with exception: {1}", TaskIdentifierForLogging, ex.Message), ex);                        
                    break;
                }
            }

            Logger.Info(String.Format("Ending thread on {0}", TaskIdentifierForLogging));
            _mainThreadIsNotRunningEvent.Set();
        }

        private static readonly object LaunchBackgroundThreadIfNeededLock = new object();

        /// <summary>
        /// Perform the work once in a background thread
        /// </summary>
        public static void PerformWorkOnceWithThread(ref Thread thread, ThreadStart threadStart, string threadName)
        {
            ILog logger = LogManager.GetLogger(typeof(SitkaTaskBase));

            lock (LaunchBackgroundThreadIfNeededLock)
            {
                // If thread has been previously created..
                if (thread != null && thread.ThreadState != ThreadState.Stopped)
                {
                    // If thread is not outright stopped, we will wait for it to complete, and we don't attempt to restart it
                    return;
                }

                // start up a background thread for running scheduled tasks 
                // IsBackground is set to true so that when IIS is unloading the ASP.NET Application Domain the ThreadAbort exception can shutdown the thread
                var worker = new Thread(threadStart) { Name = threadName, IsBackground = true };
                worker.Start();
                thread = worker;

                logger.Info(string.Format("Started new background scheduled task thread: {0} {1}", worker.Name, worker.ManagedThreadId));
            }
        }

        /// <summary>
        /// Thread Start function for performing the work once in a background thread
        /// </summary>
        public void PerformWorkOnceThreadStart()
        {
            _mainThreadIsNotRunningEvent.Reset();
            Logger.Info(String.Format("Beginning thread on {0}", TaskIdentifierForLogging));

            var timeOfThisRun = DateTime.Now;

            _lastRunningManagedThreadId = Thread.CurrentThread.ManagedThreadId;
            _lastRunningThreadName = Thread.CurrentThread.Name;

            Logger.Info(String.Format("Beginning PerformWork on {0}", TaskIdentifierForLogging));
            try
            {
                PerformWork(timeOfThisRun);
            }
            catch (Exception ex)
            {
                // log and continue
                Logger.Error(String.Format("Exception in PerformWork on {0}", TaskIdentifierForLogging), ex);
            }
            Logger.Info(String.Format("Ending PerformWork on {0}. StartTime: {1}, EndTime: {2}, ElapsedTime: {3}", TaskIdentifierForLogging, timeOfThisRun, DateTime.Now, DateTime.Now - timeOfThisRun));

            Logger.Info(String.Format("Ending thread on {0}", TaskIdentifierForLogging));
            _mainThreadIsNotRunningEvent.Set();
        }

        /// <summary>
        /// Signal that <see cref="Stop"/> has been called, can be used by task to quit early
        /// </summary>
        protected bool ShouldBeStopped()
        {
            return _stopHasBeenCalledEvent.WaitOne(TimeSpan.Zero);
        }

        /// <summary>
        /// Wait until the next time to run OR that a <see cref="Stop"/> signal has been received
        /// </summary>
        private void WaitUntilNextRunTimeOrStopSignal(DateTime timeOfNextRun)
        {
            var waitDuration = timeOfNextRun - DateTime.Now;
            if (waitDuration > TimeSpan.Zero)
            {
                // Sleep until next run (but wake up right away if stop is signalled so we can exit out)
                _stopHasBeenCalledEvent.WaitOne(waitDuration);
            }
        }

        /// <summary>
        /// Do the work starting right now
        /// </summary>
        public void PerformWork()
        {
            PerformWork(DateTime.Now);
        }

        /// <summary>
        /// Do the work
        /// </summary>
        private void PerformWork(DateTime timeOfThisRun)
        {
            PerformWorkWithLockWrapper(() => PerformWorkImpl(timeOfThisRun, Logger.Info));
        }

        protected void PerformWorkWithLockWrapper(Action workFunctionDelegate)
        {
            // We lock here because we manually invoke PerformScheduledWork via a button, and therefore we could have a collison between
            // that and a background thread. This is separate from and in addition to the lock on the background thread launcher.
            lock (PerformWorkImplLock)
            {
                if (ShouldBeStopped())
                {
                    Logger.Info(String.Format("Skipping work because Stop() was called on {0}", TaskIdentifierForLogging));
                    return;
                }

                _isRunning = true;

                try
                {
                    workFunctionDelegate();
                }
                finally
                {
                    _isRunning = false;
                }
            }
        }

        /// <summary>
        /// Derived classes implement this. This is where the work gets done.
        /// </summary>
        protected abstract void PerformWorkImpl(DateTime timeOfThisRun, Action<string> messageLoggingFunction);

        #region Time interval functions

        protected static DateTime TruncateToTheHour(DateTime dateTimeToTruncate)
        {
            return TruncateDate(dateTimeToTruncate, true, true, false, false, false);
        }

        protected static DateTime TruncateToTheDay(DateTime dateTimeToTruncate)
        {
            return TruncateDate(dateTimeToTruncate, true, true, true, false, false);
        }

        protected static DateTime TruncateDate(DateTime dateTimeToTruncate, bool truncateSeconds, bool truncateMinutes, bool truncateHours, bool truncateDays, bool truncateMonths)
        {
            return new DateTime(dateTimeToTruncate.Year, truncateMonths ? 1 : dateTimeToTruncate.Month, truncateDays ? 1 : dateTimeToTruncate.Day,
                truncateHours ? 0 : dateTimeToTruncate.Hour, truncateMinutes ? 0 : dateTimeToTruncate.Minute, truncateSeconds ? 0 : dateTimeToTruncate.Second);
        }

        #endregion Time interval functions

        public virtual void Stop(bool immediate)
        {
            Logger.Info(String.Format("IRegisteredObject.Stop() - Beginning Stop() for thread \"{0} (ManagedThreadId {1})\" Immediate: {2}", _lastRunningThreadName, _lastRunningManagedThreadId, immediate));

            // Signal the worker thread to stop
            _stopHasBeenCalledEvent.Set();

            // Wait for any impending work to complete
            lock (PerformWorkImplLock)
            {
                // Wait for the thread to try to exit itself gracefully
                var exitedGracefully = _mainThreadIsNotRunningEvent.WaitOne(TimeSpan.FromMinutes(1));

                if (!exitedGracefully)
                {
                    Logger.Error(String.Format("IRegisteredObject.Stop() - thread did not exit in response to stop event. App shutdown will proceed possibly terminating thread abruptly or via ThreaAbortException. Thread \"{0} (ManagedThreadId {1})\" Immediate: {2}", _lastRunningThreadName, _lastRunningManagedThreadId, immediate));
                }
            }
            HostingEnvironment.UnregisterObject(this);
            Logger.Info(String.Format("IRegisteredObject.Stop() - Ending Stop() for thread \"{0} (ManagedThreadId {1})\" Immediate: {2}", _lastRunningThreadName, _lastRunningManagedThreadId, immediate));
        }

        /// <summary>
        /// This function gives the next time for a daily run of a task at a certain time.
        /// 
        /// For example if you had a task that ran at 1:30 AM every day, this function tells you the next
        /// DateTime this task should run.
        /// </summary>
        /// <param name="now">Normally the actual current time, but can be set manually for testing</param>
        /// <param name="timeOfLastRun">Time the last run occurred. (This can be fudged, but that's the intended meaning)</param>
        /// <param name="timeOfDayToRun">Hour/minute in the day to run at</param>
        /// <returns>Time that next run should occur</returns>
        public static DateTime TimeOfNextRunForDailyRun(DateTime now, DateTime timeOfLastRun, TimeSpan timeOfDayToRun)
        {
            Check.Require(timeOfDayToRun >= TimeSpan.Zero && timeOfDayToRun < TimeSpan.FromDays(1), "The time of day {0} is not within range. Must be positive timespan less than 24hrs.");

            // If this "impossible" situation arising in which the *last* run is somehow in the future...
            if(timeOfLastRun > now)
            {
                // Ignore last run and trust the "now" time as being last run
                timeOfLastRun = now;
            }

            var justDateOfLastRun = timeOfLastRun.Date;
            var nextRunDateTime = justDateOfLastRun + timeOfDayToRun;
            if (now > nextRunDateTime)
            {
                if (now.TimeOfDay < timeOfDayToRun)
                {
                    nextRunDateTime = now.Date + timeOfDayToRun;
                }
                else
                {
                    nextRunDateTime = now.Date + timeOfDayToRun + TimeSpan.FromDays(1);
                }
            }
            return nextRunDateTime;
        }
    }
}
