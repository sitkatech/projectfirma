using System;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ScheduledBackgroundJobException : Exception
    {
        public ScheduledBackgroundJobException(string jobName, Exception innerException)
            : base(FormatMessage(jobName, innerException), innerException)
        {
        }

        private static string FormatMessage(string jobName, Exception innerException)
        {
            return $"Scheduled Background Job \"{jobName}\" encountered exception {innerException.GetType().Name}: {innerException.Message}.";
        }
    }
}