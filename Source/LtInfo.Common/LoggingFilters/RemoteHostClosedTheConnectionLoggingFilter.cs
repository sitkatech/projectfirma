using System;

namespace LtInfo.Common.LoggingFilters
{
    public class RemoteHostClosedTheConnectionLoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            if (requestInfo.OriginalException is System.Web.HttpException)
            {
                return requestInfo.OriginalException.Message.Contains("The remote host closed the connection", StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
    }
}