using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Routing;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class SitkaReverseProxy : IHttpHandler, IRouteHandler
    {
        /// <summary>
        /// The url path for the proxy
        /// </summary>
        public const string UrlPath = "SitkaReverseProxy";

        /// <summary>
        /// Name of the query string parameter for the proxy to work
        /// </summary>
        public const string QueryParameter = "ReverseProxyUrl";

        /// <summary>
        /// Use this to add the real URL you want in place
        /// </summary>
        public static string UrlBase
        {
            get { return String.Format("/{0}?{1}=", UrlPath, QueryParameter); } 
        }

        public void ProcessRequest(HttpContext context)
        {
            var whiteList = FirmaWebConfiguration.SitkaReverseProxyWhitelist;
            var url = CalculateTargetUrlFromCurrentRequestQueryString(context, whiteList);
            CopyUrlContentsToResponse(url, context);
        }

        public void ProcessRequest(string url, HttpContext context)
        {
            var whiteList = FirmaWebConfiguration.SitkaReverseProxyWhitelist;
            DemandUrlAllowedByWhitelist(whiteList, url);
            CopyUrlContentsToResponse(url, context);
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public static List<Uri> LoadWhiteList()
        {
            const string appSettingKeyName = "ReverseProxyWhitelist";
            var whiteList = SitkaConfiguration.GetOptionalAppSetting(appSettingKeyName);

            try
            {
                return ParseWhitelist(whiteList);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    string.Format("Problem while parsing configuration setting \"{0}\", check configuration file. Value: \"{1}\"",
                                  appSettingKeyName, whiteList),
                    ex);
            }
        }

        //public for testing only
        public string CalculateTargetUrlFromCurrentRequestQueryString(HttpContext context, List<Uri> whiteList)
        {
            var queryString = context.Request.Url.GetComponents(UriComponents.Query, UriFormat.UriEscaped);
            var url = HttpUtility.ParseQueryString(queryString)[QueryParameter];
            Check.Require(url != null, String.Format("The reverse proxy requires the {0} query parameter.", QueryParameter));                     
            DemandUrlAllowedByWhitelist(whiteList, url);
            return url;
        }

        private void DemandUrlAllowedByWhitelist(List<Uri> whiteList, string url)
        {
            var requestedUrl = new Uri(url);
            Check.Require(whiteList.Any(u => GetUriLeftPartPath(requestedUrl).StartsWith(GetUriLeftPartPath(u), StringComparison.InvariantCultureIgnoreCase)),
                          string.Format("Url {0} does not match the reverse proxy white list: '{1}'", url, string.Join(",", whiteList)));
        }

        //public for testing only
        public void CopyUrlContentsToResponse(string url, HttpContext context)
        {
            var outputResponse = context.Response;

            var newRequest = (HttpWebRequest) WebRequest.Create(url);
            newRequest.Method = context.Request.HttpMethod;
            newRequest.ContentType = context.Request.ContentType;

            if (context.Request.HttpMethod == "POST")
            {
                var originalRequestStream = context.Request.InputStream;
                var newRequestStream = newRequest.GetRequestStream();
                originalRequestStream.CopyTo(newRequestStream);
            }

            HttpWebResponse serverResponse; // response from the proxied server

            try
            {
                serverResponse = (HttpWebResponse) newRequest.GetResponse();
            }
            catch (WebException we)
            {
                if (we.Response == null)
                {
                    // didn't get a connection -- bad host
                    throw;
                }
                // For any http problems echo the problem across to the client
                serverResponse = (HttpWebResponse) we.Response;
            }

            outputResponse.StatusCode = (int)serverResponse.StatusCode;
            outputResponse.StatusDescription = serverResponse.StatusDescription;
            // This ClearHeaders is deemed OK since we WANT high-fidelity replication of whatever the proxied site is saying - we need to be transparent.
            // http://projects.sitkatech.com/projects/taurus/cards/3239
            outputResponse.ClearHeaders();
            outputResponse.ContentType = serverResponse.ContentType;
            CopyHeaderIfPresentAndNotNullOrWhitespace("Content-Disposition", serverResponse.Headers, outputResponse);

            var responseStream = serverResponse.GetResponseStream();
            outputResponse.ClearContent();

            if (responseStream != null)
            {
                responseStream.CopyTo(outputResponse.OutputStream);
            }

            serverResponse.Close();
            outputResponse.End();
        }

        private static void CopyHeaderIfPresentAndNotNullOrWhitespace(string nameOfHeaderToCopy, NameValueCollection serverHeaders, HttpResponse response)
        {
            var valueOfHeaderToCopy = serverHeaders[nameOfHeaderToCopy];
            if (!String.IsNullOrWhiteSpace(valueOfHeaderToCopy))
            {
                response.AppendHeader(nameOfHeaderToCopy, valueOfHeaderToCopy);
            }
        }

        //public for testing only
        public static List<Uri> ParseWhitelist(string whiteList)
        {
            if (String.IsNullOrWhiteSpace(whiteList))
            {
                return new List<Uri>();
            }
            return whiteList.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                .Where(h => !string.IsNullOrWhiteSpace(h))
                .Select(h => new Uri(h.Trim()))
                .ToList();
        }

        private string GetUriLeftPartPath(Uri uri)
        {
            return uri.GetLeftPart(UriPartial.Path);
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }
}