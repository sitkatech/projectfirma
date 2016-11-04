namespace LtInfo.Common.LoggingFilters
{
    public class RequireSslLoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            // we were checking for the error message, but then it would give an error like: Http Server is returning response status code "500 Internal Server Error" and error was not logged via the Application_Error method
            // so we filter all Head request errors.
            return requestInfo.DebugInfo.RequestInfo.StartsWith("HEAD") || requestInfo.DebugInfo.RequestInfo.StartsWith("PROPFIND") || requestInfo.DebugInfo.RequestInfo.StartsWith("OPENVAS");// && requestInfo.OriginalException != null && requestInfo.OriginalException.Message == "The requested resource can only be accessed via SSL.";
        }
    }
}
