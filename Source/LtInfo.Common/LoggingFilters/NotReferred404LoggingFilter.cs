using System;
using System.Net;
using System.Web;

namespace LtInfo.Common.LoggingFilters
{
    public class NotReferred404LoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            //should be filtered if status code is 404 and there is no referrer
            if (requestInfo.OriginalException is HttpException)
            {
                var http = (HttpException) requestInfo.OriginalException;
                return (http.GetHttpCode() == (int)HttpStatusCode.NotFound &&
                        (requestInfo.UrlReferrer == null ||
                         String.IsNullOrWhiteSpace(requestInfo.UrlReferrer.ToString())));
            }

            //should also be filtered out if exception is SitkaRecordNotFoundException and there is no referrer
            if (requestInfo.OriginalException is SitkaRecordNotFoundException)
            {
                return (requestInfo.UrlReferrer == null || String.IsNullOrWhiteSpace(requestInfo.UrlReferrer.ToString()));
            }

            return false;
        }
    }
}
