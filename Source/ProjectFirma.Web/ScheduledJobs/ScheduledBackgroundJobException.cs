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
            return String.Format("Scheduled Background Job \"{0}\" encountered exception {1}: {2}.", jobName, innerException.GetType().Name, innerException.Message);
        }
    }
}