using System.Net;

namespace LtInfo.Common.LoggingFilters
{
    public class SitkaDisplayExceptionWith503ServiceUnavailable503LoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            // Should be filtered if:
            // - This is a display exception with a HTTP code
            // - that HTTP code is 503 - Service Unavailable
            if (requestInfo.OriginalException is SitkaDisplayErrorExceptionWithHttpCode)
            {
                var exception = (SitkaDisplayErrorExceptionWithHttpCode)requestInfo.OriginalException;
                return (exception.HttpStatusCode == HttpStatusCode.ServiceUnavailable);
            }

            return false;
        }
    }
}
