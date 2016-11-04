namespace LtInfo.Common.LoggingFilters
{
    public interface ISitkaLoggingFilter
    {
        bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo);
    }
}