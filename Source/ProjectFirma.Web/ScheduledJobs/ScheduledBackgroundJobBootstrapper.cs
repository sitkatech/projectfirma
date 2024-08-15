using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Storage;
using Owin;
using ProjectFirma.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using NUnit.Framework;
using ProjectFirma.Web.ScheduledJobs;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.ScheduledJobs
{
    /// <summary>
    /// All the logic to get the Corral Scheduled Jobs wired up in <see cref="Hangfire"/>
    /// </summary>
    public class ScheduledBackgroundJobBootstrapper
    {
        /// <summary>
        /// Configuration entry point for <see cref="FirmaOwinStartup"/> via the <see cref="Microsoft.Owin.OwinStartupAttribute"/>
        /// </summary>
        public static void ConfigureHangfireAndScheduledBackgroundJobs(IAppBuilder app)
        {
            ConfigureHangfire(app);
            ConfigureScheduledBackgroundJobs();
        }

        /// <summary>
        /// Setup the basics for <see cref="Hangfire"/>, database connectivity and security on urls
        /// </summary>
        private static void ConfigureHangfire(IAppBuilder app)
        {
            Thread.Sleep(1000);
            var sqlServerStorageOptions = new SqlServerStorageOptions
            {
                // We have scripted out the Hangfire tables, so we tell Hangfire not to insert them. 
                // This might be an issue when Hangfire does a change to its schema, but this should work for now.
                PrepareSchemaIfNecessary = false
            };
            GlobalConfiguration.Configuration.UseSqlServerStorage(FirmaWebConfiguration.DatabaseConnectionString,
                sqlServerStorageOptions);
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1,
                Queues = new[] {"critical","default"},
                ServerName = "ProjectFirma:1337"
            }); // 11/03/2015 MF - limit the number of worker threads, we really don't need that many - in fact we try to have each job run serially for the time being because we're not sure how concurrent the different jobs could really be.

            // Hangfire defaults to 10 retries for failed jobs; this disables that behavior by doing no automatic retries.
            // http://hangfire.readthedocs.org/en/latest/background-processing/dealing-with-exceptions.html
            // Note that specific jobs may override this; look for uses of the AutomaticRetry symbol on specific job start functions.
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
        }

        /// <summary>
        /// Set up the jobs particular to this application
        /// </summary>
        private static void ConfigureScheduledBackgroundJobs()
        {
            var recurringJobIds = new List<string>();

            // because the reminder configurations are tenant-specific and user-configurable, just schedule the job to run nightly and have it check whether it's time to send a remind for each tenant.
            AddRecurringJob(ProjectUpdateReminderScheduledBackgroundJob.ScheduledBackgroundJobName,
                () => ScheduledBackgroundJobLaunchHelper.RunProjectUpdateKickoffReminderScheduledBackgroundJob(),
                MakeDailyUtcCronJobStringFromLocalTime(1,23),
                recurringJobIds);

            AddRecurringJob(SyncProjectsForTscProjectTrackerBackgroundJob.ScheduledBackgroundJobName,
                () => ScheduledBackgroundJobLaunchHelper.RunSyncProjectsForTscProjectTrackerBackgroundJob(),
                MakeDailyUtcCronJobStringFromLocalTime(2, 00),
                recurringJobIds);

            // Clean up stale FirmaSessions
            AddRecurringJob(CleanUpStaleFirmaSessionsJob.ScheduledBackgroundJobName,
                () => ScheduledBackgroundJobLaunchHelper.RunCleanUpStaleFirmaSessionsScheduledBackgroundJob(),
                Cron.Hourly(10), 
                recurringJobIds);

            // Remove any jobs we haven't explicitly scheduled
            RemoveExtraneousJobs(recurringJobIds);
        }

        private static void AddRecurringJob(string jobName, Expression<Action> methodCallExpression,
            string cronExpression, List<string> recurringJobIds)
        {
            RecurringJob.AddOrUpdate(jobName, methodCallExpression, cronExpression);
            recurringJobIds.Add(jobName);
        }

        private static void RemoveExtraneousJobs(List<string> recurringJobIds)
        {
            using (var connection = JobStorage.Current.GetConnection())
            {
                var recurringJobs = connection.GetRecurringJobs();
                var jobsToRemove = recurringJobs.Where(x => !recurringJobIds.Contains(x.Id)).ToList();
                foreach (var job in jobsToRemove)
                {
                    RecurringJob.RemoveIfExists(job.Id);
                }
            }
        }

        /// <summary>
        /// Hangfire defaults to a UTC time, so here convert from local time to UTC, then use the equivalent
        /// UTC time to create a cron string.
        /// 
        /// Since SetUpBackgroundHangfireJobs should be re-run when the webserver restarts, this should get
        /// updated enough to handle the problems associated with DST/UTC/TimeZone conversions. At the least,
        /// problems won't hang around for too long since AddOrUpdate will adjust the time to be the correct one
        /// after a DST change. -- SLG 03/16/2015
        /// </summary>
        private static string MakeDailyUtcCronJobStringFromLocalTime(int hour, int minute)
        {
            var utcCronTime = MakeUtcCronTime(hour, minute);
            return Cron.Daily(utcCronTime.Hour, utcCronTime.Minute);
        }

        private static string MakeYearlyUtcCronJobStringFromLocalTime(int month, int day, int hour, int minute)
        {
            var utcCronTime = MakeUtcCronTime(month, day, hour, minute);
            return Cron.Yearly(utcCronTime.Month, utcCronTime.Day, utcCronTime.Hour, utcCronTime.Minute);
        }

        private static DateTime MakeUtcCronTime(int hour, int minute)
        {
            var now = DateTime.Now;
            return MakeUtcCronTime(now.Year, now.Month, now.Day, hour, minute);
        }

        private static DateTime MakeUtcCronTime(int month, int day, int hour, int minute)
        {
            var now = DateTime.Now;
            return MakeUtcCronTime(now.Year, month, day, hour, minute);
        }

        internal static DateTime MakeUtcCronTime(int year, int month, int day, int hour, int minute)
        {
            TimeZoneInfo tz = TimeZoneInfo.Local; // getting the current system timezone
            DateTime localCronTime = new DateTime(year, month, day, hour, minute, 0, DateTimeKind.Local);

            // Catch cases where time is invalid or ambiguous due to daylight savings
            // 3/8/20 2am becomes 3am (so 2am – 3am in invalid)
            // 11/1/20 2am becomes 1am(so 1am – 2am is ambiguous)
            if (tz.IsAmbiguousTime(localCronTime) || tz.IsInvalidTime(localCronTime))
            {
                localCronTime = localCronTime.Add(TimeSpan.Parse("1:01:00"));

                // Make sure we've fixed the issue
                Check.Ensure(!tz.IsAmbiguousTime(localCronTime));
                Check.Ensure(!tz.IsInvalidTime(localCronTime));
            }

            var utcCronTime = TimeZoneInfo.ConvertTimeToUtc(localCronTime);
            return utcCronTime;
        }
    }
}

