namespace LtInfo.Common.LoggingFilters
{
    public class NagiosLoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            return (requestInfo.UserAgent ?? string.Empty).ToLower().Contains("nagios");
        }
    }
}