[TestFixture]
public class ScheduledBackgroundJobBootstrapperTest
{
    [Test]
    public void HandlesAmbiguousDaylightSavingsTimeWhenSchedulingJobs()
    {
        DateTime ambiguousDateTime = DateTime.Parse("11/01/2020 01:15:00");
        Assert.That(TimeZoneInfo.Local.IsAmbiguousTime(ambiguousDateTime), "This test requires an ambiguous time.");
        Assert.That(ScheduledBackgroundJobBootstrapper.MakeUtcCronTime(ambiguousDateTime.Year, ambiguousDateTime.Month, ambiguousDateTime.Day, ambiguousDateTime.Hour, ambiguousDateTime.Minute), Is.EqualTo(DateTime.Parse("11/01/2020 10:16:00")),
            "Given an ambiguous time, move the local time ahead 1 hour and 1 minute before converting to UTC");
    }

    [Test]
    public void HandlesinvalidDaylightSavingsTimeWhenSchedulingJobs()
    {
        DateTime invalidDateTime = DateTime.Parse("03/08/2020 02:15:00");
        Assert.That(TimeZoneInfo.Local.IsInvalidTime(invalidDateTime), "This test requires an invalid time.");
        Assert.That(ScheduledBackgroundJobBootstrapper.MakeUtcCronTime(invalidDateTime.Year, invalidDateTime.Month, invalidDateTime.Day, invalidDateTime.Hour, invalidDateTime.Minute), Is.EqualTo(DateTime.Parse("03/08/2020 10:16:00")),
            "Given an invalid time, move the local time ahead 1 hour and 1 minute before converting to UTC");
    }

    [Test]
    public void HandlesNonAmbiguousAndValidTimeWhenSchedulingJobs()
    {
        DateTime ambiguousDateTime = DateTime.Parse("11/01/2020 12:30:00");
        Assert.That(ScheduledBackgroundJobBootstrapper.MakeUtcCronTime(ambiguousDateTime.Year, ambiguousDateTime.Month, ambiguousDateTime.Day, ambiguousDateTime.Hour, ambiguousDateTime.Minute), Is.EqualTo(DateTime.Parse("11/01/2020 20:30:00")),
            "Given an non-ambiguous and valid time, time remains the same local time before converting to UTC");
    }
}